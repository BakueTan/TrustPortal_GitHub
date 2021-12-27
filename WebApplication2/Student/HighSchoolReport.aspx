<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="HighSchoolReport.aspx.vb" Inherits="TrustAcademyPortal.WebForm1" 
    title="StudentPortal" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style8
        {
            width: 100%;
        }
    .style9
    {
        height: 35px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style8">
        <tr>
            <td class="style9">
&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Class"></asp:Label>
&nbsp;<asp:DropDownList ID="dlCls" runat="server" Width="125px">
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                </asp:DropDownList>
&nbsp;<asp:Label ID="Label3" runat="server" Text="Form"></asp:Label>
&nbsp;<asp:DropDownList ID="dlForm" runat="server" Width="125px">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Text="Exam"></asp:Label>
                <asp:DropDownList ID="dlExam" runat="server" Width="224px" Height="16px" 
                    DataSourceID="SqlDataSource1" DataTextField="Sessions" 
                    DataValueField="Sessions">
                    <asp:ListItem>First Term 2012</asp:ListItem>
                    <asp:ListItem>Second Term 2012</asp:ListItem>
                    <asp:ListItem>Third Term 2012</asp:ListItem>
                    <asp:ListItem>First Term 2013</asp:ListItem>
                    <asp:ListItem>Second Term 2013</asp:ListItem>
                    <asp:ListItem>Third Term 2013</asp:ListItem>
                    <asp:ListItem>First Term 2014</asp:ListItem>
                    <asp:ListItem>Second Term 2014</asp:ListItem>
                    <asp:ListItem>Third Term 2014</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" 
                    SelectCommand="SELECT [Sessions] FROM [Sessions]"></asp:SqlDataSource>
                <asp:Label ID="Label6" runat="server" Text=" Program"></asp:Label>
                <asp:DropDownList ID="dlProgram" runat="server" DataSourceID="Forms" 
                    DataTextField="Description" DataValueField="Forms" Width="125px">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="Forms" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" 
                    SelectCommand="SELECT [Forms], [Description] FROM [forms] WHERE ([Section] = @Section)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="High School" Name="Section" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:Button ID="ViewReport" runat="server" Text="ViewReport" />
            </td>
        </tr>
        <tr>
            <td width = "100%" >
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" style="margin-left: 0px" 
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                    
<LocalReport ReportPath="Reports\rptHsReport.rdlc">
                    </LocalReport>
                
</rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    TypeName="WebApplication2.dsReportsTableAdapters.HsExamMarksTableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="dlProgram" Name="prog" 
                            PropertyName="SelectedValue" Type="String" />
                        <asp:SessionParameter Name="studid" SessionField="userName" Type="String" />
                        <asp:ControlParameter ControlID="dlForm" Name="lvl" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="dlCls" Name="cls" PropertyName="SelectedValue" 
                            Type="Int32" />
                        <asp:ControlParameter ControlID="dlExam" Name="ref" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
