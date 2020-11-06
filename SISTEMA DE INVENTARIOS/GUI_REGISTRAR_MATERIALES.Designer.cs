namespace SISTEMA_DE_INVENTARIOS
{
    partial class GUI_REGISTRAR_MATERIALES
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelInches = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelSave = new System.Windows.Forms.Label();
            this.labelErase = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 445);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "NOMBRE";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(76, 5);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 23);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(76, 34);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(100, 23);
            this.textBoxHeight.TabIndex = 3;
            this.textBoxHeight.TextChanged += new System.EventHandler(this.textBoxHeight_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "LARGO(M)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "ANCHO(M)";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(75, 70);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(100, 23);
            this.textBoxWidth.TabIndex = 6;
            this.textBoxWidth.TextChanged += new System.EventHandler(this.textBoxWidth_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "MEDIDA";
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Location = new System.Drawing.Point(238, 37);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(121, 23);
            this.comboBoxSize.TabIndex = 8;
            this.comboBoxSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxSize_SelectedIndexChanged);
            this.comboBoxSize.TextChanged += new System.EventHandler(this.comboBoxSize_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "PRECIO";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(237, 70);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 23);
            this.textBoxPrice.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(10, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 10);
            this.label6.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelInches);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(62, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 205);
            this.panel2.TabIndex = 12;
            // 
            // labelInches
            // 
            this.labelInches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInches.Location = new System.Drawing.Point(38, 99);
            this.labelInches.Name = "labelInches";
            this.labelInches.Size = new System.Drawing.Size(130, 19);
            this.labelInches.TabIndex = 14;
            this.labelInches.Text = "PULGADAS";
            this.labelInches.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(26, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 177);
            this.label8.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(10, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 177);
            this.label7.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelWidth);
            this.panel3.Controls.Add(this.labelHeight);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(28, 115);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(309, 240);
            this.panel3.TabIndex = 13;
            // 
            // labelWidth
            // 
            this.labelWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWidth.Location = new System.Drawing.Point(0, -1);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(309, 25);
            this.labelWidth.TabIndex = 14;
            this.labelWidth.Text = "ANCHO";
            this.labelWidth.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelHeight
            // 
            this.labelHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHeight.Location = new System.Drawing.Point(-1, 90);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(67, 67);
            this.labelHeight.TabIndex = 13;
            this.labelHeight.Text = "LARGO";
            this.labelHeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSave
            // 
            this.labelSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSave.Location = new System.Drawing.Point(1, 388);
            this.labelSave.Name = "labelSave";
            this.labelSave.Size = new System.Drawing.Size(161, 56);
            this.labelSave.TabIndex = 14;
            this.labelSave.Text = "GUARDAR";
            this.labelSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSave.Click += new System.EventHandler(this.labelSave_Click);
            // 
            // labelErase
            // 
            this.labelErase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelErase.Location = new System.Drawing.Point(198, 388);
            this.labelErase.Name = "labelErase";
            this.labelErase.Size = new System.Drawing.Size(161, 56);
            this.labelErase.TabIndex = 15;
            this.labelErase.Text = "ELIMINAR";
            this.labelErase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelErase.Click += new System.EventHandler(this.labelErase_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBoxName);
            this.panel4.Controls.Add(this.labelErase);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.labelSave);
            this.panel4.Controls.Add(this.textBoxHeight);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.comboBoxSize);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.textBoxPrice);
            this.panel4.Controls.Add(this.textBoxWidth);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(198, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(359, 444);
            this.panel4.TabIndex = 16;
            // 
            // GUI_REGISTRAR_MATERIALES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 450);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "GUI_REGISTRAR_MATERIALES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI_INSTRUMENTOS_UNO_Y_DOS";
            this.Load += new System.EventHandler(this.GUI_INSTRUMENTOS_UNO_Y_DOS_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelInches;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelSave;
        private System.Windows.Forms.Label labelErase;
        private System.Windows.Forms.Panel panel4;
    }
}