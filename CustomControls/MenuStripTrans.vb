Option Strict On

Imports System.Windows.Forms

''' <summary>
''' Creates a custom menu strip.
''' </summary>
''' <remarks>
''' Serves no real purpose other then over riding windows default color scheme.
''' </remarks>

Public Class MenuStripTrans
    Inherits MenuStrip

    Public Sub New()
        Me.BackColor = Color.Transparent
    End Sub
End Class


