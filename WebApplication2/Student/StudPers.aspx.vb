
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls.FormView
Partial Public Class WebForm5


    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Private Sub DetailsView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewUpdateEventArgs) Handles DetailsView1.ItemUpdating
    '    Dim sql As String
    '    Dim cmd As SqlCommand = Nothing
    '    Dim txtDateofBith, txtContactNumber, txtemaiAdd As TextBox
    '    txtDateofBith = DetailsView1.FindControl("DateOfBirth")
    '    sql = "update studentpersonaldetails set DateofBirth = @date Contact_number = @cont EmailAddress = @email "

    '    cmd.CommandText = sql
    '    cmd.Parameters.AddWithValue("@date", txtDateofBith.Text)

    'End Sub





    
    Protected Sub UpdateButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Dim cnn As String = ConfigurationManager.ConnectionStrings("soccerConnectionstring").ConnectionString.ToString
        'Dim sql As String
        'Dim CNCTIN As SqlConnection
        'CNCTIN = New SqlConnection(cnn)


        'Dim cmd As New SqlCommand("", CNCTIN)



        'Dim txtDateofBith, txtContactNumber, txtemaiAdd As TextBox
        ''txtDateofBith = FormView1.FindControl("DateOfBirth")

        'txtContactNumber = FormView1.FindControl("Contact_NumberTextBox")
        'txtemaiAdd = FormView1.FindControl("EmailAddressTextBox")
        'cmd.Parameters.AddWithValue("@cont", txtContactNumber.Text)
        'cmd.Parameters.AddWithValue("@email", txtemaiAdd.Text)
        'sql = "update studentpersonaldetails set [Contact number] = @cont, EmailAddress = @email WHERE STUDENTID = '" & Session("userName") & "'"
        'cmd.CommandText = sql
        'CNCTIN.Open()
        'cmd.ExecuteNonQuery()
        'CNCTIN.Close()
    End Sub

    'Protected Sub FormView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewPageEventArgs) Handles FormView1.PageIndexChanging

    'End Sub
End Class