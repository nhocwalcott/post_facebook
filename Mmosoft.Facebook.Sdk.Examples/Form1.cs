using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace Mmosoft.Facebook.Sdk.Examples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fb = new FacebookClient(txtUsername.Text, txtPassword.Text);           
            fb.PostToWall(txtContent.Text);
            MessageBox.Show("Đăng thành công!", "Thông Báo");
        }
        private void btnPostGroup_Click(object sender, EventArgs e)
        {          
            var fb = new FacebookClient(txtUsername.Text, txtPassword.Text);
            fb.PostToGroup(txtContent.Text, txtIDgroup.Text);
            MessageBox.Show("Đăng tin lên Group Facebook thành công!", "Thông Báo");
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_facebook;";
            string sql = "Select link from chitiet where date =" + txtContent.Text ;
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(sql, connection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                connection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    string[] rows = new string[100];
                    int i = 0;
                    while (reader.Read())
                    {
                        string row = reader.GetString(0);
                        rows[i] = row;
                        i++;
                        var fb = new FacebookClient(txtUsername.Text, txtPassword.Text);
                        fb.PostToWall(row);
                    }
                    MessageBox.Show(sql);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
