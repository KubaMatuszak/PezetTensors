#pragma once
#define EXPORTED_METHOD extern "C" __declspec(dllexport)
#include "OpType.h"

enum class OperatorNo : int
{
    None = 0,
    Opp = 1,
    Inv = 2,
    Squ = 10,
    Cub = 11,
    RootSq = 15,
    RootCub = 16,
    LogN = 17,
    ExpN = 18,
    Add = 5,
    Sub = 6,
    Mul = 7,
    Div = 8,
    Pow = 20,
    Log = 21
};

enum class OpType : int
{
    Start = -99,
    Val = 0,
    Num = 10,
    Operator = 20
};

//public OpType OpType;
//public double DoubleValue;
//public OperatorNo OperatorNo;

EXPORTED_METHOD int CreateExpression(int len, OpType* types, double* values, OperatorNo* operators);
