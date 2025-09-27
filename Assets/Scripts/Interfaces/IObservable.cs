using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IObservable
    {
        public List<IObserver> Observers { get; }
        public void RegisterObserver(IObserver ob)
        {
            Observers.Add(ob);
        }
        public void UnregisterObserver(IObserver ob)
        {
            Observers.Remove(ob);
        }
        public void Raise()
        {
            foreach(IObserver observer in Observers)
            {
                observer.OnEventRaised();
            }
        }
    }

}