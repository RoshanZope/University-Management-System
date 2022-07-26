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
    public partial class Campus : System.Web.UI.Page
    {
        SqlConnection Connection;
        SqlCommand cmd;
        string join_dates = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            join_dates = Request.Form["join_date"];
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataTable dtCampus = new DataTable();
            DataLayer dl = new DataLayer();
            dtCampus = dl.GetDBData("Campus");

            if (dtCampus.Rows.Count > 0)
            {
                GridView1.DataSource = dtCampus;
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

                cmd = new SqlCommand("INSERT INTO CampusTbl(Name,City,Director,Rank,Join_Date)values(@Name,@City,@Director,@Rank,@Join_Date)", Connection);

                cmd.Parameters.AddWithValue("@Name", Convert.ToString(txtcamp.Value));
                cmd.Parameters.AddWithValue("@City", Convert.ToString(txtcity.Value));
                cmd.Parameters.AddWithValue("@Director", Convert.ToString(txtdname.Value));
                cmd.Parameters.AddWithValue("@Rank", Convert.ToString(txtdrank.Value));

                if (join_dates != "")
                    cmd.Parameters.AddWithValue("@Join_Date", Convert.ToDateTime(join_dates));
                else
                    cmd.Parameters.AddWithValue("@Join_Date", Convert.ToDateTime(""));

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
                cmd = new SqlCommand("UPDATE CampusTbl SET Name = @Name ,City = @City, Director = @Director ,Rank = @Rank ,Join_Date =@Join_Date  WHERE Camp_Id=@SKey", Connection);

                cmd.Parameters.AddWithValue("@Name", Convert.ToString(txtcamp.Value));
                cmd.Parameters.AddWithValue("@City", Convert.ToString(txtcity.Value));
                cmd.Parameters.AddWithValue("@Director", Convert.ToString(txtdname.Value));
                cmd.Parameters.AddWithValue("@Rank", Convert.ToString(txtdrank.Value));
                if (join_dates != "")

                    cmd.Parameters.AddWithValue("@Join_Date", Convert.ToDateTime(join_dates));
                else
                    cmd.Parameters.AddWithValue("@Join_Date", Convert.ToDateTime(""));

                cmd.ExecuteNonQuery();
                Connection.Close();
                BindGrid();

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string stdId = GridView1.SelectedRow.Cells[0].Text;
                string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
                SqlConnection Connection = new SqlConnection(constr);
                Connection.Open();
                SqlCommand cmd = new SqlCommand("Delete from CampusTbl where Camp_Id=@Camp_Id", Connection);
                cmd.Parameters.AddWithValue("@Camp_Id", stdId);
                int result = cmd.ExecuteNonQuery();
                Connection.Close();
                BindGrid();
                if (result == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted Successfully..!! ');", true);
                    BindGrid();
                }
            }
            catch (Exception EX)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + EX.Message + "');", true);
            }

        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToString(GridView1.SelectedRow.Cells[1].Text) != "")
                    txtcamp.Value = Convert.ToString(GridView1.SelectedRow.Cells[1].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[2].Text) != "")
                    txtcity.Value = GridView1.SelectedRow.Cells[2].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[3].Text) != "")
                    txtdname.Value = Convert.ToString(GridView1.SelectedRow.Cells[3].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[4].Text) != "")
                    txtdrank.Value = GridView1.SelectedRow.Cells[4].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[5].Text) != "")
                    join_dates = Convert.ToString(GridView1.SelectedRow.Cells[5].Text);


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}