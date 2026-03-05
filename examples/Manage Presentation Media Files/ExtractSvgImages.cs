using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractSvgImages
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for extracted SVG files
            string outputDir = "ExtractedSvgs";

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];

                    // Iterate through shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is a picture frame
                        IPictureFrame pictureFrame = shape as IPictureFrame;
                        if (pictureFrame != null)
                        {
                            // Get the image associated with the picture frame
                            IPPImage image = pictureFrame.PictureFormat.Picture.Image;

                            // Check if the image contains an SVG representation
                            if (image.SvgImage != null)
                            {
                                // Retrieve SVG content
                                string svgContent = image.SvgImage.SvgContent;

                                // Build output file name
                                string svgFileName = $"slide{slideIndex + 1}_shape{shapeIndex + 1}.svg";
                                string svgFilePath = Path.Combine(outputDir, svgFileName);

                                // Write SVG content to file
                                File.WriteAllText(svgFilePath, svgContent);
                            }
                        }
                    }
                }

                // Save the presentation (required by authoring rules)
                string savedPath = "output.pptx";
                pres.Save(savedPath, SaveFormat.Pptx);
            }
        }
    }
}