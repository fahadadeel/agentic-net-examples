using System;
using Aspose.Words;
using Aspose.Words.Tables;

class InsertTableIntoDocm
{
    static void Main()
    {
        // Load an existing DOCM document.
        Document doc = new Document("InputDocument.docm");

        // Create a DocumentBuilder attached to the loaded document.
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Start a new table.
        Table table = builder.StartTable();

        // Insert the first row with two cells.
        builder.InsertCell();
        builder.Write("Header 1");
        builder.InsertCell();
        builder.Write("Header 2");
        builder.EndRow();

        // Insert a second row with data.
        builder.InsertCell();
        builder.Write("Row 1, Cell 1");
        builder.InsertCell();
        builder.Write("Row 1, Cell 2");
        builder.EndRow();

        // Insert a third row with data.
        builder.InsertCell();
        builder.Write("Row 2, Cell 1");
        builder.InsertCell();
        builder.Write("Row 2, Cell 2");
        builder.EndRow();

        // Finish the table.
        builder.EndTable();

        // Optional: Apply a built‑in style and auto‑fit to contents.
        table.StyleIdentifier = StyleIdentifier.LightShadingAccent1;
        table.AutoFit(AutoFitBehavior.AutoFitToContents);

        // Save the document back as a DOCM file (preserves macros if any).
        doc.Save("OutputDocument.docm");
    }
}
