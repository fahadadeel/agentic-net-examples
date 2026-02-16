using System;
using Aspose.Words;

class InsertIntoRangeExample
{
    static void Main()
    {
        // Load the existing DOCX document.
        Document doc = new Document("input.docx");

        // Create a DocumentBuilder for editing the document.
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Move the builder to the start of the document's main range.
        // This positions the insertion point at the very beginning.
        builder.MoveToDocumentStart();

        // Insert the desired content.
        builder.Writeln("This text has been inserted into the document range.");

        // Save the modified document.
        doc.Save("output.docx");
    }
}
