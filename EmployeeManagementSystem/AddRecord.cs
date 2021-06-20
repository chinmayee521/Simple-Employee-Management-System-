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
    public partial class AddRecord : Form
    {
        public AddRecord()
        {
            InitializeComponent();
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            //Define Connection string 
            string ConnectionString = "Data Source=LAPTOP-3GT6L3CM\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True";

            //Define connection object using connection string
            SqlConnection sc = new SqlConnection(ConnectionString);

            //Define DataAdapter to get data from Emp table
            SqlDataAdapter da = new SqlDataAdapter("Select * from Emp;",sc);

            //CommandBuilder object to generate commands for DataAdapter object
            SqlCommandBuilder scb = new SqlCommandBuilder(da);

            //Define DataSet object
            DataSet ds = new DataSet();

            //Fill the DataSet(just a convention-not mandatory to fill the name of table and data member of dataset)
            da.Fill(ds, "Emp");

            //Add constraint on Empno column of Emp table
            ds.Tables[0].Constraints.Add("Empno_PK", ds.Tables[0].Columns[0], true);

            //adding record
            //Assign new row of DataTable, provide values for columns
            DataRow row;
            row = ds.Tables[0].NewRow();
            row["Empno"] = txtEmpNo.Text;
            row["Ename"] = txtEName.Text;
            row["Salary"] = txtSalary.Text;
            row["Hiredate"] = dtpHireDate.Value;
            //add DataRow variable to Rows collection
            ds.Tables[0].Rows.Add(row);

            //update the DataAdapter
            da.Update(ds.Tables[0]);

            MessageBox.Show("Employee Record Added!");
            foreach(var c in Controls)
            {
                var textbox = c as TextBox;
                if (textbox != null)
                    textbox.Clear();
            }




        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Welcome w = new Welcome();
            w.Show();
            this.Hide();
        }

        private void AddRecord_Load(object sender, EventArgs e)
        {

        }
    }
}
