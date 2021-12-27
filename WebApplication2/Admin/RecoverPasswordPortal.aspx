<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="RecoverPasswordPortal.aspx.vb" Inherits="TrustAcademyPortal.RecoverPasswordPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdateProgress ID ="progretrieve" runat ="server" AssociatedUpdatePanelID ="UpdatePanel1"  >
        <ProgressTemplate>
            <div style="height:100%;width:100%;position:fixed;opacity:0.6;z-index:999;margin:auto;background-color:lightgray;">
                       <img alt="image" src="../Images/Loader.gif" class="center" />
                                         Processing.... 
                  </div>
        </ProgressTemplate>

    </asp:UpdateProgress>

   
    <h1>Retrieve Password</h1>
    <div style ="display:flex;flex-direction:column">
        <div>
                <asp:Label ID="Label2" runat="server" Text="Enter the Email Address you provided when you created your account : " style="float:left;font-size:smaller"></asp:Label>
        </div>

   <div>
          <asp:TextBox ID="TextBox1" runat="server" cssclass="inputtext" placeholder="Email" AutoPostBack="True"></asp:TextBox>
   </div>

        <asp:Panel ID ="pnlSecurity" runat ="server" Visible ="false">
                <div>
                <asp:Label ID="lbQuestion" runat="server" Text="Security Question: " style="float:left;font-size:smaller"></asp:Label>
        </div>
              <div>
          <asp:TextBox ID="txtPasswordQ" runat="server" cssclass="inputtextReadOnly" placeholder="Security Question" ReadOnly="true"></asp:TextBox>
   </div>
                          <div>
                <asp:Label ID="Label1" runat="server" Text="Security Answer: " style="float:left;font-size:smaller"></asp:Label>
        </div>
                   <div>
          <asp:TextBox ID="txtPasswordA" runat="server" cssclass="inputtext" placeholder="Provide Answer to Security Question"></asp:TextBox>
   </div>
        </asp:Panel>
         

 
    </div>
  
            <asp:UpdatePanel ID="UpdatePanel1"  runat ="server">
        <ContentTemplate>
                  <div>
            <asp:Button ID="Button1" runat="server" Text="RetrievePassword" cssclass="btn" />
    </div>
               
 <div>
      <asp:Label ID="Errorstatus" runat="server" ForeColor="Red"></asp:Label>
 </div>

        </ContentTemplate>
    </asp:UpdatePanel>


       
      
</asp:Content>
