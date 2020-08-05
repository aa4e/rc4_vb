Option Strict On
Option Explicit On
Option Infer On

Imports System.Runtime.CompilerServices

''' <summary>
''' Алгоритм шифрования и расшифрования RC4.
''' </summary>
Public Class Rc4

    ''' <summary>
    ''' Ключ шифрования (и расшифрования).
    ''' </summary>
    Public ReadOnly Property Key As Byte()

#Region "CTOR"

    ''' <summary>
    ''' Инициализация алгоритма RC4 заданным ключом.
    ''' </summary>
    ''' <param name="key"></param>
    Public Sub New(key As Byte())
        Me.Key = key
    End Sub

    Private S(255) As Integer 'Вектор перестановки.
    Private X As Integer 'Счётчик.
    Private Y As Integer 'Счётчик.

    ''' <summary>
    ''' Инициализирует вектор перестановки заданным ключом
    ''' (алгоритм ключевого расписания, key-scheduling algorithm).
    ''' </summary>
    ''' <param name="key">Байты ключа.</param>
    Private Sub Init(key() As Byte)
        X = 0
        Y = 0
        For i As Integer = 0 To 255
            S(i) = i
        Next
        Dim j As Integer = 0
        Dim keyLen As Integer = key.Length
        For i As Integer = 0 To 255
            j = (j + S(i) + CInt(key(i Mod keyLen))) Mod 256
            S.Swap(i, j)
        Next
    End Sub

#End Region '/CTOR

#Region "OPEN METHODS"

    ''' <summary>
    ''' Кодирует массив.
    ''' </summary>
    ''' <param name="openTextBytes">Массив байтов открытого текста.</param>
    Public Function Encode(openTextBytes As Byte()) As Byte()
        Init(Key)
        Dim ecnode As Byte() = New Byte(openTextBytes.Length - 1) {}
        For i As Integer = 0 To openTextBytes.Length - 1
            ecnode(i) = (openTextBytes(i) Xor GetNextItem())
        Next
        Return ecnode
    End Function

    ''' <summary>
    ''' Декодирует массив.
    ''' </summary>
    ''' <param name="encodedBytes">Зашифрованный массив.</param>
    Public Function Decode(encodedBytes As Byte()) As Byte()
        Return Encode(encodedBytes)
    End Function

#End Region '/OPEN METHODS

    ''' <summary>
    ''' Возвращает следующий элемент ПСП.
    ''' </summary>
    Private Function GetNextItem() As Byte
        X = (X + 1) Mod 256
        Y = (Y + S(X)) Mod 256
        S.Swap(X, Y)
        Dim ind As Integer = (S(X) + S(Y)) Mod 256
        Return CByte(S(ind))
    End Function

End Class '/Rc4

''' <summary>
''' Класс, расширяющий функциональность заданных типов.
''' </summary>
<Extension()>
Friend Module SwapExt

    ''' <summary>
    ''' Меняет местами заданные элементы массива.
    ''' </summary>
    ''' <typeparam name="T">Тип массива.</typeparam>
    ''' <param name="arr">Массив.</param>
    ''' <param name="index1">Индекс 1-го элемента.</param>
    ''' <param name="index2">Индекс 2-го элемента.</param>
    <Extension()>
    Public Sub Swap(Of T)(arr() As T, index1 As Integer, index2 As Integer)
        Dim temp As T = arr(index1)
        arr(index1) = arr(index2)
        arr(index2) = temp
    End Sub

End Module