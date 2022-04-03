<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Admin.Master" CodeBehind="ApproveApplication.aspx.vb" Inherits="TrustAcademyPortal.ApproveApplication" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
        <div class="divMainStandard">
    <asp:UpdateProgress runat ="server" ID ="offerprogress" AssociatedUpdatePanelID ="pnlApproveApp">
      <ProgressTemplate>
                 <div class ="modal">
                         <div class="center">
                               
            <img alt="" src="../../Images/Loader.gif" />

                   Updating Application...    
                               
        </div>
                   </div>
      </ProgressTemplate>
  </asp:UpdateProgress>
 
            <div class="appformdiv">
                    <h1 style ="width :50%;margin:auto;">APPLICATION</h1>
            </div>
         

               <div class="appformdiv">
               
               <div class="appformdiv">
                   <asp:label ID="lbMessage" runat="server"  text="NO FURTHER CHANGES CAN BE DONE TO THE APPLICATION, DECISION HAS ALREADY BEEN MADE. " ForeColor="Red"></asp:label>
                                </div>
           </div>
              
             <div class="appformdiv">
                                     <asp:Label ID ="lbusertype" runat ="server" Text ="Application Reference" float ="left" Font-Size="XX-Small"></asp:Label>
                 <div>
 <asp:TextBox ID="txtAppRef" runat="server" CssClass="inputtextReadOnly" placeholder ="Appication Reference" ReadOnly ="true" ></asp:TextBox>
                 </div>
                    
          
                </div>
                  <div class="appformdiv">
              <asp:Label ID ="Label29" runat ="server" Text ="StudentID" float ="left" Font-Size="XX-Small"></asp:Label>

                              <div>
                   <asp:TextBox ID="txtStudentID" runat="server" CssClass ="inputtextReadOnly" ReadOnly ="true" placeholder="StudentID not yet Assigned"></asp:TextBox>
                                </div>
           </div>

           <div class="appformdiv">
              <asp:Label ID ="Label3" runat ="server" Text ="First Name" float ="left" Font-Size="XX-Small"></asp:Label>

                              <div>
                   <asp:TextBox ID="txtFirstNAme" runat="server" CssClass ="inputtextReadOnly" placeholder ="First Name" ReadOnly ="true"></asp:TextBox>
                                </div>
           </div>
              

         
            <div class="appformdiv">
                   <asp:Label ID ="Label4" runat ="server" Text ="Last Name" float ="left" Font-Size="XX-Small"></asp:Label>
                <div>
                     <asp:TextBox ID="txtLastName" runat="server" CssClass="inputtextReadOnly" placeholder ="Last Name"  ReadOnly ="true"></asp:TextBox>
          
                </div>
            </div>
                 
    
            <div class="appformdiv">
                   <asp:Label ID ="Label5" runat ="server" Text ="DOB" float ="left" Font-Size="XX-Small"></asp:Label>
                               <div >
                          <asp:TextBox ID="txtDOB" runat="server" TextMode="SingleLine"  CssClass="inputtextReadOnly" placeholder ="Date Of Birth" ReadOnly="true"></asp:TextBox>
          
             
            </div>
        </div>
             
        
            <div class="appformdiv">
                  <asp:Label ID ="Label6" runat ="server" Text ="Gender" float ="left" Font-Size="XX-Small"></asp:Label>
                <div>
                    <asp:TextBox ID="txtgender" runat="server"  CssClass="inputtextReadOnly"  Placeholder ="Gender" ReadOnly="true"></asp:TextBox>
                    
            
                </div>
            </div>
        
               
         

     <div class="appformdiv">
           <asp:Label ID ="Label7" runat ="server" Text ="Email" float ="left" Font-Size="XX-Small"></asp:Label>
                <div>
                      <asp:TextBox ID="txtEmail" runat="server" CssClass="inputtextReadOnly" placeholder="Email Address" ReadOnly="true"></asp:TextBox>
           
                </div>
    
     </div>
               
            <div class="appformdiv">
                 <asp:Label ID ="Label8" runat ="server" Text ="Contact" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                      <asp:TextBox ID="txtcontact" runat="server" CssClass="inputtextReadOnly" placeholder ="Contact not Submitted" ReadOnly="true" ></asp:TextBox>
                </div>
            </div>

                 <div class="appformdiv">
                 <asp:Label ID ="Label36" runat ="server" Text ="Previously Enrolled with TrustAcademy" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                      <asp:TextBox ID="txtPreviousEnrollment" runat="server" CssClass="inputtextReadOnly" placeholder ="PreviousEnrollment not Submitted" ReadOnly="true" ></asp:TextBox>
                </div>
            </div>
     
             
    <div class="appformdiv"> 
            <asp:Label ID ="Label9" runat ="server" Text ="Occupation" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                     <asp:TextBox ID="txtoccupation" runat="server" CssClass="inputtextReadOnly"  placeholder ="Occupation Not Submitted" ReadOnly="true"></asp:TextBox>
                </div>
    </div>
  
            
   <div  class="appformdiv">
         <asp:Label ID ="Label10" runat ="server" Text ="Work Phone" float ="left" Font-Size="XX-Small"></asp:Label>
                <div>
                    <asp:TextBox ID="txtworkphone" runat="server" CssClass="inputtextReadOnly"  placeholder ="No Phone Submitted" ReadOnly="true"></asp:TextBox>
                </div>
   </div>

               

            <div class="appformdiv">
                  <asp:Label ID ="Label11" runat ="server" Text ="Address" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                    <asp:TextBox ID="txtAdd1" runat="server"  CssClass="inputtextReadOnly"  placeholder ="Address not Submitted" ReadOnly="true"></asp:TextBox>
                                 
                </div>
            </div>
  
                    <div class="appformdiv">
                  <asp:Label ID ="Label32" runat ="server" Text ="Address" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                    <asp:TextBox ID="txtNokName" runat="server"  CssClass="inputtextReadOnly"  placeholder ="NokName not Submitted" ReadOnly="true"></asp:TextBox>
                                 
                </div>
            </div>

                          <div class="appformdiv">
                  <asp:Label ID ="Label33" runat ="server" Text ="NokAddress" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                    <asp:TextBox ID="TxtNokAdddress" runat="server"  CssClass="inputtextReadOnly"  placeholder ="NokAddress not Submitted" ReadOnly="true"></asp:TextBox>
                                 
                </div>
            </div>

                               <div class="appformdiv">
                  <asp:Label ID ="Label34" runat ="server" Text ="NokContact" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                    <asp:TextBox ID="txtNokContact" runat="server"  CssClass="inputtextReadOnly"  placeholder ="NokContact not Submitted" ReadOnly="true"></asp:TextBox>
                                 
                </div>
            </div>

                                   <div class="appformdiv">
                  <asp:Label ID ="Label35" runat ="server" Text ="NokEmail" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                    <asp:TextBox ID="txtNokEmail" runat="server"  CssClass="inputtextReadOnly"  placeholder ="NokEmail not Submitted" ReadOnly="true"></asp:TextBox>
                                 
                </div>
            </div>

               
            
                
            <div class="appformdiv">
                  <asp:Label ID ="Label12" runat ="server" Text ="Work Address" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                     <asp:TextBox ID="txtWorkAddress" runat="server" CssClass="inputtextReadOnly"  placeholder ="Work Adress not Submitted" ReadOnly="true" ></asp:TextBox>
                    </div>
            </div>
               
                    <div class="appformdiv">
              <asp:Label ID ="Label31" runat ="server" Text ="EntryType" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                     <asp:Textbox ID="txtEntryType" runat="server" CssClass="inputtextReadOnly"  Placeholder ="EntryType not Selected" ReadOnly="true"> </asp:Textbox>
                            </div>
   
          </div>
                    <div class="appformdiv">
              <asp:Label ID ="Label30" runat ="server" Text ="Campus" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                     <asp:Textbox ID="txtCampus" runat="server" CssClass="inputtextReadOnly"  Placeholder ="Campus not Selected" ReadOnly="true"> </asp:Textbox>
                            </div>
   
          </div>
  
          <div class="appformdiv">
              <asp:Label ID ="Label13" runat ="server" Text ="School" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                     <asp:Textbox ID="txtSchool" runat="server" CssClass="inputtextReadOnly"  Placeholder ="School not Selected" ReadOnly="true"> </asp:Textbox>
                            </div>
   
          </div>
                
            <div class="appformdiv">
                 <asp:Label ID ="Label14" runat ="server" Text ="Program" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                            <asp:TextBox ID="txtProgram" runat="server" CssClass="inputtextReadOnly"  Placeholder ="Program not Selected" ReadOnly="true"></asp:TextBox>
            
                </div>
     
            </div>
      
               
            <div class="appformdiv">
      <asp:Label ID ="Label15" runat ="server" Text ="Intake" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >

                <asp:TextBox ID="txtIntake" runat="server" CssClass="inputtextReadOnly"  Placeholder ="Intake not Selected" ReadOnly="true"></asp:TextBox>
                  
           
    </div>
            </div>
        
         <div class="appformdiv">
            <asp:Label ID ="Label16" runat ="server" Text ="Class" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                    <asp:TextBox ID="txtclass" runat="server" CssClass="inputtextReadOnly"  Placeholder ="Class not Selected" ReadOnly="true"></asp:TextBox>
                
                </div>
         </div>

                <div class="appformdiv" >
           <asp:Label ID ="Label26" runat ="server" Text ="Level" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                               <asp:TextBox ID="txtLevel" runat="server"  CssClass="inputtextReadOnly" Placeholder ="Level not selected" ReadOnly="true"></asp:TextBox>
            
                </div>
         </div>

                         <div class="appformdiv" >
           <asp:Label ID ="Label27" runat ="server" Text ="Semester" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                               <asp:TextBox ID="txtSemester" runat="server"  CssClass="inputtextReadOnly" Placeholder ="Semester not Selected" ReadOnly="true"></asp:TextBox>
            
                </div>
         </div>

               
         <div class="appformdiv" >
           <asp:Label ID ="Label17" runat ="server" Text ="Session" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                               <asp:TextBox ID="txtSession" runat="server"  CssClass="inputtextReadOnly" Placeholder ="Session not Selected" ReadOnly="true"></asp:TextBox>
            
                </div>
         </div>
