<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Application.Master" CodeBehind="RegConfirm.aspx.vb" Inherits="TrustAcademyPortal.RegConfirm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 


  <asp:Button ID="Button13" style="display:none" runat ="server" Text="Cancel" />    

     <ajaxtoolkit:modalpopupextender ID="ModalPopupExtender_Creater" runat="server" BehaviorID="btnConfirmPopUp_ModalPopupExtender" TargetControlID="Button13"
                         PopupControlID="pnlCreateUserResultPopup"    BackgroundCssClass="modalBackground_Transparent">
                     </ajaxtoolkit:modalpopupextender>
                
           
            <asp:Panel runat="server" ID="pnlCreateUserResultPopup" Style="width:200px;border:solid;" CssClass ="modalPopup" BorderStyle="None" ForeColor="White" HorizontalAlign="Center"  >
       <div>
           <asp:Label ID ="lbCreateUserResults" runat ="server" ></asp:Label>
       </div>
             
       <div>
            <asp:Button runat="server" ID="hideResultsModalPopupViaServer" Text="Ok"  CausesValidation="False"  />
       </div>
                  </asp:Panel>
</asp:Content>
