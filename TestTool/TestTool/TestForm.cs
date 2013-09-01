using System;
using System.Windows.Forms;

namespace TestTool
{
    public partial class TestForm : Form
    {
        public static string Title;

        public TestForm()
        {
            InitializeComponent();
            Title = null;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            Title = tbTitle.Text;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Title = null;
            Close();
        }
    }
}
