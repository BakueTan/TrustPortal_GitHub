<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="EnrolForm.aspx.vb" Inherits="TrustAcademyPortal.EnrolForm" %>
<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>

<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <rsweb:ReportViewer id = "ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt" Height="979px" Width="1174px" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
        <LocalReport ReportPath="Reports\rptStudentSubjects.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" 
                    Name="DataSet1" />
            </DataSources>
        </LocalReport>
        </rsweb:ReportViewer>
       
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" SelectCommand="SELECT studentsubjects.StudentID, studentsubjects.Year, studentsubjects.Semester, studentsubjects.SubjectID, StudentPersonalDetails.StudentSurname, Subjects.Subject, studentsubjects.Program, forms.Description, enrollment.YearEnrolled, forms.Forms, enrollment.Gender, enrollment.Session, StudentPersonalDetails.StudentName, enrollment.DateEnrolled, StudentPersonalDetails.DateOfBirth, enrollment.YearEnrolled AS Expr1, StudentPersonalDetails.ResidentialAdress, StudentPersonalDetails.ContactNumber, StudentPersonalDetails.EmailAddress, StudentPersonalDetails.Address2, StudentPersonalDetails.Address3, StudentPersonalDetails.NationalID, @user AS LoggedUser, Subjects.Type, enrollment.Intake FROM studentsubjects INNER JOIN StudentPersonalDetails ON studentsubjects.StudentID = StudentPersonalDetails.StudentID INNER JOIN Subjects ON studentsubjects.SubjectID = Subjects.SubjectID INNER JOIN forms ON studentsubjects.Program = forms.Forms INNER JOIN enrollment ON studentsubjects.StudentID = enrollment.StudentID AND studentsubjects.Program = enrollment.Program AND studentsubjects.Year = enrollment.Year AND studentsubjects.Semester = enrollment.Semester WHERE (studentsubjects.Year = @level) AND (studentsubjects.Semester = @sem) AND (studentsubjects.Program = @prog) AND (studentsubjects.StudentID = @stud) AND (studentsubjects.RegStatus = 'Registered')">
        <SelectParameters>
            <asp:SessionParameter Name="user" SessionField="userName" />
            <asp:SessionParameter Name="level" SessionField="Level" />
            <asp:SessionParameter Name="sem" SessionField="Semester" />
            <asp:SessionParameter Name="prog" SessionField="Program" />
            <asp:SessionParameter Name="stud" SessionField="userName" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
