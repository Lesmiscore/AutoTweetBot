Public NotInheritable Class PluginContext
    Private pi As PluginInfo

    Protected Sub New(pi As PluginInfo)
        Me.pi = pi
    End Sub

    Public ReadOnly Property PluginName As String
        Get
            Return pi.PluginName
        End Get
    End Property
    Public ReadOnly Property InternalIdenfier As String
        Get
            Return PluginName.Where(Function(i) Not (vbCrLf + " " + Path.DirectorySeparatorChar + Path.GetInvalidPathChars + Path.GetInvalidFileNameChars + Path.PathSeparator).Contains(i))
        End Get
    End Property
    Public Function CreateTweet() As PluginTweet
        Return New PluginTweet(Me)
    End Function
End Class
