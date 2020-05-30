<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_experience.aspx.cs" Inherits="Doctor_doc_experience" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function deletefunction(id1) {
        if (confirm("Are you sure you want to delete?")) {
            window.location.href = "doc_delete_experience.aspx?expid=" + id1;

        }

    }
</script>
<h1 class="page-header">Doctor Experience Information</h1>

    <div class="row">
        <div class="col-md-12">
			                <!-- begin panel -->
                                                                                                                                                            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Experience</h4>
                    </div>
                    <div class="panel-body panel-form">
                        <form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
                          <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="doc_exp_year_from" EventName="SelectedIndexChanged" />
                        </Triggers>
                        <ContentTemplate>
						
						    <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">From :</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="doc_exp_month_from" runat="server" class="form-control">
                                            <asp:ListItem disabled Selected Value="SELECT">Select Month</asp:ListItem>
                                           
                                            </asp:DropDownList>
                                           
                                            <asp:DropDownList ID="doc_exp_year_from" runat="server" class="form-control" 
                                                AutoPostBack="True" 
                                                onselectedindexchanged="doc_exp_year_from_SelectedIndexChanged">
                                            <asp:ListItem disabled Selected Value="SELECT">Select Year</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Select Month." ForeColor="Red" ControlToValidate="doc_exp_month_from" InitialValue="SELECT" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Select Year." ForeColor="Red" ControlToValidate="doc_exp_year_from" InitialValue="SELECT" Display="Dynamic"></asp:RequiredFieldValidator>

                                        </div>
                                        
                             </div>

                             

						    <div class="form-group">
                                        <label class="col-md-4 col-sm-4 control-label">To :</label>
                                        <div class="col-md-6">
                                            
                                            <asp:DropDownList ID="doc_exp_month_to" runat="server" class="form-control">
                                            <asp:ListItem disabled Selected Value="SELECT">Select Month</asp:ListItem>
                                            </asp:DropDownList>  
                                            <asp:DropDownList ID="doc_exp_year_to" runat="server" class="form-control" 
                                                AutoPostBack="True">
                                            <asp:ListItem disabled Selected Value="SELECT">Select Year</asp:ListItem>
                                         
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Select Month." ForeColor="Red" ControlToValidate="doc_exp_month_to" InitialValue="SELECT" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Select Year." ForeColor="Red" ControlToValidate="doc_exp_year_to" InitialValue="SELECT" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                             </div>
                             </ContentTemplate>
                        </asp:UpdatePanel>
                            <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4">Discription</label>
							    <div class="col-md-6 col-sm-6">
                                <asp:TextBox ID="doc_disc" name="doc_disc" runat="server" CssClass="form-control" placeholder="Discription"></asp:TextBox>
							    </div>
						    </div>
						       
						    <div class="form-group">
							    <label class="control-label col-md-4 col-sm-4"></label>
							    <div class="col-md-6 col-sm-6">
                                    <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-danger" 
                                        onclick="submit_Click"/>
							    </div>
						    </div>
                        </form>
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
                        <h4 class="panel-title">Experience Table</h4>
                    </div>
                    <div class="panel-body">
                        <table id="data-table" class="table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th>Sr.No</th>
                                    <th>From </th>
                                    <th>To</th>
                                    <th>Description</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                   
                                </tr>
                            </thead>
                            <tbody id="tbl_exp" runat="server">
                                
                            </tbody>
                        </table>
                    </div>
                </div>
        </div>
    </div>
   
</asp:Content>

