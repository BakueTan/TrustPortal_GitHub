<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="RegisterSubjects.aspx.vb" Inherits="TrustAcademyPortal.RegisterSubjects" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdateProgress ID ="RegUpdateProgress" AssociatedUpdatePanelID ="UpdExamExntry" runat ="server">
        <ProgressTemplate>
            <div class="modal">
               

               
                       <img alt="image" src="../Images/Loader.gif" />
                                         Processing....</div> 
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID ="UpdExamExntry" runat="server">
        <ContentTemplate>



    <div class="divMain">


 
         
     <div style ="padding-top:2em;padding-bottom:2em;display:flex;flex-wrap:wrap">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black" Font-Size="Larger"></asp:Label>
     </div>

        <asp:panel  id ="pnlRegScreen" runat ="server"  class="divPanelMainRegVisible">

              <div id ="firstRowColumn" style="display:flex;flex-direction:column">
        <div>
        </div>
 
           
        <div>
<asp:panel runat ="server" id ="pnlCurrentEnrol">
      <asp:Panel runat ="server" ID ="pnlCurrentHeader">
           <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="White" BackColor="bLACK" Text=" Current Enrollment:"></asp:Label>
    </asp:Panel>
   <div style="display:flex;flex-direction:row;flex-wrap:wrap">

    <div>
  <asp:TextBox ID="txtProgram" runat="server" Width="59px" 
                    ReadOnly="True" Enabled ="false"></asp:TextBox>
    </div>
                <div>
    <asp:TextBox ID="txtLvl" runat="server" Width="28px" ReadOnly="True" Enabled="false" Height="16px"></asp:TextBox> 

                </div>
       <div> 
     <asp:Label ID="Label4" runat="server" Text="."></asp:Label>
               </div>
       <div>
                             <asp:TextBox ID="txtSem" runat="server" Width="28px" Enabled="false" Height="16px"></asp:TextBox>

       </div>
              </div>
         </asp:panel>
        </div>
             <div style="padding-top:0.5em;padding-bottom:0.5em">
            <asp:panel runat ="server" id ="pnlnextEnrollment"> 
                         <asp:Panel runat ="server" ID ="Panel8">
           <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="White" BackColor="BLACK" Text=" Next Enrollment:"></asp:Label>
    </asp:Panel>
                  <div style="display:flex;flex-direction:row;flex-wrap:wrap">
                <div>
                             <asp:TextBox ID="txtNxtLvl" runat="server" ReadOnly="True" Width="28px" Enabled="false" Height="16px"></asp:TextBox>
                    </div>
                      <div>
                               <asp:Label ID="Label2" runat="server" Text="."></asp:Label>
                      </div>
          
                      
                      <div>
                          <asp:TextBox ID="txtNxtSem" runat="server" ReadOnly="True"  Width="28px" Enabled="false" Height="16px"></asp:TextBox>
                      </div>
                 
                      <div>
                    <asp:Button ID="btnRetrieveLevelSubs" runat ="server" Text ="RetrieveSubjects" CssClass ="btn" visible="false"/>
                </div>

                      </div>
       
         </asp:panel>
                 </div>
      
        <div style="border-bottom-color:black;border-bottom:solid;border-bottom-width:thin;background-color:black;color:white;font-weight:bold">
                    SUBJECTS
                    
           </div> 
             <div>   
                <asp:GridView ID="gdSubjects" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="712px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkInclude" runat="server"  Checked ='<%# Bind("Slct") %>' Enabled ="true" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                          
                            <ItemTemplate>
                                <asp:dropdownlist ID="Register" runat="server" Text='<%# Bind("Register") %>'  Enabled = '<%# Bind("ChangeReg") %>'>
                                    <asp:ListItem Value ="Register" Text ="Register"></asp:ListItem>
                                    <asp:ListItem Value ="Drop" Text ="Drop" >Drop</asp:ListItem>
                                    </asp:dropdownlist>

                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="SubjectID" ReadOnly="True" DataField="SubjectID" HeaderStyle-HorizontalAlign ="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Subject">
                        
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Subject") %>'></asp:Label>
                            </ItemTemplate>
                             <CONTROLSTYLE Width="310px" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                                                <asp:BoundField DataField="Level" HeaderText="Level" ReadOnly="True"  HeaderStyle-HorizontalAlign="Left">
                    
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                                                          <asp:TemplateField HeaderText="Comment">
                                                             
                                                              <ItemTemplate>
                                                                  <asp:Label ID="lbComment" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                                                              </ItemTemplate>
                                                              <ControlStyle Width="310px" />
                                                              <HeaderStyle HorizontalAlign="Left" />
                                                              <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <EmptyDataTemplate>
                        <div>
                              No Subjects Found, Please Contact Exams Department for Assistance.
                        </div>
                      
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle  Font-Bold="True" ForeColor="black" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
        </div> 

 
  
    <div class="RegisterbuttonsDiv" >
             <asp:Panel runat ="server"  ID ="pnlRegister"> <asp:Button ID="btnRegister" runat="server" Text="Register"  CssClass ="RegButton" /></asp:Panel>
                  <asp:Panel runat ="server"  ID ="pnlReRegister" CssClass="divPanelMainRegHidden" >
                      <asp:Button ID="btnReRegister" runat="server" Text="Cancel Registration"  CssClass ="RegButton"  style="margin-left:0.5em"/></asp:Panel>
     </div>
    
    <asp:panel ID="pnlViewEnrollment" style="padding-bottom:1EM;padding-top:0.5em;" class="divPanelMainRegHidden" runat="server">
          <asp:HyperLink ID="hlViewEnrollmentForm" runat="server" NavigateUrl="~/Student/EnrolForm.aspx">Print Enrollment Form</asp:HyperLink>

      </asp:panel>


          <div style="padding-top:0.5em" >
          <asp:Panel runat ="server"  ID ="Panel1">
              <div style="background-color:black;color:white;font-weight:bold">
                  REGISTRATION INSTRUCTIONS</div>
            </asp:Panel> 
   </div>
 
       <div>
            <asp:Panel runat ="server"  ID ="Panel2" HorizontalAlign="Left">
              *To Register/Drop a Subject(s) , SELECT the Subject(s) and pick the appropriate STATUS for each Subject Selected and SAVE.</asp:Panel> 
       </div>
