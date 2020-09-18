using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;

namespace InsertingStudentS
{
    public partial class Insert : Form
    {
        public Insert()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.TextLength <= 2)
            {
                MessageBox.Show("Invalid Name");
                return;
            }
            // [snip] - As C# is purely object-oriented the following lines must be put into a class:
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            // create a new database connection:
            sqlite_conn = new SQLiteConnection(ConnectSQLite.GetConnect());
            try
            {   
                // open the connection:
                sqlite_conn.Open();
                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                string text;
                text = "INSERT INTO Student(name) VALUES('";
                text += txtName.Text + "');";

                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = text;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
                this.Text = ex.Message;
            }
            finally
            {
                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
