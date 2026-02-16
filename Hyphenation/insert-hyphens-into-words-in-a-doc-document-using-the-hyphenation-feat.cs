using System;
using Aspose.Words;

namespace HyphenationExample
{
    class Program
    {
        static void Main()
        {
            // Create a new blank document.
            Document doc = new Document();

            // Initialize a DocumentBuilder to add content.
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Write a paragraph of sample text.
            builder.Font.Size = 24;
            builder.Writeln("Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                            "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");

            // Enable automatic hyphenation and configure its options.
            doc.HyphenationOptions.AutoHyphenation = true;          // Turn on hyphenation.
            doc.HyphenationOptions.ConsecutiveHyphenLimit = 2;     // Max consecutive hyphenated lines.
            doc.HyphenationOptions.HyphenationZone = 720;          // 0.5 inch from right margin.
            doc.HyphenationOptions.HyphenateCaps = true;           // Hyphenate all‑caps words.

            // Save the document to a file.
            doc.Save("HyphenatedDocument.docx");
        }
    }
}
