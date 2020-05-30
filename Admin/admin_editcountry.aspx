<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_side_masterpage1.master" AutoEventWireup="true" CodeFile="admin_editcountry.aspx.cs" Inherits="Admin_admin_editcountry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1 class="page-header">Country Information</h1>

    <div class="row">
        <div class="col-md-8">
			                <!-- begin panel -->
                                                                                                                                                            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Extra Validation Field</h4>
                    </div>
                    <div class="panel-body panel-form">
                        <form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Country Name :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="admin_country" name="admin_country" runat="server" CssClass="form-control" placeholder="Enter Country Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Country Name." ControlToValidate="admin_country" ForeColor="Red"></asp:RequiredFieldValidator>

							    </div>
						    </div>
                               
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                    <asp:Button ID="btnupdate" runat="server" Text="Update"  class="btn btn-danger" 
                                        onclick="btnupdate_Click" />
                                    <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-danger" NavigateUrl="~/Admin/admin_country.aspx">Cancel</asp:HyperLink>
							    </div>
						    </div>
                        </form>
                    </div>
        </div>
        </div>              
	</div>
    

</asp:Content>

