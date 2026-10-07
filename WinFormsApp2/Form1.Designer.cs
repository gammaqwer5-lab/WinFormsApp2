namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            FillTbale = new Button();
            richTextBox1 = new RichTextBox();
            button6 = new Button();
            textBox1 = new TextBox();
            button7 = new Button();
            button8 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 133);
            button1.Name = "button1";
            button1.Size = new Size(165, 23);
            button1.TabIndex = 0;
            button1.Text = "1 Экипаж";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 187);
            button2.Name = "button2";
            button2.Size = new Size(165, 23);
            button2.TabIndex = 1;
            button2.Text = "2 Поиск по имени";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 269);
            button3.Name = "button3";
            button3.Size = new Size(165, 23);
            button3.TabIndex = 2;
            button3.Text = "3 меню";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 325);
            button4.Name = "button4";
            button4.Size = new Size(165, 23);
            button4.TabIndex = 3;
            button4.Text = "4 Диагностика";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(12, 381);
            button5.Name = "button5";
            button5.Size = new Size(165, 23);
            button5.TabIndex = 4;
            button5.Text = "5 Система тревоги";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // FillTbale
            // 
            FillTbale.Location = new Point(242, 12);
            FillTbale.Name = "FillTbale";
            FillTbale.Size = new Size(117, 23);
            FillTbale.TabIndex = 5;
            FillTbale.Text = "Fill crew table";
            FillTbale.UseVisualStyleBackColor = true;
            FillTbale.Click += FillTbale_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(197, 41);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(556, 376);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button6.Location = new Point(12, 12);
            button6.Name = "button6";
            button6.Size = new Size(165, 59);
            button6.TabIndex = 7;
            button6.Text = "Connect";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 216);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(165, 23);
            textBox1.TabIndex = 8;
            // 
            // button7
            // 
            button7.Location = new Point(12, 77);
            button7.Name = "button7";
            button7.Size = new Size(165, 23);
            button7.TabIndex = 9;
            button7.Text = "Clear output";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(365, 12);
            button8.Name = "button8";
            button8.Size = new Size(175, 23);
            button8.TabIndex = 10;
            button8.Text = "Create and Fill system table";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 429);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(textBox1);
            Controls.Add(button6);
            Controls.Add(richTextBox1);
            Controls.Add(FillTbale);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button FillTbale;
        private RichTextBox richTextBox1;
        private Button button6;
        private TextBox textBox1;
        private Button button7;
        private Button button8;
    }
}
