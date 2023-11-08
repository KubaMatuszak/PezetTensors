using PZWrapper.Extensions;
using PZWrapper.Links;
using System.Drawing;
using System.Runtime.InteropServices;
using Windows.UI;

namespace PZWrapper.Types
{

    //public class BWImage
    //{
    //    public int Width;
    //    public int Height;
    //    public double[,] Data;
    //    public BWImage() { }
    //    public BWImage(int width, int height) { }
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    //    public BWImage(string filename)
    //    {
    //        if (filename == null) throw new ArgumentNullException("filename");
    //        Bitmap bitmap = new Bitmap(filename);
    //        Width = bitmap.Width;
    //        Height = bitmap.Height;
    //        Data = new double[Height, Width];
    //        this.ForEach((r, c) => Data[r, c] = bitmap.GetPixel(c, r).ToGrayDouble());
    //    }

    //    public BWImage(Matrix2D matrix)
    //    {
    //        Data = matrix.Values;
    //        Height = matrix.NRows;
    //        Width = matrix.NCols;
    //    }
    //}
}
