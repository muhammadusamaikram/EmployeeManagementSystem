using System;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer; // Make sure this is the correct namespace for EmployeeDAL

namespace EmployeeManagementSystem
{
    public partial class MainForm : Form
    {
        EmployeeDAL employeeDAL = new EmployeeDAL(); // Creating an instance of Data Access Layer

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load employees on form load
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get values from textboxes
            string name = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string department = textBox3.Text.Trim();
            decimal salary;

            // Validate Salary Input
            if (!decimal.TryParse(textBox4.Text.Trim(), out salary))
            {
                MessageBox.Show("Please enter a valid salary!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for empty fields
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(department))
            {
                MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add Employee to Database
            bool success = employeeDAL.AddEmployee(name, email, department, salary);
            if (success)
            {
                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees(); // Refresh the DataGridView
            }
            else
            {
                MessageBox.Show("Error adding employee.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Clear textboxes after adding
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = employeeDAL.GetAllEmployees(); // Get employees from the database
            dataGridView1.DataSource = dt;  // Load employees into the DataGridView
        }

        private void LoadEmployees()
        {
            DataTable dt = employeeDAL.GetAllEmployees(); // Fetch employees from database
            dataGridView1.DataSource = dt; // Bind to DataGridView
        }
    }
}
