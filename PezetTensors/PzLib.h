#pragma once


//#define PezetTensors_API __declspec(dllimport)
#define PezetTensors_API __declspec(dllexport)

struct MyStruct 
{
    int a;
    char b;
};

struct IntArrayOneD 
{
    double* values;
};

#define EXPORTED_METHOD extern "C" __declspec(dllexport)
 
EXPORTED_METHOD int CppMethod(MyStruct* myStruct);
EXPORTED_METHOD double Sum(int len, double* values);
EXPORTED_METHOD double MultiplyAHSum(int len, double* doublesA, double* doublesB);
EXPORTED_METHOD double* MultiplyIndiv(int len, double* doublesA, double* doublesB);
EXPORTED_METHOD double* MatrixMultiply(int nARows, int nAColsBRows, int nBCols, double* doublesA, double* doublesB);
EXPORTED_METHOD void Inverse256(int len, double* doubles);
EXPORTED_METHOD double* ArrayCopy(int len, double* doubles);
EXPORTED_METHOD double* ReturnDoubleArray(int size);
