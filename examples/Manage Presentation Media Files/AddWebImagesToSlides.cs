using System;
using System.Net;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // URL of the image to download
        string imageUrl = "https://example.com/image.jpg";

        // Download image data from the web
        System.Net.WebClient webClient = new System.Net.WebClient();
        byte[] imageBytes = webClient.DownloadData(imageUrl);
        webClient.Dispose();

        // Add the downloaded image to the presentation's image collection
        Aspose.Slides.IPPImage ipImage = presentation.Images.AddImage(imageBytes);

        // Insert the image onto the slide as a picture frame
        slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50f, 150f, 300f, 200f, ipImage);

        // Save the presentation to a file
        string outputPath = "AddWebImages_out.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}