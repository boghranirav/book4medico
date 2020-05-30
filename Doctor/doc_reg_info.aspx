<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_reg_info.aspx.cs" Inherits="Doctor_doc_reg_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h1 class="page-header">Doctor Registration Information</h1>
<form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<Triggers>
<asp:AsyncPostBackTrigger ControlID="GridView1" />
</Triggers>
<ContentTemplate>
    <div class="row">
        <div class="col-md-12">
			                                                                                                                                                
             <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Resgistration</h4>
                    </div>
                    <div class="panel-body panel-form">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      
                        <ContentTemplate>
                        
						    
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Registration No. :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="doc_reg_no" name="doc_reg_no" runat="server" 
                                        CssClass="form-control" placeholder="Registration No" 
                                         AutoPostBack="True" 
                                        ontextchanged="doc_reg_no_TextChanged"></asp:TextBox>
							   
                                <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                            <div>
                                            <span>
                                                <font color="red">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Number " Display="Dynamic" ControlToValidate="doc_reg_no" ></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Only Number" ControlToValidate="doc_reg_no" ValidationExpression="^[0-9a-zA-Z]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                </font>
                                            </span>
                                        </div>
                             
                                </div>
						    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Name of Board :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="doc_board" name="doc_board" runat="server" CssClass="form-control" placeholder="Board Discription"></asp:TextBox>
							    <div>
                                     <span>
                                          <font color="red">
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Enter Name Of Bord " Display="Dynamic" ControlToValidate="doc_board" ></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Only Character" ControlToValidate="doc_board" ValidationExpression="^[ a-zA-Z,.-]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                </font>
                                            </span>
                                        </div>
                             
                                </div>
						    </div>
						       
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                    <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" 
                                        onclick="submit_Click"/>
                                  
                                    <asp:Button ID="update_delete" runat="server" Text="" class="btn btn-danger" 
                                        onclick="update_delete_Click" />
                                    
                                    <asp:HyperLink ID="cancel_b" runat="server" class="btn btn-danger" NavigateUrl="~/Doctor/doc_reg_info.aspx">Cancel</asp:HyperLink>
							    </div>
						    </div>
                        
                    </div>
        </div>
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
                            <h4 class="panel-title">Registration Information</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                             
                 <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered" DataKeyNames="reg_id" 
                                    onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                                   >
                        <Columns>
                            <asp:BoundField DataField="registration_no" HeaderText="Registration No" ReadOnly="true"/>
                            <asp:BoundField DataField="description" HeaderText="Board Name" ReadOnly="true"/>  
                            <asp:CommandField ShowEditButton="True" HeaderText="Edit" 
                                ShowCancelButton="false" CancelText="" UpdateText="" ButtonType="Image"  EditImageUrl="~/assets/img/edit.png" ItemStyle-HorizontalAlign="Center"/>
                            <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" ButtonType="Image"  DeleteImageUrl="~/assets/img/delete.png" ItemStyle-HorizontalAlign="Center"/>
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

