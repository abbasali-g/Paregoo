Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting

Namespace BaseForm
    Public Class ImageManager


#Region "LReview"

#Region "Methods"

        Public Shared Function WriteImage(ByVal imageID As String, ByVal imageFullpath As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_imageID", imageID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim imageBinary() As Byte = Nothing

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_imagesSelContentByID", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                imageBinary = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "imageLogo")

            End If

            reader.Close()

            If imageBinary Is Nothing Then Return False

            Common.FileManager.GetFileFromBinaryFormat(imageBinary, imageFullpath, False, True)

            Return True

        End Function

        Public Shared Function EditImage(ByVal parameter As Image, Optional ByVal imagePath_wirte As String = "") As Boolean

            Dim params(4) As MySqlParameter

            params(0) = New MySqlParameter("_imageExtension", parameter.imageExtension)

            params(1) = New MySqlParameter("_imageID", parameter.imageID)
            Dim logo As Byte() = Nothing
            If parameter.imagePath = String.Empty Then

                params(2) = New MySqlParameter("_imageLogo", DBNull.Value)
            Else
                logo = Common.FileManager.GetFileInBinaryFormat(parameter.imagePath, parameter.imageID & parameter.imageUpdateDate, True)
                params(2) = New MySqlParameter("_imageLogo", logo)

            End If

            If parameter.imageName <> String.Empty AndAlso parameter.imageName.Length > 45 Then parameter.imageName = parameter.imageName.Substring(0, 45)

            params(3) = New MySqlParameter("_imageName", parameter.imageName)

            params(4) = New MySqlParameter("_imageUpdateDate", parameter.imageUpdateDate)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_imagesUpd", params)

            If db.HasError Then Throw db.ErrorException

            If imagePath_wirte <> "" Then Common.FileManager.GetFileFromBinaryFormat(logo, imagePath_wirte, False, True)

            Return True

        End Function

        Public Shared Function IsCorrectImage(ByVal extenstion As String) As Boolean

            extenstion = extenstion.ToLower()

            If extenstion = ".jpg" OrElse extenstion = ".png" OrElse extenstion = ".gif" OrElse extenstion = ".bitmap" Then

                Return True

            End If

            Return False

        End Function

        Public Shared Function AddImage(ByVal parameter As Image, Optional ByVal imagePath_wirte As String = "") As Boolean

            Dim params(4) As MySqlParameter

            params(0) = New MySqlParameter("_imageExtension", parameter.imageExtension)

            params(1) = New MySqlParameter("_imageID", parameter.imageID)

            Dim logo As Byte() = Nothing

            If parameter.imagePath = String.Empty Then
                params(2) = New MySqlParameter("_imageLogo", DBNull.Value)

            Else
                logo = Common.FileManager.GetFileInBinaryFormat(parameter.imagePath, parameter.imageID & parameter.imageUpdateDate, True)
                params(2) = New MySqlParameter("_imageLogo", logo)

            End If
           
            'Dim logo As Byte() = Common.FileManager.GetFileInBinaryFormat(parameter.imagePath, parameter.imageID, True)

           
            If parameter.imageName <> String.Empty AndAlso parameter.imageName.Length > 45 Then parameter.imageName = parameter.imageName.Substring(0, 45)

            params(3) = New MySqlParameter("_imageName", parameter.imageName)

            params(4) = New MySqlParameter("_imageUpdateDate", parameter.imageUpdateDate)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_imagesIns", params)

            If db.HasError Then Return False

            If imagePath_wirte <> "" Then Common.FileManager.GetFileFromBinaryFormat(logo, imagePath_wirte, False, True)

            Return True

        End Function

        Public Shared Function GetImageByID(ByVal imageID As String) As Image

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_imageID", imageID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim pic As Image = Nothing

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_imagesSelAllByID", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                pic = GetImageFromReader(reader)

            End If

            reader.Close()

            Return pic

        End Function

        Public Shared Function IsImageExist(ByVal imageID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_imageID", imageID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim pic As Image = Nothing

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_iimagesUtiIsExist", params))

            If db.HasError Then Return True

            Return result

        End Function

        Public Shared Function GetImagesByGroupName(ByVal groupName As String) As ImageCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_imageGroupName", groupName)

            Dim list As New ImageCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_imagesSelByGroupName", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim child As Image = GetImageFromReader(reader)

                list.Add(child)

            End While

            reader.Close()

            Return list

        End Function



#End Region

#Region "Utility"


        Private Shared Function GetImageFromReader(ByVal reader As IDataReader) As Image

            Dim parameter As New Image

            parameter.imageExtension = DbAccessLayer.MySqlDataHelper.GetString(reader, "imageExtension")

            parameter.imageID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "imageID").ToString()

            parameter.imageLogo = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "imageLogo")

            parameter.imageName = DbAccessLayer.MySqlDataHelper.GetString(reader, "imageName")

            parameter.imageUpdateDate = DbAccessLayer.MySqlDataHelper.GetString(reader, "imageUpdateDate")

            Return parameter

        End Function

