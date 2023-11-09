#pragma once
#define EXPORTED_METHOD extern "C" __declspec(dllexport)

EXPORTED_METHOD double* SampleBlur(int len, double* doubles);