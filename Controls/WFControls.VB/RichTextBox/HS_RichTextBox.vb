Option Explicit On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing

Namespace HS

    Public Class HS_RichTextBox : Inherits RichTextBox


#Region " Other "


        ' Convert the unit that is used by the .NET framework (1/100 inch) 
        ' and the unit that is used by Win32 API calls (twips 1/1440 inch)
        Private Const AnInch As Double = 14.4

        <StructLayout(LayoutKind.Sequential)> _
         Private Structure RECT
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure CHARRANGE
            Public cpMin As Integer          ' First character of range (0 for start of doc)
            Public cpMax As Integer          ' Last character of range (-1 for end of doc)
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure FORMATRANGE
            Public hdc As IntPtr             ' Actual DC to draw on
            Public hdcTarget As IntPtr       ' Target DC for determining text formatting
            Public rc As RECT                ' Region of the DC to draw to (in twips)
            Public rcPage As RECT            ' Region of the whole DC (page size) (in twips)
            Public chrg As CHARRANGE         ' Range of text to draw (see above declaration)
        End Structure

        Private Const WM_USER As Integer = &H400
        Private Const EM_FORMATRANGE As Integer = WM_USER + 57
        'Overloads
        Private Overloads Declare Function SendMessage Lib "USER32" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr


#End Region

#Region "Property"

        Private _CaretPos As Integer
        Public ReadOnly Property CaretPos() As Integer
            Get
                Return _CaretPos
            End Get

        End Property

#End Region

#Region " Print "

        'Render the contents of the RichTextBox for printing
        'Return the last character printed + 1 (printing start from this point for next page)

        Public Function Print(ByVal charFrom As Integer, ByVal charTo As Integer, ByVal e As PrintPageEventArgs) As Integer

            ' Mark starting and ending character 
            Dim cRange As CHARRANGE
            cRange.cpMin = charFrom
            cRange.cpMax = charTo

            ' Calculate the area to render and print
            Dim rectToPrint As RECT
            rectToPrint.Top = e.MarginBounds.Top * AnInch
            rectToPrint.Bottom = e.MarginBounds.Bottom * AnInch
            rectToPrint.Left = e.MarginBounds.Left * AnInch
            rectToPrint.Right = e.MarginBounds.Right * AnInch

            ' Calculate the size of the page
            Dim rectPage As RECT
            rectPage.Top = e.PageBounds.Top * AnInch
            rectPage.Bottom = e.PageBounds.Bottom * AnInch
            rectPage.Left = e.PageBounds.Left * AnInch
            rectPage.Right = e.PageBounds.Right * AnInch

            Dim hdc As IntPtr = e.Graphics.GetHdc()

            Dim fmtRange As FORMATRANGE
            fmtRange.chrg = cRange                 ' Indicate character from to character to 
            fmtRange.hdc = hdc                     ' Use the same DC for measuring and rendering
            fmtRange.hdcTarget = hdc               ' Point at printer hDC
            fmtRange.rc = rectToPrint              ' Indicate the area on page to print
            fmtRange.rcPage = rectPage             ' Indicate whole size of page

            Dim res As IntPtr = IntPtr.Zero

            Dim wparam As IntPtr = IntPtr.Zero
            wparam = New IntPtr(1)

            ' Move the pointer to the FORMATRANGE structure in memory
            Dim lparam As IntPtr = IntPtr.Zero
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
            Marshal.StructureToPtr(fmtRange, lparam, False)

            ' Send the rendered data for printing 
            res = SendMessage(Handle, EM_FORMATRANGE, wparam, lparam)

            ' Free the block of memory allocated
            Marshal.FreeCoTaskMem(lparam)

            ' Release the device context handle obtained by a previous call
            e.Graphics.ReleaseHdc(hdc)

            ' Return last + 1 character printer
            Return res.ToInt32()
        End Function


#End Region

#Region " Highlight Sarandy"


