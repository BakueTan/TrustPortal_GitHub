<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="CreateUserPortal_Custom.aspx.vb" Inherits="TrustAcademyPortal.CreateUser_Custom" 
    title="StudentPortal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
  
                 <div class="divMainLogin">
                             <asp:UpdateProgress ID ="progretrieve" runat ="server" AssociatedUpdatePanelID ="pnlSave"  >
        <ProgressTemplate>
            <div class="modal">
                       <img alt="image" src="../Images/Loader.gif"  style="height: 150px" />
                                         Creating User.... 
                  </div>
        </ProgressTemplate>

    </asp:UpdateProgress>

           
                      <div class ="appformdiv">
                                                       <h1> Sign Up for Your New Account</h1> 
                           </div>
                       
                                
                            <div class ="appformdiv">
                                  <asp:TextBox ID="UserName" runat="server" CssClass="inputtext" placeholder="UserName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" ErrorMessage="StudentID is required." 
                                    ToolTip="User Name is required." ></asp:RequiredFieldValidator>
                            </div>
                              
                      
                         <div class ="appformdiv">
                             <div>
                                  <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="inputtext" placeholder="Password"></asp:TextBox>
                             </div>
                             <div>
                                 <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="Password is required." 
                                    ToolTip="Password is required." 
                                    Font-Size="Smaller"></asp:RequiredFieldValidator>
                             </div>
                               
                                
                         </div>
                             
                        
                           <div class ="appformdiv">
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="inputtext" placeholder="Confirm Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmPassword" 
                                    ErrorMessage="Confirm Password is required." 
                                    ToolTip="Confirm Password is required." ></asp:RequiredFieldValidator>
                           </div>
                               
                    <div class ="appformdiv">
                        <asp:TextBox ID="Email" runat="server" CssClass="inputtext" placeholder="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                    ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                    ToolTip="E-mail is required." ></asp:RequiredFieldValidator>
                    </div>
                         <div class ="appformdiv">
                             <asp:TextBox ID="Question" runat="server" CssClass="inputtext" placeholder="Security Question"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                    ControlToValidate="Question" ErrorMessage="Security question is required." 
                                    ToolTip="Security question is required." ></asp:RequiredFieldValidator>
                         </div>
                                
                        <div class ="appformdiv">
                            <asp:TextBox ID="Answer" runat="server" CssClass="inputtext" placeholder="Security Answer"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                    ControlToValidate="Answer" ErrorMessage="Security answer is required." 
                                    ToolTip="Security answer is required." ></asp:RequiredFieldValidator>
                        </div>
                                
                     <asp:UpdatePanel ID ="pnlSave" runat ="server">
                        <ContentTemplate>

                      
   

                   
                               <div class ="appformdiv">
                                   <div>
                                   <asp:Button ID ="btnCreateUser" runat ="server" Text ="Create Account" CssClass="btn" />
                                   </div>
                                     <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                    ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    Display="Dynamic" 
                                    ErrorMessage="The Password and Confirmation Password must match." 
                                   ></asp:CompareValidator>

                               </div>
     
                        
      

    
                                           
                                <asp:Button ID="Button13" style="display:none" runat ="server" Text="Cancel" />              
                                            
                     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender_Creater" runat="server" BehaviorID="btnConfirmPopUp_ModalPopupExtender" TargetControlID="Button13"
                         PopupControlID="pnlCreateUserResultPopup"    BackgroundCssClass="modalBackground">
                     </ajaxToolkit:ModalPopupExtender>
                
           
            <asp:Panel runat="server" ID="pnlCreateUserResultPopup" Style="width:200px;display:none" CssClass ="modalPopup" BorderStyle="None"    >
                  <asp:Panel ID ="pnlResultHeader" runat ="server" style="width:100%;background-color:black">
                     <asp:Label ID ="lblheader" Text="Student Portal"  style="width:100%;text-align:center;font-weight:bold;color:white" runat ="server"></asp:Label>
                 </asp:Panel>
       <div>
           <asp:Label ID ="lbCreateUserResults" runat ="server" ></asp:Label>
       </div>
             
         <div style="display:flex;background-color:lightgray;width:100%;padding-top:0.25em;padding-bottom:0.25em;justify-content:flex-end" >
            <asp:Button runat="server" ID="hideResultsModalPopupViaServer" Text="Ok"  CausesValidation="False"  style="width:25%"/>
       </div>
           
               
      
    </asp:Panel>
                              </ContentTemplate>
                    </asp:UpdatePanel>
                               
                      <div class ="appformdiv">
                           <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                      </div>
                               
                           </div>
        

 
</asp:Content>
