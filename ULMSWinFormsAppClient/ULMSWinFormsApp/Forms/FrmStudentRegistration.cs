using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmStudentRegistration : Form
    {
        public FrmStudentRegistration()
        {
            InitializeComponent();
        }

        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            try
            {
                string studentId = txtStudentId.Text.Trim();
                string fullName = txtFullName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string programme = cmbProgramme.Text.Trim();

                // Validate empty fields
                if (string.IsNullOrEmpty(studentId) ||
                    string.IsNullOrEmpty(fullName) ||
                    string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(txtAge.Text) ||
                    string.IsNullOrEmpty(programme))
                {
                    MessageBox.Show("Please fill in all fields.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate age safely
                int age;
                if (!int.TryParse(txtAge.Text, out age))
                {
                    MessageBox.Show("Please enter a valid numeric age.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate age range
                if (age < 16 || age > 100)
                {
                    MessageBox.Show("Age must be between 16 and 100.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Basic email validation
                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create student object
                Student student = new Student
                {
                    StudentId = studentId,
                    FullName = fullName,
                    Email = email,
                    Age = age,
                    Programme = programme
                };

                // Output success
                txtStudentOutput.Text =
                    "Student saved successfully!" + Environment.NewLine +
                    "Student ID: " + student.StudentId + Environment.NewLine +
                    "Full Name: " + student.FullName + Environment.NewLine +
                    "Email: " + student.Email + Environment.NewLine +
                    "Age: " + student.Age + Environment.NewLine +
                    "Programme: " + student.Programme;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format detected in input.", "Format Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("A required field is missing.", "System Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "System Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtStudentId.Focus();
            }
        }

        private void btnClearStudent_Click(object sender, EventArgs e)
        {
            try
            {
                txtStudentId.Clear();
                txtFullName.Clear();
                txtEmail.Clear();
                txtAge.Clear();
                cmbProgramme.SelectedIndex = -1;
                txtStudentOutput.Clear();
                txtStudentId.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while clearing fields: " + ex.Message, "System Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Add Back button to return to dashboard
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while closing form: " + ex.Message, "System Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}