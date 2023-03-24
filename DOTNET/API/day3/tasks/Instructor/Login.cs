using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instructor
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (email.Text.Length > 0 && password.Text.Length > 0)
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["email"] = email.Text;
                parameters["password"] = password.Text;
                var responce = client.PostAsync("https://localhost:7173/login", new StringContent(JsonSerializer.Serialize(parameters), Encoding.UTF8, "application/json")).Result;

                if (responce.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var instructors = new Instructors(responce.Content.ReadAsStringAsync().Result);
                    instructors.ShowDialog();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong info");
                }
            }
        }
    }
}
