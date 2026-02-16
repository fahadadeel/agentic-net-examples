using System;
using Aspose.Words;
using Aspose.Words.Fonts;
using Aspose.Words.Loading;

class FontLoadingExample
{
    static void Main()
    {
        // Path to the input DOCX file.
        string inputPath = @"C:\Docs\InputDocument.docx";

        // Path to the output file (any format supported by Aspose.Words, e.g., PDF).
        string outputPath = @"C:\Docs\OutputDocument.pdf";

        // Create LoadOptions and assign FontSettings that include system fonts.
        LoadOptions loadOptions = new LoadOptions();

        // Initialize FontSettings. By default it already contains a SystemFontSource,
        // but we explicitly reset to ensure only the system fonts are used.
        FontSettings fontSettings = new FontSettings();
        fontSettings.ResetFontSources(); // Clears any custom sources and adds the default system source.

        // Optionally, you can verify the system font source.
        // FontSourceBase[] sources = fontSettings.GetFontsSources();
        // SystemFontSource systemSource = (SystemFontSource)sources[0];

        // Assign the FontSettings to the LoadOptions.
        loadOptions.FontSettings = fontSettings;

        // Load the DOCX document using the configured LoadOptions.
        Document doc = new Document(inputPath, loadOptions);

        // Save the document to the desired format.
        doc.Save(outputPath);
    }
}
