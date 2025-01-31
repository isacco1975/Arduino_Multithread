<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.efHost = New System.Windows.Forms.TextBox()
        Me.efPort = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.efFrom = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.efTo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.efSubj = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.efBody = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'efHost
        '
        Me.efHost.Location = New System.Drawing.Point(73, 17)
        Me.efHost.Name = "efHost"
        Me.efHost.Size = New System.Drawing.Size(93, 23)
        Me.efHost.TabIndex = 1
        Me.efHost.Text = "192.168.73.128"
        '
        'efPort
        '
        Me.efPort.Location = New System.Drawing.Point(231, 17)
        Me.efPort.Name = "efPort"
        Me.efPort.Size = New System.Drawing.Size(64, 23)
        Me.efPort.TabIndex = 3
        Me.efPort.Text = "64000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(180, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Port"
        '
        'efFrom
        '
        Me.efFrom.Location = New System.Drawing.Point(73, 46)
        Me.efFrom.Name = "efFrom"
        Me.efFrom.Size = New System.Drawing.Size(222, 23)
        Me.efFrom.TabIndex = 5
        Me.efFrom.Text = "indirizzoqualsiasi@dominio.com"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "From"
        '
        'efTo
        '
        Me.efTo.Location = New System.Drawing.Point(73, 75)
        Me.efTo.Name = "efTo"
        Me.efTo.Size = New System.Drawing.Size(222, 23)
        Me.efTo.TabIndex = 7
        Me.efTo.Text = "indirizzoqualsiasi@dominio.com"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "To"
        '
        'efSubj
        '
        Me.efSubj.Location = New System.Drawing.Point(73, 103)
        Me.efSubj.Name = "efSubj"
        Me.efSubj.Size = New System.Drawing.Size(222, 23)
        Me.efSubj.TabIndex = 9
        Me.efSubj.Text = "Arduino Remote Control"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Subject"
        '
        'efBody
        '
        Me.efBody.Location = New System.Drawing.Point(73, 130)
        Me.efBody.Name = "efBody"
        Me.efBody.Size = New System.Drawing.Size(222, 23)
        Me.efBody.TabIndex = 11
        Me.efBody.Text = "*1;07*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "BODY"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(220, 159)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Send"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 196)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.efBody)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.efSubj)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.efTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.efFrom)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.efPort)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.efHost)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents efHost As TextBox
    Friend WithEvents efPort As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents efFrom As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents efTo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents efSubj As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents efBody As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
End Class
