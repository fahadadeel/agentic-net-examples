using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationMediaFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output directory for the generated PPTX file
            string outDir = "Output";
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            // Directory containing EMF image files
            string dataDir = "Data";
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get all EMF files from the data directory
            string[] emfFiles = Directory.GetFiles(dataDir, "*.emf");

            foreach (string emfPath in emfFiles)
            {
                // Read EMF file into a byte array
                byte[] imageData = File.ReadAllBytes(emfPath);

                // Add the EMF image to the presentation's image collection
                Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);

                // Add a new empty slide to host the image
                Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

                // Insert the image as a picture frame covering the entire slide
                slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    0,
                    0,
                    pres.SlideSize.Size.Width,
                    pres.SlideSize.Size.Height,
                    img);
            }

            // Save the presentation in PPTX format
            string outPath = Path.Combine(outDir, "AddEmfImages_out.pptx");
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            pres.Dispose();
        }
    }
}