using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Management;

namespace Screen_Brightness_Adjuster
{
    public partial class WindowsServices : Form
    {
        private static ManagementObject _brightnessInstance;
        private static ManagementBaseObject _brightnessClass;
        private static int a;

        public static int espInput;

        public int Algorithm1(int i)
        {
            return a = 100 - (i / 4000) * 100;
        }

        public WindowsServices()
        {
            InitializeComponent();
        }

        static WindowsServices()
        {
            // Querying the Windows service to get the Brightness API.
            var searcher = new ManagementObjectSearcher(
                "root\\WMI",
                "SELECT * FROM WmiMonitorBrightness");

            var results = searcher.Get();
            var resultEnum = results.GetEnumerator();
            resultEnum.MoveNext();
            _brightnessClass = resultEnum.Current;

            // We need to create an instance to use the Set method!
            var instanceName = (string)_brightnessClass["InstanceName"];
            _brightnessInstance = new ManagementObject(
                "root\\WMI",
                "WmiMonitorBrightnessMethods.InstanceName='" + instanceName + "'",
                null);
        }

        public static int GetDeviceCurrentBrightness()
        {
            // Getting the current value.
            var value = _brightnessClass.GetPropertyValue("CurrentBrightness");
            var valueString = value.ToString();
            return int.Parse(valueString); // Direct cast fails.
        }

        public static void SetDeviceBrightness(int newValue)
        {
            if (newValue < 0)
            {
                newValue = 0;
            }

            if (newValue > 100)
            {
                newValue = 100;
            }

            var inParams = _brightnessInstance.GetMethodParameters("WmiSetBrightness");
            inParams["Brightness"] = newValue;
            inParams["Timeout"] = 0;
            _brightnessInstance.InvokeMethod("WmiSetBrightness", inParams, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a = Algorithm1(Convert.ToInt32(richTextBox1.Text));
                SetDeviceBrightness(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
