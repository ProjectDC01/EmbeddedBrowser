'Public Class Form1
'    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
'        Dim i As Integer
'        i = TextBox1.Text
'        Label1.Text = Int((i + 1) / 2)
'    End Sub
'End Class


Imports CefSharp
Imports CefSharp.WinForms

Public Class Form1
    'setting
    Dim setchkinfo(100) As String
    Dim setchk As New System.IO.StreamReader("setting.ini", System.Text.Encoding.GetEncoding("shift_jis"))
    Public Function setting0() As Integer
        For index As Integer = 0 To 5
            If setchk.ReadLine(index) <> Nothing Then
                setchkinfo(index) = setchk.ReadLine(index)
                TextBox1.Text = TextBox1.Text + setchkinfo(index)
            End If
        Next
        'TextBox1.Text = setchk.ReadToEnd
    End Function

    'IE用レジストリ設定
    Private Function IEReg(iever As Integer) As Integer
        Dim regkeyid As Integer
        If iever = 12 Then
            regkeyid = 12001
        ElseIf iever = 11 Then
            regkeyid = 11000
        ElseIf iever = 10 Then
            regkeyid = 10001
        ElseIf iever = 9 Then
            regkeyid = 9999
        ElseIf iever = 8 Then
            regkeyid = 8888
        ElseIf iever = 7 Then
            regkeyid = 7000
        Else
            regkeyid = 7000
        End If

        Dim regkey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", False)
        If regkey Is Nothing Then
            regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION")
            regkey.SetValue(My.Application.Info.Title & ".exe", regkeyid)
            regkey.Close()
        ElseIf CInt(regkey.GetValue("WebPageViewer Version 1.00.exe")) <> regkeyid Then
            regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION")
            regkey.SetValue(My.Application.Info.Title & ".exe", regkeyid)
            regkey.Close()
        End If
        Return 0
    End Function

    Public spbr0(1000, 5) As Integer
    Public brsp0(1000, 5) As Integer
    Private Function Startup0() As Integer
        setting0()
        For index As Integer = 0 To 1000
            For index2 As Integer = 0 To 5
                spbr0(index, index2) = 0
                brsp0(index, index2) = 0
            Next
        Next
    End Function
    'addSplit
    Private SplitContainer() As System.Windows.Forms.SplitContainer
    Public splitno As Integer = 1
    Private splitpanlno As Integer = 1

    Private Function Splitadd0(splitor As Integer) As Integer
        If splitno = 1 Then
            Me.SplitContainer = New System.Windows.Forms.SplitContainer(32) {}

            Me.SplitContainer(splitno) = New System.Windows.Forms.SplitContainer
            CType(Me.SplitContainer(splitno), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer(splitno).Panel1.SuspendLayout()
            Me.SplitContainer(splitno).Panel2.SuspendLayout()
            Me.SplitContainer(splitno).SuspendLayout()
            Me.SuspendLayout()

            If splitor = 1 Then
                Me.SplitContainer(splitno).Orientation = Orientation.Horizontal
            End If

            Me.SplitContainer(splitno).Panel1.BackColor = Color.Black
            Me.SplitContainer(splitno).Panel2.BackColor = Color.Gray

            Me.Controls.Add(Me.SplitContainer(splitno))
            Me.SplitContainer(splitno).BringToFront()
            Me.SplitContainer(splitno).Dock = System.Windows.Forms.DockStyle.Fill
            'Me.SplitContainer(splitno).Location = New System.Drawing.Point(0, 24)
            Me.SplitContainer(splitno).Name = "SplitContainer" & splitno
            Me.SplitContainer(splitno).Panel1.Tag = splitpanlno
            Me.SplitContainer(splitno).Panel2.Tag = splitpanlno + 1

            Me.SplitContainer(splitno).Panel1.ContextMenuStrip = Me.SplitMenu
            Me.SplitContainer(splitno).Panel2.ContextMenuStrip = Me.SplitMenu

            If spbr0(1000, 0) <> 0 Or spbr0(1000, 1) <> 0 Then
                If spbr0(1000, 0) <> 0 Then
                    Me.SplitContainer(splitno).Panel1.Controls.Add(Me.IEWebBrowser(spbr0(1000, 0)))
                Else
                    Me.SplitContainer(splitno).Panel1.Controls.Add(Me.ChWebBrowser(spbr0(1000, 1)))
                End If
            End If

            Me.SplitContainer(splitno).Panel1.ResumeLayout(False)
            Me.SplitContainer(splitno).Panel2.ResumeLayout(False)
            CType(Me.SplitContainer(splitno), System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer(splitno).ResumeLayout(False)
            Me.ResumeLayout(False)

            Me.Hide()
            Me.Show()

            splitno = splitno + 1
            splitpanlno = splitpanlno + 2

        Else
            Dim splitno2 = splitno - 1

            Me.SplitContainer(splitno) = New System.Windows.Forms.SplitContainer
            CType(Me.SplitContainer(splitno), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer(splitno).Panel1.SuspendLayout()
            Me.SplitContainer(splitno).Panel2.SuspendLayout()
            Me.SplitContainer(splitno).SuspendLayout()
            Me.SuspendLayout()

            If splitor = 1 Then
                Me.SplitContainer(splitno).Orientation = Orientation.Horizontal
            End If

            Me.SplitContainer(splitno).Panel1.BackColor = Color.Aqua
            Me.SplitContainer(splitno).Panel2.BackColor = Color.YellowGreen

            Me.SplitContainer(splitno2).Panel2.Controls.Add(Me.SplitContainer(splitno))
            Me.SplitContainer(splitno).Dock = System.Windows.Forms.DockStyle.Fill
            'Me.SplitContainer(splitno).Location = New System.Drawing.Point(0, 24)
            Me.SplitContainer(splitno).Name = "SplitContainer" & splitno
            Me.SplitContainer(splitno).BringToFront()
            Me.SplitContainer(splitno).Panel1.Tag = splitpanlno
            Me.SplitContainer(splitno).Panel2.Tag = splitpanlno + 1

            Me.SplitContainer(splitno).Panel1.ContextMenuStrip = Me.SplitMenu
            Me.SplitContainer(splitno).Panel2.ContextMenuStrip = Me.SplitMenu

            If spbr0(splitpanlno - 1, 0) <> 0 Or spbr0(splitpanlno - 1, 1) <> 0 Then
                If spbr0(splitpanlno - 1, 0) <> 0 Then
                    Me.SplitContainer(splitno).Panel1.Controls.Add(Me.IEWebBrowser(spbr0(splitpanlno - 1, 0)))
                Else
                    Me.SplitContainer(splitno).Panel1.Controls.Add(Me.ChWebBrowser(spbr0(splitpanlno - 1, 1)))
                End If
            End If

            Me.SplitContainer(splitno).Panel1.ResumeLayout(False)
            Me.SplitContainer(splitno).Panel2.ResumeLayout(False)
            CType(Me.SplitContainer(splitno), System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer(splitno).ResumeLayout(False)
            Me.ResumeLayout(False)
            splitno = splitno + 1
            splitpanlno = splitpanlno + 2
        End If
        Return 0
    End Function
    Private Function Chksrc() As Integer
        Dim src01 As Control = Me.SplitMenu.SourceControl
        If src01 IsNot Nothing Then
            Return src01.Tag
        Else
            Return 0
        End If
    End Function

    Private Function Chkbrsrc() As Integer
        Dim src02 As Control = Me.WebWindowsMenu.SourceControl
        If src02 IsNot Nothing Then
            Return src02.Tag
            Me.Text = src02.Tag
        Else
            Return 0
        End If
    End Function

    Public IEWebBrowser() As System.Windows.Forms.WebBrowser
    Public ChWebBrowser() As ChromiumWebBrowser
    Public iebrno As Integer = 1
    Public chbrno As Integer = 1
    Public brtagno As Integer = 1

    Private Function AddBrowser(ctlsrcid As Integer, brid As Integer) As Integer
        If ctlsrcid <> 1000 Then
            Dim ctlsrcid2 As Integer
            Dim ctlsrcid3 As Integer
            ctlsrcid2 = CInt(Int((ctlsrcid + 1) / 2))
            ctlsrcid3 = ctlsrcid - ctlsrcid2 * 2 + 1

            If brid = 0 Then
                If iebrno = 1 Then
                    Me.IEWebBrowser = New System.Windows.Forms.WebBrowser(32) {}
                End If

                Me.IEWebBrowser(iebrno) = New System.Windows.Forms.WebBrowser

                If ctlsrcid3 = 0 Then
                    Me.SplitContainer(ctlsrcid2).Panel1.Controls.Add(Me.IEWebBrowser(iebrno))
                ElseIf ctlsrcid3 = 1 Then
                    Me.SplitContainer(ctlsrcid2).Panel2.Controls.Add(Me.IEWebBrowser(iebrno))
                End If

                Me.IEWebBrowser(iebrno).Dock = System.Windows.Forms.DockStyle.Fill
                Me.IEWebBrowser(iebrno).Name = "IEWebBrowser" & iebrno
                Me.IEWebBrowser(iebrno).Tag = brtagno
                Me.IEWebBrowser(iebrno).Navigate("http://yahoo.co.jp")
                Me.IEWebBrowser(iebrno).IsWebBrowserContextMenuEnabled = False
                Me.IEWebBrowser(iebrno).ContextMenuStrip = Me.WebWindowsMenu

                spbr0(ctlsrcid, brid) = iebrno
                brsp0(brtagno, brid) = iebrno
                iebrno = iebrno + 1
                brtagno = brtagno + 1

                Return 0
            ElseIf brid = 1 Then
                If chbrno = 1 Then
                    Me.ChWebBrowser = New ChromiumWebBrowser(32) {}
                End If

                Me.ChWebBrowser(chbrno) = New ChromiumWebBrowser("http://google.co.jp")

                If ctlsrcid3 = 0 Then
                    Me.SplitContainer(ctlsrcid2).Panel1.Controls.Add(Me.ChWebBrowser(chbrno))
                ElseIf ctlsrcid3 = 1 Then
                    Me.SplitContainer(ctlsrcid2).Panel2.Controls.Add(Me.ChWebBrowser(chbrno))
                End If

                Me.ChWebBrowser(chbrno).Dock = System.Windows.Forms.DockStyle.Fill
                Me.ChWebBrowser(chbrno).Name = "ChWebBrowser" & chbrno
                Me.ChWebBrowser(chbrno).Tag = brtagno

                spbr0(ctlsrcid, brid) = chbrno
                brsp0(brtagno, brid) = chbrno
                chbrno = chbrno + 1
                brtagno = brtagno + 1

                Return 1
            Else
                Return 2
            End If
        ElseIf ctlsrcid = 1000 Then

            If brid = 0 Then
                If iebrno = 1 Then
                    Me.IEWebBrowser = New System.Windows.Forms.WebBrowser(32) {}
                End If

                Me.IEWebBrowser(iebrno) = New System.Windows.Forms.WebBrowser

                Me.Controls.Add(Me.IEWebBrowser(iebrno))

                Me.IEWebBrowser(iebrno).Dock = System.Windows.Forms.DockStyle.Fill
                Me.IEWebBrowser(iebrno).Name = "IEWebBrowser" & iebrno
                Me.IEWebBrowser(iebrno).Tag = brtagno
                Me.IEWebBrowser(iebrno).Navigate("http://yahoo.co.jp")
                Me.IEWebBrowser(iebrno).IsWebBrowserContextMenuEnabled = False
                Me.IEWebBrowser(iebrno).ContextMenuStrip = Me.WebWindowsMenu

                spbr0(ctlsrcid, brid) = iebrno
                brsp0(brtagno, brid) = iebrno
                iebrno = iebrno + 1
                brtagno = brtagno + 1

            ElseIf brid = 1 Then
                If chbrno = 1 Then
                    Me.ChWebBrowser = New ChromiumWebBrowser(32) {}
                End If
                Me.ChWebBrowser(chbrno) = New ChromiumWebBrowser("http://google.co.jp")

                Me.Controls.Add(Me.ChWebBrowser(iebrno))

                Me.ChWebBrowser(chbrno).Dock = System.Windows.Forms.DockStyle.Fill
                Me.ChWebBrowser(chbrno).Name = "ChWebBrowser" & chbrno
                Me.ChWebBrowser(chbrno).Tag = brtagno
                Me.ChWebBrowser(chbrno).ContextMenuStrip = Me.WebWindowsMenu

                spbr0(ctlsrcid, brid) = chbrno
                brsp0(brtagno, brid) = chbrno
                chbrno = chbrno + 1
                brtagno = brtagno + 1

            End If
        End If
    End Function

    Private Function Browserhide(ctlscrid As Integer) As Integer
        If brsp0(ctlscrid, 0) <> 0 Then
            Me.IEWebBrowser(brsp0(ctlscrid, 0)).Hide()
        ElseIf brsp0(ctlscrid, 1) <> 1 Then
            Me.IEWebBrowser(brsp0(ctlscrid, 0)).Hide()
        End If
    End Function

    Private Function Exit0() As Integer
        Application.Exit()
        Return 0
    End Function
    Private Function Form(formst As Integer) As Integer
        If formst = 0 Then
            Me.Show()
            Return 0
        ElseIf formst = 1 Then
            Me.Hide()
            Return 1
        Else
            Return 2
        End If
    End Function
    Private Function Formwid(winst As Integer) As Integer
        If winst = 0 Then
            Me.WindowState = FormWindowState.Maximized
        ElseIf winst = 1 Then
            Me.WindowState = FormWindowState.Minimized
        ElseIf winst = 2 Then
            Me.WindowState = FormWindowState.Normal
        End If
        Return 0
    End Function
    Private Function Pnl1(panel1st As Integer) As Integer
        If panel1st = 0 Then
            Me.Panel1.Show()
        ElseIf panel1st = 1 Then
            Me.Panel1.Hide()
        End If
        Return 0
    End Function


    'フォーム移動
    Private mousePoint As Point
    Private Sub Form1_MouseDown(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles MyBase.MouseDown, Panel1.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            mousePoint = New Point(e.X, e.Y)
        End If
    End Sub
    Private Sub Form1_MouseMove(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles MyBase.MouseMove, Panel1.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y
        End If
    End Sub

    Private Sub ライセンスToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ライセンスToolStripMenuItem.Click
        Form4.Show()
    End Sub

    Private Sub 横向きToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 横向きToolStripMenuItem.Click
        Splitadd0(0)
    End Sub

    Private Sub 下向きToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 下向きToolStripMenuItem.Click
        Splitadd0(1)
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Exit0()
    End Sub

    Private Sub 全画面ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全画面ToolStripMenuItem.Click
        Formwid(0)
    End Sub

    Private Sub 最小化ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 最小化ToolStripMenuItem.Click
        Formwid(1)
    End Sub

    Private Sub 非表示ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 非表示ToolStripMenuItem.Click
        Dim st As Integer = 0
        st = Form(1)
        If st = 1 Then
        End If
    End Sub

    Private Sub メニューを隠すToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles メニューを隠すToolStripMenuItem.Click
        Pnl1(1)
    End Sub

    Private ctlsrctag As Integer
    Private Sub ブラウザToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ブラウザToolStripMenuItem.Click
        If Chksrc() <> 0 Then
            ctlsrctag = Chksrc()
        End If
    End Sub

    Private Sub IEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IEToolStripMenuItem.Click
        If ctlsrctag <> Nothing Then
            AddBrowser(ctlsrctag, 0)
        End If
    End Sub
    Private Sub ChromeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChromeToolStripMenuItem.Click
        If ctlsrctag <> Nothing Then
            AddBrowser(ctlsrctag, 1)
        End If
    End Sub
    Private ctlbrtag As Integer
    Private Sub ブラウザToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ブラウザToolStripMenuItem1.Click
        If Chkbrsrc() <> 0 Then
            ctlbrtag = Chkbrsrc()
        End If
    End Sub
    Private Sub 非表示ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles 非表示ToolStripMenuItem3.Click
        Browserhide(ctlbrtag)
    End Sub
    Private Sub 設定ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 設定ToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub 管理画面ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 管理画面ToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Startup0()
    End Sub


End Class
