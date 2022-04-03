<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Application.Master" CodeBehind="ApplicationStatus.aspx.vb" Inherits="TrustAcademyPortal.ApplicationStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
     <div class="appformdiv">
          <h1 style="margin :auto">Application Status</h1>
     </div>
        <div>
           <asp:UpdateProgress ID="statprog" runat ="server" AssociatedUpdatePanelID="pnlstagrid">
               <ProgressTemplate>
                                <div class ="modal">
                         <div class="center">
                               
            <img alt="" src="../../Images/Loader.gif" />

                   Updating Application...    
                               
        </div>
                   </div>
               </ProgressTemplate>
              
           </asp:UpdateProgress>
        </div>
        <asp:UpdatePanel ID ="pnlstagrid" runat ="server">
            <ContentTemplate>

         
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="AppReference" DataSourceID="dsAppStatus" 
        CaptionAlign="Left" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" Width="1272px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
               <asp:TemplateField >
                             <ItemTemplate>
                    <asp:linkbutton ID="lbSelect" runat="server" text="ViewOfferLetter" CommandName ="View" Visible ='<%#Bind("ViewOffer") %>' ToolTip ="View Offer Letter" height ="20"></asp:linkbutton>
                </ItemTemplate>
            </asp:TemplateField>
             
                 <asp:TemplateField HeaderText="School" SortExpression="School" Visible ="false">
                             <ItemTemplate>
                    <asp:Label ID="lbSchool" runat="server" Text='<%# Bind("School") %>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


                <asp:TemplateField HeaderText="StudentID" SortExpression="StudentID">
                             <ItemTemplate>
                    <asp:Label ID="lbStudentID" runat="server" Text='<%# Bind("StudentID") %>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                             <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
            
                <ItemTemplate>
                    <asp:Label ID="lbFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LastName" SortExpression="LastName">
            
                <ItemTemplate>
                    <asp:Label ID="lbLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DateSubmitted" SortExpression="DateSubmitted">
             
                <ItemTemplate>
                    <asp:Label ID="lblDatesubmitted" runat="server" Text='<%# Bind("DateSubmitted_f") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AppReference" SortExpression="AppReference" Visible="False">
             
                <ItemTemplate>
                    <asp:Label ID="lbAppReference" runat="server" Text='<%# Bind("AppReference") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="Session" SortExpression="Session">
             
                <ItemTemplate>
                    <asp:Label ID="lbSession" runat="server" Text='<%# Bind("Session") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Level" SortExpression="Level">
             
                <ItemTemplate>
                    <asp:Label ID="lbLevel" runat="server" Text='<%# Bind("Level") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Semester" SortExpression="Sem">
             
                <ItemTemplate>
                    <asp:Label ID="lbSemester" runat="server" Text='<%# Bind("Sem") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Decision" SortExpression="AppStatus">
               
                <ItemTemplate>
                    <asp:Label ID="lbAppStatus" runat="server" Text='<%# Bind("AppStatus") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle BackColor="White" ForeColor="Black" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DateDecisionMade" SortExpression ="Dateupdated" >
           
                <ItemTemplate>
                    <asp:Label ID="lbDateDecisionMade" runat="server" Text='<%# Bind("Dateupdated") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comment" SortExpression="Comment">
           
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="200px" />
            </asp:TemplateField>

               <asp:TemplateField HeaderText="OfferAccepted" Visible="False" >
           
                <ItemTemplate>
                    <asp:Label ID="lbAppicationAccepted" runat="server" Text='<%# Bind("apllicationaccepted") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

               <asp:TemplateField HeaderText="DateAccepted" Visible="False" >
           
                <ItemTemplate>
                    <asp:Label ID="lbDateAccepted" runat="server" Text='<%# Bind("DateAccepted") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField >
                             <ItemTemplate>
                    <asp:linkbutton ID="lbWithdraw" runat="server" text="WithDraw  Application" OnClientClick ="return confirm('WithDraw Application?');" CommandName ="WithDraw" Visible ='<%#Bind("WithDraw") %>'  tooltip ="Withdraw Application" Height ="20"></asp:linkbutton>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField >
                             <ItemTemplate>
                    <asp:linkbutton ID="lbUpdateApp" runat="server" text="Update  Application" CommandName ="UpdateApp" Visible ='<%#Bind("UpdateApp") %>' CommandArgument="" tooltip ="Update Application" Height ="20"></asp:linkbutton>
                </ItemTemplate>
            </asp:TemplateField>
          
        </Columns>
        <EditRowStyle BorderStyle="Dotted" BackColor="#999999" />
        <EmptyDataTemplate>
            NO APPLICATIONS FOUND
        </EmptyDataTemplate>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="black" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Smaller" HorizontalAlign="Center" VerticalAlign="Bottom" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
                   </ContentTemplate>
        </asp:UpdatePanel>
    <asp:SqlDataSource ID="dsAppStatus" runat="server" ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" SelectCommand="SELECT case AppStatus when 'Approved'  then 'True' when  'Declined' then 'True' else 'False' end as ViewOffer, case AppStatus when 'Pending' then 'True' else 'False' end as Withdraw, case appstatus when 'Decision Withheld' then 'True' else 'False' end as UpdateApp ,Email, FirstName, LastName, CAST(DateSubmitted AS date) AS DateSubmitted_F, AppReference, Program, Intake, Class, Session, AppStatus,dateupdated , comment, dbo.StudOfferAcceptence(dateaccepted,ApllicationAccepted) as ApllicationAccepted, DateAccepted,[level],sem,Remarks,[Active],isnull(Studentid,'Pending') as StudentID  ,dbo.bgcolor(studentid) as StudColor ,school FROM StudentApplication WHERE (Email = @email) and [Active] = 1 order by datesubmitted desc">
        <SelectParameters>
            <asp:SessionParameter Name="email" SessionField="Email" />
        </SelectParameters>
    </asp:SqlDataSource>

        <div>
            <asp:Label ID="lbStatusError" runat ="server" forecolor="Red"></asp:Label>
        </div>
       <div>
         
</div>

       </div>
   

</asp:Content>
