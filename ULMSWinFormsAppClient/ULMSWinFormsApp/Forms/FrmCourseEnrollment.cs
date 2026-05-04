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
    public partial class FrmCourseEnrollment : Form
    {
        // Simple in-memory list to prevent duplicate enrollments
        private static List<string> enrollmentRecords = new List<string>();

        public FrmCourseEnrollment()
        {
            InitializeComponent();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            try
            {
                string studentId = txtEnrollStudentId.Text.Trim();
                string studentName = txtEnrollStudentName.Text.Trim();
                string course = cmbCourse.Text.Trim();
                string semester = cmbSemester.Text.Trim();

                // Validate empty fields
                if (string.IsNullOrEmpty(studentId) ||
                    string.IsNullOrEmpty(studentName) ||
                    string.IsNullOrEmpty(course) ||
                    string.IsNullOrEmpty(semester))
                {
                    MessageBox.Show("Please fill in all fields.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Extra validation (basic business rules)
                if (studentId.Length < 3)
                {
                    MessageBox.Show("Student ID must be at least 3 characters long.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create enrollment object
                Enrollment enrollment = new Enrollment
                {
                    StudentId = studentId,
                    StudentName = studentName,
                    CourseName = course,
                    Semester = semester
                };

                // Prevent duplicate enrollment
                string uniqueKey = enrollment.StudentId + "-" + enrollment.CourseName;

                if (enrollmentRecords.Contains(uniqueKey))
                {
                    MessageBox.Show("This student is already enrolled in this course.", "Duplicate Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save record (in-memory)
                enrollmentRecords.Add(uniqueKey);

                // Output success
                txtEnrollmentOutput.Text =
                    "Enrollment completed successfully!" + Environment.NewLine +
                    "Student ID: " + enrollment.StudentId + Environment.NewLine +
                    "Student Name: " + enrollment.StudentName + Environment.NewLine +
                    "Course: " + enrollment.CourseName + Environment.NewLine +
                    "Semester: " + enrollment.Semester;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format detected.", "Format Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("A required field is missing or not initialized.", "System Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "System Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Always ensure UI remains responsive / safe state
                txtEnrollStudentId.Focus();
            }
        }

        private void btnClearEnrollment_Click(object sender, EventArgs e)
        {
            try
            {
                txtEnrollStudentId.Clear();
                txtEnrollStudentName.Clear();
                cmbCourse.SelectedIndex = -1;
                cmbSemester.SelectedIndex = -1;
                txtEnrollmentOutput.Clear();
                txtEnrollStudentId.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while clearing fields: " + ex.Message, "System Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackEnrollment_Click(object sender, EventArgs e)
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

        private void txtEnrollStudentId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}