
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_side_masterpage1.master" AutoEventWireup="true" CodeFile="admin_editarea.aspx.cs" Inherits="Admin_admin_editarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1 class="page-header">Area Information</h1>

    <div class="row">
        <div class="col-md-8">
			                <!-- begin panel -->
                                                                                                                                                            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Area</h4>
                    </div>
                    <div class="panel-body panel-form">
                        <form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dd_country2" EventName="SelectedIndexChanged" />
                            </Triggers>
                            <ContentTemplate>
						    <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">Select Country :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="dd_country2" runat="server" class="form-control" 
                                                onselectedindexchanged="dd_country2_SelectedIndexChanged" 
                                                AutoPostBack="True">
                                            <asp:ListItem disabled Selected Value="SELECT">SELECT</asp:ListItem>
                                           
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Select Country." ControlToValidate="dd_country2" ForeColor="Red" InitialValue="SELECT" Display="Dynamic"></asp:RequiredFieldValidator>

                                        </div>
                             </div>
                             <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">Select State:</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="dd_state1" runat="server" class="form-control" 
                                                onselectedindexchanged="dd_state1_SelectedIndexChanged" 
                                                AutoPostBack="True">
                                            <asp:ListItem disabled Selected Value="SELECT">SELECT</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Select State." ControlToValidate="dd_state1" ForeColor="Red" InitialValue="SELECT" Display="Dynamic"></asp:RequiredFieldValidator>

                                        </div>
                             </div>
                             
                             <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">Select City:</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="dd_city" runat="server" class="form-control" 
                                                AutoPostBack="True">
                                            <asp:ListItem disabled Selected Value="SELECT">SELECT</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Select City." ControlToValidate="dd_city" ForeColor="Red" InitialValue="SELECT" Display="Dynamic"></asp:RequiredFieldValidator>

                                        </div>
                             </div>
                             
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Area Name :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="admin_area" name="admin_area" runat="server" CssClass="form-control" placeholder="Enter area Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Enter Area." ControlToValidate="admin_area" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

							    </div>
						    </div>
                            
                                  </ContentTemplate>
                            </asp:UpdatePanel>
                               
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                   
                                    <asp:Button ID="btnupdate" runat="server" Text="Update"  class="btn btn-danger" 
                                        onclick="btnupdate_Click"/>

                                    <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-danger" NavigateUrl="~/Admin/admin_area.aspx">Cancel</asp:HyperLink>
							    </div>
						    </div>
                        </form>
                    </div>
        </div>
        </div>              
	</div>
    

</asp:Content>

