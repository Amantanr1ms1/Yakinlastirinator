namespace ZoomApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxZoomIn;
        private System.Windows.Forms.ComboBox comboBoxZoomOut;
        private System.Windows.Forms.ComboBox comboBoxStep;
        private System.Windows.Forms.Button btnSetZoomIn;
        private System.Windows.Forms.Button btnSetZoomOut;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label labelZoomIn;
        private System.Windows.Forms.Label labelZoomOut;
        private System.Windows.Forms.Label labelStep;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBoxZoomIn = new System.Windows.Forms.ComboBox();
            this.comboBoxZoomOut = new System.Windows.Forms.ComboBox();
            this.comboBoxStep = new System.Windows.Forms.ComboBox();
            this.btnSetZoomIn = new System.Windows.Forms.Button();
            this.btnSetZoomOut = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.labelZoomIn = new System.Windows.Forms.Label();
            this.labelZoomOut = new System.Windows.Forms.Label();
            this.labelStep = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxZoomIn
            // 
            this.comboBoxZoomIn.BackColor = System.Drawing.Color.IndianRed;
            this.comboBoxZoomIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZoomIn.ForeColor = System.Drawing.Color.Black;
            this.comboBoxZoomIn.Location = new System.Drawing.Point(12, 104);
            this.comboBoxZoomIn.Name = "comboBoxZoomIn";
            this.comboBoxZoomIn.Size = new System.Drawing.Size(106, 28);
            this.comboBoxZoomIn.TabIndex = 0;
            // 
            // comboBoxZoomOut
            // 
            this.comboBoxZoomOut.BackColor = System.Drawing.Color.IndianRed;
            this.comboBoxZoomOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZoomOut.Location = new System.Drawing.Point(12, 161);
            this.comboBoxZoomOut.Name = "comboBoxZoomOut";
            this.comboBoxZoomOut.Size = new System.Drawing.Size(102, 28);
            this.comboBoxZoomOut.TabIndex = 1;
            this.comboBoxZoomOut.SelectedIndexChanged += new System.EventHandler(this.comboBoxZoomOut_SelectedIndexChanged);
            // 
            // comboBoxStep
            // 
            this.comboBoxStep.BackColor = System.Drawing.Color.IndianRed;
            this.comboBoxStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStep.Location = new System.Drawing.Point(12, 218);
            this.comboBoxStep.Name = "comboBoxStep";
            this.comboBoxStep.Size = new System.Drawing.Size(102, 28);
            this.comboBoxStep.TabIndex = 2;
            this.comboBoxStep.SelectedIndexChanged += new System.EventHandler(this.comboBoxStep_SelectedIndexChanged);
            // 
            // btnSetZoomIn
            // 
            this.btnSetZoomIn.BackColor = System.Drawing.Color.IndianRed;
            this.btnSetZoomIn.Location = new System.Drawing.Point(491, 12);
            this.btnSetZoomIn.Name = "btnSetZoomIn";
            this.btnSetZoomIn.Size = new System.Drawing.Size(120, 30);
            this.btnSetZoomIn.TabIndex = 3;
            this.btnSetZoomIn.Text = "Set Zoom In Key";
            this.btnSetZoomIn.UseVisualStyleBackColor = false;
            this.btnSetZoomIn.Click += new System.EventHandler(this.btnSetZoomIn_Click);
            // 
            // btnSetZoomOut
            // 
            this.btnSetZoomOut.BackColor = System.Drawing.Color.IndianRed;
            this.btnSetZoomOut.Location = new System.Drawing.Point(491, 48);
            this.btnSetZoomOut.Name = "btnSetZoomOut";
            this.btnSetZoomOut.Size = new System.Drawing.Size(120, 30);
            this.btnSetZoomOut.TabIndex = 4;
            this.btnSetZoomOut.Text = "Set Zoom Out Key";
            this.btnSetZoomOut.UseVisualStyleBackColor = false;
            this.btnSetZoomOut.Click += new System.EventHandler(this.btnSetZoomOut_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(5, 694);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(175, 31);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset Zoom";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // labelZoomIn
            // 
            this.labelZoomIn.BackColor = System.Drawing.Color.IndianRed;
            this.labelZoomIn.Location = new System.Drawing.Point(14, 78);
            this.labelZoomIn.Name = "labelZoomIn";
            this.labelZoomIn.Size = new System.Drawing.Size(100, 23);
            this.labelZoomIn.TabIndex = 6;
            this.labelZoomIn.Text = "Zoom In Tuşu:";
            // 
            // labelZoomOut
            // 
            this.labelZoomOut.BackColor = System.Drawing.Color.IndianRed;
            this.labelZoomOut.Location = new System.Drawing.Point(14, 135);
            this.labelZoomOut.Name = "labelZoomOut";
            this.labelZoomOut.Size = new System.Drawing.Size(100, 23);
            this.labelZoomOut.TabIndex = 7;
            this.labelZoomOut.Text = "Zoom Out Tuşu:";
            this.labelZoomOut.Click += new System.EventHandler(this.labelZoomOut_Click);
            // 
            // labelStep
            // 
            this.labelStep.BackColor = System.Drawing.Color.IndianRed;
            this.labelStep.Location = new System.Drawing.Point(14, 192);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(100, 23);
            this.labelStep.TabIndex = 8;
            this.labelStep.Text = "Zoom Step (Kat):";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZoomApp.Properties.Resources.aaa22aa;
            this.pictureBox1.Location = new System.Drawing.Point(-5, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(636, 903);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(621, 872);
            this.Controls.Add(this.comboBoxZoomIn);
            this.Controls.Add(this.comboBoxZoomOut);
            this.Controls.Add(this.comboBoxStep);
            this.Controls.Add(this.btnSetZoomIn);
            this.Controls.Add(this.btnSetZoomOut);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.labelZoomIn);
            this.Controls.Add(this.labelZoomOut);
            this.Controls.Add(this.labelStep);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Yakınlastiranator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
