using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;
using System.Management;
using System.Diagnostics;

namespace Screen_Brightness_Adjuster
{
    public partial class WindowsServices : Form
    {
        private static ManagementObject _brightnessInstance;
        private static ManagementBaseObject _brightnessClass;
        private static int a;
        private static int espInput;
        private static bool start;

        public WindowsServices()
        {
            InitializeComponent();
            button6.Visible = false;
            button7.Visible = false;
            trackBar1.Visible = false;
            richTextBox1.Visible = false;
            label1.Visible = false;
        }

        public void RestrictA()
        {
            if (a < 0)
            {
                a = 0;
            }

            if (a > 100)
            {
                a = 100;
            }
        }

        public int Algorithm1(int i)
        {
            return a = 100 - (i / 4000) * 100;
        }

        public void showTextbox1()
        {
            if (textBox1.Visible == false)
            {
                textBox1.Visible = true;
            }
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

        public int GetDeviceCurrentBrightness()
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
            ///
            /// Take integer from ESP32 and change brightness relative to it
            /// 1. Run ESP32 integer through algorithm
            /// 2. Change the brightness to the outputed number
            /// 3. Show then current brightness as en integer
            ///
            try
            {
                a = Algorithm1(espInput);
                SetDeviceBrightness(a);
                RestrictA();
                textBox1.Text = Convert.ToString(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ///
            /// Diplay main screen
            /// Main screen includes:
            /// 1. Button that starts auto brightness adjustment
            /// 2. Textbox that shows current brightness
            /// 3. All menu buttons
            /// ...
            ///
            
            if (trackBar1.Visible)
            {
                trackBar1.Visible = false;
            }

            if (richTextBox1.Visible)
            {
                richTextBox1.Visible = false;
            }

            if (button1.Visible == false)
            {
                button1.Visible = true;
            }

            if (button6.Visible)
            {
                button6.Visible = false;
            }

            if (button7.Visible)
            {
                button7.Visible = false;
            }

            if (label1.Visible)
            {
                label1.Visible = false;
            }

            showTextbox1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ///
            /// Display manual adjustment screen
            /// Manual adjustment screen includes:
            /// 1. Button that sets brightness to the selected level
            /// 2. Trackbar that selects the brightness level
            /// 3. Textbox that showsthe current brightness
            /// 4. All menu buttons
            /// ...
            ///

            if (button1.Visible)
            {
                button1.Visible = false;
            }

            if (trackBar1.Visible == false)
            {
                trackBar1.Visible = true;
            }

            if (richTextBox1.Visible == false)
            {
                richTextBox1.Visible = true;
            }

            if (button6.Visible == false)
            {
                button6.Visible = true;
            }

            if (button7.Visible == false)
            {
                button7.Visible = true;
            }

            if (label1.Visible == false)
            {
                label1.Visible = true;
            }

            showTextbox1();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ///
            /// Display options screen
            /// Options screen includes:
            /// 1. Rick rolls
            ///

            Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ///
            /// Change brightness to the trackbar value
            /// 1. Get value form trackbar
            /// 2. Change brightness to the trackbar value
            /// 3. Show the current brightness
            ///
            try
            {
                a = trackBar1.Value;
                SetDeviceBrightness(a);
                RestrictA();
                textBox1.Text = Convert.ToString(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ///
            /// Change brightness to value stated in the textbox
            /// 1. Get value from text and convert it to an integer
            /// 2. Change brightness to the outputed integer
            /// 3. Show the current bruightness
            ///
            try
            {
                a = Convert.ToInt32(richTextBox1.Text);
                SetDeviceBrightness(a);
                RestrictA();
                textBox1.Text = Convert.ToString(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
