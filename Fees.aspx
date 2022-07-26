<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Fees.aspx.cs" Inherits="University_Management_System.Fees" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="py-5 text-center">
            <h2>
                MIT World Peace University</h2>
            <h4>
                Fees Details</h4>
        </div>
        <div class="row">
            <div class="col-md-12">
                <form>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="Sid">
                            Student Name</label>
                        <asp:DropDownList ID="ddlStdId" runat="server" AutoPostBack="true" class="custom-select d-block w-100"
                            required OnSelectedIndexChanged="ddlStdId_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 mb-4" style="display: none;">
                        <label for="sname">
                            Student Name</label>
                        <input type="text" class="form-control" id="txtsname" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="amount">
                            Amount</label>
                        <input type="text" class="form-control" id="txtamount" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="Sid">
                            Department</label>
                        <asp:DropDownList ID="ddlDeptId" runat="server" AutoPostBack="true" class="custom-select d-block w-100"
                            required OnSelectedIndexChanged="ddlDeptId_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 mb-4" style="display: none;">
                        <label for="Department">
                            Department
                        </label>
                        <input type="text" class="form-control" id="txtdepartment" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="sem">
                            Semester</label>
                        <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" class="custom-select d-block w-100"
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
                    <div class="col-md-4 mb-4">
                        <label for="start">
                            Pay Date</label>
                        <input type="date" id="txtDOB" class="form-control" name="PayDate" />
                    </div>
                </div>
                <hr class="mb-4">
                <div class="row">
                    <div class="col-md-4 mb-3">
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnSave" Text="Pay" runat="server" class="btn btn-primary btn-lg btn-block"
                            OnClick="btnSave_Click" />
                    </div>
                    <%-- <div class="col-md-2">
                        <asp:Button ID="btnUpdate" Text="Update" runat="server" class="btn btn-primary btn-lg btn-block"
                            OnClick="btnUpdate_Click" />
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnDelete" Text="Delete" runat="server" class="btn btn-primary btn-lg btn-block"
                            OnClick="btnDelete_Click" />
                    </div>--%>
                </div>
                <br />
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                        RowStyle-CssClass="rows" PageSize="10" OnRowDataBound="GridView1_RowDataBound"
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="150px" DataField="Fee_id" HeaderText="Id" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="StId" HeaderText="Student Id" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="StName" HeaderText="Student Name" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Amount" HeaderText="Amount" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="StDept" HeaderText="Dept Id" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="DeptName" HeaderText="Department" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Semester" HeaderText="Semester" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="SemesterName" HeaderText="Semester" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="PayDate" HeaderText="Pay Date" />
                        </Columns>
                    </asp:GridView>
                </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
