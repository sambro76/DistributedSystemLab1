'Name: SAMNANG CHAY
'Id: 1000732321
'SUMMER '17
'Lab 01 ASSIGNMENT
'--------------------------
'---START OF CLIENT CODE---
'--------------------------
Imports System.Net, System.Net.Sockets
'MAKING USE OF CLASS SYSTEM.TEXT FOR ASCIIENCODING
Imports System.Text
'MAKING USE OF THREAD CLASS
Imports System.Threading

Public Class frmClient
    Dim clientSocket As Socket
    Dim host As String = "127.0.0.1"
    Dim port As Integer = "6868"
    'SET RECEIVING DATA STRING TO BE MAXIMUM OF 256 BYTES
    Dim byteData = New Byte(255) {}

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim ipAddress As IPAddress = IPAddress.Parse(host)
        Dim ipEndPoint As IPEndPoint = New IPEndPoint(ipAddress, port)
        clientSocket.BeginConnect(ipEndPoint, New AsyncCallback(AddressOf onConnect), Nothing)
        btnConnect.Enabled = False
        btnConnect.Text = "Connected"
    End Sub

    'AFTER CONNECTED, CLIENT BEGIN TO LISTEN AND TO RECEIVE DATA
    Private Sub onConnect(ByVal ar As IAsyncResult)
        clientSocket.EndConnect(ar)
        clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf onReceive), clientSocket)
        TextBox1.Text &= "Connected to Server..." & Environment.NewLine
    End Sub

    'RECEIVE SERVER MESSAGE
    Private Sub onReceive(ByVal ar As IAsyncResult)
        If Me.InvokeRequired Then
            Try
                Dim bytesRec As Byte() = byteData
                Dim msgFromServer As String = ASCIIEncoding.ASCII.GetString(bytesRec)
                read(msgFromServer)
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf onReceive), clientSocket)
                clientSocket.EndReceive(ar)
            Catch ex As Exception
            End Try
            ' REDUCE CPU USAGE
            Thread.Sleep(100)
        End If


    End Sub

    Delegate Sub _read(ByVal msg As String)

    Private Sub read(ByVal msg As String)
        If InvokeRequired Then
            Invoke(New _read(AddressOf read), msg)
            Exit Sub
        End If
        TextBox1.Text &= msg

    End Sub

    Private Sub btnSend2Svr_Click(sender As Object, e As EventArgs) Handles btnSearchOnServer.Click
        byteData = ASCIIEncoding.ASCII.GetBytes(txtMsg2SVR.Text)
        clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf onSend), clientSocket)

        'WRITE TO CLIENT LOGS' BOX
        TextBox1.Text &= txtMsg2SVR.Text & Environment.NewLine
    End Sub

    Private Sub onSend(ByVal ar As IAsyncResult)
        clientSocket.EndSend(ar)
    End Sub

End Class