#End Region
#End Region
#Region "Methods"

        Public Shared Function WriteAndGetImagePath(ByVal imageID As String, ByVal WritePath As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_imageID", imageID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim newImage As Image

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_imagesSelAllByID", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                newImage = GetImageFromReader(reader)

            End If

            reader.Close()

            Dim imageFullPath As String = WritePath + imageID + newImage.imageUpdateDate + newImage.imageExtension

            Common.FileManager.GetFileFromBinaryFormat(newImage.imageLogo, imageFullPath, )

            Return imageFullPath

        End Function


        Public Shared Function DeleteImage(ByVal ImageId As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_imageID", ImageId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_imagesDel", params)

            If db.HasError Then Return False

            Return True

        End Function

        
#End Region

#Region "Utility"

        Private Shared Function GetPictureFromReader(ByVal reader As IDataReader) As Common.Picture

            Dim parameter As New Common.Picture

            parameter.BinaryPicture = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "imageLogo")

            parameter.pictureExtention = DbAccessLayer.MySqlDataHelper.GetString(reader, "imageExtension")

            parameter.picUpdatedate = DbAccessLayer.MySqlDataHelper.GetString(reader, "imageUpdateDate")

            Return parameter

        End Function

        Private Shared Function GetUserImageFromReader(ByVal reader As IDataReader) As BaseForm.ImageReview

            Dim parameter As New BaseForm.ImageReview

            parameter.imageLogo = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "imageLogo")

            parameter.imageExtension = DbAccessLayer.MySqlDataHelper.GetString(reader, "imageExtension")

            parameter.imageUpdateDate = DbAccessLayer.MySqlDataHelper.GetString(reader, "imageUpdateDate")

            Return parameter

        End Function


#End Region

