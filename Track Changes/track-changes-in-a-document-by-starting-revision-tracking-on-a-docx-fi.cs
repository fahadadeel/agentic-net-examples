using System;
using Aspose.Words;

class TrackChangesExample
{
    static void Main()
    {
        // Load an existing DOCX file.
        Document doc = new Document("InputDocument.docx");

        // Start tracking revisions. Provide author name and current date/time.
        doc.StartTrackRevisions("John Doe", DateTime.Now);

        // Any edits made after this point will be recorded as revisions.
        DocumentBuilder builder = new DocumentBuilder(doc);
        builder.Writeln("This text is added while tracking changes.");

        // Stop tracking if no further revisions are needed (optional).
        doc.StopTrackRevisions();

        // Save the document with revisions.
        doc.Save("OutputDocument.docx");
    }
}
