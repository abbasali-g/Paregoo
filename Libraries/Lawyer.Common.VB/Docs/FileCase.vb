Namespace Docs
    Public Class FileCase
        Private _fileCaseComplainant As Boolean
        Private _fileCaseCat As Int16
        Private _fileCaseType As Boolean
        Private _fileCaseSubject As String
        Private _fileCaseDescription As String
        Private _fileCaseNumberInSystem As String
        Private _fileCaseNumberInCourt As String
        Private _fileCaseOpenDate As Int32
        Private _fileCaseCloseDate As Int32?
        Private _fileCaseStep As Int16
        Private _fileID As String
        Private _fileCaseAreaID As String
        Private _fileCaseSubAreaID As String
        Private _fileCaseBranchID As String
        Private _fileCaseRelatedID As String
        Private _fileCaseID As String
        Private _fileCaseLastAction As String
        Private _fileCaseOtherDescription As String
        Private _fileCaseResult As String
        Private _filecaseResultDetail As String
        Private _fileCaseGhararType As String
        Private _fileCaseCost As Double?
        Private _fileCaseNumberInBranch As String
        Private _fileCaseNumberYear As String
        Private _fileCasePass As String
        Private _decryptedFileCasePass As String



        Public Property fileCasePass() As String
            Get
                Return _fileCasePass
            End Get
            Set(ByVal value As String)
                _fileCasePass = value
            End Set
        End Property

        Public Property fileCaseNumberInBranch() As String
            Get
                Return _fileCaseNumberInBranch
            End Get
            Set(ByVal value As String)
                _fileCaseNumberInBranch = value
            End Set
        End Property

        Public Property fileCaseNumberYear() As String
            Get
                Return _fileCaseNumberYear
            End Get
            Set(ByVal value As String)
                _fileCaseNumberYear = value
            End Set
        End Property


        Public Property fileCaseResult() As String
            Get
                Return _fileCaseResult
            End Get
            Set(ByVal value As String)
                _fileCaseResult = value
            End Set
        End Property

        Public Property fileCaseCost() As Double?
            Get
                Return _fileCaseCost
            End Get
            Set(ByVal value As Double?)
                _fileCaseCost = value
            End Set
        End Property
        Public Property filecaseResultDetail() As String
            Get
                Return _filecaseResultDetail
            End Get
            Set(ByVal value As String)
                _filecaseResultDetail = value
            End Set
        End Property


        Public Property fileCaseComplainant() As Boolean
            Get
                Return _fileCaseComplainant
            End Get
            Set(ByVal value As Boolean)
                _fileCaseComplainant = value
            End Set
        End Property

       
        Public Property fileCaseCat() As Int16
            Get
                Return _fileCaseCat
            End Get
            Set(ByVal value As Int16)
                _fileCaseCat = value
            End Set
        End Property

       

        Public Property fileCaseType() As Boolean
            Get
                Return _fileCaseType
            End Get
            Set(ByVal value As Boolean)
                _fileCaseType = value
            End Set
        End Property

      

        Public Property fileCaseLastAction() As String
            Get
                Return _fileCaseLastAction
            End Get
            Set(ByVal value As String)
                _fileCaseLastAction = value
            End Set
        End Property


        Public Property fileCaseGhararType() As String
            Get
                Return _fileCaseGhararType
            End Get
            Set(ByVal value As String)
                _fileCaseGhararType = value
            End Set
        End Property


        Public Property fileCaseOtherDescription() As String
            Get
                Return _fileCaseOtherDescription
            End Get
            Set(ByVal value As String)
                _fileCaseOtherDescription = value
            End Set
        End Property

        Public Property fileCaseSubject() As String
            Get
                Return _fileCaseSubject
            End Get
            Set(ByVal value As String)
                _fileCaseSubject = value
            End Set
        End Property

        Public Property fileCaseDescription() As String
            Get
                Return _fileCaseDescription
            End Get
            Set(ByVal value As String)
                _fileCaseDescription = value
            End Set
        End Property


        Public Property fileCaseNumberInSystem() As String
            Get
                Return _fileCaseNumberInSystem
            End Get
            Set(ByVal value As String)
                _fileCaseNumberInSystem = value
            End Set
        End Property


        Public Property fileCaseNumberInCourt() As String
            Get
                Return _fileCaseNumberInCourt
            End Get
            Set(ByVal value As String)
                _fileCaseNumberInCourt = value
            End Set
        End Property


        Public Property fileCaseOpenDate() As Int32
            Get
                Return _fileCaseOpenDate
            End Get
            Set(ByVal value As Int32)
                _fileCaseOpenDate = value
            End Set
        End Property


        Public Property fileCaseCloseDate() As Int32?
            Get
                Return _fileCaseCloseDate
            End Get
            Set(ByVal value As Int32?)
                _fileCaseCloseDate = value
            End Set
        End Property


        Public Property fileCaseStep() As Int16
            Get
                Return _fileCaseStep
            End Get
            Set(ByVal value As Int16)
                _fileCaseStep = value
            End Set
        End Property


        Public Property fileID() As String
            Get
                Return _fileID
            End Get
            Set(ByVal value As String)
                _fileID = value
            End Set
        End Property


        Public Property fileCaseAreaID() As String
            Get
                Return _fileCaseAreaID
            End Get
            Set(ByVal value As String)
                _fileCaseAreaID = value
            End Set
        End Property


        Public Property fileCaseSubAreaID() As String
            Get
                Return _fileCaseSubAreaID
            End Get
            Set(ByVal value As String)
                _fileCaseSubAreaID = value
            End Set
        End Property


        Public Property fileCaseBranchID() As String
            Get
                Return _fileCaseBranchID
            End Get
            Set(ByVal value As String)
                _fileCaseBranchID = value
            End Set
        End Property


        Public Property fileCaseRelatedID() As String
            Get
                Return _fileCaseRelatedID
            End Get
            Set(ByVal value As String)
                _fileCaseRelatedID = value
            End Set
        End Property


        Public Property fileCaseID() As String
            Get
                Return _fileCaseID
            End Get
            Set(ByVal value As String)
                _fileCaseID = value
            End Set
        End Property


