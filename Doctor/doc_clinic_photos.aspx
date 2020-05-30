<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_clinic_photos.aspx.cs" Inherits="Doctor_doc_clinic_photos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1 class="page-header">Doctor Clinic Photos</h1>
<br />
   <form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server" enctype="multipart/form-data">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
   </asp:ScriptManager>
   <div class="row">
        <div class="col-md-12">
			                <!-- begin panel -->
                                                                                                                                                            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Add Clinic Photos</h4>
                    </div>
                    <div class="panel-body panel-form">
                     
						    <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">Select Clinic :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="doc_clinic" runat="server" class="form-control">
                                            <asp:ListItem disabled Selected Value="select">SELECT CLINIC</asp:ListItem>
                                           
                                            </asp:DropDownList>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ErrorMessage="Please Select Clinic" ControlToValidate="doc_clinic" 
                                                ForeColor="Red" InitialValue="select"></asp:RequiredFieldValidator>
                                        </div>
                             </div>
						    
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Select Path</label>
							    <div class="col-md-6 col-sm-6">
                                <input type="file" ID="my_file" runat="server" class="multi"/>
                                <br />
							    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
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
        </div>              
	</div>


    
    <h1 class="page-header">Clinic Gallery </h1>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
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
                        <h4 class="panel-title">Clinic Photos Gallery</h4>
                    </div>
                      <div class="panel-body panel-form">
                     
						    <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">Select Clinic :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" 
                                                onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem Selected Value="ALL">ALL CLINIC</asp:ListItem>
                                           
                                            </asp:DropDownList>
                                            <br />
                                        </div>
                             </div>
                            
                            
					</div>
                </div>
        </div>              
	</div>

    <div class="superbox" data-offset="54" id="img_g" runat="server">		
    </div>
   
    </ContentTemplate>
</asp:UpdatePanel>
  </form>
    <style type="text/css">
        .stylish-button {
            color:#333;
            background-color:#FA2;
            border-radius:5px;
            border:none;
            width:55px;
	        height:25px;
	        font-size:16px;
            font-weight:700;
        }
</style>

</asp:Content>
