<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_edit_experience.aspx.cs" Inherits="Admin_doc_edit_experience" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1 class="page-header">Doctor Experience Information</h1>

    <div class="row">
        <div class="col-md-12">
			                <!-- begin panel -->
                                                                                                                                                            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Experience</h4>
                    </div>
                    <div class="panel-body panel-form">
                        <form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
                          <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="doc_exp_year_from" EventName="SelectedIndexChanged" />
                        </Triggers>
                        <ContentTemplate>
						
						    <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">From :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="doc_exp_month_from" runat="server" class="form-control">
                                            <asp:ListItem disabled Selected>Select Month</asp:ListItem>
                                           
                                            </asp:DropDownList>
                                           
                                            <asp:DropDownList ID="doc_exp_year_from" runat="server" class="form-control" 
                                                AutoPostBack="True" onselectedindexchanged="doc_exp_year_from_SelectedIndexChanged" 
                                                >
                                            <asp:ListItem disabled Selected>Select Year</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        
                             </div>

                             

						    <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">To :</label>
                                        <div class="col-md-6">
                                            
                                            <asp:DropDownList ID="doc_exp_month_to" runat="server" class="form-control">
                                            <asp:ListItem disabled Selected>Select Month</asp:ListItem>
                                            </asp:DropDownList>  
                                            <asp:DropDownList ID="doc_exp_year_to" runat="server" class="form-control" 
                                                AutoPostBack="True">
                                            <asp:ListItem disabled Selected>Select Year</asp:ListItem>
                                         
                                            </asp:DropDownList>
                                        </div>
                             </div>
                             </ContentTemplate>
                        </asp:UpdatePanel>
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Discription</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="doc_disc" name="doc_disc" runat="server" CssClass="form-control" placeholder="Discription"></asp:TextBox>
							    </div>
						    </div>
						       
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                    <asp:Button ID="submit" runat="server" Text="Update" class="btn btn-danger" onclick="submit_Click" 
                                        />
                                    <asp:Button ID="cancel_b" runat="server" Text="Cancel" class="btn btn-danger" onclick="cancel_b_Click" 
                                        />
                                    </div>
						    </div>
                        </form>
                    </div>
        </div>
        </div>              
	</div>

</asp:Content>

