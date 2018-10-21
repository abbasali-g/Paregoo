Imports System.Web.UI.WebControls

Imports System
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography

Namespace HS.General

    Public Class Builder
        Inherits General.GeneralString

#Region "-- Property --"




        Private _Logic As String
        Public Property Logic() As String
            Get
                Return _Logic
            End Get
            Set(ByVal value As String)
                _Logic = value
            End Set
        End Property

        Private _Comparison As String
        Public Property Comparison() As String
            Get
                Return _Comparison
            End Get
            Set(ByVal value As String)
                _Comparison = value
            End Set
        End Property


        Private _Where As String
        Public ReadOnly Property Where() As String

            Get

                If Trim(_Where) <> String.Empty Then
                    _Where = IIf(Trim(_Where).StartsWith("AND"), Trim(_Where).Remove(0, 3), _Where)
                    _Where = IIf(Trim(_Where).StartsWith("OR"), Trim(_Where).Remove(0, 2), _Where)
                    _Where = " where " + _Where
                End If

                Return _Where

            End Get

        End Property

#End Region



        Public Sub WhereBuilder(ByVal Field As String, ByVal Obj As Object, ByVal default_Comparison As String)


            Try

                Dim Where As String = String.Empty
                Dim Compare As String = String.Empty

                Compare = IIf(_Comparison = "0", default_Comparison, _Comparison)


                If TypeOf (Obj) Is TextBox Then

                    If CType(Obj, TextBox).Text <> String.Empty Then

                        If Trim(Compare) = "=" Then
                            Where += _Logic + " " + Field + " = '" + DbReplace(CType(Obj, TextBox).Text) + "' "
                        ElseIf Trim(UCase(Compare)) = "LIKE" Then
                            Where += _Logic + " " + Field + " LIKE N'%" + DbReplace(CType(Obj, TextBox).Text) + "%' "
                        End If

                    End If

                ElseIf TypeOf (Obj) Is DropDownList Then

                    If CType(Obj, DropDownList).SelectedIndex <> 0 Then '= defaultIndex
                        Where += _Logic + " " + Field + "  =" + CType(Obj, DropDownList).SelectedValue + " "
                    End If

                End If


                'Return Where
                _Where += Where


            Catch ex As Exception
                Throw New System.Exception("Error W", ex)
                'Return "Error Where"
            End Try


        End Sub

        Public Sub WhereBuilder(ByVal Field As String, ByVal AZ As String, ByVal TA As String)


            Try

                Dim Where As String = String.Empty
                'Dim Compare As String = String.Empty

                'Compare = IIf(mComparison = "0", default_Comparison, mComparison)


                If AZ <> String.Empty And TA <> String.Empty Then

                    Where += _Logic + "  " + Field + " >='" + AZ + "' And " + Field + " <='" + TA + "' "

                ElseIf AZ <> String.Empty And TA = String.Empty Then

                    Where += _Logic + "  " + Field + " >='" + AZ + "'"

                ElseIf AZ = String.Empty And TA <> String.Empty Then

                    Where += _Logic + "  " + Field + " <='" + TA + "'"

                End If


                'Return Where
                _Where += Where

            Catch ex As Exception
                Throw New System.Exception("Error W", ex)
                'Return "Error Where"
            End Try


        End Sub



        Public Sub AddToWhere(ByVal Str As String)

            Dim Where As String = String.Empty

            Where = _Logic + " " + Str + " "

            _Where += Where

        End Sub



    End Class


End Namespace


