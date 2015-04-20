Imports CoreTweet.OAuth

Public Class LoginForm
    Dim user_key, user_secret As String
    Dim session As OAuthSession
    Dim token As CoreTweet.Tokens
    Dim allowClose As Boolean = False
    Private Sub LoginForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If allowClose Then
            Return
        End If
        Application.Exit()
    End Sub
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Overloads Function ShowDialog(ses As OAuthSession) As Object()
        Me.WebBrowser1.Url = ses.AuthorizeUri
        user_key = Nothing
        user_secret = Nothing
        session = ses
        Me.ShowDialog()
        user_key = token.AccessToken
        user_secret = token.AccessTokenSecret
        Return {user_key, user_secret, token}
    End Function

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        If e.Url.Host = "nao20010128nao.blogspot.jp" Then
            Dim query = e.Url.Query
            Dim queries = query.Split("&"c, "?"c)
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            token = session.GetTokens(tbPIN.Text)
            If token Is Nothing Then
                Throw New Exception
            End If
        Catch ex As Exception
            MessageBox.Show("PINが間違っています。")
            Return
        End Try
        allowClose = True
        Me.Close()
    End Sub
End Class