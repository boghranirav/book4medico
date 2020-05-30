<%@ Page Title="" Language="C#" MasterPageFile="~/user_side_nested_master.master" AutoEventWireup="true" CodeFile="user_doctor_disp.aspx.cs" Inherits="user_doctor_disp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section id="pageContent" class="page-content category-type_list">
				<div class="container">
					<div class="row">
						<div class="sidebar col-lg-3 col-md-3 col-sm-3 col-xs-12 clearfix">

                            
							<h3 class="sidebar-title font-additional font-weight-bold text-uppercase customColor wow fadeInUp" data-wow-delay="0.3s">Location</h3>
							<ul class="categories-tree wow fadeInUp" data-wow-delay="0.3s">
								<asp:Panel ID="select_catagory" runat="server">
                                
                                </asp:Panel>
                                <asp:TextBox ID="test" runat="server" Visible="false"></asp:TextBox>
							</ul>
							<h3 class="sidebar-title font-additional font-weight-bold text-uppercase customColor wow fadeInUp" data-wow-delay="0.3s">Consultation Fee</h3>
							<div class="sidebar-slider sidebar-slider_btm_padding wow fadeInUp" data-wow-delay="0.3s">
								<div class="slider-range" data-min="0" data-max="1000" data-range="true" data-value-container-id="priceAmount" id="slider_div" runat="server"></div>
								<div class="filter-container">
									<div class="slider-range-value pull-left">
										<label class="font-main font-weight-normal" for="priceAmount" >Price:</label>
										<input class="font-weight-normal rupees-symbol" type="text" id="priceAmount" readonly >
									   

                                        
									</div>
                                    <%--<asp:TextBox ID="test_slider" CssClass="test_slide" runat="server"></asp:TextBox>--%>
                                    <input type="hidden" id="test_slider" runat="server" class="test_slide" />
                                        <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" CssClass="btn button-border font-additional font-weight-bold hvr-rectangle-out hover-focus-bg hover-focus-border before-bg pull-right"></asp:Button>
								</div>
							</div>

                            <%--<h3 class="sidebar-title font-additional font-weight-bold text-uppercase customColor wow fadeInUp" data-wow-delay="0.3s">Availability</h3>
							<ul class="categories-tree wow fadeInUp" data-wow-delay="0.3s">
                                <asp:Panel ID="Panel1" runat="server">
								<li>
									<asp:CheckBox ID="day_any" runat="server" 
                                        CssClass="font-additional font-weight-normal hover-focus-color color-third text-uppercase" 
                                        oncheckedchanged="day_CheckedChanged" AutoPostBack="True"/>&nbsp;Any
								</li>
                                <li>
									<span class="pull-left">
                                    <asp:CheckBox ID="Monday" runat="server" 
                                        CssClass="font-additional font-weight-normal hover-focus-color color-third text-uppercase" 
                                        oncheckedchanged="day_CheckedChanged" AutoPostBack="True"/>&nbsp;Monday</span>	
								</li>
								<li>
									<span class="pull-left">
                                    <asp:CheckBox ID="Tuesday" runat="server" 
                                        CssClass="font-additional font-weight-normal hover-focus-color color-third text-uppercase" 
                                        oncheckedchanged="day_CheckedChanged" AutoPostBack="True" />&nbsp;Tuesday</span>	
								</li>
                                <li>
									<span class="pull-left">
                                    <asp:CheckBox ID="Wednesday" runat="server" 
                                        CssClass="font-additional font-weight-normal hover-focus-color color-third text-uppercase" 
                                        oncheckedchanged="day_CheckedChanged" AutoPostBack="True"/>&nbsp;Wednesday</span>	
								</li>
                                <li>
									<span class="pull-left">
                                    <asp:CheckBox ID="Thrusday" runat="server" 
                                        CssClass="font-additional font-weight-normal hover-focus-color color-third text-uppercase" 
                                        oncheckedchanged="day_CheckedChanged" AutoPostBack="True"/>&nbsp;Thursday</span>	
								</li>
                                <li>
									<span class="pull-left">
                                    <asp:CheckBox ID="Friday" runat="server" 
                                        CssClass="font-additional font-weight-normal hover-focus-color color-third text-uppercase" 
                                        oncheckedchanged="day_CheckedChanged" AutoPostBack="True"/>&nbsp;Friday</span>	
								</li>
                                <li>    
									<span class="pull-left">
                                    <asp:CheckBox ID="Saturday" runat="server" 
                                        CssClass="font-additional font-weight-normal hover-focus-color color-third text-uppercase" 
                                        oncheckedchanged="day_CheckedChanged" AutoPostBack="True"/>&nbsp;Saturday</span>	
								</li>
                                <li>
									<span class="pull-left">
                                    <asp:CheckBox ID="Sunday" runat="server" 
                                        CssClass="font-additional font-weight-normal hover-focus-color color-third text-uppercase" 
                                        oncheckedchanged="day_CheckedChanged" AutoPostBack="True"/>&nbsp;Sunday</span>	
								</li>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </asp:Panel>
							</ul>
                            --%>
							
						
						</div>
						<div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 clearfix">
							<div class="content-box">
								
								<div class="products-cat clearfix">
									<ul class="products-list">
										<li class="wow fadeInUp" data-wow-delay="0.3s" runat="server" id="display_doctor_info">
											<%--<div class="product-list_item row">
												<div class="product-list_item_img col-lg-3 col-md-3 col-sm-3 col-xs-12 clearfix">
													<a href="product-details.html">
														<asp:Image ID="Image1" runat="server" CssClass="product-list_item_img hvr-grow-rotate" AlternateText="Dr. Profile Picture"></asp:Image>
													</a>
												</div>
												<div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 clearfix">
													<div class="product-list-info">
														<div class="product-list_item_title">
															<h3 class="font-additional font-weight-bold text-uppercase">MEN POLO SHIRT</h3>
														</div>
                                                        <div class="product-item_price font-additional font-weight-normal">Speciality</div>
                                                        <div class="product-item_price font-additional font-weight-normal">
                                                            <div id="gallery" class="gallery">
                                                                <div class="image gallery-group-1">
                                                                    <div class="image-inner">
                                                                        <a href="assets/img/gallery/gallery-1.jpg" data-lightbox="gallery-group-1">
                                                                            <img src="assets/img/gallery/gallery-1.jpg" alt="" width="50" height="50"/>
                                                                        </a>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                        </div>
														<div class="font-main font-weight-normal color-third">Experience</div>
														<br />
                                                        <div class="font-main font-weight-normal color-third">Clinic Name</div>
														<br />
														<div class="font-main font-weight-normal color-third">services</div>
														
													</div>
												</div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 clearfix">
													<div class="font-main font-weight-normal color-third">Address</div>
                                                    <br />
                                                    <div class="font-additional font-weight-normal customColor">
                                                    <span class="icon-cash"></span>
                                                    $240.00
                                                    </div>
                                                    <br />
													<div class="font-main font-weight-normal color-third">
                                                    <span class="icon-clock"></span>
                                                    Time
                                                    </div>
                                                    <br />

                                                    <a href="#" class="btn button-additional font-additional font-weight-normal text-uppercase hvr-rectangle-out hover-focus-bg before-bg">
															Book Appointment
													</a>
												</div>
											</div>--%>
										</li>
									
                                        
										
									</ul>

								</div>
								<%--<div class="pagination-container wow fadeInUp" data-wow-delay="0.3s">
									<div class="pagination-info font-additional">Items 1 to 6 of 157 total</div>
									<ul class="pagination-list">
										<li><a href="#" class="prev hover-focus-color">previous</a></li>
										<li><a href="#" class="page current customBgColor">1</a></li>
										<li><a href="#" class="page hover-focus-color">2</a></li>
										<li><a href="#" class="page hover-focus-color">3</a></li>
										<li><a href="#" class="page hover-focus-color">4</a></li>
										<li><span>....</span></li>
										<li><a href="#" class="page hover-focus-color">26</a></li>
										<li><a href="#" class="next hover-focus-color">NEXT</a></li>
									</ul>
								</div>--%>
							</div>
						</div>
					</div>
				</div>
			</section>

</asp:Content>

