namespace DBapplication
{
    partial class Welcome
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
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton3 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton5 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton6 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
            this.kryptonButton1.Location = new System.Drawing.Point(895, 41);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonButton1.Size = new System.Drawing.Size(197, 79);
            this.kryptonButton1.TabIndex = 0;
            this.kryptonButton1.Values.Text = "Admin";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
            this.kryptonButton2.Location = new System.Drawing.Point(895, 165);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonButton2.Size = new System.Drawing.Size(197, 79);
            this.kryptonButton2.TabIndex = 1;
            this.kryptonButton2.Values.Text = "Manager";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
            this.kryptonButton3.Location = new System.Drawing.Point(895, 422);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonButton3.Size = new System.Drawing.Size(197, 79);
            this.kryptonButton3.TabIndex = 2;
            this.kryptonButton3.Values.Text = "Client";
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
            this.kryptonButton4.Location = new System.Drawing.Point(895, 288);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonButton4.Size = new System.Drawing.Size(197, 79);
            this.kryptonButton4.TabIndex = 3;
            this.kryptonButton4.Values.Text = "HOD";
            // 
            // kryptonButton5
            // 
            this.kryptonButton5.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
            this.kryptonButton5.Location = new System.Drawing.Point(895, 591);
            this.kryptonButton5.Name = "kryptonButton5";
            this.kryptonButton5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.kryptonButton5.Size = new System.Drawing.Size(197, 38);
            this.kryptonButton5.TabIndex = 4;
            this.kryptonButton5.Values.Text = "Register";
            // 
            // kryptonButton6
            // 
            this.kryptonButton6.Location = new System.Drawing.Point(818, 17);
            this.kryptonButton6.Name = "kryptonButton6";
            this.kryptonButton6.Size = new System.Drawing.Size(10, 512);
            this.kryptonButton6.TabIndex = 6;
            this.kryptonButton6.UseWaitCursor = true;
            this.kryptonButton6.Values.Text = "kryptonButton6";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 10);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1222, 673);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.kryptonButton6);
            this.Controls.Add(this.kryptonButton5);
            this.Controls.Add(this.kryptonButton4);
            this.Controls.Add(this.kryptonButton3);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.kryptonButton1);
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton6;
        private System.Windows.Forms.Button button1;
    }
}