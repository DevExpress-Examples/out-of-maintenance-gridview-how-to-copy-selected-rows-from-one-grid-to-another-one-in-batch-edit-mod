<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8" />
    <title>@ViewBag.Title</title>

    @Html.DevExpress().GetStyleSheets(New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}, New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors}, New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView}) 
    @Html.DevExpress().GetScripts(New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}, New Script With {.ExtensionSuite = ExtensionSuite.GridView}, New Script With {.ExtensionSuite = ExtensionSuite.Editors})
    <script src="~/Scripts/Helpers.js"></script>
    <style>
        .container__buttons {
            text-align: right;
        }

        .container__command-buttons {
            text-align: center;
        }

        .button {
            margin-right: 5px;
        }

        .button__left-aligned {
            margin-right: 2em;
        }
    </style>
</head>

<body>
    @RenderBody()
</body>
</html>