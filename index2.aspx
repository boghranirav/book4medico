<%@ Page Title="" Language="C#" MasterPageFile="~/user_side_nested_master.master" AutoEventWireup="true" CodeFile="index2.aspx.cs" Inherits="index2" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    
    <section id="slider" class="slider-container slider-top-pagination">
				<div class="container">
					<h2 class="title font-additional font-weight-bold text-uppercase wow zoomIn" data-wow-delay="0.3s">DOCTORS</h2>
					<div class="starSeparatorBox clearfix">
						<div class="starSeparator wow zoomIn" data-wow-delay="0.3s">
							<span aria-hidden="true" class="icon-star"></span>
						</div>
						<div   runat="server" id="divslider" class="enable-owl-carousel owl-product-slider owl-top-pagination owl-carousel owl-theme wow fadeInUp" data-wow-delay="0.7s" data-navigation="true" data-pagination="false" data-single-item="false" data-auto-play="false" data-transition-style="false" data-main-text-animation="false" data-min600="2" data-min800="3" data-min1200="4">
				<%--			<div class="item">
								<div class="product-item hvr-underline-from-center">
									<div class="product-item_body product-border">
										<img alt="Product" src="user_side_assets/image/Dentist.jpg" class="product-item_image" width="200" height="200">
										
										<ul class="product-item_info transition">
										</ul>
									</div>
									<a class="product-item_footer" href="product-details.html">
										<div class="product-item_title font-additional font-weight-bold text-center text-uppercase">WOMEN CAP</div>
									</a>
								</div>
							</div>
                            	<div class="item">
								<div class="product-item hvr-underline-from-center">
									<div class="product-item_body product-border">
										<img alt="Product" src="user_side_assets/image/Ophthalmologist.jpg" class="product-item_image" width="200" height="200">
										
										<ul class="product-item_info transition">
										</ul>
									</div>
									<a class="product-item_footer" href="product-details.html">
										<div class="product-item_title font-additional font-weight-bold text-center text-uppercase">WOMEN CAP</div>
									</a>
								</div>
							</div>--%>
						</div>
					</div>
				</div>
			</section>

</asp:Content>

