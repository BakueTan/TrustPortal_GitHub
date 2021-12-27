<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Admin.Master" CodeBehind="frmBillingCutOff.aspx.vb" Inherits="TrustAcademyPortal.frmBillingCutOff" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>

   <div>
       <h1>MAINTAIN EXAMS BILLING CUT OFF</h1>
   </div>
       <div class ="appformdiv">
             <asp:Label ID="Label1" runat="server" Text="Cut Off Period" style="float:left;font-size:small"></asp:Label>

                  <div>
           <asp:DropDownList ID="dpCutOffPeriod" runat="server" DataSourceID="dsPAstelPeriods" DataTextField="Description" DataValueField="Period" CssClass="ddlinput">
</asp:DropDownList>
         
       </div
       </div>

       <div class="appformdiv">
             <div>
           <asp:Button ID="Button1" runat="server" Text="Update" cssclass="btn" />
       </div>
       </div>
     

         
       <div class ="appformdiv">
             <div>
                   <asp:Label ID="lbstatus" runat="server" Text=""></asp:Label>
           </div>
       </div>
         

                
<asp:SqlDataSource ID="dsPAstelPeriods" runat="server" ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" SelectCommand="SELECT [Description], [Period] FROM [PaymentPeriods2]"></asp:SqlDataSource>
      </div>
</asp:Content>
