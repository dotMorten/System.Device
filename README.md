### System.Device

.NET Core 3.0 port of System.Device.Location APIs from .NET Reference Source.

Based on commit: https://github.com/microsoft/referencesource/commit/bf498ea2b1a6270a2fe5cb122acf4b1c5b45c21d

Original source code is MIT. See: https://github.com/microsoft/referencesource/blob/master/LICENSE.txt

### Note:
The GeoCoordinate APIs are wrapping the Location COM APIs. Those were deprecated in Windows 8. 
If you don't need Windows 7 support, I'd encourage you to port your code to use the WinRT GeoLocation APIs instead. You can get these by adding a reference to [Microsoft.Windows.SDK.Contracts](https://www.nuget.org/packages/Microsoft.Windows.SDK.Contracts/).

Old `System.Device.Location` code:
```cs
var watcher = new System.Device.Location.GeoCoordinateWatcher(System.Device.Location.GeoPositionAccuracy.High);
watcher.StatusChanged += (s, e) => Debug.WriteLine($"Status changed: {e.Status}");
watcher.PositionChanged += (s, e) => Debug.WriteLine($"Position changed: {e.Position.Location.Latitude} , {e.Position.Location.Longitude} , {e.Position.Location.Altitude}  ");
watcher.Start();
```
New `Windows.Devices.Geolocation` equivalent code:
```cs
var locator = new Windows.Devices.Geolocation.Geolocator() { DesiredAccuracy = Windows.Devices.Geolocation.PositionAccuracy.High };
locator.StatusChanged += (s, e) => Debug.WriteLine($"Status changed: {e.Status}");
locator.PositionChanged += (s, e) => Debug.WriteLine($"Position changed: {e.Position.Coordinate.Point.Position.Latitude} , {e.Position.Coordinate.Point.Position.Longitude} , {e.Position.Coordinate.Point.Position.Altitude}  ");
```
