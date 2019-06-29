namespace AliveHookManager
{
    partial class FixedFloatHelper
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
            this.textBox_RawHex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_RawInt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_ResultFloat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_RawHex
            // 
            this.textBox_RawHex.Location = new System.Drawing.Point(42, 19);
            this.textBox_RawHex.Name = "textBox_RawHex";
            this.textBox_RawHex.Size = new System.Drawing.Size(100, 20);
            this.textBox_RawHex.TabIndex = 0;
            this.textBox_RawHex.TextChanged += new System.EventHandler(this.textBox_RawHex_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hex:";
            // 
            // textBox_RawInt
            // 
            this.textBox_RawInt.Location = new System.Drawing.Point(42, 45);
            this.textBox_RawInt.Name = "textBox_RawInt";
            this.textBox_RawInt.Size = new System.Drawing.Size(100, 20);
            this.textBox_RawInt.TabIndex = 0;
            this.textBox_RawInt.TextChanged += new System.EventHandler(this.textBox_RawInt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Int:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_RawHex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_RawInt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 82);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Raw";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_ResultFloat);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 56);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // textBox_ResultFloat
            // 
            this.textBox_ResultFloat.Location = new System.Drawing.Point(42, 19);
            this.textBox_ResultFloat.Name = "textBox_ResultFloat";
            this.textBox_ResultFloat.Size = new System.Drawing.Size(100, 20);
            this.textBox_ResultFloat.TabIndex = 0;
            this.textBox_ResultFloat.TextChanged += new System.EventHandler(this.textBox_ResultFloat_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Float:";
            // 
            // FixedFloatHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 167);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FixedFloatHelper";
            this.Text = "FixedFloatHelper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_RawHex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_RawInt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_ResultFloat;
        private System.Windows.Forms.Label label4;
    }
}