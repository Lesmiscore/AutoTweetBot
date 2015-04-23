Public Class PluginTweet
    Inherits Tweet
    Dim plgctx As PluginContext
    Friend Sub New(plgctx As PluginContext)
        MyBase.New(Date.MinValue)
        Me.plgctx = plgctx
    End Sub
End Class