<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_side_masterpage1.master" AutoEventWireup="true" CodeFile="admin_view_clinic.aspx.cs" Inherits="Admin_admin_view_clinic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server">
			<h1 class="page-header">Clinic Detail </h1>
			
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
                            <div class="table-responsive"  id="tbl_disp" runat="server">
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
<asp:Button ID="Button1" runat="server" Text="Back" OnClientClick="JavaScript: window.history.back(1); return false;" CssClass="btn btn-primary"/>
</form>
</asp:Content>

