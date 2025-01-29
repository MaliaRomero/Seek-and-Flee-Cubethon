using UnityEngine;
using System.Collections;

namespace Chapter.Observer
{
    public abstract class Subject : MonoBehaviour
    {
        private readonly 
            ArrayList _observers = new ArrayList();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
            Debug.Log("Observer attached: " + observer.GetType());
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (Observer observer in _observers)
            {
                Debug.Log("Notifying observer: " + observer.GetType());
                observer.Notify(this);
            }
        }
    }
}