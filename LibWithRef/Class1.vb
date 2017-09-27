Imports Emgu.CV
Imports Emgu.CV.Structure

Public Class Class1

    Public Shared Sub CallToNuGetPackage()
        Dim img As New Image(Of Bgr, Byte)("FragLernMoment.png")

        'Show the image
        UI.ImageViewer.Show(img)
    End Sub

End Class
