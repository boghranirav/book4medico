<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_side_masterpage1.master" AutoEventWireup="true" CodeFile="admin_editstate.aspx.cs" Inherits="Admin_admin_editstate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <h1 class="page-header">State Information</h1>


    <div class="row">
        <div class="col-md-8">
			                <!-- begin panel -->
                                                                                                                                                            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">State</h4>
                    </div>
                    <div class="panel-body panel-form">
                        <form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
						    <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">Select Country :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="admin_country" runat="server" class="form-control">
                                            <asp:ListItem disabled Selected Value="SELECT">SELECT</asp:ListItem>
                                            
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Select Country." ControlToValidate="admin_country" ForeColor="Red" InitialValue="SELECT"></asp:RequiredFieldValidator>

                                        </div>
                             </div>
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">State Name :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="admin_state" name="admin_state" runat="server" CssClass="form-control" placeholder="Enter State Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Enter State Name." ControlToValidate="admin_state" ForeColor="Red"></asp:RequiredFieldValidator>

							    </div>
						    </div>
                               
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                   
                                    <asp:Button ID="btnupdate" runat="server" Text="Update" class="btn btn-danger" 
                                        onclick="btnupdate_Click"/>
                                    <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-danger" NavigateUrl="admin_state.aspx">Cancel</asp:HyperLink>

							    </div>
						    </div>
                        </form>
                    </div>
        </div>
        </div>              
	</div>
    

</asp:Content>

