<%@ Page Title="" Language="C#" MasterPageFile="~/user_master.master" AutoEventWireup="true" CodeFile="viewappointment.aspx.cs" Inherits="viewappointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript">
     function deleteappfunction(id1) {
         if (confirm("Are you sure you want to delete?")) {
             window.location.href = "deleteorcancelapp.aspx?appid=" + id1;

         }

     }
     function cancelappfunction(id2) {
         if (confirm("Are you sure you want to cancel?")) {
             window.location.href = "deleteorcancelapp.aspx?appid=" + id2;

         }

     }
     function deletereviewfunction(id3) {
         if (confirm("Are you sure you want to delete?")) {
             window.location.href = "deletereview.aspx?fbid=" + id3;

         }

     }
</script>
 <div class="row">
   <div class="col-lg-10 col-lg-offset-1" style="margin-top:1.5cm;">
   <form runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
   </asp:ScriptManager>
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <Triggers>
              <asp:AsyncPostBackTrigger ControlID="rdbup" EventName="CheckedChanged" />
               
      </Triggers>
      <Triggers>
              <asp:AsyncPostBackTrigger ControlID="rdbpast" EventName="CheckedChanged" />
      </Triggers>
   <ContentTemplate >
   
       <asp:RadioButton ID="rdbup" runat="server"  Checked="true" 
           Text="Upcoming Appointment" AutoPostBack="True" GroupName="appointment" 
           oncheckedchanged="rdbup_CheckedChanged"/>
       &nbsp;&nbsp;<asp:RadioButton ID="rdbpast" runat="server"  
           Text="Past Appointment" oncheckedchanged="rdbpast_CheckedChanged" 
           AutoPostBack="True" GroupName="appointment" />
       <br/>
        <br/>
        <div class="table-responsive">
        <table  class="table table-bordered">
                 <tbody ID="booktableid" runat="server">
                 </tbody>
             
        </table>
       
               
        </div>
       <div class="table-responsive">
       <table class="table">
       <tbody ID="reviewid" runat="server">
                 </tbody>
        </table>
       </div>
       
          </ContentTemplate>
   </asp:UpdatePanel>
 
     </form>
   </div>
   
 </div>
</asp:Content>

