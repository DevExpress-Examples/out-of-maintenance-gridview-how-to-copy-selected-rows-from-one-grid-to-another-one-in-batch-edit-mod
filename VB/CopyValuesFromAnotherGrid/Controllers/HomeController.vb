Imports CopyValuesFromAnotherGrid.Models
Imports DevExpress.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace CopyValuesFromAnotherGrid.Controllers
	Public Class HomeController
		Inherits Controller

		' GET: Home
		Public Function Index() As ActionResult
			Session.Clear()
			Return View()
		End Function

		<ValidateInput(False)>
		Public Function PredefinedItemsGridPartial() As ActionResult
			Dim model = ItemRepository.GetPredefinedItems()
			Return PartialView("_PredefinedItemsGridPartial", model)
		End Function

		<ValidateInput(False)>
		Public Function GridViewOrderListPartial() As ActionResult
			Dim model = ItemRepository.Data
			Return PartialView("_GridViewOrderListPartial", model)
		End Function

		<ValidateInput(False), HttpPost>
		Public Function GridViewOrderListBatchUpdate(ByVal updateValues As MVCxGridViewBatchUpdateValues(Of Item, Object)) As ActionResult
			Dim model = ItemRepository.Data
			' Insert all added values. 
			Dim newId = If(model.Count > 0, model.Max(Function(i) i.ItemID), 0)
			For Each item In updateValues.Insert
				Try
                    newId += 1
                    model.Add(New Item With {.ItemID = newId, .ItemName = item.ItemName, .ItemDescription = item.ItemDescription})
				Catch e As Exception
					updateValues.SetErrorText(item, e.Message)
				End Try
			Next item
			' Update all edited values. 
			For Each item In updateValues.Update
				Try
					Dim modelItem = model.FirstOrDefault(Function(it) it.ItemID = item.ItemID)
					If modelItem IsNot Nothing Then
						Me.UpdateModel(modelItem)
					End If
				Catch e As Exception
					updateValues.SetErrorText(item, e.Message)
				End Try
			Next item
			' Delete all values that were deleted on the client side from the data source. 
			For Each ItemID In updateValues.DeleteKeys
				Try
					Dim item = model.FirstOrDefault(Function(it) it.ItemID = Convert.ToInt32(ItemID))
					If item IsNot Nothing Then
						model.Remove(item)
					End If
				Catch e As Exception
					updateValues.SetErrorText(ItemID, e.Message)
				End Try
			Next ItemID
			Return PartialView("_GridViewOrderListPartial", model.ToList())
		End Function
	End Class
End Namespace