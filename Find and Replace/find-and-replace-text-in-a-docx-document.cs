using System;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Replacing;

namespace AsposeWordsFindReplaceExample
{
    class Program
    {
        static void Main()
        {
            // Load the existing DOCX document.
            Document doc = new Document("Input.docx");

            // Define the text to find and the replacement text.
            string findText = "old value";
            string replaceText = "new value";

            // Create FindReplaceOptions if you need to customize the operation.
            FindReplaceOptions options = new FindReplaceOptions();
            // Example: make the search case‑insensitive.
            options.MatchCase = false;

            // Perform a simple string replace.
            doc.Range.Replace(findText, replaceText, options);

            // Alternatively, you can use a regular expression.
            // Regex regex = new Regex(@"\bold\s+value\b", RegexOptions.IgnoreCase);
            // doc.Range.Replace(regex, replaceText, options);

            // Save the modified document.
            doc.Save("Output.docx");
        }
    }
}
