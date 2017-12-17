using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //https://msdn.microsoft.com/en-us/library/dd783449%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
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