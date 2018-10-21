Imports Lawyer.Common.VB.Laws

Namespace LawInfos



    Public Class LawInfo
        Private _lawPassedDate As Int32
        Private _lawPublishedDate As Int32
        Private _lawPublicationNumber As String
        Private _lawNote As String
        Private _lawMansoukh As Int16
        Private _lawMansoukhDescription As String
        Private _lawTypeName As String
        Private _lawCatName As String


        Public Property lawPassedDate() As Int32
            Get
                Return _lawPassedDate
            End Get
            Set(ByVal value As Int32)
                _lawPassedDate = value
            End Set
        End Property


        Public Property lawPublishedDate() As Int32
            Get
                Return _lawPublishedDate
            End Get
            Set(ByVal value As Int32)
                _lawPublishedDate = value
            End Set
        End Property


        Public Property lawPublicationNumber() As String
            Get
                Return _lawPublicationNumber
            End Get
            Set(ByVal value As String)
                _lawPublicationNumber = value
            End Set
        End Property


        Public Property lawNote() As String
            Get
                Return _lawNote
            End Get
            Set(ByVal value As String)
                _lawNote = value
            End Set
        End Property


        Public Property lawMansoukh() As Int16
            Get
                Return _lawMansoukh
            End Get
            Set(ByVal value As Int16)
                _lawMansoukh = value
            End Set
        End Property


        Public Property lawMansoukhDescription() As String
            Get
                Return _lawMansoukhDescription
            End Get
            Set(ByVal value As String)
                _lawMansoukhDescription = value
            End Set
        End Property


        Public Property lawTypeName() As String
            Get
                Return _lawTypeName
            End Get
            Set(ByVal value As String)
                _lawTypeName = value
            End Set
        End Property


        Public Property lawCatName() As String
            Get
                Return _lawCatName
            End Get
            Set(ByVal value As String)
                _lawCatName = value
            End Set
        End Property




        Private _lawMansoukh_Type As String
        Public ReadOnly Property lawMansoukh_Type() As String
            Get

                Select Case _lawMansoukh
                    Case Enums.lawMansoukh_Type.جزئی
                        _lawMansoukh_Type = Enums.lawMansoukh_Type.جزئی.ToString()
                    Case Enums.lawMansoukh_Type.کلی
                        _lawMansoukh_Type = Enums.lawMansoukh_Type.کلی.ToString
                    Case Enums.lawMansoukh_Type.هیچیک
                        _lawMansoukh_Type = Enums.lawMansoukh_Type.هیچیک.ToString
                    Case Else
                        _lawMansoukh_Type = Enums.lawMansoukh_Type.هیچیک.ToString
                End Select

                Return _lawMansoukh_Type
            End Get

        End Property


    End Class



End Namespace
