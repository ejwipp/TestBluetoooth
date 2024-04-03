namespace TestBluetooth
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		IPlatformBluetooth _platformBT = DependencyService.Get<IPlatformBluetooth>();

		public MainPage()
		{
			InitializeComponent();

		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			if (_platformBT.BluetoothEnabled)
			{
				labelBluetoothEnabled.Text = "Enabled";
			}
			else
			{
				labelBluetoothEnabled.Text = "Disabled";
			}

			editorDebug.Text = _platformBT.DebugMessage;

		}
	}

}
