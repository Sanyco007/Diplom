namespace TestTool
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImportXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExportToCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpCreate = new System.Windows.Forms.TabPage();
            this.bAnalyze = new System.Windows.Forms.Button();
            this.bDeleteTest = new System.Windows.Forms.Button();
            this.bDeleteQuestion = new System.Windows.Forms.Button();
            this.bEditQuestion = new System.Windows.Forms.Button();
            this.bAddQuestion = new System.Windows.Forms.Button();
            this.dgvQuestion = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.bEditTest = new System.Windows.Forms.Button();
            this.bAddNewTest = new System.Windows.Forms.Button();
            this.dgvTest = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tpAnalyze = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb2D = new System.Windows.Forms.RadioButton();
            this.rb3D = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTextType = new System.Windows.Forms.RadioButton();
            this.rbPieType = new System.Windows.Forms.RadioButton();
            this.rbColumnType = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).BeginInit();
            this.tpAnalyze.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(705, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImportXML,
            this.toolStripMenuItem1,
            this.tsmiExportToCSV,
            this.toolStripMenuItem2,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 20);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiImportXML
            // 
            this.tsmiImportXML.Name = "tsmiImportXML";
            this.tsmiImportXML.Size = new System.Drawing.Size(249, 22);
            this.tsmiImportXML.Text = "Імпортувати відповіді з XML";
            this.tsmiImportXML.Click += new System.EventHandler(this.TsmiImportXmlClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(246, 6);
            // 
            // tsmiExportToCSV
            // 
            this.tsmiExportToCSV.Name = "tsmiExportToCSV";
            this.tsmiExportToCSV.Size = new System.Drawing.Size(249, 22);
            this.tsmiExportToCSV.Text = "Експорувати опитування в  XML";
            this.tsmiExportToCSV.Click += new System.EventHandler(this.TsmiExportToCsvClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(246, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(249, 22);
            this.tsmiExit.Text = "Вихід";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpCreate);
            this.tabControl.Controls.Add(this.tpAnalyze);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(705, 423);
            this.tabControl.TabIndex = 1;
            // 
            // tpCreate
            // 
            this.tpCreate.BackColor = System.Drawing.SystemColors.Control;
            this.tpCreate.Controls.Add(this.bAnalyze);
            this.tpCreate.Controls.Add(this.bDeleteTest);
            this.tpCreate.Controls.Add(this.bDeleteQuestion);
            this.tpCreate.Controls.Add(this.bEditQuestion);
            this.tpCreate.Controls.Add(this.bAddQuestion);
            this.tpCreate.Controls.Add(this.dgvQuestion);
            this.tpCreate.Controls.Add(this.label2);
            this.tpCreate.Controls.Add(this.bEditTest);
            this.tpCreate.Controls.Add(this.bAddNewTest);
            this.tpCreate.Controls.Add(this.dgvTest);
            this.tpCreate.Controls.Add(this.label1);
            this.tpCreate.Location = new System.Drawing.Point(4, 22);
            this.tpCreate.Name = "tpCreate";
            this.tpCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tpCreate.Size = new System.Drawing.Size(697, 397);
            this.tpCreate.TabIndex = 0;
            this.tpCreate.Text = "Створення";
            // 
            // bAnalyze
            // 
            this.bAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAnalyze.Location = new System.Drawing.Point(261, 362);
            this.bAnalyze.Name = "bAnalyze";
            this.bAnalyze.Size = new System.Drawing.Size(133, 27);
            this.bAnalyze.TabIndex = 10;
            this.bAnalyze.Text = "Аналізувати";
            this.bAnalyze.UseVisualStyleBackColor = true;
            this.bAnalyze.Click += new System.EventHandler(this.bAnalyze_Click);
            // 
            // bDeleteTest
            // 
            this.bDeleteTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bDeleteTest.Location = new System.Drawing.Point(169, 362);
            this.bDeleteTest.Name = "bDeleteTest";
            this.bDeleteTest.Size = new System.Drawing.Size(73, 27);
            this.bDeleteTest.TabIndex = 9;
            this.bDeleteTest.Text = "Видалити";
            this.bDeleteTest.UseVisualStyleBackColor = true;
            // 
            // bDeleteQuestion
            // 
            this.bDeleteQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bDeleteQuestion.Location = new System.Drawing.Point(616, 362);
            this.bDeleteQuestion.Name = "bDeleteQuestion";
            this.bDeleteQuestion.Size = new System.Drawing.Size(73, 27);
            this.bDeleteQuestion.TabIndex = 8;
            this.bDeleteQuestion.Text = "Видалити";
            this.bDeleteQuestion.UseVisualStyleBackColor = true;
            this.bDeleteQuestion.Click += new System.EventHandler(this.bDeleteQuestion_Click);
            // 
            // bEditQuestion
            // 
            this.bEditQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bEditQuestion.Location = new System.Drawing.Point(537, 362);
            this.bEditQuestion.Name = "bEditQuestion";
            this.bEditQuestion.Size = new System.Drawing.Size(73, 27);
            this.bEditQuestion.TabIndex = 7;
            this.bEditQuestion.Text = "Редагувати";
            this.bEditQuestion.UseVisualStyleBackColor = true;
            this.bEditQuestion.Click += new System.EventHandler(this.bEditQuestion_Click);
            // 
            // bAddQuestion
            // 
            this.bAddQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddQuestion.Location = new System.Drawing.Point(458, 362);
            this.bAddQuestion.Name = "bAddQuestion";
            this.bAddQuestion.Size = new System.Drawing.Size(73, 27);
            this.bAddQuestion.TabIndex = 6;
            this.bAddQuestion.Text = "Додати";
            this.bAddQuestion.UseVisualStyleBackColor = true;
            this.bAddQuestion.Click += new System.EventHandler(this.bAddQuestion_Click);
            // 
            // dgvQuestion
            // 
            this.dgvQuestion.AllowUserToAddRows = false;
            this.dgvQuestion.AllowUserToDeleteRows = false;
            this.dgvQuestion.AllowUserToResizeRows = false;
            this.dgvQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuestion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuestion.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuestion.Location = new System.Drawing.Point(261, 31);
            this.dgvQuestion.Name = "dgvQuestion";
            this.dgvQuestion.RowHeadersVisible = false;
            this.dgvQuestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestion.ShowCellErrors = false;
            this.dgvQuestion.ShowCellToolTips = false;
            this.dgvQuestion.ShowEditingIcon = false;
            this.dgvQuestion.ShowRowErrors = false;
            this.dgvQuestion.Size = new System.Drawing.Size(428, 325);
            this.dgvQuestion.TabIndex = 5;
            this.dgvQuestion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuestion_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Запитання:";
            // 
            // bEditTest
            // 
            this.bEditTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bEditTest.Location = new System.Drawing.Point(91, 362);
            this.bEditTest.Name = "bEditTest";
            this.bEditTest.Size = new System.Drawing.Size(74, 27);
            this.bEditTest.TabIndex = 3;
            this.bEditTest.Text = "Редагувати";
            this.bEditTest.UseVisualStyleBackColor = true;
            // 
            // bAddNewTest
            // 
            this.bAddNewTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAddNewTest.Location = new System.Drawing.Point(14, 362);
            this.bAddNewTest.Name = "bAddNewTest";
            this.bAddNewTest.Size = new System.Drawing.Size(73, 27);
            this.bAddNewTest.TabIndex = 2;
            this.bAddNewTest.Text = "Додати";
            this.bAddNewTest.UseVisualStyleBackColor = true;
            this.bAddNewTest.Click += new System.EventHandler(this.bAddNewTest_Click);
            // 
            // dgvTest
            // 
            this.dgvTest.AllowUserToAddRows = false;
            this.dgvTest.AllowUserToDeleteRows = false;
            this.dgvTest.AllowUserToResizeRows = false;
            this.dgvTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTest.BackgroundColor = System.Drawing.Color.White;
            this.dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTest.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTest.Location = new System.Drawing.Point(14, 31);
            this.dgvTest.Name = "dgvTest";
            this.dgvTest.RowHeadersVisible = false;
            this.dgvTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTest.ShowCellErrors = false;
            this.dgvTest.ShowCellToolTips = false;
            this.dgvTest.ShowEditingIcon = false;
            this.dgvTest.ShowRowErrors = false;
            this.dgvTest.Size = new System.Drawing.Size(228, 325);
            this.dgvTest.TabIndex = 1;
            this.dgvTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTest_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Опитування:";
            // 
            // tpAnalyze
            // 
            this.tpAnalyze.BackColor = System.Drawing.SystemColors.Control;
            this.tpAnalyze.Controls.Add(this.groupBox2);
            this.tpAnalyze.Controls.Add(this.groupBox1);
            this.tpAnalyze.Controls.Add(this.label3);
            this.tpAnalyze.Controls.Add(this.chartPie);
            this.tpAnalyze.Controls.Add(this.tbResult);
            this.tpAnalyze.Location = new System.Drawing.Point(4, 22);
            this.tpAnalyze.Name = "tpAnalyze";
            this.tpAnalyze.Padding = new System.Windows.Forms.Padding(3);
            this.tpAnalyze.Size = new System.Drawing.Size(697, 397);
            this.tpAnalyze.TabIndex = 1;
            this.tpAnalyze.Text = "Аналіз";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rb2D);
            this.groupBox2.Controls.Add(this.rb3D);
            this.groupBox2.Location = new System.Drawing.Point(541, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 81);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Відображення";
            // 
            // rb2D
            // 
            this.rb2D.AutoSize = true;
            this.rb2D.Location = new System.Drawing.Point(14, 51);
            this.rb2D.Name = "rb2D";
            this.rb2D.Size = new System.Drawing.Size(39, 17);
            this.rb2D.TabIndex = 1;
            this.rb2D.Text = "2D";
            this.rb2D.UseVisualStyleBackColor = true;
            this.rb2D.CheckedChanged += new System.EventHandler(this.radioView_CheckedChanged);
            // 
            // rb3D
            // 
            this.rb3D.AutoSize = true;
            this.rb3D.Checked = true;
            this.rb3D.Location = new System.Drawing.Point(14, 28);
            this.rb3D.Name = "rb3D";
            this.rb3D.Size = new System.Drawing.Size(39, 17);
            this.rb3D.TabIndex = 0;
            this.rb3D.TabStop = true;
            this.rb3D.Text = "3D";
            this.rb3D.UseVisualStyleBackColor = true;
            this.rb3D.CheckedChanged += new System.EventHandler(this.radioView_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbTextType);
            this.groupBox1.Controls.Add(this.rbPieType);
            this.groupBox1.Controls.Add(this.rbColumnType);
            this.groupBox1.Location = new System.Drawing.Point(541, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 105);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип відображення";
            // 
            // rbTextType
            // 
            this.rbTextType.AutoSize = true;
            this.rbTextType.Location = new System.Drawing.Point(14, 74);
            this.rbTextType.Name = "rbTextType";
            this.rbTextType.Size = new System.Drawing.Size(55, 17);
            this.rbTextType.TabIndex = 2;
            this.rbTextType.Text = "Текст";
            this.rbTextType.UseVisualStyleBackColor = true;
            this.rbTextType.CheckedChanged += new System.EventHandler(this.radioType_CheckedChanged);
            // 
            // rbPieType
            // 
            this.rbPieType.AutoSize = true;
            this.rbPieType.Location = new System.Drawing.Point(14, 51);
            this.rbPieType.Name = "rbPieType";
            this.rbPieType.Size = new System.Drawing.Size(114, 17);
            this.rbPieType.TabIndex = 1;
            this.rbPieType.Tag = "Singlechoose";
            this.rbPieType.Text = "Кругова діаграма";
            this.rbPieType.UseVisualStyleBackColor = true;
            this.rbPieType.CheckedChanged += new System.EventHandler(this.radioType_CheckedChanged);
            // 
            // rbColumnType
            // 
            this.rbColumnType.AutoSize = true;
            this.rbColumnType.Checked = true;
            this.rbColumnType.Location = new System.Drawing.Point(14, 28);
            this.rbColumnType.Name = "rbColumnType";
            this.rbColumnType.Size = new System.Drawing.Size(125, 17);
            this.rbColumnType.TabIndex = 0;
            this.rbColumnType.TabStop = true;
            this.rbColumnType.Tag = "Multichoose";
            this.rbColumnType.Text = "Стовчаста діаграма";
            this.rbColumnType.UseVisualStyleBackColor = true;
            this.rbColumnType.CheckedChanged += new System.EventHandler(this.radioType_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Результат:";
            // 
            // chartPie
            // 
            this.chartPie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartPie.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.WallWidth = 4;
            chartArea1.Name = "ChartArea1";
            this.chartPie.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "PieLegend";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.chartPie.Legends.Add(legend1);
            this.chartPie.Location = new System.Drawing.Point(18, 30);
            this.chartPie.Name = "chartPie";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "PieLegend";
            series1.Name = "Column";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Enabled = false;
            series2.Legend = "PieLegend";
            series2.Name = "Pie";
            this.chartPie.Series.Add(series1);
            this.chartPie.Series.Add(series2);
            this.chartPie.Size = new System.Drawing.Size(523, 337);
            this.chartPie.TabIndex = 0;
            title1.Name = "ColumnTitle";
            title1.Text = "123";
            this.chartPie.Titles.Add(title1);
            // 
            // tbResult
            // 
            this.tbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResult.Location = new System.Drawing.Point(18, 30);
            this.tbResult.MaxLength = 65536;
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResult.Size = new System.Drawing.Size(517, 337);
            this.tbResult.TabIndex = 4;
            this.tbResult.Visible = false;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.FileName = "untitled.xml";
            this.saveFileDialog.Filter = "XML File (*.xml)|*.xml";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xml";
            this.openFileDialog.Filter = "XML File (*.xml)|*.xml";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 447);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Створення та аналіз опитувань";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tpCreate.ResumeLayout(false);
            this.tpCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).EndInit();
            this.tpAnalyze.ResumeLayout(false);
            this.tpAnalyze.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportToCSV;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpCreate;
        private System.Windows.Forms.TabPage tpAnalyze;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTest;
        private System.Windows.Forms.Button bAddNewTest;
        private System.Windows.Forms.Button bEditTest;
        private System.Windows.Forms.DataGridView dgvQuestion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bDeleteQuestion;
        private System.Windows.Forms.Button bEditQuestion;
        private System.Windows.Forms.Button bAddQuestion;
        private System.Windows.Forms.Button bDeleteTest;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem tsmiImportXML;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button bAnalyze;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTextType;
        private System.Windows.Forms.RadioButton rbPieType;
        private System.Windows.Forms.RadioButton rbColumnType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb2D;
        private System.Windows.Forms.RadioButton rb3D;
        private System.Windows.Forms.TextBox tbResult;
    }
}

