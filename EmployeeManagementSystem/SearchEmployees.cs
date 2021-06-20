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

    public partial class SearchEmployees : Form
    {
        SqlConnection sc;
        SqlDataAdapter da;
        DataSet ds;
        public SearchEmployees()
        {
            InitializeComponent();
        }

        private void SearchEmployees_Load(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=LAPTOP-3GT6L3CM\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True";
            //define objects
            sc = new SqlConnection(ConnectionString);
            da = new SqlDataAdapter("select * from Emp", sc);
            ds = new DataSet();
            da.Fill(ds, "Emp");

            //add pk constraint
            ds.Tables["Emp"].Constraints.Add("Empno_PK", ds.Tables["Emp"].Columns
                ["Empno"], true);

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int empno = int.Parse(txtSearchEid.Text);
            if(ds.Tables["Emp"].Rows.Contains(empno) == true)
            {
                DataRow row;
                row = ds.Tables["Emp"].Rows.Find(empno);
                txtSearchEname.Text = row["Ename"].ToString();
                txtSearchSalary.Text = row["Salary"].ToString();
                txtSearchHireDate.Text = row["Hiredate"].ToString();
            }
            else
            {
                MessageBox.Show("Record doesn't exist!","Error");
                txtSearchEname.Clear();
                txtSearchSalary.Clear();
                txtSearchHireDate.Clear();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            Welcome w = new Welcome();
            w.Show();
            this.Hide();
        }
    }
}
