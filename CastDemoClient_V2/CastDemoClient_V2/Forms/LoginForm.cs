using System;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    public partial class LoginForm : Form
    {
        private Settings m_Settings;

        public LoginForm(Settings settings)
        {
            m_Settings = settings;

            InitializeComponent();
        }

        private void OnAbortButtonClick(Object sender
            , EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void OnOKButtonClick(Object sender
            , EventArgs e)
        {
            if (String.IsNullOrEmpty(UserNameTexBox.Text))
            {
                MessageBox.Show("Please enter User Name or cancel.");

                return;
            }

            m_Settings.UserName = UserNameTexBox.Text;

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}