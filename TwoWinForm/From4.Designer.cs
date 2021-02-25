namespace TwoWinForm
{
    partial class From4
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Red1 = new System.Windows.Forms.Label();
            this.Red2 = new System.Windows.Forms.Label();
            this.Red3 = new System.Windows.Forms.Label();
            this.Red4 = new System.Windows.Forms.Label();
            this.Red5 = new System.Windows.Forms.Label();
            this.Red6 = new System.Windows.Forms.Label();
            this.Blue7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.Blue7);
            this.groupBox1.Controls.Add(this.Red6);
            this.groupBox1.Controls.Add(this.Red5);
            this.groupBox1.Controls.Add(this.Red4);
            this.groupBox1.Controls.Add(this.Red3);
            this.groupBox1.Controls.Add(this.Red2);
            this.groupBox1.Controls.Add(this.Red1);
            this.groupBox1.Location = new System.Drawing.Point(47, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 202);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "双色求";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Red1
            // 
            this.Red1.AutoSize = true;
            this.Red1.ForeColor = System.Drawing.Color.Red;
            this.Red1.Location = new System.Drawing.Point(31, 57);
            this.Red1.Name = "Red1";
            this.Red1.Size = new System.Drawing.Size(23, 15);
            this.Red1.TabIndex = 0;
            this.Red1.Text = "00";
            // 
            // Red2
            // 
            this.Red2.AutoSize = true;
            this.Red2.ForeColor = System.Drawing.Color.Red;
            this.Red2.Location = new System.Drawing.Point(78, 57);
            this.Red2.Name = "Red2";
            this.Red2.Size = new System.Drawing.Size(23, 15);
            this.Red2.TabIndex = 1;
            this.Red2.Text = "00";
            // 
            // Red3
            // 
            this.Red3.AutoSize = true;
            this.Red3.ForeColor = System.Drawing.Color.Red;
            this.Red3.Location = new System.Drawing.Point(127, 57);
            this.Red3.Name = "Red3";
            this.Red3.Size = new System.Drawing.Size(23, 15);
            this.Red3.TabIndex = 2;
            this.Red3.Text = "00";
            this.Red3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Red4
            // 
            this.Red4.AutoSize = true;
            this.Red4.ForeColor = System.Drawing.Color.Red;
            this.Red4.Location = new System.Drawing.Point(180, 57);
            this.Red4.Name = "Red4";
            this.Red4.Size = new System.Drawing.Size(23, 15);
            this.Red4.TabIndex = 3;
            this.Red4.Text = "00";
            // 
            // Red5
            // 
            this.Red5.AutoSize = true;
            this.Red5.ForeColor = System.Drawing.Color.Red;
            this.Red5.Location = new System.Drawing.Point(231, 57);
            this.Red5.Name = "Red5";
            this.Red5.Size = new System.Drawing.Size(23, 15);
            this.Red5.TabIndex = 4;
            this.Red5.Text = "00";
            // 
            // Red6
            // 
            this.Red6.AutoSize = true;
            this.Red6.ForeColor = System.Drawing.Color.Red;
            this.Red6.Location = new System.Drawing.Point(285, 57);
            this.Red6.Name = "Red6";
            this.Red6.Size = new System.Drawing.Size(23, 15);
            this.Red6.TabIndex = 5;
            this.Red6.Text = "00";
            // 
            // Blue7
            // 
            this.Blue7.AutoSize = true;
            this.Blue7.ForeColor = System.Drawing.Color.Blue;
            this.Blue7.Location = new System.Drawing.Point(351, 57);
            this.Blue7.Name = "Blue7";
            this.Blue7.Size = new System.Drawing.Size(23, 15);
            this.Blue7.TabIndex = 6;
            this.Blue7.Text = "00";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(105, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 7;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(234, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 32);
            this.button3.TabIndex = 8;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // From4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 412);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "From4";
            this.Text = "From4";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label Blue7;
        private System.Windows.Forms.Label Red6;
        private System.Windows.Forms.Label Red5;
        private System.Windows.Forms.Label Red4;
        private System.Windows.Forms.Label Red3;
        private System.Windows.Forms.Label Red2;
        private System.Windows.Forms.Label Red1;
    }
}