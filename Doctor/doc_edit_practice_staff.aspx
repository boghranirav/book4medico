<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_edit_practice_staff.aspx.cs" Inherits="Doctor_doc_edit_practice_staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h1 class="page-header">Doctor Specializations Information</h1>

    <div class="row">
        <div class="col-md-12">
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
                                        <label class="col-md-4 col-sm-4 control-label">Select Clinic :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="doc_clinic_id" runat="server" class="form-control">
                                            <asp:ListItem disabled Selected>Select</asp:ListItem>
                                            
                                            </asp:DropDownList>
                                        </div>
                             </div>
                          <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Staff Name :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="doc_staff_name" name="doc_staff_name" runat="server" CssClass="form-control" placeholder="Staff Name"></asp:TextBox>
							      
                                          
                                            <div>
                                            <span>
                                                <font color="red">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Name " Display="Dynamic" ControlToValidate="doc_staff_name" ></asp:RequiredFieldValidator>
                                                    
                                                </font>
                                            </span>
                                        </div>
                             
                                </div>
						    </div>
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Mobile No. :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="staff_mo_no" name="staff_mo_no" runat="server" CssClass="form-control" placeholder="Mobile Number" ></asp:TextBox>
							      
                                           
                                            <div>
                                            <span>
                                                <font color="red">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Enter Number " Display="Dynamic" ControlToValidate="staff_mo_no" ></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Only Number" ControlToValidate="staff_mo_no" ValidationExpression="^[0-9a-zA-Z]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                </font>
                                            </span>
                                        </div>
                             
                                </div>
						    </div>
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Email-ID. :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="staff_email" name="staff_email" runat="server" CssClass="form-control" placeholder="Email-ID" ></asp:TextBox>
							      
                                            <div>
                                            <span>
                                                <font color="red">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Enter Email-ID " Display="Dynamic" ControlToValidate="staff_email" ></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Email-ID" ControlToValidate="staff_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                                                </font>
                                            </span>
                                        </div>
                             
                                </div>
						    </div>
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Registration No. :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="staff_reg_no" name="staff_reg_no" runat="server" CssClass="form-control" placeholder="Registration No"  onchange="RegistrationnoAvailability()"></asp:TextBox>
							        <div id="checkregno" runat="server">                             
                                                <asp:Label ID="lblcheck" runat="server"></asp:Label>  
                                            </div>
                                                                         
                                </div>
						    </div>
                             <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Address :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="staff_address" name="staff_address" runat="server" 
                                        CssClass="form-control" placeholder="Address" TextMode="MultiLine" ></asp:TextBox>
							      
                                            <div>
                                            <span>
                                                <font color="red">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Enter Address " Display="Dynamic" ControlToValidate="staff_address" ></asp:RequiredFieldValidator>
                                                    
                                                </font>
                                            </span>
                                        </div>
                             
                                </div>
						    </div>

                              <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">Select City :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="staff_city" runat="server" class="form-control">
                                            <asp:ListItem disabled Selected>Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                             </div>
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Note :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="note" name="note" runat="server" CssClass="form-control" 
                                        placeholder="Note" TextMode="MultiLine" ></asp:TextBox>
							    </div>
						    </div>
                             <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Degree :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="staff_degree" name="staff_degree" runat="server" CssClass="form-control" placeholder="Degree" ></asp:TextBox>
							      
                                            <div>
                                            <span>
                                                <font color="red">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Enter Degree " Display="Dynamic" ControlToValidate="staff_degree" ></asp:RequiredFieldValidator>
                                                    
                                                </font>
                                            </span>
                                        </div>
                             
                                </div>
						    </div>
                             <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Registration Board :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="staff_reg_board" name="staff_reg_board" runat="server" CssClass="form-control" placeholder="Registration Board" ></asp:TextBox>
							      
                                            
                             
                                </div>
						    </div>
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                    <asp:Button ID="submit" runat="server" Text="Update" class="btn btn-danger" onclick="submit_Click"  
                                        />
                                    <a href="doc_practice_staff.aspx" class="btn btn-danger">Cancel</a>
                                    
							    </div>
						    </div>
                        </form>
                    </div>
        </div>
        </div>              
	</div>

</asp:Content>

