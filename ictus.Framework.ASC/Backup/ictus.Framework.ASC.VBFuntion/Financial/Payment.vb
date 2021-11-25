Imports Microsoft.VisualBasic

Public Class Financial
    Public Shared Function PV(ByVal Rate As Decimal, ByVal NPer As Decimal, ByVal Pmt As Decimal, ByVal FV As Decimal) As Decimal
        Return Microsoft.VisualBasic.PV(Rate, NPer, Pmt, FV)
    End Function

    Public Shared Function PMT(ByVal Rate As Decimal, ByVal NPer As Decimal, ByVal PV As Decimal) As Decimal
        Return Microsoft.VisualBasic.Pmt(Rate, NPer, PV)
    End Function

    Public Shared Function NegativePV(ByVal Rate As Decimal, ByVal NPer As Decimal, ByVal Pmt As Decimal, ByVal FV As Decimal) As Decimal
        Return Microsoft.VisualBasic.PV(Rate, NPer, Pmt, FV) * -1
    End Function

    Public Shared Function NegativePMT(ByVal Rate As Decimal, ByVal NPer As Decimal, ByVal PV As Decimal) As Decimal
        Return Microsoft.VisualBasic.Pmt(Rate, NPer, PV) * -1
    End Function
End Class