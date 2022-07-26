<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs"
    Inherits="University_Management_System.Department" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="py-5 text-center">
            <h2>
                MIT World Peace University</h2>
            <h4>
            Department</h4s>
        </div>
        <div class="row">
            <div class="col-md-12">
                <form>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="Department">
                            Department</label>
                        <input type="text" class="form-control" id="txtdept" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="Intake">
                            Intake</label>
                        <input type="text" class="form-control" id="txtintake" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="Feesperyear">
                            Fees Per Year</label>
                        <input type="text" class="form-control" id="txtFPY" runat="server" required />
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
                        <asp:Button ID="btnDelete" Text="Delete" runat="server" 
                            class="btn btn-primary btn-lg btn-block" onclick="btnDelete_Click" />
                    </div>
                </div>
                <br />
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                        RowStyle-CssClass="rows" PageSize="10" OnRowDataBound="GridView1_RowDataBound"
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="150px" DataField="DeptId" HeaderText="ID" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Name" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Intake" HeaderText="Intake" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Fees" HeaderText="Fees" />
                        </Columns>
                    </asp:GridView>
                </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
