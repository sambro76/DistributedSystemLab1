<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmServer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lsvClients = New System.Windows.Forms.ListView()
        Me.colIP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmLsvClient = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SendMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmLsvClient.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsvClients
        '
        Me.lsvClients.AllowColumnReorder = True
        Me.lsvClients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIP, Me.colStatus})
        Me.lsvClients.ContextMenuStrip = Me.cmLsvClient
        Me.lsvClients.Location = New System.Drawing.Point(12, 12)
        Me.lsvClients.Name = "lsvClients"
        Me.lsvClients.Size = New System.Drawing.Size(399, 130)
        Me.lsvClients.TabIndex = 0
        Me.lsvClients.UseCompatibleStateImageBehavior = False
        Me.lsvClients.View = System.Windows.Forms.View.Details
        '
        'colIP
        '
        Me.colIP.Text = "IP Address : Port"
        Me.colIP.Width = 99
        '
        'colStatus
        '
        Me.colStatus.Text = "Status"
        Me.colStatus.Width = 108
        '
        'cmLsvClient
        '
        Me.cmLsvClient.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SendMessageToolStripMenuItem})
        Me.cmLsvClient.Name = "cmLsvClient"
        Me.cmLsvClient.Size = New System.Drawing.Size(150, 26)
        '
        'SendMessageToolStripMenuItem
        '
        Me.SendMessageToolStripMenuItem.Name = "SendMessageToolStripMenuItem"
        Me.SendMessageToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.SendMessageToolStripMenuItem.Text = "Send Message"
        '
        'TextBox1
        '
        Me.TextBox1.AllowDrop = True
        Me.TextBox1.Location = New System.Drawing.Point(152, 177)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(259, 86)
        Me.TextBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AllowDrop = True
        Me.Label1.Location = New System.Drawing.Point(149, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Message Logs from Client:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(12, 195)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(134, 20)
        Me.TextBox2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AllowDrop = True
        Me.Label2.Location = New System.Drawing.Point(9, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Incoming Client Message:"
        '
        'frmServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 275)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lsvClients)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmServer"
        Me.Text = "Server Window"
        Me.cmLsvClient.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lsvClients As ListView
    Friend WithEvents colIP As ColumnHeader
    Friend WithEvents cmLsvClient As ContextMenuStrip
    Friend WithEvents SendMessageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents colStatus As ColumnHeader
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
End Class
