Imports System.Web.UI.WebControls
Imports NwdSolutions.Web




Namespace HS.General


    Public Class Where


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
        Public WriteOnly Property Comparison() As String
            Set(ByVal value As String)
                _Comparison = value
            End Set
        End Property

#End Region



        Public Function WhereBuilder(ByVal Field As String, ByVal Obj As Object, ByVal default_Comparison As String) As String

            Dim General As New GeneralUtilities.General

            Try

                Dim Where As String = String.Empty
                Dim Compare As String = String.Empty

                Compare = IIf(_Comparison = "0", default_Comparison, _Comparison)


                If TypeOf (Obj) Is TextBox Then

                    If CType(Obj, TextBox).Text <> String.Empty Then

                        If Trim(Compare) = "=" Then
                            Where += _Logic + " " + Field + " = '" + General.DbReplace(CType(Obj, TextBox).Text) + "' "
                        ElseIf Trim(UCase(Compare)) = "LIKE" Then
                            Where += _Logic + " " + Field + " LIKE N'%" + General.DbReplace(CType(Obj, TextBox).Text) + "%' "
                        End If

                    End If

                ElseIf TypeOf (Obj) Is DropDownList Then

                    If CType(Obj, DropDownList).SelectedIndex <> 0 Then '= defaultIndex
                        Where += _Logic + " " + Field + "  =" + CType(Obj, DropDownList).SelectedValue + " "
                    End If

                End If


                Return Where



            Catch ex As Exception
                Throw New System.Exception("Error W", ex)
                Return "Error Where"
            End Try


        End Function

        Public Function WhereBuilder(ByVal Field As String, ByVal Obj As Object, ByVal default_Comparison As String, ByVal IsAccess As Boolean, Optional ByVal IsString As Boolean = False) As String


            Dim General As New GeneralUtilities.General


            Dim Where As String = String.Empty
            Dim Compare As String = String.Empty
            Try

                If IsAccess = True Then

                    Compare = IIf(_Comparison = "0", default_Comparison, _Comparison)

                    If TypeOf (Obj) Is TextBox Then

                        If CType(Obj, TextBox).Text <> String.Empty Then


                            If Trim(Compare) = "=" Then

                                Where += _Logic + " " + Field + " = '" + General.DbReplace(CType(Obj, TextBox).Text) + "' "

                            ElseIf Trim(UCase(Compare)) = "LIKE" Then

                                Where += _Logic + " " + Field + " LIKE '%" + General.DbReplace(CType(Obj, TextBox).Text) + "%' "

                            End If


                        End If


                    ElseIf TypeOf (Obj) Is DropDownList Then

                        If CType(Obj, DropDownList).SelectedIndex <> 0 Then '= defaultIndex


                            If IsString Then
                                Where += _Logic + " " + Field + "  = '" + CType(Obj, DropDownList).SelectedValue + "' "
                            Else
                                Where += _Logic + " " + Field + "  = " + CType(Obj, DropDownList).SelectedValue + " "
                            End If


                        End If

                    ElseIf TypeOf (Obj) Is CheckBox Then

                        If CType(Obj, CheckBox).Checked Then

                            Where += _Logic + " " + Field + "  =1 "
                        Else
                            Where += _Logic + " " + Field + "  =0 "
                        End If


                    End If

                    Return Where
                Else

                    Return Nothing
                End If

            Catch ex As Exception

                Throw New System.Exception("Error W", ex)

                Return "Error Where"

            End Try




        End Function

        Public Function WhereBuilder(ByVal Field As String, ByVal AZ As String, ByVal TA As String) As String


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


                Return Where


            Catch ex As Exception
                Throw New System.Exception("Error W", ex)
                Return "Error Where"
            End Try


        End Function


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Shared

        Public Shared Function WhereBuilder_Google(ByVal columns As ArrayList, ByVal str As String) As String

            Dim Where As String = String.Empty

            Try

                Dim charSeparators() As Char = {" "}
                Dim Words() As String = str.Split(charSeparators, System.StringSplitOptions.RemoveEmptyEntries)



                For i As Integer = 0 To Words.Length - 1

                    For j As Integer = 0 To columns.Count - 1

                        If j = 0 Then
                            Where += "("
                        End If

                        Where += columns(j) + " LIKE N'%" + Words(i) + "%'"

                        If j <> columns.Count - 1 Then
                            Where += " OR "
                        Else
                            Where += ")"
                        End If
                    Next

                    If i <> Words.Length - 1 Then
                        Where += " AND "
                    End If

                Next


                Return Where


            Catch ex As Exception
                Return Nothing
                Throw New System.Exception("Error W_Google", ex)
            End Try


        End Function






    End Class


End Namespace