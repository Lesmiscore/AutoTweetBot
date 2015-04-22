Imports CoreTweet
Imports System.Threading

Public Class AccountAuthManager
    Private Shared ReadOnly consumerKey As String = "jRJyQ12Kc0yDM20Lg6VlcBoBg"
    Private Shared ReadOnly consumerSecret As String = "nZRhSrJT9vWzv9kyqi3MfPxMsaAKETXf6v7gfNGLTOjQCpjuyg"
    Public Shared Function GetAccount(allowDialog As Boolean) As Tokens
        Dim sm = SettingsManager.Open
        If Not sm.IsAuthencated Then
            Dim session = OAuth.Authorize(consumerKey, consumerSecret)
            Dim n As Object()
            n = New LoginForm().ShowDialog(session)
            sm.IsAuthencated = True
            sm.AuthencateKey = n(0)
            sm.AuthencateKeySecret = n(1)
            sm.Commit()
            Return n(2)
        End If
        Return Tokens.Create(consumerKey, consumerSecret, sm.AuthencateKey, sm.AuthencateKeySecret)
    End Function
End Class