<div>
          <asp:Panel runat ="server"  ID ="Panel3" HorizontalAlign="Left">
              *Subjects which appear with a&nbsp; &quot;Register&quot; Status have not been Registered or have been dropped previously and can be registered again.</asp:Panel> 
</div>

     <div>
            <asp:Panel runat ="server"  ID ="Panel4" HorizontalAlign="Left">
              *Subjects which appear with&nbsp; a &quot;Drop&quot; Status are already Registered and can be Dropped.</asp:Panel> 
     </div>    

     <div>
           <asp:Panel runat ="server"  ID ="Panel5" HorizontalAlign="Left">
              * For assistance contact the Registrar&#39;s office.</asp:Panel> 
     </div>
        <div>
                      <asp:Panel runat ="server"  ID ="Panel6" HorizontalAlign="Left">
              <strong>NB:Subjects not SELECTED are not Registered/Dropped.</strong></asp:Panel> 

        </div>
                  </div>

            </asp:panel>

            </div>

       <asp:Button ID="Button13" style="display:none" runat ="server" Text="Cancel" />              
                                            
                     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender_Subjects" runat="server" BehaviorID="btnConfirmPopUp_ModalPopupExtender" TargetControlID="Button13"
                         PopupControlID="pnlSubjectsResultPopup"    BackgroundCssClass="modalBackground" PopupDragHandleControlID="ExamRegInfoHeader">
                     </ajaxToolkit:ModalPopupExtender>
                
           
            <asp:Panel runat="server" ID="pnlSubjectsResultPopup" CssClass ="modalPopup"  HorizontalAlign="left" Style=" display:normal;" >
   
                <asp:Panel ID ="ExamRegInfoHeader" runat="server" style="background-color:black">
                         <asp:Label ID ="Label7" runat ="server" Text="TAMS"  style="background-color:black;color:white;font-weight:bold"></asp:Label>

                </asp:Panel>
                <div style="padding-top:0.2em;padding-bottom:0.2em">
           <asp:Label ID ="lblUpadateSubjectsResults" runat ="server" ></asp:Label>
       </div>
             
       <div style="display:flex;justify-content:center;background-color:lightgray">
            <asp:Button runat="server" ID="hideResultsModalPopupViaServer" Text="Ok"  CausesValidation="False" class="btn"/>
       </div>
           
               
     
    </asp:Panel>

                                 <asp:Button ID="Button1" style="display:none" runat ="server" Text="Cancel" />              
                                            
                     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender_ConfirmReg" runat="server" BehaviorID="btnConfirmPopUp_ModalPopupExtender1" TargetControlID="Button1"
                         PopupControlID="pnlConfirmReg"    BackgroundCssClass="modalBackground">
                     </ajaxToolkit:ModalPopupExtender>
                
           
            <asp:Panel runat="server" ID="pnlConfirmReg"  CssClass ="modalPopup"  HorizontalAlign="Left" Style=" display:normal;"  >
       <div style="padding-bottom:0.5em">
           <asp:Label ID ="Label6" runat ="server" Text ="Register Subjects?" ></asp:Label>
       </div>
             
                <div style="display:flex;flex-direction:row;">
                    <div style="padding-right:0.1em">
            <asp:Button runat="server" ID="btnConfirmReg" Text="Ok"  CausesValidation="False" CssClass="btn"  Width="5em"/>
       </div>
                       <div>
            <asp:Button runat="server" ID="Button2" Text="Cancel"  CausesValidation="False"  CssClass="btnCancel" Width="5em" OnClientClick="changeColor('Yellow');" />
       </div>
                </div>
       
           
               
      
    </asp:Panel>
                    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
