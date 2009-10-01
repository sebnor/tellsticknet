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
            this.btnDim = new System.Windows.Forms.Button();
            this.btnBell = new System.Windows.Forms.Button();
            this.btnLearn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetLamps
            // 
            this.btnGetLamps.Location = new System.Drawing.Point(497, 12);
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
            this.listBox1.Size = new System.Drawing.Size(480, 238);
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
            this.btnDelete.Location = new System.Drawing.Point(497, 70);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(497, 41);
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
            // btnDim
            // 
            this.btnDim.Location = new System.Drawing.Point(255, 256);
            this.btnDim.Name = "btnDim";
            this.btnDim.Size = new System.Drawing.Size(75, 23);
            this.btnDim.TabIndex = 14;
            this.btnDim.Text = "Dim";
            this.btnDim.UseVisualStyleBackColor = true;
            // 
            // btnBell
            // 
            this.btnBell.Location = new System.Drawing.Point(336, 256);
            this.btnBell.Name = "btnBell";
            this.btnBell.Size = new System.Drawing.Size(75, 23);
            this.btnBell.TabIndex = 15;
            this.btnBell.Text = "Bell";
            this.btnBell.UseVisualStyleBackColor = true;
            this.btnBell.Click += new System.EventHandler(this.btnBell_Click);
            // 
            // btnLearn
            // 
            this.btnLearn.Location = new System.Drawing.Point(417, 256);
            this.btnLearn.Name = "btnLearn";
            this.btnLearn.Size = new System.Drawing.Size(75, 23);
            this.btnLearn.TabIndex = 16;
            this.btnLearn.Text = "Learn";
            this.btnLearn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(511, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 296);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLearn);
            this.Controls.Add(this.btnBell);
            this.Controls.Add(this.btnDim);
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
        private System.Windows.Forms.Button btnDim;
        private System.Windows.Forms.Button btnBell;
        private System.Windows.Forms.Button btnLearn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

