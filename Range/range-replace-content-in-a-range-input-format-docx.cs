using System;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Replacing;

class Program
{
    static void Main()
    {
        // Load the source DOCX file.
        Document doc = new Document("Input.docx");

        // Obtain the range that represents the whole document.
        // Use 'var' (or a fully‑qualified type) to avoid the System.Range conflict.
        var range = doc.Range;

        // Replace all occurrences of a literal string.
        range.Replace("Hello", "Hi");

        // Replace using a regular expression with custom find/replace options.
        FindReplaceOptions options = new FindReplaceOptions
        {
            // Example option: case‑insensitive search.
            MatchCase = false
        };
        range.Replace(new Regex(@"\bWorld\b"), "Universe", options);

        // Save the modified document.
        doc.Save("Output.docx");
    }
}
