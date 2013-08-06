Imports RegawMOD.Android
Imports System.IO
Public Class Form1
    Dim android As AndroidController
    Dim device As Device
    Private WithEvents MyProcess As Process
    Private Delegate Sub AppendOutputTextDelegate(ByVal text As String)
    Dim serial As String
    Dim verint As Integer = 36
    Dim VerString As String = "3.4.2"
    Private Sub ExiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExiToolStripMenuItem.Click
        End

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ofd1.ShowDialog()
            TextBox1.Text = ofd1.FileName

        Catch ex As Exception
            MsgBox("Invalid file name!", MsgBoxStyle.Exclamation, "ADB Helper")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim p As New ProcessStartInfo
        p.FileName = "adb.exe"
        Dim arg As String = ofd1.FileName
        p.Arguments = "install " + arg
        p.WindowStyle = ProcessWindowStyle.Normal
        Process.Start(p)

    End Sub

    Private Sub InstallADBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstallADBToolStripMenuItem.Click
        Try
            If MsgBox("This will download and install ADB and FASTBOOT into System32, continue?", MsgBoxStyle.YesNo, "Install core files?") = MsgBoxResult.Yes Then

                Try
                    My.Computer.Network.DownloadFile("http://urgero.org/adbgui/adb.exe", "adb.exe", vbNullString, vbNullString, True, 5000, True)
                    My.Computer.Network.DownloadFile("http://urgero.org/adbgui/AdbWinApi.dll", "AdbWinApi.dll", vbNullString, vbNullString, True, 5000, True)
                    My.Computer.Network.DownloadFile("http://urgero.org/adbgui/AdbWinUsbApi.dll", "AdbWinUsbApi.dll", vbNullString, vbNullString, True, 5000, True)
                    My.Computer.Network.DownloadFile("http://urgero.org/adbgui/fastboot.exe", "fastboot.exe", vbNullString, vbNullString, True, 5000, True)
                Catch ex As Exception
                    MsgBox("Could Not Update Completely!", MsgBoxStyle.Critical, "Error!")
                    MsgBox("Shutting down application!", MsgBoxStyle.Critical, "Error!")
                    End

                End Try

                Try
                    FileCopy("adb.exe", "C:\Windows\adb.exe")
                    System.IO.File.Delete("adb.exe")

                    FileCopy("AdbWinApi.dll", "C:\Windows\AdbWinApi.dll")
                    System.IO.File.Delete("AdbWinApi.dll")

                    FileCopy("AdbWinUsbApi.dll", "C:\Windows\AdbWinUsbApi.dll")
                    System.IO.File.Delete("AdbWinUsbApi.dll")

                    FileCopy("fastboot.exe", "C:\Windows\fastboot.exe")
                    System.IO.File.Delete("fastboot.exe")

                    MsgBox("Finished Downloading and Installing! You are now ready to use the program!", MsgBoxStyle.Information, "ADB GUI")

                Catch ex As Exception
                    MsgBox("Could not copy files to the system directory! Please make sure you run as admin!", MsgBoxStyle.Critical, "Error!")
                    MsgBox("Shutting down application!", MsgBoxStyle.Critical, "Error!")
                    End
                End Try

            Else
            End If
        Catch ex As Exception
            MsgBox("Please run this program as Administrator to gain access to System32!", MsgBoxStyle.Information, "ADB GUI")


        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim p As New ProcessStartInfo
        p.FileName = "adb.exe"
        Dim arg As String = ofd1.FileName
        p.Arguments = "reboot bootloader"
        p.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(p)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim p As New ProcessStartInfo
        p.FileName = "adb.exe"
        Dim arg As String = ofd1.FileName
        p.Arguments = "reboot recovery"
        p.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(p)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim p As New ProcessStartInfo
        p.FileName = "adb.exe"
        Dim arg As String = ofd1.FileName
        p.Arguments = "reboot fastboot"
        p.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(p)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim p As New ProcessStartInfo
        p.FileName = "adb.exe"
        Dim arg As String = ofd1.FileName
        p.Arguments = "logcat"
        p.WindowStyle = ProcessWindowStyle.Normal
        Process.Start(p)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MsgBox("Please be aware, this should only be used for devs and other advanced users! Please hit no if you do not know what this does!", MsgBoxStyle.YesNo, "ADB GUI") = MsgBoxResult.Yes Then

            Dim p As New ProcessStartInfo
            p.FileName = "adb.exe"
            Dim arg As String = ofd1.FileName
            p.Arguments = "sync"
            p.WindowStyle = ProcessWindowStyle.Normal
            Process.Start(p)
        Else

        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim p As New ProcessStartInfo
        p.FileName = "adb.exe"
        Dim arg As String = ofd1.FileName
        p.Arguments = "shell"
        p.WindowStyle = ProcessWindowStyle.Normal
        Process.Start(p)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim p As New ProcessStartInfo
        p.FileName = "adb.exe"
        Dim arg As String = ofd1.FileName
        p.Arguments = "remount"
        p.WindowStyle = ProcessWindowStyle.Normal
        Process.Start(p)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        MsgBox("This will NOT root your device, your device needs to be rooted before hand before running this command, Continue?", MsgBoxStyle.YesNo, "ADB GUI")
        If MsgBoxResult.Yes Then
            Dim p As New ProcessStartInfo
            p.FileName = "adb.exe"
            Dim arg As String = ofd1.FileName
            p.Arguments = "root"
            p.WindowStyle = ProcessWindowStyle.Normal
            Process.Start(p)
        Else

        End If

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ofd2.ShowDialog()
        Dim rec1 As String = ofd2.FileName
        Try
            Dim p As New ProcessStartInfo
            p.FileName = "adb.exe"
            Dim arg As String = ofd1.FileName
            p.Arguments = "reboot fastboot"
            p.WindowStyle = ProcessWindowStyle.Normal
            Process.Start(p)


            Shell("ping 192.0.2.2 -n 1 -w 10000 > nul")

            Dim p2 As New ProcessStartInfo
            p2.FileName = "adb.exe"
            p2.Arguments = "flash recovery " + ofd2.FileName
            p2.WindowStyle = ProcessWindowStyle.Normal
            Process.Start(p)
        Catch ex As Exception
            MsgBox("Possible Error has occured while trying to flash recovery." + ex.ToString + " Please send the error code to Me at urgero.org/ticket", MsgBoxStyle.Exclamation, "Error has occured")

        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        ofd3.ShowDialog()
        Dim rec1 As String = ofd3.FileName
        Try
            Dim p As New ProcessStartInfo
            p.FileName = "adb.exe"
            p.Arguments = "reboot fastboot"
            p.WindowStyle = ProcessWindowStyle.Normal
            Process.Start(p)


            Shell("ping 192.0.2.2 -n 1 -w 20000 > nul")

            Dim p2 As New ProcessStartInfo
            p2.FileName = "adb.exe"
            p2.Arguments = "flash boot " + ofd3.FileName
            p2.WindowStyle = ProcessWindowStyle.Normal
            Process.Start(p)
        Catch ex As Exception
            MsgBox("Possible Error has occured while trying to flash recovery." + ex.ToString + " Please send the error code to Me at urgero.org/ticket", MsgBoxStyle.Exclamation, "Error has occured")

        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("This program is brought to you by: Mitchell Urgero of URGERO.ORG (c)URGERO.ORG" + vbNewLine + " Application Version: " + VerString, MsgBoxStyle.Information, "About")

    End Sub
    Private Function USBID()
        Dim USBClass As New System.Management.ManagementClass("Win32_USBHub")
        Dim USBCollection As System.Management.ManagementObjectCollection = USBClass.GetInstances()
        Dim USB As System.Management.ManagementObject

        For Each USB In USBCollection
            Me.ListBox1.Items.Add("Device Name: " & USB("Name").ToString())
            Me.ListBox1.Items.Add("-----------------------------------")

            'Me.ListBox1.Items.Add("PNP Device ID = " & USB("PNPDeviceID").ToString())
        Next USB
    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Try
                If TextBox2.Text = "devmode9184" Then
                    ListBox1.Enabled = True
                    ListBox1.Visible = True
                    Button13.Enabled = True
                    Button13.Visible = True
                    Button11.Visible = True
                    Button12.Visible = True
                    Button17.Visible = True
                Else
                    MsgBox("Wrong code to enter Developer Mode!", MsgBoxStyle.Information, "Error!")
                    ListBox1.Enabled = False
                    ListBox1.Visible = False
                    TextBox2.Clear()
                    CheckBox1.Checked = False
                    Button13.Enabled = False
                    Button13.Visible = False
                    Button11.Visible = False
                    Button12.Visible = False
                    Button17.Visible = False
                End If
            Catch ex As Exception

            End Try
        Else
            ListBox1.Enabled = False
            ListBox1.Visible = False
            Button13.Enabled = False
            Button13.Visible = False
        End If

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        USBID()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Me.Text = "ADB Helper V: " + VerString

        TabControl1.Enabled = False
        If System.IO.File.Exists("C:\Windows\adb.exe") Then

        Else
            If MsgBox("It seems you are missing some important files from your System32 Directory that are required for this program to run. Would you like to download and install them now? them now?", MsgBoxStyle.YesNo, "Need further installation!") = MsgBoxResult.Yes Then

                Try
                    If MsgBox("This will download and install ADB and FASTBOOT into System32, continue?", MsgBoxStyle.YesNo, "Install core files?") = MsgBoxResult.Yes Then


                        Try
                            My.Computer.Network.DownloadFile("http://urgero.org/adbgui/adb.exe", "adb.exe", vbNullString, vbNullString, True, 5000, True)
                            My.Computer.Network.DownloadFile("http://urgero.org/adbgui/AdbWinApi.dll", "AdbWinApi.dll", vbNullString, vbNullString, True, 5000, True)
                            My.Computer.Network.DownloadFile("http://urgero.org/adbgui/AdbWinUsbApi.dll", "AdbWinUsbApi.dll", vbNullString, vbNullString, True, 5000, True)
                            My.Computer.Network.DownloadFile("http://urgero.org/adbgui/fastboot.exe", "fastboot.exe", vbNullString, vbNullString, True, 5000, True)
                        Catch ex As Exception
                            MsgBox("Could Not Update Completely!", MsgBoxStyle.Critical, "Error!")
                            MsgBox("Shutting down application!", MsgBoxStyle.Critical, "Error!")
                            End

                        End Try

                        Try
                            FileCopy("adb.exe", "C:\Windows\adb.exe")
                            System.IO.File.Delete("adb.exe")

                            FileCopy("AdbWinApi.dll", "C:\Windows\AdbWinApi.dll")
                            System.IO.File.Delete("AdbWinApi.dll")

                            FileCopy("AdbWinUsbApi.dll", "C:\Windows\AdbWinUsbApi.dll")
                            System.IO.File.Delete("AdbWinUsbApi.dll")

                            FileCopy("fastboot.exe", "C:\Windows\fastboot.exe")
                            System.IO.File.Delete("fastboot.exe")

                            MsgBox("Finished Downloading and Installing! You are now ready to use the program!", MsgBoxStyle.Information, "ADB GUI")

                        Catch ex As Exception
                            MsgBox("Could not copy files to the system directory! Please make sure you run as admin!", MsgBoxStyle.Critical, "Error!")
                            MsgBox("Shutting down application!", MsgBoxStyle.Critical, "Error!")
                            End
                        End Try

                    Else
                    End If
                Catch ex As Exception
                    MsgBox("Please run this program as Administrator to gain access to System32!", MsgBoxStyle.Information, "ADB GUI")


                End Try
            Else
                GoTo resno
            End If
        End If
