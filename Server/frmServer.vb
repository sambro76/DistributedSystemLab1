'Name: SAMNANG CHAY
'Id: 1000732321
'SUMMER '17
'Lab 01 ASSIGNMENT
'--------------------------
'---START OF SERVER CODE---
'--------------------------
'MAKING USE OF CLASS NETWORK SOCKET 
Imports System.Net, System.Net.Sockets
'MAKING USE OF CLASS SYSTEM.TEXT FOR ASCIIENCODING
Imports System.Text
'MAKING USE OF THREAD CLASS
Imports System.Threading

Public Class frmServer
    'ASSIGN SOCKET VARIABLES FOR SERVER AND CLIENTS
    Dim serverSocket As Socket
    Dim clientSocket As Socket
    'SET RECEIVING DATA STRING TO BE MAXIMUM OF 256 BYTES
    Dim byteData(255) As Byte

    'WHEN SERVER WINDOW LOADS, SERVER STARTS TO LISTEN ANY IPADDRESS ON ALL NETWORK INTERFACES WITH 6868 AS ASSIGNED PORT.
    'HERE, 127.0.0.1 WAS USED AS IT IS INCLUDED IN THE HOSTS FILE. CLIENT WILL CONNECT USING THIS IP ADDRESS AND THE ASSIGNED PORT.
    Private Sub ServerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        serverSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim ipEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Any, 6868)
        serverSocket.Bind(ipEndPoint)
        serverSocket.Listen(4)
        serverSocket.BeginAccept(New AsyncCallback(AddressOf onAccept), Nothing)
    End Sub

    Delegate Sub _AddClient(ByVal client As Socket)

    'CREATE SUBROUTINE addClient TO SHOW CLIENT NAME TO THE LISTVIEWBOX 
    Private Sub addClient(ByVal client As Socket)
        '
        If Me.InvokeRequired Then
            Try
                Dim lv1 As New ListViewItem(client.LocalEndPoint.ToString)
                lv1.Tag = client
                lsvClients.Items.Add(lv1)
                lv1.SubItems.Add("Started...")
            Catch ex As Exception
            End Try
            ' REDUCE CPU USAGE
            Thread.Sleep(100)
        End If
    End Sub

    Private Sub send(ByVal msg As String, ByVal client As Socket)
        Dim sendbytes As Byte() = ASCIIEncoding.ASCII.GetBytes(msg)
        client.BeginSend(sendbytes, 0, sendbytes.Length, SocketFlags.None, New AsyncCallback(AddressOf onSend), client)
    End Sub

    Private Sub onSend(ByVal ar As IAsyncResult)
        Dim client As Socket = ar.AsyncState
        client.EndSend(ar)
    End Sub

    Private Sub SendMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendMessageToolStripMenuItem.Click
        If lsvClients.SelectedIndices.Count = 0 Then
            MessageBox.Show("No message to send...", "Server")
        Else
            send("Message from server", lsvClients.SelectedItems(0).Tag)
        End If
    End Sub

    'AFTER THE CLIENT IS ACCEPTED, SERVER START TO LISTEN
    Private Sub onAccept(ByVal ar As IAsyncResult)
        clientSocket = serverSocket.EndAccept(ar)
        clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf onReceive), clientSocket)

        'BeginAccept and receive client info
        serverSocket.BeginAccept(New AsyncCallback(AddressOf onAccept), Nothing)
        addClient(clientSocket)

    End Sub

    'RECEIVE A TEXT FROM THE CLIENT
    Private Sub onReceive(ByVal ar As IAsyncResult)
        If Me.InvokeRequired Then
            Try
                clientSocket = ar.AsyncState
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf onReceive), clientSocket)
                Dim wordFromClient As String = ASCIIEncoding.ASCII.GetString(byteData)



                'TEXTBOX1 IS TO KEEP LOGS FOR ALL INCOMING CLIENT MESSAGES
                TextBox1.Text &= Environment.NewLine & wordFromClient

                'TEXTBOX2 IS TO SHOW CURRENT WORD REQUESTED BY CLIENT
                TextBox2.Text = wordFromClient

                Dim R As New IO.StreamReader("..\" & "Lexicon.txt")
                If InStr(R.ReadToEnd, TextBox2.Text) Then
                    TextBox1.Text &= " is found"
                    'send(" is found", lsvClients.SelectedItems(clientID).Tag)

                    'MessageBox.Show(TextBox2.Text & " was found.")
                Else
                    TextBox1.Text &= " <ERROR>"
                    'send(" <ERROR>", lsvClients.SelectedItems(clientID).Tag)

                    'MessageBox.Show("<ERROR> " & TextBox2.Text & " is NOT in the Lexicon!")
                End If
                R.Close()

                clientSocket.EndReceive(ar)
                For i As Integer = 0 To 255
                    byteData(i) = "0"
                Next
            Catch ex As Exception

            End Try
            ' REDUCE CPU USAGE
            Thread.Sleep(100)
        End If

    End Sub


End Class