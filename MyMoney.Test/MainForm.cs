using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMoney.Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString);

            System.Data.SqlClient.SqlCommand com = new System.Data.SqlClient.SqlCommand("select * from User_Base where User_Id=@userId", conn);

            SqlParameterCollection sqlParas = com.Parameters;
            sqlParas.Add(new SqlParameter("@userId", "2"));

            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(com);

            DataSet ds = new DataSet();

            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString);

            System.Data.SqlClient.SqlCommand com = new System.Data.SqlClient.SqlCommand("insert User_Base (User_Id,User_Name,Password)values('1','qm','123')", conn);

            conn.Open();

            Int32 count=com.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show(count.ToString());
        }
    }
}
