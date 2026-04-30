using System;
using System.IO.Ports;
using System.Windows;

namespace AircraftControl
{
    public partial class MainWindow : Window
    {
        private SerialPort _serialPort;
        
        public MainWindow()
        {
            InitializeComponent();
            _serialPort = new SerialPort();
        }
        
        private void ConnectToCOMPort(string portName)
        {
            _serialPort.PortName = portName;
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
        }
        
        private void PerformAircraftCalculations()
        {
            // TODO: Implement aircraft calculations
        }
        
        private void ManageControlSurfaces()
        {
            // TODO: Implement control surface management
        }
    }
}