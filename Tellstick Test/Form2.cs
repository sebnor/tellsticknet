using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TellStick.Models;
using TellStick;
using System.Reflection;
using TellStick.Protocols;

namespace Tellstick_Test
{
    public partial class Form2 : Form
    {
        Form1 parent;
        TellStickDevice device;

        public Form2(Form1 p)
        {
            parent = p;
            InitializeComponent();
            LoadModels();
            LoadDevice();
        }

        public Form2(Form1 p, TellStickDevice d)
        {
            device = d;
            parent = p;
            InitializeComponent();
            LoadModels();
            LoadDevice();
        }

        private void LoadDevice()
        {
            if (device != null)
                foreach (TreeNode modelNode in treeView1.Nodes)
                    if (modelNode.Tag.GetType() == device.Model.GetType())
                        foreach (TreeNode node in modelNode.Nodes)
                            if (((TellStickSettingTypes)node.Tag) == device.ControlType)
                                treeView1.SelectedNode = node;
        }

        private void LoadModels()
        {
            foreach (Type t in Assembly.GetAssembly(typeof(TellStick.TellStickDevice)).GetTypes())
            {
                if (t.Namespace.Equals("TellStick.Models") && t.BaseType == typeof(ModelBase))
                {
                    foreach (ModelNameAttribute attribute in t.GetCustomAttributes(typeof(ModelNameAttribute), true))
                    {
                        if (attribute.HideInList)
                        {
                            ModelBase m = (ModelBase)Activator.CreateInstance(t);
                            TreeNode pNode = new TreeNode(m.DisplayName);
                            pNode.Tag = m;

                            foreach (int en in Enum.GetValues(typeof(TellStickSettingTypes)))
                            {
                                if ((((TellStickSettingTypes)en) & m.Protocol.SettingTypes) == ((TellStickSettingTypes)en))
                                {
                                    TreeNode cNode = new TreeNode(EnumHelper.GetSettingsDisplayName((TellStickSettingTypes)en));
                                    cNode.Tag = ((TellStickSettingTypes)en);
                                    pNode.Nodes.Add(cNode);
                                }
                            }

                            treeView1.Nodes.Add(pNode);
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            flowLayoutPanel1.Controls.Clear();
            if (tv.SelectedNode.Tag is TellStickSettingTypes)
            {
                if (device != null)
                    tbName.Text = device.Name;

                ModelBase m = (ModelBase)tv.SelectedNode.Parent.Tag;
                foreach (Parameter p in m.Protocol.GetParameters((TellStickSettingTypes)tv.SelectedNode.Tag))
                {
                    ParameterControl pc = new ParameterControl(p);
                    if (device != null && ((TellStickSettingTypes)tv.SelectedNode.Tag) == device.ControlType)
                        pc.TextValue = device.GetParameter(p.Type);
                    flowLayoutPanel1.Controls.Add(pc);
                }
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("You have to write a name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is TellStickSettingTypes)
            {
                ModelBase m = (ModelBase)treeView1.SelectedNode.Parent.Tag;
                if (device == null)
                    device = new TellStickDevice(tbName.Text, m, (TellStickSettingTypes)treeView1.SelectedNode.Tag);
                else
                {
                    if (device.Model.GetType() != m.GetType())
                        device.Model = m;
                    if (device.ControlType != ((TellStickSettingTypes)treeView1.SelectedNode.Tag))
                        device.ControlType = (TellStickSettingTypes)treeView1.SelectedNode.Tag;

                    device.Name = tbName.Text;
                }
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    if (c is ParameterControl)
                    {
                        ParameterControl cp = (ParameterControl)c;
                        if (!cp.Parameter.Validate(cp.TextValue))
                        {
                            MessageBox.Show("Parameter not in correct format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        device.SetParameter(cp.Parameter.Type, cp.TextValue);
                    }
                }

                device.Save();
                parent.GetDevices();
                this.Dispose();
            }
            else
                MessageBox.Show("You have to choose a control", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
