<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="ChangePasswordPortal.aspx.vb" Inherits="TrustAcademyPortal.WebForm3" 
    title="StudentPortal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style8
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="divMainLogin"

             
                        <div>

                    
                     <div class="appformdiv">
                          <h3 style="margin:auto;"> Change Your Password</h3> 
                     </div>
                                              
                                      <div>
                                           <asp:TextBox ID="CurrentPassword" runat="server" 
                                                    TextMode="Password" CssClass ="inputtext" Placeholder ="Current Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" 
                                                    ControlToValidate="CurrentPassword" ErrorMessage="Password is required." 
                                                    ToolTip="Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                      </div>
                                               
                                        <div>
                                             <asp:TextBox ID="NewPassword" runat="server" 
                                                    TextMode="Password" CssClass ="inputtext" Placeholder ="New Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" 
                                                    ControlToValidate="NewPassword" ErrorMessage="New Password is required." 
                                                    ToolTip="New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                        </div>
                                     <div>
                                           <asp:TextBox ID="ConfirmNewPassword" runat="server" 
                                                    TextMode="Password" CssClass ="inputtext" Placeholder ="Cornfirm Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" 
                                                    ControlToValidate="ConfirmNewPassword" 
                                                    ErrorMessage="Confirm New Password is required." 
                                                    ToolTip="Confirm New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                     </div>
                                        <div>
                                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" 
                                                    ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                                    Display="Dynamic" 
                                                    ErrorMessage="The Confirm New Password must match the New Password entry." 
                                                    ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                        </div>
                                                
                                           <div>
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                           </div>
                                           
                        <div style="display:flex;flex-direction:row;">
                            <div class="appformdiv">
                                             <asp:Button ID="ChangePasswordPushButton" runat="server" 
                                                    CommandName="ChangePassword" 
                                                    Text="Change Password" ValidationGroup="ChangePassword1" OnClick="ChangePasswordPushButton_Click" CssClass="btn" />
                                    </div>
                                           
                                           
                                           <div class="appformdiv">
                                                <asp:Button ID="CancelPushButton" runat="server" 
                                                    CausesValidation="False" CommandName="Cancel" 
                                                    Text="Cancel" CssClass="btn" />
                                           </div>
                        </div>
                                    
                                               
                                </div>
           
                  
  </div>

                          <asp:Button ID="Button13" style="display:none" runat ="server" Text="Cancel" />              
                                            
                     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender_Creater" runat="server" BehaviorID="btnConfirmPopUp_ModalPopupExtender" TargetControlID="Button13"
                         PopupControlID="pnlCreateUserResultPopup"    BackgroundCssClass ="modalBackground">
                     </ajaxToolkit:ModalPopupExtender>
                
           
            <asp:Panel runat="server" ID="pnlCreateUserResultPopup" CssClass ="modalPopup"  HorizontalAlign="Center"  >
       <div>
           <asp:Label ID ="lbCreateUserResults" runat ="server" ></asp:Label>
       </div>
             
       <div>
            <asp:Button runat="server" ID="hideResultsModalPopupViaServer" Text="Ok"  CausesValidation="False" />
       </div>
           
               
      
    </asp:Panel>
                  
                  
</asp:Content>
