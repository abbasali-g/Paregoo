Namespace Guilts

    Public Class Guilt


        Private _tgID As Int32
        Private _tgTitle As String
        Private _tgRuleDef As String
        Private _tgPenalty As String
        Private _tgRelatedRules As String
        Private _tgRuleTile As String
        Private _tgRulePassedDate As String
        Private _tgDescription As String


        Public Property tgID() As Int32
            Get
                Return _tgID
            End Get
            Set(ByVal value As Int32)
                _tgID = value
            End Set
        End Property


        Public Property tgTitle() As String
            Get
                Return _tgTitle
            End Get
            Set(ByVal value As String)
                _tgTitle = value
            End Set
        End Property


        Public Property tgRuleDef() As String
            Get
                Return _tgRuleDef
            End Get
            Set(ByVal value As String)
                _tgRuleDef = value
            End Set
        End Property


        Public Property tgPenalty() As String
            Get
                Return _tgPenalty
            End Get
            Set(ByVal value As String)
                _tgPenalty = value
            End Set
        End Property


        Public Property tgRelatedRules() As String
            Get
                Return _tgRelatedRules
            End Get
            Set(ByVal value As String)
                _tgRelatedRules = value
            End Set
        End Property


        Public Property tgRuleTile() As String
            Get
                Return _tgRuleTile
            End Get
            Set(ByVal value As String)
                _tgRuleTile = value
            End Set
        End Property


        Public Property tgRulePassedDate() As String
            Get
                Return _tgRulePassedDate
            End Get
            Set(ByVal value As String)
                _tgRulePassedDate = value
            End Set
        End Property


        Public Property tgDescription() As String
            Get
                Return _tgDescription
            End Get
            Set(ByVal value As String)
                _tgDescription = value
            End Set
        End Property







    End Class

End Namespace
