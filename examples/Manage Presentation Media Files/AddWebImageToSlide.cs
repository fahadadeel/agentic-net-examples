using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // URL of the image to download
        string imageUrl = "https://example.com/image.jpg";

        // Download image data from the web
        HttpClient httpClient = new HttpClient();
        byte[] imageBytes = httpClient.GetByteArrayAsync(imageUrl).Result;

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add the downloaded image to the presentation
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageBytes);

        // Insert the image onto the first slide as a picture frame
        presentation.Slides[0].Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50,   // X position
            50,   // Y position
            400,  // Width
            300,  // Height
            image);

        // Save the presentation to a PPTX file
        presentation.Save("ImageFromWeb.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}