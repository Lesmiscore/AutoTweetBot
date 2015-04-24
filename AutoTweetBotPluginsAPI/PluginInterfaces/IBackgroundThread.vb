''' <summary>
''' バックグラウンドで処理をするオブジェクトを表します
''' </summary>
''' <remarks></remarks>
Public Interface IBackgroundThread
    Inherits IDisposable, IPluginBase
    ''' <summary>
    ''' バックグラウンドで実行する処理
    ''' </summary>
    ''' <param name="plgctx"></param>
    ''' <remarks></remarks>
    Sub DoWork(plgctx As PluginContext)
End Interface
