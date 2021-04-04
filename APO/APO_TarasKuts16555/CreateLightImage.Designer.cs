namespace APO_TarasKuts16555
{
    partial class CreateLightImage
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOK_LINE = new System.Windows.Forms.Button();
            this.rdHorizontal = new System.Windows.Forms.RadioButton();
            this.rdVertical = new System.Windows.Forms.RadioButton();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOK_CROPS = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOK_LINE);
            this.groupBox2.Controls.Add(this.rdHorizontal);
            this.groupBox2.Controls.Add(this.rdVertical);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(12, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 89);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Line";
            // 
            // btnOK_LINE
            // 
            this.btnOK_LINE.BackColor = System.Drawing.Color.Lime;
            this.btnOK_LINE.Location = new System.Drawing.Point(100, 39);
            this.btnOK_LINE.Name = "btnOK_LINE";
            this.btnOK_LINE.Size = new System.Drawing.Size(71, 41);
            this.btnOK_LINE.TabIndex = 2;
            this.btnOK_LINE.Text = "OK";
            this.btnOK_LINE.UseVisualStyleBackColor = false;
            this.btnOK_LINE.Click += new System.EventHandler(this.btnOK_LINE_Click);
            // 
            // rdHorizontal
            // 
            this.rdHorizontal.AutoSize = true;
            this.rdHorizontal.Location = new System.Drawing.Point(94, 19);
            this.rdHorizontal.Name = "rdHorizontal";
            this.rdHorizontal.Size = new System.Drawing.Size(93, 18);
            this.rdHorizontal.TabIndex = 3;
            this.rdHorizontal.TabStop = true;
            this.rdHorizontal.Text = "Horizontal";
            this.rdHorizontal.UseVisualStyleBackColor = true;
            // 
            // rdVertical
            // 
            this.rdVertical.AutoSize = true;
            this.rdVertical.Location = new System.Drawing.Point(12, 19);
            this.rdVertical.Name = "rdVertical";
            this.rdVertical.Size = new System.Drawing.Size(76, 18);
            this.rdVertical.TabIndex = 2;
            this.rdVertical.TabStop = true;
            this.rdVertical.Text = "Vertical";
            this.rdVertical.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(12, 42);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(44, 22);
            this.numericUpDown2.TabIndex = 0;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(12, 221);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(187, 42);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOK_CROPS);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 77);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crops in %";
            // 
            // btnOK_CROPS
            // 
            this.btnOK_CROPS.BackColor = System.Drawing.Color.Lime;
            this.btnOK_CROPS.Location = new System.Drawing.Point(100, 25);
            this.btnOK_CROPS.Name = "btnOK_CROPS";
            this.btnOK_CROPS.Size = new System.Drawing.Size(71, 39);
            this.btnOK_CROPS.TabIndex = 2;
            this.btnOK_CROPS.Text = "OK";
            this.btnOK_CROPS.UseVisualStyleBackColor = false;
            this.btnOK_CROPS.Click += new System.EventHandler(this.btnOK_CROPS_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 42);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(44, 22);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CreateLightImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 281);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Name = "CreateLightImage";
            this.Text = "LlightImage";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOK_LINE;
        private System.Windows.Forms.RadioButton rdHorizontal;
        private System.Windows.Forms.RadioButton rdVertical;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK_CROPS;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}