resno:
verline:


        BackgroundWorker1.RunWorkerAsync()


    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        BackgroundWorker3.RunWorkerAsync()

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Process.Start("cmd.exe")
    End Sub


    Public Function GetProp( _
    key As String _
) As String

    End Function

    Private Sub Bin4ryRootScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Bin4ryRootScriptToolStripMenuItem.Click

        root1.Show()


    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Try
            If System.IO.File.Exists("odin422.exe") Then
                Process.Start("odin422.exe")
            Else
                If MsgBox("You must download Odin first, would you like to do that now?", MsgBoxStyle.YesNo, "Install Odin?") = MsgBoxResult.Yes Then
                    My.Computer.Network.DownloadFile("http://urgero.org/adbgui/odin422.exe", "odin422.exe", vbNullString, vbNullString, True, 5000, True)
                    Process.Start("odin422.exe")
                Else

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FDroidOpenSourceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FDroidOpenSourceToolStripMenuItem.Click
        Try
            If MsgBox("This will download and install F-Droid Open Source Application to your to your phone, enabling a new open source repository on your device." + vbNewLine + "Continue?", MsgBoxStyle.YesNo, "Install F-Droid?") = MsgBoxResult.Yes Then
                My.Computer.Network.DownloadFile("http://f-droid.org/FDroid.apk", "FDroid.apk", vbNullString, vbNullString, True, 5000, True)
                Shell("adb install FDroid.apk")
            Else
                MsgBox("Installation canceled by user!", MsgBoxStyle.Information, "Info")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SourceCodeBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SourceCodeBrowserToolStripMenuItem.Click
        Process.Start("http://urgero.org/explorer/data/public/e02c0bced273b5eafa9dc262c81f3053.php?lang=en")
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Try
            If MsgBox("This will remove the pattern/password on your device, but may also brick it!" + vbNewLine + "This is only to be used for YOUR phone!" + vbNewLine + "Use at your own risk!" + vbNewLine + "Requires: Root acces in terminal!", MsgBoxStyle.OkCancel, "Continue?") = MsgBoxResult.Ok Then
                Shell("adb shell rm data/system/*.key")
                MsgBox("Please note, this does NOT work for non-rooted phones!")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        'Dim esfv As New ExplorerStyleViewer()
        'esfv.Show()
        explorer.Show()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Label14.Text = "Checking for a connected device..."
            android = AndroidController.Instance
            android.UpdateDeviceList()
            Label14.Text = "Start step 2..."
            If android.HasConnectedDevices Then
                serial = android.ConnectedDevices(0)
                device = android.GetConnectedDevice(serial)
                Label9.Text = "Battery Level: " + device.Battery.Level.ToString
                If device.HasRoot = True Then
                    Label10.Text = "SU Version: " + device.Su.Version.ToString
                Else
                    Label10.Text = "No su binary found!"
                End If
                Label11.Text = "Device State: " + device.State.ToString
                Label12.Text = "Device Serial: " + serial
                If device.BusyBox.Version = "" Then
                    Label15.Text = "BusyBox Version: No BusyBox Found!!"
                Else
                    Label15.Text = "BusyBox Version: " + device.BusyBox.Version
                End If
                If DeviceState.RECOVERY = True Then
                    MsgBox("Connected device has been detected in recovery mode! Some commands may not work!", MsgBoxStyle.Critical, "Recovery Detected!")

                End If

                Label7.Text = serial.ToUpper
                Label7.Text.ToUpper()
                android.Dispose()
            Else
                ' MsgBox("No device found! Drivers may need to be installed first, or the device is not plugged in!", MsgBoxStyle.Critical, "Device not found!")
                Label7.Text = "No Devices Found!"
            End If
            Try
                android.Dispose()
            Catch ex As Exception

            End Try
            If Label7.Text = "No Devices Found!" Then
                Label9.Text = "No devices connected!"
                Label10.Text = ""
                Label11.Text = ""
                Label12.Text = ""
                Label15.Text = ""
            End If
            BackgroundWorker2.RunWorkerAsync()
        Catch ex As Exception
            MsgBox("There has been an error communicating to the device. A possible fix is rebooting the PC.", MsgBoxStyle.Exclamation, "Oops!")
        End Try

       
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            Label14.Text = "Checking for update from server..."
            Dim wc As New System.Net.WebClient()
            Dim address As String = "http://urgero.org/adbgui/adbversion.txt"
            Dim ver = wc.DownloadString(address)

            If ver > verint Then
                If MsgBox("There is an update available, would you like to update?", MsgBoxStyle.YesNo, "Update Available!") = MsgBoxResult.Yes Then
                    Try

                        Process.Start("update.exe")
                        End
                    Catch ex1 As Exception
                        loading.Visible = False
                        MsgBox("Cannot start updater application!")

                    End Try
                End If
            End If

            Label14.Text = "Finished Loading Resources!"
        Catch ex As Exception
            loading.Visible = False
            MsgBox("Cannot reach the update server, please try updating later!", MsgBoxStyle.Information, "Oops!")
        End Try
        TabControl1.Enabled = True
        PictureBox1.Visible = False
        Label14.Visible = False

    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        PictureBox1.Visible = True
        Label14.Text = "Checking for a connected device..."
        Label14.Visible = True
        Dim serial As String
        android = AndroidController.Instance
        android.UpdateDeviceList()
        If android.HasConnectedDevices Then
            serial = android.ConnectedDevices(0)
            device = android.GetConnectedDevice(serial)
            Label7.Text = serial.ToUpper
            Label7.Text.ToUpper()
            Label9.Text = "Battery Level: " + device.Battery.Level.ToString
            If device.HasRoot = True Then
                Label10.Text = "SU Version: " + device.Su.Version.ToString
            Else
                Label10.Text = "No su binary found!"
            End If
            Label11.Text = "Device State: " + device.State.ToString
            Label12.Text = "Device Serial: " + serial
            If device.BusyBox.Version = "" Then
                Label15.Text = "BusyBox Version: No BusyBox Found!!"
            Else
                Label15.Text = "BusyBox Version: " + device.BusyBox.Version
            End If
            If DeviceState.RECOVERY = True Then
                MsgBox("Connected device has been detected in recovery mode! Some commands may not work!", MsgBoxStyle.Critical, "Recovery Detected!")

            End If
            android.Dispose()
        Else
            'MsgBox("No device found! Drivers may need to be installed first, or the device is not plugged in!", MsgBoxStyle.Critical, "Device not found!")
            Label7.Text = "No Device Found!"
        End If
        Try
            android.Dispose()
        Catch ex As Exception

        End Try
        If Label7.Text = "No Devices Found!" Then
            Label9.Text = "No devices connected!"
            Label10.Text = ""
            Label11.Text = ""
            Label12.Text = ""
            Label15.Text = ""
        End If
        Label14.Text = "Finished Loading Resources!"
        PictureBox1.Visible = False
        Label14.Visible = False
    End Sub

    Private Sub MyAndroidApplicationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MyAndroidApplicationsToolStripMenuItem.Click
        Process.Start("https://play.google.com/store/search?q=urgero")
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Shell("adb kill-server")
        System.Threading.Thread.Sleep("5000")
        Shell("adb start-server")
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Shell("adb shell am kill-all")
        System.Threading.Thread.Sleep("2000")
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim p As New ProcessStartInfo
        p.FileName = "adb.exe"
        Dim arg As String = ofd1.FileName
        p.Arguments = "push " + """" + arg + """" + " " + TextBox4.Text
        p.WindowStyle = ProcessWindowStyle.Normal
        Process.Start(p)
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Try
            ofd1.ShowDialog()
            TextBox3.Text = ofd1.SafeFileName

        Catch ex As Exception
            MsgBox("Invalid file name!", MsgBoxStyle.Exclamation, "ADB Helper")
        End Try
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        If TextBox5.TextLength = TextBox5.MaxLength Then
            TextBox5.Text = ""
        End If
        MyProcess.StandardInput.WriteLine(TextBox6.Text)
        MyProcess.StandardInput.Flush()
        TextBox6.Text = ""
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Try
            If Label7.Text = "No Device Found!" Then
                GoTo badLine2
            Else

            End If
                If Label7.Text = "No Devices Found!" Then
                    GoTo badLine2
                Else

                End If
                If File.Exists("C:\Windows\adb.exe") = True Then
                    GoTo startLine
                Else
                    GoTo badLine
                End If
