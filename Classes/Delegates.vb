Option Strict On

Public Class Delegates
    ''' <summary>
    '''  Represents the method that will handle the <see cref="InitiateConnection.ServerResponseOutputEventArghs">InitializeConnection</see> event of <see cref="InitiateConnection" />.
    ''' </summary>
    ''' <param name="ServerResponse">
    ''' The source of the IRC stream.
    ''' </param>
    ''' <remarks>
    ''' Writers selected IRC server streams to the normal window.
    ''' </remarks>
    Public Delegate Sub ServerResponseOutputEventHandler(ByVal ServerResponse As String)

    ''' <summary>
    ''' Represents the method that will handle the <see cref="OutputMessages.OutputResponse">OutputResponse</see> event of <see cref="InitiateConnection" />.
    ''' </summary>
    ''' <param name="control">
    ''' The control of the output.
    ''' </param>
    ''' <param name="output">
    ''' The source of the output.
    ''' </param>
    ''' <param name="color">
    ''' The color of the output.
    ''' </param>
    ''' <remarks>
    '''  Writes asynchronously to the UI to output all IRC server streams.
    ''' </remarks>
    Public Delegate Sub OutputEventHandler(ByVal control As RichTextBox, ByVal output As String, ByVal color As Color)

    ''' <summary>
    ''' Represents the method that will handle the <see cref="InitiateConnection.NameListEventArgs">NamesList</see> event of <see cref="InitiateConnection" />.
    ''' </summary>
    ''' <param name="NamesList">
    ''' The source of the users
    ''' </param>
    ''' <remarks>
    ''' Updates ListView of channel users.
    ''' </remarks>
    Public Delegate Sub NamesListEventHandler(ByVal NamesList As String)

    ''' <summary>
    ''' Represents the method that will handle the <see cref="InitiateConnection.NickListUpdateEventArghs">NickList</see> event of <see cref="InitiateConnection" />.
    ''' </summary>
    ''' <param name="ServerResponse">
    ''' The server response.
    ''' </param>
    ''' <remarks>
    ''' Updates the list of chatters.
    ''' </remarks>
    Public Delegate Sub NickListUpdateEventHandler(ByVal ServerResponse As String)

End Class
