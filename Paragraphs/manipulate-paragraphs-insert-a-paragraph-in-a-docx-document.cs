using System;
using Aspose.Words;

class Program
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();

        // Attach a DocumentBuilder to the document for easy content insertion.
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Add the first paragraph.
        builder.Writeln("First paragraph.");

        // Insert a new paragraph at the current cursor position.
        builder.Writeln("Inserted paragraph.");

        // Add another paragraph after the inserted one.
        builder.Writeln("Third paragraph.");

        // Save the document as a DOCX file.
        doc.Save("InsertedParagraph.docx");
    }
}
