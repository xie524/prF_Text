namespace ThermalPrinting
{
    partial class prF
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(prF));
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.textBox_Y = new System.Windows.Forms.TextBox();
            this.boBox_Seep = new System.Windows.Forms.TextBox();
            this.button_QR = new System.Windows.Forms.Button();
            this.textBox_QR = new System.Windows.Forms.TextBox();
            this.printfButtoon_15 = new System.Windows.Forms.Button();
            this.printfComBox_15 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_Num = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBoxPrfText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_X
            // 
            this.textBox_X.Location = new System.Drawing.Point(357, 44);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.Size = new System.Drawing.Size(100, 25);
            this.textBox_X.TabIndex = 11;
            this.textBox_X.Text = "200";
            this.textBox_X.TextChanged += new System.EventHandler(this.textBox_X_TextChanged);
            // 
            // textBox_Y
            // 
            this.textBox_Y.Location = new System.Drawing.Point(357, 74);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.Size = new System.Drawing.Size(100, 25);
            this.textBox_Y.TabIndex = 12;
            this.textBox_Y.Text = "200";
            this.textBox_Y.TextChanged += new System.EventHandler(this.textBox_Y_TextChanged);
            // 
            // boBox_Seep
            // 
            this.boBox_Seep.Location = new System.Drawing.Point(357, 13);
            this.boBox_Seep.Name = "boBox_Seep";
            this.boBox_Seep.Size = new System.Drawing.Size(100, 25);
            this.boBox_Seep.TabIndex = 13;
            this.boBox_Seep.Text = "27";
            this.boBox_Seep.TextChanged += new System.EventHandler(this.boBox_Seep_TextChanged);
            // 
            // button_QR
            // 
            this.button_QR.Location = new System.Drawing.Point(463, 64);
            this.button_QR.Name = "button_QR";
            this.button_QR.Size = new System.Drawing.Size(315, 97);
            this.button_QR.TabIndex = 14;
            this.button_QR.Text = "QR";
            this.button_QR.UseVisualStyleBackColor = true;
            this.button_QR.Click += new System.EventHandler(this.button_QR_Click);
            // 
            // textBox_QR
            // 
            this.textBox_QR.Location = new System.Drawing.Point(463, 12);
            this.textBox_QR.Multiline = true;
            this.textBox_QR.Name = "textBox_QR";
            this.textBox_QR.Size = new System.Drawing.Size(315, 46);
            this.textBox_QR.TabIndex = 15;
            this.textBox_QR.Text = "http://47.113.204.99:20524/";
            this.textBox_QR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_QR.TextChanged += new System.EventHandler(this.textBox_QR_TextChanged);
            // 
            // printfButtoon_15
            // 
            this.printfButtoon_15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.printfButtoon_15.BackColor = System.Drawing.SystemColors.Info;
            this.printfButtoon_15.Location = new System.Drawing.Point(12, 42);
            this.printfButtoon_15.Name = "printfButtoon_15";
            this.printfButtoon_15.Size = new System.Drawing.Size(330, 46);
            this.printfButtoon_15.TabIndex = 25;
            this.printfButtoon_15.Text = "打印机_15*5";
            this.printfButtoon_15.UseVisualStyleBackColor = false;
            this.printfButtoon_15.Click += new System.EventHandler(this.printfButtoon_15_Click);
            // 
            // printfComBox_15
            // 
            this.printfComBox_15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.printfComBox_15.FormattingEnabled = true;
            this.printfComBox_15.Location = new System.Drawing.Point(12, 13);
            this.printfComBox_15.Name = "printfComBox_15";
            this.printfComBox_15.Size = new System.Drawing.Size(339, 23);
            this.printfComBox_15.TabIndex = 26;
            this.printfComBox_15.Text = "printCom-15";
            this.printfComBox_15.DropDown += new System.EventHandler(this.printfComBox_15_DropDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 182);
            this.button1.TabIndex = 27;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(578, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 181);
            this.button2.TabIndex = 28;
            this.button2.Text = "本地";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(357, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 56);
            this.button3.TabIndex = 29;
            this.button3.Text = "有路径";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // textBox_Num
            // 
            this.textBox_Num.Location = new System.Drawing.Point(233, 136);
            this.textBox_Num.Name = "textBox_Num";
            this.textBox_Num.Size = new System.Drawing.Size(109, 25);
            this.textBox_Num.TabIndex = 30;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(12, 379);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(330, 46);
            this.button4.TabIndex = 31;
            this.button4.Text = "buttonTextSpr";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonTextSpr);
            // 
            // textBoxPrfText
            // 
            this.textBoxPrfText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrfText.Font = new System.Drawing.Font("华文楷体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPrfText.Location = new System.Drawing.Point(12, 167);
            this.textBoxPrfText.Multiline = true;
            this.textBoxPrfText.Name = "textBoxPrfText";
            this.textBoxPrfText.Size = new System.Drawing.Size(339, 194);
            this.textBoxPrfText.TabIndex = 32;
            this.textBoxPrfText.Text = "http://47.113.204.99:20524/";
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button5.BackColor = System.Drawing.SystemColors.Info;
            this.button5.Location = new System.Drawing.Point(12, 42);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(339, 46);
            this.button5.TabIndex = 25;
            this.button5.Text = "打印机_15*5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.printfButtoon_15_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(233, 136);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 25);
            this.textBox1.TabIndex = 30;
            // 
            // prF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxPrfText);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox_Num);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.printfComBox_15);
            this.Controls.Add(this.printfButtoon_15);
            this.Controls.Add(this.textBox_QR);
            this.Controls.Add(this.button_QR);
            this.Controls.Add(this.boBox_Seep);
            this.Controls.Add(this.textBox_Y);
            this.Controls.Add(this.textBox_X);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "prF";
            this.Text = "prF";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.TextBox textBox_Y;
        private System.Windows.Forms.TextBox boBox_Seep;
        private System.Windows.Forms.Button button_QR;
        private System.Windows.Forms.TextBox textBox_QR;
        private System.Windows.Forms.Button printfButtoon_15;
        private System.Windows.Forms.ComboBox printfComBox_15;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_Num;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBoxPrfText;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
    }
}

