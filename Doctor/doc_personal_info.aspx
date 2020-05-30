<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_personal_info.aspx.cs" Inherits="Doctor_doc_personal_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h1 class="page-header">Doctor Personal Information</h1>
	<form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">		
		<br />
    <div class="col-md-8">
			        <!-- begin panel -->
                    <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title">Profile</h4>
                        </div>
                        <div class="panel-body panel-form">
                            
								<div class="form-group">
									<label class="control-label col-md-4 col-sm-4">First Name :</label>
									<div class="col-md-6 col-sm-6">
                                        <asp:TextBox ID="doc_first_name" name="doc_first_name" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter First Name" ForeColor="Red" ControlToValidate="doc_first_name" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Enter Valid Name." ValidationExpression="^([a-zA-Z]){2,40}$" ForeColor="Red" ControlToValidate="doc_first_name"></asp:RegularExpressionValidator>

									</div>
								</div>
								<div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Last Name :</label>
									<div class="col-md-6 col-sm-6">
                                    <asp:TextBox ID="doc_last_name" name="doc_last_name" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Enter Last Name" ForeColor="Red" ControlToValidate="doc_last_name" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Enter Valid Name." ValidationExpression="^([a-zA-Z]){2,40}$" ForeColor="Red" ControlToValidate="doc_last_name"></asp:RegularExpressionValidator>

									</div>
								</div>
								<div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Mobile :</label>
									<div class="col-md-6 col-sm-6">
										<asp:TextBox ID="doc_mobile" name="doc_mobile" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Enter Mobile" ForeColor="Red" ControlToValidate="doc_mobile" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Enter Valid Mobile Number.." ValidationExpression="[789][0-9]{9}" ForeColor="Red" ControlToValidate="doc_mobile"></asp:RegularExpressionValidator>

									</div>
								</div>
                                <div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Email :</label>
									<div class="col-md-6 col-sm-6">
										<asp:TextBox ID="doc_email" name="doc_email" runat="server" CssClass="form-control" disabled></asp:TextBox>
                                       
									</div>
								</div>
                                <div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Gender :</label>
									<div class="col-md-6 col-sm-6">
										<div class="radio">
                                            <label>
												<asp:RadioButton ID="doc_gender1" name="doc_gender" value="Male" runat="server" Checked="True" GroupName="gender" />Male
                                            </label>
										</div>
										<div class="radio">
                                            <label>
											    <asp:RadioButton ID="doc_gender2" name="doc_gender" value="Female" runat="server" GroupName="gender" />Female
                                            </label>
										</div>
                                        
									</div>
								</div>
                                <div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Experience(Years) :</label>
									<div class="col-md-6 col-sm-6">
										<asp:TextBox ID="doc_experience" name="doc_experience" runat="server" CssClass="form-control" placeholder="Enter Experience"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Enter Your Experience" ForeColor="Red" ControlToValidate="doc_experience" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Enter Valid Experience(Only Numbers)." ValidationExpression="[0-9]{0,2}" ForeColor="Red" ControlToValidate="doc_experience"></asp:RegularExpressionValidator>

									</div>
								</div>
                                <div class="form-group">
									<label class="control-label col-md-4">Country :</label>
									<div class="col-md-6">
										<asp:DropDownList ID="doc_country" name="doc_country" runat="server"  CssClass="form-control">
                                        <asp:ListItem Value="SELECT">SELECT</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Select Country" ForeColor="Red" ControlToValidate="doc_country" InitialValue="SELECT"></asp:RequiredFieldValidator>
									</div>
								</div>
								<div class="form-group">
									<label class="control-label col-md-4 col-sm-4"></label>
									<div class="col-md-6 col-sm-6">
                                        <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" 
                                            onclick="submit_Click"/>
									</div>
								</div>
                        </div>
                    </div>
                    <!-- end panel -->
    </div>

    <div class="col-md-3">
			        <!-- begin panel -->
                    <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <h4 class="panel-title">Profile Picture</h4>
                        </div>
                        <div class="panel-body panel-form">
                            <br />
                            
								<div class="col-md-8 col-sm-4">
                                    <asp:Image ID="display_pro_pic" runat="server" height="200" width="200" />
                                    <br /><br />
								</div>

                                <div class="col-md-6 col-sm-6">
                                        <asp:FileUpload ID="profile_picture" runat="server"  />
                                        <br />
                                        <asp:Button ID="btn_upload" runat="server" text="Upload" 
                                            onclick="btn_upload_Click" class="btn btn-danger" />
                                  
								</div>
                                <br /><br /> 
						</div>
                          <br />
                    </div>
                    <!-- end panel -->
     </div>
    
 </form>  
</asp:Content>

