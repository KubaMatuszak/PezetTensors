#include "pch.h" // use stdafx.h in Visual Studio 2017 and earlier
#include "PZMath.h"
#include <utility>
#include <limits.h>
#include <functional>

int Clip(int val, int min, int max)
{
	int lol = val < min ? min : val > max ? max : val;
	return lol;
}
