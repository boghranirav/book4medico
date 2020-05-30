<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="index2.aspx.cs" Inherits="Doctor_index" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<meta http-equiv="Refresh" content="30" />
 <script type="text/javascript">
     function cancelappfunction(id1) {
         if (confirm("Are you sure you want to Cancel Appointment.?")) {
             window.location.href = "cancel_p_appointment.aspx?appid=" + id1;
         }
     }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
<form id="Form1" class="form-horizontal form-bordered" data-parsley-validate="true" runat="server">
  
<h1 class="page-header">Patient Upcoming Appointments</h1>
			<div class="row">
			    <div class="col-md-12">
			        <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title">List of Patient Upcoming Appointment</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                           
     

                                <table id="data-table" class="table table-striped table-bordered" >
                                    <thead>
                                        <tr>
                                            <th>Patient Name</th>
                                            <th>Clinic Name</th>
                                            <th>Phone No</th>
                                            <th>Appointment Date</th>
                                            <th>Time</th>
                                            <th>Reason To Visit</th>
                                            <th>Detail</th>
                                            <th>Cancel</th>
                                        </tr>
                                    </thead>
                                    
                                    <tbody id="tbl_display_upcoming" runat="server">
                                        
                                        
                                    </tbody>
                                    
                                </table>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
</form>
</asp:Content>