#Region "BaseMethod"


        Public Shared Function GetDefaultIcon_FilesTable(ByVal type As Docs.Enums.FileType) As String


            Select Case type

                Case Docs.Enums.FileType.فایل


                    Return "24aa44d2-8e8e-4bf4-9e21-1eedff448b30"

                Case Docs.Enums.FileType.پرونده

                    Return "792e637a-1385-4b5c-b79b-752b7c5501ec"

                Case Docs.Enums.FileType.دایرکتوری_اوراق

                    Return "416ba958-e924-4f02-bdfa-af83cebcebd8"

                Case Docs.Enums.FileType.پرونده_قفل_شده

                    Return "3b93ef80-a23d-4983-bcfe-f2c5d469d4f2"

                Case Docs.Enums.FileType.مشخصات_پرونده

                    Return "f01b95c5-fd9b-48f5-a681-3fc505d549aa"

                Case Docs.Enums.FileType.پرونده_مختومه

                    Return "60b2ce40-663e-4a11-8d3d-27da8db3c76d"

                Case Docs.Enums.FileType.دایرکتوری_مستندات

                    Return "21c0a2f7-f5b4-49b9-8e09-cd918340fab5"

                Case Docs.Enums.FileType.دایرکتوری_متفرقه

                    Return "40bbab0c-0b6d-4e7e-a007-8949dcaa42e9"

                Case Docs.Enums.FileType.آلارم

                    Return "2fb5a172-3c6c-406b-96c6-9d8aa176e932"

                Case Docs.Enums.FileType.مالی
                    Return "a18ab656-390c-41f7-820f-97a79e046cf9"

                Case Docs.Enums.FileType.تجمیع_پرونده

                    Return "08651579-9106-4333-afc6-41b06c6888de"

                Case Docs.Enums.FileType.مشاوره

                    Return "3a806042-67ce-41eb-b621-1f8a4b4fc427"

                Case Docs.Enums.FileType.آرشیو_فایل
                    Return "4fc7c583-6d5c-4126-ad75-dfa2803e7456"
            End Select

        End Function

        'Public Shared Function GetDefaultIcon_TempDocsTable(ByVal extension As String) As String

        '    Select Case extension.ToLower()

        '        Case ".txt"

        '            Return "d64d660e-b851-4349-8691-0e98597a68e5"

        '        Case ".doc", ".docx", ".dot", ".dotx"

        '            Return "bb453cce-c085-4ae2-8720-dce65c68a787"

        '        Case ".jpg", ".gif", ".bmp"

        '            Return "b364eb5c-0bf9-45f3-a95c-21967b50446c"

        '        Case ".rar"

        '            Return "a1af4167-55e7-4f88-9387-916f32d675c3"

        '        Case ".zip"

        '            Return "561c2743-6f93-42e4-b4ab-3eb0fe3b3a61"

        '        Case ".pdf"

        '            Return "69ac97ff-381d-4c7e-a0b9-b8c0c5260228"

        '        Case ""

        '            Return "413ba2ae-cd0b-45b0-a579-c0e89bab0d95"

        '        Case Else

        '            Return "6584afef-6f1e-442d-b758-3714523d5082"

        '    End Select



        'End Function


        'Public Shared Function GetDefaultIcon_TempDocsTable(ByVal extension As String) As String

        '    Select Case extension.ToLower()

        '        Case ".txt"

        '            Return "91c08097-26b0-4e1d-8671-744d59793d0c"

        '        Case ".doc", ".docx", ".dot", ".dotx"

        '            Return "685cbd91-8d17-43cb-8370-d97184b28d9f"

        '        Case ".jpg", ".gif", ".bmp"

        '            Return "4fe37491-b59e-4708-b28e-44d652b8acc8"

        '        Case ".rar", ".zip"

        '            Return "9efe4a3e-7c6e-453d-a489-29a2436e4c45"

        '        Case ".pdf"

        '            Return "fe705d4f-ae40-4adb-8fc4-029ffda35b24"

        '        Case ".xls", "xlsx"

        '            Return "3980fcaa-d3f2-4b8a-8719-b63c6d3d5ab4"

        '        Case Else

        '            Return "55254771-b242-4b98-b1de-ba1eb20bfe41"

        '    End Select



        'End Function


        Public Shared Function GetDefaultIcon_TempDocsTable(ByVal extension As String) As String

            Select Case extension.ToLower()

                Case ".txt"

                    Return "30fbb815-8229-4c3a-bb48-f59555f03e7d"

                Case ".doc", ".docx"

                    Return "230d0c11-815b-459d-badf-621a036f66ef"


                Case ".dot", ".dotx"

                    Return "408783e5-9a58-49a6-9a72-9888badcf36a"


                Case ".jpg", ".gif", ".bmp", ".tif", ".tiff", ".jpeg", ".png"

                    Return "d1ed7b4b-e149-4eda-b602-f617f092697f"


                Case ".pdf"

                    Return "fb9db9a9-6596-454b-bb6e-5f72ce2e272b"

                Case ""

                    Return "c8191a91-f8ea-44ed-897e-01ccb33a97bf"

                Case ".xls", ".xlsx"

                    Return "156d8f19-168e-4b73-a034-432b14a3f448"

            End Select

            Return Nothing


        End Function

        Public Shared Function GetDefaultIcon_TempDocsTable16(ByVal extension As String) As String

            Select Case extension.ToLower()

                Case ".txt"

                    Return "40b990d8-a775-4767-b8c7-288b848c8b91"

                Case ".doc", ".docx", ".dot", ".dotx"

                    Return "00bb5701-55f1-4390-8f57-bd3bdc8c028c"

                Case ".jpg", ".gif", ".bmp", ".tif", ".tiff", ".jpeg", ".png"

                    Return "717c890e-749b-4af0-b05a-a742009f41e1"

                Case ".rar", ".zip"

                    Return "82368643-37a5-417f-b9dc-65a720cab7eb"

                Case ".pdf"

                    Return "a506a346-c7e4-4209-b8d8-a435a08109e4"

                Case ".xls", ".xlsx"

                    Return "b928a0f9-d0cc-4615-8d0b-eab6b7262413"

                Case Else

                    Return "1bd43e93-376b-452a-b55d-e4f23cd1ba47"

            End Select

            Return Nothing


        End Function

#End Region

    End Class
End Namespace

