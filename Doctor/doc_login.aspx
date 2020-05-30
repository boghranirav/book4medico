<%@ Page Language="C#" AutoEventWireup="true" CodeFile="doc_login.aspx.cs" Inherits="Doctor_doc_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
<!--<![endif]-->

<!-- Mirrored from seantheme.com/color-admin-v1.3/login.html by HTTrack Website Copier/3.x [XR&CO'2014], Sun, 02 Nov 2014 09:12:01 GMT -->
<head>
	<meta charset="utf-8" />
	<title>Book4Medico | Login Page</title>
	<meta content="width=device-width, initial-scale=1.0" name="viewport" />
	<meta content="" name="description" />
	<meta content="" name="author" />
	
	<!-- ================== BEGIN BASE CSS STYLE ================== -->
	<link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet">
	<link href="../assets/plugins/jquery-ui-1.10.4/themes/base/minified/jquery-ui.min.css" rel="stylesheet" />
	<link href="../assets/plugins/bootstrap-3.2.0/css/bootstrap.min.css" rel="stylesheet" />
	<link href="../assets/plugins/font-awesome-4.2.0/css/font-awesome.min.css" rel="stylesheet" />
	<link href="../assets/css/animate.min.css" rel="stylesheet" />
	<link href="../assets/css/style.min.css" rel="stylesheet" />
	<link href="../assets/css/style-responsive.min.css" rel="stylesheet" />
	<link href="../assets/css/theme/default.css" rel="stylesheet" id="theme" />
	<!-- ================== END BASE CSS STYLE ================== -->
</head>
<body>
	<!-- begin #page-loader -->
	<div id="page-loader" class="fade in"><span class="spinner"></span></div>
	<!-- end #page-loader -->
	
	<!-- begin #page-container -->
	<div id="page-container" class="fade">
	    <!-- begin login -->
        <div class="login bg-black animated fadeInDown">
            <!-- begin brand -->
            <div class="login-header">
                <div class="brand">
                    <img src="../assets/img/logo.png" height="28" width="28"/>
                    Book4Medico
                    <small>Doctor Side Login Form</small>
                </div>
                <div class="icon">
                    <i class="fa fa-sign-in"></i>
                </div>
            </div>
            <!-- end brand -->
            <div class="login-content">
                <form id="Form1"   class="margin-bottom-0" runat="server">
                
                    <div class="form-group m-b-20">
                        <asp:TextBox ID="user_id" runat="server" CssClass="form-control input-lg"  placeholder="Email Address"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Enter Email Id." ControlToValidate="user_id" ForeColor="White" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group m-b-20">
                         <asp:TextBox ID="user_password" CssClass="form-control input-lg" 
                             placeholder="Password" runat="server" ontextchanged="user_password_TextChanged"  TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Password." ControlToValidate="user_password" ForeColor="White"  Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                     <div class="form-group m-b-20">
                         <asp:Label ID="Label1" runat="server" Text="" ForeColor="White"></asp:Label>
                    </div>
                    <div class="login-buttons">
                        <asp:Button ID="submit" runat="server" Text="Sign me in" 
                            CssClass="btn btn-success btn-block btn-lg" onclick="submit_Click" />
                    </div>
                    
                    <br />

                    <div class="login-buttons">
                        <asp:HyperLink ID="register" runat="server" CssClass="btn btn-success btn-block btn-lg" NavigateUrl="~/Doctor/doc_registration_login.aspx">Register As Doctor</asp:HyperLink>
                    </div>
                </form>
            </div>
        </div>
        
	</div>
	<!-- end page container -->
	
	<!-- ================== BEGIN BASE JS ================== -->
	<script src="../assets/plugins/jquery-1.8.2/jquery-1.8.2.min.js"></script>
	<script src="../assets/plugins/jquery-ui-1.10.4/ui/minified/jquery-ui.min.js"></script>
	<script src="../assets/plugins/bootstrap-3.2.0/js/bootstrap.min.js"></script>
	<!--[if lt IE 9]>
		<script src="assets/crossbrowserjs/html5shiv.js"></script>
		<script src="assets/crossbrowserjs/respond.min.js"></script>
		<script src="assets/crossbrowserjs/excanvas.min.js"></script>
	<![endif]-->
	<script src="../assets/plugins/slimscroll/jquery.slimscroll.min.js"></script>
	<script src="../assets/plugins/jquery-cookie/jquery.cookie.js"></script>
	<!-- ================== END BASE JS ================== -->
	
	<!-- ================== BEGIN PAGE LEVEL JS ================== -->
	<script src="../assets/js/apps.min.js"></script>
	<!-- ================== END PAGE LEVEL JS ================== -->
	<script>
	    $(document).ready(function () {
	        App.init();
	    });
	</script>
	<script>
	    (function (i, s, o, g, r, a, m) {
	        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
	            (i[r].q = i[r].q || []).push(arguments)
	        }, i[r].l = 1 * new Date(); a = s.createElement(o),
      m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
	    })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

	    ga('create', 'UA-53034621-1', 'auto');
	    ga('send', 'pageview');
    
    </script>
</body>

<!-- Mirrored from seantheme.com/color-admin-v1.3/login.html by HTTrack Website Copier/3.x [XR&CO'2014], Sun, 02 Nov 2014 09:12:01 GMT -->
</html>