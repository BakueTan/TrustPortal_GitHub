<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="RegisterSubjects.aspx.vb" Inherits="TrustAcademyPortal.RegisterSubjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divMain">


 
         
     <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
     </div>
            
        <div>
            <asp:CheckBox ID ="chkenableupdate" runat ="server" text ="Enable upddate" Visible =" false"/>
        </div>
 
           
        <div>
<asp:panel runat ="server" id ="pnlCurrentEnrol"> Current Enrollment:&nbsp;&nbsp;&nbsp;
    <div>
  <asp:TextBox ID="txtProgram" runat="server" Width="59px" 
                    ReadOnly="True" Enabled ="false"></asp:TextBox>
    </div>
                
    <asp:TextBox ID="txtLvl" runat="server" Width="28px" ReadOnly="True" Enabled="false" Height="16px"></asp:TextBox> 
     <asp:Label ID="Label4" runat="server" Text="."></asp:Label>
                             <asp:TextBox ID="txtSem" runat="server" Width="28px" Enabled="false" Height="16px"></asp:TextBox>
              
         </asp:panel>
        </div>
              <div>
            <asp:panel runat ="server" id ="pnlnextEnrollment"> Next Enrollment:&nbsp;&nbsp;&nbsp;
                <div>
                             <asp:TextBox ID="txtNxtLvl" runat="server" ReadOnly="True" Width="28px" Enabled="false" Height="16px"></asp:TextBox>
                &nbsp;. <asp:TextBox ID="txtNxtSem" runat="server" ReadOnly="True" 
                    Width="28px" Enabled="false" Height="16px"></asp:TextBox>
                    <asp:Button ID="btnRetrieveLevelSubs" runat ="server" Text ="RetrieveSubjects" CssClass ="btn" visible="false"/>
                </div>
       
         </asp:panel>
        </div>
         <div>
                    <asp:Label ID="lbSubjects" runat="server" Text="Subjects" Font-Bold="True" 
                    Font-Size="X-Large"></asp:Label>
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
                                <asp:dropdownlist ID="Register" runat="server" Text='<%# Bind("Register") %>' Enabled="true" >
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
                        <asp:BoundField DataField="Subject" HeaderText="Subject" ReadOnly="True"  HeaderStyle-HorizontalAlign="left">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <EmptyDataTemplate>
                        No Subjectss Found.
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="#5D7B9D" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
        </div> 

 
  
     <div>
             <asp:Panel runat ="server"  ID ="pnlRegister" HorizontalAlign ="Center"> <asp:Button ID="btnRegister" runat="server" Text="Save" Font-Bold="True" Font-Size="Larger" CssClass ="MenuLink" style="background-color:green"/></asp:Panel>
     </div>

     <div>
               <asp:Label ID="lbstatus" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
     </div> 
      <div>
  <asp:HyperLink ID="hlViewEnrollmentForm" runat="server" NavigateUrl="~/Student/EnrolForm.aspx" Visible="False">Print Enrollment Form</asp:HyperLink>

      </div>

    <div>
<asp:Panel ID ="pnl223" runat ="server"></asp:Panel>
    </div>
        <div>
<asp:Panel ID ="Panel7" runat ="server"></asp:Panel>
        </div>
   <div>
          <asp:Panel runat ="server"  ID ="Panel1">
              <div class="auto-style3">
                  <strong><em>INSTRUCTIONS</em></strong></div>
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
</asp:Content>
