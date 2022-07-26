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
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection Connection;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {

            string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            Connection = new SqlConnection(constr);
            Connection.Open();

            cmd = new SqlCommand("SELECT COUNT(StId) StId FROM StudentTbl", Connection);
            lblStd.InnerText = Convert.ToString(cmd.ExecuteScalar());

            cmd = new SqlCommand("SELECT COUNT(DeptId) DeptId FROM DepartmentTbl", Connection);
            lblDept.InnerText = Convert.ToString(cmd.ExecuteScalar());

            cmd = new SqlCommand("SELECT COUNT(Camp_Id) CampId FROM CampusTbl", Connection);
            lblCamp.InnerText = Convert.ToString(cmd.ExecuteScalar());

            cmd = new SqlCommand("SELECT COUNT(F_Id) FId FROM FacultyTbl", Connection);
            lblfact.InnerText = Convert.ToString(cmd.ExecuteScalar());

            cmd = new SqlCommand("SELECT SUM(Amount) Amount FROM FeesTbl", Connection);
            if (Convert.ToString(cmd.ExecuteScalar()) != "")
                lblFinc.InnerText = "Rs." + Convert.ToString(cmd.ExecuteScalar());
            else
                lblFinc.InnerText = "Rs.0";

            cmd = new SqlCommand("SELECT SUM(Salary) Salary FROM SalaryTbl", Connection);
            if (Convert.ToString(cmd.ExecuteScalar()) != "")
                lblSal.InnerText = "Rs." + Convert.ToString(cmd.ExecuteScalar());
            else
                lblSal.InnerText = "Rs.0";

            Connection.Close();
        }
    }
}