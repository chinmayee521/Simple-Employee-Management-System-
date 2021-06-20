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

namespace EmployeeManagementSystem
{
    public partial class ShowEmployees : Form
    {
        public ShowEmployees()
        {
            InitializeComponent();
        }

        private void ShowEmployees_Load(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=LAPTOP-3GT6L3CM\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True";
            SqlConnection sc = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("Select * from Emp;", sc);
            DataSet ds = new DataSet();
            da.Fill(ds, "Emp");
            dataGridView1.DataSource = ds.Tables[0];
        }


        private void btnBack_Click(object sender, EventArgs e)
        {

            Welcome w = new Welcome();
            w.Show();
            this.Hide();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            Welcome w = new Welcome();
            w.Show();
            this.Hide();
        }
    }
}
