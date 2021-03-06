
namespace MMC_LiamRaj
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
            this._dgv = new System.Windows.Forms.DataGridView();
            this.button_Sort_Name = new System.Windows.Forms.Button();
            this.button_Char_Symb = new System.Windows.Forms.Button();
            this.button_Sort_Atomic = new System.Windows.Forms.Button();
            this.labelChem = new System.Windows.Forms.Label();
            this.textBoxChemFormula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMolarMass = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgv
            // 
            this._dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgv.Location = new System.Drawing.Point(15, 10);
            this._dgv.Margin = new System.Windows.Forms.Padding(2);
            this._dgv.Name = "_dgv";
            this._dgv.RowHeadersWidth = 51;
            this._dgv.RowTemplate.Height = 24;
            this._dgv.Size = new System.Drawing.Size(410, 254);
            this._dgv.TabIndex = 0;
            // 
            // button_Sort_Name
            // 
            this.button_Sort_Name.Location = new System.Drawing.Point(430, 10);
            this.button_Sort_Name.Margin = new System.Windows.Forms.Padding(2);
            this.button_Sort_Name.Name = "button_Sort_Name";
            this.button_Sort_Name.Size = new System.Drawing.Size(143, 25);
            this.button_Sort_Name.TabIndex = 1;
            this.button_Sort_Name.Text = "Sort By Name";
            this.button_Sort_Name.UseVisualStyleBackColor = true;
            // 
            // button_Char_Symb
            // 
            this.button_Char_Symb.Location = new System.Drawing.Point(429, 40);
            this.button_Char_Symb.Margin = new System.Windows.Forms.Padding(2);
            this.button_Char_Symb.Name = "button_Char_Symb";
            this.button_Char_Symb.Size = new System.Drawing.Size(144, 25);
            this.button_Char_Symb.TabIndex = 2;
            this.button_Char_Symb.Text = "Single Character Symbols";
            this.button_Char_Symb.UseVisualStyleBackColor = true;
            // 
            // button_Sort_Atomic
            // 
            this.button_Sort_Atomic.Location = new System.Drawing.Point(429, 69);
            this.button_Sort_Atomic.Margin = new System.Windows.Forms.Padding(2);
            this.button_Sort_Atomic.Name = "button_Sort_Atomic";
            this.button_Sort_Atomic.Size = new System.Drawing.Size(144, 25);
            this.button_Sort_Atomic.TabIndex = 3;
            this.button_Sort_Atomic.Text = "Sort By Atomic #";
            this.button_Sort_Atomic.UseVisualStyleBackColor = true;
            // 
            // labelChem
            // 
            this.labelChem.AutoSize = true;
            this.labelChem.Location = new System.Drawing.Point(13, 284);
            this.labelChem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelChem.Name = "labelChem";
            this.labelChem.Size = new System.Drawing.Size(93, 13);
            this.labelChem.TabIndex = 4;
            this.labelChem.Text = "Chemical Formula:";
            // 
            // textBoxChemFormula
            // 
            this.textBoxChemFormula.Location = new System.Drawing.Point(110, 284);
            this.textBoxChemFormula.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxChemFormula.Name = "textBoxChemFormula";
            this.textBoxChemFormula.Size = new System.Drawing.Size(174, 20);
            this.textBoxChemFormula.TabIndex = 5;
            this.textBoxChemFormula.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 284);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Approx Molar Mass:";
            // 
            // labelMolarMass
            // 
            this.labelMolarMass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMolarMass.Location = new System.Drawing.Point(430, 284);
            this.labelMolarMass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMolarMass.Name = "labelMolarMass";
            this.labelMolarMass.Size = new System.Drawing.Size(143, 20);
            this.labelMolarMass.TabIndex = 7;
            this.labelMolarMass.Text = "0";
            this.labelMolarMass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.labelMolarMass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxChemFormula);
            this.Controls.Add(this.labelChem);
            this.Controls.Add(this.button_Sort_Atomic);
            this.Controls.Add(this.button_Char_Symb);
            this.Controls.Add(this.button_Sort_Name);
            this.Controls.Add(this._dgv);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Molecular Mass Calculator";
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _dgv;
        private System.Windows.Forms.Button button_Sort_Name;
        private System.Windows.Forms.Button button_Char_Symb;
        private System.Windows.Forms.Button button_Sort_Atomic;
        private System.Windows.Forms.Label labelChem;
        private System.Windows.Forms.TextBox textBoxChemFormula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMolarMass;
    }
}

