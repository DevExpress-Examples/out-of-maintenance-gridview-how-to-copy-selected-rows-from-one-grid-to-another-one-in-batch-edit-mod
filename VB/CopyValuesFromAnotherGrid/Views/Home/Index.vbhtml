
@Code
    ViewBag.Title = "Index"
End Code

<h2>Items request list</h2>
<i>
    Specify items to request. Note that you can add predefined items<br/>
    using the "Predefined items" dialog. Click the "Predefined items" to invoke this dialog.
</i>
<br /><br />

@Html.Action("GridViewOrderListPartial")
@Html.DevExpress().PopupControl(Sub(settings)
	settings.Name = "CatalogPopup"
	settings.Height = Unit.Pixel(500)
	settings.Width = Unit.Pixel(400)
	settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
	settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
	settings.Modal = True
	settings.ShowHeader = False
	settings.ShowFooter = True
	settings.SetContent(Sub() Html.RenderPartial("Catalog"))
	settings.SetFooterContentTemplateContent(Sub(t)
		ViewContext.Writer.Write("<div class='container__buttons'>")
		Html.DevExpress().Button(Sub(settingsConfirmButton)
			settingsConfirmButton.Name = "ConfirmButton"
			settingsConfirmButton.Text = "Confirm"
			settingsConfirmButton.UseSubmitBehavior = False
			settingsConfirmButton.RenderMode = ButtonRenderMode.Link
			settingsConfirmButton.ControlStyle.CssClass = "button"
			settingsConfirmButton.ClientSideEvents.Click = "OrderListHelper.ConfirmPredefinedOrders"
		End Sub).Render()
		Html.DevExpress().Button(Sub(settingsCancelButton)
			settingsCancelButton.Name = "CancelButton"
			settingsCancelButton.Text = "Cancel"
			settingsCancelButton.UseSubmitBehavior = False
			settingsCancelButton.RenderMode = ButtonRenderMode.Link
			settingsCancelButton.ControlStyle.CssClass = "button"
			settingsCancelButton.ClientSideEvents.Click = "OrderListHelper.CancelPredefinedOrders"
		End Sub).Render()
		ViewContext.Writer.Write("</div>")
	End Sub)
End Sub).GetHtml()