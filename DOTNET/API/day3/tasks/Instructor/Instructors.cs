using System.Text.Json;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using DepartmentInstructor.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net;
using System.Net.Http.Headers;

namespace Instructor
{
    public partial class Instructors : Form
    {
        public Instructors(string _jwt)
        {
            InitializeComponent();
            jwt = _jwt;

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            GridInstructors.UserDeletingRow += GridInstructors_UserDeletingRow;
        }

        private void GridInstructors_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row != null)
            {
                var ins = (DepartmentInstructor.Models.Instructor)e.Row.DataBoundItem;

                if (ins != null)
                {
                    var responce = HttpClient.DeleteAsync($"https://localhost:7173/api/Instructors/{ins.Id}").Result;

                    if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        MessageBox.Show("Data deleted Successfully");
                    }
                }
            }
        }

        public string jwt;
        private HttpClient HttpClient = new();

        private void Instructors_Load(object sender, EventArgs e)
        {
            ReadAll();
        }

        private void ReadAll()
        {
            var responce = HttpClient.GetAsync("https://localhost:7173/api/Instructors").Result;
            string x = responce.Content.ReadAsStringAsync().Result;
            var content = JsonConvert.DeserializeObject<List<DepartmentInstructor.Models.Instructor>>(x);


            GridInstructors.DataSource = new BindingSource() { DataSource = content };
            GridInstructors.Columns[0].ReadOnly = true;

            GridInstructors.AllowUserToAddRows = true;
            GridInstructors.AllowUserToDeleteRows = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GridInstructors.EndEdit();

            if (GridInstructors.SelectedCells.Count > 0)
            {
                var ins = (DepartmentInstructor.Models.Instructor)(GridInstructors.Rows[GridInstructors.SelectedCells[0].RowIndex].DataBoundItem);

                if (ins != null)
                {
                    var responce = HttpClient.PutAsync($"https://localhost:7173/api/Instructors/{ins.Id}", new StringContent(JsonSerializer.Serialize(ins), Encoding.UTF8, "application/json")).Result;

                    if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        MessageBox.Show("Data Saved Successfully");
                    }
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridInstructors.EndEdit();

            if (GridInstructors.SelectedCells.Count > 0)
            {
                var ins = (DepartmentInstructor.Models.Instructor)(GridInstructors.Rows[GridInstructors.SelectedCells[0].RowIndex].DataBoundItem);

                if (ins != null)
                {
                    var responce = HttpClient.PostAsync($"https://localhost:7173/api/Instructors", new StringContent(JsonSerializer.Serialize(ins), Encoding.UTF8, "application/json")).Result;

                    if (responce.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        MessageBox.Show("Data added Successfully");

                        var content = JsonConvert.DeserializeObject<DepartmentInstructor.Models.Instructor>(responce.Content.ReadAsStringAsync().Result);

                        GridInstructors.Rows[GridInstructors.SelectedCells[0].RowIndex].Cells[0].Value = content.Id;
                    }
                }
            }
        }
    }
}