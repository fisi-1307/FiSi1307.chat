
Option Strict On

''' <summary>
''' Handles all client side information.
''' </summary>

Module ConnectionInformation

#Region " Private Members "
    Private _server As String
    Private _port As Integer
    Private _channel As String
    Private _nick As String
    Private _altNick As String
    Private _userName As String
    Private _realName As String
#End Region

#Region " Properties "
    ' Gets or sets the current server.
    Public Property Server As String
        Get
            Return _server
        End Get
        Set(ByVal value As String)
            _server = value
        End Set
    End Property
    ' Gets the current port number.
    Public ReadOnly Property port As Integer
        Get
            Return 6667
        End Get
    End Property
    ' Gets or sets the current channel.
    Public Property Channel As String
        Get
            Return _channel
        End Get
        Set(ByVal value As String)
            _channel = value
        End Set
    End Property
    ' Gets or sets the channel nick.
    Public Property ChannelNick As String
        Get
            Return _nick
        End Get
        Set(ByVal value As String)
            _nick = value
        End Set
    End Property
    ' Gets or sets the channel alternative nick.
    Public Property ChannelAltNick As String
        Get
            Return _altNick
        End Get
        Set(ByVal value As String)
            _altNick = value
        End Set
    End Property
    ' Gets or sets the current User name.
    Public Property UserName As String
        Get
            Return _userName
        End Get
        Set(ByVal value As String)
            _userName = value
        End Set
    End Property
    ' Gets or sets the current real name.
    Public Property RealName As String
        Get
            Return _realName
        End Get
        Set(ByVal value As String)
            _realName = value
        End Set
    End Property
#End Region

End Module

