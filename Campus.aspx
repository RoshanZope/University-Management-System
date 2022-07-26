<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Campus.aspx.cs"
    Inherits="University_Management_System.Campus" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="py-5 text-center">
            <h2>
                MIT World Peace University</h2>
            <h4>
                Campus</h4>
        </div>
        <div class="row">
            <div class="col-md-12">
                <form>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="camp">
                            Campus Name</label>
                        <input type="text" class="form-control" id="txtcamp" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="city">
                            City</label>
                        <input type="text" class="form-control" id="txtcity" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="dname">
                            Director Name</label>
                        <input type="text" class="form-control" id="txtdname" runat="server" required />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 mb-4">
                        <label for="drank">
                            Director Rank
                        </label>
                        <input type="text" class="form-control" id="txtdrank" runat="server" required />
                    </div>
                    <div class="col-md-4 mb-4">
                        <label for="join_date">
                            Join Date</label>
                        <input type="date" id="txtjoin_date" class="form-control" name="join_date" required />
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
                        RowStyle-CssClass="rows" PageSize="10" OnRowDataBound="GridView1_RowDataBound1"
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="150px" DataField="Camp_Id" HeaderText="Camp_Id" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Name" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="City" HeaderText="City" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Director" HeaderText="Director" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Rank" HeaderText="Rank" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="Join_Date" HeaderText="Join_Date" />
                        </Columns>
                    </asp:GridView>
                </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
