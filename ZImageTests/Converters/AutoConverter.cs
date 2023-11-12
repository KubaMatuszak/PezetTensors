using PZWrapper.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PZWrapper.Extensions;
using PZControlsWpf.ImageHelpers;

namespace PZControlsWpf.Converters
{
    public abstract class AutoConverter
    {
        private static AutoConverter _convChain = new BWImage2ImageSourceConv().SetNext(new Matrix2DImageSourceConv()).Root;
        public static AutoConverter ConvChain => _convChain;
        public abstract Type TypeIn { get;}
        public abstract Type TypeOut { get;}
        public AutoConverter Next { get; set; }
        public AutoConverter Prev { get; set; }
        public AutoConverter Root => Prev == null ? this: Prev.Root;
        public AutoConverter SetNext(AutoConverter next)
        {
            Next = next;
            next.Prev = this;
            return next;
        }
        public bool CanConvert<Tin, Tout>(Tin typeIn, Tout type2) => typeof(Tin) == TypeIn && typeof(Tout) == TypeOut;
        public Tout Convert<Tin, Tout>(Tin inputObj) where Tin : class where Tout : class 
        {
            Tout outputObj = null;
            if (false == CanConvert(inputObj, outputObj) || inputObj == null)
                return null;
            return Func.Invoke(inputObj) as Tout;
        }
        public abstract Func<object, object> Func { get; }
    }

    public class BWImage2ImageSourceConv : AutoConverter
    {
        public override Type TypeIn => typeof(Matrix2D);
        public override Type TypeOut => typeof(ImageSource);
        public override Func<object, object> Func => (o) => ((Matrix2D)System.Convert.ChangeType(o, typeof(Matrix2D))).ToBitmap().ToImageSource();

    }

    public class Matrix2DImageSourceConv : AutoConverter
    {
        public override Type TypeIn => typeof(Matrix2D);
        public override Type TypeOut => typeof(ImageSource);
        public override Func<object, object> Func => (o) => ((Matrix2D)System.Convert.ChangeType(o, typeof(Matrix2D))).ToBitmap().ToImageSource();
    }


}
