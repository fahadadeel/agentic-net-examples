using Aspose.Words;
using Aspose.Words.Tables;

class Program
{
    static void Main()
    {
        // Create a new empty document.
        Document doc = new Document();

        // Attach a DocumentBuilder to the document for content insertion.
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Begin a new table.
        Table table = builder.StartTable();

        // ---- First row (header) ----
        builder.InsertCell();                 // First cell of the header row.
        builder.Write("Header 1");            // Write text into the cell.
        builder.InsertCell();                 // Second cell of the header row.
        builder.Write("Header 2");
        builder.EndRow();                     // Complete the header row.

        // ---- Second row (data) ----
        builder.InsertCell();                 // First cell of the data row.
        builder.Write("Cell 1");
        builder.InsertCell();                 // Second cell of the data row.
        builder.Write("Cell 2");
        builder.EndRow();                     // Complete the data row.

        // End the table construction.
        builder.EndTable();

        // Apply automatic fitting to the contents and a built‑in style.
        table.AutoFit(AutoFitBehavior.AutoFitToContents);
        table.StyleIdentifier = StyleIdentifier.LightShadingAccent1;

        // Save the document to disk.
        doc.Save("TableExample.docx");
    }
}
