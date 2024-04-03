using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBluetooth.Platforms.Windows;
using Windows.Devices.Bluetooth;
using Windows.Devices.Radios;

[assembly: Dependency(typeof(BluetoothWin))]
namespace TestBluetooth.Platforms.Windows
{
	
	internal class BluetoothWin : IPlatformBluetooth
	{
		bool _btEnabled;
		string _debugMessage;


		public BluetoothWin()
		{
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
			checkradionew();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
		}

		public bool BluetoothEnabled => _btEnabled;

		public string DebugMessage => _debugMessage;

		async Task<bool> checkradionew()
		{
			Debug.WriteLine("Checking radio start");
			_debugMessage = "Checking adapter\r\n";
			BluetoothAdapter x = await BluetoothAdapter.GetDefaultAsync();
			_debugMessage += "adapter " + (x != null).ToString() + "\r\n";
			if (x != null)
			{
				try
				{
					_debugMessage += "x.GetRadioAsync()\r\n";
					var btradio = await x.GetRadioAsync();
					_debugMessage += "btradio " + (btradio != null).ToString() + "\r\n";
					if (btradio != null)
					{
						_debugMessage += "btradio state " + btradio.State + "r\n";
					}
				}
				catch (Exception ex)
				{
					_debugMessage += ex + "\r\n";
					if (ex.InnerException != null)
					{
						_debugMessage += ex.InnerException + "\r\n";
					}
				}
			}
			_debugMessage += "Checking radio\r\n";
			var radios = await Radio.GetRadiosAsync();
			_debugMessage += "got radios " + (radios != null).ToString() + "\r\n";
			var bluetoothRadio = radios.FirstOrDefault(radio => radio.Kind == RadioKind.Bluetooth);
			_debugMessage += "First or default " + (bluetoothRadio != null).ToString() + "\r\n";
			bool state = bluetoothRadio != null && bluetoothRadio.State == RadioState.On;
			_btEnabled = state;

			Debug.WriteLine("Checking radio finished");
			return _btEnabled;
		}
	}
}