#Region "Property: SelectionBackColor"


        <StructLayout(LayoutKind.Sequential)> Private Structure CharFormat2

            Public cbSize As Int32
            Public dwMask As Int32
            Public dwEffects As Int32
            Public yHeight As Int32
            Public yOffset As Int32

            Public crTextColor As Int32

            Public bCharSet As Byte
            Public bPitchAndFamily As Byte


            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> Public szFaceName As String

            Public wWeight As Int16
            Public sSpacing As Int16
            Public crBackColor As Int32
            Public lcid As Int32
            Public dwReserved As Int32
            Public sStyle As Int16
            Public wKerning As Int16
            Public bUnderlineType As Byte
            Public bAnimation As Byte
            Public bRevAuthor As Byte
            Public bReserved1 As Byte
        End Structure




        Private Const LF_FACESIZE = 32
        Private Const CFM_BACKCOLOR = &H4000000
        Private Const CFE_AUTOBACKCOLOR = CFM_BACKCOLOR
        ' Private Const WM_USER = &H400   'difine in top
        Private Const EM_SETCHARFORMAT = (WM_USER + 68)
        Private Const EM_SETBKGNDCOLOR = (WM_USER + 67)
        Private Const EM_GETCHARFORMAT = (WM_USER + 58)
        Private Const WM_SETTEXT = &HC
        Private Const SCF_SELECTION = &H1&


        Private Overloads Declare Auto Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As CharFormat2) As Boolean


        ' Here we do the magic...
        Public Property SelectionBackColor() As Color
            Get
                ' We need to ask the RTB for the backcolor of the current selection.
                ' This is done using SendMessage with a format structure which the RTB will fill in for us.
                Dim HWND As IntPtr = Me.Handle ' Force the creation of the window handle...
                Dim Format As New CharFormat2
                Format.dwMask = CFM_BACKCOLOR
                Format.cbSize = Marshal.SizeOf(Format)
                SendMessage(Me.Handle, EM_GETCHARFORMAT, SCF_SELECTION, Format)
                Return ColorTranslator.FromOle(Format.crBackColor)
            End Get
            Set(ByVal Value As Color)
                ' Here we do relatively the same thing as in Get, but we are telling the RTB to set
                ' the color this time instead of returning it to us.
                Dim HWND As IntPtr = Me.Handle ' Force the creation of the window handle...
                Dim Format As New CharFormat2
                Format.crBackColor = ColorTranslator.ToOle(Value)
                Format.dwMask = CFM_BACKCOLOR
                Format.cbSize = Marshal.SizeOf(Format)
                SendMessage(Me.Handle, EM_SETCHARFORMAT, SCF_SELECTION, Format)
            End Set
        End Property


#End Region

#Region "Proc: ClearBackColor"


        Private Enum ScrollBarTypes
            SB_HORZ = 0
            SB_VERT = 1
            SB_CTL = 2
            SB_BOTH = 3
        End Enum

        Private Enum ScrollBarInfoFlags
            SIF_RANGE = &H1
            SIF_PAGE = &H2
            SIF_POS = &H4
            SIF_DISABLENOSCROLL = &H8
            SIF_TRACKPOS = &H10
            SIF_ALL = (SIF_RANGE Or SIF_PAGE Or SIF_POS Or SIF_TRACKPOS)
        End Enum

        '------------------ clearbackcolor



        <StructLayout(LayoutKind.Sequential)> Private Structure SCROLLINFO

            Public cbSize As Integer ' UINT cbSize; 
            Public fMask As ScrollBarInfoFlags ' UINT fMask; 
            Public nMin As Integer 'int  nMin; 
            Public nMax As Integer 'int  nMax; 
            Public nPage As Integer 'UINT nPage;  
            Public nPos As Integer ' int  nPos; 
            Public nTrackPos As Integer ' int  nTrackPos; 

        End Structure

        Private Declare Function GetScrollInfo Lib "User32" (ByVal hWnd As IntPtr, ByVal fnBar As ScrollBarTypes, ByRef lpsi As SCROLLINFO) As Boolean

        Private Function GetScrollBarPos(ByVal hWnd As IntPtr, ByVal BarType As ScrollBarTypes) As Integer

            Dim INFO As SCROLLINFO
            INFO.fMask = ScrollBarInfoFlags.SIF_POS
            INFO.cbSize = Marshal.SizeOf(INFO)
            GetScrollInfo(hWnd, BarType, INFO)
            Return INFO.nPos

        End Function

#End Region

#Region "Proc: Highlight"

        Public Declare Function LockWindowUpdate Lib "user32.dll" (ByVal hWndLock As IntPtr) As Boolean

        '------------------- highlight


#End Region

#Region "Proc: ScrollToBottom"


        Private Enum EMFlags  '"Scroller Flags"
            EM_SETSCROLLPOS = &H400 + 222
        End Enum


        Private Enum ScrollBarFlags
            SBS_HORZ = &H0
            SBS_VERT = &H1
            SBS_TOPALIGN = &H2
            SBS_LEFTALIGN = &H2
            SBS_BOTTOMALIGN = &H4
            SBS_RIGHTALIGN = &H4
            SBS_SIZEBOXTOPLEFTALIGN = &H2
            SBS_SIZEBOXBOTTOMRIGHTALIGN = &H4
            SBS_SIZEBOX = &H8
            SBS_SIZEGRIP = &H10
        End Enum


#Region "Structure: POINT"
        <StructLayout(LayoutKind.Sequential)> Private Class POINT
            Public x As Integer
            Public y As Integer

            Public Sub New()
            End Sub

            Public Sub New(ByVal x As Integer, ByVal y As Integer)
                Me.x = x
                Me.y = y
            End Sub
        End Class
#End Region

        Private Declare Function GetScrollRange Lib "User32" (ByVal hWnd As IntPtr, ByVal nBar As Integer, ByRef lpMinPos As Integer, ByRef lpMaxPos As Integer) As Boolean

        '**********************************************
        Private Overloads Declare Auto Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As HS_RichTextBox.POINT) As IntPtr

        '-------------------------scrolltobottom







