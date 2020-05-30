<%@ Page Title="" Language="C#" MasterPageFile="~/user_master.master" AutoEventWireup="true" CodeFile="account.aspx.cs" Inherits="account1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
            /*Calendar Control CSS*/
            .cal_Theme1 .ajax__calendar_container   {
            background-color: #DEF1F4;
            border:solid 1px #77D5F7;
            }

            .cal_Theme1 .ajax__calendar_header  {
            background-color: #ffffff;
            margin-bottom: 4px;
            }

            .cal_Theme1 .ajax__calendar_title,
            .cal_Theme1 .ajax__calendar_next,
            .cal_Theme1 .ajax__calendar_prev    {
            color: #004080;
            padding-top: 3px;
            }

            .cal_Theme1 .ajax__calendar_body    {
            background-color: #ffffff;
            border: solid 1px #77D5F7;
            }

            .cal_Theme1 .ajax__calendar_dayname {
            text-align:center;
            font-weight:bold;
            margin-bottom: 4px;
            margin-top: 2px;
            color: #004080;
            }

            .cal_Theme1 .ajax__calendar_day {
            color: #004080;
            text-align:center;
            }

            .cal_Theme1 .ajax__calendar_hover .ajax__calendar_day,
            .cal_Theme1 .ajax__calendar_hover .ajax__calendar_month,
            .cal_Theme1 .ajax__calendar_hover .ajax__calendar_year,
            .cal_Theme1 .ajax__calendar_active  {
            color: #004080;
            font-weight: bold;
            background-color: #DEF1F4;
            }

            .cal_Theme1 .ajax__calendar_today   {
            font-weight:bold;
            }

            .cal_Theme1 .ajax__calendar_other,
            .cal_Theme1 .ajax__calendar_hover .ajax__calendar_today,
            .cal_Theme1 .ajax__calendar_hover .ajax__calendar_title {
            color: #bbbbbb;
            }
</style>
  <div class="Row">
                   
			<form id="Form1"   runat="server" >
                             <asp:ScriptManager ID="ScriptManager1" runat="server">
                               </asp:ScriptManager>
                            <div class="col-lg-4 col-lg-offset-4" style="padding-top:2cm">
                            <h2>Profile Details</h2>
                            <br/>
                                <div class="form-group">
                                    <label>Patient Name :</label>
                                       <asp:TextBox ID="pt_name" CssClass="form-control" runat="server" Width="350px" ></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Patient Name." ControlToValidate="pt_name" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Enter Valid Name." ValidationExpression="^([a-zA-Z ]){2,40}$" ForeColor="Red" ControlToValidate="pt_name"></asp:RegularExpressionValidator>

                                </div>
                                <div class="form-group">
                                    <label>Email :</label>
                                     <asp:TextBox ID="u_email" CssClass="form-control" runat="server" Width="350px" ReadOnly="true"></asp:TextBox>
                                     
                                </div>
                               <div class="form-group">
                                    <label>BirthDate :</label>
                               
                                   <asp:TextBox ID="birth_date" runat="server" CssClass="form-control" Width="350px"></asp:TextBox>
                                     <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" 
                                        TargetControlID="birth_date" CssClass="cal_Theme1"/> 
                                </div>
                                
                                <div class="form-group">
                                    <label>Mobile No :</label>
                                       <asp:TextBox ID="u_mobile" CssClass="form-control" runat="server" Width="350px" ReadOnly="true" ></asp:TextBox>
                                </div>
                                
                                 <div class="form-group">
                                    <label>Gender :</label>
                                         <asp:RadioButton ID="rbmale" runat="server" Text=" Male"  GroupName="gender" />
                                         <asp:RadioButton ID="rbfemale" runat="server" Text=" Female" GroupName="gender"/>
                                </div>
                                
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="form-group">
                                   <asp:Button ID="done" runat="server"  
                                        CssClass="btn btn-primary font-additional hvr-wobble-bottom"  Text="Save" onclick="done_Click" 
                                        />
                                    <br />
                                    <br />
                      </div>
               </div>
          </form>
    </div>
</asp:Content>

