Imports System.Reflection

Public Class PluginLoader
    Shared classesWriter As Action(Of PluginInfo, Type()) = GetType(PluginInfo).GetProperty("LoadedClassesWriter").GetValue(Nothing)
    Shared assemblyWriter As Action(Of PluginInfo, Assembly) = GetType(PluginInfo).GetProperty("ParentAssemblyWriter").GetValue(Nothing)
    Shared instancesWriter As Action(Of PluginInfo, IPluginBase()) = GetType(PluginInfo).GetProperty("InstancesWriter").GetValue(Nothing)
    Private Sub New()
    End Sub
    Public Shared Function LoadPlugins(path As String) As PluginInfo()
        If Not Directory.Exists(path) Then
            Return {} 'だってフォルダ無いんだもん
        End If
        Dim loaded As New List(Of PluginInfo)
        For Each i In Directory.GetFiles(path)
            Dim asm = Assembly.LoadFile(path)
            For Each j In asm.GetTypes.Where(Function(k) GetType(PluginInfo).IsAssignableFrom(k))
                Dim plgi As PluginInfo = j.InvokeMember("", BindingFlags.CreateInstance Or BindingFlags.Public, Nothing, Nothing, New Object() {})
                assemblyWriter(plgi, asm)
                Dim classes = plgi.LoadedClasses
                If classes Is Nothing OrElse classes.Length = 0 Then 'クラス自動判定処理をする場合
                    Dim loadedC As New List(Of Type)
                    Dim instance As New List(Of IPluginBase)
                    For Each k In asm.GetTypes.
                        Where(Function(l) GetType(IPluginBase).IsAssignableFrom(l)).
                        Where(Function(l) l <> GetType(IPluginBase)).
                        Where(Function(l) {GetType(IBackgroundThread), GetType(IWindowTask), GetType(IEditorWindow)}.Contains(l)) 'ここで読み込めるクラスを篩(ふる)う
                        Try
                            instance.Add(k.InvokeMember("", BindingFlags.CreateInstance Or BindingFlags.Public, Nothing, Nothing, New Object() {}))
                            loadedC.Add(k)
                        Catch ex As Exception
                        End Try
                    Next
                    classesWriter(plgi, loadedC.ToArray)
                    instancesWriter(plgi, instance.ToArray)
                Else '読み込めるクラスが指定されている場合
                    Dim loadedC As New List(Of Type)
                    Dim instance As New List(Of IPluginBase)
                    For Each k In classes.
                        Where(Function(l) GetType(IPluginBase).IsAssignableFrom(l)).
                        Where(Function(l) l <> GetType(IPluginBase)).
                        Where(Function(l) {GetType(IBackgroundThread), GetType(IWindowTask), GetType(IEditorWindow)}.Contains(l)) 'ここで読み込めるクラスを篩(ふる)う
                        Try
                            instance.Add(k.InvokeMember("", BindingFlags.CreateInstance Or BindingFlags.Public, Nothing, Nothing, New Object() {}))
                            loadedC.Add(k)
                        Catch ex As Exception
                        End Try
                    Next
                    classesWriter(plgi, loadedC.ToArray)
                    instancesWriter(plgi, instance.ToArray)
                End If
                loaded.Add(plgi)
            Next
        Next
        Return loaded.ToArray
    End Function
    Public Shared Function LoadPlugins() As PluginInfo()
        Return LoadPlugins(Path.Combine(Environment.CurrentDirectory, "Plugins"))
    End Function
End Class
