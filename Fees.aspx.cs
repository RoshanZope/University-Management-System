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
    public partial class Fees : System.Web.UI.Page
    {
        SqlConnection Connection;
        SqlCommand cmd;

        string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        string PayDates = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            PayDates = Request.Form["PayDate"];

            if (!IsPostBack)
            {
                BindGrid();
                BindDept();
                BindStudent();
            }
        }

        private void BindGrid()
        {
            DataTable dtFees = new DataTable();
            DataLayer dl = new DataLayer();
            dtFees = dl.GetDBData("Fees");

            if (dtFees.Rows.Count > 0)
            {
                GridView1.DataSource = dtFees;
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
                                txtdepartment.Value = dataRow["Name"].ToString();
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

        public void BindStudent()
        {

            try
            {

                string Query = "Select * from StudentTbl";
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
                                ddlStdId.DataTextField = "Name";
                                ddlStdId.DataValueField = "StId";
                                ddlStdId.DataSource = dtDept;
                                ddlStdId.DataBind();
                                ddlStdId.Items.Insert(0, new ListItem("Choose...", "0"));
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

        private void GetStudentName()
        {
            try
            {
                string Query = "Select * from StudentTbl where StId = " + ddlStdId.SelectedValue.ToString() + " ";
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
                                txtsname.Value = dataRow["Name"].ToString();
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

                    e.Row.Cells[1].Visible = false;
                    GridView1.HeaderRow.Cells[1].Visible = false;

                    e.Row.Cells[4].Visible = false;
                    GridView1.HeaderRow.Cells[4].Visible = false;

                    e.Row.Cells[6].Visible = false;
                    GridView1.HeaderRow.Cells[6].Visible = false;
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
                    ddlStdId.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[1].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[2].Text) != "")
                    txtsname.Value = GridView1.SelectedRow.Cells[2].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[3].Text) != "")
                    txtamount.Value = Convert.ToString(GridView1.SelectedRow.Cells[3].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[4].Text) != "")
                    ddlDeptId.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[4].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[5].Text) != "")
                    txtdepartment.Value = GridView1.SelectedRow.Cells[5].Text;

                if (Convert.ToString(GridView1.SelectedRow.Cells[6].Text) != "")
                    ddlSemester.SelectedValue = Convert.ToString(GridView1.SelectedRow.Cells[6].Text);

                if (Convert.ToString(GridView1.SelectedRow.Cells[8].Text) != "")
                    PayDates = Convert.ToString(GridView1.SelectedRow.Cells[8].Text);


            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ddlStdId_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetStudentName();
            DataTable dtStd = new DataTable();

            if (Convert.ToInt32(ddlStdId.SelectedValue) > 0)
            {
                Connection = new SqlConnection(constr);
                Connection.Open();

                cmd = new SqlCommand("SELECT DeptId,Semester FROM StudentTbl WHERE StId=@StId", Connection);
                cmd.Parameters.AddWithValue("@StId", Convert.ToInt32(ddlStdId.SelectedValue));
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtStd);

                if (dtStd.Rows.Count > 0)
                {
                    ddlDeptId.SelectedIndex = Convert.ToInt32(dtStd.Rows[0]["DeptId"]);
                    ddlSemester.SelectedIndex = Convert.ToInt32(dtStd.Rows[0]["Semester"]);
                }
            }
        }

        protected void ddlDeptId_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDeptName();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                Connection = new SqlConnection(constr);
                Connection.Open();

                cmd = new SqlCommand("INSERT INTO FeesTbl(StId,StName,StDept,Semester,Amount,PayDate,DeptName,SemesterName)values(@StId,@StName,@StDept,@Semester,@Amount,@PayDate,@DeptName,@SemesterName)", Connection);

                cmd.Parameters.AddWithValue("@StId", Convert.ToInt32(ddlStdId.SelectedValue));
                cmd.Parameters.AddWithValue("@StName", Convert.ToString(txtsname.Value));
                cmd.Parameters.AddWithValue("@StDept", Convert.ToInt32(ddlDeptId.SelectedValue));
                cmd.Parameters.AddWithValue("@Semester", Convert.ToString(ddlSemester.SelectedValue));
                cmd.Parameters.AddWithValue("@Amount", Convert.ToInt32(txtamount.Value));

                if (PayDates != "")
                    cmd.Parameters.AddWithValue("@PayDate", Convert.ToDateTime(PayDates));
                else
                    cmd.Parameters.AddWithValue("@PayDate", Convert.ToDateTime(""));

                cmd.Parameters.AddWithValue("@DeptName", Convert.ToString(ddlDeptId.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@SemesterName", Convert.ToString(ddlSemester.SelectedItem.Text));

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

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        string stdId = GridView1.SelectedRow.Cells[0].Text;
        //        string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        //        Connection = new SqlConnection(constr);
        //        Connection.Open();
        //        cmd = new SqlCommand("UPDATE FeesTbl SET StId = @StId,StName = @StName,StDept =@StDept ,Semester = @Semester,Amount = @Amount,PayDate = @PayDate ,DeptName = @DeptName,SemesterName = @SemesterName)", Connection);

        //        cmd.Parameters.AddWithValue("@StId", Convert.ToInt32(ddlStdId.SelectedValue));
        //        cmd.Parameters.AddWithValue("@StName", Convert.ToString(txtsname.Value));
        //        cmd.Parameters.AddWithValue("@StDept", Convert.ToInt32(ddlDeptId.SelectedValue));
        //        cmd.Parameters.AddWithValue("@Semester", Convert.ToString(ddlSemester.SelectedValue));
        //        cmd.Parameters.AddWithValue("@Amount", Convert.ToInt32(txtamount.Value));

        //        if (PayDates != "")
        //            cmd.Parameters.AddWithValue("@PayDate", Convert.ToDateTime(PayDates));
        //        else
        //            cmd.Parameters.AddWithValue("@PayDate", Convert.ToDateTime(""));

        //        cmd.Parameters.AddWithValue("@DeptName", Convert.ToString(ddlDeptId.SelectedItem.Text));
        //        cmd.Parameters.AddWithValue("@SemesterName", Convert.ToString(ddlSemester.SelectedItem.Text));
        //        cmd.Parameters.AddWithValue("@SKey", stdId);

        //        int result = cmd.ExecuteNonQuery();
        //        Connection.Close();
        //        BindGrid();

        //         if (result == 1)
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Fees Updated Successfully..!! ');", true);
        //            BindGrid();
        //        }
        //    }
        //    catch (Exception EX)
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + EX.Message + "');", true);
        //    }
        //}

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{

        //    string stdId = GridView1.SelectedRow.Cells[0].Text;

        //    try
        //    {
        //        string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        //        SqlConnection Connection = new SqlConnection(constr);
        //        Connection.Open();
        //        SqlCommand cmd = new SqlCommand("Delete from FeesTbl where StId=@StKey", Connection);
        //        cmd.Parameters.AddWithValue("@StKey", stdId);
        //        int result = cmd.ExecuteNonQuery();
        //        Connection.Close();
        //        BindGrid();
        //         if (result == 1)
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted Successfully..!! ');", true);
        //            BindGrid();
        //        }
        //    }
        //    catch (Exception EX)
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + EX.Message + "');", true);
        //    }
        //        }
    }

}