<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="salary.aspx.cs"
    Inherits="University_Management_System.salary" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="py-5 text-center">
            <h2>
                MIT World Peace University</h2>
            <h4>
                Staff Salary</h4>
        </div>
        <div class="row">
            <div class="col-md-12">
                <form>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="fid">
                            Faculty ID</label>
                        <asp:DropDownList ID="ddlfactid" runat="server" AutoPostBack="true" class="custom-select d-block w-100"
                            OnSelectedIndexChanged="ddlfactid_SelectedIndexChanged" required>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="fname">
                            Faculty Name</label>
                        <input type="text" class="form-control" id="txtfname" runat="server" />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="amount">
                            Amount</label>
                        <input type="text" class="form-control" id="amount" runat="server" required />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="Sid">
                            Department ID</label>
                        <asp:DropDownList ID="ddlDeptId" runat="server" AutoPostBack="true" class="custom-select d-block w-100"
                            required OnSelectedIndexChanged="ddlDeptId_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="Department">
                            Department
                        </label>
                        <input type="text" class="form-control" id="txtdepartment" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="paydates">
                            Pay Date</label>
                        <input type="date" id="paydates" class="form-control" name="PayDate" required />
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
                </div>
                <br />
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                        RowStyle-CssClass="rows" PageSize="10" OnRowDataBound="GridView1_RowDataBound"
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="150px" DataField="salary_id" HeaderText="salary_id" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="F_Id" HeaderText="F_Id" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="F_Name" HeaderText="F_Name" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Salary" HeaderText="Salary" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Department" HeaderText="Department" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="PayDate" HeaderText="PayDate" />
                        </Columns>
                    </asp:GridView>
                </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
