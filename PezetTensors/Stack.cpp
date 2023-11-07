#include "pch.h"
#include "Stack.h"

Stack::Stack()
{

}

Stack::Stack(int len, OpType* types, double* values, OperatorNo* operators)
{

    int res = 1;
    for (int i = 0; i < len; i++)
    {
        auto type = types[i];
        if (type == OpType::Val)
        {
            res = res * 2;
        }
        else if (type == OpType::Num)
        {
            res = res * 3;
        }
        else if (type == OpType::Operator)
        {
            res = res * 5;
        }
    }

    Cells = new StackCell[len];

    for (int i = 0; i < len; i++)
    {
        auto type = types[i];
        if (type == OpType::Val)
        {
            res = res * 2;
        }
        else if (type == OpType::Num)
        {
            res = res * 3;
        }
        else if (type == OpType::Operator)
        {
            res = res * 5;
        }
    }


};
