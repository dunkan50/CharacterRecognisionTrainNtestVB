'traing and testing the

Option Explicit On
Option Strict On

Imports Emgu.CV.Util

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Public Class contourWithItem
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Const MIN_CONTOUR_AREA As Integer = 100

    Public contours As VectorOfPoint
    Public boundingRect As Rectangle
    Public dbArea As Double

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function checkIfContourIsReal() As Boolean 'wiil need to upgrade this fro any industrial kinda use
        If (dbArea < MIN_CONTOUR_AREA) Then
            Return False
        Else
            Return True

        End If
    End Function
End Class
