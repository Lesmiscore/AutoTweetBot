Imports System.Text

Public Class TweetManager
    Public Shared Function OpenTweets() As Tweet()
        Return Tweet.Open
    End Function
End Class
