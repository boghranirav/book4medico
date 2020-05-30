<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_registrations.aspx.cs" Inherits="user_registrations" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
    	<link rel="shortcut icon" type="image/x-icon" href="favicon.html" />

		<link href="user_side_assets/css/master.css" rel="stylesheet">
		<link href="user_side_assets/css/header5.css" rel="stylesheet">
        <script src="assets/plugins/jquery-1.8.2/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function UserOrEmailAvailability() { //This function call on text change.             
            $.ajax({
                type: "POST",
                url: "user_registrations.aspx/CheckEmail", // this for calling the web method function in cs code.  
                data: '{useroremail: "' + $("#<%=u_mobile.ClientID%>")[0].value + '" }', // user name or email value  
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

                case "true":
                    msg.style.display = "block";
                    msg.style.color = "red";
                    msg.innerHTML = "Mobile Number already exists.";


                    $("#u_mobile").focus();
                    break;
                case "false":
                    //                    msg.style.display = "block";
                    //                    msg.style.color = "green";
                    msg.innerHTML = "";
                    $("#u_mobile").css("background-color", "white");
                    $("#u_mobile").css("color", "black");

                    break;
            }
        }  
  
    </script>
 
</head>

	<body class="animated-css home-construction-v5" data-scrolling-animations="true">
    	<div class="sp-body">
			<!-- Loader Landing Page -->
			<%--<div id="ip-container" class="ip-container">
				<div class="ip-header" >
					<div class="ip-loader">
						<div class="text-center">
							<div class="ip-logo">
								<a class="logo"></a>
							</div>
						</div>
						<svg class="ip-inner" width="60px" height="60px" viewBox="0 0 80 80">
							<path class="ip-loader-circlebg" d="M40,10C57.351,10,71,23.649,71,40.5S57.351,71,40.5,71 S10,57.351,10,40.5S23.649,10,39.3,10z"/>
							<path id="ip-loader-circle" class="ip-loader-circle" d="M40,10C57.351,10,71,23.649,71,40.5S57.351,71,40.5,71 S10,57.351,10,40.5S23.649,10,40.5,10z"/>
						</svg> 
					</div>
				</div>
			</div>--%>
			<!-- Loader end -->
			
			<header id="header">
				<div class="header-top">
					<div class="container">
					<ul class="nav nav-pills navbar-right" style="margin-top:0.3cm">
						<li>
                            <span class="contact-list_label font-main font-weight-normal"><a href=""><font color="white">Doctor Login</font></a></span>
						</li>						
                        <li>
                            <span class="contact-list_label font-main font-weight-normal"><a href=""><font color="white">User Login</font></a></span>
						</li>
					</ul>
			
					</div>
				</div>
                
			</header>

           <div class="Row">
                   
							<form id="Form1"   runat="server" >
                            <div class="col-lg-4 col-lg-offset-1" style="padding-top:3cm">
                            <h1>Registration</h1>
                             
                            <br/>
                                <div class="form-group">
                                    <label>Patient Name :</label>
                                       <asp:TextBox ID="pt_name" CssClass="form-control" runat="server" Width="350px" ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"  ErrorMessage="*Enter patient name" ForeColor="Red" ControlToValidate="pt_name"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Enter valid name" ForeColor="Red" Display="Dynamic" ValidationExpression="^([a-zA-Z ]){2,30}$" ControlToValidate="pt_name"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>Mobile No :</label>
                                       <asp:TextBox ID="u_mobile" CssClass="form-control" runat="server" Width="350px"  onblur="UserOrEmailAvailability()"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ErrorMessage="*Enter mobile no." ControlToValidate="u_mobile" ForeColor="Red"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Enter valid mobile no." ForeColor="Red" ValidationExpression="[789][0-9]{9}" ControlToValidate="u_mobile" Display="Dynamic"></asp:RegularExpressionValidator>
                                      <asp:Label ID="lblStatus" runat="server" style="color:Red;"></asp:Label>  

                                </div>
                                <div class="form-group">
                                    <label>Email :</label>
                                     <asp:TextBox ID="u_email" CssClass="form-control" runat="server" Width="350px" ></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Enter email-id"  ForeColor="Red" ControlToValidate="u_email" Display="Dynamic"></asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Enter Valid email-id" ForeColor="Red" Display="Dynamic" ControlToValidate="u_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                                
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                 </div>
                                <div class="form-group">
                                   <asp:Button ID="Submit" runat="server"  
                                        CssClass="btn btn-primary font-additional hvr-wobble-bottom"  Text="Sign up" 
                                        onclick="Submit_Click" />
                                </div>
                                
               <a href="usersidelogin.aspx"  >Already have account?Login.</a>
                             </div>
                              
                            </form>
                             <vr/>
        				</div>
                      
	 </div>
             

		<script src="user_side_assets/js/modernizr.custom.js"></script>
		<script src="user_side_assets/js/jquery.placeholder.min.js"></script>
		<script src="user_side_assets/js/smoothscroll.min.js"></script>
		<!-- Loader -->
		<script src="user_side_assets/plugins/loader/js/classie.js"></script>
		<script src="user_side_assets/plugins/loader/js/pathLoader.js"></script>
		<script src="user_side_assets/plugins/loader/js/main.js"></script>
		<script src="user_side_assets/js/classie.js"></script>
		<!--Owl Carousel-->
	    <script src="user_side_assets/plugins/owl-carousel/owl.carousel.min.js"></script>
	    <!-- bxSlider -->
	    <script src="user_side_assets/plugins/bxslider/jquery.bxslider.min.js"></script>
		<!--Switcher-->
		<script src="user_side_assets/plugins/switcher/js/bootstrap-select.js"></script> 
		<script src="user_side_assets/plugins/switcher/js/evol.colorpicker.min.js" type="text/javascript"></script> 
		<script src="user_side_assets/plugins/switcher/js/dmss.js"></script>
	    <!-- SCRIPTS -->
	    <script type="text/javascript" src="user_side_assets/plugins/isotope/jquery.isotope.min.js"></script> 

		<!--THEME--> 
		<script src="user_side_assets/js/wow.min.js"></script>
		<script src="user_side_assets/js/cssua.min.js"></script>
        <script src="user_side_assets/js/theme.js"></script> 
            
</body>
</html>
