using System;
using Aspose.Words;
using Aspose.Words.Loading;
using Aspose.Words.Saving;
using Aspose.Words.Comparing;

class Program
{
    static void Main()
    {
        // Load an existing DOCX file (no password required for loading).
        LoadOptions loadOptions = new LoadOptions(); // default options
        Document docOriginal = new Document("Original.docx", loadOptions);

        // Add a new paragraph using DocumentBuilder (Builder Overview operation).
        DocumentBuilder builder = new DocumentBuilder(docOriginal);
        builder.Writeln("This is a new paragraph added for demonstration.");

        // Apply write protection with a password and recommend read‑only opening.
        docOriginal.WriteProtection.SetPassword("writePass");
        docOriginal.WriteProtection.ReadOnlyRecommended = true;

        // Save the document with encryption (password protection) using OoxmlSaveOptions.
        OoxmlSaveOptions encryptOptions = new OoxmlSaveOptions
        {
            Password = "encryptPass" // encrypts the saved file with ECMA376 standard encryption
        };
        docOriginal.Save("ProtectedEncrypted.docx", encryptOptions);

        // Create a modified copy of the original document to compare against.
        Document docEdited = (Document)docOriginal.Clone(true);
        DocumentBuilder editBuilder = new DocumentBuilder(docEdited);
        editBuilder.Writeln("An additional line that will be detected as a change.");

        // Configure comparison options (e.g., track changes at word level, compare moves, etc.).
        CompareOptions compareOptions = new CompareOptions
        {
            CompareMoves = true,
            Granularity = Granularity.WordLevel,
            IgnoreFormatting = false,
            IgnoreCaseChanges = false,
            Target = ComparisonTargetType.New // use the edited document as the target
        };

        // Perform the comparison; revisions are added to docOriginal.
        docOriginal.Compare(docEdited, "Comparer", DateTime.Now, compareOptions);

        // Save the document that now contains revision marks showing the differences.
        docOriginal.Save("ComparisonResult.docx");
    }
}
