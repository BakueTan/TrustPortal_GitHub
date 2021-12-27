<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Master1.Master" CodeBehind="EnterStudMarks.aspx.vb" Inherits="TrustAcademyPortal.WebForm7" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style8
        {
            width: 121%;
        }
        .style9
        {
            width: 345px;
        }
        .style10
        {
            width: 735px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;<table class="style8">
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style10" style="vertical-align: inherit">
                <asp:DropDownList ID="ddlProg" runat="server" DataSourceID="SqlDataSource1" 
                    DataTextField="Forms" DataValueField="Forms">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlClass" runat="server">
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlLevel" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlSem" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlIntake" runat="server">
                    <asp:ListItem>January</asp:ListItem>
                    <asp:ListItem>February</asp:ListItem>
                    <asp:ListItem>March</asp:ListItem>
                    <asp:ListItem>April</asp:ListItem>
                    <asp:ListItem>May</asp:ListItem>
                    <asp:ListItem>June</asp:ListItem>
                    <asp:ListItem>July</asp:ListItem>
                    <asp:ListItem>August</asp:ListItem>
                    <asp:ListItem>September</asp:ListItem>
                    <asp:ListItem>October</asp:ListItem>
                    <asp:ListItem>November</asp:ListItem>
                    <asp:ListItem>December</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlSess" runat="server">
                    <asp:ListItem>Evening</asp:ListItem>
                    <asp:ListItem>Weekend</asp:ListItem>
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                    <asp:ListItem>Day</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="ViewClass" Width="84px" 
                    Height="22px" />
            </td>
        </tr>
        <tr>
            <td class="style9" style="vertical-align: top">
                <asp:FormView ID="FormView1" runat="server" AllowPaging="True" 
                    DataSourceID="dsStudMarks" Width="339px" 
                    DataKeyNames="StudentID,Program,Year,Semester,SubjectID,RerefenceName">
                    <EditItemTemplate>
                        StudentID:
                        <asp:Label ID="StudentIDLabel1" runat="server" 
                            Text='<%# Eval("StudentID") %>' />
                        <br />
                        Program:
                        <asp:Label ID="ProgramLabel1" runat="server" Text='<%# Eval("Program") %>' />
                        <br />
                        Year:
                        <asp:Label ID="YearLabel1" runat="server" Text='<%# Eval("Year") %>' />
                        <br />
                        Semester:
                        <asp:Label ID="SemesterLabel1" runat="server" Text='<%# Eval("Semester") %>' />
                        <br />
                        SubjectID:
                        <asp:Label ID="SubjectIDLabel1" runat="server" 
                            Text='<%# Eval("SubjectID") %>' />
                        <br />
                        ExamMark:
                        <asp:TextBox ID="ExamMarkTextBox" runat="server" 
                            Text='<%# Bind("ExamMark") %>' />
                        <br />
                        CourseMark:
                        <asp:TextBox ID="CourseMarkTextBox" runat="server" 
                            Text='<%# Bind("CourseMark") %>' />
                        <br />
                        FinalMark:
                        <asp:TextBox ID="FinalMarkTextBox" runat="server" 
                            Text='<%# Bind("FinalMark") %>' />
                        <br />
                        Points:
                        <asp:TextBox ID="PointsTextBox" runat="server" 
                            Text='<%# Bind("Points") %>' />
                        <br />
                        Decision:
                        <asp:TextBox ID="DecisionTextBox" runat="server" 
                            Text='<%# Bind("Decision") %>' />
                        <br />
                        ExamStatus:
                        <asp:TextBox ID="ExamStatusTextBox" runat="server" 
                            Text='<%# Bind("ExamStatus") %>' />
                        <br />
                        RerefenceName:
                        <asp:Label ID="RerefenceNameLabel1" runat="server" 
                            Text='<%# Eval("RerefenceName") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                            Text="Update" CommandName="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        StudentID:
                        <asp:TextBox ID="StudentIDTextBox" runat="server" 
                            Text='<%# Bind("StudentID") %>' />
                        <br />
                        Program:
                        <asp:TextBox ID="ProgramTextBox" runat="server" Text='<%# Bind("Program") %>' />
                        <br />
                        Year:
                        <asp:TextBox ID="YearTextBox" runat="server" 
                            Text='<%# Bind("Year") %>' />
                        <br />
                        Semester:
                        <asp:TextBox ID="SemesterTextBox" runat="server" 
                            Text='<%# Bind("Semester") %>' />
                        <br />
                        SubjectID:
                        <asp:TextBox ID="SubjectIDTextBox" runat="server" 
                            Text='<%# Bind("SubjectID") %>' />
                        <br />
                        ExamMark:
                        <asp:TextBox ID="ExamMarkTextBox" runat="server" 
                            Text='<%# Bind("ExamMark") %>' />
                        <br />
                        CourseMark:
                        <asp:TextBox ID="CourseMarkTextBox" runat="server" 
                            Text='<%# Bind("CourseMark") %>' />
                        <br />
                        FinalMark:
                        <asp:TextBox ID="FinalMarkTextBox" runat="server" 
                            Text='<%# Bind("FinalMark") %>' />
                        <br />
                        Points:
                        <asp:TextBox ID="PointsTextBox" runat="server" 
                            Text='<%# Bind("Points") %>' />
                        <br />
                        Decision:
                        <asp:TextBox ID="DecisionTextBox" runat="server" 
                            Text='<%# Bind("Decision") %>' />
                        <br />
                        ExamStatus:
                        <asp:TextBox ID="ExamStatusTextBox" runat="server" 
                            Text='<%# Bind("ExamStatus") %>' />
                        <br />
                        RerefenceName:
                        <asp:TextBox ID="RerefenceNameTextBox" runat="server" 
                            Text='<%# Bind("RerefenceName") %>' />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                            CommandName="Insert" Text="Insert" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        StudentID:
                        <asp:Label ID="StudentIDLabel" runat="server" Text='<%# Eval("StudentID") %>' />
                        <br />
                        Program:
                        <asp:Label ID="ProgramLabel" runat="server" Text='<%# Eval("Program") %>' />
                        <br />
                        Year:
                        <asp:Label ID="YearLabel" runat="server" Text='<%# Eval("Year") %>' />
                        <br />
                        Semester:
                        <asp:Label ID="SemesterLabel" runat="server" 
                            Text='<%# Eval("Semester") %>' />
                        <br />
                        SubjectID:
                        <asp:Label ID="SubjectIDLabel" runat="server" Text='<%# Eval("SubjectID") %>' />
                        <br />
                        ExamMark:
                        <asp:Label ID="ExamMarkLabel" runat="server" Text='<%# Bind("ExamMark") %>' />
                        <br />
                        CourseMark:
                        <asp:Label ID="CourseMarkLabel" runat="server" 
                            Text='<%# Bind("CourseMark") %>' />
                        <br />
                        FinalMark:
                        <asp:Label ID="FinalMarkLabel" runat="server" 
                            Text='<%# Bind("FinalMark") %>' />
                        <br />
                        Points:
                        <asp:Label ID="PointsLabel" runat="server" 
                            Text='<%# Bind("Points") %>' />
                        <br />
                        Decision:
                        <asp:Label ID="DecisionLabel" runat="server" Text='<%# Bind("Decision") %>' />
                        <br />
                        ExamStatus:
                        <asp:Label ID="ExamStatusLabel" runat="server" 
                            Text='<%# Bind("ExamStatus") %>' />
                        <br />
                        RerefenceName:
                        <asp:Label ID="RerefenceNameLabel" runat="server" 
                            Text='<%# Eval("RerefenceName") %>' />
                        <br />
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                            CommandName="Edit" Text="Edit" />
                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                            CommandName="New" Text="New" />
                    </ItemTemplate>
                </asp:FormView>
                <asp:SqlDataSource ID="dsStudMarks" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" 
                    InsertCommand="INSERT INTO StudentMarks(StudentID, SubjectID, Program, Year, Semester, ExamMark, CourseMark, FinalMark, Points, Decision, ExamStatus, RerefenceName) VALUES (@studentid, @subjectid, @program, @year, @semester, @examMark, @coursemark, @finalmark, @points, @decision, @ExamStatus, @RerefenceName)" 
                    SelectCommand="SELECT StudentID,Program, Year, Semester, SubjectID, ExamMark, CourseMark, FinalMark, Points, Decision, ExamStatus, RerefenceName  FROM StudentMarks WHERE (StudentID = @StudentID) AND (Year = @Year) AND (Semester = @Semester)" 
                    
                    
                    
                    UpdateCommand="UPDATE StudentMarks SET ExamMark = @ExamMark, CourseMark = @CourseMark, FinalMark = dbo.FinaleMark(@CourseMark, @ExamMark, @program), Points = @Points, Decision = dbo.ExamGrades(dbo.FinaleMark(@CourseMark, @ExamMark, @program), @program), ExamStatus = @ExamStatus, RerefenceName = @RerefenceName WHERE (StudentID = @studentid) AND (SubjectID = @subjectid)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GridView1" Name="StudentID" 
                            PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="ddlLevel" Name="Year" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="ddlSem" Name="Semester" 
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:ControlParameter ControlID="FormView1" Name="ExamMark" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="CourseMark" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="ddlProg" Name="program" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="Points" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="ExamStatus" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="RerefenceName" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="GridView1" Name="studentid" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="subjectid" 
                            PropertyName="SelectedValue" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:ControlParameter ControlID="FormView1" Name="studentid" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="subjectid" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="ddlProg" Name="program" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="ddlLevel" Name="year" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="ddlSem" Name="semester" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="examMark" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="coursemark" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="finalmark" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="points" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="decision" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="ExamStatus" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="FormView1" Name="RerefenceName" 
                            PropertyName="SelectedValue" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
            <td class="style10" style="vertical-align: top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="StudentID,Gender,Program,Year,Semester,Date_Joined,Session,Intake" 
                    DataSourceID="DSclassStuds" Visible="False">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="StudentID" HeaderText="StudentID" ReadOnly="True" 
                            SortExpression="StudentID" />
                        <asp:BoundField DataField="StudentName" HeaderText="StudentName" 
                            SortExpression="StudentName" />
                        <asp:BoundField DataField="StudentSurname" HeaderText="StudentSurname" 
                            SortExpression="StudentSurname" />
                        <asp:BoundField DataField="Program" HeaderText="Program" ReadOnly="True" 
                            SortExpression="Program" />
                        <asp:BoundField DataField="Year" HeaderText="Year" ReadOnly="True" 
                            SortExpression="Year" />
                        <asp:BoundField DataField="Semester" HeaderText="Semester" ReadOnly="True" 
                            SortExpression="Semester" />
                        <asp:BoundField DataField="Date_Joined" HeaderText="Class" 
                            ReadOnly="True" SortExpression="Date_Joined" />
                        <asp:BoundField DataField="Session" HeaderText="Session" ReadOnly="True" 
                            SortExpression="Session" />
                        <asp:BoundField DataField="Intake" HeaderText="Intake" ReadOnly="True" 
                            SortExpression="Intake" />
                        <asp:BoundField DataField="Status" HeaderText="Status" 
                            SortExpression="Status" />
                    </Columns>
                    <SelectedRowStyle BackColor="Red" />
                </asp:GridView>
                <asp:SqlDataSource ID="DSclassStuds" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" 
                    SelectCommand="SELECT enrollment.StudentID, enrollment.Gender, enrollment.Program, enrollment.Year, enrollment.Semester, enrollment.[Date Joined] AS Date_Joined, enrollment.Session, enrollment.Intake, enrollment.Status, enrollment.Date_Enrolled, StudentPersonalDetails.StudentName, StudentPersonalDetails.StudentSurname FROM enrollment INNER JOIN StudentPersonalDetails ON enrollment.StudentID = StudentPersonalDetails.StudentID WHERE (enrollment.Program = @Program) AND (enrollment.Year = @Year) AND (enrollment.Semester = @Semester) AND (enrollment.Intake = @Intake) AND (enrollment.Session = @Session) AND (enrollment.[Date Joined] = @Date_Joined)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlProg" Name="Program" 
                            PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="ddlLevel" Name="Year" 
                            PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="ddlSem" Name="Semester" 
                            PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="ddlIntake" Name="Intake" 
                            PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="ddlSess" Name="Session" 
                            PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="ddlClass" Name="Date_Joined" 
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:soccerConnectionString %>" 
                    SelectCommand="SELECT [Forms], [Description] FROM [forms]">
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
