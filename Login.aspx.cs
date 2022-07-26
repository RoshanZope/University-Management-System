using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace University_Management_System
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection Connection;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = 0;

                if (txtEmail.Value != "" && txtPwd.Value != "")
                {

                    string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
                    Connection = new SqlConnection(constr);
                    Connection.Open();

                    cmd = new SqlCommand("SELECT ID from LoginTbl where Username =@Username AND Password=@Password", Connection);

                    cmd.Parameters.AddWithValue("@Username", Convert.ToString(txtEmail.Value));
                    cmd.Parameters.AddWithValue("@Password", Convert.ToString(txtPwd.Value));

                    ID = Convert.ToInt32(cmd.ExecuteScalar());

                    if (ID > 0)
                    {
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Username & Password Wrong..!! ');", true);
                    }

                    Connection.Close();

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Username & Password..!! ');", true);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}