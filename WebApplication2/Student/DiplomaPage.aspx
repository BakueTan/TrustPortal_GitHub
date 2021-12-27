<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="DiplomaPage.aspx.vb" Inherits="TrustAcademyPortal.WebForm9" %>
<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="1244px" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1026px" 
        SizeToReportContent="True" style="margin-right: 37px" 
        ShowBackButton="False" ShowCredentialPrompts="False" ShowFindControls="False" 
        ShowPageNavigationControls="False" ShowParameterPrompts="False" 
        ShowPrintButton="False" ShowPromptAreaButton="False" 
        ShowRefreshButton="False" ShowWaitControlCancelLink="False" 
        ShowZoomControl="False" ShowExportControls="False">
        <LocalReport ReportPath="Reports\rptDiplomaTrans.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" 
                    Name="dsReports_Transcript" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" 
        
        
        SelectCommand="SELECT StudentPersonalDetails.StudentID, StudentPersonalDetails.StudentName, StudentPersonalDetails.StudentSurname, StudentPersonalDetails.Gender, studentmarks_online.SubjectID, Subjects.Subject, studentmarks_online.Semester, studentmarks_online.ExamMark, studentmarks_online.CourseMark, studentmarks_online.FinalMark, studentmarks_online.Points, studentmarks_online.Decision, studentmarks_online.RerefenceName, forms.Description, studentmarks_online.Program, studentmarks_online.Year, enrollment.yearenrolled, enrollment.Session, enrollment.Intake, forms.Section, studentmarks_online.ExamStatus, Subjects.Credits, Subjects.Type, avg1.Average AS ExamAverage, isnull(Suppsubs_online.LevelDecision, '') AS LevelDecision, suppsubs_online.Subjects AS SuppSubs, StudentPersonalDetails.DateOfBirth, StudentPersonalDetails.PlaceOfBirth, SemesterDurations.StartDate, SemesterDurations.EndDate, FinalGrade_online.Repeat AS FinalRpeat, FinalGrade_online.RepeatSubs AS FinalRepeatSubs, FinalGrade_online.Grade, LevelGrade.LevelGrade, LevelGrade.LevelMark, LevelGrade.RetakeSubs, LevelGrade.Retake AS LevelRetake, FinalGrade_online.Completed AS FinalCompleted, FinalGrade_online.Aggregate, LevelGrade.Level, LevelGrade.LevelRepeat AS LevelCarry, LevelGrade.Repeat, StudentPersonalDetails.Image, Sessions.Year AS ExamYear, LevelGrade.Concurrent, Suppsubs_Online.subjects AS SuppSubs, LevelGrade.LevelPoints, LevelGrade.LevelFail, dense_rank() OVER (partition BY studentmarks_online.Program, enrollment.YearEnrolled, forms.Section, enrollment.Intake,FinalGrade_online.BookPrice ORDER BY studentmarks_online.studentid) AS Pos FROM StudentMArks_online INNER JOIN StudentPersonaldetails ON StudentPersonalDetails.StudentID = studentmarks_online.StudentID INNER JOIN Subjects ON studentmarks_online.SubjectID = Subjects.SubjectID INNER JOIN forms ON StudentPersonalDetails.Program = forms.Forms INNER JOIN enrollment ON studentmarks_online.StudentID = enrollment.StudentID AND studentmarks_online.Program = enrollment.Program AND studentmarks_online.Year = enrollment.Year AND studentmarks_online.Semester = enrollment.Semester FULL OUTER JOIN LevelGrade ON studentmarks_online.StudentID = LevelGrade.StudentID AND studentmarks_online.Year = LevelGrade.Level AND studentmarks_online.Program = LevelGrade.Program AND rerefencename = levelgrade.exam FULL OUTER JOIN FinalGrade_online ON studentmarks_online.StudentID = FinalGrade_online.StudentID AND studentmarks_online.Program = FinalGrade_online.Program FULL OUTER JOIN SemesterDurations ON enrollment.Year = SemesterDurations.Year AND enrollment.Semester = SemesterDurations.Semester AND enrollment.Program = SemesterDurations.Program AND enrollment.yearenrolled = SemesterDurations.Class AND enrollment.Intake = SemesterDurations.Intake INNER JOIN Sessions ON Sessions.Sessions = studentmarks_online.RerefenceName LEFT OUTER JOIN avg1 ON studentmarks_online.StudentID = avg1.StudentID AND studentmarks_online.Year = avg1.Year AND studentmarks_online.Program = avg1.Program AND studentmarks_online.Semester = avg1.Semester AND avg1.rerefencename = studentmarks_online.rerefencename LEFT OUTER JOIN SuppSubs_online ON studentmarks_online.StudentID = Suppsubs_online.StudentID AND studentmarks_online.Program = SuppSubs_online.Program AND studentmarks_online.Year = SuppSubs_online.Year AND studentmarks_online.rerefencename = suppsubs_online.exam WHERE ( StudentMarks_online.StudentID = @stud AND studentmarks_online.program=@prog) ORDER BY StudentMarks_online.Year, StudentMarks_online.Semester, examyear, StudentMarks_online.RerefenceName">
        <SelectParameters>
            <asp:SessionParameter Name="stud" SessionField="userName" />
            <asp:SessionParameter Name="prog" SessionField="Program" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
