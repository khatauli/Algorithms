using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LocationTracker : IObservable<Location>
    {
        private List<IObserver<Location>> observers = new List<IObserver<Location>>();
        public IDisposable Subscribe(IObserver<Location> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new Unsubscriber(observers, observer);
        }

        public void Notify()
        {
            observers.ForEach(x => x.OnNext(new Location(1.2, 4)));
        }
    }

    public class Unsubscriber : IDisposable
    {
        public Unsubscriber(List<IObserver<Location>> observers, IObserver<Location> observer)
        {
            this.Observers = observers;
            this.Observer = observer;
        }

        public List<IObserver<Location>> Observers { get; set; }
        public IObserver<Location> Observer { get; set; }

        public void Dispose()
        {
            this.Observers.Remove(this.Observer);
        }
    }
}
