using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.IO.Ports;

namespace Yak130Controller {
    public partial class MainWindow : Window {
        private SerialPortManager serialPortManager;
        private ControlSurfaceManager controlSurfaceManager;
        private Yak130Aerodynamics aerodynamics;
        private ObservableCollection<string> comPorts;

        public MainWindow() {
            InitializeComponent();
            Initialize();
        }

        private void Initialize() {
            serialPortManager = new SerialPortManager();
            controlSurfaceManager = new ControlSurfaceManager();
            aerodynamics = new Yak130Aerodynamics();
            comPorts = new ObservableCollection<string>();
            RefreshComPorts();
            SetupEventHandlers();
        }

        private void RefreshComPorts() {
            comPorts.Clear();
            foreach (string port in SerialPort.GetPortNames()) {
                comPorts.Add(port);
            }
            ComPortComboBox.ItemsSource = comPorts;
        }

        private void SetupEventHandlers() {
            serialPortManager.ConnectionStatusChanged += (s, msg) => StatusLabel.Content = msg;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e) {
            RefreshComPorts();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e) {
            if (ComPortComboBox.SelectedItem != null) {
                string port = ComPortComboBox.SelectedItem.ToString();
                serialPortManager.Connect(port);
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e) {
            double speed = double.Parse(SpeedTextBox.Text ?? "0");
            double altitude = double.Parse(AltitudeTextBox.Text ?? "0");
            double angle = double.Parse(AngleTextBox.Text ?? "0");

            var (lift, drag, thrust, ailerons, flaps, rudderYaw, rudderPitch) = aerodynamics.CalculateAircraftCharacteristics(speed, altitude, angle);

            controlSurfaceManager.SetAileronDeflection((float)ailerons);
            controlSurfaceManager.SetFlapDeflection((float)flaps);
            controlSurfaceManager.SetRudderYawDeflection((float)rudderYaw);
            controlSurfaceManager.SetRudderPitchDeflection((float)rudderPitch);

            string command = $"E:{ailerons:F1}|F:{flaps:F1}|R:{rudderYaw:F1}|P:{rudderPitch:F1}\n";
            serialPortManager.SendCommand(command);

            LiftLabel.Content = $"Подъемная сила: {lift:F2} N";
            DragLabel.Content = $"Сопротивление: {drag:F2} N";
            ThrustLabel.Content = $"Тяга: {thrust:F2} N";
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e) {
            serialPortManager.Disconnect();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            serialPortManager.Disconnect();
        }
    }
}