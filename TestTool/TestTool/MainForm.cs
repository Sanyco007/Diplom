using System;
using System.Windows.Forms;
using TestTool.Properties;
using System.Xml;

namespace TestTool
{
    public partial class MainForm : Form
    {
        private readonly DataBase _db = DataBase.GetInstance();
        private int _testId;
        private int _questionRow;

        public MainForm()
        {
            InitializeComponent();
            ShowTests();
        }

        private void ShowTests()
        {
            dgvTest.DataSource = _db.SelectTable("SELECT * FROM test");
            if (dgvTest.Columns["_id"] != null)
            {
                dgvTest.Columns["_id"].Visible = false;
            }
            if (dgvTest.Columns["title"] != null)
            {
                dgvTest.Columns["title"].HeaderText = Resources.TitleText;
            }
            if (dgvTest.Columns["create_date"] != null)
            {
                dgvTest.Columns["create_date"].HeaderText = Resources.DateText;
            }
        }

        private void ShowQuestions(int id)
        {
            dgvQuestion.DataSource = _db.SelectTable("SELECT * FROM question WHERE id_test = " + id + ";");
            if (dgvQuestion.Columns["_id"] != null)
            {
                dgvQuestion.Columns["_id"].Visible = false;
            }
            if (dgvQuestion.Columns["id_test"] != null)
            {
                dgvQuestion.Columns["id_test"].Visible = false;
            }
            if (dgvQuestion.Columns["variants"] != null)
            {
                dgvQuestion.Columns["variants"].Visible = false;
            }
            if (dgvQuestion.Columns["title"] != null)
            {
                dgvQuestion.Columns["title"].HeaderText = Resources.TitleText;
            }
            if (dgvQuestion.Columns["type"] != null)
            {
                dgvQuestion.Columns["type"].HeaderText = Resources.TypeText;
            }
            _questionRow = -1;
        }

        private void bAddNewTest_Click(object sender, EventArgs e)
        {
            new TestForm().ShowDialog(this);
            if (TestForm.Title != null)
            {
                if (_db.AddTest(TestForm.Title))
                {
                    ShowTests();
                }
            }
        }

        private void dgvTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _testId = (Int32)dgvTest.Rows[e.RowIndex].Cells["_id"].Value;
            _questionRow = -1;
            ShowQuestions(_testId);
        }

        private void bAddQuestion_Click(object sender, EventArgs e)
        {
            new QuestionForm().ShowDialog(this);
            if (QuestionForm.Question != null)
            {
                var question = QuestionForm.Question;
                var type = QuestionForm.Type;
                var variants = QuestionForm.Variants;
                if (_db.AddQuestion(_testId, question, type, variants))
                {
                    ShowQuestions(_testId);
                }
            }
        }

        private void dgvQuestion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _questionRow = e.RowIndex;
        }

        private void bEditQuestion_Click(object sender, EventArgs e)
        {
            if (_questionRow < 0) return;
            var cells = dgvQuestion.Rows[_questionRow].Cells;
            var question = (string)cells[Resources.TitleText].Value;
            var type = (string)cells[Resources.TypeText].Value;
            var variants = (string)cells["variants"].Value;
            new QuestionForm(question, type, variants).ShowDialog(this);
            if (QuestionForm.Question != null)
            {
                question = QuestionForm.Question;
                type = QuestionForm.Type;
                variants = QuestionForm.Variants;
                var id = (int)cells["_id"].Value;
                if (_db.UpdateQuestion(id, question, type, variants))
                {
                    ShowQuestions(_testId);
                }
            }
        }

        private void bDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (_questionRow < 0) return;
            var cells = dgvQuestion.Rows[_questionRow].Cells;
            var id = (int)cells["_id"].Value;
            _db.DeleteQuestion(id);
            ShowQuestions(_testId);
        }

        private void TsmiExportToCsvClick(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                _db.ExportCvs(_testId, fileName);
            }
        }

        private void TsmiImportXmlClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                var xml = new XmlDocument();
                xml.Load(fileName);
                var elemList = xml.GetElementsByTagName("Row");
                for (int i = 0; i < elemList.Count; i++)
                {
                    var nodes = elemList[i].ChildNodes;
                    string id = nodes[0].InnerText;
                    string idQuestion = nodes[1].InnerText;
                    string text = nodes[2].InnerText;
                    _db.AddAnswer(id, idQuestion, text);
                }
            }
        }

        private void bAnalyze_Click(object sender, EventArgs e)
        {
            if (_questionRow < 0) return;
            var cells = dgvQuestion.Rows[_questionRow].Cells;
            var id = (int)cells["_id"].Value;
            string type = null;
            string title = null;
            var dict = _db.GetAnswer(id, ref type, ref title);

            chartPie.Series["Column"].Points.Clear();
            chartPie.Titles["ColumnTitle"].Text = title;
            foreach (var item in dict.Keys)
            {
                chartPie.Series["Column"].Points.AddXY(item, new object[] { dict[item] });
            }

            chartPie.Series["Pie"].Points.Clear();
            chartPie.Titles["ColumnTitle"].Text = title;
            foreach (var item in dict.Keys)
            {
                chartPie.Series["Pie"].Points.AddXY(item, new object[] { dict[item] });
            }

            const string crlf = "\r\n";
            tbResult.Clear();
            tbResult.AppendText(title + crlf + crlf);
            foreach (var item in dict.Keys)
            {
                tbResult.AppendText(item + " => " + dict[item]  + crlf + crlf);
            }

            if (type == "Multichoose")
            {
                rbColumnType.Checked = true;
            }
            else if (type == "Singlechoose")
            {
                rbPieType.Checked = true;
            }
            else
            {
                rbTextType.Checked = true;
            }
            tabControl.SelectTab(1);
        }

        private void ShowGraphType(string type)
        {
            if (type == "Multichoose")
            {
                chartPie.Visible = true;
                tbResult.Visible = false;
                chartPie.Legends[0].Enabled = false;
                chartPie.Series["Pie"].Enabled = false;
                chartPie.Series["Column"].Enabled = true;
            }
            else if (type == "Singlechoose")
            {
                chartPie.Visible = true;
                tbResult.Visible = false;
                chartPie.Legends[0].Enabled = true;
                chartPie.Series["Pie"].Enabled = true;
                chartPie.Series["Column"].Enabled = false;
            }
            else
            {
                chartPie.Visible = false;
                tbResult.Visible = true;
            }
        }

        private void radioType_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                var type = radioButton.Tag as string;
                ShowGraphType(type);
            }
        }

        private void radioView_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                string text = radioButton.Text;
                chartPie.ChartAreas[0].Area3DStyle.Enable3D = text == "3D";
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
