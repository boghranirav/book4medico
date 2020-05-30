<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_side_masterpage1.master" AutoEventWireup="true" CodeFile="admin_doctor_deatils.aspx.cs" Inherits="Admin_admin_doctor_deatils" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<h1 class="page-header">Doctor Detail </h1>
			<form runat="server">
                <table>
                    <tr>
                        <td><label> Status : </label></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <asp:RadioButton ID="block" runat="server" GroupName="status" 
                                oncheckedchanged="block_CheckedChanged" Text="Block" AutoPostBack="True"/>
                            <asp:RadioButton ID="unblock" runat="server" GroupName="status" Text="Un-Block" 
                                AutoPostBack="True" oncheckedchanged="unblock_CheckedChanged"/>
                        </td>
                    </tr>
                </table>
            </form>
			<div class="row">
			    <div class="col-md-12">
			        <div class="panel panel-inverse">
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title">List of Doctors</h4>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered">
                                    <thead>
                                        
                                    </thead>
                                    <tbody id="tbl_disp" runat="server">
                                        
                                        
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

</asp:Content>

