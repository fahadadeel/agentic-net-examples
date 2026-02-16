using System;
using Aspose.Words;
using Aspose.Words.Drawing;

class InsertImageExample
{
    static void Main()
    {
        // Create a new empty document.
        Document doc = new Document();

        // Initialize a DocumentBuilder for the document.
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Path to the image file to be inserted.
        string imagePath = @"C:\Images\Sample.jpg";

        // Insert the image into the document. The method returns the Shape that represents the image.
        Shape imageShape = builder.InsertImage(imagePath);

        // Example: set the image to be inline with text (default behavior).
        // imageShape.WrapType = WrapType.Inline;

        // Save the document with the inserted image.
        doc.Save(@"C:\Output\DocumentWithImage.docx");
    }
}
