﻿using PZWrapper.Types;
using ZImageTests.Process.Generics;
using ZImageTests.Types.Elementary;
using PZWrapper.Links;

namespace ZImageTests.Process.Simples
{
    public class ArrayCopyProcess : ABwProcess
    {
        public override string ProcessName => GetType().Name;
        public override ProcessResult<Matrix2D> Process(Matrix2D inputMatrix)
        {
            var blurIm = Marshaled.ArrayCopy(inputMatrix);
            ProcessResult<Matrix2D> result = new ProcessResult<Matrix2D>();
            result.IsOk = true;
            result.ResBwIm = blurIm;
            return result;
        }

    }

}
