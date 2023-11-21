using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ZImageTests.Visualisation
{

    public static class BackJobs
    {

        public static void RunAndInformDispatched<Tin>(Dispatcher dispatcher, Func<Tin> func, Action<Tin> func1, bool asBackground = false)
        {
            if (asBackground)
            {
                var t1 = DateTime.Now;
                var task = Task.Factory.StartNew(() =>
                {
                    var res = func.Invoke();
                    dispatcher.Invoke(new Action(() => { func1.Invoke(res); }));
                    Thread.Sleep(10000);
                });

                var t2 = DateTime.Now;
                var diff = (t2 - t1).TotalMilliseconds;
            }
            else
            {
                var res = func.Invoke();
                func1.Invoke(res);
            }
        }
    }
}
