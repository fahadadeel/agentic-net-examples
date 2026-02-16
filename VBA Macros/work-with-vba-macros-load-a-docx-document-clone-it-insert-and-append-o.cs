using System;
using System.Collections.Generic;
using Aspose.Words;
using Aspose.Words.Vba;

class Program
{
    static void Main()
    {
        // Load the main macro-enabled document.
        Document mainDoc = new Document("Main.docm");

        // Clone the VBA project from the main document.
        VbaProject clonedProject = mainDoc.VbaProject.Clone();

        // Create a new blank document and assign the cloned VBA project.
        Document clonedDoc = new Document();
        clonedDoc.VbaProject = clonedProject;

        // Insert another document at the beginning of the cloned document.
        Document insertDoc = new Document("Insert.docx");
        DocumentBuilder builder = new DocumentBuilder(clonedDoc);
        builder.MoveToDocumentStart();
        builder.InsertDocument(insertDoc, ImportFormatMode.KeepSourceFormatting);

        // Append a third document at the end of the cloned document.
        Document appendDoc = new Document("Append.docx");
        clonedDoc.AppendDocument(appendDoc, ImportFormatMode.KeepSourceFormatting);

        // Save the combined document (still macro-enabled to retain VBA).
        clonedDoc.Save("Combined.docm");

        // Split the combined document into separate documents, each containing a single section.
        List<Document> splitDocs = SplitDocumentBySection(clonedDoc);

        // Save each split part.
        for (int i = 0; i < splitDocs.Count; i++)
        {
            splitDocs[i].Save($"Part_{i + 1}.docx");
        }
    }

    // Splits a document into a list of documents, each containing one section from the source.
    static List<Document> SplitDocumentBySection(Document source)
    {
        List<Document> parts = new List<Document>();

        foreach (Section section in source.Sections)
        {
            // Create a new empty document for the current section.
            Document part = new Document();

            // Import the section into the new document, preserving formatting.
            NodeImporter importer = new NodeImporter(source, part, ImportFormatMode.KeepSourceFormatting);
            Section importedSection = (Section)importer.ImportNode(section, true);

            // Add the imported section to the new document.
            part.AppendChild(importedSection);
            parts.Add(part);
        }

        return parts;
    }
}
