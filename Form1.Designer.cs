namespace Kursova
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbSymkey = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tbText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnIDEA_E = new System.Windows.Forms.Button();
            this.btnRSA = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbq = new System.Windows.Forms.TextBox();
            this.tbp = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPerevirka = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReadIdeaKey = new System.Windows.Forms.Button();
            this.btnReadRSAkeys = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSymkey
            // 
            this.tbSymkey.Location = new System.Drawing.Point(106, 87);
            this.tbSymkey.Name = "tbSymkey";
            this.tbSymkey.Size = new System.Drawing.Size(381, 22);
            this.tbSymkey.TabIndex = 0;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(512, 29);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(99, 31);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(106, 33);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(381, 22);
            this.tbText.TabIndex = 3;
            this.tbText.Text = "Arhipov Oleksiy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "IDEA_key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Text";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(28, 278);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(841, 244);
            this.listBox1.TabIndex = 6;
            // 
            // btnIDEA_E
            // 
            this.btnIDEA_E.Location = new System.Drawing.Point(512, 83);
            this.btnIDEA_E.Name = "btnIDEA_E";
            this.btnIDEA_E.Size = new System.Drawing.Size(99, 31);
            this.btnIDEA_E.TabIndex = 7;
            this.btnIDEA_E.Text = "IDEA_E";
            this.btnIDEA_E.UseVisualStyleBackColor = true;
            this.btnIDEA_E.Click += new System.EventHandler(this.btnIDEA_E_Click);
            // 
            // btnRSA
            // 
            this.btnRSA.Location = new System.Drawing.Point(197, 153);
            this.btnRSA.Name = "btnRSA";
            this.btnRSA.Size = new System.Drawing.Size(102, 31);
            this.btnRSA.TabIndex = 8;
            this.btnRSA.Text = "RSA";
            this.btnRSA.UseVisualStyleBackColor = true;
            this.btnRSA.Click += new System.EventHandler(this.btnRSA_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(29, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "q =";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(29, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "p =";
            // 
            // tbq
            // 
            this.tbq.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbq.Location = new System.Drawing.Point(77, 175);
            this.tbq.Name = "tbq";
            this.tbq.Size = new System.Drawing.Size(97, 22);
            this.tbq.TabIndex = 10;
            // 
            // tbp
            // 
            this.tbp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbp.Location = new System.Drawing.Point(77, 136);
            this.tbp.Name = "tbp";
            this.tbp.Size = new System.Drawing.Size(97, 22);
            this.tbp.TabIndex = 9;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(758, 31);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(80, 20);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Random";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(758, 57);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(109, 20);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Enter yourself";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(758, 83);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(111, 20);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Read from file";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(668, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 20);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "IDEA";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(668, 57);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(57, 20);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Text = "RSA";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(486, 178);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 46);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save in file";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPerevirka
            // 
            this.btnPerevirka.Location = new System.Drawing.Point(891, 279);
            this.btnPerevirka.Name = "btnPerevirka";
            this.btnPerevirka.Size = new System.Drawing.Size(151, 67);
            this.btnPerevirka.TabIndex = 19;
            this.btnPerevirka.Text = "Digital signature\r\nverification";
            this.btnPerevirka.UseVisualStyleBackColor = true;
            this.btnPerevirka.Click += new System.EventHandler(this.btnPerevirka_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(937, 29);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 31);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReadIdeaKey
            // 
            this.btnReadIdeaKey.Location = new System.Drawing.Point(891, 352);
            this.btnReadIdeaKey.Name = "btnReadIdeaKey";
            this.btnReadIdeaKey.Size = new System.Drawing.Size(151, 67);
            this.btnReadIdeaKey.TabIndex = 21;
            this.btnReadIdeaKey.Text = "Read IDEA key";
            this.btnReadIdeaKey.UseVisualStyleBackColor = true;
            this.btnReadIdeaKey.Click += new System.EventHandler(this.btnReadIdeaKey_Click);
            // 
            // btnReadRSAkeys
            // 
            this.btnReadRSAkeys.Location = new System.Drawing.Point(891, 425);
            this.btnReadRSAkeys.Name = "btnReadRSAkeys";
            this.btnReadRSAkeys.Size = new System.Drawing.Size(151, 58);
            this.btnReadRSAkeys.TabIndex = 22;
            this.btnReadRSAkeys.Text = "Read RSA keys";
            this.btnReadRSAkeys.UseVisualStyleBackColor = true;
            this.btnReadRSAkeys.Click += new System.EventHandler(this.btnReadRSAkeys_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 622);
            this.Controls.Add(this.btnReadRSAkeys);
            this.Controls.Add(this.btnReadIdeaKey);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPerevirka);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbq);
            this.Controls.Add(this.tbp);
            this.Controls.Add(this.btnRSA);
            this.Controls.Add(this.btnIDEA_E);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.tbSymkey);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSymkey;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnIDEA_E;
        private System.Windows.Forms.Button btnRSA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbq;
        private System.Windows.Forms.TextBox tbp;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPerevirka;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReadIdeaKey;
        private System.Windows.Forms.Button btnReadRSAkeys;
    }
}

