<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Admin.Master" CodeBehind="AssignStudentID.aspx.vb" Inherits="TrustAcademyPortal.AssignStudentID" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                 <div >
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="panel2"  >
               <ProgressTemplate >

                   <div class ="modal">
                         <div class="center">
                               
            <img alt="" src="../../Images/Loader.gif" />

                   Updating Application.......    
                               
        </div>
                   </div>
                 
                       
               </ProgressTemplate>
                           
                                                
           </asp:UpdateProgress>
                    </div>
     <div class ="divMain">
            <div class="appformdiv">
                    <h1 style ="width :50%;margin:auto;">ASSIGN STUDENTID</h1>
            </div>
         

           
              
             <div class="appformdiv">
                                     <asp:Label ID ="lbusertype" runat ="server" Text ="Application Reference" float ="left" Font-Size="XX-Small"></asp:Label>
                 <div>
 <asp:TextBox ID="txtAppRef" runat="server" CssClass="inputtext" placeholder ="Appication Reference" ReadOnly ="true" ></asp:TextBox>
                 </div>
                    
          
                </div>
         

           <div class="appformdiv">
              <asp:Label ID ="Label3" runat ="server" Text ="Full Name" float ="left" Font-Size="XX-Small"></asp:Label>

                              <div>
                   <asp:TextBox ID="txtFirstNAme" runat="server" CssClass ="inputtext" placeholder ="First Name" ReadOnly ="true"></asp:TextBox>
                                </div>
           </div>
  <%--        <div class="appformdiv">
              <asp:Label ID ="Label1" runat ="server" Text ="StudentID" float ="left" Font-Size="XX-Small"></asp:Label>

                              <div>
                   <asp:TextBox ID="txtStudentID" runat="server" CssClass ="inputtext" placeholder ="Student ID" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="txtStudentID" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
           </div>--%>
         <asp:UpdatePanel ID ="panel2" runat ="server">
             <ContentTemplate>

      
                  <div style ="display:inline-flex;flex-flow:row;flex-wrap:wrap">
                <div class="appformdiv">
                         <asp:Button ID="btnUpdateApplication" runat="server" Text="Assign" CssClass ="btn"  /> 
                </div>
                <div class="appformdiv">
                     <asp:Button ID="btnCancel" runat="server" Text="Cancel" cssclass="btnCancel" CausesValidation="False" />
                </div>
            </div>
            <div class="appformdiv">
            </div>
             
           <div class="appformdiv">
                     <asp:Button ID="btnConfirmPopUp" style="display:none" runat ="server" Text="Cancel" />
                     <ajaxtoolkit:modalpopupextender ID="btnConfirmPopUp_ModalPopupExtender" runat="server" BehaviorID="btnConfirmPopUp_ModalPopupExtender" TargetControlID="btnConfirmPopUp"
                         PopupControlID="ResultPopup"    BackgroundCssClass="modalBackground">
                     </ajaxtoolkit:modalpopupextender>
                </div>
            <asp:Panel runat="server" ID="ResultPopup" Style=" display:none;width:200px;border:solid" CssClass ="modalPopup"  >
       <asp:Label ID ="lblAppSubmitResult" runat ="server" ></asp:Label>
                <br />
       
            <asp:Button runat="server" ID="hideModalPopupViaServer" Text="Ok"
                OnClick="hideModalPopupViaServer_Click" CausesValidation="False" />
      
    </asp:Panel>
                   </ContentTemplate>
         </asp:UpdatePanel>
        </div>
     


              </div>
</asp:Content>
