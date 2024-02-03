// Original License:
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ClrProfiling.Core;
using TestProfilers;
using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.Diagnostics.ClrProfiling;
using static Windows.Win32.System.Diagnostics.ClrProfiling.COR_PRF_MONITOR;
using static Windows.Win32.System.Diagnostics.ClrProfiling.COR_PRF_HIGH_MONITOR;

using unsafe ObjectHandleID = void**;
using ObjectID = nuint;
using ClassID = nuint;
using ClrProfiling.Shared;
using ClrProfiling.Helpers;
using Tests.Common.Utils;

namespace TestsProfilers;

[ProfilerCallback("A0F96622-522D-4654-AA56-BF421E79B210")]
internal unsafe class HandlesProfiler : TestProfilerBase
{
    private int _failures;
    private int _gcCount;
    private bool _isInduced;
    private ObjectHandleID _strongHandle = (void**)nint.Zero;
    private ObjectHandleID _weakHandle = (void**)nint.Zero;
    private ObjectHandleID _pinnedHandle = (void**)nint.Zero;
    private nuint _pinnedObject;
    private ICorProfilerInfo13* _corProfilerInfo13;

    // The goal of this test is to validate the ICorProfilerInfo13 handle management methods:
    //   CreateHandle (weak, strong, pinned)
    //   DestroyHandle
    //   GetObjectIDFromHandle
    //
    // SCENARIO:
    //   1. Specific managed types instances are created but no reference are kept.
    //   2. The corresponding native HandlesProfiler creates a handle for each.
    //   3. A gen2 GC is triggered
    //   --> HandlesProfiler ensures:
    //       - weak wrapped objects are no more alive
    //       - strong and pinned wrapped objects are still alive
    //   4. A gen2 is triggered.
    //   --> HandlesProfiler destroys strong and pinned handles + wrap the corresponding
    //       instances with a weak reference
    //   5. A gen2 is triggered.
    //   --> HandlesProfiler ensures that no more instances are alive.
    //
    public override HRESULT Initialize(IUnknown* unknown)
    {
        base.Initialize(unknown);

        if (Runtime.IsNet7OrGreater() == false)
        {
            Console.WriteLine("PROFILER TEST SKIPPED: This profiler is only supported for runtime version >= 7.0.0");
            return HRESULT.E_FAIL;
        }

        var hr = ProfilerInfo->QueryInterface(ICorProfilerInfo13.IID_Guid, out var pCorProfilerInfo13);

        if (hr.Failed)
        {
            Console.WriteLine($"Profiler.dll!Profiler::Initialize failed to QI for ICorProfilerInfo13.");
            return hr;
        }

        _corProfilerInfo13 = (ICorProfilerInfo13*)pCorProfilerInfo13;
        _corProfilerInfo13->AddRef();

        hr = ProfilerInfo->SetEventMask2(
            (uint)(COR_PRF_ENABLE_OBJECT_ALLOCATED | COR_PRF_MONITOR_OBJECT_ALLOCATED), 
            (uint)(COR_PRF_HIGH_BASIC_GC | COR_PRF_HIGH_MONITOR_LARGEOBJECT_ALLOCATED | COR_PRF_HIGH_MONITOR_PINNEDOBJECT_ALLOCATED));

        if (hr.Failed)
        {
            _failures++;
            Console.WriteLine($"SetEventMask2 failed with hr=0x{hr:x8}");
            return HRESULT.E_FAIL;
        }

        return HRESULT.S_OK;
    }

