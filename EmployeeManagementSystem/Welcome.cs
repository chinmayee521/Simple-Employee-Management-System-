using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRecord ar = new AddRecord();
            ar.Show();
            this.Hide();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ShowEmployees se = new ShowEmployees();
           se.Show();
           this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEmployees se = new SearchEmployees();
            se.Show();
            this.Hide();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageEmployees se = new ManageEmployees();
            se.Show();
            this.Hide();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
