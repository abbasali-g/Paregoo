Namespace LockDocs

    Public Class Transfer

        Public Shared TransferError As String

        Public Shared Function TransferToLocal(ByVal fileCase As Windows.Forms.ListViewItem, ByVal parentId As String) As String

            Dim fileId As String = fileCase.SubItems(1).Text

            If fileCase.SubItems(3).Text = Docs.Enums.FileType.پرونده_قفل_شده Then

                Dim locker As ContactInfo.ContactInfoReview = Docs.FileDocManager.GetFileLocker(fileId)

                If locker.custID = Login.CurrentLogin.CurrentUser.UserID Then

                    Try
                        '

                        If Update.UpdateManager.GetCurrentVersion("d"c) = DestinationManager.GetCurrentVersion("d"c) Then

                            '1)fileCaseArea Table
                            TransferFileCaseAreaTable_Local()

                            '2)Contactinfo Table
                            TransferContactinfoTable_Local()

                            '3) انتقال پرونده
                            If TransferFileCase_Local(fileId) Then
                                '' ''If TransferFileCase_Local(parentId, fileId) Then

                                Return String.Empty

                            Else

                                Throw New Exception

                            End If

                        Else
                            Throw New Exception

                        End If

                    Catch ex As Exception

                        Return "نسخه پایگاه داده درست نمی باشد . ابتدااز طریق فرم پشتیبان گیری نسخه جدید را از سرور دانلود کنید."

                    End Try
                    'مقایسه ورژن دو پایگاه داده
                   

                    Return String.Empty

                Else

                    Return "پرونده توسط " & locker.custFullName & " قفل شده است "

                End If

            Else

                Return "ابتدا پرونده را قفل نمایید"

            End If

        End Function

        Public Shared Function TransferToLocal_new(ByVal fileCase As Windows.Forms.ListViewItem, ByVal parentId As String) As String

            Dim fileId As String = fileCase.SubItems(1).Text

            If fileCase.SubItems(3).Text = Docs.Enums.FileType.پرونده_قفل_شده Then

                Dim locker As ContactInfo.ContactInfoReview = Docs.FileDocManager.GetFileLocker(fileId)

                If locker.custID = Login.CurrentLogin.CurrentUser.UserID Then

                    Try
                        '

                        If Update.UpdateManager.GetCurrentVersion("d"c) = DestinationManager.GetCurrentVersion("d"c) Then

                            Try
                                '1)fileCaseArea Table
                                TransferFileCaseAreaTable_Local()

                                '2)Contactinfo Table
                                TransferContactinfoTable_Local()

                            Catch ex As Exception

                                Return "خطا در ارسال مقادیر پایه"

                            End Try
                           

                            '3) انتقال پرونده

                            Return TransferFileCase_Local_new(parentId, fileId)

                        Else
                            Throw New Exception

                        End If

                    Catch ex As Exception

                        Return "نسخه پایگاه داده درست نمی باشد . ابتدااز طریق فرم پشتیبان گیری نسخه جدید را از سرور دانلود کنید."

                    End Try
                    'مقایسه ورژن دو پایگاه داده


                    Return String.Empty

                Else

                    Return "پرونده توسط " & locker.custFullName & " قفل شده است "

                End If

            Else

                Return "ابتدا پرونده را قفل نمایید"

            End If

        End Function

        Public Shared Function CheckBeforeTransferToServer(ByVal fileCase As Windows.Forms.ListViewItem, ByVal parentId As String) As String

            Try

                Dim fileId As String = fileCase.SubItems(1).Text

                Dim locker As ContactInfo.ContactInfoReview = DestinationManager.CheckLockDoc(fileId)

                '1) پرونده در سرور توسط این کاربر قفل شده است , یا پرونده جدید می باشد
                If locker Is Nothing OrElse locker.custID = Login.CurrentLogin.CurrentUser.UserID Then

                    Try
                        '2)قفل کردن همین پرونده در کامپیوتر جاری
                        Docs.FileDocManager.UpdateFileLocker(fileId, Login.CurrentLogin.CurrentUser.UserID, BaseForm.ImageManager.GetDefaultIcon_FilesTable(Docs.Enums.FileType.پرونده_قفل_شده), Docs.Enums.FileType.پرونده_قفل_شده)

                        Return String.Empty

                    Catch ex As Exception

                        Return "پرونده را قفل نمایید."

                    End Try



                ElseIf locker IsNot Nothing Then

                    If locker.custID <> Guid.Empty.ToString() Then

                        Return "پرونده توسط " & locker.custFullName & " قفل شده است. "

                    Else

                        Return "ابتدا پرونده رادر سرور قفل نمایید."

                    End If

                End If

                Return String.Empty

            Catch ex As Exception

                Return "خطا در ارسال پرونده"

            End Try

        End Function

        Public Shared Function TransferFileCase(ByVal parentId As String, ByVal fileId As String, ByVal isNew As Boolean) As String

            Try

                TransferError = String.Empty

                '1) انتقال پرونده
                Dim filecaseId As String = Docs.FileDocManager.GetFileCaseID(fileId)

                If filecaseId <> String.Empty AndAlso filecaseId <> Guid.Empty.ToString() Then

                    Dim fc As Docs.FileCase = Docs.FileCaseManager.GetFileCaseByID(filecaseId)

                    If fc IsNot Nothing AndAlso fc.fileCaseID <> String.Empty Then

                        isNew = Not DestinationManager.IsExistsFileByID(fileId)

                        DestinationManager.DeleteFileCase(filecaseId)

                        If Not isNew Then

                            SendMessageAll(fc, True)

                        End If

                        ''--------------------------FileParties
                        InsertFilePartiesTable(filecaseId)

                        ''----------------------FileCaseArea

                        Select Case InsertFileCaseAreaTable(fc.fileCaseAreaID, fc.fileCaseSubAreaID)

                            Case 1
                                TransferError &= vbCrLf & "مجتمع  و شعبه منتقل نشد"
                                fc.fileCaseAreaID = Guid.Empty.ToString
                                fc.fileCaseSubAreaID = Guid.Empty.ToString
                                fc.fileCaseBranchID = Guid.Empty.ToString
                            Case 2
                                TransferError &= vbCrLf & " شعبه منتقل نشد"
                                fc.fileCaseSubAreaID = Guid.Empty.ToString
                                fc.fileCaseBranchID = Guid.Empty.ToString

                        End Select

                        '----------------------FileCase
                        '1) بررسی کد سیستم در پرونده

                        If LockDocs.DestinationManager.IsExitsFileCaseNoInSystem(fc.fileCaseNumberInSystem) Then

                            TransferError &= vbCrLf & "شماره سیستمی پرونده تکراری می باشد. شماره منتقل نشد، در سرور دوباره وارد نمایید"

                            fc.fileCaseNumberInSystem = String.Empty

                        End If

                        LockDocs.DestinationManager.AddFileCase(fc)

                        '----------------------Files
                        Dim include As Boolean = DestinationManager.IsExitsFileByType(fc.fileCaseID, Docs.Enums.FileType.آلارم)

                        Dim list As Docs.FilesCollection = Docs.FileDocManager.GetFilesForTransfer(filecaseId, Not include)

                        If list IsNot Nothing Then

                            For Each Item As Docs.Files In list

                                If Item.FileType = Docs.Enums.FileType.پرونده_قفل_شده Then
                                    Item.FileLocker = Login.CurrentLogin.CurrentUser.UserID
                                Else

                                    Item.FileLocker = Guid.Empty.ToString()

                                End If
                                LockDocs.DestinationManager.CreateFile(Item)

                            Next

                        End If

                        '-----------------------FilesDocs
                        TransferFileDocsTable(filecaseId)

                        SendMessageAll(fc, False)

                        Return String.Empty


                    End If

                End If

                Return "خطا در انتقال پرونده"

            Catch ex As Exception

                Return "خطا در انتقال پرونده"

            End Try


        End Function

