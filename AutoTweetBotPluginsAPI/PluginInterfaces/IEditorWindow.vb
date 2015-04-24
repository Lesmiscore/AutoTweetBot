﻿''' <summary>
''' ツイートを編集するウィンドウを表示するオブジェクトを表します
''' </summary>
''' <remarks></remarks>
Public Interface IEditorWindow
    Inherits IPluginBase
    ''' <summary>
    ''' ツイートを編集するウィンドウを開きます
    ''' </summary>
    ''' <param name="tweet"></param>
    ''' <param name="plgctx"></param>
    ''' <remarks></remarks>
    Sub OpenEditor(tweet As Tweet, plgctx As PluginContext)
    ''' <summary>
    ''' 編集をキャンセルし、ウィンドウを閉じることを通知します。
    ''' </summary>
    ''' <remarks></remarks>
    Sub NotifyCancel()
End Interface
