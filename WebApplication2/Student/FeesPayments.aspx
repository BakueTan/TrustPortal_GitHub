<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Master1.Master" CodeBehind="FeesPayments.aspx.vb" Inherits="TrustAcademyPortal.WebForm4" 
    title="StudentPortal" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divMain">
       <div class="appformdiv">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
   
  <div class="appformdiv">
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True" CssClass="auto-style2" Width="393px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="AccNumber" HeaderText="AccNumber" 
                            SortExpression="AccNumber" />
                        <asp:BoundField DataField="DDate" HeaderText="Date" 
                            SortExpression="DDate" />
                        <asp:BoundField DataField="Refrence" HeaderText="Refrence" 
                            SortExpression="Refrence" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" 
                            SortExpression="Amount" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" 
                    
                    SelectCommand="SELECT AccNumber, DDate, Refrence, Amount FROM ledgertransactions WHERE (AccNumber = @acc) AND (PPeriod &lt;= (SELECT Period FROM ResultsCutOff))">
                    <SelectParameters>
                        <asp:SessionParameter Name="acc" SessionField="userName" />
                    </SelectParameters>
                </asp:SqlDataSource>
  </div>
   </div>
    
         
    
</asp:Content>
