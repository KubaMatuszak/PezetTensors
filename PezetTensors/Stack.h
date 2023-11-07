#pragma once
#include "StackCell.h"
#include "ExprAdapter.h"


class Stack
{
public:
	Stack();
	Stack(int len, OpType* types, double* values, OperatorNo* operators);
	int StackHeight = 0;
	StackCell* Cells;
};

