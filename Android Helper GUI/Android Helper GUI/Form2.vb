Imports System.IO
Imports JoeBlogs
Imports CookComputing.XmlRpc
Public Class Form2
    Dim login As String


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        Button1.Enabled = False

        Try
            If TextBox1.Text = "" Then
                If MsgBox("You are choosing to continue as a ""Guest""! Continue?", MsgBoxStyle.YesNo, "Message") = MsgBoxResult.Yes Then
                    Form1.Show()
                    Me.Hide()
                Else

                End If
            Else
                Dim wp As New WordPressWrapper("http://urgero.org/home/xmlrpc.php", TextBox1.Text, TextBox2.Text)

                login = wp.GetUserInfo.Nickname(TextBox1.Text)
                Form1.Show()
                Me.Hide()
            End If

        Catch ex As Exception
            'MsgBox(ex.ToString)
            If ex.ToString.Contains("403") Then
                Timer1.Enabled = False
                Timer1.Stop()
                MsgBox("Sorry, that is an incorrect username or password!", MsgBoxStyle.Exclamation, "Oops!")
            Else
                My.Computer.Registry.CurrentUser.CreateSubKey("urgeroADBGUI")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\urgeroADBGUI",
                  "current_username", TextBox1.Text)
                My.Computer.Registry.CurrentUser.CreateSubKey("urgeroADBGUI")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\urgeroADBGUI",
                  "current_p", TextBox2.Text)
                Timer1.Enabled = False
                Timer1.Stop()
                Form1.Show()
                Me.Hide()

            End If
        End Try
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        Button1.Enabled = True


        'Form1.Show()
        'Me.Hide()
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'comment for GitHub
        AcceptButton = Button1
        If System.IO.File.Exists("CookComputing.XmlRpcV2.dll") Then
        Else
            Button1.Enabled = False
            My.Computer.Network.DownloadFile("http://urgero.org/adbgui/CookComputing.XmlRpcV2.dll", "CookComputing.XmlRpcV2.dll")
            Button1.Enabled = True
        End If
        If System.IO.File.Exists("JoeBlogs.dll") Then

        Else
            Button1.Enabled = False
            My.Computer.Network.DownloadFile("http://urgero.org/adbgui/JoeBlogs.dll", "JoeBlogs.dll")
            Button1.Enabled = True
        End If
        login1()
    End Sub
    Private Sub login1()
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\urgeroADBGUI", "current_username", Nothing) = "" Then

        Else
            TextBox1.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\urgeroADBGUI", "current_username", Nothing)
            TextBox2.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\urgeroADBGUI", "current_p", Nothing)
            Timer1.Enabled = True
            Timer1.Start()

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Button1.PerformClick()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://urgero.org/home/wp-login.php")
    End Sub
End Class