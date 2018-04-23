Imports DevExpress.Data

Public NotInheritable Class MainPage
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        grid.ItemsSource = New ProductList()
        grid.TotalSummary.Add(SummaryItemType.Count, "ProductName")
        grid.TotalSummary.Add(SummaryItemType.Max, "UnitPrice").DisplayFormat = "Max: {0:c2}"
        grid.TotalSummary.Add(SummaryItemType.Average, "UnitPrice").DisplayFormat = "Avg: {0:c2}"
    End Sub

    Private Sub grid_CustomUnboundColumnData(ByVal sender As Object, ByVal e As DevExpress.UI.Xaml.Grid.GridColumnDataEventArgs)
        If e.IsGetData Then
            Dim price As Integer = Convert.ToInt32(e.GetListSourceFieldValue("UnitPrice"))
            Dim quantity As Integer = Convert.ToInt32(e.GetListSourceFieldValue("Quantity"))
            e.Value = price * quantity
        End If
    End Sub
End Class
