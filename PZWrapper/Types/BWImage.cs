using PZWrapper.Extensions;
using PZWrapper.Links;
using System.Drawing;
using System.Runtime.InteropServices;
using Windows.UI;

namespace PZWrapper.Types
{

    public class BWImage
    {
        public int Width;
        public int Height;
        public double[,] Data;
        public BWImage() { }
        public BWImage(int width, int height) { }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public BWImage(string filename)
        {
            if (filename == null) throw new ArgumentNullException("filename");
            Bitmap bitmap = new Bitmap(filename);
            Width = bitmap.Width;
            Height = bitmap.Height;
            Data = new double[Height, Width];
            for (int rowNo = 0; rowNo < Height; rowNo++)
                for (int colNo = 0; colNo < Width; colNo++)
                {
                    var col = bitmap.GetPixel(colNo, rowNo);
                    Data[rowNo, colNo] = (double)(col.R + col.G + col.B)/3;
                }
            this.ForEach((r, c) => Data[r, c] = bitmap.GetPixel(c, r).ToGrayDouble());
        }

        public BWImage(Bitmap bitmap)
        {

        }


        public BWImage(Matrix2D matrix)
        {
            Data = matrix.Values;
            Height = matrix.NRows;
            Width = matrix.NCols;
        }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        //public Bitmap ToBitmap()
        //{
        //    Bitmap bitmap = new Bitmap(Width, Height);
        //    ForEach((r, c) => bitmap.SetPixel(c, r, Data[r, c].ToGrayColor()));
        //    return bitmap;
        //}

        //public BWImage ForEachPixChanClone(Func<double, double> func)
        //{
        //    BWImage cloned = new BWImage(Width, Height);
        //    ForEach((r, c) => cloned.Data[r, c] = func.Invoke(r));
        //    return cloned;
        //}

        //public BWImage Clone()
        //{
        //    BWImage cloned = new BWImage(Width, Height);
        //    ForEach((r, c) => cloned.Data[r, c] = Data[r, c]);
        //    return cloned;
        //}


        //public Matrix2D ToMatrix2D() => new Matrix2D(Data);



        //public void ForEach(Action<int, int> action)
        //{
        //    for (int rowNo = 0; rowNo < Height; rowNo++)
        //        for (int colNo = 0; colNo < Width; colNo++)
        //        {
        //            action.Invoke(rowNo, colNo);
        //        }
        //}

    }
}
