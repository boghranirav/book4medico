<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master"  AutoEventWireup="true" CodeFile="doc_specialization.aspx.cs" Inherits="Doctor_doc_specilazation" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1 class="page-header">Doctor Specialization Information</h1>
     <form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
     <asp:ScriptManager ID="ScriptManager2" runat="server">
     </asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                <asp:AsyncPostBackTrigger ControlID="doc_specialization" EventName="SelectedIndexChanged" />
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
                        <h4 class="panel-title">Specialization</h4>
                    </div>
                    <div class="panel-body panel-form">
                      
						    <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">Select Specialization :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="doc_specialization" runat="server" class="form-control" 
                                                AutoPostBack="True" 
                                                onselectedindexchanged="doc_specialization_SelectedIndexChanged">
                                            <asp:ListItem disabled Selected>SELECT</asp:ListItem>
                                           
                                            </asp:DropDownList>
                                            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        </div>
                             </div>
						  
                            
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                    <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" 
                                        onclick="submit_Click" />
                                    <asp:Button ID="update_delete" runat="server" Text="" class="btn btn-danger" onclick="update_delete_Click" 
                                       />
                                    <asp:Button ID="btncancle" runat="server" Text="Cancel" class="btn btn-danger" onclick="btncancle_Click" 
                                         />
							    </div>
						    </div>
                        
                    </div>
        </div>
        </div>              
	</div>
        	        <!-- begin col-6 -->
   
                        <!-- end panel -->
                        <div class="row">
			    <div class="col-md-12">
			        <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title">List of Specialization</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                             
                 <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered" DataKeyNames="doc_sep_id" 
                                    onrowdeleting="GridView1_RowDeleting"
                                    >
                        <Columns>
                            <asp:BoundField DataField="spe_name" HeaderText="Specialization" ReadOnly="true"/>
                           
                            <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" ItemStyle-Width="20%" ButtonType="Image"  DeleteImageUrl="~/assets/img/delete.png" ItemStyle-HorizontalAlign="Center"/>
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

