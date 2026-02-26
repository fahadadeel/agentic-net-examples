using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationContent
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output directory
            string outDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            // Output file path (PPT format)
            string resultPath = Path.Combine(outDir, "SectionZoom.ppt");

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a slide that will belong to the new section
            Aspose.Slides.ISlide sectionSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

            // Add a second slide that the section zoom will navigate to
            Aspose.Slides.ISlide targetSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

            // Add a section containing the first slide
            Aspose.Slides.ISection section = pres.Sections.AddSection("Section 1", sectionSlide);

            // Load a custom image to be used in the section zoom frame
            string imagePath = Path.Combine(outDir, "image1.png"); // Ensure this image exists
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);

            // Add a Section Zoom frame on the first slide with the custom image
            Aspose.Slides.ISectionZoomFrame zoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(100, 100, 200, 100, section, ppImg);

            // Save the presentation in PPT format
            pres.Save(resultPath, Aspose.Slides.Export.SaveFormat.Ppt);

            // Clean up
            pres.Dispose();
        }
    }
}