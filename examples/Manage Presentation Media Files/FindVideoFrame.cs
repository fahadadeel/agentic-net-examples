using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input PPTX file
        var inputPath = "input.pptx";

        // Load the presentation
        using (var pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                var slide = pres.Slides[slideIndex];

                // Iterate through all shapes on the current slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    var shape = slide.Shapes[shapeIndex];

                    // Check if the shape is a video frame
                    if (shape is Aspose.Slides.IVideoFrame videoFrame)
                    {
                        Console.WriteLine($"Video frame found on slide {slideIndex + 1}, shape index {shapeIndex}");

                        // Access embedded video information (if any)
                        var embeddedVideo = videoFrame.EmbeddedVideo;
                        if (embeddedVideo != null)
                        {
                            Console.WriteLine($"Embedded video content type: {embeddedVideo.ContentType}");
                        }
                    }
                }
            }

            // Save the (potentially unchanged) presentation
            pres.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}