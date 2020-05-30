<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_side_masterpage1.master" AutoEventWireup="true" CodeFile="admin_specialization.aspx.cs" Inherits="Admin_admin_specialization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function deletefunction(id1) {
        if (confirm("Are you sure you want to delete?")) {
            window.location.href = "admin_deletespecialization.aspx?speid=" + id1;

        }

    }
</script>
<h1 class="page-header">Doctor Specialization Information</h1>

    <div class="row">
        <div class="col-md-12">
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Specialization" ForeColor="Red" ControlToValidate="admin_spe" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Enter Valid Specialization." ValidationExpression="^([a-zA-Z ()-]){2,40}$" ForeColor="Red" ControlToValidate="admin_spe"></asp:RegularExpressionValidator>
							    </div>
						    </div>
                               
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                    <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" 
                                        onclick="submit_Click"/>
							    </div>
						    </div>
                        </form>
                    </div>
        </div>
        </div>              
	</div>
    

   		
			<h1 class="page-header">List of Specialization </h1>
			
			<div class="row">
			    <div class="col-md-12">
			        <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title">List of Speciality</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table id="data-table" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>
                                            <th>Srno</th>
                                            <th>Specialization</th>
                                            <th>Edit</th>
                                            <th>Delete</th>
                                        </tr>
                                    </thead>
                                    <tbody id="doc_spe" runat="server">
                                        
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
      
</asp:Content>

