using System;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    internal partial class EditCastForm : Form
    {
        private CastMember m_CastMember;

        private String m_PreviousCastId;

        public EditCastForm(CastMember castMember)
        {
            m_CastMember = castMember;

            m_PreviousCastId = m_CastMember.CastId;

            InitializeComponent();

            FillName();

            RoleTextBox.Text = m_CastMember.Role;

            VoiceCheckBox.Checked = m_CastMember.Voice;

            CreditedAsTextBox.Text = m_CastMember.CreditedAs;

            SetCastIdTextBox();

            OnCastIdTextBoxTextChanged(this, EventArgs.Empty);
        }

        private void SetCastIdTextBox()
        {
            if ((String.IsNullOrEmpty(m_CastMember.CastId) == false) && (m_CastMember.CastId.StartsWith(CastListControl.NewId)))
            {
                CastIdTextBox.Text = m_CastMember.CastId.Substring(CastListControl.NewId.Length);
            }
            else
            {
                CastIdTextBox.Text = m_CastMember.CastId;
            }
        }

        private void FillName()
        {
            FirstNameTextBox.Text = m_CastMember.FirstName;

            MiddleNameTextBox.Text = m_CastMember.MiddleName;

            LastNameTextBox.Text = m_CastMember.LastName;
        }

        private void OnAssignCastIdButtonClick(Object sender
            , EventArgs e)
        {
            if (CheckFirstName() == false)
            {
                return;
            }

            CastMember tempCastMember = new CastMember();

            tempCastMember.FirstName = FirstNameTextBox.Text;
            tempCastMember.MiddleName = MiddleNameTextBox.Text;
            tempCastMember.LastName = LastNameTextBox.Text;
            tempCastMember.CastId = m_CastMember.CastId;
            tempCastMember.Upc = m_CastMember.Upc;

            using (SearchForCastForm form = new SearchForCastForm(tempCastMember))
            {
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    m_CastMember.FirstName = tempCastMember.FirstName;
                    m_CastMember.MiddleName = tempCastMember.MiddleName;
                    m_CastMember.LastName = tempCastMember.LastName;
                    m_CastMember.CastId = tempCastMember.CastId;

                    SetCastIdTextBox();

                    if (String.IsNullOrEmpty(CreditedAsTextBox.Text))
                    {
                        CreditedAsTextBox.Text = FirstNameTextBox.Text;

                        if (String.IsNullOrEmpty(MiddleNameTextBox.Text) == false)
                        {
                            CreditedAsTextBox.Text += " " + MiddleNameTextBox.Text;
                        }

                        if (String.IsNullOrEmpty(LastNameTextBox.Text) == false)
                        {
                            CreditedAsTextBox.Text += " " + LastNameTextBox.Text;
                        }
                    }

                    FillName();
                }
            }
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
            if (CheckFirstName() == false)
            {
                return;
            }

            m_CastMember.FirstName = FirstNameTextBox.Text;
            m_CastMember.MiddleName = MiddleNameTextBox.Text;
            m_CastMember.LastName = LastNameTextBox.Text;
            m_CastMember.Role = RoleTextBox.Text;
            m_CastMember.Voice = VoiceCheckBox.Checked;
            m_CastMember.CreditedAs = CreditedAsTextBox.Text;
            //m_CastMember.CastId = CastIdTextBox.Text;

            DialogResult = DialogResult.OK;

            Close();
        }

        private void OnCastIdTextBoxTextChanged(Object sender
            , EventArgs e)
        {
            Boolean switcher = String.IsNullOrEmpty(CastIdTextBox.Text);

            CreditedAsTextBox.ReadOnly = switcher;

            FirstNameTextBox.ReadOnly = (switcher == false);

            MiddleNameTextBox.ReadOnly = (switcher == false);

            LastNameTextBox.ReadOnly = (switcher == false);
        }

        private void OnEditCastFormFormClosing(Object sender
            , FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                m_CastMember.CastId = m_PreviousCastId;
            }
        }

        private Boolean CheckFirstName()
        {
            if (String.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                MessageBox.Show("Please enter at least a First Name!");

                return (false);
            }

            return (true);
        }
    }
}