<div>
                                                        <asp:GridView ID="dgSubjects" runat="server" AutoGenerateColumns="False" style="margin-top: 8px" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%">
                                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                       
               
                        <asp:BoundField DataField="Subject" HeaderText="Subjects" SortExpression="Subject" />
                    
                    </Columns>
                                                            <EmptyDataTemplate>
                                                                No Subjects Submitted
                                                            </EmptyDataTemplate>
                    <FooterStyle BackColor="#CCCCCC" /><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /><SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" /><SortedAscendingCellStyle BackColor="#F1F1F1" /><SortedAscendingHeaderStyle BackColor="#808080" /><SortedDescendingCellStyle BackColor="#CAC9C9" /><SortedDescendingHeaderStyle BackColor="#383838" />

                     </asp:GridView>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrustAcademyPortal.My.MySettings.soccerConnectionString %>" SelectCommand="SELECT s.Subject FROM StudSubs AS st INNER JOIN Subjects AS s ON s.SubjectID = st.subjectid WHERE (st.AppRef = @appref)">
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="appref" SessionField="AppReference" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                   </div>
                
      

  <div class="appformdiv">
    <asp:Label ID ="Label18" runat ="server" Text ="Marketing Method" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                     <asp:TextBox ID="txtKnowhow" runat="server" CssClass="inputtextReadOnly" Placeholder ="No option provided" ReadOnly="true"></asp:TextBox>
                         
               
                </div>
  </div>
        <div class="appformdiv">
            <asp:Label ID ="Label19" runat ="server" Text ="Income Source" float ="left" Font-Size="XX-Small"></asp:Label>
               
                <div >
                    
                <asp:TextBox ID="txtIncome" runat="server" CssClass="inputtextReadOnly" pplaceholder ="Income Source not provided " ReadOnly="true"></asp:TextBox>
       
                </div>
     
      </div>

            <div>
                <div>
                    
                </div>
            </div>
                
  
            <div style="font-weight: bold; text-decoration: underline " class="appformdiv">
                              Documents
            </div>

            <div style="display:flex;flex-direction:row;flex-wrap:wrap">

 
                </div>
           
                                               
                                                    <div>
                                                        <asp:GridView ID="gdFiles" runat="server" AutoGenerateColumns="False" style="margin-top: 8px" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField>
                        <ItemTemplate>
                            <%--<asp:LinkButton ID="lbDelete" runat="server" Text ="Delete" CommandName ="DeleteFiles" OnClientClick ="return confirm('Delete File?');"  CommandArgument='<%#Eval("fileref") %>'></asp:LinkButton>--%>
                            <asp:LinkButton ID="lbDownLoad" runat="server" CommandArgument='<%#Eval("fileref") %>' Text='<%# eval("FileName") %>' CommandName ="Download" CausesValidation ="false"/>
                            <%--<asp:Label ID ="lbfilename"  Text='<%#Eval("FileName") %>' runat ="server" Visible ="true"></asp:Label>--%>
                              <asp:Label ID ="lbFileType"  Text='<%#Eval("Filetype") %>' runat ="server" Visible ="true"></asp:Label>
                                                 <%--<asp:Label ID ="lbfilesize"  Text='<%#Eval("filesize") %>' runat ="server" ></asp:Label>--%>
                               <asp:Label ID ="lbdoc"  Text='<%#Eval("doc") %>' runat ="server" Visible ="false"></asp:Label>
                        </ItemTemplate>

                             </asp:TemplateField>
               
                        <asp:TemplateField HeaderText="FileSize (Kb)" SortExpression="FileSize">
                         
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FileSize") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DateUploaded" SortExpression="DateUploaded">
                 
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("DateUploaded") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                                                            <EmptyDataTemplate>
                                                                No Qualifications Found
                                                            </EmptyDataTemplate>
                    <FooterStyle BackColor="#CCCCCC" /><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /><SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" /><SortedAscendingCellStyle BackColor="#F1F1F1" /><SortedAscendingHeaderStyle BackColor="#808080" /><SortedDescendingCellStyle BackColor="#CAC9C9" /><SortedDescendingHeaderStyle BackColor="#383838" />

                     </asp:GridView></div>

                 <asp:Button ID="btnSubjects" runat ="server" style="display:none" />
                 <ajaxToolkit:ModalPopupExtender ID="SubjectsPopup_ModalPopupExtender" runat="server" BehaviorID="SubjectsPopup_ModalPopupExtender" TargetControlID="btnSubjects" PopupControlID ="SubjectsPopup"  BackgroundCssClass="modalBackground" OkControlID="btnOkSubjects"   PopupDragHandleControlID="PnlHeader" CancelControlID="imgcncel" OnCancelScript="hide()">
                 </ajaxToolkit:ModalPopupExtender>

                <asp:Panel ID ="SubjectsPopup" runat ="server"  CssClass="subjectsPopUp" PopupDragHandleControlID="PopupHeader" drag="true"  ScrollBars="Auto">
                    <asp:Panel ID ="PnlHeader" runat ="server" style="width:100%">
                        <div style="width:100%" class="appformdivrow">
                           
                            <div style="width:100%">
                                <asp:ImageButton ID="imgcncel" runat ="server" ImageUrl="~/images/close.png" Height ="15" style="float:right" />
                            </div>

                                                                                            </div>
                          </asp:Panel>
                   
                  <div>
