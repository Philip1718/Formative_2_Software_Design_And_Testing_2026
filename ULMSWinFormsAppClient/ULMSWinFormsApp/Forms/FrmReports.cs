using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmReports : Form
    {
        public FrmReports()
        {
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                string reportType = cmbReportType.Text;
                string studentId = txtReportStudentId.Text;

                // Validate report type
                if (string.IsNullOrWhiteSpace(reportType))
                {
                    MessageBox.Show("Please select a report type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Optional: validate student ID (if required)
                if (string.IsNullOrWhiteSpace(studentId))
                {
                    MessageBox.Show("Please enter a Student ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Simulate processing WITHOUT freezing UI completely
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents(); // allow UI refresh
                Thread.Sleep(1000); // reduced delay

                StringBuilder report = new StringBuilder();

                report.AppendLine("===== ULMS REPORT =====");
                report.AppendLine("Report Type: " + reportType);
                report.AppendLine("Student ID Filter: " + studentId);
                report.AppendLine("Generated On: " + DateTime.Now);
                report.AppendLine();

                if (reportType == "Student Summary Report")
                {
                    report.AppendLine("Student Name: John Doe");
                    report.AppendLine("Programme: Software Engineering");
                    report.AppendLine("Status: Active");
                }
                else if (reportType == "Marks Report")
                {
                    report.AppendLine("Subject 1: 78");
                    report.AppendLine("Subject 2: 65");
                    report.AppendLine("Subject 3: 80");

                    // Fixed average
                    double average = (78 + 65 + 80) / 3.0;
                    report.AppendLine("Average: " + average);
                }
                else if (reportType == "Enrollment Report")
                {
                    report.AppendLine("Course 1: Programming 1");
                    report.AppendLine("Course 2: Database Systems");
                    report.AppendLine("Semester: Semester 1");
                }
                else
                {
                    MessageBox.Show("Invalid report type selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtReportOutput.Text = report.ToString();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("An error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearReport_Click(object sender, EventArgs e)
        {
            cmbReportType.SelectedIndex = -1;
            txtReportStudentId.Clear();
            txtReportOutput.Clear();
            txtReportStudentId.Focus();
        }

        private void btnBackReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtReportStudentId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}