startLine:
                AcceptButton = Button23

                MyProcess = New Process

                With MyProcess.StartInfo
                    .FileName = "ADB.EXE"
                    .Arguments = "SHELL"
                    .UseShellExecute = False
                    .CreateNoWindow = True
                    .RedirectStandardInput = True
                    .RedirectStandardOutput = True
                    .RedirectStandardError = True
                End With

                MyProcess.Start()

                MyProcess.BeginErrorReadLine()      'start async read on stderr
                MyProcess.BeginOutputReadLine()     'start async read on stdout
            ' MyProcess.StandardInput.WriteLine("cls") 'send an EXIT command to the Command Prompt
                MyProcess.StandardInput.Flush()
                AppendOutputText("Process Started at: " & MyProcess.StartTime.ToString)
                TextBox6.Enabled = True
                Button23.Enabled = True
                Button25.Enabled = True
            Button24.Enabled = False
            TextBox6.Focus()
                GoTo finStart
badLine:
            AppendOutputText("Please make sure ADB is installed to the system dir!" + vbNewLine)
                GoTo finStart

badLine2:
            AppendOutputText("An android device needs to be connected first!" + vbNewLine)
finStart:
            Catch ex As Exception
                MsgBox("Error starting ADB SHELL!!", MsgBoxStyle.Critical, "Oops!")
            End Try

    End Sub
    Private Sub AppendOutputText(ByVal text As String)

        If TextBox5.InvokeRequired Then
            Dim myDelegate As New AppendOutputTextDelegate(AddressOf AppendOutputText)
            Me.Invoke(myDelegate, text)
        Else
            TextBox5.AppendText(text)
        End If

    End Sub
    Private Sub MyProcess_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles MyProcess.OutputDataReceived

        AppendOutputText(vbCrLf & e.Data)

    End Sub
    Private Sub MyProcess_ErrorDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles MyProcess.ErrorDataReceived

        AppendOutputText(vbCrLf & e.Data)

    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Try
            MyProcess.StandardInput.WriteLine("EXIT") 'send an EXIT command to the Command Prompt
            MyProcess.StandardInput.Flush()

            TextBox6.Enabled = False
            Button23.Enabled = False
            Button25.Enabled = False
            Button24.Enabled = True
            Button26.Enabled = True
            TextBox5.Text = "Service Stopped."
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Try
            'If Label7.Text = "No Device Found!" Then
            '    GoTo badLine2
            'Else

            'End If
            'If Label7.Text = "No Devices Found!" Then
            '    GoTo badLine2
            'Else

            'End If
            'If File.Exists("C:\Windows\adb.exe") = True Then
            '    GoTo startLine
            'Else
            '    GoTo badLine
            'End If
