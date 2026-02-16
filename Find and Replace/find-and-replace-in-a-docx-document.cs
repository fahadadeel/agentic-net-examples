using System;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Replacing;

class FindAndReplaceExample
{
    static void Main()
    {
        // Path to the folder that contains the input document.
        string docsPath = @"C:\Docs\";

        // Load the existing DOCX document.
        Document doc = new Document(docsPath + "Input.docx");

        // Configure find/replace options (optional).
        FindReplaceOptions options = new FindReplaceOptions
        {
            // Example: make the search case‑insensitive.
            MatchCase = false,
            // Example: replace whole words only.
            FindWholeWordsOnly = true
        };

        // Perform the replacement using a regular expression.
        // This will replace every occurrence of "old text" with "new text".
        doc.Range.Replace(new Regex(@"old text", RegexOptions.IgnoreCase), "new text", options);

        // Save the modified document.
        doc.Save(docsPath + "Output.docx");
    }
}
