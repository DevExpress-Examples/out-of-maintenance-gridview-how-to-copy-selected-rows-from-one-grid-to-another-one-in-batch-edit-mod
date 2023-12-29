<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/CopyValuesFromAnotherGrid/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/CopyValuesFromAnotherGrid/Controllers/HomeController.vb))
* [Model.cs](./CS/CopyValuesFromAnotherGrid/Models/Model.cs) (VB: [Model.vb](./VB/CopyValuesFromAnotherGrid/Models/Model.vb))
* [Helpers.js](./CS/CopyValuesFromAnotherGrid/Scripts/Helpers.js) (VB: [Helpers.js](./VB/CopyValuesFromAnotherGrid/Scripts/Helpers.js))
* [_GridViewOrderListPartial.cshtml](./CS/CopyValuesFromAnotherGrid/Views/Home/_GridViewOrderListPartial.cshtml)
* [_PredefinedItemsGridPartial.cshtml](./CS/CopyValuesFromAnotherGrid/Views/Home/_PredefinedItemsGridPartial.cshtml)
* [Catalog.cshtml](./CS/CopyValuesFromAnotherGrid/Views/Home/Catalog.cshtml)
* [Index.cshtml](./CS/CopyValuesFromAnotherGrid/Views/Home/Index.cshtml)
* [_Layout.cshtml](./CS/CopyValuesFromAnotherGrid/Views/Shared/_Layout.cshtml)
<!-- default file list end -->
# GridView - How to copy selected rows from one grid to another one in batch edit mode


<p>This example demonstrate how to copy selected rows data from one grid to another one in batch edit mode with the possibility to remove the copied data without a request to the sever.<br><br>The copy functionality is implemented using the ASPxClientGridView.<a href="https://documentation.devexpress.com/aspnet/DevExpressWebScriptsASPxClientGridView_GetSelectedFieldValuestopic.aspx">GetSelectedFieldValues</a> method and various methods of the ASPxClientGridView.<a href="https://documentation.devexpress.com/aspnet/DevExpressWebScriptsASPxClientGridView_batchEditApitopic.aspx">batchEditApi</a> object. Refer to the following code snippet with the main function that copies row values:</p>


```js
ConfirmPredefinedOrders: function () {
    var handler = function (values) {
        if (values === undefined && values === null) return;
        var length = values.length;
        for (var i = 0; i < length; i++) {
            var newIndex = OrderListHelper.AddNewIndex();
            GridViewOrderList.AddNewRow();
            GridViewOrderList.batchEditApi.EndEdit();
            GridViewOrderList.batchEditApi.SetCellValue(newIndex, "ItemName", values[i][0]);
            GridViewOrderList.batchEditApi.SetCellValue(newIndex, "ItemDescription", values[i][1]);
        }
        CatalogPopup.Hide();
        OrderListHelper.ClearPredefinedItemsSelection();
    };
    PredefinedItemsGrid.GetSelectedFieldValues("ItemName;ItemDescription", handler);
},

```


<p> </p>
<p>Also note that in order to implement this scenario, you will need to create a custom template for most command elements on the page. The sample implementation is demonstrated in this example.<br><br><strong>See also:</strong><br><a href="https://www.devexpress.com/Support/Center/Example/Details/E2636">How to move selected rows from the ASPxGridView into another ASPxGridView</a></p>

<br/>


