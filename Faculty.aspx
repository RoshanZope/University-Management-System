<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Faculty.aspx.cs"
    Inherits="University_Management_System.Faculty" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="py-5 text-center">
            <h2>
                MIT World Peace University</h2>
            <h4>
                Faculty Details</h4>
        </div>
        <div class="row">
            <div class="col-md-12">
                <form>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="FName">
                            Faculty Name</label>
                        <input type="text" class="form-control" id="txtFname" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="exampleInputEmail1">
                            Email address</label>
                        <input type="text" class="form-control" id="txtMail" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="gender">
                            Gender</label>
                        <asp:DropDownList ID="ddlGender" runat="server" class="custom-select d-block w-100"
                            required>
                            <asp:ListItem Value="0">Choose...</asp:ListItem>
                            <asp:ListItem Value="1">Male</asp:ListItem>
                            <asp:ListItem Value="2">Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="exampleInputPassword1">
                            Address
                        </label>
                        <input type="text" class="form-control" id="txtaddress" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="dept">
                            Dept ID</label>
                        <asp:DropDownList ID="ddlDeptID" runat="server" AutoPostBack="true" class="custom-select d-block w-100"
                            OnSelectedIndexChanged="ddlDeptID_SelectedIndexChanged" required>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="DeptName">
                            Dept Name
                        </label>
                        <input type="text" class="form-control" id="txtDeptName" runat="server" required />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="dept">
                            Qualification</label>
                        <input type="text" class="form-control" id="txtQual" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="Salary">
                            Salary
                        </label>
                        <input type="text" class="form-control" id="txtsalary" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="Exp">
                            Experience
                        </label>
                        <input type="text" class="form-control" id="txtExp" runat="server" required />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="start">
                            Date of Birth:</label>
                        <input type="date" id="txtDOB" class="form-control" name="DOBDate" />
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
                            <asp:BoundField ItemStyle-Width="150px" DataField="F_Id" HeaderText="ID" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Name" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Email" HeaderText="Email Address" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Gender" HeaderText="Gender" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Address" HeaderText="Address" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="DeptId" HeaderText="DeptID" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Department" HeaderText="Department" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Qualification" HeaderText="Qualification" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Salary" HeaderText="Salary" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Experience" HeaderText="Experience" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="DOB" HeaderText="DOB" />
                        </Columns>
                    </asp:GridView>
                </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
