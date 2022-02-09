using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;
using System.Text;

namespace ObserverTest
{
    public class InterfaceWay
    {
        public class DesktopApp : ITempatureMonitorObserver
        {
            public string OnTempatureChanged(double tempature)
            {
               return $"Desktop App被通知溫度變化了: {tempature}";
            }
        }
        public class MobileApp : ITempatureMonitorObserver
        {
            public string OnTempatureChanged(double tempature)
            {
                return $"Mobile App被通知溫度變化了: {tempature}";
            }
        }

        public interface ITempatureMonitorSubject
        {
            void RegisterObserver(ITempatureMonitorObserver observer);

            void UnregisterObserver(ITempatureMonitorObserver observer);

            void NotifyTempature();
        }

        // ITempatureMonitorObserver.cs
        public interface ITempatureMonitorObserver
        {
            string OnTempatureChanged(double tempature);
        }

        public class TempatureMonitorSubject : ITempatureMonitorSubject
        {
            private double tempature;

            public double Tempature
            {
                get { return tempature; }
                set
                {
                    var oldTempature = tempature;
                    if (oldTempature != value)
                    {
                        tempature = value;
                        NotifyTempature();
                    }
                }
            }

            private List<ITempatureMonitorObserver> observers;

            public TempatureMonitorSubject()
            {
                observers = new List<ITempatureMonitorObserver>();
                Console.WriteLine("開始偵測溫度");
            }

            public void RegisterObserver(ITempatureMonitorObserver observer)
            {
                observers.Add(observer);
            }

            public void UnregisterObserver(ITempatureMonitorObserver observer)
            {
                observers.Remove(observer);
            }

            public void NotifyTempature()
            {
                foreach (var observer in observers)
                {
                    observer.OnTempatureChanged(tempature);
                }
            }
        }

      

    }

}
