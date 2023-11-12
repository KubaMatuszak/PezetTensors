using System.Runtime.InteropServices;

namespace PZWrapper.Helpers
{
    public class MarshalHelper
    {
        public static double[] GetFromPtr(int len, IntPtr arrayPtr)
        {
            double[] managedArray = new double[len];
            Marshal.Copy(arrayPtr, managedArray, 0, len);
            Marshal.FreeHGlobal(arrayPtr);
            return managedArray;
        }




        public static bool TryPtrToArr(Func<IntPtr> func, int len, int[] outValues, Exception exception)
            => TryRun(func, (ptr) => { Marshal.Copy(ptr, outValues, 0, len); Marshal.FreeHGlobal(ptr); }, exception);

        public static bool TryPtrToArr(Func<IntPtr> func, int len, double[] outValues, Exception exception)
            => TryRun(func,
                      (ptr) =>
                          {
                              Marshal.Copy(ptr, outValues, 0, len);
                              Marshal.FreeHGlobal(ptr);
                          }, exception);


        public static bool TryRun(Func<IntPtr> func, Action<IntPtr> action, Exception exc)
        {
            if (func == null || action == null) return false;
            try
            {
                var ptr = func.Invoke();
                action(ptr);
            }
            catch (Exception e) { exc = e; }
            return true;
        }

        public static bool TryMarshallFill(Func<IntPtr> func, int len, int[] intArr, out Exception exception)
        {
            if (func == null)
            {
                exception = new Exception("func is null");
                return false;
            }

            exception = null;
            try
            {
                var mulPtr = func.Invoke();
                Marshal.Copy(mulPtr, intArr, 0, len);
                //Marshal.PtrToStructure;
                Marshal.FreeHGlobal(mulPtr);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return true;
        }


    }
}
