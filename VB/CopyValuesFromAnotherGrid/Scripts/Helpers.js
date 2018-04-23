Array.prototype.remove = function() {
    var what, a = arguments, L = a.length, ax;
    while (L && this.length) {
        what = a[--L];
        while ((ax = this.indexOf(what)) !== -1) {
            this.splice(ax, 1);
        }
    }
    return this;
};


var OrderListHelper = {
    NewRowIndices: [],
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
    CancelPredefinedOrders: function () {
        CatalogPopup.Hide();
        OrderListHelper.ClearPredefinedItemsSelection();
    },
    ClearPredefinedItemsSelection: function () {
        if (PredefinedItemsGrid.GetSelectedRowCount() > 0)
            PredefinedItemsGrid.UnselectRows();
    },
    AddNewItem: function () {
        GridViewOrderList.AddNewRow();
        OrderListHelper.AddNewIndex();
    },
    DeleteItem: function (event) {
        var tr = event.target.parentElement.parentElement.parentElement; // Get the row element
        var id = tr.attributes['id'].value;
        var index = id.split("DataRow")[1];
        GridViewOrderList.DeleteRow(index);
        OrderListHelper.NewRowIndices = OrderListHelper.NewRowIndices.remove(parseInt(index));
    },
    AddNewIndex: function () {
        var newIndex = -1;
        if (OrderListHelper.NewRowIndices.length > 0)
            newIndex = OrderListHelper.NewRowIndices[OrderListHelper.NewRowIndices.length - 1] - 1;
        OrderListHelper.NewRowIndices.push(newIndex);
        return newIndex;
    }
};