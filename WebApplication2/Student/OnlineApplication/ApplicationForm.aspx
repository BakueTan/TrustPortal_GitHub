

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Application.Master" CodeBehind="ApplicationForm.aspx.vb" Inherits="TrustAcademyPortal.ApplicationForm" MaintainScrollPositionOnPostback="true" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >  
           


       <div class ="divMain">
             
                   <div class="appformdiv">
               <h1 class="HeaderWidth">APPLICATION FORM</h1>
           </div>

       

        
                    <asp:Wizard ID ="wzAppForm" runat ="server" ActiveStepIndex="1" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"  DisplayCancelButton="True" FinishCompleteButtonText="Close" Width ="100%" >
        <CancelButtonStyle CssClass="btnCancel" />
        <FinishCompleteButtonStyle CssClass="btn" />
        <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
        <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
        <NavigationStyle Wrap="False" />
        <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
        <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" HorizontalAlign="Justify"  CssClass ="SideBarWidth" />
        <StepStyle Font-Size="0.8em" ForeColor="#333333" />
        <WizardSteps>
            <asp:WizardStep ID="PersInfo" runat="server" Title="Personal Details" StepType="Start">
       
       <div class="appformdiv">
 <h2 style="text-decoration:underline">Personal Details</h2>
       </div>
           

            <div class="appformdiv" >
                 <asp:Label ID ="lbFirstName" runat ="server" Text ="First Name" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                               <div>
                    <asp:TextBox ID="txtFirstNAme" runat="server" CssClass ="inputtext" placeholder ="First Name" AutoPostBack="false"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="txtFirstNAme" ErrorMessage="First Name Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>
              

         
            <div class="appformdiv">
                      <asp:Label ID ="lbLastName" runat ="server" Text ="Last Name" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div>
                     <asp:TextBox ID="txtLastName" runat="server" CssClass="inputtext" placeholder ="Last Name" AutoPostBack="false" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorName0" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>
                 
    
            <div class="appformdiv">
                   <asp:Label ID ="lbdob" runat ="server" Text ="Date Of Birth" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                               <div >
                          <asp:TextBox ID="txtDOB" runat="server" TextMode="SingleLine"  CssClass="inputtext" placeholder ="Date Of Birth" AutoPostBack="false"  ></asp:TextBox>
             <ajaxToolkit:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" BehaviorID="txtDOB_CalendarExtender" Format="dd/MM/yyyy" TargetControlID="txtDOB">
             </ajaxToolkit:CalendarExtender>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorName8" runat="server" ControlToValidate="txtDOB" ErrorMessage="Date Of Birth Required" SetFocusOnError="True" ></asp:RequiredFieldValidator>
                </div>
            </div>

               <div class="appformdiv">
                      <asp:Label ID ="lbPOB" runat ="server" Text ="Place Of Birth" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                               <div >
                          <asp:TextBox ID="txtPOB" runat="server" TextMode="SingleLine"  CssClass="inputtext" placeholder ="Place Of Birth" AutoPostBack="false"></asp:TextBox>
           
             <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtPOB" ErrorMessage="Place Of Birth Required" SetFocusOnError="True" ></asp:RequiredFieldValidator>
                </div>
            </div>
       
             
        
            <div class="appformdiv">
                  
                <div>
                    <asp:DropDownList ID="dpgender" runat="server"  CssClass="ddlinput">
                       <asp:ListItem Value="-1">Select Gender</asp:ListItem>
                       <asp:ListItem>F</asp:ListItem>
                       <asp:ListItem>M</asp:ListItem>
                   </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorName1" runat="server" ControlToValidate="dpgender" ErrorMessage="Gender Required" SetFocusOnError="True"  Initialvalue ="-1"></asp:RequiredFieldValidator>
                </div>
            </div>
        
                   <div class="appformdiv">
                
                <div>
                    <asp:DropDownList ID="dpPreviouslyStudiedWithTrust" runat="server"  CssClass="ddlinput">
                       <asp:ListItem Value="-1">Have you been previously enrolled with Trust Academy</asp:ListItem>
                       <asp:ListItem>Yes</asp:ListItem>
                       <asp:ListItem>No</asp:ListItem>
                   </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="dpPreviouslyStudiedWithTrust" ErrorMessage="Field Required" SetFocusOnError="True"  Initialvalue ="-1"></asp:RequiredFieldValidator>
                </div>
            </div>
        
         

     <div class="appformdiv">
          <asp:Label ID ="lbEmail" runat ="server" Text ="Email" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
         
                <div>
                      <asp:TextBox ID="txtEmail" runat="server" CssClass="inputtext" placeholder="Email Address" ReadOnly ="true" AutoPostBack="false"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Address Required" SetFocusOnError="True"  ></asp:RequiredFieldValidator>

             <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Valid Email Address Required" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
                </div>
    
     </div>
               
            <div class="appformdiv">
                <asp:Label ID ="lbContact" runat ="server" Text ="Phone Number" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div >
                      <asp:TextBox ID="txtcontact" runat="server" CssClass="inputtext" placeholder ="Phone Number" AutoPostBack="false" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtcontact" ErrorMessage="Phone Number Required" SetFocusOnError="True"  ></asp:RequiredFieldValidator>
                </div>
            </div>
     
               <div class="appformdiv">
           <asp:Label ID ="lbNationalID" runat ="server" Text ="NationalID" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div >
                     <asp:TextBox ID="TxtNationalID" runat="server" CssClass="inputtext"  placeholder ="National ID" AutoPostBack="false"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNationalID" ErrorMessage="National ID Required" SetFocusOnError="True"  ></asp:RequiredFieldValidator>
                </div>
    </div>
    <div class="appformdiv">
           <asp:Label ID ="lbOccupation" runat ="server" Text ="Occupation" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div >
                     <asp:TextBox ID="txtoccupation" runat="server" CssClass="inputtext"  placeholder ="Occupation" AutoPostBack="false"></asp:TextBox>
                </div>
    </div>
  
            
   <div  class="appformdiv">
        <asp:Label ID ="lbWorkPhone" runat ="server" Text ="Work Phone" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div>
                    <asp:TextBox ID="txtworkphone" runat="server" CssClass="inputtext"  placeholder ="Work Phone" AutoPostBack="false"></asp:TextBox>
                </div>
   </div>

               

            <div class="appformdiv">
                 <asp:Label ID ="lbAddress1" runat ="server" Text ="Address 1" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div >
                    <asp:TextBox ID="txtAdd1" runat="server"  CssClass="inputtext"  placeholder ="Address 1" AutoPostBack="False"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorName2" runat="server" ControlToValidate="txtAdd1" ErrorMessage="Address Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>
  
       <div class="appformdiv" >
           <asp:Label ID ="lbAddress2" runat ="server" Text ="Address 2" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div>
                      <asp:TextBox ID="txtAdd2" runat="server" CssClass="inputtext"  placeholder ="Address 2" AutoPostBack="false"></asp:TextBox>
   
    </div>
       </div>
               
            <div class="appformdiv">
              <asp:Label ID ="lbAddress3" runat ="server" Text ="Address 3" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div >
                      <asp:TextBox ID="txtAddress4" runat="server"  CssClass="inputtext"   placeholder ="Address 3" AutoPostBack="false"></asp:TextBox>
                </div>
     
  
            </div>
                
            <div class="appformdiv">
                 <asp:Label ID ="lbWorkAddress" runat ="server" Text ="Work Address" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div >
                     <asp:TextBox ID="txtWorkAddress" runat="server"  CssClass="inputtext"  placeholder ="Work Adress" AutoPostBack="false" ></asp:TextBox>
                    </div>
            </div>

               <div class="appformdiv">
                 <asp:Label ID ="lbNokName" runat ="server" Text ="Next Of Kin Full Name" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div >
                     <asp:TextBox ID="txtNokName" runat="server"  CssClass="inputtext"  placeholder ="Next Of Kin Full Name" AutoPostBack="false" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNokName" ErrorMessage="Field Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
            </div>
               
                <div class="appformdiv">
                 <asp:Label ID ="lbNokAddress" runat ="server" Text ="Next Of Kin Address" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div >
                     <asp:TextBox ID="txtNokAddress" runat="server"  CssClass="inputtext"  placeholder ="Next Of Kin Address" AutoPostBack="false" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNokAddress" ErrorMessage="Address Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
            </div>

                     <div class="appformdiv">
                  <asp:Label ID ="lbNokContactNumber" runat ="server" Text ="Next Of Kin Contact Number" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div >
                     <asp:TextBox ID="txtNokContactNumber" runat="server"  CssClass="inputtext"  placeholder ="Next Of Kin Contact Number" AutoPostBack="false" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtNokContactNumber" ErrorMessage="Contact Number Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
            </div>

                  <div class="appformdiv">
               <asp:Label ID ="lbNokEmail" runat ="server" Text ="Next Of Kin Email Address" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                <div >
                     <asp:TextBox ID="txtNokEmail" runat="server"  CssClass="inputtext"  placeholder ="Next Of Kin Email Address" AutoPostBack="false" ></asp:TextBox>
                    </div>
            </div>
         
            </asp:WizardStep>

                <asp:WizardStep ID="EnrollmentInfo" runat="server" Title="Program/Course Details">
                    <div class="appformdiv">
                         <h2 style="text-decoration:underline">
                        Program Details
                    </h2>
                    </div>
                   
                            <div class="appformdiv">
                <div >
                     <asp:DropDownList ID="ddlCampus" runat="server" CssClass="ddlinput">
             <asp:ListItem Value="-1">Select Campus</asp:ListItem>
                 <asp:ListItem>Harare</asp:ListItem>
                 <asp:ListItem>Bulawayo</asp:ListItem>
                                    </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCampus" ErrorMessage="Campus Required" SetFocusOnError="True" Initialvalue ="-1"></asp:RequiredFieldValidator>
                </div>

          </div>
               

                     <div class="appformdiv">
            
                <div >
                     <asp:DropDownList ID="ddlEntryType" runat="server" AutoPostBack="True" CssClass="ddlinput">
             <asp:ListItem Value="-1">Select Entry Type</asp:ListItem>
                 <asp:ListItem>Normal</asp:ListItem>
                 <asp:ListItem>Mature</asp:ListItem>
                         <asp:ListItem>Special</asp:ListItem>
             </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlEntryType" ErrorMessage="Entry Type Required" SetFocusOnError="True" Initialvalue ="-1"></asp:RequiredFieldValidator>
                </div>
   </div>
  
          <div class="appformdiv">
            
                <div >
                     <asp:DropDownList ID="dpSchool" runat="server" AutoPostBack="True" CssClass="ddlinput">
             <asp:ListItem Value="-1">Select School</asp:ListItem>
                 <asp:ListItem>IT</asp:ListItem>
                 <asp:ListItem>Business School</asp:ListItem>
                   <asp:ListItem>High School</asp:ListItem>
          
             </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorName9" runat="server" ControlToValidate="dpSchool" ErrorMessage="School Required" SetFocusOnError="True" Initialvalue ="-1"></asp:RequiredFieldValidator>
                </div>
   </div>
            
                
            <div class="appformdiv">
               
                <div >
                            <asp:DropDownList ID="dpProgram" runat="server" CssClass="ddlinput" AutoPostBack="True">
             <asp:ListItem Value="-1">Select Program</asp:ListItem>
         
             </asp:DropDownList>
                     
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorName3" runat="server" ControlToValidate="dpProgram" ErrorMessage="Program Required" SetFocusOnError="True" Initialvalue ="-1"></asp:RequiredFieldValidator>
                </div>
      
            </div>
           
            
             
   
           


      
               

          
               
            <div class="appformdiv">
    
                <div >

                <asp:DropDownList ID="dpIntake" runat="server" CssClass="ddlinput">
                    <asp:ListItem Value="-1">Select Intake</asp:ListItem>
                   
                 
                </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorName4" runat="server" ControlToValidate="dpintake" ErrorMessage="Intake Required" SetFocusOnError="True" Initialvalue ="-1"></asp:RequiredFieldValidator>
    </div>
            </div>
        
         <div class="appformdiv">
          
                <div >
                    <asp:DropDownlist ID="dpclass" runat="server" CssClass="ddlinput">
                 <asp:ListItem Value="-1">Select Class</asp:ListItem>
               
             </asp:DropDownlist>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorName5" runat="server" ControlToValidate="dpclass" ErrorMessage="Class Required" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
         </div>
       
               
         <div class="appformdiv" >
         
                <div >
                               <asp:DropdownList ID="DpSession" runat="server"  CssClass="ddlinput">
             <asp:ListItem Value="-1">Select Session</asp:ListItem>
            
             </asp:DropdownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorName6" runat="server" ControlToValidate="DpSession" ErrorMessage="Session Required" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
         </div>
            <div class="appformdiv">

          <div>
              
                               <asp:DropdownList ID="dpLevel" runat="server"  CssClass="ddlinput" AutoPostBack="True">
             <asp:ListItem Value="-1">Select Level</asp:ListItem>
             <asp:ListItem>1</asp:ListItem>
             <asp:ListItem>2</asp:ListItem>
             <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
             </asp:DropdownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dplevel" ErrorMessage="Level Required" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
         </div>

               <div class="appformdiv" >
         
                <div >
                               <asp:DropdownList ID="dpSemester" runat="server"  CssClass="ddlinput" AutoPostBack="True">
             <asp:ListItem Value="-1">Select Semester</asp:ListItem>
             <asp:ListItem>1</asp:ListItem>
             <asp:ListItem>2</asp:ListItem>
             <asp:ListItem>3</asp:ListItem>
                                               </asp:DropdownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DpSemester" ErrorMessage="Semester Required" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
                  
         </div>
                  
                
      

  <div class="appformdiv">
  
                <div >
                     <asp:dropdownlist ID="dpKnowhow" runat="server" CssClass="ddlinput">
                          <asp:ListItem Value="-1">How did you hear about trust?</asp:ListItem>
                 <asp:ListItem>Star FM</asp:ListItem>
                 <asp:ListItem>The Herald</asp:ListItem>
                 <asp:ListItem>Daily News</asp:ListItem>
                 <asp:ListItem>Sunday Mail</asp:ListItem>
                 <asp:ListItem>HMetro</asp:ListItem>
                 <asp:ListItem>Friend</asp:ListItem>
                 <asp:ListItem>Others</asp:ListItem>
             </asp:dropdownlist>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dpKnowHow" ErrorMessage="Field Required" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
  </div>
        <div class="appformdiv">
          
               
                <div >
                    
                <asp:DropDownList ID="dpIncome" runat="server" CssClass="ddlinput">
                            <asp:ListItem Value="-1">Select Source of Income</asp:ListItem>
                    <asp:ListItem>Self</asp:ListItem>
                    <asp:ListItem>Parent/Guardian</asp:ListItem>
                    <asp:ListItem>Sponsor</asp:ListItem>
                </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorName7" runat="server" ControlToValidate="dpIncome" ErrorMessage="Source Of Income Required" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
     
      </div>

          
            </asp:WizardStep>

                <asp:WizardStep runat="server" Title="Register Subjects" ID="RegSubs">
                    <div>
                        <div>
                             <asp:GridView ID="gdSubjects" runat="server" AutoGenerateColumns="False" style="margin-top: 8px"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"  ForeColor="Black" GridLines="Vertical" Width="100%">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText ="Choose Subject" ItemStyle-Width="10%">
                            <ItemTemplate>
                            <asp:CheckBox ID ="chkSelectsubject" runat ="server" />
                            </ItemTemplate>

