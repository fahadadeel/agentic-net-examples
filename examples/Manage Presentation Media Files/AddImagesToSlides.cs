using System;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Download image data from the web
        System.Net.WebClient client = new System.Net.WebClient();
        byte[] imageData = client.DownloadData("https://example.com/image.jpg");
        client.Dispose();

        // Add the downloaded image to the presentation's image collection
        Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);

        // Insert a picture frame on the slide using the added image
        slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50,    // X position
            50,    // Y position
            img.Width,
            img.Height,
            img);

        // Save the presentation to a PPTX file
        pres.Save("WebImagePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}