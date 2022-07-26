<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs"
    Inherits="University_Management_System.Courses" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="py-5 text-center">
            <h2>
                MIT World Peace University</h2>
            <h4>
                Course Details</h4>
        </div>
        <div class="row">
            <div class="col-md-12">
                <form>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="CName">
                            Course Name</label>
                        <input type="text" class="form-control" id="txtCname" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="Credit Hours">
                            Credit Hours</label>
                        <input type="text" class="form-control" id="txtCH" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="dept">
                            Dept ID</label>
                        <asp:DropDownList ID="ddlDeptID" runat="server" AutoPostBack="true" class="custom-select d-block w-100"
                            OnSelectedIndexChanged="ddlDeptID_SelectedIndexChanged" required>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="DepartmentName">
                            Department Name
                        </label>
                        <input type="text" class="form-control" id="txtDeptName" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="factId">
                            Faculty ID</label>
                        <asp:DropDownList ID="ddlfactid" runat="server" AutoPostBack="true" class="custom-select d-block w-100"
                            OnSelectedIndexChanged="ddlfactid_SelectedIndexChanged" required>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="Fname">
                            Faculty Name
                        </label>
                        <input type="text" class="form-control" id="txtfname" runat="server" required />
                    </div>
                </div>
                <hr class="mb-4">
                <div class="row">
                    <div class="col-md-3 mb-3">
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnSave" Text="Add" runat="server" class="btn btn-primary btn-lg btn-block"
                            OnClick="btnSave_Click" />
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnUpdate" Text="Update" runat="server" class="btn btn-primary btn-lg btn-block"
                            OnClick="btnUpdate_Click" />
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnDelete" Text="Delete" runat="server" class="btn btn-primary btn-lg btn-block"
                            OnClick="btnDelete_Click" />
                    </div>
                </div>
                <br />
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                        RowStyle-CssClass="rows" PageSize="10" OnRowDataBound="GridView1_RowDataBound"
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="150px" DataField="Course_Id" HeaderText="Course_Id" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Course_Name" HeaderText="Course_Name" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Credit_Hrs" HeaderText="Credit_Hrs" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="DeptId" HeaderText="DeptId" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Department" HeaderText="Department" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Fac_Id" HeaderText="Fac_Id" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Fac_Name" HeaderText="Fac_Name" />
                        </Columns>
                    </asp:GridView>
                </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
