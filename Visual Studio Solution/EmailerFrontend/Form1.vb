Imports System.Net.Mail

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()

            Smtp_Server.UseDefaultCredentials = True
            Smtp_Server.Credentials = New Net.NetworkCredential("username@somedonain.com", "password")
            Smtp_Server.Port = Convert.ToInt32(efPort.Text)
            Smtp_Server.EnableSsl = False
            Smtp_Server.Host = efHost.Text

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(efFrom.Text)
            e_mail.To.Add(efTo.Text)
            e_mail.Subject = efSubj.Text
            e_mail.IsBodyHtml = False
            e_mail.Body = efBody.Text

            Smtp_Server.Send(e_mail)
            'MsgBox("Mail Sent")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
