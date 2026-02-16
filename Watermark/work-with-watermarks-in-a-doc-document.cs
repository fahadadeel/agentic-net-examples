using System;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Saving;

class Program
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();

        // ---------- Add a text watermark ----------
        // Simple watermark with default options.
        doc.Watermark.SetText("Confidential");

        // Watermark with custom formatting.
        TextWatermarkOptions textOptions = new TextWatermarkOptions
        {
            FontFamily = "Arial",
            FontSize = 48,
            Color = Color.Red,
            Layout = WatermarkLayout.Diagonal,
            IsSemitrasparent = false
        };
        doc.Watermark.SetText("Do Not Distribute", textOptions);

        // Save the document with the text watermark.
        string textWatermarkPath = "TextWatermark.docx";
        doc.Save(textWatermarkPath, SaveFormat.Docx);

        // ---------- Add an image watermark ----------
        // Load the previously saved document.
        Document imgDoc = new Document(textWatermarkPath);

        // Configure image watermark appearance.
        ImageWatermarkOptions imgOptions = new ImageWatermarkOptions
        {
            Scale = 5,          // Increase size of the image.
            IsWashout = false   // Do not apply washout effect.
        };

        // Add an image watermark from a file path.
        string imagePath = "logo.png"; // Ensure this file exists in the working directory.
        imgDoc.Watermark.SetImage(imagePath, imgOptions);

        // Save the document with both text and image watermarks.
        string imageWatermarkPath = "ImageWatermark.docx";
        imgDoc.Save(imageWatermarkPath, SaveFormat.Docx);

        // ---------- Remove a watermark ----------
        // Load the document that contains watermarks.
        Document removeDoc = new Document(imageWatermarkPath);

        // Check the type of the current watermark and remove it if it is a text watermark.
        if (removeDoc.Watermark.Type == WatermarkType.Text)
        {
            removeDoc.Watermark.Remove();
        }

        // Save the document after removal.
        string removedWatermarkPath = "WatermarkRemoved.docx";
        removeDoc.Save(removedWatermarkPath, SaveFormat.Docx);
    }
}
