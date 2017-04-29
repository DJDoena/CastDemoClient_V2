using System;
using System.Windows.Forms;
using BrightIdeasSoftware;
using DoenaSoft.DVDProfiler.CastDemoClient_V2.Resources;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    internal partial class CastListControl : UserControl
    {
        public const String NewId = "<newid> ";

        internal Boolean ShowAddEpisodeButton;

        internal String Upc;

        internal event EventHandler<AddedEventArgs> CastEntryAdded;

        public CastListControl()
        {
            InitializeComponent();
        }

        private void CastListControl_Load(object sender, EventArgs e)
        {
            CastIdColumn.Renderer = new MappedImageRenderer(new Object[] { "check", GridResources.tick16, "newid", GridResources.star16 });

            CastIdColumn.AspectGetter = (row =>
                    {
                        CastEntry entry = (CastEntry)row;

                        if (String.IsNullOrEmpty(entry.CastId) == false)
                        {
                            if (entry.CastId.StartsWith(NewId))
                            {
                                return ("newid");
                            }

                            return ("check");
                        }
                        else
                        {
                            return (null);
                        }
                    }
               );

            CastListView.CanExpandGetter = (castEntry =>
                    {
                        Episode episode = castEntry as Episode;

                        if (episode != null)
                        {
                            return (episode.CastList?.Count > 0);
                        }

                        return (false);
                    }
                );

            CastListView.ChildrenGetter = (castEntry => ((Episode)castEntry).CastList);

            if (ShowAddEpisodeButton == false)
            {
                AddEpisodeButton.Enabled = false;
            }
        }

        private void OnAddCastButtonClick(Object sender
            , EventArgs e)
        {
            CastMember castMember = new CastMember();

            castMember.Upc = Upc;
            castMember.DatabaseCastId = -1;

            using (EditCastForm editCastForm = new EditCastForm(castMember))
            {
                editCastForm.ShowDialog();

                if (editCastForm.DialogResult == DialogResult.OK)
                {
                    if (CastEntryAdded != null)
                    {
                        AddedEventArgs eventArgs = new AddedEventArgs(castMember);

                        CastEntryAdded(this, eventArgs);
                    }
                }
            }
        }

        private void AddEpisodeButton_Click(object sender, EventArgs e)
        {
            Episode episode;

            episode = new Episode();
            episode.Upc = Upc;
            using (EditEpisodeForm form = new EditEpisodeForm(episode))
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    if (CastEntryAdded != null)
                    {
                        AddedEventArgs eventArgs;

                        eventArgs = new AddedEventArgs(episode);
                        CastEntryAdded(this, eventArgs);
                    }
                }
            }
        }

        private void OnEditRowButtonClick(Object sender
            , EventArgs e)
        {
            if (CastListView.SelectedIndex != -1)
            {
                OLVListItem row = (OLVListItem)(CastListView.Items[CastListView.SelectedIndex]);

                CastMember castMember = row.RowObject as CastMember;

                if (castMember != null)
                {
                    using (EditCastForm form = new EditCastForm(castMember))
                    {
                        form.ShowDialog();

                        if (form.DialogResult == DialogResult.OK)
                        {
                            CastListView.RebuildAll(true);
                        }
                    }
                }
                else
                {
                    Episode episode = row.RowObject as Episode;

                    if (episode != null)
                    {
                        using (EditEpisodeForm form = new EditEpisodeForm(episode))
                        {
                            form.ShowDialog();

                            if (form.DialogResult == DialogResult.OK)
                            {
                                CastListView.RebuildAll(true);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row.");
            }
        }
    }
}