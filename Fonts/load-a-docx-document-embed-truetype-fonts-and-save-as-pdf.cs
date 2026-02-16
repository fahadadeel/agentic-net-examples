using System.IO;
using Aspose.Words;
using Aspose.Words.Saving;

class EmbedFontsToPdf
{
    static void Main()
    {
        // Paths to the input DOCX and the output PDF.
        string dataDir = @"C:\Docs\";
        string inputPath = Path.Combine(dataDir, "input.docx");
        string outputPath = Path.Combine(dataDir, "output.pdf");

        // Load the DOCX document.
        Document doc = new Document(inputPath);

        // Configure PDF save options to embed all TrueType fonts.
        PdfSaveOptions pdfOptions = new PdfSaveOptions
        {
            // Embed every font used in the document.
            FontEmbeddingMode = PdfFontEmbeddingMode.EmbedAll,
            // Embed the full font data (not just subsets).
            EmbedFullFonts = true,
            // Allow embedding of fonts that have PostScript outlines.
            AllowEmbeddingPostScriptFonts = true
        };

        // Save the document as PDF with the specified options.
        doc.Save(outputPath, pdfOptions);
    }
}
