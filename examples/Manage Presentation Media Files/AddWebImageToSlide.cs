using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // URL of the image to be added
        string imageUrl = "https://example.com/image.jpg";

        // Download the image data into a byte array
        byte[] imageBytes;
        using (HttpClient httpClient = new HttpClient())
        {
            Task<byte[]> downloadTask = httpClient.GetByteArrayAsync(imageUrl);
            downloadTask.Wait();
            imageBytes = downloadTask.Result;
        }

        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Add the downloaded image to the presentation
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageBytes);

            // Get the first slide in the presentation
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Insert the image onto the slide as a picture frame
            slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300, image);

            // Save the presentation to a PPTX file
            presentation.Save("PresentationWithWebImage.pptx", SaveFormat.Pptx);
        }
    }
}