project(hooks  LANGUAGES CXX)

enable_language(C ASM_MASM)

SET (CMAKE_LINK_DEF_FILE_FLAG "/DEF:hooks.def")

add_library(${PROJECT_NAME} SHARED hooks.cpp hooks_asm.asm hooks.def)

set_target_properties(
        ${PROJECT_NAME} PROPERTIES
        CXX_STANDARD 20
        CXX_STANDARD_REQUIRED ON
)