using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    internal partial class SearchForCastForm : Form
    {
        private CastMember m_CastMember;

        public SearchForCastForm(CastMember castMember)
        {
            m_CastMember = castMember;

            InitializeComponent();

            NameTextBox.Text = castMember.GetFullName();
        }

        private void OnSearchButtonClick(Object sender
            , EventArgs e)
        {
            if (String.IsNullOrEmpty(NameTextBox.Text) == false)
            {
                List<SearchEntry> rootElements = new List<SearchEntry>(3);

                Program.OnlineConnection.Open();

                using (OleDbCommand command = Program.OnlineConnection.CreateCommand())
                {
                    SearchByName(rootElements, command);

                    SearchByCreditedAs(rootElements, command);

                    SearchByPendingContributions(rootElements, command);
                }

                SearchResultsView.Roots = rootElements;
                SearchResultsView.RebuildAll(false);

                Program.OnlineConnection.Close();
            }
        }

        private void SearchByPendingContributions(List<SearchEntry> rootElements
            , OleDbCommand command)
        {
            StringBuilder commandText = new StringBuilder("SELECT DISTINCT FirstName, MiddleName, LastName, OriginalTitle, Title, ProductionYear, CastId FROM vPendingContributions WHERE ");

            AppendSearchCondition(commandText, "FullName");

            AddSortOrder(commandText);

            SearchHeader header = new SearchHeader();

            header.FirstName = "Search by Pending Contributions";

            rootElements.Add(header);

            GetSearchResults(command, commandText, header, true);
        }

        private void SearchByCreditedAs(List<SearchEntry> rootElements
            , OleDbCommand command)
        {
            StringBuilder commandText = new StringBuilder("SELECT DISTINCT FirstName, MiddleName, LastName, OriginalTitle, Title, ProductionYear, CastId, CreditedAs FROM vCastNames WHERE ");

            AppendSearchCondition(commandText, "CreditedAs");

            AddSortOrder(commandText);

            SearchHeader header = new SearchHeader();

            header.FirstName = "Search by Credited As";

            rootElements.Add(header);

            GetSearchResults(command, commandText, header, false);
        }

        private void AppendSearchCondition(StringBuilder commandText
            , String fieldName)
        {
            String[] split = NameTextBox.Text.Split(' ');

            for (Int32 i = 0; i < split.Length - 1; i++)
            {
                AppendSearchCondition(split[i], commandText, fieldName);

                commandText.Append(" AND ");
            }

            AppendSearchCondition(split[split.Length - 1], commandText, fieldName);
        }

        private void SearchByName(List<SearchEntry> rootElements
            , OleDbCommand command)
        {
            StringBuilder commandText = new StringBuilder("SELECT DISTINCT FirstName, MiddleName, LastName, OriginalTitle, Title, ProductionYear, CastId, CreditedAs FROM vCastNames WHERE ");

            AppendSearchCondition(commandText, "FullName");

            commandText.Append(" AND ");
            commandText.Append("(CastId <> NULL)");

            AddSortOrder(commandText);

            SearchHeader header = new SearchHeader();

            header.FirstName = "Search by Name";

            rootElements.Add(header);

            GetSearchResults(command, commandText, header, false);
        }

        private static void AddSortOrder(StringBuilder commandText)
        {
            commandText.Insert(0, "SELECT * FROM (");
            commandText.Append(") itab ORDER BY LastName, FirstName, MiddleName");
        }

        private static void GetSearchResults(OleDbCommand command
            , StringBuilder commandText
            , SearchHeader header
            , Boolean isPending)
        {
            command.CommandText = commandText.ToString();

            using (OleDbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    Dictionary<Int32, List<SearchResult>> results = new Dictionary<Int32, List<SearchResult>>();

                    while (reader.Read())
                    {
                        Int32 castId = reader.GetInt32(6);

                        List<SearchResult> resultList;
                        if (results.TryGetValue(castId, out resultList) == false)
                        {
                            resultList = new List<SearchResult>();

                            results.Add(castId, resultList);
                        }

                        SearchResult result = new SearchResult();

                        if (isPending)
                        {
                            result.CastId = CastListControl.NewId + castId.ToString();
                        }
                        else
                        {
                            result.CastId = castId.ToString();
                        }

                        if (reader.IsDBNull(0) == false)
                        {
                            String temp = reader.GetString(0);

                            MainForm.ClearNull(ref temp);

                            result.FirstName = temp;
                        }

                        if (reader.IsDBNull(1) == false)
                        {
                            String temp = reader.GetString(1);

                            MainForm.ClearNull(ref temp);

                            result.MiddleName = temp;
                        }

                        if (reader.IsDBNull(2) == false)
                        {
                            String temp = reader.GetString(2);

                            MainForm.ClearNull(ref temp);

                            result.LastName = temp;
                        }

                        if (reader.IsDBNull(3) == false)
                        {
                            String temp = reader.GetString(3);

                            MainForm.ClearNull(ref temp);

                            result.Title = temp;
                        }

                        if (String.IsNullOrEmpty(result.Title))
                        {
                            if (reader.IsDBNull(4) == false)
                            {
                                String temp = reader.GetString(4);

                                MainForm.ClearNull(ref temp);

                                result.Title = temp;
                            }
                        }

                        if (reader.IsDBNull(5) == false)
                        {
                            result.ProductionYear = reader.GetInt32(5).ToString();
                        }

                        if (isPending == false)
                        {
                            if (reader.IsDBNull(7) == false)
                            {
                                String temp = reader.GetString(7);

                                MainForm.ClearNull(ref temp);

                                result.CreditedAs = temp;
                            }
                        }

                        resultList.Add(result);
                    }

                    header.ResultList = new List<SearchResult>(results.Count);

                    foreach (KeyValuePair<Int32, List<SearchResult>> kvp in results)
                    {
                        SearchResult subHeader = new SearchResult();

                        subHeader.FirstName = kvp.Value[0].FirstName;
                        subHeader.MiddleName = kvp.Value[0].MiddleName;
                        subHeader.LastName = kvp.Value[0].LastName;
                        subHeader.CastId = kvp.Value[0].CastId;
                        subHeader.Title = "(CastId: " + kvp.Key.ToString() + ")";
                        subHeader.ResultList = new List<SearchResult>(kvp.Value);

                        header.ResultList.Add(subHeader);
                    }
                }
            }
        }

        private static void AppendSearchCondition(String condition
            , StringBuilder commandText
            , String fieldName)
        {
            commandText.Append("(");
            commandText.Append(fieldName);
            commandText.Append(" LIKE '%");
            commandText.Append(MainForm.ReplaceApostrophes(condition));
            commandText.Append("%')");
        }

        private void OnSearchForCastFormLoad(Object sender
            , EventArgs e)
        {
            SearchResultsView.CanExpandGetter = (obj =>
                    {
                        SearchEntry searchEntry = (SearchEntry)obj;

                        return (searchEntry.ResultList?.Count > 0);
                    }
                );

            SearchResultsView.ChildrenGetter = (obj =>
                    {
                        SearchEntry searchEntry = (SearchEntry)obj;

                        return (searchEntry.ResultList);
                    }
                );
        }

        private void OnSelectCastMemberButtonClick(Object sender
            , EventArgs e)
        {
            if (SearchResultsView.SelectedIndex != -1)
            {
                OLVListItem row = (OLVListItem)(SearchResultsView.Items[SearchResultsView.SelectedIndex]);

                SearchResult result = row.RowObject as SearchResult;

                if (result != null)
                {
                    m_CastMember.CastId = result.CastId;
                    m_CastMember.FirstName = result.FirstName;
                    m_CastMember.MiddleName = result.MiddleName;
                    m_CastMember.LastName = result.LastName;

                    DialogResult = DialogResult.OK;

                    Close();
                }
                else
                {
                    MessageBox.Show("Please select a cast row.");
                }
            }
            else
            {
                MessageBox.Show("Please select a row.");
            }
        }

        private void OnCreateNewIdButtonClick(Object sender
            , EventArgs e)
        {
            Program.OnlineConnection.Open();

            using (OleDbCommand command = Program.OnlineConnection.CreateCommand())
            {
                command.CommandText = "SELECT NewId FROM vNewId";

                Int32 newId;
                using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult))
                {
                    reader.Read();

                    newId = reader.GetInt32(0);

                    m_CastMember.CastId = CastListControl.NewId + newId.ToString();
                }

                StringBuilder commandText = new StringBuilder("INSERT INTO tPendingContributions VALUES (");

                commandText.Append(newId);
                commandText.Append(",");
                commandText.Append(MainForm.PrepareTextForDb(MainForm.Settings.UserName));
                commandText.Append(",");
                commandText.Append(MainForm.PrepareTextForDb(m_CastMember.Upc));
                commandText.Append(",");
                commandText.Append(MainForm.PrepareOptionalTextForDb(m_CastMember.LastName));
                commandText.Append(",");
                commandText.Append(MainForm.PrepareOptionalTextForDb(m_CastMember.MiddleName));
                commandText.Append(",");
                commandText.Append(MainForm.PrepareTextForDb(m_CastMember.FirstName));
                commandText.Append(")");

                command.CommandText = commandText.ToString();
                command.ExecuteNonQuery();

                DialogResult = DialogResult.OK;

                Close();
            }

            Program.OnlineConnection.Close();
        }
    }
}