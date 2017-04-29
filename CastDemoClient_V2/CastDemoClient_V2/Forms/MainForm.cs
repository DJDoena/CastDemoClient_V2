using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    public partial class MainForm : Form
    {
        private const String NULL = "NULL";

        internal static Settings Settings;

        private List<CastEntry> m_RootElements;

        public MainForm()
        {
            InitializeComponent();

            CastListControl.ShowAddEpisodeButton = true;
        }

        private void OnMainFormLoad(Object sender
            , EventArgs e)
        {
            GetSettings();

            GetData();

            CastListControl.Upc = UpcTextBox.Text;
            CastListControl.CastListView.Roots = m_RootElements;
            CastListControl.CastListView.RebuildAll(false);
            CastListControl.CastEntryAdded += OnCastListControlCastEntryAdded;
        }

        private void GetData()
        {
            m_RootElements = new List<CastEntry>();

            Program.LocalConnection.Open();

            using (OleDbCommand command = Program.LocalConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM vCast";

                using (OleDbDataReader castReader = command.ExecuteReader())
                {
                    if (castReader.HasRows)
                    {
                        Int32 previousEpisodeId = -1;

                        Episode episode = null;

                        while (castReader.Read())
                        {
                            UpcTextBox.Text = castReader.GetString(0);

                            TitleTextBox.Text = castReader.GetString(1);

                            if (castReader.IsDBNull(11))
                            {
                                //cast member is not assigned to an episode
                                episode = null;
                            }
                            else
                            {
                                Int32 newEpisodeId = castReader.GetInt32(11);

                                if (previousEpisodeId != newEpisodeId)
                                {
                                    //next episode
                                    episode = null;
                                }

                                if (episode == null)
                                {
                                    previousEpisodeId = newEpisodeId;

                                    episode = new Episode();

                                    episode.Upc = UpcTextBox.Text;
                                    episode.EpisodeNumber = castReader.GetString(2);
                                    episode.EpisodeName = castReader.GetString(3);

                                    m_RootElements.Add(episode);
                                }
                            }

                            CastMember castMember = new CastMember();

                            castMember.Upc = UpcTextBox.Text;
                            castMember.FirstName = castReader.GetString(4);

                            if (castReader.IsDBNull(5) == false)
                            {
                                String temp = castReader.GetString(5);

                                ClearNull(ref temp);

                                castMember.MiddleName = temp;
                            }

                            if (castReader.IsDBNull(6) == false)
                            {
                                String temp = castReader.GetString(6);

                                ClearNull(ref temp);

                                castMember.LastName = temp;
                            }

                            if (castReader.IsDBNull(7) == false)
                            {
                                String temp = castReader.GetString(7);

                                ClearNull(ref temp);

                                castMember.Role = temp;
                            }

                            castMember.Voice = castReader.GetBoolean(8);

                            if (castReader.IsDBNull(9) == false)
                            {
                                String temp = castReader.GetString(9);

                                ClearNull(ref temp);

                                castMember.CreditedAs = temp;
                            }

                            if (castReader.IsDBNull(10) == false)
                            {
                                castMember.CastId = castReader.GetString(10);
                            }

                            castMember.DatabaseCastId = castReader.GetInt32(12);

                            if (episode != null)
                            {
                                if (episode.CastList == null)
                                {
                                    episode.CastList = new List<CastMember>();
                                }

                                episode.CastList.Add(castMember);
                            }
                            else
                            {
                                m_RootElements.Add(castMember);
                            }
                        }
                    }
                }
            }

            Program.LocalConnection.Close();
        }

        internal static void ClearNull(ref String field)
        {
            if (field == "Null")
            {
                field = String.Empty;
            }
        }

        void OnCastListControlCastEntryAdded(Object sender
            , AddedEventArgs e)
        {
            m_RootElements.Add(e.NewCastEntry);

            CastListControl.CastListView.Roots = m_RootElements;
            CastListControl.CastListView.RebuildAll(true);
        }

        private void GetSettings()
        {
            Settings = null;

            if (File.Exists("settings.xml"))
            {
                Settings = Settings.Deserialize("settings.xml");
            }

            if (Settings == null)
            {
                Settings = new Settings();

                using (LoginForm loginForm = new LoginForm(Settings))
                {
                    loginForm.ShowDialog();

                    if (loginForm.DialogResult == DialogResult.Cancel)
                    {
                        Close();
                    }
                }

                Settings.Serialize("settings.xml");
            }
        }

        private void OnMainFormFormClosing(Object sender
            , FormClosingEventArgs e)
        {
            if (m_RootElements == null)
            {
                return;
            }

            Program.LocalConnection.Open();

            using (OleDbCommand command = Program.LocalConnection.CreateCommand())
            {
                command.Transaction = Program.LocalConnection.BeginTransaction();
                command.CommandText = "DELETE FROM tDVDxCast WHERE DVDId = '" + UpcTextBox.Text + "'";
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM tDivider WHERE DVDId = '" + UpcTextBox.Text + "'";
                command.ExecuteNonQuery();

                Int32 orderNumber = 0;

                foreach (CastEntry entry in m_RootElements)
                {
                    Episode episode = entry as Episode;

                    if (episode != null)
                    {
                        AddDividerToDatabase(episode, command, ref orderNumber);
                    }
                    else
                    {
                        AddCastMemberToDatabase(command, -1, ref orderNumber, (CastMember)entry);
                    }
                }

                command.Transaction.Commit();
            }

            Program.LocalConnection.Close();
        }

        private void AddDividerToDatabase(Episode episode
            , OleDbCommand commmand
            , ref Int32 orderNumber)
        {
            StringBuilder commandText = new StringBuilder("INSERT INTO tDivider (DVDId, [Number], Title) VALUES (");

            commandText.Append(PrepareTextForDb(UpcTextBox.Text));
            commandText.Append(", ");
            commandText.Append(PrepareTextForDb(episode.EpisodeNumber));
            commandText.Append(", ");
            commandText.Append(PrepareTextForDb(episode.EpisodeName));
            commandText.Append(")");

            commmand.CommandText = commandText.ToString();
            commmand.ExecuteNonQuery();

            commandText = new StringBuilder("SELECT @@identity FROM tDivider");

            commmand.CommandText = commandText.ToString();

            Int32 dividerId;
            using (OleDbDataReader episodeReader = commmand.ExecuteReader(CommandBehavior.SingleResult))
            {
                episodeReader.Read();

                dividerId = episodeReader.GetInt32(0);
            }

            foreach (CastMember castMember in episode.CastList)
            {
                AddCastMemberToDatabase(commmand, dividerId, ref orderNumber, castMember);
            }
        }

        private void AddCastMemberToDatabase(OleDbCommand command
            , Int32 dividerId
            , ref Int32 orderNumber
            , CastMember castMember)
        {
            StringBuilder commandText;
            if (castMember.DatabaseCastId == -1)
            {
                commandText = new StringBuilder("INSERT INTO tCast (LastName, MiddleName, FirstName) VALUES (");

                commandText.Append(PrepareOptionalTextForDb(castMember.LastName));
                commandText.Append(", ");
                commandText.Append(PrepareOptionalTextForDb(castMember.MiddleName));
                commandText.Append(", ");
                commandText.Append(PrepareTextForDb(castMember.FirstName));
                commandText.Append(")");

                command.CommandText = commandText.ToString();
                command.ExecuteNonQuery();

                commandText = new StringBuilder("SELECT @@identity FROM tDivider");

                command.CommandText = commandText.ToString();

                using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult))
                {
                    reader.Read();

                    castMember.DatabaseCastId = reader.GetInt32(0);
                }
            }

            commandText = new StringBuilder("UPDATE tCast SET CastId = ");

            commandText.Append(PrepareOptionalTextForDb(castMember.CastId));
            commandText.Append(" WHERE Id = ");
            commandText.Append(castMember.DatabaseCastId);

            command.CommandText = commandText.ToString();
            command.ExecuteNonQuery();

            orderNumber++;

            commandText = new StringBuilder("INSERT INTO tDVDxCast (DVDId, CastId, DividerId, Role, CreditedAs, Voice, OrderNumber) VALUES (");

            commandText.Append(PrepareTextForDb(UpcTextBox.Text));
            commandText.Append(", ");
            commandText.Append(castMember.DatabaseCastId);
            commandText.Append(", ");

            if (dividerId == -1)
            {
                commandText.Append(NULL);
            }
            else
            {
                commandText.Append(dividerId);
            }

            commandText.Append(", ");
            commandText.Append(PrepareOptionalTextForDb(castMember.Role));
            commandText.Append(", ");
            commandText.Append(PrepareOptionalTextForDb(castMember.CreditedAs));
            commandText.Append(", ");
            commandText.Append(castMember.Voice.ToString());
            commandText.Append(", ");
            commandText.Append(orderNumber);
            commandText.Append(")");

            command.CommandText = commandText.ToString();
            command.ExecuteNonQuery();
        }

        internal static String PrepareTextForDb(String text)
            => ("'" + ReplaceApostrophes(text) + "'");

        internal static String ReplaceApostrophes(String text)
            => (text.Replace("'", "''"));

        internal static String PrepareOptionalTextForDb(String text)
            => ((String.IsNullOrEmpty(text)) ? NULL : (PrepareTextForDb(text)));

        private static String PrepareCastIdForDb(String text)
            => ((String.IsNullOrEmpty(text)) ? NULL : text);

        private void OnContributeButtonClick(Object sender
            , EventArgs e)
        {
            Program.OnlineConnection.Open();

            using (OleDbCommand command = Program.OnlineConnection.CreateCommand())
            {
                command.Transaction = Program.OnlineConnection.BeginTransaction();

                StringBuilder commandText = new StringBuilder("DELETE FROM tDVDxCast WHERE (DVDId =");

                commandText.Append(PrepareTextForDb(UpcTextBox.Text));
                commandText.Append(")");

                command.CommandText = commandText.ToString();
                command.ExecuteNonQuery();

                foreach (CastEntry castEntry in m_RootElements)
                {
                    Episode episode = castEntry as Episode;

                    if (episode != null)
                    {
                        if (episode.CastList != null)
                        {
                            foreach (CastMember castMember in episode.CastList)
                            {
                                ContributeCastMember(command, castMember);
                            }
                        }
                    }
                    else
                    {
                        ContributeCastMember(command, (CastMember)castEntry);
                    }
                }

                command.Transaction.Commit();
            }

            Program.OnlineConnection.Close();

            CastListControl.CastListView.Roots = m_RootElements;
            CastListControl.CastListView.RebuildAll(true);
        }

        private void ContributeCastMember(OleDbCommand command
            , CastMember castMember)
        {
            if (String.IsNullOrEmpty(castMember.CastId))
            {
                StringBuilder commandText = new StringBuilder("INSERT INTO tDVDxCast (DVDId, LastName, MiddleName, FirstName, Role, Voice) VALUES (");

                commandText.Append(PrepareTextForDb(UpcTextBox.Text));
                commandText.Append(", ");
                commandText.Append(PrepareOptionalTextForDb(castMember.LastName));
                commandText.Append(", ");
                commandText.Append(PrepareOptionalTextForDb(castMember.MiddleName));
                commandText.Append(", ");
                commandText.Append(PrepareTextForDb(castMember.FirstName));
                commandText.Append(", ");
                commandText.Append(PrepareOptionalTextForDb(castMember.Role));
                commandText.Append(", ");
                commandText.Append(castMember.Voice);
                commandText.Append(")");

                command.CommandText = commandText.ToString();
                command.ExecuteNonQuery();
            }
            else
            {
                StringBuilder commandText;
                if (castMember.CastId.StartsWith(CastListControl.NewId))
                {
                    String newId = castMember.CastId.Substring(CastListControl.NewId.Length);

                    commandText = new StringBuilder("INSERT INTO tCast SELECT Id, LastName, MiddleName, FirstName FROM tPendingContributions WHERE Id = ");

                    commandText.Append(newId);

                    command.CommandText = commandText.ToString();
                    command.ExecuteNonQuery();

                    commandText = new StringBuilder("DELETE FROM tPendingContributions WHERE Id = ");
                    commandText.Append(newId);

                    command.CommandText = commandText.ToString();
                    command.ExecuteNonQuery();

                    castMember.CastId = newId.ToString();
                }

                commandText = new StringBuilder("INSERT INTO tDVDxCast (DVDId, CastId, Role, CreditedAs, Voice) VALUES (");

                commandText.Append(PrepareTextForDb(UpcTextBox.Text));
                commandText.Append(", ");
                commandText.Append(castMember.CastId);
                commandText.Append(", ");
                commandText.Append(PrepareOptionalTextForDb(castMember.Role));
                commandText.Append(", ");
                commandText.Append(PrepareOptionalTextForDb(castMember.CreditedAs));
                commandText.Append(", ");
                commandText.Append(castMember.Voice);
                commandText.Append(")");

                command.CommandText = commandText.ToString();
                command.ExecuteNonQuery();
            }
        }
    }
}