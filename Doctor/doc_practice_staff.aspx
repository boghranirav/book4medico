<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_practice_staff.aspx.cs" Inherits="Doctor_doc_practice_staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function deletefunction(id1) {
        if (confirm("Are you sure you want to delete?")) {
            window.location.href = "doc_delete_practice_staff.aspx?psid=" + id1;

        }

    }
</script>


<h1 class="page-header">Practice Staff Information</h1>

    <div class="row">
        <div class="col-md-12">
			                <!-- begin panel -->
                                                                                                                                                            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Practice Staff</h4>
                    </div>
                    <div class="panel-body panel-form">
                        <form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>

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
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Enter Valid Name." ValidationExpression="^([a-zA-Z ]){2,40}$" ForeColor="Red" ControlToValidate="doc_staff_name"></asp:RegularExpressionValidator>
                                                    
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
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Registration No. :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="staff_reg_no" name="staff_reg_no" runat="server" 
                                        CssClass="form-control" placeholder="Registration No" AutoPostBack="True" 
                                        ontextchanged="staff_reg_no_TextChanged"></asp:TextBox>
							    <asp:Label ID="lblcheck" runat="server" ForeColor="Red"></asp:Label>  
                                </div>
						    </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>
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
                                            <asp:ListItem disabled Selected Value="SELECT">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="staff_city" ErrorMessage="*Select City." ForeColor="Red" InitialValue="SELECT"></asp:RequiredFieldValidator>
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
							    <label class="control-label col-md-4 col-sm-4">Education :</label>
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
                                    <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" onclick="submit_Click" 
                                        />
							    </div>
						    </div>
                        </form>
                    </div>
        </div>
        </div>              
	</div>
        	        <!-- begin col-6 -->
     <div class="row">
	    <div class="col-md-12">
            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">List of Practice Staff </h4>
                    </div>
                    <div class="panel-body">
                        <table  id="data-table" class="table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th>Sr.No</th>
                                    <th>Clinic Name</th>
                                    <th>Staff Name</th>
                                    <th>Mobile</th>
                                    <th>Email</th>
                                    <th>Detail</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                            <tbody id="tbl_pstaff" runat="server">
                                
                            </tbody>
                        </table>
                    </div>
                </div>
        </div>
    </div>
</asp:Content>

