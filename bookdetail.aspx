<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bookdetail.aspx.cs" Inherits="bookdetail" %>

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
							<span class="contact-list_label font-main font-weight-normal"><a href="index2.aspx"><img src="user_side_assets/media/logo/logo-orange.png" /></a></span>
						</li>
						
                        					
                        
					</ul>
                    
					<ul class="nav nav-pills navbar-right" style="margin-top:0.3cm">
						<%--<li>
                            <span class="contact-list_label font-main font-weight-normal"><a href=""><font color="white">Doctor Login</font></a></span>
						</li>						
                        <li>
                            <span class="contact-list_label font-main font-weight-normal"><a href=""><font color="white">User Login</font></a></span>
						</li>--%>
					</ul>
			
					</div>
				</div>
                
			</header>

           <div class="Row">
                <div >
                    		<form id="Form1"   runat="server" >
                            <div class="col-lg-4 col-lg-offset-1" style="padding-top:3cm">
                            <h2>Appointment Details</h2>
                            <br/>
                                <div class="form-group">
                                    <label>Patient Name :</label>
                                       <asp:TextBox ID="pt_name" CssClass="form-control" runat="server" Width="350px" ReadOnly="true" ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Email :</label>
                                     <asp:TextBox ID="u_email" CssClass="form-control" runat="server" Width="350px"  ReadOnly="true"></asp:TextBox>
                                      <asp:Label ID="lblStatus" runat="server" style="color:Red;"></asp:Label>  
                                </div>
                                <div class="form-group">
                                    <label>Reason For Visit :</label>
                                       <asp:TextBox ID="rsn_fr_visit" CssClass="form-control" runat="server" Width="350px"  ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Mobile No :</label>
                                       <asp:TextBox ID="u_mobile" CssClass="form-control" runat="server" Width="350px"  ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                   <asp:Button ID="done" runat="server"  
                                        CssClass="btn btn-primary font-additional hvr-wobble-bottom"  Text="Done" 
                                        onclick="done_Click" />
                                   <asp:Button ID="Button1" runat="server" Text="Cancel" onclick="Button1_Click" CssClass="btn btn-primary font-additional hvr-wobble-bottom"/>
                                </div>
                             </div>
                              <div class="col-lg-6" style="padding-top:3cm;">
                                    <div class="col-lg-12" style="border-left:0.1cm solid #DCDCDC">
                                        <div class="col-lg-2" style="margin-bottom:10px;">
					    	                <asp:Image ID="doc_profile_picture" runat="server" height="140" width="120"></asp:Image>
						                </div>
						                <div class="col-lg-10" style="margin-bottom:10px;">
                                             <div class="col-lg-9 col-lg-offset-1">
                                              <label>Name : </label><asp:Label ID="lblname" runat="server" Text=""></asp:Label><br/>
                                              <label>Speciality : </label> <asp:Label ID="lblspeciality" runat="server" Text=""></asp:Label><br /><br />
                                              <label>Clinc Address:</label><asp:Label ID="lbladdress" runat="server" Text=""></asp:Label><br /><br />							
                                              <br />
						                     </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12" style="border-left:0.1cm solid #DCDCDC">
                                        &nbsp;&nbsp;&nbsp;
                                       <label>Fees : </label><asp:Label ID="lblfees" runat="server" Text=""></asp:Label><br /><br />
                                       &nbsp;&nbsp;&nbsp;
                                      <label> Appointment Date : </label><asp:Label ID="lbldate" runat="server" Text=""></asp:Label><br/><br />
                                      &nbsp;&nbsp;&nbsp;
                                      <label> Preferred Time : </label><asp:Label ID="lbltime" runat="server" Text=""></asp:Label><br/><br />
                                    </div>
                                    
                              </div>
                            </form>
        		</div>

                
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
