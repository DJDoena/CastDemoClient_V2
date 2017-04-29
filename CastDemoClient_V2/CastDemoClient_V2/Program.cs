using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    public static class Program
    {
        internal static OleDbConnection LocalConnection;

        internal static OleDbConnection OnlineConnection;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LocalConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"Data\LocalDatabase.mdb" + ";Persist Security Info=True");

            OnlineConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"Data\OnlineDatabase.mdb" + ";Persist Security Info=True");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            LocalConnection.Dispose();

            OnlineConnection.Dispose();
        }
    }
}