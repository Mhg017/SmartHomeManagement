using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartHomeManagement
{
    public partial class MainWindow : Window
    {
        private CustomDictionary<string, string> deviceDictionary;

        public MainWindow()
        {
            InitializeComponent();
            deviceDictionary = new CustomDictionary<string, string>();
        }

        private void AddDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            string deviceId = DeviceIdTextBox.Text;
            string status = ((ComboBoxItem)StatusComboBox.SelectedItem).Content.ToString();

            if (!string.IsNullOrEmpty(deviceId) && !string.IsNullOrEmpty(status))
            {
                deviceDictionary.Add(deviceId, status);
                RefreshDeviceList();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Please enter both Device ID and Status.");
            }
        }

        private void UpdateStatusButton_Click(object sender, RoutedEventArgs e)
        {
            string deviceId = DeviceIdTextBox.Text;
            string status = ((ComboBoxItem)StatusComboBox.SelectedItem).Content.ToString();

            if (deviceDictionary.ContainsKey(deviceId))
            {
                deviceDictionary.Update(deviceId, status);
                RefreshDeviceList();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Device ID not found.");
            }
        }

        private void RemoveDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            string deviceId = DeviceIdTextBox.Text;

            if (deviceDictionary.ContainsKey(deviceId))
            {
                deviceDictionary.Remove(deviceId);
                RefreshDeviceList();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Device ID not found.");
            }
        }

        private void RefreshDeviceList()
        {
            DevicesListBox.Items.Clear();
            foreach (var item in deviceDictionary.GetAllItems())
            {
                DevicesListBox.Items.Add($"{item.Key}: {item.Value}");
            }
        }

        private void ClearInputs()
        {
            DeviceIdTextBox.Clear();
            StatusComboBox.SelectedIndex = -1;
        }
    }
}