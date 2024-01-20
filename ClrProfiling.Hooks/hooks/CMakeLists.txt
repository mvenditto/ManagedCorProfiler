cmake_minimum_required(VERSION 3.5 FATAL_ERROR)

project(hooks LANGUAGES CXX)

enable_language(C ASM_MASM)

# objs for static linking
if (HOOKS_LIB_TYPE STREQUAL "static")
    message("Hooks version: ${HOOKS_VERSION}")

    set_source_files_properties(
        hooks.asm
        PROPERTIES
        COMPILE_FLAGS "/D${HOOKS_VERSION}")

    set_source_files_properties(
	    hooks.cpp
        PROPERTIES
        COMPILE_FLAGS "/D${HOOKS_VERSION}")

    add_library(hooks OBJECT hooks.cpp hooks.asm)
endif()

# shared library for dynamic loading
if (HOOKS_LIB_TYPE STREQUAL "shared")

    SET (CMAKE_LINK_DEF_FILE_FLAG "/DEF:hooks.def")

    set (ELT_VERSION_ALL_FLAGS "/DELT3 /DELT2")

    set_source_files_properties(
	    hooks.asm
        PROPERTIES
        COMPILE_FLAGS "${ELT_VERSION_ALL_FLAGS}")

    set_source_files_properties(
	    hooks_dyn.cpp
        PROPERTIES
        COMPILE_FLAGS "${ELT_VERSION_ALL_FLAGS}")

    add_library(hooks SHARED hooks_shared.cpp hooks.asm hooks.def)
endif()

set_target_properties(
    hooks 
    PROPERTIES
    CXX_STANDARD 20
    CXX_STANDARD_REQUIRED ON
)