Option Strict On

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls


Public Class General

#Region "JavaScripts"

    Public Shared Function SetOpacity(ByVal ControlName As String, ByVal Opacity As Integer) As String

        Dim Str As String = ""

        Str = "javascript:document.all['" + ControlName + "'].style.filter = 'alpha(opacity=" + Opacity.ToString + ")'"

        Return Str

    End Function

    Public Shared Function SetOpacity(ByVal ControlName As String, ByVal Opacity As Integer, ByVal Style As Integer, ByVal FinishOpacity As Integer) As String

        Dim Str As String = ""

        Str = "javascript:document.all['" & ControlName & "'].style.filter = 'alpha(opacity=" & Convert.ToString(Opacity) & ",style=" & Style & ",finishopacity=" & FinishOpacity & ")'"

        Return Str

    End Function

    Public Shared Function SetOpacity(ByVal Opacity As Integer, ByVal Style As Integer, ByVal FinishOpacity As Integer) As String

        Dim Str As String = ""

        Str = "javascript:this.style.filter = 'alpha(opacity=" + Opacity.ToString + ",style=" + Style.ToString + ",finishopacity=" + FinishOpacity.ToString + ")'"

        Return Str

    End Function

    Public Shared Function PopupWindowNew(ByVal Url As String, Optional ByVal Height As String = "500", Optional ByVal Width As String = "800", Optional ByVal Modal As Boolean = False, Optional ByVal Target As Enumerators.WinTarget = Enumerators.WinTarget.Blank) As String

        Dim Script As String

        If Modal = True Then
            Script = " <script language=""javascript""> window.showModalDialog("""
            Script = Script + "" + Url
            Script = Script + ""","""",""scrollbars:yes;menubar:no;dialogHeight:" + Height + "px;dialogWidth:" + Width + "px;dialogLeft:0px;dialogtop:250px;edge:Raised;enter:Yes;fullscreen:no;help:No;resizable:No;status:No;"")   </script>"
        Else
            Script = " <script language=""javascript""> window.open("""
            Script = Script + "" + Url
            Script = Script + """,""" & CStr(IIf(Target = Enumerators.WinTarget.Blank, "_blank", "_self")) & """,""scrollbars=yes,menubar=no ,height=" + Height + ",width=" + Width + ",left=0,top=80,resizable=Yes,statusbar=no,fullscreen=no"") ;    </script>"
        End If

        Return Script

    End Function

    Public Shared Function PopupWindowWithoutScript(ByVal Url As String, Optional ByVal Height As String = "500", Optional ByVal Width As String = "800", Optional ByVal Modal As Boolean = False, Optional ByVal Target As Enumerators.WinTarget = Enumerators.WinTarget.Self) As String

        Dim Script As String

        If Modal = True Then
            Script = " window.showModalDialog("""
            Script = Script + "" + Url
            Script = Script + ""","""",""scrollbars:yes;menubar:no;dialogHeight:" + Height + "px;dialogWidth:" + Width + "px;dialogLeft:0px;dialogtop:250px;edge:Raised;enter:Yes;fullscreen:no;help:No;resizable:No;status:No;"") "
        Else
            Script = "  window.open("""
            Script = Script + "" + Url
            Script = Script + """,""" & CStr(IIf(Target = Enumerators.WinTarget.Blank, "_blank", "_self")) & """,""scrollbars=yes,menubar=no ,height=" + Height + ",width=" + Width + ",left=0,top=80,resizable=Yes,statusbar=no,fullscreen=no"") ; "
        End If

        Return Script

    End Function

    Public Shared Function CloseWindow() As String

        Return "<script language=""javascript"">window.opener='';self.close();</script>"

    End Function

    Public Shared Function Redirect(ByVal PageURL As String, Optional ByVal TargetFrame As String = "Contents") As String

        Return "<script language='javascript'>top.frames[" + """" + TargetFrame + """" + "].location=" + """" + PageURL + """" + ";</script>"

    End Function

    Public Shared Function PopupWindow(ByVal Url As String, Optional ByVal Height As String = "500", Optional ByVal Width As String = "800", Optional ByVal Modal As Boolean = False, Optional ByVal Target As Enumerators.WinTarget = Enumerators.WinTarget.Self) As String

        Dim Script As String

        If Modal = True Then
            Script = " window.showModalDialog("""
            Script = Script + "" + Url
            Script = Script + ""","""",""scrollbars:yes;menubar:no;dialogHeight:" + Height + "px;dialogWidth:" + Width + "px;dialogLeft:0px;dialogtop:250px;edge:Raised;enter:Yes;fullscreen:no;help:No;resizable:No;status:No;"") "
        Else
            Script = "  window.open("""
            Script = Script + "" + Url
            Script = Script + """,""" & CStr(IIf(Target = Enumerators.WinTarget.Blank, "_blank", "_self")) & """,""scrollbars=yes,menubar=no ,height=" + Height + ",width=" + Width + ",left=0,top=80,resizable=Yes,statusbar=no,fullscreen=no"") ; "
        End If

        Return Script

    End Function

    Public Shared Function Message(ByVal MessageText As String) As String

        Dim MessageScript As String

        MessageScript = "<SCRIPT LANGUAGE=""JavaScript"">"
        MessageScript = MessageScript + "  alert("" " + MessageText + " "") "
        MessageScript = MessageScript + "  </script>"

        Return MessageScript

    End Function

#End Region

#Region "FileReading"

    Public Shared Function GetByteArrayFromFileField( _
        ByVal FileField As System.Web.UI.WebControls.FileUpload) _
        As Byte()
        ' Returns a byte array from the passed 
        ' file field controls file
        Dim intFileLength As Integer, bytData() As Byte
        Dim objStream As System.IO.Stream

        If FileFieldSelected(FileField) Then
            intFileLength = FileField.PostedFile.ContentLength
            ReDim bytData(intFileLength)
            objStream = FileField.PostedFile.InputStream
            objStream.Read(bytData, 0, intFileLength)

            Return bytData

        End If

        Return Nothing

    End Function

    Public Shared Function FileFieldSelected(ByVal FileField As _
        System.Web.UI.WebControls.FileUpload) As Boolean
        ' Returns a True if the passed
        ' FileField has had a user post a file
        If FileField.PostedFile Is Nothing Then Return False
        If FileField.PostedFile.ContentLength = 0 Then Return False

        Return True

    End Function

    Public Shared Function FileFieldSelected(ByVal FileField As _
   System.Web.UI.HtmlControls.HtmlInputFile) As Boolean

        ' Returns a True if the passed
        ' FileField has had a user post a file
        If FileField.PostedFile Is Nothing Then Return False
        If FileField.PostedFile.ContentLength = 0 Then Return False

        Return True

    End Function

    Public Shared Function GetByteArrayFromFileField( _
     ByVal FileField As System.Web.UI.HtmlControls.HtmlInputFile) _
     As Byte()

        ' Returns a byte array from the passed 
        ' file field controls file
        Dim intFileLength As Integer, bytData() As Byte
        Dim objStream As System.IO.Stream

        If FileFieldSelected(FileField) Then
            intFileLength = FileField.PostedFile.ContentLength
            ReDim bytData(intFileLength)
            objStream = FileField.PostedFile.InputStream
            objStream.Read(bytData, 0, intFileLength)
            Return bytData

        End If

        Return Nothing

    End Function

    Public Shared Function FileFieldType(ByVal FileField As _
      System.Web.UI.HtmlControls.HtmlInputFile) As String
        ' Returns the type of the posted file
        If Not FileField.PostedFile Is Nothing Then
            Return FileField.PostedFile.ContentType
        End If

        Return String.Empty

    End Function

    Public Shared Function FileFieldLength(ByVal FileField As _
      System.Web.UI.HtmlControls.HtmlInputFile) As Integer
        ' Returns the length of the posted file
        If Not FileField.PostedFile Is Nothing Then _
          Return FileField.PostedFile.ContentLength

    End Function

    Public Shared Function FileFieldLength(ByVal FileField As _
        System.Web.UI.WebControls.FileUpload) As Integer

        ' Returns the length of the posted file
        If Not FileField.PostedFile Is Nothing Then _
          Return FileField.PostedFile.ContentLength

    End Function

    Public Shared Function FileFieldFilename(ByVal FileField As _
      System.Web.UI.HtmlControls.HtmlInputFile, Optional ByVal AddUniqeNameToRealName As Boolean = True) As String
        ' Returns the core filename of the posted file
        If Not FileField.PostedFile Is Nothing Then _
        Return CStr(IIf(AddUniqeNameToRealName = True, CStr(DateTime.Now.ToFileTime()), "")) + Replace(Replace(FileField.PostedFile.FileName, _
              StrReverse(Mid(StrReverse(FileField.PostedFile.FileName), _
              InStr(1, StrReverse(FileField.PostedFile.FileName), "\"))), ""), " ", "")


    End Function

    Public Shared Function FileFieldFilename(ByVal FileField As _
            System.Web.UI.WebControls.FileUpload) As String
        ' Returns the core filename of the posted file
        If Not FileField.PostedFile Is Nothing Then _
        Return Replace(FileField.PostedFile.FileName, _
              StrReverse(Mid(StrReverse(FileField.PostedFile.FileName), _
              InStr(1, StrReverse(FileField.PostedFile.FileName), "\"))), "")

    End Function

    Public Shared Sub DeliverFilePage(ByRef page As System.Web.UI.Page, _
           ByVal Data() As Byte, ByVal Type As String, _
           ByVal Length As Integer, _
           ByVal serverpath As String, Optional ByVal DownloadFileName As String = "")
        ' Delivers a file, such as an image or PDF file,
        ' back through the Response object
        ' Sample usage from within an ASP.NET page:
        ' - DeliverFile(Me, bytFile(), strType, intLength, "MyImage.bmp")

        With page.Response
            .Clear()
            .ContentType = Type
            If DownloadFileName <> "" Then
                page.Response.AddHeader("content-disposition", _
                  "filename=" & serverpath + "\TempPics\" + DownloadFileName)
            End If
            .OutputStream.Write(Data, 0, Length)
            .BinaryWrite(Data)
            .End()
        End With

    End Sub

#End Region

#Region "Reset Elements"

    ''' <summary>
    ''' 
    ''' Reset TextBoxs values
    ''' </summary>
    ''' <param name="Obj"></param>
    ''' <remarks></remarks>
    Public Shared Sub ClearTxt(ByRef Obj As Object)

        For Each ctl As Control In CType(Obj, WebControl).Controls

            If TypeOf (ctl) Is TextBox Then

                CType(ctl, TextBox).Text = String.Empty

            ElseIf Not (ctl.Controls Is Nothing) Then

                If ctl.Controls.Count > 0 Then
                    ClearTxt(CType(ctl, WebControl))
                End If

            End If

        Next

    End Sub

    ''' <summary>
    ''' Reset TextBox as DropdownLiast Values
    ''' </summary>
    ''' <param name="Obj"></param>
    ''' <param name="defaultIndex"></param>
    ''' <remarks></remarks>
    Public Shared Sub ResetElements(ByVal Obj As Object, Optional ByVal defaultIndex As Integer = 0)

        For Each ctl As Control In CType(Obj, Control).Controls

            If TypeOf (ctl) Is TextBox Then

                CType(ctl, TextBox).Text = String.Empty

            ElseIf TypeOf (ctl) Is DropDownList Then

                Try

                    CType(ctl, DropDownList).SelectedIndex = defaultIndex

                Catch ex As Exception
                End Try

            ElseIf Not (ctl.Controls Is Nothing) Then

                If ctl.Controls.Count > 0 Then
                    ResetElements(ctl, defaultIndex)
                End If

            End If

        Next

    End Sub

    Public Shared Sub RefreshDropDown(ByRef obj As Object)

        For Each ctl As Control In CType(obj, WebControl).Controls

            If TypeOf (ctl) Is DropDownList Then

                Try

                    CType(ctl, DropDownList).SelectedIndex = 0

                Catch ex As Exception
                End Try

            ElseIf Not (ctl.Controls Is Nothing) Then

                If ctl.Controls.Count > 0 Then
                    RefreshDropDown(CType(ctl, WebControl))
                End If

            End If

        Next

    End Sub

#End Region

#Region "Check Null Fields"

    Public Shared Function DBNull(ByVal DataRow As Data.DataRow, ByVal FieldName As String) As String
        Try
            If IsDBNull(DataRow.Item(FieldName)) Then
                Return ""
            Else
                Return CStr(DataRow.Item(FieldName))
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function DBNull(ByVal Field As Object, Optional ByVal NullOut As String = "") As String

        Try

            If IsDBNull(Field) Then
                Return NullOut
            Else
                Return Field.ToString
            End If

        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Shared Function DBNullField(ByVal Field As Object, Optional ByVal NullOut As String = "") As String

        Return DBNull(Field, NullOut)

    End Function

#End Region

#Region "DataTable Funtions..."

    Public Shared Function Ranking(ByVal TableToRank As System.Data.DataTable) As Data.DataTable

        If TableToRank.Columns.Contains("Rank") = False Then TableToRank.Columns.Add("Rank")

        For i As Integer = 0 To TableToRank.Rows.Count - 1
            TableToRank.Rows(i).Item("Rank") = (i + 1).ToString
        Next

        Return TableToRank

    End Function

#End Region

#Region "Fill Objects..."

    Public Overloads Shared Sub FillDropDown(ByVal DropDownObj As System.Web.UI.WebControls.DropDownList, _
    ByVal DataTextField As String, ByVal DataValueField As String, ByVal DataSource As IList)

        DropDownObj.DataTextField = DataTextField
        DropDownObj.DataValueField = DataValueField
        DropDownObj.DataSource = DataSource
        DropDownObj.DataBind()

    End Sub

    Public Overloads Shared Sub FillDropDown(ByVal DropDownObj As System.Web.UI.WebControls.DropDownList, ByVal DataTextField As String, ByVal DataValueField As String, ByVal DataSource As ICollection)

        DropDownObj.DataTextField = DataTextField
        DropDownObj.DataValueField = DataValueField
        DropDownObj.DataSource = DataSource
        DropDownObj.DataBind()

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="DropDownObj"></param>
    ''' <param name="DataTextField"></param>
    ''' <param name="DataValueField"></param>
    ''' <param name="DataSource">DataTable And DataSet Implements IListSource Interface</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub FillDropDown(ByVal DropDownObj As System.Web.UI.WebControls.DropDownList, ByVal DataTextField As String, ByVal DataValueField As String, ByVal DataSource As ComponentModel.IListSource)

        DropDownObj.DataTextField = DataTextField
        DropDownObj.DataValueField = DataValueField
        DropDownObj.DataSource = DataSource
        DropDownObj.DataBind()

    End Sub

    Public Overloads Shared Sub FillDropDown(ByVal DropDownObj As System.Web.UI.WebControls.DropDownList, ByVal DataTextField As String, ByVal DataValueField As String, ByVal DataSource As Object)

        DropDownObj.DataTextField = DataTextField
        DropDownObj.DataValueField = DataValueField
        DropDownObj.DataSource = DataSource
        DropDownObj.DataBind()

    End Sub

    Public Overloads Shared Sub FillCheckBoxList(ByVal CheckBoxList As System.Web.UI.WebControls.CheckBoxList, ByVal DataTextField As String, ByVal DataValueField As String, ByVal DataSource As Object)
        CheckBoxList.DataTextField = DataTextField
        CheckBoxList.DataValueField = DataValueField
        CheckBoxList.DataSource = DataSource
        CheckBoxList.DataBind()
    End Sub

#End Region

#Region "Safe String values"

    ''' <summary>
    ''' کاراکتر های "ی" و "ک" را بع معدل عربی عوض می کند
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DbReplace(ByVal value As String) As String

        Return value.Replace("ی", "ي").Replace("ک", "ك").ToString

    End Function

    ''' <summary>
    ''' this function safe Dynamically assembled queries  and from Sql injection
    ''' </summary>
    ''' <param name="inputString"></param>
    ''' <param name="bitLikeSafe"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SafeDynamicString(ByVal inputString As String, ByVal bitLikeSafe As Boolean, ByVal replaceNoneArabicChars As Boolean) As String

        Dim output As String = inputString

        If replaceNoneArabicChars Then output = DbReplace(output)

        output = output.Replace(Chr(39), Chr(39) + Chr(39))

        output = output.Replace("[", "[[]")

        output = output.Replace("%", "[%]")

        output = output.Replace("_", "[_]")

        Return output

    End Function

#End Region

#Region "simple datgrid Binding"


    ''' <summary>
    ''' first DataGrid Binding
    ''' </summary>
    ''' <param name="CurrentPage"></param>
    ''' <param name="DT"></param>
    ''' <param name="DG"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindGrid(ByVal CurrentPage As System.Web.UI.Page, ByVal DT As Data.DataTable, ByRef DG As System.Web.UI.WebControls.DataGrid, ByVal DoRanking As Boolean)

        If Not DT Is Nothing Then

            DG.CurrentPageIndex = 0

            CurrentPage.Session(CurrentPage.UniqueID & "_" & DG.UniqueID & "_" & "BindData") = DT

        End If

        If CurrentPage.Session(CurrentPage.UniqueID & "_" & DG.UniqueID & "_" & "BindData") IsNot Nothing AndAlso CType(CurrentPage.Session(CurrentPage.UniqueID & "_" & DG.UniqueID & "_" & "BindData"), Data.DataTable).Rows.Count >= 0 Then

            If DoRanking = True Then

                Ranking(CType(CurrentPage.Session(CurrentPage.UniqueID & "_" & DG.UniqueID & "_" & "BindData"), Data.DataTable))

            End If

            DG.DataSource = CurrentPage.Session(CurrentPage.UniqueID & "_" & DG.UniqueID & "_" & "BindData")

            DG.DataBind()

        Else

            DG.DataSource = Nothing

            DG.DataBind()

        End If

    End Sub

    Public Shared Sub BindGrid(ByVal CurrentPage As System.Web.UI.Page, ByRef DG As System.Web.UI.WebControls.DataGrid)

        BindGrid(CurrentPage, Nothing, DG, False)

    End Sub

    Public Shared Sub BindGrid(ByVal CurrentPage As System.Web.UI.Page, ByRef DG As System.Web.UI.WebControls.DataGrid, ByVal SortKey As String)

        Dim DT As DataTable

        Dim SortDirection As String = String.Empty

        DT = CType(CurrentPage.Session(CurrentPage.UniqueID & "_" & DG.UniqueID & "_" & "BindData"), DataTable)

        If CurrentPage.Session(CurrentPage.UniqueID & "_" & DG.UniqueID & "_" & "SortDirection").ToString() = "desc" Then

            SortDirection = "asc"

            CurrentPage.Session(CurrentPage.UniqueID & "_" & DG.UniqueID & "_" & "SortDirection") = "asc"

        Else

            SortDirection = "desc"

            CurrentPage.Session(CurrentPage.UniqueID & "_" & DG.UniqueID & "_" & "SortDirection") = "desc"

        End If

        If DT.Rows.Count >= 0 Then

            DT.DefaultView.Sort = SortKey + " " + SortDirection

            DT.AcceptChanges()

            DG.DataSource = DT

            DG.DataBind()

        Else

            DG.DataSource = Nothing

            DG.DataBind()

        End If

    End Sub

#End Region

End Class
