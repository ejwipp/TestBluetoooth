using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBluetooth
{
	internal interface IPlatformBluetooth
	{
		Boolean BluetoothEnabled
		{
			get;
		}

		String DebugMessage {get; }
	}
}
