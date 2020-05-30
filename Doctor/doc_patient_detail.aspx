<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_patient_detail.aspx.cs" Inherits="Doctor_doc_patient_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="row">
<h1 class="page-header">Patient Information</h1>
	<form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">		
		<br />
    <div class="col-md-12">
			        <!-- begin panel -->
                    <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title">Patient Profile</h4>
                        </div>
                        <div class="panel-body panel-form">
                            
								<div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Patient Name :</label>
									<div class="col-md-6 col-sm-6">
                                        <asp:TextBox ID="p_first_name" name="p_first_name" runat="server" CssClass="form-control" disabled></asp:TextBox>
									</div>
								</div>
								<div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Email Id :</label>
									<div class="col-md-6 col-sm-6">
                                    <asp:TextBox ID="p_email" name="p_email" runat="server" CssClass="form-control" disabled></asp:TextBox>
									</div>
								</div>
								<div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Mobile :</label>
									<div class="col-md-6 col-sm-6">
										<asp:TextBox ID="p_mobile" name="p_mobile" runat="server" CssClass="form-control" disabled></asp:TextBox>
									</div>
								</div>
                                <div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Gender :</label>
									<div class="col-md-6 col-sm-6">
										<asp:TextBox ID="p_gender" name="p_gender" runat="server" CssClass="form-control" disabled></asp:TextBox>
                                       
									</div>
								</div>
                                <div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Birth Date :</label>
									<div class="col-md-6 col-sm-6">
										<asp:TextBox ID="p_birthdate" name="p_birthdate" runat="server" CssClass="form-control" disabled></asp:TextBox>
									</div>
								</div>
                               <div class="form-group">
									<label class="control-label col-md-4 col-sm-4">Age :</label>
									<div class="col-md-6 col-sm-6">
										<asp:TextBox ID="p_age" name="p_age" runat="server" CssClass="form-control" disabled></asp:TextBox>
									</div>
								</div>
							
                        </div>
                    </div>

           
                    <!-- end panel -->
    </div>
     <h1 class="page-header">Patient Appointment Information </h1>
			
	 <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title">Appointment History</h4>
                        </div>
                        <div class="panel-body">
                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <th>Clinic Name</th>
                                        <th>Book Date</th>
                                        <th>Book Time</th>
                                        <th>Book Reason</th>
                                    </tr>
                                </thead>
                                <tbody id="tbl_appontment_h" runat="server">
                                    
                                </tbody>
                            </table>
                        </div>
                    </div>
			 
           
    </form>
 </div>
</asp:Content>

