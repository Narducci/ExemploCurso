Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Public Class CursoCEP
    Inherits TextBox

#Region "Propriedades"
    <Category("Curso")>
    <Description("Envia cursor para o próximo controle. Enter: próximo controle, Seta para Baixo: próximo controle, Seta para cima: Cursor anterior.")>
    Public Property EnviaTab As Boolean = True
#End Region
    Private Sub CursoCEP_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If Me.EnviaTab = True Then
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
                SendKeys.Send("{TAB}")
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Up Then
                SendKeys.Send("+{TAB}")
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub CursoCEP_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        '07032-250
        If e.KeyCode <> Keys.Back Then
            If Me.TextLength = 5 Then
                Me.Text = Me.Text & "-"
                Me.SelectionStart = Me.TextLength
            End If
        End If
    End Sub

    Private Sub CursoCEP_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.BackColor = Color.LightYellow
    End Sub

    Private Sub CursoCEP_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Me.BackColor = Color.White
    End Sub


End Class
