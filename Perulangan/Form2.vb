Public Class Form2

    Dim hasil As String = String.Empty
    Dim angka As Integer
    Dim data As String

    
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Pyramid")
        ComboBox1.Items.Add("Hollow Pyramid")
        ComboBox1.Items.Add("Inverted Pyramid")
        ComboBox1.Items.Add("Hollow Inverted Pyramid")
    End Sub

    Function Pyramid()

        angka = Convert.ToInt64(txtBaris.Text)

        For baris As Integer = 1 To angka
            For kolom As Integer = 1 To (angka - baris)
                hasil &= " "
            Next
            For kolom As Integer = 1 To (baris * 2) - 1
                hasil &= "*"
            Next
            hasil &= vbCrLf
        Next
        data &= hasil
        txtHasil.Text = data
        data = Nothing

    End Function

    Function HollowPyramid()

        angka = Convert.ToInt64(txtBaris.Text)

        For baris As Integer = 1 To angka
            For kolom As Integer = 1 To (angka - baris)
                hasil &= " "
            Next
            If baris = angka Or baris = 1 Then
                For kolom As Integer = 1 To (baris) + (baris - 1)
                    hasil &= "*"
                Next
            Else
                hasil &= "*"
                For kolom As Integer = 1 To (baris) + (baris - 3)
                    hasil &= " "
                Next
                hasil &= "*"
            End If
            hasil &= vbCrLf
        Next
        data &= hasil
        txtHasil.Text = data
        data = Nothing

    End Function


    Function InvertedPyramid()

        angka = Convert.ToInt64(txtBaris.Text)

        For baris As Integer = angka To 1 Step -1
            For kolom As Integer = (angka - baris) To 1 Step -1
                hasil &= " "
            Next
            For kolom As Integer = (baris * 2) - 1 To 1 Step -1
                hasil &= "*"
            Next
            hasil &= vbCrLf
        Next
        data &= hasil
        txtHasil.Text = data
        data = Nothing
    End Function

    Function HollowInvertedPyramid()

        angka = Convert.ToInt64(txtBaris.Text)

        For baris As Integer = angka To 1 Step -1
            For kolom As Integer = (angka - baris) To 1 Step -1
                hasil &= " "
            Next
            If baris = angka Or baris = 1 Then
                For kolom As Integer = (baris) + (baris - 1) To 1 Step -1
                    hasil &= "*"
                Next
            Else
                hasil &= "*"
                For kolom As Integer = (baris) + (baris - 3) To 1 Step -1
                    hasil &= " "
                Next
                hasil &= "*"
            End If
            hasil &= vbCrLf
        Next
        data &= hasil
        txtHasil.Text = data
        data = Nothing
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (ComboBox1.Text = ("Pyramid")) Then
            hasil = Nothing
            Pyramid()
        ElseIf (ComboBox1.Text = ("Hollow Pyramid")) Then
            hasil = Nothing
            HollowPyramid()
        ElseIf (ComboBox1.Text = ("Inverted Pyramid")) Then
            hasil = Nothing
            InvertedPyramid()
        ElseIf (ComboBox1.Text = ("Hollow Inverted Pyramid")) Then
            hasil = Nothing
            HollowInvertedPyramid()
        End If
    End Sub
End Class