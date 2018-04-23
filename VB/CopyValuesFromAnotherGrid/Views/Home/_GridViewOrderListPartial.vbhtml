@Code
	Dim grid = Html.DevExpress().GridView(Sub(settings)
		settings.Name = "GridViewOrderList"
		settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewOrderListPartial"}
		settings.SettingsEditing.Mode = GridViewEditingMode.Batch
		settings.SettingsEditing.BatchUpdateRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewOrderListBatchUpdate"}
		settings.KeyFieldName = "ItemID"
		settings.Columns.Add(Sub(col)
			col.Caption = "#"
			col.EditFormSettings.Visible = DefaultBoolean.False
			col.SetHeaderCaptionTemplateContent(Sub(t)
				ViewContext.Writer.Write("<div class='container__command-buttons'>")
				Html.DevExpress().Button(Sub(buttonSettings)
					buttonSettings.Name = "NewItemButton"
					buttonSettings.Text = "New"
					buttonSettings.UseSubmitBehavior = False
					buttonSettings.RenderMode = ButtonRenderMode.Link
					buttonSettings.ClientSideEvents.Click = "function (s, e) { OrderListHelper.AddNewItem(); }"
				End Sub).Render()
				ViewContext.Writer.Write("</div>")
			End Sub)
			col.SetDataItemTemplateContent(Sub(t)
				ViewContext.Writer.Write("<div class='container__command-buttons'>")
				ViewContext.Writer.Write("<a href='javascript:;' onclick='OrderListHelper.DeleteItem(event)'>Delete</a>")
				ViewContext.Writer.Write("</div>")
			End Sub)
		End Sub)
		settings.Columns.Add("ItemName")
		settings.Columns.Add("ItemDescription")
		settings.SetStatusBarTemplateContent(Sub(c)
			ViewContext.Writer.Write("<div class='container__buttons'>")
			Html.DevExpress().Button(Sub(buttonSettings)
				buttonSettings.Name = "PredefinedItemsButton"
				buttonSettings.Text = "Predefined items"
				buttonSettings.UseSubmitBehavior = False
				buttonSettings.RenderMode = ButtonRenderMode.Link
				buttonSettings.ControlStyle.CssClass = "button button__left-aligned"
				buttonSettings.ClientSideEvents.Click = "function (s, e) { CatalogPopup.Show(); }"
			End Sub).Render()
			Html.DevExpress().Button(Sub(buttonSettings)
				buttonSettings.Name = "SaveChangesButton"
				buttonSettings.Text = "Save Changes"
				buttonSettings.UseSubmitBehavior = False
				buttonSettings.RenderMode = ButtonRenderMode.Link
				buttonSettings.ControlStyle.CssClass = "button"
				buttonSettings.ClientSideEvents.Click = "function (s, e) { if (GridViewOrderList.batchEditApi.HasChanges()) { GridViewOrderList.UpdateEdit(); OrderListHelper.NewRowIndices = []; } }"
			End Sub).Render()
			Html.DevExpress().Button(Sub(buttonSettings)
				buttonSettings.Name = "CancelChangesButton"
				buttonSettings.Text = "Cancel Changes"
				buttonSettings.UseSubmitBehavior = False
				buttonSettings.RenderMode = ButtonRenderMode.Link
				buttonSettings.ControlStyle.CssClass = "button"
				buttonSettings.ClientSideEvents.Click = "function (s, e) { if (GridViewOrderList.batchEditApi.HasChanges()) { GridViewOrderList.CancelEdit(); OrderListHelper.NewRowIndices = []; } }"
			End Sub).Render()
			ViewContext.Writer.Write("</div>")
		End Sub)
	End Sub)
End Code
@grid.Bind(Model).GetHtml()