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
    public partial class Teachers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
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
                /*
                ClientWeb.UserService.UserServiceClient proxy = new ClientWeb.UserService.UserServiceClient();
                DataSet ds = proxy.SearchTeacher(TextBox1.Text);
                DataTable dt = ds.Tables[0];
                GridView2.DataSource = dt;
                GridView2.DataBind();
                */
            }
        }

        protected async void AllTeachers_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            //IEnumerable<User> users = new IEnumerable<User>();
            HttpResponseMessage response = await client.GetAsync("Teachers");
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
                              + "DOB " + cust.DOB + "<br> " + "Subject :" + cust.Subject + "<br>" + "-----" + "<br>");
                }
                Label1.Text = "Teachers retrived successfully!!";
            }
        }

        protected void AddTeacher_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Label1.Text = "Enter credentials";
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
            //IEnumerable<User> users = new IEnumerable<User>();
            HttpResponseMessage response = await client.GetAsync("Teachers/" + TextBox8.Text);
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
                    TextBox6.Text = user.Subject;
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
            user.Subject = TextBox6.Text;
            user.Id = Convert.ToInt32(TextBox8.Text);
            user.Name = TextBox2.Text;
            user.Gender = TextBox3.Text;
            String Text = "22/11/2009";

            user.DOB = DateTime.ParseExact(Text, "dd/MM/yyyy", null);
            HttpResponseMessage response = await client.PutAsJsonAsync($"Teachers/{user.Id}", user);
            if (response.IsSuccessStatusCode)
            {
                Label1.Text = "User updated successfully!!";
            }
            else
            {
                Label1.Text = response.StatusCode.ToString();
            }
            /*
            UserService.IUserService client = new UserService.UserServiceClient();
            UserService.UserInfo user = new UserService.UserInfo();
            user.Type = UserService.UserType.Teacher;
            user.Sub = TextBox6.Text;
            user.ID = Convert.ToInt32(TextBox8.Text);
            user.Name = TextBox2.Text;
            user.Gender = TextBox3.Text;
            String Text = "22/11/2009";

            user.DOB = DateTime.ParseExact(Text, "dd/MM/yyyy", null);
            client.UpdateUser(user);
            Label1.Text = "Teacher updated successfully!!";
            */
        }

        protected async void DeleteTeacher_Click(object sender, EventArgs e)
        {
            /*
            UserService.IUserService client = new UserService.UserServiceClient();

            client.DeleteUser(Convert.ToInt32(TextBox8.Text));
            Label1.Text = "Deleted successfully";
            */

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            HttpResponseMessage response = await client.DeleteAsync($"Teachers/{TextBox8.Text}");
            if (response.IsSuccessStatusCode)
            {
                Label1.Text = "Teacher deleted successfully!!";
            }
            else
            {
                Label1.Text = response.StatusCode.ToString();
            }
        }

        protected async void Button4_Click(object sender, EventArgs e)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            User user = new User();
            user.Type = UserType.Teacher;
            user.Subject = Sub.Text;
            user.Name = Name.Text;
            user.Gender = Gender.Text;
            user.DOB = Convert.ToDateTime(DOB.Text);

            HttpResponseMessage response = await client.PostAsJsonAsync($"Teachers", user);
            if (response.IsSuccessStatusCode)
            {
                Label1.Text = "Teacher saved successfully!!";
            }
            else
            {
                Label1.Text = response.StatusCode.ToString();
            }
            /*
            UserService.IUserService client = new UserService.UserServiceClient();
            UserService.UserInfo user = new UserService.UserInfo();
            user.Type = UserService.UserType.Teacher;
            user.Sub = Sub.Text;
            user.ID = Convert.ToInt32(Id.Text);
            user.Name = Name.Text;
            user.Gender = Gender.Text;
            user.DOB = Convert.ToDateTime(DOB.Text);

            client.SaveUser(user);
            Label1.Text = "Teachers saved successfully!!";
            */
        }
    }
}