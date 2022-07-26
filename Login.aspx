<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="University_Management_System.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Styles/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style.css" s rel="stylesheet" type="text/css" />
    <script src="Scripts/js/bootstrap.js" type="text/javascript"></script>
    <script src="Scripts/js/bootstrap.min.js" type="text/javascript"></script>
</head>
<body>
    <div class="vh-100" style="background-color: #9A616D;">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col col-xl-10">
                    <div class="card" style="border-radius: 1rem;">
                        <div class="row g-0">
                            <div class="col-md-6 col-lg-5 d-none d-md-block">
                                <img src="Images/mit-wpu.jpeg" alt="login form" class="img1" style="border-radius: 1rem 0 0 1rem;" />
                            </div>
                            <div class="col-md-6 col-lg-7 d-flex align-items-center">
                                <div class="card-body p-4 p-lg-5 text-black">
                                    <form runat="server">
                                    <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">
                                        Sign into your account</h5>
                                    <div class="form-outline mb-4">
                                        <input type="text" id="txtEmail" runat="server" required class="form-control form-control-lg" />
                                        <label class="form-label" for="form2Example17">
                                            Email address</label>
                                    </div>
                                    <div class="form-outline mb-4">
                                        <input type="password" id="txtPwd" class="form-control form-control-lg" runat="server"
                                            required />
                                        <label class="form-label" for="form2Example27">
                                            Password</label>
                                    </div>
                                    <div class="pt-1 mb-4">
                                        <asp:Button ID="Button1" Text="Login" class="btn btn-dark btn-lg btn-block" runat="server"
                                            OnClick="btnLogin_Click" />
                                    </div>
                                    <a class="small text-muted" href="#!"></a>
                                    <p class="mb-5 pb-lg-2" style="color: #393f81;">
                                        <a href="#!" style="color: #393f81;"></a></p>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
