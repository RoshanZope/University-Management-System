<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="University_Management_System.Menu" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Menu</title>
    <link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css' />
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.0/animate.min.css' />
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css' />
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.4/css/tether.min.css' />
    <link rel="stylesheet" href="Styles/css/style.css" />
    <!-- Demo CSS -->
    <link rel="stylesheet" href="Styles/css/demo.css" />
    <style type="text/css">
        #wrapper.toggled #sidebar-wrapper
        {
            width: 258px;
        }
        .sidebar-nav
        {
            width: 258px;
        }
        .sidebar-nav li
        {
            line-height: 28px;
        }
        
    </style>
</head>
<body>
    <div id="wrapper" class="toggled">
        <div class="overlay" style="display: block;">
        </div>
        <!-- Sidebar -->
        <nav class="navbar navbar-inverse fixed-top navbar1" id="sidebar-wrapper" role="navigation">
     <ul class="nav sidebar-nav">
       <div class="sidebar-header">
       <div class="sidebar-brand">
         <a href="#">MIT-WPU</a>
         </div>
         </div>
        <li><a href="">Home</a></li>
        <li><a href="Student.aspx">Student</a></li>
        <li><a href="">Department</a></li>
        <li><a href="">Faculty</a></li>
        <li><a href="">Courses</a></li>
        <li><a href="">Fees</a></li>
        <li><a href="">Salary</a></li>
        <li><a href="">Campus</a></li>
        <li><a href="">logout</a></li>
      </ul>
  </nav>
        <div id="page-content-wrapper">
            <%--<button type="button" class="hamburger animated fadeInLeft is-closed" data-toggle="offcanvas">
                <span class="hamb-top"></span><span class="hamb-middle"></span><span class="hamb-bottom">
                </span>
            </button>--%>
            <div class="container">
                <div class="row">
                </div>
            </div>
        </div>
    </div>
    <script src='https://code.jquery.com/jquery-3.3.1.slim.min.js' type="text/javascript"></script>
    <script src='https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js'
        type="text/javascript"></script>
    <script src='https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js'
        type="text/javascript"></script>
    <script src='https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.4/js/tether.min.js'
        type="text/javascript"></script>
    <script src="Scripts/js/script.js" type="text/javascript"></script>
</body>
</html>
