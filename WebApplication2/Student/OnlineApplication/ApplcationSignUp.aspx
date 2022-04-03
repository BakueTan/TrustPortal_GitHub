<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Application.Master" CodeBehind="ApplcationSignUp.aspx.vb" Inherits="TrustAcademyPortal.ApplcationSignUp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            /*' display: inline-block;*/
        border-style: none;
            border-color: inherit;
            border-width: medium;
            font-style: normal;
            text-decoration: none;
            color: white;
            padding-bottom: 3px;
            padding-top: 3px; /*padding-left: 10px;*/;
            background-color: green;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="divMainLogin">

                                <asp:UpdateProgress ID ="progretrieve" runat ="server" AssociatedUpdatePanelID ="pnlSave"  >
        <ProgressTemplate>
            <div style="height:100%;width:100%;position:fixed;opacity:0.6;z-index:999;margin:auto;background-color:lightgray;">
                       <img alt="image" src="../../Images/Loader.gif" class="center" style="height: 150px" />
                                         Creating Account.... 
                  </div>
        </ProgressTemplate>

    </asp:UpdateProgress>
           

        <h1>Create Account</h1>
                <div class="appformdiv">
 <asp:TextBox ID="txtFullname" runat="server"  placeholder="Full Name" CssClass ="inputtext"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFullName" runat="server" ControlToValidate="txtFullname" ErrorMessage="Full Name Required"></asp:RequiredFieldValidator>
                          
        </div>

        <div class="appformdiv">
             <asp:TextBox ID="TextBox1" runat="server" CssClass ="inputtext" placeholder="E-mail"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="E-mail Required"></asp:RequiredFieldValidator>
        </div>
                 
                    

              
   <div class="appformdiv">
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="inputtext" placeholder ="Password"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
   </div>
                  
        <div class="appformdiv">
 <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" placeholder="Confirm Password" CssClass ="inputtext"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Confirm Password Required"></asp:RequiredFieldValidator>
                          
        </div>
                
             <asp:UpdatePanel ID ="pnlSave" runat ="server">
                        <ContentTemplate>         
   <div >
    <asp:Button ID="Button1" runat="server" Text="Create An Account" CssClass ="auto-style1"/>
   </div>
    <div class="appformdiv">

      <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="Passwords Must Match"></asp:CompareValidator>
    </div>

                                     <asp:Button ID="Button13" style="display:none" runat ="server" Text="Cancel" />    

     <ajaxtoolkit:modalpopupextender ID="ModalPopupExtender_Creater" runat="server" BehaviorID="btnConfirmPopUp_ModalPopupExtender" TargetControlID="Button13"
                         PopupControlID="pnlCreateUserResult"    BackgroundCssClass="modalBackground" PopupDragHandleControlID="pnlResultHeader">
                     </ajaxtoolkit:modalpopupextender>
                
           
            <asp:Panel runat="server" ID="pnlCreateUserResult" Style="width:200px;display:normal" CssClass ="modalPopup"   >
                  <asp:Panel ID ="pnlResultHeader" runat ="server" style="width:100%;background-color:black">
                     <asp:Label ID ="lblheader" Text="Online Application"  style="width:100%;text-align:center;font-weight:bold;color:white" runat ="server"></asp:Label>
                 </asp:Panel>

       <div>
           <asp:Label ID ="lbCreateUserResults" runat ="server" ></asp:Label>
       </div>
             
          <div style=" display:flex;background-color:lightgray;width:100%;padding-top:0.25em;padding-bottom:0.25em;justify-content:flex-end"  >
            <asp:Button runat="server" ID="hideResultsModalPopupViaServer" Text="Ok"  CausesValidation="False" style="width:25%;" />
       </div>
                  </asp:Panel>

                             </ContentTemplate>
             </asp:UpdatePanel>
    
        <div class="appformdiv">

        </div>
        <div class ="appformdiv">
            <div>
                Already have an Account ? <asp:HyperLink ID ="lbLogin" Text="Login" runat ="server" NavigateUrl="~/Student/OnlineApplication/ApplicationLogin.aspx"></asp:HyperLink>
            </div>
        </div>

    </div>

   
          



      
  



               
      

         
</asp:Content>
