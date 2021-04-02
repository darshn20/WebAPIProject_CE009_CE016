using System;
using System.Net.Http.Formatting;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using WebApplication1.Models;

namespace ClientWeb
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }
        protected async void btnGetUser_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            //IEnumerable<User> users = new IEnumerable<User>();
            HttpResponseMessage response = await client.GetAsync("Users/"+ TextBox1.Text);
            if (response.IsSuccessStatusCode)
            {
                var formatters = new List<MediaTypeFormatter>() {
                    new JsonMediaTypeFormatter(),
                    new XmlMediaTypeFormatter()
                };
                User user = await response.Content.ReadAsAsync<User>(formatters);
                if (user!=null)
                {
                    TextBox2.Text = user.Name;
                    TextBox3.Text = user.Gender;
                    TextBox4.Text = user.DOB.ToString();
                    if (user.Type== UserType.Student)
                    {
                        tr1.Visible = true;
                        tr2.Visible = false;
                        Label2.Text = "Student";
                        TextBox6.Text = user.Std.ToString();
                    }
                    else
                    {

                        tr1.Visible = false;
                        tr2.Visible = true;
                        Label2.Text = "Teacher";
                        TextBox7.Text = user.Subject.ToString();
                    }
                }
                else
                {
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox7.Text = "";
                    TextBox6.Text = "";
                    Label2.Text = "";
                    Label1.Text = "No user with this ID ,Enter valid!";
                }
            }
            else
            {
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox7.Text = "";
                TextBox6.Text = "";
                Label2.Text = "";
                Label1.Text = "No user with this ID ,Enter valid!";
            }
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Panel1.Visible = true;
            if (ddlUserType.SelectedValue == "-1")
            {
                trSub.Visible = false;
                trStd.Visible = false;
            }
            else if (ddlUserType.SelectedValue == "1")
            {
                trStd.Visible = true;
                trSub.Visible = false;
            }
            else
            {
                trStd.Visible = false;
                trSub.Visible = true;
            }
        }

        protected async void btnSave_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            //IEnumerable<User> users = new IEnumerable<User>();
            User user = new User();
            if (ddlUserType.SelectedValue == "-1")
            {
                lblMessage.Text = "Please select User Type";
            }
            else
            {
                if (((UserType)Convert.ToInt32(ddlUserType.SelectedValue)) == UserType.Student)
                {
                    user.Type = UserType.Student;
                    user.Std = Convert.ToInt32(txtStd.Text);
                }
                else
                {
                    user.Type = UserType.Teacher;
                    user.Subject = (txtSubject.Text).ToString();
                }
                user.Name = txtName.Text;
                user.Gender = txtGender.Text;
                user.DOB = Convert.ToDateTime(txtDateOfBirth.Text);

                HttpResponseMessage response = await client.PostAsJsonAsync("Users", user);
                if (response.IsSuccessStatusCode)
                {
                    lblMessage.Text = "User saved successfully!!";
                }
                else
                {
                    lblMessage.Text = response.StatusCode.ToString();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
            Panel3.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
        }

        protected async void Button3_Click(object sender, EventArgs e)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            //IEnumerable<User> users = new IEnumerable<User>();
            HttpResponseMessage response = await client.GetAsync("Users");
            IEnumerable<User> users;
            if (response.IsSuccessStatusCode)
            {
                var formatters = new List<MediaTypeFormatter>() {
                    new JsonMediaTypeFormatter(),
                    new XmlMediaTypeFormatter()
                };
                users=await response.Content.ReadAsAsync<IEnumerable<User>>(formatters);
                foreach (var cust in users)
                {
                    Response.Write("Name: " + cust.Name + "<br> " + "Gender: " + cust.Gender + " <br> "
                              + "DOB " + cust.DOB + "<br> " + "Subject :" + cust.Subject + "<br>" + "Std :" + cust.Std + "<br>" + "-----" + "<br>");
                }
            }
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }
            DataTable tb1 = tb;
            return tb1;

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected async void Button4_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            HttpResponseMessage response = await client.DeleteAsync($"Users/{TextBox1.Text}");
            if (response.IsSuccessStatusCode)
            {
                Label1.Text = "User deleted successfully!!";
            }
            else
            {
                Label1.Text = response.StatusCode.ToString();
            }

        }

        protected async void Button5_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/");
            //IEnumerable<User> users = new IEnumerable<User>();
            User user = new User();
            if (Label2.Text.Equals("Student"))
            {
                user.Type = UserType.Student;
                user.Std = Convert.ToInt32(TextBox6.Text);
            }
            else
            {
                user.Type = UserType.Teacher;
                user.Subject = (TextBox7.Text).ToString();
            }
            user.Id = Convert.ToInt32(TextBox1.Text);
            user.Name = TextBox2.Text;
            user.Gender = TextBox3.Text;
            String Text = "22/11/2009";

            user.DOB = DateTime.ParseExact(Text, "dd/MM/yyyy", null);
            HttpResponseMessage response = await client.PutAsJsonAsync($"Users/{user.Id}", user);
            if (response.IsSuccessStatusCode)
            {
                lblMessage.Text = "User saved successfully!!";
            }
            else
            {
                lblMessage.Text =response.StatusCode.ToString() ;
            }
        }
    }
}