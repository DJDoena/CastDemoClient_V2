using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    internal partial class EditEpisodeForm : Form
    {
        private Episode m_Episode;

        public EditEpisodeForm(Episode episode)
        {
            m_Episode = episode;

            InitializeComponent();

            CastListControl.Upc = m_Episode.Upc;
            CastListControl.ShowAddEpisodeButton = false;

            NumberTextBox.Text = m_Episode.EpisodeNumber;

            TitleTextBox.Text = m_Episode.EpisodeName;
        }

        private void OnOKButtonClick(Object sender
            , EventArgs e)
        {
            if ((String.IsNullOrEmpty(TitleTextBox.Text)
                || (String.IsNullOrEmpty(NumberTextBox.Text))))
            {
                MessageBox.Show("Please enter Episode Number and Title!");

                return;
            }

            m_Episode.EpisodeName = TitleTextBox.Text;
            m_Episode.EpisodeNumber = NumberTextBox.Text;

            DialogResult = DialogResult.OK;

            Close();
        }

        private void OnAbortButtonClick(Object sender
            , EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void OnEditEpisodeFormLoad(Object sender
            , EventArgs e)
        {
            if (m_Episode.CastList == null)
            {
                m_Episode.CastList = new List<CastMember>();
            }

            CastListControl.CastListView.Roots = m_Episode.CastList;
            CastListControl.CastListView.RebuildAll(false);
            CastListControl.CastEntryAdded += OnCastListControlCastEntryAdded;
        }

        void OnCastListControlCastEntryAdded(Object sender
            , AddedEventArgs e)
        {
            m_Episode.CastList.Add((CastMember)(e.NewCastEntry));

            CastListControl.CastListView.Roots = m_Episode.CastList;
            CastListControl.CastListView.RebuildAll(true);
        }
    }
}