<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_side_masterpage1.master" AutoEventWireup="true" CodeFile="admin_editspecialization.aspx.cs" Inherits="Admin_admin_editspecialization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h1 class="page-header">Doctor Specialization Information</h1>

    <div class="row">
        <div class="col-md-8">
			                <!-- begin panel -->
                                                                                                                                                            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Specialization</h4>
                    </div>
                    <div class="panel-body panel-form">
                        <form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Specialization Name :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="admin_spe" name="admin_spe" runat="server" CssClass="form-control" placeholder="Enter Specialization Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Specialization" ForeColor="Red" ControlToValidate="admin_spe"></asp:RequiredFieldValidator>

							    </div>
						    </div>
                               
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                    <asp:Button ID="update" runat="server" Text="Update" class="btn btn-danger" 
                                        onclick="update_Click" />
                                    <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-danger" NavigateUrl="~/Admin/admin_specialization.aspx">Cancel</asp:HyperLink>
							    </div>
						    </div>
                        </form>
                    </div>
        </div>
        </div>              
	</div>
    

   		

</asp:Content>

