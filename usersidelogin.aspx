<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usersidelogin.aspx.cs" Inherits="usersidelogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    	<link rel="shortcut icon" type="image/x-icon" href="favicon.html" />
        <link href="user_side_assets/css/master.css" rel="stylesheet">
		<link href="user_side_assets/css/header5.css" rel="stylesheet">

</head>

<body class="animated-css home-construction-v5" data-scrolling-animations="true">
    	<div class="sp-body">
			
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
                                        <label>Enter Your Mobile Number :</label>
                                         <asp:TextBox ID="u_mobile" CssClass="form-control" runat="server" Width="350px"></asp:TextBox>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Enter valid mobile no." ForeColor="Red" ValidationExpression="[789][0-9]{9}" ControlToValidate="u_mobile" Display="Dynamic"></asp:RegularExpressionValidator>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Mobile Number." ControlToValidate="u_mobile" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                               </div>
                              
                               <div class="form-group">
                                 <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </div>
                               <div class="form-group">
                                   <asp:Button ID="submit" runat="server"  
                                       CssClass="btn btn-primary font-additional hvr-wobble-bottom"  Text="Proceed" 
                                       onclick="submit_Click" />
                                </div>
                              <div class="form-group">
                               <a href="user_registrations.aspx">Create Account.</a>
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
