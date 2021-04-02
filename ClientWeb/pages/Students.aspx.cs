using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace ClientWeb.pages
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;

        }

        protected async void Button2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            Panel4.Visible = false;
            if (TextBox1.Text == null)
            {
                Label1.Text = "Please enter credentials";
            }
            else
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44346/api/");
                //IEnumerable<User> users = new IEnumerable<User>();
                HttpResponseMessage response = await client.GetAsync("Students/Search/"+ TextBox1.Text);
                IEnumerable<User> users;
                if (response.IsSuccessStatusCode)
                {
                    var formatters = new List<MediaTypeFormatter>() {
                    new JsonMediaTypeFormatter(),
                    new XmlMediaTypeFormatter()
                };
                    users = await response.Content.ReadAsAsync<IEnumerable<User>>(formatters);
                    foreach (var cust in users)
                    {
                        Response.Write("Name: " + cust.Name + "<br> " + "Gender: " + cust.Gender + " <br> "
                                  + "DOB " + cust.DOB + "<br> " + "Std :" + cust.Std + "<br>" + "-----" + "<br>");
                    }
                }
                Label1.Text = "";
            }
        }

        protected async void AllStudents_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            //IEnumerable<User> users = new IEnumerable<User>();
            HttpResponseMessage response = await client.GetAsync("Students");
            IEnumerable<User> users;
            if (response.IsSuccessStatusCode)
            {
                var formatters = new List<MediaTypeFormatter>() {
                    new JsonMediaTypeFormatter(),
                    new XmlMediaTypeFormatter()
                };
                users = await response.Content.ReadAsAsync<IEnumerable<User>>(formatters);
                foreach (var cust in users)
                {
                    Response.Write("Name: " + cust.Name + "<br> " + "Gender: " + cust.Gender + " <br> "
                              + "DOB " + cust.DOB + "<br> "+ "Std :" + cust.Std + "<br>" + "-----" + "<br>");
                }
            }
        }

        protected void AddStudent_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Label1.Text = "Enter credentials";
        }

        protected async void Button4_Click(object sender, EventArgs e)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            User user = new User();
            user.Type = UserType.Student;
            user.Std = Convert.ToInt32(Std.Text);
            user.Name = Name.Text;
            user.Gender = Gender.Text;
            user.DOB = Convert.ToDateTime(DOB.Text);

            HttpResponseMessage response = await client.PostAsJsonAsync($"Students", user);
            if (response.IsSuccessStatusCode)
            {
                Label1.Text = "User saved successfully!!";
            }
            else
            {
                Label1.Text = response.StatusCode.ToString();
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = true;
        }

        protected async void GetUser_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            HttpResponseMessage response = await client.GetAsync("Students/" + TextBox8.Text);
            if (response.IsSuccessStatusCode)
            {
                var formatters = new List<MediaTypeFormatter>() {
                    new JsonMediaTypeFormatter(),
                    new XmlMediaTypeFormatter()
                };
                var user = await response.Content.ReadAsAsync<User>(formatters);
                if (user != null)
                {
                    TextBox2.Text = user.Name;
                    TextBox3.Text = user.Gender;
                    TextBox4.Text = user.DOB.ToString();
                    TextBox6.Text = user.Std.ToString();
                    Label1.Text = "Student retrived successfully!";
                }
                else
                {
                    Label1.Text = response.StatusCode.ToString();
                }
            }
            else
            {
                Label1.Text = response.StatusCode.ToString();
            }
        }

        protected async void Button5_Click(object sender, EventArgs e)
        {

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            User user = new User();
            user.Type = UserType.Student;
            user.Std = Convert.ToInt32(TextBox6.Text);
            user.Id = Convert.ToInt32(TextBox8.Text);
            user.Name = TextBox2.Text;
            user.Gender = TextBox3.Text;
            String Text = "22/11/2009";

            user.DOB = DateTime.ParseExact(Text, "dd/MM/yyyy", null);
            HttpResponseMessage response = await client.PutAsJsonAsync($"Students/{user.Id}", user);
            if (response.IsSuccessStatusCode)
            {
                Label1.Text = "User updated successfully!!";
            }
            else
            {
                Label1.Text = response.StatusCode.ToString();
            }
        }

        protected async void DeleteStudent_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            HttpResponseMessage response = await client.DeleteAsync($"Students/{TextBox8.Text}");
            if (response.IsSuccessStatusCode)
            {
                Label1.Text = "User deleted successfully!!";
            }
            else
            {
                Label1.Text = response.StatusCode.ToString();
            }
        }
    }
}