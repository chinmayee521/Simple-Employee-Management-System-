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
    public partial class ManageEmployees : Form
    {
        SqlConnection sc;
        SqlDataAdapter da;
        SqlCommandBuilder scb;
        DataSet ds;

        public ManageEmployees()
        {
            InitializeComponent();
        }

        private void ManageEmployees_Load(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=LAPTOP-3GT6L3CM\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True";

            //define objects
            sc = new SqlConnection(ConnectionString);
            da = new SqlDataAdapter("select * from Emp", sc);
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Emp");

            //add pk constraint
            ds.Tables["Emp"].Constraints.Add("Empno_PK", ds.Tables["Emp"].Columns
                ["Empno"], true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int empno = int.Parse(txtUpdateEid.Text);
            if (ds.Tables["Emp"].Rows.Contains(empno) == true)
            {
                DataRow row;
                row = ds.Tables["Emp"].Rows.Find(empno);
                txtUpdateEname.Text = row["Ename"].ToString();
                txtUpdateSalary.Text = row["Salary"].ToString();
                txtUpdateHireDate.Text = row["Hiredate"].ToString();
            }
            else
            {
                MessageBox.Show("Record doesn't exist!", "Error");
                txtUpdateEname.Clear();
                txtUpdateSalary.Clear();
                txtUpdateHireDate.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int eno = int.Parse(txtUpdateEid.Text);
            DataRow row;
            row = ds.Tables["Emp"].Rows.Find(eno);
            row.BeginEdit();
            row["Ename"] = txtUpdateEname.Text;
            row["Salary"] = txtUpdateSalary.Text;
            row.EndEdit();
            da.Update(ds.Tables["Emp"]);
            MessageBox.Show("Employee Record updated!","Update");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to delete the record","Delete",MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)==DialogResult.Yes)
            {
                int eno = int.Parse(txtUpdateEid.Text);
                ds.Tables["Emp"].Rows.Find(eno).Delete();
                da.Update(ds.Tables["Emp"]);
                MessageBox.Show("Employee Record Deleted!", "Delete");
                txtUpdateEname.Clear();
                txtUpdateSalary.Clear();
                txtUpdateHireDate.Clear();
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