    private unsafe ObjectID CheckIfAlive(string name, ObjectHandleID handle, bool shouldBeAlive)
    {
        if (handle == null)
        {
            _failures++;
            Console.WriteLine($"HandlesProfiler::CheckIfAlive({name}): FAIL: null handle");
            return 0;
        }

        ObjectID objectId = 0;

        var hr = _corProfilerInfo13->GetObjectIDFromHandle(handle, &objectId);

        if (hr.Failed)
        {
            _failures++;
            Console.WriteLine($"HandlesProfiler::CheckIfAlive({name}): FAIL: GetObjectIDFromHandle failed.");
            return 0;
        }

        if (shouldBeAlive)
        {
            if (objectId == 0)
            {
                _failures++;
                Console.WriteLine($"HandlesProfiler::CheckIfAlive({name}): FAIL: the object should be alive");
            }
            else
            {
                Console.WriteLine($"HandlesProfiler::CheckIfAlive({name}): object alive as expected ");

                ClassID classId = 0;
                hr = ProfilerInfo->GetClassFromObject(objectId, &classId);

                if (hr.Failed)
                {
                    _failures++;
                    Console.WriteLine("(FAIL: impossible to get class from object).");
                }
                else
                {
                    ProfilerInfoHelpers.GetClassIDName((ICorProfilerInfo2*)ProfilerInfo, classId, out var className);
                    Console.WriteLine($"({className})");
                    return objectId;
                }
            }
        }
        else
        {
            if (objectId != 0)
            {
                _failures++;
                Console.WriteLine($"HandlesProfiler::CheckIfAlive({name}): FAIL: the object should not be alive anymore.");
            }
            else
            {
                Console.WriteLine($"HandlesProfiler::CheckIfAlive({name}): object not alive as expected.");
            }
        }

        return 0;
    }

    public override unsafe HRESULT GarbageCollectionStarted(int cGenerations, BOOL* generationCollected, COR_PRF_GC_REASON reason)
    {
        using var _ = new ShutdownGuard();

        if (ShutdownGuard.HasShutdownStarted())
        {
            return HRESULT.S_OK;
        }

        _isInduced = COR_PRF_GC_REASON.COR_PRF_GC_INDUCED == (reason & COR_PRF_GC_REASON.COR_PRF_GC_INDUCED);

        if (_isInduced)
        {
            _gcCount++;
        }

        return HRESULT.S_OK;
    }

    public unsafe override HRESULT ObjectAllocated(nuint objectId, nuint classId)
    {
        // Create handles for TestClassForWeakHandle, TestClassForStrongHandle and TestClassForPinnedHandle instances
        var hres = ProfilerInfoHelpers.GetClassIDName((ICorProfilerInfo2*)ProfilerInfo, classId, out var typeName);

        var tname = string.IsNullOrEmpty(typeName) ? "NULL" : typeName;

        Console.WriteLine($"0x{hres:x8} -> {tname}");

        var hr = HRESULT.S_OK;

        if (typeName == "Profiler.Tests.TestClassForWeakHandle")
        {
            fixed (void*** pWeakHandle = &_weakHandle)
            {
                hr = _corProfilerInfo13->CreateHandle(objectId, COR_PRF_HANDLE_TYPE.COR_PRF_HANDLE_TYPE_WEAK, pWeakHandle);
            }

            if (hr.Failed)
            {
                _failures++;
                Console.WriteLine("HandlesProfiler::ObjectAllocated: FAIL: CreateHandle failed for weak handle.");
            }
            else
            {
                Console.WriteLine("HandlesProfiler::ObjectAllocated: weak handle created.");
            }
        }
        else if (typeName == "Profiler.Tests.TestClassForStrongHandle")
        {
            fixed (void*** pStrongHandle = &_strongHandle)
            {
                hr = _corProfilerInfo13->CreateHandle(objectId, COR_PRF_HANDLE_TYPE.COR_PRF_HANDLE_TYPE_STRONG, pStrongHandle);
            }

            if (hr.Failed)
            {
                _failures++;
                Console.WriteLine("HandlesProfiler::ObjectAllocated: FAIL: CreateHandle failed for strong handle.");
            }
            else
            {
                Console.WriteLine("HandlesProfiler::ObjectAllocated: strong handle created.");
            }
        }
        else if (typeName == "Profiler.Tests.TestClassForPinnedHandle")
        {
            // Keep track of the address of the pinned object to be able
            // to check that it will not be moved by the next collection
            _pinnedObject = objectId;

            fixed (void*** pPinnedHandle = &_pinnedHandle)
            {
                hr = _corProfilerInfo13->CreateHandle(objectId, COR_PRF_HANDLE_TYPE.COR_PRF_HANDLE_TYPE_PINNED, pPinnedHandle);
            }

            if (hr.Failed)
            {
                _failures++;
                Console.WriteLine("HandlesProfiler::ObjectAllocated: FAIL: CreateHandle failed for pinned handle.");
            }
            else
            {
                Console.WriteLine("HandlesProfiler::ObjectAllocated: pinned handle created.");
            }
        }

        return HRESULT.S_OK;
    }

