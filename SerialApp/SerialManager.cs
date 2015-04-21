using System;
using System.IO.Ports;

namespace SerialApp
{
	internal class SerialManager: IDisposable
	{
		private readonly SerialPort _port;

		public SerialManager(string port)
		{
			_port = new SerialPort(port) {DtrEnable = true, NewLine = Environment.NewLine};
			_port.DataReceived += OnDataReceived;
			_port.Open();
		}

		private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			Console.WriteLine("> {0}", _port.ReadExisting());
		}

		public void Send(string line)
		{
			_port.WriteLine(line);
		}

		public void Dispose()
		{
			_port.Dispose();
		}
	}
}