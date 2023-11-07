#include "pch.h"
#include "StackCell.h"

StackCell::StackCell()
{
	
}

StackCell::StackCell(OpType type, double value, OperatorNo operator1) 
{
	Type = type;
	Value = value;
	OperatorNum = operator1;
}