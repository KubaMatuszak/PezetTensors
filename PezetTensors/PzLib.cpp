#include "pch.h" // use stdafx.h in Visual Studio 2017 and earlier
#include <utility>
#include <limits.h>
#include "PzLib.h"


double Sum(int len, double* values) 
{
    double sum = 0;
    for (int i = 0; i < len; i++) 
    {
        sum += values[i];
    }
    return sum;
}

double MultiplyAHSum(int len, double* doublesA, double* doublesB) 
{
    double sum = 0;
    for (int i = 0; i < len; i++)
        sum += doublesA[i] * doublesB[i];
    return sum;
}

double* MultiplyIndiv(int len, double* doublesA, double* doublesB)
{
    double*  arr = new double[len];
    for (int i = 0; i < len; i++)
        arr[i] = doublesA[i] * doublesB[i];
    return arr;
}



double* MatrixMultiply(int nARows, int nAColsBRows, int nBCols, double* doublesA, double* doublesB)
{
    double* myDynamic2DArray = new double[nARows];

    
    for (int i = 0; i < nARows * nBCols; ++i) {
        myDynamic2DArray[i] = 0;
    }

    for (int i = 0; i < nARows; ++i) {
        for (int j = 0; j < nBCols; ++j) {
    
            myDynamic2DArray[i*nBCols + j] = 99.999; // Example formula, replace it with your logic
        }
    }
    return myDynamic2DArray;
}

void Inverse256(int len, double* doubles) 
{
    for (int i = 0; i < len; i++)
        doubles[i] = 255 - doubles[i];
}





int CppMethod(MyStruct* myStruct){
    int res = 0;
    for (int i = 0; i < 100000; i++) {
        for (int j = 0; j < 100000; j++) {
            res = i + j;
        }
    }
    return res;
}

double* ArrayCopy(int len, double* doubles)
{
    double* myDynamic2DArray = new double[len];


    for (int i = 0; i < len; i++) {
        myDynamic2DArray[i] = doubles[i];
    }
    return myDynamic2DArray;
}

double* ReturnDoubleArray(int size) {
    double* arr = new double[size];
    for (int i = 0; i < size; ++i) {
        arr[i] = i * 1.5; // Fill the array with some example data
    }
    return arr;
}

