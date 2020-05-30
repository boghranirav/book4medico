<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_side_masterpage1.master" AutoEventWireup="true" CodeFile="admin_services.aspx.cs" Inherits="Admin_admin_services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function deletefunction(id1) {
        if (confirm("Are you sure you want to delete service?")) {
        window.location.href="admin_deleteservices.aspx?serid="+id1;

        }
        
    }
</script>
<h1 class="page-header">Doctor Services Information</h1>

    <div class="row">
        <div class="col-md-12">
			                <!-- begin panel -->
                                                                                                                                                            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Services</h4>
                    </div>
                    <div class="panel-body panel-form">
                        <form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Service Name :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="admin_service" name="admin_service" runat="server" CssClass="form-control" placeholder="Enter Service Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Service Name" ForeColor="Red" ControlToValidate="admin_service"></asp:RequiredFieldValidator>
							    </div>
						    </div>
                               
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                    <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" onclick="submit_Click" 
                                        />
							    </div>
						    </div>
                        </form>
                    </div>
        </div>
        </div>              
	</div>
    

    <div class="row">
			
			<h1 class="page-header">Services List </h1>
			
			<div class="row">
			    <div class="col-md-12">
			        <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title">List of Service</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table id="data-table" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>
                                            <th>Sr No.</th>
                                            <th>Service</th>
                                            <th>Edit</th>
                                            <th>Delete</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbl_service" runat="server">
                                        
                                        
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

</asp:Content>

