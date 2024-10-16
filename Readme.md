<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128629018/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E693)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Data Grid - Hide a check box from certain grid cells

This example creates an empty repository item and handles the [CustomRowCellEdit]() event to assign it to grid cells based on a specific condition:

![WinForms Data Grid - Hide a check box from certain grid cells](https://raw.githubusercontent.com/DevExpress-Examples/how-to-hide-a-check-box-in-a-grid-cell-e693/13.1.4%2B/media/winforms-grid-empty-editor.png)

```csharp
RepositoryItem emptyEditor;
private void Form1_Load(object sender, System.EventArgs e) {
    emptyEditor = new RepositoryItem();
    gridControl1.RepositoryItems.Add(emptyEditor);
    // ...
}
private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
    if (e.Column.FieldName == "Discontinued" &&
        NeedToHideDiscontinuedCheckbox(sender as GridView, e.RowHandle))
        e.RepositoryItem = emptyEditor;
}
bool NeedToHideDiscontinuedCheckbox(GridView view, int row) {
    return (view.GetRowCellDisplayText(row, "Category") == "Dairy Products");
}
```
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-hide-check-box-from-certain-cells&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-hide-check-box-from-certain-cells&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
