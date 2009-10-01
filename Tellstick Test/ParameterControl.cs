using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TellStick.Protocols;

namespace Tellstick_Test
{
    public partial class ParameterControl : TableLayoutPanel
    {
        private Parameter _parameter;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private List<CheckBox> codeBoxes;

        public ParameterControl(Parameter parameter)
        {
            _parameter = parameter;
            if (parameter is OnOffParameter)
            {
                OnOffParameter p = (OnOffParameter)parameter;
                this.ColumnCount = 5;
                this.RowCount = (int)Math.Ceiling((double)p.Values.Length / (double)5);                

                codeBoxes = new List<CheckBox>();
                foreach (string s in p.Values)
                {
                    CheckBox chk = new CheckBox();
                    chk.Text = s;
                    this.Controls.Add(chk);
                    codeBoxes.Add(chk);
                }

                this.ColumnStyles.Clear();
                for (int t = 0; t < this.ColumnCount; t++)
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

                this.RowStyles.Clear();
                for (int t = 0; t < this.RowCount; t++)
                    this.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                this.AutoSize = false;
                this.Width = 340;
                this.Height = 75;
            }
            else if (parameter is OptionsParameter)
            {
                OptionsParameter p = (OptionsParameter)parameter;
                comboBox1 = new ComboBox();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox1.DisplayMember = "Key";
                foreach (string[] s in p.Values)
                    comboBox1.Items.Add(new KeyValuePair<string, string>(s[0], s[1]));

                this.ColumnCount = 1;
                this.RowCount = 1;
                this.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                this.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                this.Controls.Add(comboBox1);
            }
            else
            {
                this.RowCount = 1;
                this.ColumnCount = 1;
                FlowLayoutPanel panel = new FlowLayoutPanel();

                textBox1 = new TextBox();
                Label label1 = new Label();
                label1.Text = parameter.Type.ToString();

                panel.Controls.Add(label1);
                panel.Controls.Add(textBox1);
                if (parameter is MinMaxParameter)
                {
                    MinMaxParameter p = (MinMaxParameter)parameter;
                    label1.Text = string.Format("{2} ({0}-{1})", p.Min.ToString(), p.Max.ToString(), label1.Text);
                }
                this.Controls.Add(panel);
                panel.AutoSize = false;
                panel.Size = new Size(textBox1.Width, textBox1.Height + label1.Height + 5);
                this.Size = panel.Size;
            }
        }

        public string TextValue
        {
            get
            {
                if (_parameter.Type == TellStick.TellStickParameterTypes.House || _parameter.Type == TellStick.TellStickParameterTypes.Unit || _parameter.Type == TellStick.TellStickParameterTypes.System)
                    return textBox1.Text;
                else if (_parameter.Type == TellStick.TellStickParameterTypes.Code)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (CheckBox c in codeBoxes)
                        sb.Append((c.Checked) ? "1" : "0");

                    return sb.ToString();
                }
                else if (_parameter.Type == TellStick.TellStickParameterTypes.Units)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (CheckBox c in codeBoxes)
                        if((c.Checked))
                            sb.Append(c.Text+",");

                    return sb.ToString().Trim(',');
                }
                else if (_parameter.Type == TellStick.TellStickParameterTypes.Fade)
                {
                    if(comboBox1.SelectedIndex > -1)
                        return ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
                }
                

                return "";
            }
            set
            {

                if (_parameter.Type == TellStick.TellStickParameterTypes.House || _parameter.Type == TellStick.TellStickParameterTypes.Unit || _parameter.Type == TellStick.TellStickParameterTypes.System)
                    textBox1.Text = value;
                else if (_parameter.Type == TellStick.TellStickParameterTypes.Units)
                {
                    string[] s = value.Split(new char[] { ',' });
                    foreach (CheckBox c in codeBoxes)
                        if (Array.IndexOf(s, c.Text) >= 0)
                            c.Checked = true;
                        else
                            c.Checked = false;
                }
                else if (_parameter.Type == TellStick.TellStickParameterTypes.Fade)
                {
                    foreach(KeyValuePair<string, string> kp in comboBox1.Items)
                        if(kp.Value.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                            comboBox1.SelectedItem = kp;
                }
                else if (_parameter.Type == TellStick.TellStickParameterTypes.Code)
                {
                    for (int i = 0; i < codeBoxes.Count; i++)
                    {
                        if (value.Substring(i, 1).Equals("1"))
                            codeBoxes[i].Checked = true;
                        else
                            codeBoxes[i].Checked = false;
                    }
                }
            }
        }

        public Parameter Parameter { get { return _parameter; } }
    }
}
