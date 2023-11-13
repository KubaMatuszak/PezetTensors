#include "pch.h"
#include "Blur.h"



double* SampleBlur(int len, double* inValues)
{
	int rad = 4;
    double* outValues = new double[len];

    for (int i = 0; i < len; i++)
    {
        outValues[i] = inValues[i];
    }
    return outValues;
}