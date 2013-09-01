namespace TestTool
{
    partial class QuestionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.gbQType = new System.Windows.Forms.GroupBox();
            this.rbMultichoose = new System.Windows.Forms.RadioButton();
            this.rbSinglechoose = new System.Windows.Forms.RadioButton();
            this.rbSimple = new System.Windows.Forms.RadioButton();
            this.gbChoose = new System.Windows.Forms.GroupBox();
            this.panel = new System.Windows.Forms.Panel();
            this.bDeleteVariant = new System.Windows.Forms.Button();
            this.lVariant01 = new System.Windows.Forms.Label();
            this.tbVariant1 = new System.Windows.Forms.TextBox();
            this.bAddVariant = new System.Windows.Forms.Button();
            this.gbQType.SuspendLayout();
            this.gbChoose.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Запитання:";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(73, 79);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(334, 20);
            this.tbTitle.TabIndex = 1;
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(332, 336);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 2;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.BOkClick);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(251, 336);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Відмінити";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // gbQType
            // 
            this.gbQType.Controls.Add(this.rbMultichoose);
            this.gbQType.Controls.Add(this.rbSinglechoose);
            this.gbQType.Controls.Add(this.rbSimple);
            this.gbQType.Location = new System.Drawing.Point(12, 12);
            this.gbQType.Name = "gbQType";
            this.gbQType.Size = new System.Drawing.Size(395, 55);
            this.gbQType.TabIndex = 4;
            this.gbQType.TabStop = false;
            this.gbQType.Text = "Тип запитання";
            // 
            // rbMultichoose
            // 
            this.rbMultichoose.AutoSize = true;
            this.rbMultichoose.Location = new System.Drawing.Point(87, 23);
            this.rbMultichoose.Name = "rbMultichoose";
            this.rbMultichoose.Size = new System.Drawing.Size(82, 17);
            this.rbMultichoose.TabIndex = 2;
            this.rbMultichoose.Text = "Multichoose";
            this.rbMultichoose.UseVisualStyleBackColor = true;
            this.rbMultichoose.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbSinglechoose
            // 
            this.rbSinglechoose.AutoSize = true;
            this.rbSinglechoose.Location = new System.Drawing.Point(187, 23);
            this.rbSinglechoose.Name = "rbSinglechoose";
            this.rbSinglechoose.Size = new System.Drawing.Size(89, 17);
            this.rbSinglechoose.TabIndex = 1;
            this.rbSinglechoose.Text = "Singlechoose";
            this.rbSinglechoose.UseVisualStyleBackColor = true;
            this.rbSinglechoose.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbSimple
            // 
            this.rbSimple.AutoSize = true;
            this.rbSimple.Checked = true;
            this.rbSimple.Location = new System.Drawing.Point(17, 23);
            this.rbSimple.Name = "rbSimple";
            this.rbSimple.Size = new System.Drawing.Size(56, 17);
            this.rbSimple.TabIndex = 0;
            this.rbSimple.TabStop = true;
            this.rbSimple.Text = "Simple";
            this.rbSimple.UseVisualStyleBackColor = true;
            this.rbSimple.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // gbChoose
            // 
            this.gbChoose.Controls.Add(this.panel);
            this.gbChoose.Enabled = false;
            this.gbChoose.Location = new System.Drawing.Point(12, 115);
            this.gbChoose.Name = "gbChoose";
            this.gbChoose.Size = new System.Drawing.Size(395, 215);
            this.gbChoose.TabIndex = 5;
            this.gbChoose.TabStop = false;
            this.gbChoose.Text = "Варіанти відповідей";
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.bDeleteVariant);
            this.panel.Controls.Add(this.lVariant01);
            this.panel.Controls.Add(this.tbVariant1);
            this.panel.Controls.Add(this.bAddVariant);
            this.panel.Location = new System.Drawing.Point(11, 18);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(376, 189);
            this.panel.TabIndex = 3;
            // 
            // bDeleteVariant
            // 
            this.bDeleteVariant.Location = new System.Drawing.Point(95, 47);
            this.bDeleteVariant.Name = "bDeleteVariant";
            this.bDeleteVariant.Size = new System.Drawing.Size(75, 23);
            this.bDeleteVariant.TabIndex = 3;
            this.bDeleteVariant.Text = "Видалити";
            this.bDeleteVariant.UseVisualStyleBackColor = true;
            this.bDeleteVariant.Click += new System.EventHandler(this.bDeleteVariant_Click);
            // 
            // lVariant01
            // 
            this.lVariant01.AutoSize = true;
            this.lVariant01.Location = new System.Drawing.Point(11, 15);
            this.lVariant01.Name = "lVariant01";
            this.lVariant01.Size = new System.Drawing.Size(57, 13);
            this.lVariant01.TabIndex = 1;
            this.lVariant01.Text = "Варіант 1:";
            // 
            // tbVariant1
            // 
            this.tbVariant1.Location = new System.Drawing.Point(75, 12);
            this.tbVariant1.Name = "tbVariant1";
            this.tbVariant1.Size = new System.Drawing.Size(272, 20);
            this.tbVariant1.TabIndex = 2;
            // 
            // bAddVariant
            // 
            this.bAddVariant.Location = new System.Drawing.Point(14, 47);
            this.bAddVariant.Name = "bAddVariant";
            this.bAddVariant.Size = new System.Drawing.Size(75, 23);
            this.bAddVariant.TabIndex = 0;
            this.bAddVariant.Text = "Додати";
            this.bAddVariant.UseVisualStyleBackColor = true;
            this.bAddVariant.Click += new System.EventHandler(this.bAddVariant_Click);
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 371);
            this.Controls.Add(this.gbChoose);
            this.Controls.Add(this.gbQType);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Запитання";
            this.gbQType.ResumeLayout(false);
            this.gbQType.PerformLayout();
            this.gbChoose.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.GroupBox gbQType;
        private System.Windows.Forms.RadioButton rbMultichoose;
        private System.Windows.Forms.RadioButton rbSinglechoose;
        private System.Windows.Forms.RadioButton rbSimple;
        private System.Windows.Forms.GroupBox gbChoose;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lVariant01;
        private System.Windows.Forms.TextBox tbVariant1;
        private System.Windows.Forms.Button bAddVariant;
        private System.Windows.Forms.Button bDeleteVariant;
    }
}