
Module Encoder

    Sub Main()

        Console.WriteLine("ШИФРОВАНИЕ СООБЩЕНИЙ АЛГОРИТМОМ RC4 ДЛЯ ""INTRANET CHAT""")
        Console.WriteLine()

        Do
            Try
                Console.WriteLine("Введите сообщение: ")
                Dim msg As String = Console.ReadLine()
                Dim key As Byte() = Text.Encoding.UTF8.GetBytes("tahci")
                Dim rc As New Rc4(key)
                Dim msgBytes As Byte() = Text.Encoding.ASCII.GetBytes(msg)
                Dim cipherText As Byte() = rc.Encode(msgBytes)
                Console.WriteLine("Закодированный текст: ")
                For Each b As Byte In cipherText
                    Console.Write(b.ToString("X2"))
                    Console.Write(" ")
                Next
                Console.WriteLine("= ")
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(cipherText))
            Catch ex As Exception
                Console.WriteLine()
                Console.WriteLine(ex.Message)
            Finally
                Console.WriteLine()
                Console.WriteLine()
            End Try
        Loop
    End Sub

End Module