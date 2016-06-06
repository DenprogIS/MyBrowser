using System.Windows.Forms;

namespace Browser
{
    public partial class info : Form
    {
        public bool linkClicked;
        public info()
        {
            InitializeComponent();
            linkClicked = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            linkClicked = true;
        }
    }
}
