Public MustInherit Class PluginInfo
    Dim ctx As New PluginContext(Me)
    ''' <summary>
    ''' プラグインの名前を取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride ReadOnly Property PluginName As String
    ''' <summary>
    ''' プラグインを読み込むクラスを取得します。
    ''' </summary>
    ''' <value>nullもしくは長さ0の配列だった場合、AutoTweetBotが自動的に検索します。</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride ReadOnly Property PluginClasses As Type()
    Public MustOverride Sub SendTime(plgctx As PluginContext)
    Public ReadOnly Property Context As PluginContext
        Get

        End Get
    End Property
End Class
