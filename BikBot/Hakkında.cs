using System;
using System.Windows.Forms;

namespace BikBot
{
    public partial class Hakkında : Form
    {
        public Hakkında()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Click += delegate { Dispose(); };
        }
    }
}