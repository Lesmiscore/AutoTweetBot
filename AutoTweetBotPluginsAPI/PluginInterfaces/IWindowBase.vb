''' <summary>
''' ウィンドウを表示し、プラグインを操作・設定します。
''' ただし、このインターフェイスは基本インターフェイスです。
''' </summary>
''' <remarks></remarks>
Public Interface IWindowBase
    Inherits IPluginBase
    ''' <summary>
    ''' ウィンドウが開いているか確認します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsWindowOpened As Boolean
    ''' <summary>
    ''' ウィンドウを閉じることを通知します。
    ''' </summary>
    ''' <remarks></remarks>
    Sub NotifyClose()
End Interface
