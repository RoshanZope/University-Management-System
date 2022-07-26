<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="University_Management_System.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="container">
        <h2>
            MIT World Peace University
        </h2>
        <h3>
            <div class="col-md-12">
                <div class="row">
                    <br>
                    <div class="col-md-8">
                    </div>
                    <div class="col-md-4">
                        <div class="card bg-primary text-white">
                            <div class="card-body">
                                Statistics</div>
                            <div class="col-md-1">
                                <img src="Images/Std.png" alt="Student" class="img1" style="border-radius: 1rem 0 0 1rem;" />
                            </div>
                            <div class="col-md-6">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br>
            <div class="card bg-success text-white">
                <div class="card-body">
                    Success card</div>
            </div>
            <br>
            <div class="card bg-info text-white">
                <div class="card-body">
                    Info card</div>
            </div>
            <br>
            <div class="card bg-warning text-white">
                <div class="card-body">
                    Warning card</div>
            </div>
            <br>
            <div class="card bg-danger text-white">
                <div class="card-body">
                    Danger card</div>
            </div>
            <br>
            <div class="card bg-secondary text-white">
                <div class="card-body">
                    Secondary card</div>
            </div>
            <br>
            <div class="card bg-dark text-white">
                <div class="card-body">
                    Dark card</div>
            </div>
            <br>
            <div class="card bg-light text-dark">
                <div class="card-body">
                    Light card</div>
            </div>
        </h3>
    </div>--%>
    <section class="wrapper">
    <div class="container-fostrap">
        <div class="content">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-3">
                        <div class="card">
                            <a class="img-card">
                            <img src="Images/st.png" />
                          </a>
                            <div class="card-content">
                                <h4 class="card-title">
                                <center><a>Students</a></center>
                                </h4>
                                <center>
                                <p class="" style="font:22px bold Arial;">
                                    <label   for="camp" id="lblStd" runat="server"></label>
                                </p>
                                </center>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-3">
                        <div class="card">
                            <a class="img-card">
                            <img src="Images/Depts.jpg"/>
                          </a>
                            <div class="card-content">
                                <h4 class="card-title">
                                <center><a>Departments</a></center>
                                    
                                </h4>
                                <center><p class="" style="font:22px bold Arial;">
                                    <label for="camp" id="lblDept" runat="server"></label>
                                </p></center>
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-3">
                        <div class="card">
                            <a class="img-card">
                            <img src="Images/campus.jpg" />
                          </a>
                          <%--<hr class="col-xs-12 col-sm-12">--%>
                            <div class="card-content">
                                <h4 class="card-title">
                                <center><a>Campuses</a></center>
                                    
                                </h4>
                                <center><p class="" style="font:22px bold Arial;">
                                    <label for="camp" id="lblCamp" runat="server"></label>
                                </p></center>
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-3">
                        <div class="card">
                            <a class="img-card">
                            <img src="Images/facultyy.jpg" />
                          </a>
                            <div class="card-content">
                            <center><h4 class="card-title">
                                    <a>Facultiess</a>
                                </h4>
                                <p class="" style="font:22px bold Arial;">
                                    <label for="camp" id="lblfact" runat="server"></label>
                                </p></center>
                                
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-2">
                    </div>
                    <div class="col-xs-12 col-sm-3">
                        <div class="card">
                            <a class="img-card">
                            <img src="Images/fina.png" />
                          </a>
                            <div class="card-content">
                            <center><h4 class="card-title">
                                    <a>Finances</a>
                                </h4>
                                <p class="" style="font:22px bold Arial;">
                                    <label for="camp" id="lblFinc" runat="server"></label>
                                </p></center>
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-2">
                    </div>
                    <div class="col-xs-12 col-sm-3">
                        <div class="card">
                            <a class="img-card">
                            <img src="Images/salary.jpg" />
                          </a>
                            <div class="card-content">
                            <center><h4 class="card-title">
                                    <a>Salaries</a>
                                </h4>
                                <p class="" style="font:22px bold Arial;">
                                    <label for="camp" id="lblSal" runat="server"></label>
                                </p></center>
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-2">
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
</asp:Content>
