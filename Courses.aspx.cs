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
    public partial class Courses : System.Web.UI.Page
    {
        SqlConnection Connection;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindDept();
                BindFaculty();
            }
        }

        private void BindGrid()
        {
            DataTable dtCourses = new DataTable();
            DataLayer dl = new DataLayer();
            dtCourses = dl.GetDBData("Courses");

            if (dtCourses.Rows.Count > 0)
            {
                GridView1.DataSource = dtCourses;
                GridView1.DataBind();
            }
        }

        public void BindDept()
        {

            try
            {
                DataTable dtDept = new DataTable();
                DataLayer dl = new DataLayer();
                dtDept = dl.GetDBData("GetDepartmentList");

                if (dtDept.Rows.Count > 0)
                {
                    ddlDeptID.DataTextField = "Name";
                    ddlDeptID.DataValueField = "DeptId";
                    ddlDeptID.DataSource = dtDept;
                    ddlDeptID.DataBind();
                    ddlDeptID.Items.Insert(0, new ListItem("Choose...", "0"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetDeptName()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
                string Query = "Select * from DepartmentTbl where DeptId = " + ddlDeptID.SelectedValue.ToString() + " ";
                DataTable data = new DataTable();

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            con.Open();
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(data);
                            foreach (DataRow dataRow in data.Rows)
                            {
                                txtDeptName.Value = dataRow["Name"].ToString();
                            }

                            con.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        public void BindFaculty()
        {

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
                string Query = "Select * from FacultyTbl";
                DataTable dtDept = new DataTable();

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            con.Open();
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dtDept);

                            if (dtDept.Rows.Count > 0)
                            {
                                ddlfactid.DataTextField = "Name";
                                ddlfactid.DataValueField = "F_Id";
                                ddlfactid.DataSource = dtDept;
                                ddlfactid.DataBind();
                                ddlfactid.Items.Insert(0, new ListItem("Choose...", "0"));
                            }

                            con.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetFacultyName()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
                string Query = "Select * from FacultyTbl where F_Id = " + ddlfactid.SelectedValue.ToString() + " ";
                DataTable data = new DataTable();

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            con.Open();
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(data);
                            foreach (DataRow dataRow in data.Rows)
                            {
                                txtfname.Value = dataRow["Name"].ToString();
                            }

                            con.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        protected void ddlDeptID_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDeptName();
        }

        protected void ddlfactid_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFacultyName();
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
                    txtCname.Value = GridView1.SelectedRow.Cells[1].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[2].Text) != "")
                    txtCH.Value = GridView1.SelectedRow.Cells[2].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[3].Text) != "")
                    ddlDeptID.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[3].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[4].Text) != "")
                    txtDeptName.Value = GridView1.SelectedRow.Cells[4].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[5].Text) != "")
                    ddlfactid.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[5].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[6].Text) != "")
                    txtfname.Value = GridView1.SelectedRow.Cells[6].Text;

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
                Connection = new SqlConnection(constr);
                Connection.Open();
                cmd = new SqlCommand("INSERT INTO CourseTbl(Course_Name,Credit_Hrs,DeptId,Department,Fac_Id,Fac_Name)values(@Course_Name,@Credit_Hrs,@DeptId,@Department,@Fac_Id,@Fac_Name)", Connection);

                cmd.Parameters.AddWithValue("@Course_Name", Convert.ToString(txtCname.Value));
                cmd.Parameters.AddWithValue("@Credit_Hrs", Convert.ToInt32(txtCH.Value));
                cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(ddlDeptID.SelectedValue));
                cmd.Parameters.AddWithValue("@Department", Convert.ToString(ddlDeptID.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@Fac_Id", Convert.ToInt32(ddlfactid.SelectedValue));
                cmd.Parameters.AddWithValue("@Fac_Name", Convert.ToString(txtfname.Value));

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
                cmd = new SqlCommand("UPDATE CourseTbl SET Course_Name=@Course_Name,Credit_Hrs=@Credit_Hrs,DeptId=@DeptId,Department=@Department,Fac_Id=@Fac_Id,Fac_Name=@Fac_Name WHERE Course_Id=@SKey", Connection);

                cmd.Parameters.AddWithValue("@Course_Name", Convert.ToString(txtCname.Value));
                cmd.Parameters.AddWithValue("@Credit_Hrs", Convert.ToInt32(txtCH.Value));
                cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(ddlDeptID.SelectedValue));
                cmd.Parameters.AddWithValue("@Department", Convert.ToString(ddlDeptID.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@Fac_Id", Convert.ToInt32(ddlfactid.SelectedValue));
                cmd.Parameters.AddWithValue("@Fac_Name", Convert.ToString(txtfname.Value));
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            string stdId = GridView1.SelectedRow.Cells[0].Text;

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
                SqlConnection Connection = new SqlConnection(constr);
                Connection.Open();
                SqlCommand cmd = new SqlCommand("Delete from CourseTbl where Course_Id=@StKey", Connection);
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