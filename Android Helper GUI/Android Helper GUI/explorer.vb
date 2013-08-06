Imports System.IO
Public Class explorer

    Private Sub explorer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub PopulateTreeView()
        Dim rootNode As TreeNode

        Dim info As New DirectoryInfo("../..")
        If info.Exists Then
            rootNode = New TreeNode(info.Name)
            rootNode.Tag = info
            GetDirectories(info.GetDirectories(), rootNode)
            TreeView1.Nodes.Add(rootNode)
        End If

    End Sub

    Private Sub GetDirectories(ByVal subDirs() As DirectoryInfo, _
        ByVal nodeToAddTo As TreeNode)

        Dim aNode As TreeNode
        Dim subSubDirs() As DirectoryInfo
        Dim subDir As DirectoryInfo
        For Each subDir In subDirs
            aNode = New TreeNode(subDir.Name, 0, 0)
            aNode.Tag = subDir
            aNode.ImageKey = "folder"
            subSubDirs = subDir.GetDirectories()
            If subSubDirs.Length <> 0 Then
                GetDirectories(subSubDirs, aNode)
            End If
            nodeToAddTo.Nodes.Add(aNode)
        Next subDir

    End Sub
    Public Sub New()
        InitializeComponent()
        PopulateTreeView()

    End Sub 'New
    Private Sub treeView1_NodeMouseClick(ByVal sender As Object, _
    ByVal e As TreeNodeMouseClickEventArgs) _
        Handles TreeView1.NodeMouseClick

        Dim newSelected As TreeNode = e.Node
        listView1.Items.Clear()
        Dim nodeDirInfo As DirectoryInfo = _
        CType(newSelected.Tag, DirectoryInfo)
        Dim subItems() As ListViewItem.ListViewSubItem
        Dim item As ListViewItem = Nothing

        Dim dir As DirectoryInfo
        For Each dir In nodeDirInfo.GetDirectories()
            item = New ListViewItem(dir.Name, 0)
            subItems = New ListViewItem.ListViewSubItem() _
                {New ListViewItem.ListViewSubItem(item, "Directory"), _
                New ListViewItem.ListViewSubItem(item, _
                dir.LastAccessTime.ToShortDateString())}

            item.SubItems.AddRange(subItems)
            listView1.Items.Add(item)
        Next dir
        Dim file As FileInfo
        For Each file In nodeDirInfo.GetFiles()
            item = New ListViewItem(file.Name, 1)
            subItems = New ListViewItem.ListViewSubItem() _
                {New ListViewItem.ListViewSubItem(item, "File"), _
                New ListViewItem.ListViewSubItem(item, _
                file.LastAccessTime.ToShortDateString())}

            item.SubItems.AddRange(subItems)
            listView1.Items.Add(item)
        Next file

        listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub
End Class