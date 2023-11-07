// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"


struct MyStruct {
    int a;
    char b;
};

#define EXPORTED_METHOD extern "C" __declspec(dllexport)

EXPORTED_METHOD int CppMethod(MyStruct* myStruct)
{
    return myStruct->a * 20;
}


EXPORTED_METHOD int CppTestFunc()
{
    return 20;
}


BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

