using CorProf.Bindings;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.ComWrappers;
using ICorProfilerCallback4 = ManagedCorProfiler.ComInterop.Interfaces.ICorProfilerCallback4;

namespace ManagedCorProfiler.ComInterop.Wrappers
{
    public unsafe static class ICorProfilerCallback4ManagedWrapper
    {
        [UnmanagedCallersOnly]
        public static unsafe int ReJITCompilationStarted(IntPtr _this, ulong functionId, ulong rejitId, int fIsSafeToBlock)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback4>((ComInterfaceDispatch*)_this)
                    .ReJITCompilationStarted(functionId, rejitId, fIsSafeToBlock);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
        [UnmanagedCallersOnly]
        public static unsafe int GetReJITParameters(IntPtr _this, ulong moduleId, uint methodId, ICorProfilerFunctionControl* pFunctionControl)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback4>((ComInterfaceDispatch*)_this)
                    .GetReJITParameters(moduleId, methodId, pFunctionControl);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
        [UnmanagedCallersOnly]
        public static unsafe int ReJITCompilationFinished(IntPtr _this, ulong functionId, ulong rejitId, int hrStatus, int fIsSafeToBlock)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback4>((ComInterfaceDispatch*)_this)
                    .ReJITCompilationFinished(functionId, rejitId, hrStatus, fIsSafeToBlock);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
        [UnmanagedCallersOnly]
        public static unsafe int ReJITError(IntPtr _this, ulong moduleId, uint methodId, ulong functionId, int hrStatus)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback4>((ComInterfaceDispatch*)_this)
                    .ReJITError(moduleId, methodId, functionId, hrStatus);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
        [UnmanagedCallersOnly]
        public static unsafe int MovedReferences2(IntPtr _this, uint cMovedObjectIDRanges, ulong* oldObjectIDRangeStart, ulong* newObjectIDRangeStart, ulong* cObjectIDRangeLength)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback4>((ComInterfaceDispatch*)_this)
                    .MovedReferences2(cMovedObjectIDRanges, oldObjectIDRangeStart, newObjectIDRangeStart, cObjectIDRangeLength);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
        [UnmanagedCallersOnly]
        public static unsafe int SurvivingReferences2(IntPtr _this, uint cSurvivingObjectIDRanges, ulong* objectIDRangeStart, ulong* cObjectIDRangeLength)
        {
            try
            {
                var hr = ComInterfaceDispatch
                    .GetInstance<ICorProfilerCallback4>((ComInterfaceDispatch*)_this)
                    .SurvivingReferences2(cSurvivingObjectIDRanges, objectIDRangeStart, cObjectIDRangeLength);

                return hr;
            }
            catch (Exception ex)
            {
                return ex.HResult;
            }
        }
    }
}
