#pragma once
#include "ExprAdapter.h"
class StackCell
{
	//OpType* types, double* values, OperatorNo* operators
public:
	OpType Type;
	double Value;
	OperatorNo OperatorNum;
	StackCell(OpType type, double value, OperatorNo operator1);
	StackCell();
};