#End Region


        Public Sub ClearBackColor(Optional ByVal ClearAll As Boolean = True)

            Dim HWND As IntPtr = Me.Handle ' Force the creation of the window handle...

            LockWindowUpdate(Me.Handle)   ' Lock drawing...
            Me.SuspendLayout()

            Dim ScrollPosVert As Integer = Me.GetScrollBarPos(Me.Handle, ScrollBarTypes.SB_VERT)
            Dim ScrollPosHoriz As Integer = Me.GetScrollBarPos(Me.Handle, ScrollBarTypes.SB_HORZ)
            Dim SelStart As Integer = Me.SelectionStart
            Dim SelLength As Integer = Me.SelectionLength

            If ClearAll Then Me.SelectAll() ' Should we clear everything or just use the current selection?
            Dim Format As New CharFormat2
            Format.crBackColor = -1
            Format.dwMask = CFM_BACKCOLOR
            Format.dwEffects = CFE_AUTOBACKCOLOR  ' Clears the backcolor
            Format.cbSize = Marshal.SizeOf(Format)
            SendMessage(Me.Handle, EM_SETCHARFORMAT, SCF_SELECTION, Format)

            ' Return the previous values...
            Me.SelectionStart = SelStart
            Me.SelectionLength = SelLength
            SendMessage(Me.Handle, EMFlags.EM_SETSCROLLPOS, 0, New HS_RichTextBox.POINT(ScrollPosHoriz, ScrollPosVert))

            Me.ResumeLayout()
            LockWindowUpdate(IntPtr.Zero) ' Unlock drawing...
        End Sub

        Public Sub Highlight(ByVal FindWhat As String, ByVal Highlight As Color, ByVal MatchCase As Boolean, ByVal MatchWholeWord As Boolean)

            LockWindowUpdate(Me.Handle)   ' Lock drawing...
            Me.SuspendLayout()

            Dim ScrollPosVert As Integer = Me.GetScrollBarPos(Me.Handle, ScrollBarTypes.SB_VERT)
            Dim ScrollPosHoriz As Integer = Me.GetScrollBarPos(Me.Handle, ScrollBarTypes.SB_HORZ)

            Dim SelStart As Integer = Me.SelectionStart
            Dim SelLength As Integer = Me.SelectionLength

            'Dim Length As Integer = FindWhat.Length

            Dim Finds As RichTextBoxFinds
            If MatchCase Then Finds = Finds Or RichTextBoxFinds.MatchCase
            If MatchWholeWord Then Finds = Finds Or RichTextBoxFinds.WholeWord

            ' Do the search.
            Dim StartFrom As Integer = 0
            '_________________________________________ for scrol

            _CaretPos = Me.Find(FindWhat, StartFrom, Finds)

            '_________________________________________
            While Me.Find(FindWhat, StartFrom, Finds) > -1 'change Me.SelectionStart
                Me.SelectionBackColor = Highlight
                StartFrom = Me.SelectionStart + Me.SelectionLength  ' Continue after the one we found..
            End While

            ' Return the previous values...
            Me.SelectionStart = SelStart
            Me.SelectionLength = SelLength

            SendMessage(Me.Handle, EMFlags.EM_SETSCROLLPOS, 0, New HS_RichTextBox.POINT(ScrollPosHoriz, ScrollPosVert))
            Me.ResumeLayout()
            LockWindowUpdate(IntPtr.Zero) ' Unlock drawing...
        End Sub

        Public Sub ScrollToBottom()

            Dim Min, Max As Integer
            GetScrollRange(Me.Handle, ScrollBarFlags.SBS_VERT, Min, Max)
            SendMessage(Me.Handle, EMFlags.EM_SETSCROLLPOS, 0, New HS_RichTextBox.POINT(0, Max - Me.Height))

        End Sub

        ''===================================================================
        '' API Function: GetScrollPos
        ''===================================================================
        'Private Declare Function GetScrollPos Lib "user32.dll" ( _
        '    ByVal hWnd As IntPtr, _
        '    ByVal nBar As Integer) As Integer
        ''===================================================================
        '' API Function: PostMessageA
        ''===================================================================
        'Private Declare Function PostMessageA Lib "user32.dll" ( _
        '    ByVal hwnd As IntPtr, _
        '    ByVal wMsg As Integer, _
        '    ByVal wParam As Integer, _
        '    ByVal lParam As Integer) As Boolean


        '====================================================================

        ' Private Sub RichTextBox3_HScroll(ByVal sender As Object,_
        ' ByVal e As System.EventArgs) Handles RichTextBox3.HScroll
        '    Dim RTB3Position As Integer
        '    RTB3Position = GetScrollPos(RichTextBox3.Handle, SBS_HORZ)
        '    PostMessageA(RichTextBox1.Handle, WM_HSCROLL, _
        '    SB_THUMBPOSITION + &H10000 * RTB3Position, 0)
        '    PostMessageA(RichTextBox2.Handle, WM_HSCROLL, _
        '    SB_THUMBPOSITION + &H10000 * RTB3Position, 0)
        'End Sub

        '=======================================================================================

#End Region


    End Class

End Namespace









