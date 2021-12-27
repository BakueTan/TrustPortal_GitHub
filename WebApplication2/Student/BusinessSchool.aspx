<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Master1.Master" CodeBehind="BusinessSchool.aspx.vb" Inherits="TrustAcademyPortal.BusinessSchool" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="1234px" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1103px" 
        ShowBackButton="False" ShowCredentialPrompts="False" ShowFindControls="False" 
        ShowPageNavigationControls="False" ShowParameterPrompts="False" 
        ShowWaitControlCancelLink="False">
        <LocalReport ReportPath="Reports\rptBusinessSchool.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" 
                    Name="Transcript" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="WebApplication2.dsReportsTableAdapters.TranscriptTableAdapter"></asp:ObjectDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" 
        SelectCommand="SELECT        StudentPersonalDetails.StudentID, StudentPersonalDetails.StudentName, StudentPersonalDetails.StudentSurname, StudentPersonalDetails.Gender, studentmarks_online.SubjectID, Subjects.Subject, 
                         studentmarks_online.Semester, studentmarks_online.ExamMark, studentmarks_online.CourseMark, studentmarks_online.FinalMark, studentmarks_online.Points, studentmarks_online.Decision, studentmarks_online.RerefenceName, forms.Description, 
                         studentmarks_online.Program, studentmarks_online.Year, enrollment.YearEnrolled, enrollment.Session, enrollment.Intake, forms.Section, studentmarks_online.ExamStatus, Subjects.Credits, Subjects.Type, 
                       avg1.Average AS ExamAverage,StudentPersonalDetails.DateOfBirth, 
                         StudentPersonalDetails.PlaceOfBirth, SemesterDurations.StartDate, SemesterDurations.EndDate, FinalGrade_online.Repeat AS FinalRpeat, FinalGrade_online.RepeatSubs AS FinalRepeatSubs, FinalGrade_online.Grade, 
                         LevelGrade_online.LevelGrade, LevelGrade_online.LevelMark, LevelGrade_online.RetakeSubs , LevelGrade_online.Retake AS LevelRetake, FinalGrade_online.Completed AS FinalCompleted, FinalGrade_online.Aggregate, LevelGrade_online.Level,
                         LevelGrade_online.LevelRepeat AS LevelCarry, LevelGrade_online.Repeat, StudentPersonalDetails.Image, Sessions.Year AS examyear, LevelGrade_online.Concurrent, LevelGrade_online.LevelPoints, LevelGrade_online.LevelFail, LevelGrade_online.Repeat2, 
                         LevelGrade_online.LevelAvg, FinalGrade_online.BookPrice, dense_rank() OVER (partition BY studentmarks_online.Program, enrollment.YearEnrolled, forms.Section, enrollment.Intake
ORDER BY studentmarks_online.studentid) AS Pos,dbo.LevelDecision_online(LevelGrade_online.program, LevelGrade_online.level, LevelGrade_online.studentid) as LevelDecision
FROM            studentmarks_online INNER JOIN
                         Studentpersonaldetails ON StudentPersonalDetails.StudentID = studentmarks_online.StudentID INNER JOIN
                         Subjects ON studentmarks_online.SubjectID = Subjects.SubjectID INNER JOIN
                         forms ON studentmarks_online.Program = forms.Forms INNER JOIN
                         enrollment ON studentmarks_online.StudentID = enrollment.StudentID AND studentmarks_online.Program = enrollment.Program AND studentmarks_online.Year = enrollment.Year AND 
                         studentmarks_online.Semester = enrollment.Semester left outer JOIN
                         LevelGrade_online ON studentmarks_online.StudentID = LevelGrade_online.StudentID AND studentmarks_online.Year = LevelGrade_online.Level AND studentmarks_online.Program = LevelGrade_online.Program AND 
                         studentmarks_online.rerefencename = LevelGrade_online.exam and  studentmarks_online.semester = LevelGrade_online.semester  INNER JOIN
                         Sessions ON Sessions.Sessions = studentmarks_online.RerefenceName left outer JOIN
                         FinalGrade_online ON studentmarks_online.StudentID = FinalGrade_online.StudentID AND studentmarks_online.Program = FinalGrade_online.Program LEFT OUTER JOIN
                         SemesterDurations ON enrollment.Year = SemesterDurations.Year AND enrollment.Semester = SemesterDurations.Semester AND enrollment.Program = SemesterDurations.Program AND 
                         enrollment.YearEnrolled = SemesterDurations.Class AND enrollment.Intake = SemesterDurations.Intake FULL OUTER JOIN
                         avg1 ON studentmarks_online.StudentID = avg1.StudentID AND studentmarks_online.Year = avg1.Year AND studentmarks_online.Program = avg1.Program AND studentmarks_online.Semester = avg1.Semester
WHERE (  StudentMarks_online.StudentID = @stud and studentmarks_online.program = @prog) 
ORDER BY   StudentMarks_online.Year,   StudentMarks_online.Semester, examyear,   StudentMarks_online.RerefenceName">
        <SelectParameters>
            <asp:SessionParameter Name="stud" SessionField="userName" />
            <asp:SessionParameter Name="prog" SessionField="Program" />
        </SelectParameters>
    </asp:SqlDataSource>
    </asp:Content>
