<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_side_masterpage1.master" AutoEventWireup="true" CodeFile="admin_view_clinic_photos.aspx.cs" Inherits="Admin_admin_view_clinic_photos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server">
			<h1 class="page-header">Clinic Photos </h1>

            <div class="superbox" data-offset="54" id="img_g" runat="server">		
            </div>

            <br />
    <asp:Button ID="Button1" runat="server" Text="Back" OnClientClick="JavaScript: window.history.back(1); return false;" CssClass="btn btn-primary"/>
</form>
</asp:Content>

