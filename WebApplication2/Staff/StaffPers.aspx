<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Master1.Master" CodeBehind="StaffPers.aspx.vb" 
    title="StudentPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style8
    {
        width: 100%;
    }
    .style9
    {
        width: 834px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style8">
    <tr>
        <td class="style9">
            <asp:DetailsView ID="DetailsView1" runat="server" 
                AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" 
                AutoGenerateInsertButton="True" AutoGenerateRows="False" BackColor="#DEBA84" 
                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                CellSpacing="2" DataKeyNames="staffID" DataSourceID="SqlDataSource1" 
                Height="50px" Width="125px">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <Fields>
                    <asp:BoundField DataField="staffID" HeaderText="staffID" ReadOnly="True" 
                        SortExpression="staffID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Surname" HeaderText="Surname" 
                        SortExpression="Surname" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" 
                        SortExpression="Gender" />
                    <asp:BoundField DataField="IDNumber" HeaderText="IDNumber" 
                        SortExpression="IDNumber" />
                    <asp:BoundField DataField="Contact" HeaderText="Contact" 
                        SortExpression="Contact" />
                    <asp:BoundField DataField="Residential_Address" 
                        HeaderText="Residential_Address" SortExpression="Residential_Address" />
                    <asp:BoundField DataField="Email_adrress" HeaderText="Email_adrress" 
                        SortExpression="Email_adrress" />
                </Fields>
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            </asp:DetailsView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" 
                SelectCommand="SELECT [staffID], [Name], [Surname], [Gender], [IDNumber], [Contact], [Residential Address] AS Residential_Address, [Email adrress] AS Email_adrress FROM [StaffPersonalDetails] WHERE ([staffID] = @staffID)">
                <SelectParameters>
                    <asp:SessionParameter Name="staffID" SessionField="userName" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
