using System;
using Aspose.Words;
using Aspose.Words.Settings;

class HyphenationExample
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a paragraph that contains long words which may be hyphenated.
        builder.Font.Size = 24;
        builder.Writeln("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");

        // Turn on automatic hyphenation for the whole document.
        doc.HyphenationOptions.AutoHyphenation = true;

        // Optional: adjust hyphenation settings.
        doc.HyphenationOptions.HyphenationZone = 720;          // Distance from right margin (0.5 inch).
        doc.HyphenationOptions.ConsecutiveHyphenLimit = 2;    // Max consecutive hyphenated lines.

        // Save the resulting document.
        doc.Save("HyphenatedDocument.docx");
    }
}
