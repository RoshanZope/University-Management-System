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
    public partial class Faculty : System.Web.UI.Page
    {
        string dtDOB = "";
        SqlConnection Connection;
        SqlCommand cmd;

        DataTable dtFact = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            dtDOB = Request.Form["DOBDate"];

            if (!IsPostBack)
            {
                BindGrid();
                BindDept();
            }
        }

        private void BindGrid()
        {
            DataLayer dl = new DataLayer();
            dtFact = dl.GetDBData("GetFacultyList");

            if (dtFact.Rows.Count > 0)
            {
                GridView1.DataSource = dtFact;
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
                    txtFname.Value = GridView1.SelectedRow.Cells[1].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[2].Text) != "")
                    txtMail.Value = GridView1.SelectedRow.Cells[2].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[3].Text) != "")
                    ddlGender.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[3].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[4].Text) != "")
                    txtaddress.Value = GridView1.SelectedRow.Cells[4].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[5].Text) != "")
                    ddlDeptID.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[5].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[6].Text) != "")
                    txtDeptName.Value = GridView1.SelectedRow.Cells[6].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[7].Text) != "")
                    txtQual.Value = GridView1.SelectedRow.Cells[7].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[8].Text) != "")
                    txtsalary.Value = GridView1.SelectedRow.Cells[8].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[9].Text) != "")
                    txtExp.Value = GridView1.SelectedRow.Cells[9].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[10].Text) != "")
                    dtDOB = Convert.ToString(GridView1.SelectedRow.Cells[10].Text);

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ddlDeptID_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDeptName();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
                Connection = new SqlConnection(constr);
                Connection.Open();
                cmd = new SqlCommand("INSERT INTO FacultyTbl(Name,DOB,Gender,Address,Qualification,Experience,DeptId,Department,Salary,Email)values(@Name,@DOB,@Gender,@Address,@Qualification,@Experience,@DeptId,@Department,@Salary,@Email)", Connection);

                cmd.Parameters.AddWithValue("@Name", Convert.ToString(txtFname.Value));

                if (dtDOB != "")

                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(dtDOB));
                else
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(""));

                cmd.Parameters.AddWithValue("@Gender", Convert.ToString(ddlGender.SelectedValue));
                cmd.Parameters.AddWithValue("@Address", Convert.ToString(txtaddress.Value));
                cmd.Parameters.AddWithValue("@Qualification", Convert.ToString(txtQual.Value));
                cmd.Parameters.AddWithValue("@Experience", Convert.ToInt32(txtExp.Value));
                cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(ddlDeptID.SelectedValue));
                cmd.Parameters.AddWithValue("@Department", Convert.ToString(ddlDeptID.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@Salary", Convert.ToInt32(txtsalary.Value));
                cmd.Parameters.AddWithValue("@Email", Convert.ToString(txtMail.Value));


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
                cmd = new SqlCommand("UPDATE FacultyTbl SET Name=@Name,DOB=@DOB,Gender=@Gender,Address=@Address,Qualification=@Qualification,Experience=@Experience,DeptId=@DeptId,Department=@Department,Salary=@Salary,Email=@Email WHERE F_Id=@SKey", Connection);

                cmd.Parameters.AddWithValue("@Name", Convert.ToString(txtFname.Value));

                if (dtDOB != "")

                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(dtDOB));
                else
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(""));

                cmd.Parameters.AddWithValue("@Gender", Convert.ToString(ddlGender.SelectedValue));
                cmd.Parameters.AddWithValue("@Address", Convert.ToString(txtaddress.Value));
                cmd.Parameters.AddWithValue("@Qualification", Convert.ToString(txtQual.Value));
                cmd.Parameters.AddWithValue("@Experience", Convert.ToInt32(txtExp.Value));
                cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(ddlDeptID.SelectedValue));
                cmd.Parameters.AddWithValue("@Department", Convert.ToString(ddlDeptID.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@Salary", Convert.ToInt32(txtsalary.Value));
                cmd.Parameters.AddWithValue("@Email", Convert.ToString(txtMail.Value));
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
                SqlCommand cmd = new SqlCommand("Delete from FacultyTbl where F_Id=@StKey", Connection);
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