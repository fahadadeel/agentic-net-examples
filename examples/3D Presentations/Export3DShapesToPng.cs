using System;
using System.IO;

namespace Export3DShapesToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file
            string inputPath = "input.pptx";
            // Output folder for PNG images
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    bool has3D = false;

                    // Check if the shape itself has 3D formatting
                    if (shape.ThreeDFormat != null)
                    {
                        has3D = true;
                    }
                    else if (shape is Aspose.Slides.IAutoShape)
                    {
                        // Check if the shape contains text with 3D formatting
                        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                        if (autoShape.TextFrame != null && autoShape.TextFrame.Text != null && autoShape.TextFrame.Text.Length > 0)
                        {
                            if (autoShape.TextFrame.TextFrameFormat != null && autoShape.TextFrame.TextFrameFormat.ThreeDFormat != null)
                            {
                                has3D = true;
                            }
                        }
                    }

                    if (has3D)
                    {
                        // Export the shape (including its 3D effect) as a PNG image
                        using (Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 2f, 2f))
                        {
                            string pngPath = Path.Combine(outputFolder, $"slide_{slideIndex}_shape_{shapeIndex}.png");
                            shapeImage.Save(pngPath, Aspose.Slides.ImageFormat.Png);
                        }
                    }
                }
            }

            // Save the (potentially unchanged) presentation before exiting
            string savedPptxPath = Path.Combine(outputFolder, "processed.pptx");
            pres.Save(savedPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}