#Region "Text"

        Public ReadOnly Property fileCaseStepText() As String
            Get
                If _fileCaseStep = -1 Then

                    Return ""
                Else

                    Return FileCaseManager.GetFileCaseStepTextByValue(_fileCaseStep.ToString()).settingName

                End If
                Return _fileCaseStep
            End Get
        End Property

        Public ReadOnly Property fileCaseAreaText() As String
            Get
                Try
                    Dim Area As String = String.Empty

                    If _fileCaseAreaID <> String.Empty Then

                        Dim co As Competencys.Competency = Competencys.CompetencyManager.GetCompetencyByLibID(_fileCaseAreaID)

                        If co IsNot Nothing Then

                            Area = co.tsState

                            If co.tsProvince <> String.Empty Then

                                Area &= " - " & co.tsProvince

                            End If

                            If co.tsName <> String.Empty Then

                                Area &= " - " & " حوزه : " & co.tsName

                            End If

                            If _fileCaseBranchID <> String.Empty Then

                                Dim br As Competencys.CompetencyBranchReview = Competencys.CompetencyManager.GetToolsSalahiatBranchById(_fileCaseBranchID)

                                If br IsNot Nothing Then

                                    If br.tsbName <> String.Empty Then

                                        Area &= " - " & CType(br.tsbType, Competencys.Enums.tsbType).ToString() & " : " & br.tsbName

                                    End If


                                End If

                            End If

                        End If

                    End If


                    Return Area

                Catch ex As Exception

                    Return String.Empty

                End Try

                Return _fileCaseSubAreaID
            End Get

        End Property

        Public Property DecryptedFileCasePass() As String
            Get
                Return _decryptedFileCasePass
            End Get

            Set(ByVal value As String)
                _decryptedFileCasePass = value
            End Set

        End Property

        Public ReadOnly Property StatusText() As String
            Get


                If _fileCaseCloseDate.HasValue Then
                    Return "مختومه"
                Else
                    Return "جاری"
                End If

            End Get

        End Property

        Public ReadOnly Property fileCaseCatText() As String
            Get
                If _fileCaseCat = 0 Then
                    Return "عادی"
                ElseIf _fileCaseCat = 1 Then
                    Return "تسخیری"
                Else
                    Return "معاضدتی"
                End If

            End Get

        End Property

        Public ReadOnly Property fileCaseTypeText() As String
            Get
                If _fileCaseType Then
                    Return "حقیقی"
                Else
                    Return "حقوقی"
                End If
            End Get

        End Property

        Public ReadOnly Property fileCaseComplainantText() As String
            Get
                If _fileCaseComplainant Then
                    Return "دفاع از خوانده"
                Else
                    Return "دفاع از خواهان"
                End If
            End Get

        End Property

        Public ReadOnly Property filecaseResultDetailText() As String
            Get
                ' ''If _filecaseResultDetail.HasValue Then

                ' ''    If _filecaseResultDetail = 0 Then

                ' ''        Return "له"

                ' ''    Else

                ' ''        Return "علیه"

                ' ''    End If
                ' ''Else

                ' ''    Return ""

                ' ''End If
                Return _filecaseResultDetail

            End Get

        End Property

        Public ReadOnly Property fileCaseCloseDateText() As String
            Get
                If _fileCaseCloseDate.HasValue Then

                    Return String.Format("{0}/{1}/{2}", _fileCaseCloseDate.ToString().Substring(0, 4), _fileCaseCloseDate.ToString().Substring(4, 2), _fileCaseCloseDate.ToString().Substring(6, 2))

                Else
                    Return String.Empty

                End If
            End Get

        End Property
#End Region
    End Class


End Namespace

