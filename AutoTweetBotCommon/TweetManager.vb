Imports System.Text

Public Class TweetManager
    Private Shared tweets As New List(Of Tweet)(OpenTweets)
    Public Shared Function OpenTweets() As Tweet()
        Return Tweet.Open
    End Function
End Class