#Region "Local"

        Private Shared Sub TransferFileCaseAreaTable_Local()

            'toolsalahiyat
            If Not DestinationManager.GetFileCaseAreaRecordCount() = FileCaseArea.AreaManger.GetSalahiatRecordCount() Then

                Dim list As Competencys.CompetencyCollection = FileCaseArea.AreaManger.GetAllRecords()

                LockDocs.DestinationManager.EmptyFileCaseArea()

                If list IsNot Nothing Then

                    For Each Item As Competencys.Competency In list

                        DestinationManager.AddArea(Item)

                    Next

                End If

            End If

            'toolsalahiyatbranch
            If Not DestinationManager.GetFileCaseAreaRecordCount1() = FileCaseArea.AreaManger.GetRecordCount1() Then

                Dim list As Competencys.CompetencyBranchCollection = FileCaseArea.AreaManger.GetAllRecords1()

                LockDocs.DestinationManager.EmptyFileCaseArea1()

                If list IsNot Nothing Then

                    For Each Item As Competencys.CompetencyBranch In list

                        DestinationManager.AddArea1(Item)

                    Next

                End If

            End If

        End Sub

        Private Shared Sub TransferContactinfoTable_Local()

            If Not DestinationManager.GetContactInfoRecordCount() = ContactInfo.ContactInfoManager.GetRecordCount() Then

                Dim list As ContactInfo.ContactInfoCollection = ContactInfo.ContactInfoManager.GetAllRecords()

                LockDocs.DestinationManager.EmptyContactInfo()

                If list IsNot Nothing Then

                    For Each Item As ContactInfo.Contact In list

                        LockDocs.DestinationManager.AddContact(Item)

                    Next

                End If

            End If

        End Sub

        Private Shared Function TransferFileCase_Local(ByVal fileId As String) As String

            Try
                '1) تشکیل پرونده
                ''''DestinationManager.DeleteFilesById(fileId)

                Dim f As Docs.Files = Docs.FileDocManager.GetFileAllInfoByID(fileId)

                If f IsNot Nothing AndAlso f.fileID <> String.Empty Then

                    '2) انتقال پرونده
                    Dim filecaseId As String = Docs.FileDocManager.GetFileCaseID(fileId)

                    If filecaseId <> String.Empty Then

                        DestinationManager.DeleteFileCase(filecaseId)

                        f.FileLocker = Login.CurrentLogin.CurrentUser.UserID

                        DestinationManager.CreateFile(f)

                        '-FileParties
                        TransferFilePartiesTable_Local(filecaseId)

                        Dim fc As Docs.FileCase = Docs.FileCaseManager.GetFileCaseByID(filecaseId)

                        If fc IsNot Nothing AndAlso fc.fileCaseID <> String.Empty Then

                            '-FileCase
                            LockDocs.DestinationManager.AddFileCase(fc)

                            '-FilesDocs
                            TransferFileDocsTable(filecaseId)

                            Return String.Empty

                        End If

                    End If

                End If

                Return "خطا در ایجاد پرونده"

            Catch ex As Exception

                Return "خطا در ایجاد پرونده"

            End Try


        End Function

        Private Shared Function TransferFileCase_Local_new(ByVal parentId As String, ByVal fileId As String) As String

            If DestinationManager.IsExistsFileByID(fileId) Then
                'انتقال پرونده
                Return TransferFileCase(parentId, fileId, False)
            Else

                If DestinationManager.IsExistsFileByID(parentId) Then

                    'تشکیل مقادیر جدیدfiles
                    'انتقال پرونده
                    Return TransferFileCase(parentId, fileId, True)

                Else


                    Dim ppiD As String = Docs.FileDocManager.GetFileParentId(parentId)

                    If DestinationManager.IsExistsFileByID(ppiD) Then

                        If CreateSubjectFile_local(parentId) Then

                            Return TransferFileCase(parentId, fileId, True)

                        Else
                            Return "خطا در ایجاد موضوع"
                        End If
                       
                    Else

                        'ایجاد فایل
                        If CreateFile_local(ppiD) Then

                            If CreateSubjectFile_local(parentId) Then

                                Return TransferFileCase(parentId, fileId, True)

                            Else

                                Return "خطا در ایجاد موضوع"

                            End If

                        Else

                            Return "خطا در ایجاد فایل"

                        End If

                      
                    End If

                End If

            End If

        End Function

        Private Shared Function CreateFile_local(ByVal fileid As String) As Boolean

            Try
                ''?????? اگر قبلا برای شخص فایل تشکیل شده است

                Dim f As Docs.Files = Docs.FileDocManager.GetFileAllInfoByID(fileid)

                If f IsNot Nothing AndAlso f.fileID <> String.Empty Then

                    f.FileLocker = Guid.Empty.ToString()

                    DestinationManager.CreateFile(f)

                    '' ''If Not DestinationManager.GetContactInfoRecordCount() = ContactInfo.ContactInfoManager.GetRecordCount() Then

                    '' ''    Dim list As ContactInfo.ContactInfoCollection = ContactInfo.ContactInfoManager.GetAllRecords()

                    '' ''    LockDocs.DestinationManager.EmptyContactInfo()

                    '' ''    If list IsNot Nothing Then

                    '' ''        For Each Item As ContactInfo.Contact In list

                    '' ''            LockDocs.DestinationManager.AddContact(Item)

                    '' ''        Next

                    '' ''    End If

                    '' ''End If

                    Return True

                End If

                Return False


            Catch ex As Exception

                Return False

            End Try

        End Function

        Private Shared Function CreateSubjectFile_local(ByVal fileid As String) As Boolean

            Try
                ''''????? نام موضوع تکراری باشد
                Dim f As Docs.Files = Docs.FileDocManager.GetFileAllInfoByID(fileid)

                If f IsNot Nothing AndAlso f.fileID <> String.Empty Then

                    f.FileLocker = Guid.Empty.ToString()

                    DestinationManager.CreateFile(f)

                    Return True

                End If

                Return False

            Catch ex As Exception

                Return False

            End Try

        End Function

        Private Shared Sub TransferFilePartiesTable_Local(ByVal fcId As String)

            Dim list As FileParties.FilePartiesCollection = FileParties.FilePartiesManager.GetAllPartiesByFileCase(fcId)

            If list IsNot Nothing Then

                For Each Item As FileParties.FileParties In list

                    DestinationManager.AddParties(Item)

                Next

            End If

        End Sub

        Private Shared Sub TransferFileDocsTable(ByVal fileCaseId As String)

            Dim list As Docs.FileDocsCollection = Docs.FileDocManager.GetAllFileDocsByFileCaseID(fileCaseId)

            If list IsNot Nothing Then

                For Each Item As Docs.FileDocs In list

                    LockDocs.DestinationManager.AddFileDoc(Item)

                Next

            End If

        End Sub


