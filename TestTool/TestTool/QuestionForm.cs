using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestTool.Properties;

namespace TestTool
{
    public partial class QuestionForm : Form
    {
        public static string Question;
        public static string Type;
        public static string Variants;

        private readonly List<Label> _labelvars = new List<Label>();
        private readonly List<TextBox> _textvars = new List<TextBox>();

        public QuestionForm(string question = null, string type = "Simple", string variants = null)
        {
            InitializeComponent();
            _labelvars.Add(lVariant01);
            _textvars.Add(tbVariant1);
            if (question != null)
            {
                tbTitle.Text = question;
            }
            Type = type;
            if (Type == "Multichoose" || Type == "Singlechoose")
            {
                gbChoose.Enabled = true;
            }
            else gbChoose.Enabled = false;
            Variants = variants;
            if (Variants != null)
            {
                var values = Variants.Split('~');
                ShowVariants(values);
            }
        }

        private void ShowVariants(string[] values)
        {
            for (int i = 1; i < values.Length; i++)
            {
                bAddVariant_Click(this, null);
            }
            int index = 0;
            foreach (var item in _textvars)
            {
                item.Text = values[index++];
            }
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            var button = sender as RadioButton;
            if (button != null)
            {
                Type = button.Text;
                if (Type == "Multichoose" || Type == "Singlechoose")
                {
                    gbChoose.Enabled = true;
                }
                else gbChoose.Enabled = false;
            }
        }

        private void bAddVariant_Click(object sender, EventArgs e)
        {
            _labelvars.Add(new Label
            {
                Text = Resources.VariantText + (_labelvars.Count + 1) + Resources.DivideSymbol,
                Top = _labelvars[_labelvars.Count - 1].Top + 27,
                Left = 11,
                AutoSize = true
            });
            _textvars.Add(new TextBox
            {
                Width = 272,
                Top = _textvars[_textvars.Count - 1].Top + 27,
                Left = 75
            });
            panel.Controls.Add(_labelvars[_labelvars.Count - 1]);
            panel.Controls.Add(_textvars[_textvars.Count - 1]);
            bAddVariant.Top += 27;
            bDeleteVariant.Top += 27;
        }

        private void bDeleteVariant_Click(object sender, EventArgs e)
        {
            if (_labelvars.Count <= 1) return;
            panel.Controls.Remove(_labelvars[_labelvars.Count - 1]);
            panel.Controls.Remove(_textvars[_textvars.Count - 1]);
            _labelvars.RemoveAt(_labelvars.Count - 1);
            _textvars.RemoveAt(_textvars.Count - 1);
            bAddVariant.Top -= 27;
            bDeleteVariant.Top -= 27;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Question = null;
            Type = null;
            Variants = null;
            Close();
        }

        private void BOkClick(object sender, EventArgs e)
        {
            Question = tbTitle.Text;
            Variants = "";
            if (Type == "Multichoose" || Type == "Singlechoose")
            {
                for (int i = 0; i < _textvars.Count; i++)
                {
                    Variants += _textvars[i].Text;
                    if (i != _textvars.Count - 1) Variants += "~";
                }
            }
            Close();
        }
    }
}
