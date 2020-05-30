<%@ Page Language="C#" AutoEventWireup="true" CodeFile="doc_registration_login.aspx.cs" Inherits="Doctor_doc_registration_login" %>

<!DOCTYPE html>

<html lang="en">

<head>
	<meta charset="utf-8" />
	<title>Color Admin | Login Page</title>
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
<script src="../assets/plugins/jquery-1.8.2/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function UserOrEmailAvailability() { //This function call on text change.             
            $.ajax({
                type: "POST",
                url: "doc_registration_login.aspx/CheckEmail", // this for calling the web method function in cs code.  
                data: '{useroremail: "' + $("#<%=email_id.ClientID%>")[0].value + '" }', // user name or email value  
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response);
                }
            });
        }

        // function OnSuccess  
        function OnSuccess(response) {
            var msg = $("#<%=lblStatus.ClientID%>")[0];
            switch (response.d) {
                case "1":
                    msg.style.display = "block";
                    msg.style.color = "red";
                    msg.innerHTML = "*Enter Email Id.";
                    $("#email_id").css("background-color", "red");
                    $("#email_id").css("color", "white");
                    $("#email_id").focus();
                    break;
                case "true":
                    msg.style.display = "block";
                    msg.style.color = "red";
                    msg.innerHTML = "User Name Or Email already exists.";
                    $("#email_id").css("background-color", "red");
                    $("#email_id").css("color", "white");
                    $("#email_id").focus();
                    break;
                case "false":
//                    msg.style.display = "block";
//                    msg.style.color = "green";
                    msg.innerHTML = "";
                    $("#email_id").css("background-color", "white");
                    $("#email_id").css("color", "black");
                  
                    break;
            }
        }  
  
    </script>
    

</head>
<body>
	<!-- begin #page-loader -->
	<div id="page-loader" class="fade in"><span class="spinner"></span></div>

    <div id="page-container" class="fade"  style="margin-top:20px">
	    <!-- begin login -->
        <div class="row" >
			    <!-- begin col-6 -->
                <div class="col-md-6 col-md-offset-3" align="center">
                     <div class="login-header">
                        <div class="brand" style="font-size: x-large">
                             <img src="../assets/img/logo.png" height="28" width="28"/> Book4Medico
                        </div>
                        
                    </div>
                </div>
			    <div class="col-md-6 col-md-offset-3">
			        <!-- begin panel -->
                    <div class="panel panel-inverse">
                        

                        <div class="panel-heading">
                            
                            <h4 class="panel-title">Register</h4>
                        </div>
                        <div class="panel-body">
                            <form id="Form1" runat="server">
                                <fieldset>
                                    <legend>Registration Form</legend>

                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Email address</label>
                                        <asp:TextBox ID="email_id" class="form-control" runat="server" 
                                            placeholder="Enter email" onblur="UserOrEmailAvailability()" 
                                            ></asp:TextBox>
                                       
                                            <div id="checkusernameoremail" runat="server">                             
                                                <asp:Label ID="lblStatus" runat="server"></asp:Label>  
                                            </div>
                                         <div>
                                            <span>
                                                <font color="red">
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Email Id" ControlToValidate="email_id" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Invalid Email" ControlToValidate="email_id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>

                                                </font>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputPassword1">Password</label>
                                        <asp:TextBox ID="doc_password" class="form-control" placeholder="Enter Password" runat="server"  TextMode="Password"></asp:TextBox>
                                        <div>
                                            <span>
                                                <font color="red">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Enter Password" ControlToValidate="doc_password" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Password must contain: Minimum 6 characters atleast 1 Alphabet and 1 Number." ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$" ForeColor="Red" ControlToValidate="doc_password"></asp:RegularExpressionValidator>
                                                </font> 
                                            </span>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="exampleInputPassword1">Re-Enter Password</label>
                                        <asp:TextBox ID="doc_password_re" class="form-control" placeholder="Re-Enter Password" runat="server"   TextMode="Password"></asp:TextBox>
                                         <div>
                                            <span>
                                                <font color="red">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                 ErrorMessage="*Enter Password" ControlToValidate="doc_password_re" 
                                                 Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                 ErrorMessage="Password Does Not Match." ControlToValidate="doc_password_re" 
                                                 ControlToCompare="doc_password" Display="Dynamic"></asp:CompareValidator>
                                                </font>
                                            </span>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="exampleInputPassword1">Mobile</label>
                                        <asp:TextBox ID="doc_mobile" class="form-control" placeholder="Enter Mobile Number" runat="server"></asp:TextBox>
                                         <div>
                                            <span>
                                                <font color="red">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Enter Mobile Number" ControlToValidate="doc_mobile" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Enter Valid Mobile Number." ControlToValidate="doc_mobile" ValidationExpression="[789][0-9]{9}" Display="Dynamic" ></asp:RegularExpressionValidator>
                                                
                                                </font>
                                            </span>
                                        </div>
                                    </div>
                       
                                    <asp:Button ID="submit" runat="server" class="btn btn-sm btn-primary m-r-5" 
                                        Text="Sign Up" onclick="submit_Click"/>
                                
                                    <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-sm btn-default" NavigateUrl="~/Doctor/doc_login.aspx">Cancel</asp:HyperLink>
                                </fieldset>
                            </form>
                        </div>
                    </div>
                    <!-- end panel -->
                </div>
                
            </div>
        <!-- end login -->
        
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

</html>

