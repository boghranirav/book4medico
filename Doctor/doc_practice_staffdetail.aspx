<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctor_side_masterpage2.master" AutoEventWireup="true" CodeFile="doc_practice_staffdetail.aspx.cs" Inherits="Doctor_doc_practice_staffdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
	    <div class="col-md-12">
            <div class="panel panel-inverse">
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Practice Staff Table</h4>
                    </div>
                    <div class="panel-body">
                        <table   class="table table-striped table-bordered" >
                            <thead>

                            </thead>
                            <tbody id="tbl_pstaff" runat="server">
                                
                            </tbody>
                        </table>
                    </div>
                </div>
        </div>
    </div>
</asp:Content>

