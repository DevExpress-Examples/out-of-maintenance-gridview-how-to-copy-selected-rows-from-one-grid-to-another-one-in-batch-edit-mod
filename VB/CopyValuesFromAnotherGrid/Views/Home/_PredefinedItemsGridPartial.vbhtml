@Code
    Dim grid = Html.DevExpress().GridView(Sub(settings)
                                                     settings.Name = "PredefinedItemsGrid"
                                                     settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "PredefinedItemsGridPartial"}
                                                     settings.Width = Unit.Percentage(100)
                                                     settings.KeyFieldName = "ItemID"
                                                     settings.SettingsPager.Visible = True
                                                     settings.Settings.ShowGroupPanel = False
                                                     settings.Settings.ShowFilterRow = False
                                                     settings.SettingsBehavior.AllowSelectByRowClick = True
                                                     settings.CommandColumn.Visible = True
                                                     settings.CommandColumn.ShowSelectCheckbox = True
                                                     settings.Columns.Add("ItemName")
                                                     settings.Columns.Add("ItemDescription")
                                             End Sub)
End Code
@grid.Bind(Model).GetHtml()