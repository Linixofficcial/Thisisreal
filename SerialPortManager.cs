using System;
using System.IO.Ports;
using System.Threading;

public class SerialPortManager
{
    private SerialPort _serialPort;

    public void Connect(string portName, int baudRate = 9600)
    {
        _serialPort = new SerialPort(portName, baudRate);
        _serialPort.Open();
        Console.WriteLine("Connected to " + portName);
    }

    public void Disconnect()
    {
        if (_serialPort != null && _serialPort.IsOpen)
        {
            _serialPort.Close();
            Console.WriteLine("Disconnected.");
        }
    }

    public void SendCommand(string command)
    {
        if (_serialPort != null && _serialPort.IsOpen)
        {
            _serialPort.WriteLine(command);
            Console.WriteLine("Sent: " + command);
        }
    }

    public string ReceiveData()
    {
        if (_serialPort != null && _serialPort.IsOpen)
        {
            string data = _serialPort.ReadLine();
            Console.WriteLine("Received: " + data);
            return data;
        }
        return null;
    }
}
