#include "pch.h"
#include "ExprAdapter.h"

/// <summary>
/// Accepts operands/operators in Polish notation.
/// </summary>
/// <param name="len"></param>
/// <param name="types"></param>
/// <param name="values"></param>
/// <param name="operators"></param>
/// <returns></returns>
EXPORTED_METHOD int CreateExpression(int len, OpType* types, double* values, OperatorNo* operators)
{

    int res = 1;
    for (int i = 0; i < len; i++) 
    {
        auto type = types[i];
        if (type == OpType::Val) 
        {
            res = res * 2;
        }
        else if(type == OpType::Num)
        {
            res = res * 3;
        }
        else if (type == OpType::Operator)
        {
            res = res * 5;
        }
    }

    return res;
}