startLine:
            AcceptButton = Button23

            MyProcess = New Process

            With MyProcess.StartInfo
                .FileName = "CMD.EXE"
                '.Arguments = "SHELL"
                .UseShellExecute = False
                .CreateNoWindow = True
                .RedirectStandardInput = True
                .RedirectStandardOutput = True
                .RedirectStandardError = True
            End With

            MyProcess.Start()

            MyProcess.BeginErrorReadLine()      'start async read on stderr
            MyProcess.BeginOutputReadLine()     'start async read on stdout
            ' MyProcess.StandardInput.WriteLine("cls") 'send an EXIT command to the Command Prompt
            MyProcess.StandardInput.Flush()
            AppendOutputText("Process Started at: " & MyProcess.StartTime.ToString)
            TextBox6.Enabled = True
            Button23.Enabled = True
            Button25.Enabled = True
            Button26.Enabled = False
            Button24.Enabled = False
            TextBox6.Focus()
            GoTo finStart
badLine:
            AppendOutputText("Please make sure ADB is installed to the system dir!" + vbNewLine)
            GoTo finStart

badLine2:
            AppendOutputText("An android device needs to be connected first!" + vbNewLine)
finStart:
        Catch ex As Exception
            MsgBox("Error starting ADB SHELL!!", MsgBoxStyle.Critical, "Oops!")
        End Try
    End Sub

    Private Sub ResetLoginScreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetLoginScreenToolStripMenuItem.Click
        Try
            My.Computer.Registry.CurrentUser.CreateSubKey("urgeroADBGUI")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\urgeroADBGUI",
              "current_username", "")
            My.Computer.Registry.CurrentUser.CreateSubKey("urgeroADBGUI")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\urgeroADBGUI",
              "current_p", "")
            MsgBox("Login screen and information has been reset!", MsgBoxStyle.Information, "Done!")
        Catch ex As Exception
            MsgBox("Error reading from registry, please run this program as administrator!", MsgBoxStyle.Critical, "Oops!")
        End Try
    End Sub
End Class
