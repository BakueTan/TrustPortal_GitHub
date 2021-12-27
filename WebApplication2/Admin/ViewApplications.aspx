<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Admin.Master" CodeBehind="ViewApplications.aspx.vb" Inherits="TrustAcademyPortal.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:UpdateProgress runat ="server" ID ="offerprogress" AssociatedUpdatePanelID ="pnlAppSearch">
      <ProgressTemplate>
                 <div class ="modal">
                         <div class="center">
                               
            <img alt="" src="../../Images/Loader.gif" />

                   Loading Applications...    
                               
                             
                               
        </div>
                   </div>
      </ProgressTemplate>
  </asp:UpdateProgress>
          <asp:UpdateProgress runat ="server" ID ="UpdateProgress1" AssociatedUpdatePanelID ="UpdatePanel1">
      <ProgressTemplate>
                 <div class ="modal">
                         <div class="center">
                               
            <img alt="" src="../../Images/Loader.gif" />

                   Loading Application...    
                               
                             
                               
        </div>
                   </div>
      </ProgressTemplate>
  </asp:UpdateProgress>
    <div>
        </div>
      <asp:UpdatePanel ID="pnlAppSearch" runat ="server" >
        <ContentTemplate>
            <div class="appformdiv" style ="background-color:lightsteelblue" >
    
        <div>
              <asp:Label ID ="Label5" runat ="server" Text ="Search Applications" float ="left"></asp:Label>
        </div>

      
       <div style="display:inline-flex;padding-top:20px;">
      <div style="padding-right:10px;width:20% "  >
           <asp:Label ID ="Label3" runat ="server" Text ="Status :" float ="left" ></asp:Label>
           <asp:DropDownList ID ="ddlAppStatus" runat ="Server" CssClass="ddlSearch" AutoPostBack="True" >
                 <asp:ListItem>--Select Status--</asp:ListItem>
                  <asp:ListItem>Pending</asp:ListItem>
               <asp:ListItem>Approved</asp:ListItem>
                       <asp:ListItem>Decision Withheld</asp:ListItem>
                          <asp:ListItem>Updated</asp:ListItem>
                      <asp:ListItem>Decision Withdrawn</asp:ListItem>
                      <asp:ListItem>Declined</asp:ListItem>
                      <asp:ListItem>Application Withdrawn</asp:ListItem>
               <asp:ListItem>ALL</asp:ListItem>
           </asp:DropDownList>
      </div>

             <div style="padding-right:10px;width:20%" >
           <asp:Label ID ="Label1" runat ="server" Text ="Class :" float ="left" ></asp:Label>
           <asp:DropDownList ID ="ddlAppClass" runat ="Server" CssClass="ddlSearch" AutoPostBack="True" >
                  <asp:ListItem>2020</asp:ListItem>
               <asp:ListItem>2021</asp:ListItem>
               <asp:ListItem>2022</asp:ListItem>
               <asp:ListItem>2023</asp:ListItem>
               <asp:ListItem>2024</asp:ListItem>
                  <asp:ListItem>2025</asp:ListItem>                        

                           

                           
           </asp:DropDownList>
      </div >
      
              <div style="padding-right:10px;width:20%" >
           <asp:Label ID ="Label2" runat ="server" Text ="Intake:" float ="left" ></asp:Label>
           <asp:DropDownList ID ="ddlAppIntake" runat ="Server" CssClass="ddlSearch" AutoPostBack="True" >
                  <asp:ListItem>January</asp:ListItem>
                 <asp:ListItem>February</asp:ListItem>
                 <asp:ListItem>March</asp:ListItem>
                 <asp:ListItem>April</asp:ListItem>
                 <asp:ListItem>May</asp:ListItem>
                              <asp:ListItem>June</asp:ListItem>
                 <asp:ListItem>July</asp:ListItem>
                 <asp:ListItem>August</asp:ListItem>
                 <asp:ListItem>September</asp:ListItem>
                 <asp:ListItem>October</asp:ListItem>
                 <asp:ListItem>November</asp:ListItem>
                 <asp:ListItem>December</asp:ListItem>
             
             
           </asp:DropDownList>
    
        </div>
                   <div style="padding-right:10px;width:20%" >
           <asp:Label ID ="Label4" runat ="server" Text ="Campus:" float ="left" ></asp:Label>
           <asp:DropDownList ID ="ddlAppCampus" runat ="Server" CssClass="ddlSearch" AutoPostBack="True" >
                  <asp:ListItem>Harare</asp:ListItem>
               <asp:ListItem>Bulawayo</asp:ListItem>
            
             
           </asp:DropDownList>
    
        </div>
           </div>
       </div>
 
    

    <div>
        <asp:Panel runat="server" ID="pnlGdStudDisplay" BackColor="#FFFFCC" Font-Size="Small" Visible="False" style="width:50%;margin :auto" ><asp:Label runat="server" Text ="Show "></asp:Label><asp:dropdownlist ID="ddlStudentSubjectsGridDisplay" runat ="server" AutoPostBack="True" style="height: 22px"  >
              <asp:ListItem>10</asp:ListItem>
              <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
              <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>35</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>
