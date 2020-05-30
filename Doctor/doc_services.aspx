<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_services.aspx.cs" Inherits="Doctor_doc_services" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
 <Triggers>
 <asp:AsyncPostBackTrigger ControlID="GridView1" />

 </Triggers>
 <ContentTemplate>
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
                       
                    
						    <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">Select Services :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="doc_dd_service" runat="server" class="form-control" 
                                               >
                                            <asp:ListItem disabled Selected>SELECT</asp:ListItem>
                                           
                                            </asp:DropDownList>
                                            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        </div>
                             </div>
                         
						     <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Fees :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="doc_txt_fees" name="doc_txt_fees" runat="server" CssClass="form-control" placeholder="Enter Fees"></asp:TextBox>
							    <div>
                                            <span>
                                                <font color="red">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Fees " Display="Dynamic" ControlToValidate="doc_txt_fees" ></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Only Number" ControlToValidate="doc_txt_fees" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                </font>
                                            </span>
                                        </div>
                                </div>
						    </div>
                           

						       
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                    <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" onclick="submit_Click" 
                                       />
                                    <asp:Button ID="update_delete" runat="server" Text="" class="btn btn-danger" 
                                        onclick="update_delete_Click"/>
                                    <asp:HyperLink ID="cancel_b" runat="server" class="btn btn-danger" NavigateUrl="~/Doctor/doc_services.aspx">Cancel</asp:HyperLink>
							    </div>
						    </div>
                            
                        
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
                            <h4 class="panel-title">List of Services</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                             
                 <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered" DataKeyNames="doc_ser_id" 
                                    onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                                   
                                >
                    <Columns>
                        <asp:BoundField DataField="service_name" HeaderText="Description"  ReadOnly="true"/>  
                        <asp:BoundField DataField="fees" HeaderText="Description"  ReadOnly="true"/>  

                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" 
                                ShowCancelButton="false" CancelText="" UpdateText="" ItemStyle-Width="15%" ButtonType="Image"  EditImageUrl="~/assets/img/edit.png" ItemStyle-HorizontalAlign="Center"/>
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" ItemStyle-Width="15%" ButtonType="Image"  DeleteImageUrl="~/assets/img/delete.png" ItemStyle-HorizontalAlign="Center"/>
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

