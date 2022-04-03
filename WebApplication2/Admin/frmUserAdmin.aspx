<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Admin.Master" CodeBehind="frmUserAdmin.aspx.vb" Inherits="TrustAcademyPortal.frmUserAdmin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divMainStandard">
        <div>
            <h1>RESET STUDENT PASSWORD</h1>
        </div>

        <div class="appformdiv">
                  <asp:Label ID="Label1" runat="server" Text="UserName:" style="float:left;font-size :small"></asp:Label> 
            <div>
                  <asp:TextBox ID="txtUserName" runat="server" cssclass="inputtext" placeholder="UserName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="txtUserName" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>

        </div>
 
    <div class="appformdiv">
                 <asp:Label ID="Label2" runat="server" Text="ResetPassword:" style="float:left;font-size:small"></asp:Label>
        <div>
              <asp:TextBox ID="txtPassword" runat="server" CssClass="inputtext" placeholder="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div style="display:flex;flex-direction:row;">
          <div class ="appformdiv">
 <div>
        <asp:Button ID="Button1" runat="server" Text="ResetUser" cssclass="btn" />
  </div>
      </div>
 
    <div class="appformdiv">
 <div>
                <asp:Button ID="Button2" runat="server" Text="Clear Inputs" CssClass="btn" />
        </div>
    </div>
    </div>
    
       
  <div class="appformdiv">
        <div>
         <asp:Label ID="lbreset" runat="server"></asp:Label>

   </div>
  </div>
 
    
            </div>
</asp:Content>
