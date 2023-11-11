#include "pch.h"
#include "Cropping.h"

EXPORTED_METHOD double* CroppCutMargin(int width, int height, double* inVals, int left, int top, int right, int bottom)
{

	int xStart = left;
	int yStart = top;
	int xEnd = width - right - 1;
	int yEnd = height - bottom - 1;

	int outWidth = width - right - left;
	int outHeight = height - bottom - top;


	int outLen = outWidth * outHeight;

	double* outVals = new double[outLen]; 

	for (int sr = yStart; sr <= yEnd; sr++)
	{
		for (int sc = xStart; sc <= xEnd; sc++)
		{
			outVals[(sr - yStart) * outWidth + sc - xStart] = inVals[sr*width + sc];
			//outVals[(sr - yStart) * outWidth + sc - xStart] = (sr + sc) % 100 > 50 ? 251 : 2;  //inVals[sr, sc];
		}
		
	}

	return outVals;
}