    public override unsafe HRESULT GarbageCollectionFinished()
    {
        using var _ = new ShutdownGuard();

        if (ShutdownGuard.HasShutdownStarted())
        {
            return HRESULT.S_OK;
        }

        if (!_isInduced)
        {
            return HRESULT.S_OK;
        }

        var hr = HRESULT.S_OK;

        if (_gcCount == 1)
        {
            // Weak should not be here anymore
            CheckIfAlive("weak", _weakHandle, false);

            // The others should still be alive
            CheckIfAlive("strong", _strongHandle, true);
            ObjectID pinnedObject = CheckIfAlive("pinned", _pinnedHandle, true);

            // Check that pinned object was not moved by the previous collection
            if (pinnedObject != _pinnedObject)
            {
                _failures++;
                Console.WriteLine("HandlesProfiler::GarbageCollectionFinished(#1): FAIL: pinned handle object address has changed.");
            }
            else
            {
                Console.WriteLine("HandlesProfiler::GarbageCollectionFinished(#1): pinned handle object address did not changed as expected.");
            }
        }
        else if (_gcCount == 2)
        {
            if (_strongHandle == null)
            {
                _failures++;
                Console.WriteLine("HandlesProfiler::GarbageCollectionFinished(#2): FAIL: null strong handle.");
                return HRESULT.S_OK;
            }
            if (_pinnedHandle == null)
            {
                _failures++;
                Console.WriteLine("HandlesProfiler::GarbageCollectionFinished(#2): FAIL: null pinned handle.");
                return HRESULT.S_OK;
            }

            // Keep a weak reference on them to be able to ensure that the instances
            // will be released after the next collection
            ObjectID strongObject = CheckIfAlive("strong", _strongHandle, true);
            ObjectID pinnedObject = CheckIfAlive("pinned", _pinnedHandle, true);

            // Destroy strong and pinned handles so next GC will release the objects
            hr = _corProfilerInfo13->DestroyHandle(_strongHandle);
            if (hr.Failed)
            {
                _failures++;
                Console.WriteLine("HandlesProfiler::GarbageCollectionFinished(#2): FAIL: DestroyHandle failed for strong handle.");
            }
            else
            {
                Console.WriteLine("HandlesProfiler::GarbageCollectionFinished(#2): strong handle destroyed.");
                
                fixed (void*** pStrongHandle = &_strongHandle)
                {
                    _corProfilerInfo13->CreateHandle(strongObject, COR_PRF_HANDLE_TYPE.COR_PRF_HANDLE_TYPE_WEAK, pStrongHandle);
                }
            }

            hr = _corProfilerInfo13->DestroyHandle(_pinnedHandle);

            if (hr.Failed)
            {
                _failures++;
                Console.WriteLine("HandlesProfiler::GarbageCollectionFinished(#2): FAIL: DestroyHandle failed for pinned handle.");
            }
            else
            {
                Console.WriteLine("HandlesProfiler::GarbageCollectionFinished(#2): pinned handle destroyed.");

                fixed (void*** pPinnedHandle = &_pinnedHandle)
                {
                    _corProfilerInfo13->CreateHandle(pinnedObject, COR_PRF_HANDLE_TYPE.COR_PRF_HANDLE_TYPE_WEAK, pPinnedHandle);
                }
            }
        }
        else if (_gcCount == 3)
        {
            Console.WriteLine("HandlesProfiler::GarbageCollectionFinished(#3): Checking handles:");

            // Check that instances wrapped by strong and pinned handles are not here any more
            CheckIfAlive("strong", _strongHandle, false);
            CheckIfAlive("pinned", _pinnedHandle, false);
        }
        else
        {
            _failures++;
            Console.WriteLine("HandlesProfiler::GarbageCollectionStarted: FAIL: no more than 3 garbage collections are expected.");
        }

        return HRESULT.S_OK;
    }

    public override HRESULT Shutdown()
    {
        var hr = base.Shutdown();

        if (_corProfilerInfo13 != null)
            _corProfilerInfo13->Release();

        if (hr.Failed) return hr;

        if (_gcCount == 0)
        {
            Console.WriteLine("HandlesProfiler::Shutdown: FAIL: Expected GarbageCollectionStarted to be called");
        }
        else if (_failures == 0)
        {
            Console.WriteLine("PROFILER TEST PASSES");
        }
        else
        {
            // failures were printed earlier when _failures was incremented
        }

        Console.Out.Flush();

        return HRESULT.S_OK;
    }
}
