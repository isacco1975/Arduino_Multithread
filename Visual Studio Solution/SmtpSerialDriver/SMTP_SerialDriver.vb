Imports System.Configuration
Imports System.IO.Ports
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Sockets
Imports System.Text

''
''*******************************************************
''* TCP Serial Driver                                   *
''*                                                     *
''*                         2024 - Isaac Garcia Peveri  *
''*                                                     *
''* --------------------------------------------------  *
''* SMTP SERVER                                         *
''* --------------------------------------------------  *
''*******************************************************
''
Module TCP_SerialDriver

#Region "WORKING-STORAGE"
    Private WithEvents serialPort As SerialPort
    Private inSerialData As String = String.Empty
    Private comportName As String = String.Empty
    Private comportSpeed As Integer = 9600
    Private comportParity As Parity
    Private comportStopBits As Integer = 1
    Private comportDataBits As Integer = 8
    Private data As String = Nothing
    Private tcpPort As Integer = 64000
#End Region

    Private Sub ReadSettings()
        comportName = ConfigurationManager.AppSettings("ComportName")
        comportSpeed = CInt(ConfigurationManager.AppSettings("ComportSpeed"))
        comportParity = CInt(ConfigurationManager.AppSettings("ComportParity"))
        comportStopBits = CInt(ConfigurationManager.AppSettings("ComportStopBits"))
        comportDataBits = CInt(ConfigurationManager.AppSettings("ComportDataBits"))
        tcpPort = CInt(ConfigurationManager.AppSettings("TcpPort"))
    End Sub

    ''' <summary>
    ''' Thread Event DataReceived
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serialPort.DataReceived
        inSerialData = serialPort.ReadExisting()
        Threading.Thread.Sleep(100)
        SendEmail(inSerialData)
    End Sub

    ''' <summary>
    ''' Sending data incoming via Client to serial port 
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <returns></returns>
    Private Function SendData(msg As String) As Boolean
        Try
            serialPort.WriteLine(msg)
            Threading.Thread.Sleep(100)
            Return True

        Catch ex As Exception
            serialPort.Close()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Main Logicv
    ''' </summary>
    Sub Main()
        ' Reading Serial Port Settings from Configuration, and creates the object
        ReadSettings()
        serialPort = New SerialPort(comportName, comportSpeed, comportParity, comportDataBits, comportStopBits)
        serialPort.Open()

        ' Data buffer for incoming data.
        Dim bytes() As Byte = New [Byte](1024) {}

        Dim ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())
        Dim localEndPoint As New IPEndPoint(ipHostInfo.AddressList(0), tcpPort)

        ' Create a TCP/IP socket.
        Dim listener As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        ' Bind the socket to the local endpoint and listen for incoming connections.
        Try
            listener.Bind(localEndPoint)
            listener.Listen(50)

            ' Start listening for connections.
            While True
                Console.WriteLine(" ")
                Console.WriteLine("Server: Waiting for a connection...")
                Dim handler As Socket = listener.Accept()

                Console.WriteLine("Incoming connection ...")
                'Answering "Ready" (to talk with the client)
                handler.Send(Encoding.ASCII.GetBytes("220 Test SMTP Service ready" & vbCrLf))

                While True
                    bytes = New Byte(1024) {}
                    Dim bytesRec As Integer = handler.Receive(bytes)
                    data = Encoding.ASCII.GetString(bytes, 0, bytesRec)
                    Console.WriteLine("Incoming data from client : {0}", data)

                    If Not data = String.Empty Then
                        'Process Commands
                        Dim command As String = data.Substring(0, 4).ToUpper
                        Select Case command
                            Case "HELO"
                                handler.Send(Encoding.ASCII.GetBytes("250 OK" & vbCrLf))
                            Case "MAIL"
                                handler.Send(Encoding.ASCII.GetBytes("250 OK" & vbCrLf))
                            Case "RCPT"
                                handler.Send(Encoding.ASCII.GetBytes("250 OK" & vbCrLf))
                            Case "DATA"
                                ' Answering the client to send body data
                                handler.Send(Encoding.ASCII.GetBytes("354 Start mail input; end with ." & vbCrLf))
                            Case "QUIT"
                                handler.Send(Encoding.ASCII.GetBytes("221 Service closing transmission channel" & vbCrLf))
                                Exit While
                            Case "EHLO"
                                handler.Send(Encoding.ASCII.GetBytes("250 OK" & vbCrLf))
                            Case "MIME"
                                handler.Send(Encoding.ASCII.GetBytes("250 OK" & vbCrLf))
                            Case Else 'IN VB IT'S THE LINE ITSELF
                                'serialPort.Open()

                                Console.WriteLine("Incoming TCP message: " & data.Replace(Convert.ToChar(0), ""))
                                SendData(data.Substring(data.IndexOf("*") + 1, 4))
                                handler.Send(Encoding.ASCII.GetBytes("250 OK" & vbCrLf))

                                'serialPort.Close()
                                Exit While
                        End Select
                    End If
                End While

                'Close Connection
                handler.Shutdown(SocketShutdown.Both)
                handler.Close()
            End While

        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        End Try

        Console.WriteLine(ControlChars.Cr + "Press ENTER to continue...")
        Console.Read()
    End Sub

    Private Sub SendEmail(pStr As String)
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()

            Smtp_Server.UseDefaultCredentials = True
            Smtp_Server.Credentials = New Net.NetworkCredential("HIDDEN@gmail.com", "HIDDEN")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("ArduinoApplication@igp.com")
            e_mail.To.Add("HIDDEN@gmail.com")
            e_mail.Subject = pStr
            e_mail.IsBodyHtml = True
            e_mail.Body = pStr

            Smtp_Server.Send(e_mail)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Module
