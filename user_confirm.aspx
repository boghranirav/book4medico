<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_confirm.aspx.cs" Inherits="user_confirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    	<link rel="shortcut icon" type="image/x-icon" href="favicon.html" />

		<link href="user_side_assets/css/master.css" rel="stylesheet">
		<link href="user_side_assets/css/header5.css" rel="stylesheet">

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
                    <ul class="pull-left contact-list">
						<li>
							<span class="contact-list_label font-main font-weight-normal"><a href="index2.aspx"><font color="white" size="5">Book4medico</font></a></span>
						</li>
					
					</ul>
					<ul class="nav nav-pills navbar-right" style="margin-top:0.3cm">
						<li>
                            <span class="contact-list_label font-main font-weight-normal"><a href="Doctor/doc_login.aspx"><font color="white">Doctor Login</font></a></span>
						</li>						
                       
					</ul>
			
					</div>
				</div>
                
			</header>
           <div class="Row">
                   
					<form id="Form1"   runat="server" >
                            <div class="col-lg-4 col-lg-offset-1" style="padding-top:3cm">
                               <div class="form-group">
                                        <label>Enter OTP Send To Your Mobile Number:</label>
                                         <asp:TextBox ID="u_otp" CssClass="form-control" runat="server" Width="350px"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter OTP." ControlToValidate="u_otp" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                               </div>
                              
                               <div class="form-group">
                                 <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </div>
                               <div class="form-group">
                                   <asp:Button ID="submit" runat="server"  
                                       CssClass="btn btn-primary font-additional hvr-wobble-bottom"  Text="Login" onclick="submit_Click" 
                                       />
                                </div>
                             
                            </div>
                     </form>
        			
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
