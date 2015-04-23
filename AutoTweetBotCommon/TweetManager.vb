Imports System.Text

Public Class TweetManager
    Private Shared tweets As New List(Of Tweet)(OpenTweets)
    Public Shared Function OpenTweets() As Tweet()
        Return Tweet.Open
    End Function
    Protected Friend Sub RegisterTweet(tweet As Tweet)
        If tweets.Contains(tweet) Then
            Return
        End If
        tweets.Add(tweet)
    End Sub
    Protected Friend Sub RegisterTweets(tweet As IEnumerable(Of Tweet))
        For Each i In tweet
            RegisterTweet(tweet)
        Next
    End Sub
    Public Sub CheckTimeAndTweet()
        For Each i In tweets
            i.CheckTimeAndTweet()
        Next
    End Sub
End Class