<%--                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt"  WaitMessageFont-Names="Verdana" width="93%"
        WaitMessageFont-Size="14pt" Height="376px" SizeToReportContent="True" ZoomMode="PageWidth" ZoomPercent="75">
        
        <LocalReport ReportPath="Reports\RptAdmissionLetter2 - Backup.rdlc">
            <DataSources>
                
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="OfferLetter">
                </rsweb:ReportDataSource>
                
            </DataSources>
            
        </LocalReport>
        
    </rsweb:ReportViewer>  --%>         
                  </div>
         
                    <div style="width:100%">
                            <asp:Button ID="btnOkSubjects" runat ="server" Text ="OK" CausesValidation="False" CssClass="btn" style="width:50%;margin:auto"/>
                    </div>
                
                  

                 </asp:Panel>
           


      
               
            <ajaxToolkit:ResizableControlExtender ID="SubjectsPopup_ResizableControlExtender" runat="server" BehaviorID="SubjectsPopup_ResizableControlExtender" MaximumHeight="800" MaximumWidth="500" MinimumHeight="300" MinimumWidth="300" TargetControlID="SubjectsPopup" ResizableCssClass="resizable" HandleCssClass="handle"/>
          





                                             
                                                       <div class="appformdiv" >
           <asp:Label ID ="Label28" runat ="server" Text ="Student other Info" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                               <asp:TextBox ID="txtRemarks" runat="server"  CssClass="inputtextReadOnly" Placeholder ="No Further Info provided" ReadOnly ="true"></asp:TextBox>
            
                </div>
         </div>


                                        
            
           
             <div class="appformdiv">
            <asp:Label ID ="Label20" runat ="server" Text ="Date Applied" float ="left" Font-Size="XX-Small"></asp:Label>
                 
               
                <div >
                    
                <asp:TextBox ID="txtDateApplicationSubmitted" runat="server" CssClass="inputtextReadOnly" placeholder="Date Application Submitted not Captured" ReadOnly="true"></asp:TextBox>
       
                </div>
                 </div>
               <div class="appformdiv">
          
                 <asp:Label ID ="Label21" runat ="server" Text ="Date Decision Made" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                    
                <asp:TextBox ID="TxtDateDecisionMade" runat="server" CssClass="inputtextReadOnly" placeholder="Decision not yet made" ReadOnly="true"></asp:TextBox>
       
                </div>
     
      </div>
               <div class="appformdiv">
         
                 <asp:Label ID ="Label22" runat ="server" Text ="Date Student Responded" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                    
                <asp:TextBox ID="txtDateStudentResponded" runat="server" CssClass="inputtextReadOnly" placeholder ="No Response yet from Student" ReadOnly="true"></asp:TextBox>
       
                </div>
     
      </div>
                  <div class="appformdiv">
          
                 <asp:Label ID ="Label23" runat ="server" Text ="Student's Response" float ="left" Font-Size="XX-Small"></asp:Label>
                <div >
                    
                <asp:TextBox ID="txtStudentResponse" runat="server" CssClass="inputtextReadOnly" placeholder ="Student's Response Pending" ReadOnly="true"></asp:TextBox>
       
                </div>
     
      </div>
                 <div class="appformdiv">
                       <asp:Label ID ="Label25" runat ="server" Text ="Decision" float ="left" Font-Size="XX-Small"></asp:Label>
                         <div>
                   <asp:DropDownList ID="DpChangeStatus" runat="server" CssClass="ddlinput">
                            <asp:ListItem Value="-1">Decision</asp:ListItem>
                                           <asp:ListItem>Declined</asp:ListItem>
                    <asp:ListItem>Approved</asp:ListItem>
                           <asp:ListItem>Decision Withheld</asp:ListItem>
                <asp:ListItem>Decision Withdrawn</asp:ListItem>

                   
                </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dpChangeStatus" ErrorMessage="*" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
            </div>
                 </div>
                   
        
            <div class="appformdiv">
                  <asp:Label ID ="Label24" runat ="server" Text ="Comment" float ="left" Font-Size="XX-Small"></asp:Label>
                 <div>
                       
                 <asp:TextBox ID="TextComment" runat="server" CssClass="inputtext" placeholder="Comment" TextMode="MultiLine" ></asp:TextBox>
       
            </div>
            </div>
           
       <asp:UpdatePanel ID="pnlApproveApp" runat="server">
           <ContentTemplate>

      
            <div style ="display:inline-flex;flex-flow:row;flex-wrap:wrap">
                <div class="appformdiv">
                         <asp:Button ID="btnUpdateApplication" runat="server" Text="Save" CssClass ="btn"  UseSubmitBehavior ="false" /> 
                </div>
                <div class="appformdiv">
                     <asp:Button ID="btnCancel" runat="server" Text="Cancel" cssclass="btnCancel" CausesValidation="False" />
                </div>
            </div>
                  <div class="appformdiv">
                     <asp:Button ID="btnConfirmPopUp" style="display:none" runat ="server" Text="Cancel" />
                     <ajaxToolkit:ModalPopupExtender ID="btnConfirmPopUp_ModalPopupExtender" runat="server" BehaviorID="btnConfirmPopUp_ModalPopupExtender" TargetControlID="btnConfirmPopUp"
                         PopupControlID="ResultPopup"    BackgroundCssClass="modalBackground">
                     </ajaxToolkit:ModalPopupExtender>
                </div>
            <asp:Panel runat="server" ID="ResultPopup" Style=" display:none;width:200px;border:solid" CssClass ="modalPopup"  >
       <asp:Label ID ="lblAppSubmitResult" runat ="server" ></asp:Label>
                <br />
       
            <asp:Button runat="server" ID="hideModalPopupViaServer" Text="Ok"
                OnClick="hideModalPopupViaServer_Click" CausesValidation="False" />
      
    </asp:Panel>
                    </ContentTemplate>
           </asp:UpdatePanel>
            <div class="appformdiv">
            </div>
             
        

        </div>
       
</asp:Content>
