<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_side_masterpage1.master" AutoEventWireup="true" CodeFile="admin_state.aspx.cs" Inherits="Admin_admin_state" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function deletefunction(id1) {
        if (confirm("Are you sure you want to delete?")) {
            window.location.href = "admin_deletestate.aspx?stid=" + id1;

        }

    }
</script>
    <h1 class="page-header">State Information</h1>


    <div class="row">
        <div class="col-md-12">
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
                                    <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" onclick="submit_Click" 
                                        />
							    </div>
						    </div>
                        </form>
                    </div>
        </div>
        </div>              
	</div>
    

			
			<h1 class="page-header">State List </h1>
			
			<div class="row">
			    <div class="col-md-12">
			        <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title">List of State</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table id="data-table" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>
                                            <th>Sr No.</th>
                                            <th>State</th>
                                            <th>Country</th>
                                            <th>Edit</th>
                                            <th>Delete</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbl_state" runat="server">
                                        
                                        
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

</asp:Content>

