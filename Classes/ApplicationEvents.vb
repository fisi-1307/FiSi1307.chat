Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

#Region " Private members "
        Private ReadOnly _dialogTitle As String = "Unexpected error"
        Private ReadOnly _dialogMessage As String = "We expect as many as many errors as possible but this one caught us completely by surprise."
#End Region

#Region " Unhandled Exception "
        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            MessageBox.Show(_dialogMessage, _
                            _dialogTitle, _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Error, _
                            MessageBoxDefaultButton.Button1)
        End Sub
#End Region

    End Class


End Namespace

