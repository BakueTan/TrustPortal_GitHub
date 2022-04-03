<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MAsterPages/Application.Master" CodeBehind="ChangePasswordOnlineApplication.aspx.vb" Inherits="TrustAcademyPortal.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="divMainLogin">
     <div>
           <h1>Change Password</h1>
     </div>
                  
    
        <div class="appformdiv">
            <asp:TextBox ID="txtOldPassword" runat ="server" TextMode="Password" placeholder="Old Password" CssClass="inputtext"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtOldPassword"></asp:RequiredFieldValidator>
        
                   </div>
    
 
         <div class="appformdiv">
                <asp:TextBox ID="TextBox2" runat="server"  TextMode="Password" placeholder="New Password" CssClass="inputtext"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
         </div>
         
          
                <div class="appformdiv">
<asp:TextBox ID="TextBox3" runat="server" TextMode="Password" placeholder="Confirm Password" CssClass="inputtext"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passowrds must match" ControlToCompare="TextBox2" ControlToValidate="TextBox3"></asp:CompareValidator>
                  
                </div>

        <div>
              <asp:Button ID="Button1" runat="server" Text="Change" CssClass ="btn"/>
        </div>

        <div class="appformdiv">
                <asp:Label ID="ErrorStatus" runat="server" Text=""></asp:Label>
        </div>
  
      
             
    
           
    </div>
</asp:Content>
