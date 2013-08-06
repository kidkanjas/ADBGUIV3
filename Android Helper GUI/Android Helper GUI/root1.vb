Imports System.IO
Imports Ionic.Zip
Public Class root1

    Private Sub root_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If File.Exists("bin4ry/RunMe.bat") Then
            GoTo confile
        Else

        End If
        If MsgBox("We need to download the script, continue?", MsgBoxStyle.YesNo, "Download needed.") = MsgBoxResult.Yes Then
            My.Computer.Network.DownloadFile("http://urgero.org/adbgui/root.zip", "root.zip", vbNullString, vbNullString, True, 5000, True)
            My.Computer.Network.DownloadFile("http://urgero.org/adbgui/run.bat", "run.bat", vbNullString, vbNullString, True, 5000, True)
            Dim ZipToUnpack As String = "root.zip"
            Dim UnpackDirectory As String = "bin4ry"
            Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
                Dim file1 As ZipEntry
                ' here, we extract every entry, but we could extract conditionally,
                ' based on entry name, size, date, checkbox status, etc.   
                For Each file1 In zip1
                    file1.Extract(UnpackDirectory, ExtractExistingFileAction.OverwriteSilently)
                Next
            End Using
            MsgBox("Finished unpacking root files, starting script!", MsgBoxStyle.Information, "Done!")
            Process.Start("run.bat")
            GoTo confile2

            Me.Hide()
        End If
confile:
        If MsgBox("Run Script?", MsgBoxStyle.YesNo, "Run?") = MsgBoxResult.Yes Then
            Process.Start("run.bat")
        Else
confile2:

            Me.Hide()

        End If
    End Sub
End Class