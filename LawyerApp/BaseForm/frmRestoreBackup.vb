Imports Lawyer.Common.CS.ConfigFile
Public Class frmRestoreBackup

    Sub New(ByVal c As Config, ByVal IsRestore As Boolean, ByVal restoreLaws As Boolean, Optional ByVal automaticStart As Boolean = False)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        BackRestore1.SetInitial(c, IsRestore, restoreLaws, automaticStart)

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub _closeForm() Handles BackRestore1._closeForm
        Me.Close()
    End Sub


End Class