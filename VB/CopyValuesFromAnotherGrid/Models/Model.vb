Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace CopyValuesFromAnotherGrid.Models
	Public Class Item
		Public Property ItemID() As Integer
		Public Property ItemName() As String
		Public Property ItemDescription() As String
	End Class

	Public NotInheritable Class ItemRepository

		Private Sub New()
		End Sub


		Private Shared sessionKey As String = "ItemsDataSource"
		Public Shared Property Data() As List(Of Item)
			Get
				If HttpContext.Current.Session(sessionKey) Is Nothing Then
					HttpContext.Current.Session(sessionKey) = New List(Of Item)()
				End If

				Return TryCast(HttpContext.Current.Session(sessionKey), List(Of Item))
			End Get
			Set(ByVal value As List(Of Item))
			End Set
		End Property

		Public Shared Function GetPredefinedItems() As List(Of Item)
			Return New List(Of Item) From {
				New Item With {.ItemID = 0, .ItemName = "Pen", .ItemDescription = "A set of 5 pens."},
				New Item With {.ItemID = 1, .ItemName = "Pencil", .ItemDescription = "A set of 5 pencils."},
				New Item With {.ItemID = 2, .ItemName = "Paper", .ItemDescription = "A pack of paper."}
			}
		End Function
	End Class
End Namespace