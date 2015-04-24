''' <summary>
''' ツイートを編集するウィンドウを表示するオブジェクトを表します
''' </summary>
''' <remarks></remarks>
Public Interface IEditorWindow
    Inherits IWindowBase
    ''' <summary>
    ''' ツイートを編集するウィンドウを開きます
    ''' </summary>
    ''' <param name="tweet"></param>
    ''' <param name="plgctx"></param>
    ''' <remarks></remarks>
    Sub OpenEditor(tweet As Tweet, plgctx As PluginContext)
End Interface
