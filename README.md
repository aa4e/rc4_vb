# rc4_vb
**RC4 algorithm cypher and decypher** on Visual Basic .NET.

## Usage

- Encoder example (`VB.NET`):

```
Dim key As Byte() = Text.Encoding.UTF8.GetBytes("mySecretKey")
Dim rc As New Rc4(key)
Dim msgBytes As Byte() = Text.Encoding.ASCII.GetBytes(msg)
Dim cipherText As Byte() = rc.Encode(msgBytes)
```

- Decoder example (`VB.NET`):

```
Dim key As Byte() = Text.Encoding.UTF8.GetBytes("mySecretKey")
Dim rc As New Rc4(key)
Dim decip As Byte() = rc.Decode(cipherText)
Console.WriteLine(System.Text.Encoding.UTF8.GetString(decip))
```
