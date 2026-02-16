using System;
using Aspose.Words;

class JoinDocumentsExample
{
    static void Main()
    {
        // Load the primary document (the one into which we will insert another document).
        Document mainDoc = new Document("MainDocument.docx");

        // Load the document that will be inserted.
        Document insertDoc = new Document("DocumentToInsert.docx");

        // Create a DocumentBuilder for the primary document.
        DocumentBuilder builder = new DocumentBuilder(mainDoc);

        // Move the cursor to the end of the main document (you can adjust the position as needed).
        builder.MoveToDocumentEnd();

        // Insert the second document at the current cursor position.
        // KeepSourceFormatting preserves the original formatting of the inserted document.
        builder.InsertDocument(insertDoc, ImportFormatMode.KeepSourceFormatting);

        // Save the combined document.
        mainDoc.Save("JoinedDocument.docx");
    }
}
