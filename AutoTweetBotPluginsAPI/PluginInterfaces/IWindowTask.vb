''' <summary>
''' ウィンドウを表示し、プラグインを操作・設定します
''' </summary>
''' <remarks></remarks>
Public Interface IWindowTask
    Inherits IWindowBase
    ''' <summary>
    ''' ウィンドウを開きます
    ''' </summary>
    ''' <param name="plgctx"></param>
    ''' <remarks></remarks>
    Sub OpenWindow(plgctx As PluginContext)
End Interface