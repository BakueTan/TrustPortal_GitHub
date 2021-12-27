Imports System.Data.SqlClient
Partial Public Class StudentReport
    Inherits System.Web.UI.Page

    Public cnn As SqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("ActivePage") = "ExamResults"

        Try
            cnn = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionString").ConnectionString)
            Dim cmd As SqlCommand
            Dim sum, bbf As Decimal
            Dim section As String



            Try
                cnn.Close()
            Catch ex As Exception

            End Try

            ' Dim sql1 As String
            Dim drr As SqlDataReader = Nothing
            ' Dim section As String
            '  Dim drr As SqlDataReader
            Dim sql As String = " select sum(amount) from Ledgertransactions where accnumber  = '" & Session("userName") & "' and pperiod <= ( select period from resultscutoff )"
            Dim sql1 As String = " select bbf from ledgerbbf where accnumber  = '" & Session("userName") & "'"

            cmd = New SqlCommand(sql, cnn)

            Try
                cnn.Open()
                sum = cmd.ExecuteScalar.ToString

            Catch ex As Exception
            Finally
                cnn.Close()

            End Try

            sum = Math.Round(sum, 2)

            cmd = New SqlCommand(sql1, cnn)



            Try
                cnn.Open()
                bbf = cmd.ExecuteScalar

            Catch ex As Exception
            Finally
                cnn.Close()
            End Try
            sum = sum + bbf

            If sum <= 0 Then


                Try
                    'Dim cnn1 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString)
                    ' cnn.Close()



                    If Session("Section") = "High School" Then
                        ' Response.Redirect("HighSchoolReport.aspx")
                    ElseIf Session("Section") = "IT" Then

                        If Session("Program") = "BMIS" Then

                            Session("Amount") = sum

                        ElseIf Session("Program") = "DMIS" Then

                            Session("Amount") = sum
                            Response.Redirect("DiplomaPage.aspx")

                        ElseIf Session("Program") = "DNEP" Then

                            Session("Amount") = sum
                            Response.Redirect("Dtel.aspx")
                        ElseIf Session("Program").ToString.ToUpper = "DTEL" Then
                            Session("Amount") = sum

                            Response.Redirect("~/Student/Dtel.aspx")
                        End If
                    ElseIf Session("Section") = "Business School" Then
                        Session("Amount") = sum

                        Response.Redirect("~/Student/BusinessSchool.aspx")
                    End If



                    ' cnn.Close()
                Catch ex As Exception
                Finally


                End Try
            Else
                Session("Amount") = sum
                Response.Redirect("Unpaid.aspx")
            End If




        Catch ex As Exception


        Finally

            cnn.Close()
            '  MsgBox(ex.Message)
        End Try




    End Sub


End Class