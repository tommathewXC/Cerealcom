Imports System.IO.Ports
Imports System.Drawing
Imports Excel = Microsoft.Office.Interop.Excel

Module Module1
    Dim st As String
    Dim arr As List(Of Double) = New List(Of Double)
    Dim prt As SerialPort
    Dim exapp As New Excel.Application
    Dim exwb As Excel.Workbook
    Dim exsht As Excel.Worksheet

    Dim window As Integer = 50
    Dim count As Integer = 1
    Dim counter As Integer = 1
    Dim arduino_delay As Integer = 2

    Private Sub Asillyscope()
        exapp.Visible = True
        exwb = exapp.Workbooks.Open("C:\Users\Public\Documents\Stephy's files\Knowledge\Codes\VBA\asillyscope.xls")
        exsht = exwb.Sheets.Item(1)

        exsht.Cells(3, 4).Value = arduino_delay / 1000
        prt = New SerialPort
        prt.PortName = "COM3"
        prt.BaudRate = 9600
        prt.Parity = Parity.None
        prt.DataBits = 8
        prt.StopBits = StopBits.One
        prt.ReadTimeout = 100000
        prt.Open()

        While (1)                                 'practically infinite loop
            st = prt.ReadLine()
            If (st <> "\r") And (st <> " ") Then
                Try
                    exsht.Cells(1 + (count Mod window), 2).Value = CDbl(st)
                    count = count + 1
                Catch ex As InvalidCastException
                    'Console.WriteLine("Error")
                End Try
            End If
        End While

        exwb.Close(SaveChanges:=True)
        exapp.Quit()
        prt.Close()
    End Sub


    Sub Main()
        counter = 0
        exapp.Visible = True
        exwb = exapp.Workbooks.Open("C:\Users\Public\Documents\Stephy's files\Knowledge\Codes\VBA\captester.xls")
        exsht = exwb.Sheets.Item(1)

        exsht.Cells(3, 4).Value = 0.1
        prt = New SerialPort
        prt.PortName = "COM3"
        prt.BaudRate = 9600
        prt.Parity = Parity.None
        prt.DataBits = 8
        prt.StopBits = StopBits.One
        prt.ReadTimeout = 100000
        prt.Open()
        While (1)                                 'practically infinite loop
            st = prt.ReadLine()
            If (st <> "\r") And (st <> " ") Then
                Try
                    exsht.Cells(1 + (counter), 2).Value = CDbl(st)
                    counter = counter + 1
                Catch ex As InvalidCastException
                    'Console.WriteLine("Error")
                Catch ex As TimeoutException
                    Return
                End Try
            End If
        End While

        exwb.Close(SaveChanges:=True)
        exapp.Quit()
        prt.Close()

    End Sub




End Module
