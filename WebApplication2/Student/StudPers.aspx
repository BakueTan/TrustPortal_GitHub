<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="StudPers.aspx.vb" Inherits="TrustAcademyPortal.WebForm5" 
    title="StudentPortal" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style8
    {
        width: 100%;
    }
    .style9
    {
        width: 627px;
    }
        .style11
        {
            width: 627px;
            height: 443px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style8">
    <tr>
        <td class="style11">
            <asp:SqlDataSource ID="dsStudPers" runat="server" 
                ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" 
                InsertCommand="INSERT INTO StudentPersonalDetails(StudentID, Gender, StudentMiddleName, StudentName, StudentSurname, Program, Year, Semester) VALUES (0, 0, 0, 0, 0, 0, 0, 0)" 
                SelectCommand="SELECT [StudentID], [Gender], [StudentName], [StudentSurname], [Program], [Year], [Semester], [Session], [Year Joined  joined] AS Year_Joined_joined, [DateOfBirth], [Residential Adress] AS Residential_Adress, [Contact Number] AS Contact_Number, [NationalID], [PlaceOfBirth], [EmailAddress] FROM [StudentPersonalDetails] WHERE ([StudentID] = @StudentID)" 
                
                
                
                UpdateCommand="UPDATE StudentPersonalDetails SET Contact_Number = @cont ,residential_adress= @add WHERE (StudentID = @stud)">
                <SelectParameters>
                    <asp:SessionParameter Name="StudentID" SessionField="userName" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter />
                    <asp:SessionParameter Name="stud" SessionField="userName" />
                    <asp:FormParameter FormField="Contact_NumberTextBox" Name="cont" />
                    <asp:FormParameter FormField="Residential_AddressTextBox" Name="add" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" ShowBackButton="False" 
                ShowCredentialPrompts="False" ShowDocumentMapButton="False" 
                ShowExportControls="False" ShowFindControls="False" 
                ShowPageNavigationControls="False" ShowParameterPrompts="False" 
                ShowPrintButton="False" ShowPromptAreaButton="False" ShowRefreshButton="False" 
                ShowToolBar="False" ShowWaitControlCancelLink="False" ShowZoomControl="False" 
                Width="603px" Font-Names="Verdana" Font-Size="8pt" 
                InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
                WaitMessageFont-Size="14pt">
                <LocalReport ReportPath="Reports\rptStudProfile.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                TypeName="WebApplication2.dsReportsTableAdapters.StudentPersonalDetailsTableAdapter">
                <SelectParameters>
                    <asp:SessionParameter Name="stud" SessionField="userName" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="style9" align = center style="vertical-align: top" >
            &nbsp;</td>
    </tr>
</table>
    </asp:Content>
