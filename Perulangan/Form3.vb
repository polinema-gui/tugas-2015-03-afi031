Public Class Form3

    Dim baris1, baris2, kolom1, kolom2 As Integer
    Dim tampil As Boolean = False

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Tambah")
        ComboBox1.Items.Add("Kurang")
    End Sub

    Private Sub masukanArray(ByRef arr1(,) As String, ByRef arr2(,) As String)
        baris1 = 0
        While baris1 < txtMatrik1.Lines.Count
            kolom1 = 0
            While kolom1 < txtMatrik1.Lines.ElementAt(baris1).Split(" ").Length
                arr1(baris1, kolom1) = txtMatrik1.Lines.ElementAt(baris1).Split(" ").ElementAt(kolom1).ToString
                kolom1 += 1
            End While
            baris1 += 1
        End While
        baris1 = 0
        While baris1 < txtMatrik2.Lines.Count
            kolom1 = 0
            While kolom1 < txtMatrik2.Lines.ElementAt(baris1).Split(" ").Length
                arr2(baris1, kolom1) = txtMatrik2.Lines.ElementAt(baris1).Split(" ").ElementAt(kolom1).ToString
                kolom1 += 1
            End While
            baris1 += 1
        End While
    End Sub

    Function matrik1() As Boolean
        baris1 = 0
        While baris1 < txtMatrik1.Lines.Count
            baris2 = 0
            While baris2 < txtMatrik1.Lines.Count
                If txtMatrik1.Lines.ElementAt(baris1).Split(" ").Length <> txtMatrik1.Lines.ElementAt(baris2).Split(" ").Length Then
                    Return True
                End If
                baris2 += 1
            End While
            baris1 += 1
        End While
        Return False
    End Function

    Function matrik2() As Boolean
        baris1 = 0
        While baris1 < txtMatrik2.Lines.Count
            baris2 = 0
            While baris2 < txtMatrik2.Lines.Count
                If txtMatrik2.Lines.ElementAt(baris1).Split(" ").Length <> txtMatrik2.Lines.ElementAt(baris2).Split(" ").Length Then
                    Return True
                End If
                baris2 += 1
            End While
            baris1 += 1
        End While
        Return False
    End Function

    Function barisMatrik() As Boolean
        If txtMatrik1.Lines.Count <> txtMatrik2.Lines.Count Then
            Return True
        Else
            Return False
        End If
    End Function

    Function kolomMatrik() As Boolean
        If txtMatrik1.Lines.ElementAt(0).Split(" ").Length <> txtMatrik2.Lines.ElementAt(0).Split(" ").Length Then
            Return True
        Else
            Return False
        End If
    End Function

    Function peraturanMatrik() As Integer
        If txtMatrik1.Text = "" Or txtMatrik1.Text = " " Then
            MsgBox("Bukan matrik yang valid", MsgBoxStyle.Information, "Peringatan")
            Return 0
            Exit Function
        End If
        If txtMatrik2.Text = "" Or txtMatrik2.Text = " " Then
            MsgBox("Bukan matrik yang valid", MsgBoxStyle.Information, "Peringatan")
            Return 0
            Exit Function
        End If
        If matrik1() Then
            MsgBox("Bukan matrik yang valid", MsgBoxStyle.Information, "Peringatan")
            Return 0
            Exit Function
        End If
        If matrik2() Then
            MsgBox("Bukan matrik yang valid", MsgBoxStyle.Information, "Peringatan")
            Return 0
            Exit Function
        End If
        Return 1
    End Function

    Function cekMatrikTambahKurang() As Integer
        If peraturanMatrik() = 0 Then
            Return 0
            Exit Function
        End If
        If barisMatrik() Then
            MsgBox("Jumlah Baris dan Kolom pada kedua matrik harus sama", MsgBoxStyle.Information, "Peringatan")
            Return 0
            Exit Function
        End If
        If kolomMatrik() Then
            MsgBox("Jumlah Baris dan Kolom pada kedua matrik harus sama", MsgBoxStyle.Information, "Peringatan")
            Return 0
            Exit Function
        End If
        Return 1
    End Function

    Private Sub tambah(ByVal arr1(,) As String, ByVal arr2(,) As String, ByRef arrHasil(,) As String)
        baris1 = 0
        While baris1 < arr1.GetLength(0) - 1
            kolom1 = 0
            While kolom1 < arr1.GetLength(1) - 1
                arrHasil(baris1, kolom1) = Val(arr1(baris1, kolom1)) + Val(arr2(baris1, kolom1))
                kolom1 += 1
            End While
            baris1 += 1
        End While
        tampil = True
    End Sub

    Private Sub kurang(ByVal arr1(,) As String, ByVal arr2(,) As String, ByRef arrHasil(,) As String)
        baris1 = 0
        While baris1 < arr1.GetLength(0) - 1
            kolom1 = 0
            While kolom1 < arr1.GetLength(1) - 1
                arrHasil(baris1, kolom1) = Val(arr1(baris1, kolom1)) - Val(arr2(baris1, kolom1))
                kolom1 += 1
            End While
            baris1 += 1
        End While
        tampil = True
    End Sub

    Private Sub tampilMatrik(ByVal arrHasil(,) As String)
        Dim str As String = ""
        baris1 = 0
        While baris1 < arrHasil.GetLength(0) - 1
            kolom1 = 0
            While kolom1 < arrHasil.GetLength(1) - 1
                str &= arrHasil(baris1, kolom1) & vbTab
                kolom1 += 1
            End While
            str &= vbCrLf
            baris1 += 1
        End While
        txtHasil.Text = str.ToString
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
        If ComboBox1.Text = ("") Then
            MsgBox("Operasi belum di pilih", MsgBoxStyle.Information, "Peringatan")
        ElseIf ComboBox1.Text = ("Tambah") Then
            If cekMatrikTambahKurang() = 1 Then
                Dim arr1(txtMatrik1.Lines.Count, txtMatrik1.Lines.ElementAt(0).Split(" ").Length), arr2(txtMatrik2.Lines.Count, txtMatrik2.Lines.ElementAt(0).Split(" ").Length), arrHasil(txtMatrik2.Lines.Count, txtMatrik2.Lines.ElementAt(0).Split(" ").Length) As String
                masukanArray(arr1, arr2)
                tambah(arr1, arr2, arrHasil)
                If tampil Then
                    tampilMatrik(arrHasil)
                    tampil = False
                End If
        End If
        ElseIf ComboBox1.Text = ("Kurang") Then
            If cekMatrikTambahKurang() = 1 Then
                Dim arr1(txtMatrik1.Lines.Count, txtMatrik1.Lines.ElementAt(0).Split(" ").Length), arr2(txtMatrik2.Lines.Count, txtMatrik2.Lines.ElementAt(0).Split(" ").Length), arrHasil(txtMatrik2.Lines.Count, txtMatrik2.Lines.ElementAt(0).Split(" ").Length) As String
                masukanArray(arr1, arr2)
                kurang(arr1, arr2, arrHasil)
                If tampil Then
                    tampilMatrik(arrHasil)
                    tampil = False
                End If
            End If
        End If
    End Sub
End Class