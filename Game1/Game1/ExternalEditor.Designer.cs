namespace Game1
{
    partial class ExternalEditor
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
            this.JumpHeightTextBox = new System.Windows.Forms.TextBox();
            this.GravityTextBox = new System.Windows.Forms.TextBox();
            this.FallSpeedTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FallSpeed = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // JumpHeightTextBox
            // 
            this.JumpHeightTextBox.Location = new System.Drawing.Point(331, 342);
            this.JumpHeightTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JumpHeightTextBox.Name = "JumpHeightTextBox";
            this.JumpHeightTextBox.Size = new System.Drawing.Size(225, 38);
            this.JumpHeightTextBox.TabIndex = 15;
            this.JumpHeightTextBox.TextChanged += new System.EventHandler(this.PlatSpeedEasy);
            // 
            // GravityTextBox
            // 
            this.GravityTextBox.Location = new System.Drawing.Point(331, 244);
            this.GravityTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GravityTextBox.Name = "GravityTextBox";
            this.GravityTextBox.Size = new System.Drawing.Size(225, 38);
            this.GravityTextBox.TabIndex = 21;
            // 
            // FallSpeedTextBox
            // 
            this.FallSpeedTextBox.Location = new System.Drawing.Point(331, 146);
            this.FallSpeedTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FallSpeedTextBox.Name = "FallSpeedTextBox";
            this.FallSpeedTextBox.Size = new System.Drawing.Size(225, 38);
            this.FallSpeedTextBox.TabIndex = 13;
            this.FallSpeedTextBox.TextChanged += new System.EventHandler(this.ChangeJumpForce);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "PlatSpeed Easy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "Gravity";
            // 
            // FallSpeed
            // 
            this.FallSpeed.AutoSize = true;
            this.FallSpeed.Location = new System.Drawing.Point(60, 153);
            this.FallSpeed.Name = "FallSpeed";
            this.FallSpeed.Size = new System.Drawing.Size(156, 32);
            this.FallSpeed.TabIndex = 10;
            this.FallSpeed.Text = "JumpForce";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1451, 727);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 57);
            this.button2.TabIndex = 16;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ExitPressed);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(331, 440);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 38);
            this.textBox1.TabIndex = 18;
            this.textBox1.TextChanged += new System.EventHandler(this.PlatSpeedMedium);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 446);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "PlatSpeed Medium";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(331, 545);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(300, 38);
            this.textBox2.TabIndex = 20;
            this.textBox2.TextChanged += new System.EventHandler(this.PlatSpeedHard);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 552);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 32);
            this.label4.TabIndex = 19;
            this.label4.Text = "PlatSpeed Hard";
            // 
            // ExternalEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2192, 1059);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.JumpHeightTextBox);
            this.Controls.Add(this.GravityTextBox);
            this.Controls.Add(this.FallSpeedTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FallSpeed);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ExternalEditor";
            this.Text = "ExternalEditor";
            this.Load += new System.EventHandler(this.ExternalEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox JumpHeightTextBox;
        private System.Windows.Forms.TextBox GravityTextBox;
        private System.Windows.Forms.TextBox FallSpeedTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FallSpeed;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}