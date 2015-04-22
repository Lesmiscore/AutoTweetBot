Public Class PluginTweetManager
    Inherits TweetManager
    Dim plgctx As PluginContext
    Private Sub New(plgctx As PluginContext)
        MyBase.New(Date.Now)
        Me.plgctx = plgctx
    End Sub
End Class