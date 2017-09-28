using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LocationReporter : IObserver<Location>
    {
        IDisposable unsubscriber;

        public virtual void RegisterSelf (IObservable<Location> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public void OnCompleted()
        {
            this.Unsubscribe();
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }


        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Location value)
        {
            Console.WriteLine($"latitude : {value.Latitude}, Longitude : {value.Longitude}");
        }
    }
}