</asp:dropdownlist>&nbsp; <asp:Label runat ="server" Text ="   Records"></asp:Label>&nbsp;<asp:Button id="btnStudGridviewPrev" runat ="server" Text ="<<" Font-Size="X-Small" style="vertical-align:central" Height="15px"/><asp:Label runat ="server" ID="lbStudentsubjectsDisp"></asp:Label><asp:Button id="btnGridviewNext" runat ="server" Text =">>" Font-Size="X-Small" style="vertical-align:central" Height="15px" />

                                </asp:Panel>
        </div>
            </ContentTemplate>
          </asp:UpdatePanel>



                <asp:UpdatePanel ID="UpdatePanel1" runat ="server" >
        <ContentTemplate>

    <div class="appformdiv">
      

        <asp:GridView ID="gdApplications" runat="server" AutoGenerateColumns="False" DataKeyNames="AppReference" DataSourceID="dsStudApplications" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" HorizontalAlign="Left" PageSize="15">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField  >
                   
                    <ItemTemplate>
                        <asp:imagebutton ID="lbViewApp" runat="server" Text= "ViewApplication" CommandName ="ViewApplication" Height="20" imageurl="~/images/View.png" ToolTip="View Application"></asp:imagebutton>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField  >
                   
                    <ItemTemplate>
                        <asp:imagebutton ID="lbAssignID" runat="server" Text= "AssigstudentID" CommandName ="AssignID" Visible ='<%# Bind("AssignStudID") %>'  ImageUrl ="~/images/Assign.png" Height ="20" ToolTip="Assign StudentID" ></asp:imagebutton>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="StudentID" SortExpression="StudentID">
                   
                    <ItemTemplate>
                        <asp:Label ID="lbStudentID" runat="server" Text='<%# Bind("StudentID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LastName" SortExpression="LastName">
                   
                    <ItemTemplate>
                        <asp:Label ID="lbLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             
                <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
                   
                    <ItemTemplate>
                        <asp:Label ID="lbFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="DOB" SortExpression="dob" Visible="False">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbDob" runat="server" Text='<%# Bind("dob") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender" SortExpression="Gender" Visible="False">
                   
                    <ItemTemplate>
                        <asp:Label ID="lbGender" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" SortExpression="Email">
                   
                    <ItemTemplate>
                        <asp:Label ID="lbEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField  Visible ="false">
                                        <ItemTemplate>
                        <asp:Label ID="lbPreviousEnrollment" runat="server" Text='<%# Bind("PreviousEnrollment") %>'></asp:Label>
                    </ItemTemplate>
                      </asp:TemplateField>
                <asp:TemplateField HeaderText ="EntryType" SortExpression="EntryType">
                                        <ItemTemplate>
                                            <asp:Label ID="lbEntryType" runat="server" Text='<%# Bind("EntryType") %>'></asp:Label>
                                        </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Campus" SortExpression="Campus">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbCampus" runat="server" Text='<%# Bind("Campus") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="School" SortExpression="School">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbSchool" runat="server" Text='<%# Bind("School") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                              <asp:TemplateField HeaderText="Program" SortExpression="Program">
                   
                    <ItemTemplate>
                        <asp:Label ID="lbProgram" runat="server" Text='<%# Bind("Program") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Intake" SortExpression="Intake">
                  
                    <ItemTemplate>
                        <asp:Label ID="lbIntake" runat="server" Text='<%# Bind("Intake") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Class" SortExpression="Class">
                                       <ItemTemplate>
                        <asp:Label ID="lbClass" runat="server" Text='<%# Bind("Class") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="Level" SortExpression="level">
                                       <ItemTemplate>
                        <asp:Label ID="lbLevel" runat="server" Text='<%# Bind("level") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="Semester" SortExpression="Semester">
                                       <ItemTemplate>
                        <asp:Label ID="lbSemester" runat="server" Text='<%# Bind("Sem") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Session" SortExpression="Session">
                                        <ItemTemplate>
                        <asp:Label ID="lbSession" runat="server" Text='<%# Bind("Session") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField  Visible="False">
                                        <ItemTemplate>
                        <asp:Label ID="lbRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               

                <asp:TemplateField HeaderText="AppStatus" SortExpression="AppStatus">
                                        <ItemTemplate>
                        <asp:Label ID="lbAppStatus" runat="server" Text='<%# Bind("AppStatus") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="DateUpdated" SortExpression="dateupdated" Visible="False">
                                        <ItemTemplate>
                        <asp:Label ID="lbdateupdated" runat="server" Text='<%# Bind("dateupdated") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="UpdatedBy" SortExpression="updatedby" Visible="False">
                                        <ItemTemplate>
                        <asp:Label ID="lbupdatedby" runat="server" Text='<%# Bind("updatedby") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DateSubmitted" SortExpression="DateSubmitted">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbDateSubmitted" runat="server" Text='<%# Bind("DateSubmitted") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                

                  <asp:TemplateField HeaderText="Address" SortExpression="School" Visible="False">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Contact" SortExpression="Contact" Visible="False">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbContact" runat="server" Text='<%# Bind("Contact") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Contact" SortExpression="Contact" Visible="False">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbNationalID" runat="server" Text='<%# Bind("NationalID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Income Source" SortExpression="IncomeSource" Visible="False">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbIncomeSource" runat="server" Text='<%# Bind("IncomeSource") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="KnowHow" SortExpression="KnowHow" Visible="False">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbKnowHow" runat="server" Text='<%# Bind("KnowHow") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Occupation" SortExpression="Occupation" Visible="False">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbOccupation" runat="server" Text='<%# Bind("Occupation") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="WorkPhone" SortExpression="WorkPhone" Visible="False">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbWorkPhone" runat="server" Text='<%# Bind("WorkPhone") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="WorkAddress" SortExpression="WorkAddress" Visible="False">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbWorkAddress" runat="server" Text='<%# Bind("WorkAddress") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="NokName" Visible="False">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbNokName" runat="server" Text='<%# Bind("NokName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="NokAddress" Visible="False" >
                    
                    <ItemTemplate>
                        <asp:Label ID="lbNokAddress" runat="server" Text='<%# Bind("NokAddress") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                  <asp:TemplateField HeaderText="NokContact" Visible="False" >
                    
                    <ItemTemplate>
                        <asp:Label ID="lbNokContact" runat="server" Text='<%# Bind("NokContact") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="NokEmail" Visible="False" >
                    
                    <ItemTemplate>
                        <asp:Label ID="lbNokEmail" runat="server" Text='<%# Bind("NokEmail") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="OfferAcceptedByStudent" SortExpression="ApllicationAccepted">
                    
                    <ItemTemplate>
                        <asp:label ID="lbApplicationAccepted" runat="server" text='<%# Bind("ApllicationAccepted") %>'  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DateAccepted" SortExpression="DateAccepted">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbDateAccepted" runat="server" Text='<%# Bind("DateAccepted") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Comment" SortExpression="Comment">
                    
                    <ItemTemplate>
                        <asp:Label ID="lbcomment" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                    </ItemTemplate>
                     <ControlStyle Width="200px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AppReference" SortExpression="AppReference" Visible="False">
                   
                    <ItemTemplate>
                        <asp:Label ID="lbAppReference" runat="server" Text='<%# Bind("AppReference") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <EmptyDataTemplate>
                NO APPLICATIONS FOUND FOR THE SPECIFIED CRITERIA , OR USER NOT AUTHORISED TO VIEW APPLICATIONS.
            </EmptyDataTemplate>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="Snow" Font-Bold="True" ForeColor="BLACK" />
            <PagerStyle BackColor="SNOW" ForeColor="BLACK" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" Font-Size="Smaller" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Bottom" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

        <asp:SqlDataSource ID="dsStudApplications" runat="server" ConnectionString="<%$ ConnectionStrings:TrustAcademyPortal.My.MySettings.soccerConnectionString %>" SelectCommand="spRetrieveApplications" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="school" SessionField="School" />
                <asp:ControlParameter ControlID="ddlAppStatus" Name="appstatus" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="ddlAppIntake" Name="intake" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="ddlAppClass" Name="clas" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="ddlAppCampus" Name="campus" PropertyName="SelectedValue" />
                <asp:SessionParameter Name="offset" SessionField="offset" Type="Int32" />
                <asp:ControlParameter ControlID="ddlStudentSubjectsGridDisplay" Name="filter" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
       </ContentTemplate>
    </asp:UpdatePanel>

    </div>
  </div></asp:Content>
