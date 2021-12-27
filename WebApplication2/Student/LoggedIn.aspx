<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="LoggedIn.aspx.vb" Inherits="TrustAcademyPortal._Default" 
    title="StudentPortal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divMain">
    <div class="appformdiv">
        <asp:Image runat="server" ImageUrl="~/Images/noimage.jpg" Height="256px" Width="256px" ID="imgStud"></asp:Image>  
    </div>
    <div class="appformdiv">
        <asp:Label ID="lbStudProgram" runat="server" Text=""></asp:Label>
    </div>
                    <div class="appformdiv">
                        <div>
                            <asp:Label ID ="lbRecoveryEmail" runat ="server" Text ="Password Recovery Email"></asp:Label>
                        </div>
                        <div>
                               <asp:TextBox ID = "recoveremail" runat="server" CssClass="inputtext" placeholder="Password Recovery Email"></asp:TextBox>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                runat="server" ControlToValidate="recoveremail" ErrorMessage="Invalid Email" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                              </div>
     
                  </div>
        <div>
              <asp:Button ID="Button2" runat="server" Text="UpdateEmail" CssClass="btn" />
                           </div>
        <div class="appformdiv">
            <asp:Label ID="lbStudEmailError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
         
      </div>
</asp:Content>


