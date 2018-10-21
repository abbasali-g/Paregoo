Imports System.Windows.Forms
Imports Lawyer.Common.VB.BloodMoneys

Namespace BloodMoneys

    Public Class BmTreeNode : Inherits TreeNode


#Region " Property "

        Private _BloodMoney As BloodMoney
        Public Property BloodMoney() As BloodMoney
            Get
                Return _BloodMoney
            End Get
            Set(ByVal value As BloodMoney)
                _BloodMoney = value
            End Set
        End Property

#End Region

#Region " New "

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal BloodMoney As BloodMoney)
            MyBase.New()
            _BloodMoney = BloodMoney
            ' Me.Text = ""
        End Sub


#End Region


    End Class


End Namespace
