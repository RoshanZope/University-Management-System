using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace University_Management_System
{
    public partial class Department : System.Web.UI.Page
    {
        SqlConnection Connection;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            DataTable dtDept = new DataTable();
            DataLayer dl = new DataLayer();
            dtDept = dl.GetDBData("GetDepartmentList");

            if (dtDept.Rows.Count > 0)
            {
                GridView1.DataSource = dtDept;
                GridView1.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
                Connection = new SqlConnection(constr);
                Connection.Open();
                cmd = new SqlCommand("Insert Into DepartmentTbl(Name,Intake,Fees)values(@Name,@Intake,@Fees)", Connection);

                cmd.Parameters.AddWithValue("@Name", Convert.ToString(txtdept.Value));
                cmd.Parameters.AddWithValue("@Intake", Convert.ToInt32(txtintake.Value));
                cmd.Parameters.AddWithValue("@Fees", Convert.ToInt32(txtFPY.Value));

                cmd.ExecuteNonQuery();
                Connection.Close();
                BindGrid();

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string stdId = GridView1.SelectedRow.Cells[0].Text;
                string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
                Connection = new SqlConnection(constr);
                Connection.Open();
                cmd = new SqlCommand("UPDATE DepartmentTbl SET Name=@Name,Intake=@Intake,Fees=@Fees WHERE DeptId=@SKey", Connection);

                cmd.Parameters.AddWithValue("@Name", Convert.ToString(txtdept.Value));
                cmd.Parameters.AddWithValue("@Intake", Convert.ToInt32(txtintake.Value));
                cmd.Parameters.AddWithValue("@Fees", Convert.ToInt32(txtFPY.Value));
                cmd.Parameters.AddWithValue("@SKey", stdId);

                cmd.ExecuteNonQuery();
                Connection.Close();
                BindGrid();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='hand'";
                    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

            try
            {

                if (Convert.ToString(GridView1.SelectedRow.Cells[1].Text) != "")
                    txtdept.Value = GridView1.SelectedRow.Cells[1].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[2].Text) != "")
                    txtintake.Value = GridView1.SelectedRow.Cells[2].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[3].Text) != "")
                    txtFPY.Value = GridView1.SelectedRow.Cells[3].Text;

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string stdId = GridView1.SelectedRow.Cells[0].Text;

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
                SqlConnection Connection = new SqlConnection(constr);
                Connection.Open();
                SqlCommand cmd = new SqlCommand("Delete from DepartmentTbl where DeptId=@StKey", Connection);
                cmd.Parameters.AddWithValue("@StKey", stdId);
                cmd.ExecuteNonQuery();
                Connection.Close();
                BindGrid();
            }
            catch (Exception Ex)
            {
            }
        }
    }
}
