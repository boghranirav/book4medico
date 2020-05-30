<%@ Page Title="" Language="C#" MasterPageFile="~/user_side_nested_master.master" AutoEventWireup="true" CodeFile="clinic_detail.aspx.cs" Inherits="clinic_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<section id="productDetails" class="product-details">

				<div class="container">
					<div class="row narrow-content" style="border-left:1px solid #000;border-top:1px solid #000;border-right:1px solid #000;border-bottom:1px solid #000;margin-bottom:10px;">
						<br/>
                        <br/>
                        <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12 clearfix">
							<div class="product-gallery vertical-pager">
							    <asp:Image ID="profile_picture" runat="server" height="150" width="150"></asp:Image>
							</div>
						</div>
						<div class="product-cart product-details-narrow col-lg-10 col-md-10 col-sm-12 col-xs-12 clearfix">
							
								<h3 class="font-additional font-weight-bold text-uppercase"><asp:Label ID="lblclinicname" runat="server" Text="" ></asp:Label></h3>
							<hr/>
							 <div class="col-lg-6">
							    	<asp:Label ID="lbladdress" runat="server"  Text=""></asp:Label>
                             </div>
                             <div class="col-lg-4">
                                   <asp:Label ID="lblphone" runat="server" Text=""></asp:Label>          
                             </div>
													
						</div>
                      
						   <div class="col-lg-12 " style="margin-top:0.3cm;">
                               <div class="col-lg-12" runat="server" id="divclinicphoto" title="Clinic Photos">
						
                                </div>
                                
                          </div>
                        <div class="col-lg-12  clearfix" id="divservices" runat="server" >
                        
                        
                        </div>
                        <div class="col-lg-12  clearfix" id="divtiming" runat="server" >
                        
                        
                        </div>
                        <div class="col-lg-2" style="margin-bottom:10px;">
					    	<asp:Image ID="doc_profile_picture" runat="server" height="120" width="120"></asp:Image>
						</div>
						<div class="col-lg-10" style="margin-bottom:10px;">
                        <h3 id="docname" runat="server"></h3>
                            
                             <div class="col-lg-5">
                                <asp:Label ID="lblexp" runat="server" Text=""></asp:Label><br/>
                                <asp:Label ID="lbldegree" runat="server" Text=""></asp:Label>	<br/>
                                <asp:Label ID="lblspeciality" runat="server" Text=""></asp:Label>												
						     </div>
                             <div class="col-lg-5">
                             <asp:Label ID="lblfees" runat="server" Text=""></asp:Label><br/>
                             <asp:Label ID="lbldoctime" runat="server" Text=""></asp:Label><br/>
                              <asp:Label ID="lbldocmobileno" runat="server" Text=""></asp:Label>
                              </div>
                        </div>
                       
			    </div>
		    </div>
			</section>
</asp:Content>

