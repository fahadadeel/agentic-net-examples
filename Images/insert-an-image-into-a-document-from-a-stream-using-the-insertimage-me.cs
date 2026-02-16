using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;

class Program
{
    static void Main()
    {
        // Create a new empty document.
        Document doc = new Document();

        // Use DocumentBuilder to add content to the document.
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Open an image file as a stream. Replace the path with your image source.
        using (FileStream imageStream = File.OpenRead("sample_image.png"))
        {
            // Insert the image from the stream into the document.
            // The method returns the Shape that represents the inserted picture.
            Shape picture = builder.InsertImage(imageStream);

            // Example: set the picture to be inline with text.
            picture.WrapType = WrapType.Inline;
        }

        // Save the resulting document to disk.
        doc.Save("Result.docx");
    }
}
