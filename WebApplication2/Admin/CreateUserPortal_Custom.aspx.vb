Imports System.Data.SqlClient
Partial Public Class CreateUser_Custom
    Inherits System.Web.UI.Page

    Protected Sub btnCreateUser_Click(sender As Object, e As EventArgs) Handles btnCreateUser.Click
        Dim sql As String = ""



        Dim cmd As New SqlCommand
        Dim cnn2 As SqlConnection = New SqlConnection(ConnectionString)


        If Page.IsValid Then





            sql = "spCreateStudentAccout"

            With cmd

                .Connection = cnn2
                .CommandText = sql
                .CommandType = CommandType.StoredProcedure

                param = New SqlParameter("@stud", UserName.Text)
                .Parameters.Add(param)

                param = New SqlParameter("@Password ", Password.Text)
                .Parameters.Add(param)

                param = New SqlParameter("@PasswordSalt", "123451")
                .Parameters.Add(param)

                param = New SqlParameter("@Email", Email.Text)
                .Parameters.Add(param)

                param = New SqlParameter("@Question", Question.Text)
                .Parameters.Add(param)

                param = New SqlParameter("@Answer", Answer.Text)
                .Parameters.Add(param)




                cnn2.Open()

                Try
                    .ExecuteNonQuery()
                    'Dim enrol As New Enrol
                    'stud = CirsmContext.StudentPersonalDetails.Where(Function(x) x.StudentID = UserName.Text).Single
                    'With enrol
                    '    .FullName = stud.FullName
                    '    .Email = Email.Text

                    'End With

                    'SendEmail(enrol, EmailType.UserCreated,, LoginMsg)
                    lbCreateUserResults.Text = "Account Successfully created!!."
                    ModalPopupExtender_Creater.Show()


                Catch ex As Exception
                    lbCreateUserResults.Text = ex.Message
                    ModalPopupExtender_Creater.Show()
                Finally
                    cnn2.Close()
                End Try







            End With
        Else
            lbCreateUserResults.Text = "Invalid StudentID."
            ModalPopupExtender_Creater.Show()

        End If



    End Sub
End Class