<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Application.Master" CodeBehind="RecoverPasswordOnlineApplication.aspx.vb" Inherits="TrustAcademyPortal.Forgot_Password" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="appformdiv" style ="display:flex;flex-direction:column">

                                       <asp:UpdateProgress ID ="progretrieve" runat ="server" AssociatedUpdatePanelID ="pnlSave"  >
        <ProgressTemplate>
            <div style="height:100%;width:100%;position:fixed;opacity:0.6;z-index:999;margin:auto;background-color:lightgray;">
                       <img alt="image" src="../Images/Loader.gif" class="center" style="height: 150px" />
                                         Processing.... 
                  </div>
        </ProgressTemplate>

    </asp:UpdateProgress>
            

        
    <asp:Label ID="Label2" runat="server" Text="Enter your Email Below and you will receive instructions on how to Reset your password" style="float:left;font-size:smaller"></asp:Label>
   <div>
          <asp:TextBox ID="TextBox1" runat="server" cssclass="inputtext" placeholder="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="TextBox1" ErrorMessage="E-mail Required"></asp:RequiredFieldValidator>


   </div>
 
    </div>

     <asp:UpdatePanel ID ="pnlSave" runat ="server">
                        <ContentTemplate>

    <div class="appformdiv">
         <div>
            <asp:Button ID="Button1" runat="server" Text="Reset Password" cssclass="btn" />
    </div>
    </div>

                                  <asp:Button ID="Button13" style="display:none" runat ="server" Text="Cancel" />    

     <ajaxtoolkit:modalpopupextender ID="ModalPopupExtender_Creater" runat="server" BehaviorID="btnConfirmPopUp_ModalPopupExtender" TargetControlID="Button13"
                         PopupControlID="pnlCreateUserResultPopup"    BackgroundCssClass="modalBackground_Transparent">
                     </ajaxtoolkit:modalpopupextender>
                
           
            <asp:Panel runat="server" ID="pnlCreateUserResultPopup" Style="width:200px;border:solid;" CssClass ="modalPopup" BorderStyle="None" ForeColor="White" HorizontalAlign="Center"  >
       <div>
           <asp:Label ID ="lbCreateUserResults" runat ="server" ></asp:Label>
       </div>
             
       <div>
            <asp:Button runat="server" ID="hideResultsModalPopupViaServer" Text="Ok"  CausesValidation="False" />
       </div>
                  </asp:Panel>

   </ContentTemplate>
  </asp:UpdatePanel>
       
      
</asp:Content>
