using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;
using scrcpy_ui.Entity;
using scrcpy_ui.Service;

namespace scrcpy_ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateDevices();
            UsbNotification.RegisterUsbDeviceNotification(this.Handle);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if(m.Msg == UsbNotification.WmDevicechange)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.DbtDevicearrival:
                        Thread.Sleep(1000);
                        UpdateDevices();
                        break;
                    case UsbNotification.DbtDeviceremovecomplete:
                        UpdateDevices();
                        break;
                }
            }
        }

        private void UpdateDevices()
        {
            // execute command 'adb devices -l'
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("adb", "devices -l")
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            
            
            var proc = System.Diagnostics.Process.Start(psi);
            // Get command result from stdout 
            string s = proc.StandardOutput.ReadToEnd();

            // process the result from command to get model and serial number
            var res = s.Split('\n');
            // Elminating the first line since its a header
            var aux = res.Reverse().Take(res.Count() - 1);

            deviceList.DisplayMember = "Model";
            deviceList.ValueMember = "SerialNumber";

            List<Device> devices = new List<Device>();
            
            // Iterate for each device found
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

            // Add devices to datasource
            deviceList.DataSource = devices;
        }

        private void btnSearchDevice_Click(object sender, EventArgs e)
        {
            UpdateDevices();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            // execute command 'scrcpy -s *selected device serial number*'
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
