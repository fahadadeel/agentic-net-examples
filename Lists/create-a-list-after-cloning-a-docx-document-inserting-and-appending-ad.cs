using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Saving;

class Program
{
    static void Main()
    {
        // Load the original DOCX document.
        Document originalDoc = new Document("Original.docx");

        // Clone the document (deep clone, including all nodes).
        Document clonedDoc = (Document)originalDoc.Clone(true);

        // Create a DocumentBuilder for the cloned document.
        DocumentBuilder builder = new DocumentBuilder(clonedDoc);

        // -----------------------------------------------------------------
        // Insert additional content at the beginning of the document.
        // -----------------------------------------------------------------
        builder.MoveToDocumentStart();               // Position cursor at the very start.
        builder.ParagraphFormat.StyleName = "Heading 1";
        builder.Writeln("=== Inserted Content (Start) ===");
        builder.Writeln("This paragraph was inserted at the beginning of the cloned document.");

        // -----------------------------------------------------------------
        // Append additional content at the end of the document.
        // -----------------------------------------------------------------
        builder.MoveToDocumentEnd();                 // Position cursor at the very end.
        builder.Writeln("\n=== Appended Content (End) ===");
        builder.Writeln("This paragraph was appended at the end of the cloned document.");

        // -----------------------------------------------------------------
        // Create a numbered list after the appended content.
        // -----------------------------------------------------------------
        builder.Writeln();                           // Add an empty line before the list.
        builder.ListFormat.ApplyNumberDefault();     // Start a new numbered list.
        builder.Writeln("First list item");
        builder.Writeln("Second list item");
        builder.Writeln("Third list item");
        builder.ListFormat.RemoveNumbers();          // End the list.

        // -----------------------------------------------------------------
        // Save the modified cloned document as a new DOCX file.
        // -----------------------------------------------------------------
        string outputDocxPath = "ClonedModified.docx";
        clonedDoc.Save(outputDocxPath);

        // -----------------------------------------------------------------
        // Split the document into separate HTML files at each section break.
        // -----------------------------------------------------------------
        HtmlSaveOptions htmlOptions = new HtmlSaveOptions
        {
            DocumentSplitCriteria = DocumentSplitCriteria.SectionBreak,
            // Optional: customize the naming of each part.
            DocumentPartSavingCallback = new CustomPartNamingCallback()
        };

        string outputHtmlBase = "ClonedSplit.html";
        clonedDoc.Save(outputHtmlBase, htmlOptions);

        Console.WriteLine("Processing complete.");
    }
}

// Custom callback to give each split part a meaningful file name.
class CustomPartNamingCallback : IDocumentPartSavingCallback
{
    private int _partIndex = 0;

    void IDocumentPartSavingCallback.DocumentPartSaving(DocumentPartSavingArgs args)
    {
        // Increment part counter.
        _partIndex++;

        // Build a new file name: base name + part number + original extension.
        string baseName = Path.GetFileNameWithoutExtension(args.DocumentPartFileName);
        string extension = Path.GetExtension(args.DocumentPartFileName);
        string newFileName = $"{baseName}_Part{_partIndex}{extension}";

        // Assign the new file name.
        args.DocumentPartFileName = newFileName;

        // Ensure the stream is closed after saving (default behavior).
        args.KeepDocumentPartStreamOpen = false;
    }
}
