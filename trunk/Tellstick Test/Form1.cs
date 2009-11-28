using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TellStick;
using System.Diagnostics;

namespace Tellstick_Test
{
    public partial class Form1 : Form
    {
        private TellStickDevice d;

        public Form1()
        {
            InitializeComponent();
            GetDevices();
        }

        public void GetDevices()
        {
            listBox1.DataSource = new List<TellStickDevice>(TellStick.Base.GetDevices());
            listBox1.DisplayMember = "Name";
        }

        private void btnGetLamps_Click(object sender, EventArgs e)
        {
            GetDevices();
        }

        private void LoadDevice()
        {
            btnBell.Enabled = false;
            btnTurnOn.Enabled = false;
            btnTurnOff.Enabled = false;
            btnToggle.Enabled = false;
            trackBar1.Enabled = false;
            btnLearn.Enabled = false;

            if (d != null && d.DeviceId > 0)
            {
                if(d.HasMethod(TellStickMethods.TurnOff))
                    btnTurnOff.Enabled = true;

                if (d.HasMethod(TellStickMethods.TurnOn))
                    btnTurnOn.Enabled = true;

                if (d.HasMethod(TellStickMethods.TurnOn) && d.HasMethod(TellStickMethods.TurnOn))
                    btnToggle.Enabled = true;

                if (d.HasMethod(TellStickMethods.Bell))
                    btnBell.Enabled = true;

                if (d.HasMethod(TellStickMethods.Dim))
                    trackBar1.Enabled = true;

                if (d.HasMethod(TellStickMethods.Learn))
                    btnLearn.Enabled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            d = (TellStickDevice)lb.SelectedItem;
            LoadDevice();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form2 form = new Form2(this, d);
            form.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (d.Save())
                lblStatus.Text = "Saved";
            else
                lblStatus.Text = "Not Saved";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(((TellStickDevice)listBox1.SelectedItem).Remove())
                lblStatus.Text = "Deleted";
            else
                lblStatus.Text = "Not Deleted";

            GetDevices();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.ShowDialog();
        }

        private void btnTurnOn_Click(object sender, EventArgs e)
        {
            d.TurnOn();
        }

        private void btnTurnOff_Click(object sender, EventArgs e)
        {
            d.TurnOff();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            d.Toggle();
        }

        private void btnBell_Click(object sender, EventArgs e)
        {
            d.Bell();
        }

        private void button1_Click(object sender, EventArgs e)
        
        {
            
        }

        void Base_RawEvent(EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //TellStick.External.TDDeviceEventCallBack t = new External.TDDeviceEventCallBack(Form1.test
            //External.tdRegisterDeviceEvent(test, new IntPtr(1));
            Base.DeviceEvent += new DeviceEventHandler(Base_DeviceEvent);
        }

        void test(DeviceEvent ev)
        {

        }

        void Base_DeviceEvent(EventArgs e)
        {
            MessageBox.Show("tjoho");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Base.DeviceEvent -= new DeviceEventHandler(Base_DeviceEvent);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_MouseCaptureChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Trackbar: " + trackBar1.Value);
            if (d.HasMethod(TellStickMethods.Dim))
            {
                d.Dim(trackBar1.Value);
            }
        }
    }
}
