<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_education.aspx.cs" Inherits="Doctor_doc_education" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1 class="page-header">Doctor Education Information</h1>
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
			                <!-- begin panel -->
                                                                                                                                                            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Education Information</h4>
                    </div>
                    <div class="panel-body panel-form">

                    
						    <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">Select Degree :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="doc_degree" runat="server" class="form-control" 
                                               >
                                            <asp:ListItem disabled Selected>SELECT</asp:ListItem>
                                           
                                            </asp:DropDownList>
                                            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                            <font color="red">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Select Degree" ControlToValidate="doc_degree" Display="Static" InitialValue="SELECT"></asp:RequiredFieldValidator>
                                            </font>
                                        </div>
                             </div>
                              

						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Institute Name :</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="doc_inst_name" name="doc_inst_name" runat="server" CssClass="form-control" placeholder="Enter Institute Name"></asp:TextBox>
							    <div>
                                            <span>
                                                <font color="red">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Institute Name" ControlToValidate="doc_inst_name" Display="Static"></asp:RequiredFieldValidator>
                                               
                                                </font>
                                            </span>
                                        </div>
                                </div>
						    </div>
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Discription(Year)</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="doc_disc" name="doc_disc" runat="server" CssClass="form-control" placeholder="Discription"></asp:TextBox>
                                <font color="red">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Enter Description" ControlToValidate="doc_disc" Display="Static"></asp:RequiredFieldValidator>
                                </font>
							    </div>
						    </div>
						       
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                    <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" 
                                        onclick="submit_Click"/>
                                    <asp:Button ID="update_delete" runat="server" Text="" class="btn btn-danger" 
                                        onclick="update_delete_Click"/>
                                    <asp:HyperLink ID="cancel_b" runat="server" class="btn btn-danger" NavigateUrl="~/Doctor/doc_education.aspx">Cancel</asp:HyperLink>
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
                            <h4 class="panel-title">List of Education</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                             
                 <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered" DataKeyNames="edu_id" 
                                    onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                                  >
                    <Columns>
                        <asp:BoundField DataField="degree_name" HeaderText="Degree Name" ReadOnly="true"/>
                        <asp:BoundField DataField="institute_name" HeaderText="Institute Name" ReadOnly="true"/>
                        <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="true"/>
                        <asp:CommandField ShowEditButton="True" HeaderText="Edit"
                                ShowCancelButton="false" CancelText="" UpdateText="" ButtonType="Image"  EditImageUrl="~/assets/img/edit.png" ItemStyle-HorizontalAlign="Center"/>
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" ButtonType="Image"  DeleteImageUrl="~/assets/img/delete.png" ItemStyle-HorizontalAlign="Center" />
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

