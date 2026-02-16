using System;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;

class WatermarkExample
{
    static void Main()
    {
        // Path to the folder where the document will be saved.
        string outputPath = @"C:\Output\Watermarked.docx";

        // Create a new blank document.
        Document doc = new Document();

        // Configure text watermark options.
        TextWatermarkOptions options = new TextWatermarkOptions
        {
            FontFamily = "Arial",
            FontSize = 36,
            Color = Color.Gray,
            Layout = WatermarkLayout.Diagonal,
            IsSemitrasparent = false
        };

        // Add the text watermark to the document.
        doc.Watermark.SetText("Confidential", options);

        // Save the document in DOCX format.
        doc.Save(outputPath);
    }
}
