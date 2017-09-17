'testin chars in images vb

Option Explicit On
Option Strict On

Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports Emgu.CV.UI
Imports Emgu.CV.Structure
Imports Emgu.CV.Util
Imports Emgu.CV.ML

Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Public Class frmMain
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Const CHANGED_IMAGE_WIDTH As Integer = 20
    Const CHANGED_IMAGE_HEIGHT As Integer = 30

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub btnChooseimage_Click(sender As Object, e As EventArgs) Handles btnChooseimage.Click
        'we have to reade the xml file twice for the system to picka and anaylyse the data
        'first its fro the rows and second the reinstatite the classifications

        Dim classificationMatrix As Matrix(Of Single) = New Matrix(Of Single)(1, 1) 'this is for the decration that this is row one and this a diff row
        Dim trainingImageMatrix As Matrix(Of Single) = New Matrix(Of Single)(1, 1) 'for resizing theimages got
        Dim validChars As New List(Of Integer)(New Integer() {Asc("0"), Asc("1"), Asc("2"), Asc("3"), Asc("4"), Asc("5"), Asc("6"), Asc("7"), Asc("8"), Asc("9"),
                                                                  Asc("A"), Asc("B"), Asc("C"), Asc("D"), Asc("E"), Asc("F"), Asc("G"), Asc("H"), Asc("I"), Asc("J"),
                                                                  Asc("K"), Asc("L"), Asc("M"), Asc("N"), Asc("O"), Asc("P"), Asc("Q"), Asc("R"), Asc("S"), Asc("T"),
                                                                  Asc("U"), Asc("V"), Asc("W"), Asc("X"), Asc("Y"), Asc("Z")})

        Dim xmlserial As XmlSerializer = New XmlSerializer(classificationMatrix.GetType) 'this a re the variables for the writer
        Dim sreader As StreamReader  'reads the xml files given

        Try
            sreader = New StreamReader("classification.xml") 'this tries to open the xml files

        Catch ex As Exception 'if there is an issue the there is an error message
            tbinfo.AppendText(vbCrLf + "Unable to open file, error:")
            tbinfo.AppendText(ex.Message + vbCrLf)
            Return
        End Try 'with this we are able to read the file to get the number of rows  not the actula data

        classificationMatrix = CType(xmlserial.Deserialize(sreader), Matrix(Of Single))
        sreader.Close() 'closes the opend file

        Dim numberOfTrainingSamples As Integer = classificationMatrix.Rows 'for the evaluatin of rows

        classificationMatrix = New Matrix(Of Single)(numberOfTrainingSamples, 1)
        trainingImageMatrix = New Matrix(Of Single)(numberOfTrainingSamples, CHANGED_IMAGE_WIDTH * CHANGED_IMAGE_HEIGHT)

        Try
            sreader = New StreamReader("classification.xml") 'reinitialize the reader and try to read the file

        Catch ex As Exception 'if there is an error
            tbinfo.AppendText(vbCrLf + "Unable to open the file,error:" + vbCrLf)
            tbinfo.AppendText(ex.Message + vbCrLf + vbCrLf)

        End Try 'we read the file again but this time we  look at the actual data

        classificationMatrix = CType(xmlserial.Deserialize(sreader), Matrix(Of Single))
        sreader.Close() 'after getting the data we cloe the file

        xmlserial = New XmlSerializer(trainingImageMatrix.GetType) 'reinitialize file reading variable

        Try
            sreader = New StreamReader("images.xml") 'tries to open the images file

        Catch ex As Exception 'if there is an arroe found
            tbinfo.AppendText("Unable to open file, error:" + vbCrLf + vbCrLf)
            tbinfo.AppendText(ex.Message + vbCrLf + vbCrLf)
        End Try

        trainingImageMatrix = CType(xmlserial.Deserialize(sreader), Matrix(Of Single)) 'reads trainging imags from file
        sreader.Close()
        ''''''''trains program and test the images '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim knearest As New KNearest()
        knearest.DefaultK = 1

        knearest.Train(trainingImageMatrix, MlEnum.DataLayoutType.RowSample, classificationMatrix)

        Dim getFile As DialogResult
        getFile = fileOpenDialog.ShowDialog()
        If (getFile <> DialogResult.OK Or fileOpenDialog.FileName = "") Then
            choosenFilelb.Text = "filenot chosen" 'to show the erroe in the programs lable
            Return
        End If
        Dim testingNumbersImage As Mat 'this is fro the input image

        Try
            testingNumbersImage = CvInvoke.Imread(fileOpenDialog.FileName, LoadImageType.Color) 'this opens our image

        Catch ex As Exception 'if there is an error
            choosenFilelb.Text = "Unable to open given file, error;" + ex.Message
            Return 'exits function

        End Try

        If (testingNumbersImage Is Nothing) Then
            choosenFilelb.Text = "Unable to open file"
            Return
        End If

        choosenFilelb.Text = fileOpenDialog.FileName 'updates the label

        Dim grayscaleImage As New Mat()
        Dim blurredImage As New Mat()
        Dim threshImage As New Mat()
        Dim copyofThreshimage As New Mat()

        CvInvoke.CvtColor(testingNumbersImage, grayscaleImage, ColorConversion.Bgr2Gray)
        CvInvoke.GaussianBlur(grayscaleImage, blurredImage, New Size(5, 5), 0)
        CvInvoke.AdaptiveThreshold(blurredImage, threshImage, 255.0, AdaptiveThresholdType.GaussianC, ThresholdType.BinaryInv, 11, 2.0)

        copyofThreshimage = threshImage.Clone()
        Dim contours As New VectorOfVectorOfPoint() 'gets the external contours 

        CvInvoke.FindContours(copyofThreshimage, contours, Nothing, RetrType.External, ChainApproxMethod.ChainApproxSimple)

        Dim listofContoursWithData As New List(Of contourWithItem)


        For i As Integer = 0 To contours.Size - 1
            Dim contourWithData As New contourWithItem 'incase of error check this space if doesnt work get the 3.0 lib
            contourWithData.contours = contours(i)
            contourWithData.boundingRect = CvInvoke.BoundingRectangle(contourWithData.contours)
            contourWithData.dbArea = CvInvoke.ContourArea(contourWithData.contours)

            If (contourWithData.checkIfContourIsReal()) Then
                listofContoursWithData.Add(contourWithData)

            End If

        Next

        Dim finalString As String = ""

        For Each contourWithData As contourWithItem In listofContoursWithData
            CvInvoke.Rectangle(testingNumbersImage, contourWithData.boundingRect, New MCvScalar(255.0, 0.0, 0.0), 2) 'bound the chacters with blue boundary

            Dim copyofROIImage As New Mat(threshImage, contourWithData.boundingRect)
            Dim ROIImage As Mat = copyofROIImage.Clone() 'this assisted to avoid change in the size of the original image after resizing
            Dim resizedROIIMage As New Mat()
            CvInvoke.Resize(ROIImage, resizedROIIMage, New Size(CHANGED_IMAGE_WIDTH, CHANGED_IMAGE_HEIGHT))
            Dim tempMatrix As Matrix(Of Single) = New Matrix(Of Single)(resizedROIIMage.Size()) 'variates the resized image to a matrix formation for better an checking
            Dim resizedTempMatrix As Matrix(Of Single) = New Matrix(Of Single)(1, CHANGED_IMAGE_WIDTH * CHANGED_IMAGE_HEIGHT) 'changed heaght of the matrix gotten
            resizedROIIMage.ConvertTo(tempMatrix, DepthType.Cv32F) 'changes the matrix image to the same height

            For intRow As Integer = 0 To CHANGED_IMAGE_HEIGHT - 1
                For intcolumns As Integer = 0 To CHANGED_IMAGE_WIDTH - 1
                    resizedTempMatrix(0, (intRow * CHANGED_IMAGE_WIDTH) + intcolumns) = tempMatrix(intRow, intcolumns) 'does the chnages in the images for us

                Next
            Next

            Dim charNow As Single

            charNow = knearest.Predict(resizedTempMatrix) 'now the program tries to geus the varialbles

            finalString = finalString + Chr(Convert.ToInt32(charNow)) 'append all char to full strings

        Next

        tbinfo.AppendText(vbCrLf + vbCrLf + "Characters got from image are: " + finalString + vbCrLf)

        CvInvoke.Imshow("The test image", testingNumbersImage)


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


    End Sub
End Class
