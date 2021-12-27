<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="CreateUserPortal.aspx.vb" Inherits="TrustAcademyPortal.CreateUser" 
    title="StudentPortal" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <div>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server"  CompleteSuccessText="" Width="100%">
        <CreateUserButtonStyle CssClass="LoginStatus" />
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" >
                <ContentTemplate>
                 <div style="display :flex;flex-direction:column;width:50%;margin:auto">

           
                      <div class ="appformdiv">
                                                       <h1> Sign Up for Your New Account</h1> 
                           </div>
                       
                                
                            <div class ="appformdiv">
                                  <asp:TextBox ID="UserName" runat="server" CssClass="inputtext" placeholder="UserName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                    ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </div>
                              
                      
                         <div class ="appformdiv">
                             <div>
                                  <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="inputtext" placeholder="Password"></asp:TextBox>
                             </div>
                             <div>
                                 <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="Password is required." 
                                    ToolTip="Password is required." ValidationGroup="CreateUserWizard1" 
                                    Font-Size="Smaller">*At least 6 charcters</asp:RequiredFieldValidator>
                             </div>
                               
                                
                         </div>
                             
                        
                           <div class ="appformdiv">
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="inputtext" placeholder="Confirm Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmPassword" 
                                    ErrorMessage="Confirm Password is required." 
                                    ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                           </div>
                               
                    <div class ="appformdiv">
                        <asp:TextBox ID="Email" runat="server" CssClass="inputtext" placeholder="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                    ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                    ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                    </div>
                         <div class ="appformdiv">
                             <asp:TextBox ID="Question" runat="server" CssClass="inputtext" placeholder="Security Question"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                    ControlToValidate="Question" ErrorMessage="Security question is required." 
                                    ToolTip="Security question is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                         </div>
                                
                        <div class ="appformdiv">
                            <asp:TextBox ID="Answer" runat="server" CssClass="inputtext" placeholder="Security Answer"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                    ControlToValidate="Answer" ErrorMessage="Security answer is required." 
                                    ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </div>
                                
                         <div class ="appformdiv">
                              <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                    ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    Display="Dynamic" 
                                    ErrorMessage="The Password and Confirmation Password must match." 
                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                         </div>
                               
                      <div class ="appformdiv">
                           <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                      </div>
                               
                           </div>
                       
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
    </asp:CreateUserWizard>
    <div>
          <asp:Label ID="lbCreateUser" runat="server" Font-Size="Larger" ForeColor="Red"></asp:Label>
    </div>
          </div> 
</asp:Content>
