using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper.Types
{



    /// <summary>
    /// Class represents black and white image.
    /// </summary>
    public class ColorImage
    {
        public int Width;
        public int Height;
        public byte[,,] Data;
        public ColorImage() { }
        public ColorImage(int width, int height) { }
        public ColorImage(string filename) 
        {
            if(filename == null) throw new ArgumentNullException("filename");
            Bitmap bitmap = new Bitmap(filename);
            Width = bitmap.Width;
            Height = bitmap.Height;
            Data = new byte[Height, Width, 1];
            for(int rowNo = 0; rowNo < Height; rowNo++) 
                for(int colNo = 0; colNo < Width; colNo++)
                {
                    var col = bitmap.GetPixel(colNo, rowNo);
                    Data[rowNo, colNo, 0] = col.R;
                    Data[rowNo, colNo, 1] = col.G;
                    Data[rowNo, colNo, 2] = col.B;
                }
            
        }
        public ColorImage(Bitmap bitmap) 
        {
            
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public Bitmap ToBitmap()
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            for (int rowNo = 0; rowNo < Height; rowNo++)
                for (int colNo = 0; colNo < Width; colNo++)
                {
                    var col = Color.FromArgb(Data[rowNo, colNo, 0], Data[rowNo, colNo, 0], Data[rowNo, colNo, 0]);
                    bitmap.SetPixel(colNo, rowNo, col);
                }
            return bitmap;
        }

        public ColorImage ForEachPixChanClone(Func<byte,byte> func)
        {
            ColorImage cloned = new ColorImage(Width, Height);
            for (int rowNo = 0; rowNo < Height; rowNo++)
                for (int colNo = 0; colNo < Width; colNo++)
                {
                    var r = Data[rowNo, colNo, 0];
                    var g = Data[rowNo, colNo, 1];
                    var b = Data[rowNo, colNo, 2];

                    var r1 = func.Invoke(r);
                    var g1 = func.Invoke(g);
                    var b1 = func.Invoke(b);

                    cloned.Data[rowNo, colNo, 0] = r1;
                    cloned.Data[rowNo, colNo, 1] = g1;
                    cloned.Data[rowNo, colNo, 2] = b1;
                }
            return cloned;
        }

        public ColorImage Clone()
        {
            ColorImage cloned = new ColorImage(Width, Height);
            for (int rowNo = 0; rowNo < Height; rowNo++)
                for (int colNo = 0; colNo < Width; colNo++)
                {
                    var r = Data[rowNo, colNo, 0];
                    var g = Data[rowNo, colNo, 1];
                    var b = Data[rowNo, colNo, 2];
                    cloned.Data[rowNo, colNo, 0] = r;
                    cloned.Data[rowNo, colNo, 1] = g;
                    cloned.Data[rowNo, colNo, 2] = b;
                }
            return cloned;
        }

    }
}
