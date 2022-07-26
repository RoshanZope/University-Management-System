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
    public partial class salary : System.Web.UI.Page
    {
        SqlConnection Connection;
        SqlCommand cmd;
        string PayDates = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            PayDates = Request.Form["PayDate"];

            if (!IsPostBack)
            {
                BindGrid();
                BindDept();
                BindFaculty();
                
            }
        }

        private void BindGrid()
        {
            DataTable dtSalary = new DataTable();
            DataLayer dl = new DataLayer();
            dtSalary = dl.GetDBData("Salary");

            if (dtSalary.Rows.Count > 0)
            {
                GridView1.DataSource = dtSalary;
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
                    ddlDeptId.DataTextField = "Name";
                    ddlDeptId.DataValueField = "DeptId";
                    ddlDeptId.DataSource = dtDept;
                    ddlDeptId.DataBind();
                    ddlDeptId.Items.Insert(0, new ListItem("Choose...", "0"));
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
                string Query = "Select * from DepartmentTbl where DeptId = " + ddlDeptId.SelectedValue.ToString() + " ";
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
                                txtdepartment.Value= dataRow["Name"].ToString();
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
        
        protected void ddlDeptId_SelectedIndexChanged(object sender, EventArgs e)
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
                    ddlfactid.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[1].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[2].Text) != "")
                    txtfname.Value = GridView1.SelectedRow.Cells[2].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[3].Text) != "")
                    amount.Value = Convert.ToString(GridView1.SelectedRow.Cells[3].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[4].Text) != "")
                    txtdepartment.Value = GridView1.SelectedRow.Cells[4].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[5].Text) != "")
                    PayDates = Convert.ToString(GridView1.SelectedRow.Cells[5].Text);


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
                cmd = new SqlCommand("INSERT INTO SalaryTbl(F_Id,F_Name,Salary,Department,PayDate)values(@F_Id,@F_Name,@Salary,@Department,@PayDate)", Connection);

                cmd.Parameters.AddWithValue("@F_Id", Convert.ToInt32(ddlfactid.SelectedValue));
                cmd.Parameters.AddWithValue("@F_Name", Convert.ToString(txtfname.Value));
                cmd.Parameters.AddWithValue("@Salary", Convert.ToInt32(amount.Value));
                cmd.Parameters.AddWithValue("@Department", Convert.ToString(ddlDeptId.SelectedItem.Text));
                if (PayDates != "")
                    cmd.Parameters.AddWithValue("@PayDate", Convert.ToDateTime(PayDates));
                else
                    cmd.Parameters.AddWithValue("@PayDate", Convert.ToDateTime(""));
                int result = cmd.ExecuteNonQuery();
                Connection.Close();

                if (result == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Fees Data Saved Successfully..!! ');", true);
                    BindGrid();
                }
            }
            catch (Exception EX)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + EX.Message + "');", true);
            }

        }

    
    }
}