<%@ Page Title="" Language="C#" MasterPageFile="~/user_master.master" AutoEventWireup="true" CodeFile="review.aspx.cs" Inherits="user_feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="Row">
                   
		<form id="Form1"   runat="server" >
           <div class="col-lg-12" style="margin-top:10px;">
                      <div class="row"> 
                       <div class="col-lg-1 col-lg-offset-4" style="margin-top:2cm;" >
					    	<asp:Image ID="doc_profile_picture" runat="server" height="120" width="120"></asp:Image>
						</div>
						<div class="col-lg-7" style="margin-top:2cm;padding-left:1cm;">
                          <h3 id="docname" runat="server"></h3>
                             <asp:Label ID="lblexp" runat="server" Text=""></asp:Label><br/>
                                <asp:Label ID="lbldegree" runat="server" Text=""></asp:Label>	<br/>
                                <asp:Label ID="lblspeciality" runat="server" Text=""></asp:Label>												
						</div>
                     </div>
                     <div class="row">
                         <div class="col-lg-8 col-lg-offset-4" style="margin-top:10px;">
                               <div class="form-group">
                                        <label>Write FeedBack</label>
                                         <asp:TextBox ID="txtfeedback" CssClass="form-control" runat="server" Width="350px" TextMode="MultiLine"></asp:TextBox>
                               </div>
                               
                               <div class="form-group">
                                   <asp:Button ID="submit" runat="server"  
                                       CssClass="btn btn-primary font-additional hvr-wobble-bottom"  Text="Done" onclick="submit_Click" 
                                       />
                                </div>

                          </div> 
                           </div>

                   </div>
                </form>
           </div>

</asp:Content>

