namespace Tellstick_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetLamps = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnTurnOn = new System.Windows.Forms.Button();
            this.btnTurnOff = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnBell = new System.Windows.Forms.Button();
            this.btnLearn = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetLamps
            // 
            this.btnGetLamps.Location = new System.Drawing.Point(417, 12);
            this.btnGetLamps.Name = "btnGetLamps";
            this.btnGetLamps.Size = new System.Drawing.Size(75, 23);
            this.btnGetLamps.TabIndex = 1;
            this.btnGetLamps.Text = "Update list";
            this.btnGetLamps.UseVisualStyleBackColor = true;
            this.btnGetLamps.Click += new System.EventHandler(this.btnGetLamps_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(399, 238);
            this.listBox1.TabIndex = 2;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 282);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(417, 70);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(417, 41);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New Device";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnTurnOn
            // 
            this.btnTurnOn.Location = new System.Drawing.Point(12, 256);
            this.btnTurnOn.Name = "btnTurnOn";
            this.btnTurnOn.Size = new System.Drawing.Size(75, 23);
            this.btnTurnOn.TabIndex = 11;
            this.btnTurnOn.Text = "TurnOn";
            this.btnTurnOn.UseVisualStyleBackColor = true;
            this.btnTurnOn.Click += new System.EventHandler(this.btnTurnOn_Click);
            // 
            // btnTurnOff
            // 
            this.btnTurnOff.Location = new System.Drawing.Point(93, 256);
            this.btnTurnOff.Name = "btnTurnOff";
            this.btnTurnOff.Size = new System.Drawing.Size(75, 23);
            this.btnTurnOff.TabIndex = 12;
            this.btnTurnOff.Text = "TurnOff";
            this.btnTurnOff.UseVisualStyleBackColor = true;
            this.btnTurnOff.Click += new System.EventHandler(this.btnTurnOff_Click);
            // 
            // btnToggle
            // 
            this.btnToggle.Location = new System.Drawing.Point(174, 256);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(75, 23);
            this.btnToggle.TabIndex = 13;
            this.btnToggle.Text = "Toggle";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // btnBell
            // 
            this.btnBell.Location = new System.Drawing.Point(255, 256);
            this.btnBell.Name = "btnBell";
            this.btnBell.Size = new System.Drawing.Size(75, 23);
            this.btnBell.TabIndex = 15;
            this.btnBell.Text = "Bell";
            this.btnBell.UseVisualStyleBackColor = true;
            this.btnBell.Click += new System.EventHandler(this.btnBell_Click);
            // 
            // btnLearn
            // 
            this.btnLearn.Location = new System.Drawing.Point(336, 256);
            this.btnLearn.Name = "btnLearn";
            this.btnLearn.Size = new System.Drawing.Size(75, 23);
            this.btnLearn.TabIndex = 16;
            this.btnLearn.Text = "Learn";
            this.btnLearn.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(12, 298);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 19;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.MouseCaptureChanged += new System.EventHandler(this.trackBar1_MouseCaptureChanged);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Dimmer";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 330);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.btnLearn);
            this.Controls.Add(this.btnBell);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.btnTurnOff);
            this.Controls.Add(this.btnTurnOn);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnGetLamps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetLamps;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnTurnOn;
        private System.Windows.Forms.Button btnTurnOff;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnBell;
        private System.Windows.Forms.Button btnLearn;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
    }
}

