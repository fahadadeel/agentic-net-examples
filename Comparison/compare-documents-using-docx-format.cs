using System;
using Aspose.Words;
using Aspose.Words.Comparing;

class DocumentComparison
{
    static void Main()
    {
        // Paths to the source documents and the result document.
        string originalPath = @"C:\Docs\Original.docx";
        string revisedPath  = @"C:\Docs\Revised.docx";
        string resultPath   = @"C:\Docs\ComparisonResult.docx";

        // Load the two documents that will be compared.
        Document original = new Document(originalPath);
        Document revised  = new Document(revisedPath);

        // Configure comparison options.
        CompareOptions options = new CompareOptions
        {
            // Track changes at the word level.
            Granularity = Granularity.WordLevel,
            // Do not ignore formatting changes.
            IgnoreFormatting = false,
            // Compare the revised document as the base (equivalent to Word's "Show changes in" = New).
            Target = ComparisonTargetType.New,
            // Example: ignore case changes.
            IgnoreCaseChanges = true,
            // Example: ignore comments.
            IgnoreComments = false,
            // Example: ignore tables.
            IgnoreTables = false,
            // Example: ignore footnotes and endnotes.
            IgnoreFootnotes = false,
            // Example: ignore text boxes.
            IgnoreTextboxes = false,
            // Example: ignore headers and footers.
            IgnoreHeadersAndFooters = false,
            // Example: ignore moves.
            CompareMoves = false
        };

        // Perform the comparison. The revisions are added to the original document.
        original.Compare(revised, "Comparer", DateTime.Now, options);

        // Save the document that now contains revision marks.
        original.Save(resultPath);
    }
}