<ItemStyle Width="10%"></ItemStyle>

                        </asp:TemplateField>
               
                        <asp:TemplateField HeaderText="Subject"  >
                         
                            <ItemTemplate>
                                <asp:Label ID="lbSubjet" runat="server" Text='<%# Bind("Subject") %>'></asp:Label>
                                                           </ItemTemplate>
                               
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="SubjectID"  Visible="true"  >
                         
                            <ItemTemplate>
                                <asp:Label ID="lbSubjectID" runat="server" Text='<%# Bind("SubjectID") %>'></asp:Label>
                                                           </ItemTemplate>
                               
                        </asp:TemplateField>
                    
                    </Columns>
                    <EmptyDataTemplate>
                        No Subjects found for the Selected Program
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#CCCCCC" /><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Font-Size="Smaller" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                 <RowStyle Font-Size="Smaller" HorizontalAlign="Center" />
                                 <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" /><SortedAscendingCellStyle BackColor="#F1F1F1" /><SortedAscendingHeaderStyle BackColor="#808080" /><SortedDescendingCellStyle BackColor="#CAC9C9" /><SortedDescendingHeaderStyle BackColor="#383838" />

                     </asp:GridView>
                  </div>
                    </div>
            </asp:WizardStep>

                <asp:WizardStep ID="RequiredDocs" runat="server" Title="Upload Documents">
               <div >
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="update2"  >
               <ProgressTemplate >

                   <div class ="modal">
                         <div class="center">
                               
            <img alt="" src="../../Images/Loader.gif" />

                   Submitting Application.......    
                               
        </div>
                   </div>
                 
                       
               </ProgressTemplate>
                           
                                                
           </asp:UpdateProgress>
                    </div>
                    <div class ="appformdiv">
                           <h2 style="text-decoration:underline">
                                     Upload Documents
                               </h2>
                    </div>
                            
                                  

            <div style="display:flex;flex-direction:row;flex-wrap:wrap">

                                                          <div>
                                                              <asp:FileUpload ID="FileUpload1" runat="server" Visible =" false" />
                                                            </div>
                                                                   
                                                    
                                                       
                                                           <div>
                                                                 <asp:Button ID ="btnUpload" Text ="Upload" runat ="server" Visible ="false " />
                                                           </div>
                </div>
            <div style="color:red">
                *First Choose File, then upload by clicking upload icon.</div>
           <div>
               
                            <asp:GridView ID="gdFiles" runat="server" AutoGenerateColumns="False" style="margin-top: 8px" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Horizontal" Width="477px">
                                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:Templatefield>
                        <ItemTemplate>
                            <asp:imagebutton ID="lbDelete" runat="server" Text ="Remove File" CommandName ="DeleteFiles" OnClientClick ="return confirm('Delete File?');"  CommandArgument='<%#Eval("fileref") %>' ImageUrl ="~/images/delete.png" Height ="20" ToolTip ="Remove File"></asp:imagebutton>
                          </itemtemplate>

                            </asp:Templatefield>

                           <asp:TemplateField HeaderText ="File#">
                        <ItemTemplate>
                       
                              <asp:Label ID ="lbRowNumber"  runat ="server" Visible ="true" Text='<%# Bind("Rownumber") %>'></asp:Label>
                           
                        </ItemTemplate>

                             </asp:TemplateField>

                         <asp:TemplateField>


                        <ItemTemplate>


                            <asp:linkbutton ID ="lbfilename"  Text='<%#Eval("FileName") %>' runat ="server" Visible ="true" CommandName ="Download" ></asp:linkbutton>
                              <asp:Label ID ="lbFileType"  Text='<%#Eval("Filetype") %>' runat ="server" Visible ="true"></asp:Label>
                                                 <%--<asp:Label ID ="lbfilesize"  Text='<%#Eval("filesize") %>' runat ="server" ></asp:Label>--%>
                               <asp:Label ID ="lbdoc"  Text='<%#Eval("doc") %>' runat ="server" Visible ="false"></asp:Label>
                        </ItemTemplate>

                             </asp:TemplateField>

                      
               
                        <asp:TemplateField HeaderText="FileSize (Kb)" >
                         
                            <ItemTemplate>
                                <asp:Label ID="lbfilesize" runat="server" Text='<%# Bind("FileSize") %>'></asp:Label>
                                                           </ItemTemplate>
                               
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DateUploaded" >
                 
                            <ItemTemplate>
                                <asp:Label ID="lbDateuploaded" runat="server" Text='<%# Bind("DateUploaded") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField>
                            <ItemTemplate >
                      <asp:FileUpload ID="FileUpload1" runat="server"  causesvalidatin ="false"/>
                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate >
                            <asp:imagebutton ID="lbUploadDoc" runat="server" Text ="Upload Document" CommandName ="UploadDoc"  ImageUrl ="~/images/upload.png" Height ="20" ToolTip ="Upload Document"></asp:imagebutton>

                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="DateUploaded"  Visible ="false">
                 
                            <ItemTemplate>
                                <asp:Label ID="lbFileRef" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                                                            <EmptyDataTemplate>
                                                                OPEN ENTRY
                                                            </EmptyDataTemplate>
                    <FooterStyle BackColor="#CCCCCC" /><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                            <RowStyle Font-Size="Small" />
                                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" /><SortedAscendingCellStyle BackColor="#F1F1F1" /><SortedAscendingHeaderStyle BackColor="#808080" /><SortedDescendingCellStyle BackColor="#CAC9C9" /><SortedDescendingHeaderStyle BackColor="#383838" />

                     </asp:GridView>
                   
           </div>
                                             
                                                    
                                                     
            <div class="appformdivrow">
                <div>
                    <asp:Label text="" runat ="server" ID ="lbPAyConfirmation" ForeColor="Red" Font-Size="Large"></asp:Label>
                              </div>
                <div>
                     <asp:Label text="Take a screen shot of payment confirmation and upload it as Proof Of Payment." runat ="server" ID ="Label1" Font-Size="Large" ForeColor="Red"></asp:Label>
                </div>
                </div>
                 
            <div class ="appformdiv">
                  <asp:Label ID ="lbRemarks" runat ="server" Text ="Additional Information" float ="left" Font-Size="XX-Small" Visible ="true"></asp:Label>
                 <div>
                <asp:TextBox ID="txtRemarks" runat ="server" CssClass ="inputtext" TextMode="MultiLine" placeholder ="Additional Information" AutoPostBack="false" ></asp:TextBox>
            </div>
            </div>
           
                                             
                                              <div>
                                                                                          <asp:Label ID="lblDocError" runat="server"></asp:Label>
                                              </div>
                    

                    <%--   <asp:UpdatePanel ID ="pnlSubmit"  runat ="server">
                        <ContentTemplate>--%>
                      <asp:UpdatePanel ID="update2" runat ="server">
                <ContentTemplate>  
            <div style ="display:inline-flex;flex-flow:row;flex-wrap:wrap">
                <div class="appformdiv">
                   
                                 <asp:Button ID ="btnSubmit" runat ="server" CssClass ="btn" Text ="Submit" style="height: 28px" />


                                     <div class="appformdiv">
                     <asp:Button ID="btnConfirmPopUp" style="display:none" runat ="server" Text="Cancel" />
                     <ajaxToolkit:ModalPopupExtender ID="btnConfirmPopUp_ModalPopupExtender" runat="server" BehaviorID="btnConfirmPopUp_ModalPopupExtender" TargetControlID="btnConfirmPopUp"
                         PopupControlID="ResultPopup"    BackgroundCssClass="modalBackground" PopupDragHandleControlID="pnlResultHeader">
                     </ajaxToolkit:ModalPopupExtender>
                </div>
           
            <asp:Panel runat="server" ID="ResultPopup" Style=" display:normal;" CssClass ="modalPopup"  >
                 <asp:Panel ID ="pnlResultHeader" runat ="server" style="width:100%;background-color:black">
                     <asp:Label ID ="lblheader" Text="Online Application"  style="width:100%;text-align:center;font-weight:bold;color:white" runat ="server"></asp:Label>
                 </asp:Panel>
       <asp:Label ID ="lblAppSubmitResult" runat ="server" ></asp:Label>
                <div style="padding-top:1em;width:100%;margin:auto" >
                     
            <asp:Button runat="server" ID="hideModalPopupViaServer" Text="Ok"
                OnClick="hideModalPopupViaServer_Click" CausesValidation="False"   />
                </div>
      
      
    </asp:Panel>
                                 
       
                      
                </div>

                 
                <div class="appformdiv">
                </div>
            </div>
                              </ContentTemplate>
       
      
       </asp:UpdatePanel>
               <%--                              </ContentTemplate>
                </asp:UpdatePanel>--%>
                                            
                                            
                                  
            <div class="appformdiv">
                     <asp:Label ID="errorstatus" runat="server" ForeColor="Red"></asp:Label>
            </div>
        

           
                         <asp:Button ID="Button3" style="display:none" runat ="server" Text="Cancel" />
                    <ajaxToolkit:ModalPopupExtender ID="btnLoadingPopUp_ModalPopupExternder" runat="server" BehaviorID="btnLoadingPopUp_ModalPopupExternder" TargetControlID="Button3"
                         PopupControlID="pnlBusy"    BackgroundCssClass="modalBackground">
                     </ajaxToolkit:ModalPopupExtender>

            
               
                   <asp:Panel runat="server" ID="pnlBusy" Style="  display:normal; width:200px;" CssClass ="modalPopup"  >
                      
       <asp:Label ID ="Label2" runat ="server" Text ="Submitting Application..." ForeColor="White" ></asp:Label>
                <br />
       
    </asp:Panel>

            </asp:WizardStep>
        </WizardSteps>

    </asp:Wizard>
      
         
         
    
           

    </div>
        
                
  
            
    
</asp:Content>
