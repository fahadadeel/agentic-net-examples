using System;
using Aspose.Words;

class Program
{
    static void Main()
    {
        // Load the primary document (the one we will append to).
        Document mainDoc = new Document("MainDocument.docx");

        // Load the secondary document (the one we want to insert/append).
        Document secondaryDoc = new Document("SecondaryDocument.docx");

        // -------------------------------------------------
        // Example 1: Append the entire secondary document to the end of the main document.
        // -------------------------------------------------
        // Keep the source formatting of the secondary document.
        mainDoc.AppendDocument(secondaryDoc, ImportFormatMode.KeepSourceFormatting);

        // -------------------------------------------------
        // Example 2: Insert the secondary document at a specific bookmark in the main document.
        // -------------------------------------------------
        // Uncomment the following lines if you need to insert at a bookmark named "InsertHere".
        /*
        DocumentBuilder builder = new DocumentBuilder(mainDoc);
        builder.MoveToBookmark("InsertHere");
        // Insert the secondary document at the current cursor position.
        builder.InsertDocument(secondaryDoc, ImportFormatMode.KeepSourceFormatting);
        */

        // Save the combined document to a new file.
        mainDoc.Save("CombinedDocument.docx");
    }
}
