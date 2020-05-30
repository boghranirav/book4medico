<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_side_masterpage1.master" AutoEventWireup="true" CodeFile="admin_passchange.aspx.cs" Inherits="Admin_admin_passchange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1 class="page-header">Change Password</h1>

    <div class="row">
        <div class="col-md-12">
			                <!-- begin panel -->
                                                                                                                                                            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Change Password</h4>
                    </div>
                    <div class="panel-body panel-form">
                        <form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
                             
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">User Name :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="admin_id" name="admin_id" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
							    </div>
						    </div>
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Old Password :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="old_pass" name="old_pass" runat="server" CssClass="form-control" 
                                        placeholder="Enter Old Password"
                                        TextMode="Password"></asp:TextBox>
                                    <asp:Label ID="lblcheck" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Old Password." ControlToValidate="old_pass" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                   
                                </div>
						    </div>
                        
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">New Password :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="new_pass" name="new_pass" runat="server" CssClass="form-control" placeholder="Enter New Password" TextMode="Password"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Enter New Password" ControlToValidate="new_pass" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Password must contain: Minimum 6 characters atleast 1 Alphabet and 1 Number." ForeColor="Red" ControlToValidate="new_pass" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$"></asp:RegularExpressionValidator>
                                
                                </div>
						    </div>

                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Confirm Password :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="confirm_pass" name="confirm_pass" runat="server" CssClass="form-control" placeholder="Confirm New Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Enter Password." ControlToValidate="confirm_pass" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>    
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*Password Does Not Match." ControlToCompare="new_pass" ControlToValidate="confirm_pass" ForeColor="Red" Display="Dynamic" Operator="Equal"></asp:CompareValidator>
                                </div>
						    </div>
                            
                               
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                    <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" 
                                        onclick="submit_Click"  />
							    </div>
						    </div>
                           
                        </form>
                    </div>
        </div>
        </div>              
	</div>

</asp:Content>