#End Region

#Region "Server"

        Private Shared Sub SendMessageAll(ByVal fc As Docs.FileCase, ByVal isDelete As Boolean)

            Try

                Dim CurTiming As New Timing.Timing

                CurTiming.timeID = Guid.NewGuid.ToString()

                CurTiming.timeSourceCustID = Login.CurrentLogin.CurrentUser.UserID

                CurTiming.fileCaseID = fc.fileCaseID

                If isDelete Then

                    CurTiming.timeText = "پرونده به شماره سیستمی : " & fc.fileCaseNumberInSystem & " و شماره قضایی :  " & fc.fileCaseNumberInCourt & "/" & fc.fileCaseNumberInBranch & " با موضوع  " & fc.fileCaseSubject & " توسط " & Login.CurrentLogin.CurrentUser.Name & " حذف شد. "

                    CurTiming.timeTitle = "حذف پرونده"

                Else
                    CurTiming.timeText = "پرونده به شماره سیستمی : " & fc.fileCaseNumberInSystem & " و شماره قضایی :  " & fc.fileCaseNumberInCourt & "/" & fc.fileCaseNumberInBranch & " با موضوع  " & fc.fileCaseSubject & " توسط " & Login.CurrentLogin.CurrentUser.Name & " به سرور برگردانده شد. "

                    CurTiming.timeTitle = "انتقال پرونده"

                End If


                CurTiming.timeType = 6

                Dim TargetCusts As FileParties.FilePartiesBaseInfoCollection = FileParties.FilePartiesManager.GetPartiesByFileCaseOwnerUsers(CurTiming.fileCaseID)

                If DestinationManager.AddTiming(CurTiming) Then

                    'TimeParties
                    Dim timeParties As New TimeParties.TimeParties


                    timeParties.timeTime = DateTime.Now.Hour & ":" & DateTime.Now.Minute & ":" & DateTime.Now.Second


                    timeParties.timeDate = VB.Common.DateManager.GetCurrentShamsiDateInNumericFormat()
                    timeParties.timeDone = False
                    timeParties.timeID = CurTiming.timeID


                    For Each Item As FileParties.FilePartiesBaseInfo In TargetCusts

                        timeParties.tpID = Guid.NewGuid().ToString()
                        timeParties.tpTargetCustID = Item.contactInfoID
                        DestinationManager.AddParties(timeParties)

                    Next

                End If

            Catch ex As Exception

            End Try
            
        End Sub

        Private Shared Sub InsertFilePartiesTable(ByVal fcId As String)

            'گرفتن تمامی افرادی که در پرونده مشارکت دارند

            Dim result As String = String.Empty

            Dim list As FileParties.FilePartiesCollection = FileParties.FilePartiesManager.GetAllPartiesByFileCase(fcId)

            If list IsNot Nothing AndAlso list.Count > 0 Then

                For Each Item As FileParties.FileParties In list

                    Try

                        result = InsertContactinfoTable(Item.contactInfoID)

                        DestinationManager.AddParties(Item)

                        If result <> String.Empty Then TransferError &= vbCrLf & result


                    Catch ex As Exception

                        If result = String.Empty Then

                            TransferError &= vbCrLf & " خطا در ثبت " & CType(Item.fileCaseRole, FileParties.Enums.FileCaseRole).ToString()

                        End If

                    End Try

                Next

            End If

        End Sub

        Private Shared Function InsertContactinfoTable(ByVal custId As String) As String

            Dim c As ContactInfo.Contact = ContactInfo.ContactInfoManager.GetContactByID(custId)

            If c IsNot Nothing Then

                c.custIsSysUser = False

                c.custPassword = String.Empty

                c.custSaltkey = String.Empty

                c.custUserName = String.Empty

                '----مشخصات کاربری قابل انتقال نیست

                If Not DestinationManager.IsExistContactById(c.custID) Then

                    Try

                        DestinationManager.AddImage(BaseForm.ImageManager.GetImageByID(c.custID))

                        DestinationManager.AddContact(c)

                    Catch ex As Exception

                        Return " کاربر با نام  " & c.custFullName & " ثبت نشد ، لطفا در سروربه صورت دستی ثبت نمایید. "

                    End Try

                End If

            End If

            Return String.Empty

        End Function

        Private Shared Function InsertFileCaseAreaTable(ByVal fcAreaId As String, ByVal fcsubArea As String) As Short

            Dim result As Short = 3

            Try

                If fcAreaId <> String.Empty AndAlso fcAreaId <> Guid.Empty.ToString Then

                    Dim a As Competencys.Competency
                    Dim a1 As Competencys.CompetencyBranch

                    If Not DestinationManager.IsExitsFileCaseArea(fcAreaId) Then
                        result = 1
                        a = FileCaseArea.AreaManger.GetFileCaseAreaById(fcAreaId)
                        DestinationManager.AddArea(a)
                        result = 2
                        If fcsubArea = String.Empty OrElse fcsubArea = Guid.Empty.ToString Then Return 4
                        a1 = FileCaseArea.AreaManger.GetFileCaseAreaById2(fcsubArea)
                        DestinationManager.AddArea1(a1)
                        result = 3
                      
                    ElseIf fcsubArea <> String.Empty AndAlso fcsubArea <> Guid.Empty.ToString AndAlso Not DestinationManager.IsExitsFileCaseArea(fcsubArea) Then
                        result = 2
                        a1 = FileCaseArea.AreaManger.GetFileCaseAreaById2(fcsubArea)
                        DestinationManager.AddArea1(a1)
                        result = 3
                   
                    End If

                End If

                Return result

            Catch ex As Exception

                Return result

            End Try

        End Function

#End Region

    End Class

End Namespace

