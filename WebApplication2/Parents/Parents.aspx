<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Master1.Master" CodeBehind="Parents.aspx.vb" Inherits="TrustAcademyPortal.WebForm8" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style8
    {
        width: 100%;
    }
    .style9
    {
        width: 733px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style8">
    <tr>
        <td class="style9">
            <asp:Label ID="Label1" runat="server" Text="Select Active Child"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            <asp:DropDownList ID="DropDownList1" runat="server" 
                DataSourceID="SqlDataSource1" DataTextField="StudentName" 
                DataValueField="StudentID" Height="16px" Width="259px" 
                AppendDataBoundItems="True" AutoPostBack="True" DataMember="DefaultView">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" 
                
                SelectCommand="SELECT StudentID, StudentName + StudentSurname AS StudentName FROM StudentPersonalDetails WHERE (NOKContactNumber = @NOKContactNumber)">
                <SelectParameters>
                    <asp:SessionParameter Name="NOKContactNumber" 
                        SessionField="Session(&quot;userName&quot;)" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
