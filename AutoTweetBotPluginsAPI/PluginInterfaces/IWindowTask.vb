''' <summary>
''' ウィンドウを表示し、プラグインを操作・設定するオブジェクトを表します
''' </summary>
''' <remarks></remarks>
Public Interface IWindowTask
    Inherits IDisposable, IPluginBase
    ''' <summary>
    ''' ウィンドウを開きます
    ''' </summary>
    ''' <param name="plgctx"></param>
    ''' <remarks></remarks>
    Sub OpenWindow(plgctx As PluginContext)
    ''' <summary>
    ''' ウィンドウを強制的に閉じます。
    ''' 通常は呼び出されません。
    ''' </summary>
    ''' <remarks></remarks>
    Sub CloseWindow()
End Interface