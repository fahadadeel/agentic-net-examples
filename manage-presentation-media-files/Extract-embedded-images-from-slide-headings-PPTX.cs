using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        try
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Directory to store extracted images
            string outputDir = "ExtractedImages";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Find shapes that are title placeholders (headings)
                Aspose.Slides.IShape[] titleShapes = Aspose.Slides.Util.SlideUtil.FindShapesByPlaceholderType(
                    slide,
                    Aspose.Slides.PlaceholderType.Title);

                // Process each title shape
                foreach (Aspose.Slides.IShape shape in titleShapes)
                {
                    // If the shape is a picture frame, extract its image
                    Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                    if (pictureFrame != null)
                    {
                        Aspose.Slides.IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                        if (image != null)
                        {
                            string imageFileName = $"slide{slideIndex + 1}_title_{pictureFrame.Name}.png";
                            string imagePath = Path.Combine(outputDir, imageFileName);

                            // Save the image binary data to a file
                            using (FileStream fileStream = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
                            {
                                fileStream.Write(image.BinaryData, 0, image.BinaryData.Length);
                            }
                        }
                    }
                }
            }

            // Save the (unchanged) presentation before exiting
            string savedPresentationPath = Path.Combine(outputDir, "presentation_saved.pptx");
            presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}