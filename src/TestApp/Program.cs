using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var watcher = new System.Device.Location.GeoCoordinateWatcher(System.Device.Location.GeoPositionAccuracy.High);
            watcher.StatusChanged += (s, e) => Console.WriteLine($"Status changed: {e.Status}");
            watcher.PositionChanged += (s, e) => Console.WriteLine($"Position changed: {e.Position.Location.Latitude} , {e.Position.Location.Longitude} , {e.Position.Location.Altitude}  ");
            watcher.Start();
            Console.ReadKey();
            watcher.Stop();
        }
    }
}
