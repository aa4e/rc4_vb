Imports System.Text.RegularExpressions

Module Decoder

    Sub Main()

        Console.WriteLine("РАСШИФРОВАНИЕ СООБЩЕНИЙ АЛГОРИТМОМ RC4 ДЛЯ ""INTRANET CHAT""")
        Console.WriteLine()

        Do
            Try
                Dim key As Byte() = Text.Encoding.UTF8.GetBytes("tahci")
                Dim rc As New Rc4(key)

                Dim cipherText As Byte() = GetBytesFromWireShark()
                Console.WriteLine()

                Dim decip As Byte() = rc.Decode(cipherText)
                Console.WriteLine("Раскодированный RC4 текст: ")
                For Each b As Byte In decip
                    Console.Write(b.ToString("x2"))
                    Console.Write(" ")
                Next
                Console.WriteLine("= ")
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(decip))
            Catch ex As Exception
                Console.WriteLine()
                Console.WriteLine(ex.Message)
            Finally
                Console.WriteLine()
                Console.WriteLine()
            End Try
        Loop
    End Sub

    Private Function GetBytesFromWireShark() As Byte()
        Dim hexRx As New Regex("[0-9A-Fa-f]{2}")
        Console.WriteLine("Введите массив байтов в HEX представлении: ")
        Dim s As String = Console.ReadLine() ' "0b:c2:63:0c:c1:61:9f:40:d1:c5:98:49:98:a3:61:63:2f:c2:be:2a:d4:80:03:4b:fc:6b:83:07:df:cf:bd:36:80:d1:e0:dd:57"
        Dim mc As MatchCollection = hexRx.Matches(s)
        Dim b As New List(Of Byte)
        For Each m As Match In mc
            b.Add(Byte.Parse(m.Value, Globalization.NumberStyles.HexNumber))
        Next
        Return b.ToArray()
    End Function

End Module