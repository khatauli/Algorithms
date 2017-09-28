using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //https://www.youtube.com/watch?v=LBsvAwQbVdw
    class Program
    {
        static void Main(string[] args)
        {
            var observable = new LocationTracker();

            var observer = new LocationReporter();

            observer.RegisterSelf(observable);

            observable.Notify();

        }
    }
}