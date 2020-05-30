<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_clinic_info.aspx.cs" Inherits="Doctor_doc_clinic_info" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1 class="page-header">Doctor Clinic Information</h1>
<form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
<asp:ScriptManager ID="ScriptManager2" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<Triggers>
<asp:AsyncPostBackTrigger ControlID="GridView1" />

</Triggers>
<ContentTemplate>
		<br />
 <div class="row">
    <div class="col-md-12">
			        <!-- begin panel -->
                    <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title">Clinic Information</h4>
                        </div>
                        <div class="panel-body panel-form">
                           
                            
								<div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Clinic Name :</label>
									<div class="col-md-6 col-sm-6">
                                        <asp:TextBox ID="doc_clinic_name" name="doc_clinic_name" runat="server" CssClass="form-control" placeholder="Clinic Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Clinic Name" ForeColor="Red" ControlToValidate="doc_clinic_name" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Enter Valid Clinic Name." ValidationExpression="^([a-zA-Z ]){2,40}$" ForeColor="Red" ControlToValidate="doc_clinic_name"></asp:RegularExpressionValidator>

									</div>
								</div>
								<div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Address :</label>
									<div class="col-md-6 col-sm-6">
                                    <asp:TextBox ID="doc_clinic_address" name="doc_clinic_address" runat="server" 
                                            CssClass="form-control" placeholder="Address" TextMode="MultiLine"></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Enter Clinic Address" ForeColor="Red" ControlToValidate="doc_clinic_address"></asp:RequiredFieldValidator>
                                    
                                    </div>
								</div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="doc_city" EventName="SelectedIndexChanged" />
                            </Triggers>
                            <ContentTemplate>
                               <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">Select City :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="doc_city" runat="server" class="form-control" 
                                                onselectedindexchanged="doc_city_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem disabled Selected Value="SELECT">SELECT</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ErrorMessage="*Select City" ForeColor="Red" ControlToValidate="doc_city" 
                                            InitialValue="SELECT"></asp:RequiredFieldValidator>
                                        </div>

                               </div>
							    <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">Select Area :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="doc_area" runat="server" class="form-control" 
                                                >
                                            <asp:ListItem disabled Selected Value="SELECT">SELECT</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ErrorMessage="*Select Area" ForeColor="Red" ControlToValidate="doc_area" 
                                            InitialValue="SELECT"></asp:RequiredFieldValidator>
                                        </div>
                               </div>
					        </ContentTemplate>
                        </asp:UpdatePanel>	
                                
                                <div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Phone Number :</label>
									<div class="col-md-6 col-sm-6">
										<asp:TextBox ID="doc_clinic_phone" name="doc_clinic_phone" runat="server" CssClass="form-control" placeholder="Phone Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Enter Clinic Phone Number" ForeColor="Red" ControlToValidate="doc_clinic_phone" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Enter valid mobile no." ForeColor="Red" ValidationExpression="[789][0-9]{9}" ControlToValidate="doc_clinic_phone" Display="Dynamic" ></asp:RegularExpressionValidator>
									</div>
								</div>
                                <div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Email :</label>
									<div class="col-md-6 col-sm-6">
										<asp:TextBox ID="doc_clinic_email" name="doc_clinic_email" runat="server" CssClass="form-control" placeholder="Clinic Email-Id"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Enter Clinic Email" ForeColor="Red" ControlToValidate="doc_clinic_email" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Enter Valid Email Id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ControlToValidate="doc_clinic_email"></asp:RegularExpressionValidator>

									</div>
								</div>
                                <div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Pincode :</label>
									<div class="col-md-6 col-sm-6">
										<asp:TextBox ID="doc_clinic_pincode" name="doc_clinic_pincode" runat="server" CssClass="form-control" placeholder="Pincode"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Enter Clinic Pincode" ForeColor="Red" ControlToValidate="doc_clinic_pincode"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Enter Valid Pincode." ValidationExpression="[0-9]{4,7}" ForeColor="Red" ControlToValidate="doc_clinic_pincode"></asp:RegularExpressionValidator>

									</div>
								</div>
                                
                                <div class="form-group">
									<label class="control-label col-md-4">Fees :</label>
									<div class="col-md-6">
										<asp:TextBox ID="doc_fees" name="doc_fees" runat="server" class="form-control" placeholder="Fees"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Enter Clinic Fees" ForeColor="Red" ControlToValidate="doc_fees" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Enter Number Only." ValidationExpression="[0-9]{2,5}" ForeColor="Red" ControlToValidate="doc_fees"></asp:RegularExpressionValidator>

									</div>
								</div>
								<div class="form-group">
									<label class="control-label col-md-4 col-sm-4"></label>
									<div class="col-md-6 col-sm-6">
                                        <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" 
                                            onclick="submit_Click"/>
                                        <asp:Button ID="update_delete" runat="server" Text="" class="btn btn-danger" 
                                            onclick="update_delete_Click" />
                                        <asp:HyperLink ID="cancel_b" runat="server" class="btn btn-danger" NavigateUrl="~/Doctor/doc_clinic_info.aspx">Cancel</asp:HyperLink>
									</div>
								</div>
                            
                        </div>
                    </div>
                    <!-- end panel -->
    </div>
</div>



     	<div class="row">
			    <div class="col-md-12">
			        <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title">List of Clinic</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                             
                 <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered" DataKeyNames="dclinic_id" 
                                    onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing">
                    <Columns>
                        <asp:BoundField DataField="clinic_name" HeaderText="Clinic Name" ReadOnly="true"/>
                        <asp:BoundField DataField="city_name" HeaderText="City Name" ReadOnly="true"/>
                        <asp:BoundField DataField="area_name" HeaderText="Area Name" ReadOnly="true"/>
                        <asp:BoundField DataField="address" HeaderText="Address" ReadOnly="true"/>
                        <asp:BoundField DataField="fees" HeaderText="Fees" ReadOnly="true"/>
                        <asp:BoundField DataField="phone_no" HeaderText="Phone Number" ReadOnly="true"/>
                        <asp:BoundField DataField="email_id" HeaderText="Email id" ReadOnly="true"/>
                       <asp:CommandField ShowEditButton="True" HeaderText="Edit" 
                                ShowCancelButton="false" CancelText="" UpdateText="" ButtonType="Image" EditImageUrl="~/assets/img/edit.png"  ItemStyle-HorizontalAlign="Center"/>
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" ButtonType="Image"  DeleteImageUrl="~/assets/img/delete.png"   ItemStyle-HorizontalAlign="Center"/>
                        </Columns>
                    </asp:GridView>                   
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        
</ContentTemplate>
</asp:UpdatePanel>

</form>
</asp:Content>

