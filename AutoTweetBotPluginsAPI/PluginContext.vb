Public NotInheritable Class PluginContext
    Dim name As String
    Public ReadOnly Property PluginName As String
        Get
            Return name
        End Get
    End Property
    Public ReadOnly Property InternalIdenfier As String
        Get
            Return name.Where(Function(i) Not (vbCrLf + " " + Path.DirectorySeparatorChar + Path.GetInvalidPathChars + Path.GetInvalidFileNameChars + Path.PathSeparator).Contains(i))
        End Get
    End Property
    Public Function CreateTweet() As PluginTweetManager
        Return New PluginTweetManager
    End Function
End Class
