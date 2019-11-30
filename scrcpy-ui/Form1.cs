using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using scrcpy_ui.Entity;

namespace scrcpy_ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateDevices();
        }

        private void UpdateDevices()
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("adb", "devices -l")
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            var proc = System.Diagnostics.Process.Start(psi);
            string s = proc.StandardOutput.ReadToEnd();

            var res = s.Split('\n');
            var aux = res.Reverse().Take(res.Count() - 1);

            deviceList.DisplayMember = "Model";
            deviceList.ValueMember = "SerialNumber";

            List<Device> devices = new List<Device>();

            foreach (var ss in aux)
            {
                if (ss != "" && ss != "\r")
                {
                    var tkn = ss.Split(' ');
                    var realTkns = new List<String>();

                    foreach (var r in tkn)
                    {
                        if (r != "")
                        {
                            realTkns.Add(r);
                        }
                    }
                    // Device
                    Device device = new Device();
                    device.SerialNumber = realTkns[0];
                    device.Model = realTkns[3].Trim('m', 'o', 'd', 'e', 'l', ':');
                    device.DeviceName = realTkns[4].Trim('d', 'e', 'v', 'i', 'c', ':');
                    devices.Add(device);
                }
            }

            deviceList.DataSource = devices;
        }

        private void btnSearchDevice_Click(object sender, EventArgs e)
        {
            UpdateDevices();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("scrcpy", "-s " + deviceList.SelectedValue)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            System.Diagnostics.Process.Start(psi);
        }

    }
}
