Imports System.Reflection

Public MustInherit Class PluginInfo
    Dim ctx As New PluginContext(Me)
    Dim loaded As Type()
    Dim parent As Assembly
    Dim instances As IPluginBase()
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
    ''' <summary>
    ''' 実際に読み込まれたクラスを取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LoadedClasses As Type()
        Get
            Return loaded
        End Get
    End Property
    ''' <summary>
    ''' このプラグインを格納するアセンブリを取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ParentAssembly As Type()
        Get
            Return loaded
        End Get
    End Property
    Public MustOverride Sub SendTime(plgctx As PluginContext)
    Public ReadOnly Property Context As PluginContext
        Get
            Return ctx
        End Get
    End Property
    Protected Friend Shared ReadOnly Property LoadedClassesWriter As Action(Of PluginInfo, Type())
        Get
            Return Sub(pi As PluginInfo, classes As Type())
                       pi.loaded = classes
                   End Sub
        End Get
    End Property
    Protected Friend Shared ReadOnly Property ParentAssemblyWriter As Action(Of PluginInfo, Assembly)
        Get
            Return Sub(pi As PluginInfo, classes As Assembly)
                       pi.parent = classes
                   End Sub
        End Get
    End Property
    Protected Friend Shared ReadOnly Property InstancesWriter As Action(Of PluginInfo, IPluginBase())
        Get
            Return Sub(pi As PluginInfo, pluginB As IPluginBase())
                       pi.instances = pluginB
                   End Sub
        End Get
    End Property
End Class
