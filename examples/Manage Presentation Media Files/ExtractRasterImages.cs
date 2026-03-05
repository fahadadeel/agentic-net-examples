using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input presentation and output directory
        string inputPath = "input.pptx";
        string outputDir = "ExtractedImages";

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        int imageIndex = 0;

        // Iterate through all slides and shapes
        foreach (Aspose.Slides.ISlide slide in pres.Slides)
        {
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Check if the shape is a picture frame
                Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                if (pictureFrame != null)
                {
                    // Get the embedded image
                    Aspose.Slides.IPPImage ppImage = pictureFrame.PictureFormat.Picture.Image;

                    // Retrieve the binary data of the image
                    byte[] imageData = ppImage.BinaryData;

                    // Determine file extension from content type (e.g., "image/png" -> ".png")
                    string extension = ".bin";
                    string contentType = ppImage.ContentType;
                    if (!string.IsNullOrEmpty(contentType))
                    {
                        int slashPos = contentType.LastIndexOf('/');
                        if (slashPos >= 0 && slashPos < contentType.Length - 1)
                        {
                            extension = "." + contentType.Substring(slashPos + 1);
                        }
                    }

                    // Save the image to the output directory
                    string outPath = Path.Combine(outputDir, $"image_{imageIndex}{extension}");
                    File.WriteAllBytes(outPath, imageData);
                    imageIndex++;
                }
            }
        }

        // Save the (unchanged) presentation before exiting
        string savedPath = Path.Combine(outputDir, "presentation_saved.pptx");
        pres.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
    }
}