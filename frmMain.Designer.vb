<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tblouter = New System.Windows.Forms.TableLayoutPanel()
        Me.btnChooseimage = New System.Windows.Forms.Button()
        Me.choosenFilelb = New System.Windows.Forms.Label()
        Me.tbinfo = New System.Windows.Forms.TextBox()
        Me.fileOpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.tblouter.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblouter
        '
        Me.tblouter.ColumnCount = 2
        Me.tblouter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblouter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblouter.Controls.Add(Me.btnChooseimage, 0, 0)
        Me.tblouter.Controls.Add(Me.choosenFilelb, 1, 0)
        Me.tblouter.Controls.Add(Me.tbinfo, 0, 1)
        Me.tblouter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblouter.Location = New System.Drawing.Point(0, 0)
        Me.tblouter.Name = "tblouter"
        Me.tblouter.RowCount = 2
        Me.tblouter.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblouter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblouter.Size = New System.Drawing.Size(751, 502)
        Me.tblouter.TabIndex = 0
        '
        'btnChooseimage
        '
        Me.btnChooseimage.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChooseimage.AutoSize = True
        Me.btnChooseimage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnChooseimage.Font = New System.Drawing.Font("Old English Text MT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChooseimage.Location = New System.Drawing.Point(3, 3)
        Me.btnChooseimage.Name = "btnChooseimage"
        Me.btnChooseimage.Size = New System.Drawing.Size(135, 30)
        Me.btnChooseimage.TabIndex = 0
        Me.btnChooseimage.Text = "Open Test Image"
        Me.btnChooseimage.UseVisualStyleBackColor = True
        '
        'choosenFilelb
        '
        Me.choosenFilelb.AutoSize = True
        Me.choosenFilelb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.choosenFilelb.Font = New System.Drawing.Font("Old English Text MT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.choosenFilelb.Location = New System.Drawing.Point(144, 0)
        Me.choosenFilelb.Name = "choosenFilelb"
        Me.choosenFilelb.Size = New System.Drawing.Size(604, 36)
        Me.choosenFilelb.TabIndex = 1
        Me.choosenFilelb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbinfo
        '
        Me.tblouter.SetColumnSpan(Me.tbinfo, 2)
        Me.tbinfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbinfo.Font = New System.Drawing.Font("Old English Text MT", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbinfo.Location = New System.Drawing.Point(3, 39)
        Me.tbinfo.Multiline = True
        Me.tbinfo.Name = "tbinfo"
        Me.tbinfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbinfo.Size = New System.Drawing.Size(745, 460)
        Me.tbinfo.TabIndex = 2
        Me.tbinfo.WordWrap = False
        '
        'fileOpenDialog
        '
        Me.fileOpenDialog.FileName = "OpenFileDialog1"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 502)
        Me.Controls.Add(Me.tblouter)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.tblouter.ResumeLayout(False)
        Me.tblouter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tblouter As TableLayoutPanel
    Friend WithEvents btnChooseimage As Button
    Friend WithEvents choosenFilelb As Label
    Friend WithEvents tbinfo As TextBox
    Friend WithEvents fileOpenDialog As OpenFileDialog
End Class
