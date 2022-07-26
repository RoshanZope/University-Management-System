<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Student.aspx.cs"
    Inherits="University_Management_System.Student" EnableEventValidation="false" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="py-5 text-center">
            <h2>
                MIT World Peace University</h2>
            <h4>
                Student Details</h4>
        </div>
        <div class="row">
            <div class="col-md-12">
                <form>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="exampleInputEmail1">
                            Student Name</label>
                        <input type="text" runat="server" class="form-control" id="txtstdName" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="exampleInputEmail1">
                            Email address</label>
                        <input type="text" class="form-control" runat="server" id="txtMail" required />
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
                        <input type="text" class="form-control" runat="server" id="txtaddress" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="country">
                            Country</label>
                        <asp:DropDownList ID="ddlcountry" runat="server" class="custom-select d-block w-100"
                            required>
                            <asp:ListItem Value="0">Choose...</asp:ListItem>
                            <asp:ListItem Value="1">India</asp:ListItem>
                            <asp:ListItem Value="2">United States</asp:ListItem>
                            <asp:ListItem Value="3">United Kingdom</asp:ListItem>
                            <asp:ListItem Value="4">Russia</asp:ListItem>
                            <asp:ListItem Value="5">Scotland</asp:ListItem>

                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="state">
                            State</label>
                        <asp:DropDownList ID="ddlstate" runat="server" class="custom-select d-block w-100"
                            required>
                            <asp:ListItem Value="0">Choose...</asp:ListItem>
                            <asp:ListItem Value="1">Maharashtra</asp:ListItem>
                            <asp:ListItem Value="2">Arunachal Pradesh</asp:ListItem>
                            <asp:ListItem Value="3">Madhya Pradesh</asp:ListItem>
                            <asp:ListItem Value="4">Tamil Nadu</asp:ListItem>
                            <asp:ListItem Value="5">Telangana</asp:ListItem>
                            <asp:ListItem Value="6">Gujrat</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="zip">
                            Zip</label>
                        <input type="text" class="form-control" id="txtzip" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="dept">
                            Department</label>
                        <asp:DropDownList ID="ddlDeptID" runat="server" AutoPostBack="true" class="custom-select d-block w-100"
                            OnSelectedIndexChanged="ddlDeptID_SelectedIndexChanged" required>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 mb-4" style="display: none;">
                        <label for="DeptName">
                            Dept Name
                        </label>
                        <input type="text" class="form-control" id="txtDeptName" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="dept">
                            Semester</label>
                        <asp:DropDownList ID="ddlSemester" runat="server" class="custom-select d-block w-100"
                            required>
                            <asp:ListItem Value="0">Choose...</asp:ListItem>
                            <asp:ListItem Value="1">Semester 1</asp:ListItem>
                            <asp:ListItem Value="2">Semester 2</asp:ListItem>
                            <asp:ListItem Value="3">Semester 3</asp:ListItem>
                            <asp:ListItem Value="4">Semester 4</asp:ListItem>
                            <asp:ListItem Value="5">Semester 5</asp:ListItem>
                            <asp:ListItem Value="6">Semester 6</asp:ListItem>
                            <asp:ListItem Value="5">Semester 7</asp:ListItem>
                            <asp:ListItem Value="6">Semester 8</asp:ListItem>

                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="DeptName">
                            Mobile No.
                        </label>
                        <input type="text" class="form-control" id="txtMobNo" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="start">
                            Date of Birth:</label>
                        <input type="date" id="txtDOB" class="form-control" name="DOBDate" required />
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
                <div class="row">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                        RowStyle-CssClass="rows" PageSize="10" OnRowDataBound="GridView1_RowDataBound"
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="150px" DataField="StId" HeaderText=" ID" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Student Name" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Email" HeaderText="Email Address" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="GenderText" HeaderText="Gender" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Gender" HeaderText="" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Address" HeaderText="Address" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="CountryName" HeaderText="Country" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Country" HeaderText="" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="StateName" HeaderText="State" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="State" HeaderText="" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="ZIP" HeaderText="Postal Code" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="DeptId" HeaderText="DeptId" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Department" HeaderText="Department" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="SemesterName" HeaderText="Semester" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Semester" HeaderText="" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Phone" HeaderText="Phone" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="DOB" HeaderText="" />
                        </Columns>
                    </asp:GridView>
                </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
