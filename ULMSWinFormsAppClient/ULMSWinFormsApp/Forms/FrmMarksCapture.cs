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
    public partial class FrmMarksCapture : Form
    {
        public FrmMarksCapture()
        {
            InitializeComponent();
        }

        private void btnCalculateResults_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate empty fields
                if (string.IsNullOrWhiteSpace(txtMarkStudentId.Text) ||
                    string.IsNullOrWhiteSpace(txtMarkStudentName.Text) ||
                    string.IsNullOrWhiteSpace(txtSubject1.Text) ||
                    string.IsNullOrWhiteSpace(txtSubject2.Text) ||
                    string.IsNullOrWhiteSpace(txtSubject3.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Safe conversion
                double subject1, subject2, subject3;

                if (!double.TryParse(txtSubject1.Text, out subject1) ||
                    !double.TryParse(txtSubject2.Text, out subject2) ||
                    !double.TryParse(txtSubject3.Text, out subject3))
                {
                    MessageBox.Show("Please enter valid numeric values for marks.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate marks range
                if (subject1 < 0 || subject1 > 100 ||
                    subject2 < 0 || subject2 > 100 ||
                    subject3 < 0 || subject3 > 100)
                {
                    MessageBox.Show("Marks must be between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create object
                MarkRecord record = new MarkRecord();

                record.StudentId = txtMarkStudentId.Text;
                record.StudentName = txtMarkStudentName.Text;
                record.Subject1 = subject1;
                record.Subject2 = subject2;
                record.Subject3 = subject3;

                // Correct average calculation
                record.Average = (record.Subject1 + record.Subject2 + record.Subject3) / 3;

                // Result status
                if (record.Average >= 50)
                {
                    record.ResultStatus = "PASS";
                }
                else
                {
                    record.ResultStatus = "FAIL";
                }

                // Output
                txtMarksOutput.Text =
                    "Marks processed successfully!" + Environment.NewLine +
                    "Student ID: " + record.StudentId + Environment.NewLine +
                    "Student Name: " + record.StudentName + Environment.NewLine +
                    "Subject 1: " + record.Subject1 + Environment.NewLine +
                    "Subject 2: " + record.Subject2 + Environment.NewLine +
                    "Subject 3: " + record.Subject3 + Environment.NewLine +
                    "Average: " + record.Average + Environment.NewLine +
                    "Final Result: " + record.ResultStatus;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearMarks_Click(object sender, EventArgs e)
        {
            txtMarkStudentId.Clear();
            txtMarkStudentName.Clear();
            txtSubject1.Clear();
            txtSubject2.Clear();
            txtSubject3.Clear();
            txtMarksOutput.Clear();
            txtMarkStudentId.Focus();
        }

        private void btnBackMarks_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSubject2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}