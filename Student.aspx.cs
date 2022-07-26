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
    public partial class Student : System.Web.UI.Page
    {
        string dtDOB = "";

        Students std = new Students();

        protected void Page_Load(object sender, EventArgs e)
        {

            dtDOB = Request.Form["DOBDate"];

            if (!IsPostBack)
            {
                BindGrid();
                BindDept();
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

        private void BindGrid()
        {

            try
            {
                DataTable dtStd = new DataTable();
                DataLayer dl = new DataLayer();
                dtStd = dl.GetDBData("GetStudentList");

                if (dtStd.Rows.Count > 0)
                {
                    GridView1.DataSource = dtStd;
                    GridView1.DataBind();
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

                    e.Row.Cells[4].Visible = false;
                    GridView1.HeaderRow.Cells[4].Visible = false;

                    e.Row.Cells[7].Visible = false;
                    GridView1.HeaderRow.Cells[7].Visible = false;

                    e.Row.Cells[9].Visible = false;
                    GridView1.HeaderRow.Cells[9].Visible = false;

                    e.Row.Cells[11].Visible = false;
                    GridView1.HeaderRow.Cells[11].Visible = false;

                    e.Row.Cells[14].Visible = false;
                    GridView1.HeaderRow.Cells[14].Visible = false;

                    e.Row.Cells[16].Visible = false;
                    GridView1.HeaderRow.Cells[16].Visible = false;
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

                BindDept();

                if (Convert.ToString(GridView1.SelectedRow.Cells[1].Text) != "")
                    txtstdName.Value = GridView1.SelectedRow.Cells[1].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[2].Text) != "")
                    txtMail.Value = GridView1.SelectedRow.Cells[2].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[5].Text) != "")
                    txtaddress.Value = GridView1.SelectedRow.Cells[5].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[10].Text) != "")
                    txtzip.Value = GridView1.SelectedRow.Cells[10].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[12].Text) != "")
                    txtDeptName.Value = GridView1.SelectedRow.Cells[12].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[15].Text) != "")
                    txtMobNo.Value = GridView1.SelectedRow.Cells[15].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[4].Text) != "")
                    ddlGender.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[4].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[7].Text) != "")
                    ddlcountry.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[7].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[9].Text) != "")
                    ddlstate.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[9].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[11].Text) != "")
                    ddlDeptID.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[11].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[14].Text) != "")
                    ddlSemester.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[14].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[14].Text) != "")
                    dtDOB = Convert.ToString(GridView1.SelectedRow.Cells[16].Text);

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
                Students std = new Students();

                std.Name = Convert.ToString(txtstdName.Value);
                std.Email = Convert.ToString(txtMail.Value);
                std.Address = Convert.ToString(txtaddress.Value);
                std.ZIP = Convert.ToInt32(txtzip.Value);
                std.Department = Convert.ToString(txtDeptName.Value);
                std.Phone = Convert.ToString(txtMobNo.Value);

                std.SemesterName = Convert.ToString(ddlSemester.SelectedItem.Text);
                std.Semester = Convert.ToInt32(ddlSemester.SelectedValue);

                std.GenderText = Convert.ToString(ddlGender.SelectedItem.Text);
                std.Gender = Convert.ToString(ddlGender.SelectedValue);

                std.CountryName = Convert.ToString(ddlcountry.SelectedItem.Text);
                std.Country = Convert.ToInt32(ddlcountry.SelectedValue);

                std.StateName = Convert.ToString(ddlstate.SelectedItem.Text);
                std.State = Convert.ToInt32(ddlstate.SelectedValue);

                std.Department = Convert.ToString(ddlDeptID.SelectedItem.Text);
                std.DeptId = Convert.ToInt32(ddlDeptID.SelectedValue);

                if (dtDOB != "")
                    std.DOB = Convert.ToDateTime(dtDOB);
                else
                    std.DOB = Convert.ToDateTime("");

                DataLayer dl = new DataLayer();
                dl.InsertData(std);
                BindGrid();
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        protected void ddlDeptID_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDeptName();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                GetValue();
                string stdId = GridView1.SelectedRow.Cells[0].Text;
                string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

                SqlConnection Connection = new SqlConnection(constr);
                Connection.Open();

                SqlCommand cmd = new SqlCommand("Update StudentTbl SET Name=@SN,DOB=@SDOB,Gender=@SGen,Address=@SAdd,DeptId=@SDeptId,Department=@SDept,Phone=@SPh,Semester=@Sem,Email=@Email,Country=@Country,State=@State,ZIP=@ZIP,GenderText=@GenderText,CountryName=@CountryName,StateName=@StateName,SemesterName=@SemesterName where StId=@SKey", Connection);

                cmd.Parameters.AddWithValue("@SN", std.Name);
                cmd.Parameters.AddWithValue("@SDOB", std.DOB.Date);
                cmd.Parameters.AddWithValue("@SGen", std.Gender);
                cmd.Parameters.AddWithValue("@SAdd", std.Address);
                cmd.Parameters.AddWithValue("@SDeptId", std.DeptId.ToString());
                cmd.Parameters.AddWithValue("@SDept", std.Department);
                cmd.Parameters.AddWithValue("@SPh", std.Phone);
                cmd.Parameters.AddWithValue("@Sem", std.Semester.ToString());

                cmd.Parameters.AddWithValue("@Email", std.Email);
                cmd.Parameters.AddWithValue("@Country", std.Country);
                cmd.Parameters.AddWithValue("@State", std.State);
                cmd.Parameters.AddWithValue("@ZIP", std.ZIP);
                cmd.Parameters.AddWithValue("@GenderText", std.GenderText.ToString());

                cmd.Parameters.AddWithValue("@CountryName", std.CountryName);
                cmd.Parameters.AddWithValue("@StateName", std.StateName.ToString());
                cmd.Parameters.AddWithValue("@SemesterName", std.SemesterName);
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
                SqlCommand cmd = new SqlCommand("Delete from StudentTbl where StId=@StKey", Connection);
                cmd.Parameters.AddWithValue("@StKey", stdId);
                cmd.ExecuteNonQuery();
                Connection.Close();
                BindGrid();
            }
            catch (Exception Ex)
            {
            }
        }

        public void GetValue()
        {

            std.Name = Convert.ToString(txtstdName.Value);
            std.Email = Convert.ToString(txtMail.Value);
            std.Address = Convert.ToString(txtaddress.Value);
            std.ZIP = Convert.ToInt32(txtzip.Value);
            std.Department = Convert.ToString(txtDeptName.Value);
            std.Phone = Convert.ToString(txtMobNo.Value);

            std.SemesterName = Convert.ToString(ddlSemester.SelectedItem.Text);
            std.Semester = Convert.ToInt32(ddlSemester.SelectedValue);

            std.GenderText = Convert.ToString(ddlGender.SelectedItem.Text);
            std.Gender = Convert.ToString(ddlGender.SelectedValue);

            std.CountryName = Convert.ToString(ddlcountry.SelectedItem.Text);
            std.Country = Convert.ToInt32(ddlcountry.SelectedValue);

            std.StateName = Convert.ToString(ddlstate.SelectedItem.Text);
            std.State = Convert.ToInt32(ddlstate.SelectedValue);

            std.Department = Convert.ToString(ddlDeptID.SelectedItem.Text);
            std.DeptId = Convert.ToInt32(ddlDeptID.SelectedValue);

            if (dtDOB != "")
                std.DOB = Convert.ToDateTime(dtDOB);
            else
                std.DOB = Convert.ToDateTime("");

        }
    }
}