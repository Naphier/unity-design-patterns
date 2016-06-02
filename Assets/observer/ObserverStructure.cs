using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.observer.structure
{
    interface IObserver
    {
        void Update();
    }

    abstract class Subject
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }
        
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                _observers[i].Update();
            }
        }
    }

    class ConcreteSubject : Subject
    {
        private string _subjectState;

        // Usually want to run notify from this accessor's setter.
        public string SubjectState
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }
    }

    class ConcreteObserver : IObserver
    {
        private string _name;
        private string _observerState;
        private ConcreteSubject _subject;

        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            _subject = subject;
            _name = name;
        }

        public void Update()
        {
            _observerState = _subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}",
                _name, _observerState);
        }

        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
    }

    class MainApp
    {
        public void Run()
        {
            ConcreteSubject s = new ConcreteSubject();
            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            //Change the subject and notify observers
            s.SubjectState = "ABC";
            s.Notify();

            Console.Read();
        }
    }
}
