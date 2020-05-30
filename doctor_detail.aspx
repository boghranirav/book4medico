<%@ Page Title="" Language="C#" MasterPageFile="~/user_side_nested_master.master" AutoEventWireup="true" CodeFile="doctor_detail.aspx.cs" Inherits="doctor_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script src="user_side_assets/js/jquery-1.11.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function toggleDiv(divId) {
        $("#" + divId).slideToggle();
    }
</script>
<style type="text/css">
.slidediv{
padding:20px;
color:#000;
border-bottom:5px solid #FFF;
display:none;
}
</style>

 <section id="productDetails" class="product-details">
				<div class="container">
					<div class="row narrow-content" style="border-left:1px solid #000;border-top:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000;margin-bottom:10px;">
						<br/>
                        <br/>
                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 clearfix">
							<div class="product-gallery vertical-pager">
							<asp:Image ID="profile_picture" runat="server" height="200" width="200"></asp:Image>
							</div>
						</div>
						<div class="product-cart product-details-narrow col-lg-9 col-md-9 col-sm-12 col-xs-12 clearfix">
							<div class="product-options_header clearfix wow fadeInUp" data-wow-delay="0.3s">
								<h3 class="font-additional font-weight-bold text-uppercase"><asp:Label ID="lbldocname" runat="server" Text="" ></asp:Label></h3>
							</div>
							<div class="product-options_body clearfix wow fadeInUp" data-wow-delay="0.3s">
								<h4 class="font-additional font-weight-bold text-uppercase"><asp:Label ID="lbldocdegree" runat="server"  Text=""></asp:Label></h4>
								<div class="product-options_desc font-main color-third">
                                <asp:Label ID="lblexperience1" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="lblspeciality" runat="server" Text=""></asp:Label>

                                 </div>
							</div>
                            <div class="product-options_body clearfix wow fadeInUp" data-wow-delay="0.3s" runat="server" id="comment_div">
								
							</div>
							
						</div>
                      
						   <div class="col-lg-12" runat="server" id="divaddress" style="margin-top:0.2cm;">
                           
							
					    	</div>
                      
                        <div class="col-lg-12  clearfix" runat="server" id="divservices">
							

						</div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 clearfix" id="divspe_edu_exp" runat="server" style="border-right:0.04cm solid #DCDCDC;">
                        
                        
                        </div>
                       
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 clearfix" runat="server" id="div_award_mem_reg" style="margin-bottom:15px;">
                        
                        
                        </div>
                       
					</div>
				</div>
			</section>
			
</asp:Content>

