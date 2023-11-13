#include "pch.h"
#include "Histogram.h"
#include <cstdint>

int* GetHistogram(int width, int height, double* inValues)
{

	int* histValues = new int[UINT16_MAX];

	for (int i = 0; i < UINT16_MAX; i++)
		histValues[i] = 0;

	int totalLen = width * height;

	for (int c = 0; c < totalLen; c++) 
	{
		int currIdx = (int)(inValues[c]);
		histValues[currIdx] += 1;
	}

	return histValues;
}


