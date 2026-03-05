using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SectionZoomWithCustomImages
{
    class Program
    {
        static void Main()
        {
            // Define directories and file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string imagePath1 = Path.Combine(dataDir, "image1.png");
            string imagePath2 = Path.Combine(dataDir, "image2.png");
            string outputPath = Path.Combine(dataDir, "SectionZoomCustomImages.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // First slide already exists (index 0)
            Aspose.Slides.ISlide slide0 = presentation.Slides[0];

            // Add a slide for the first section
            Aspose.Slides.ISlide slide1 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            Aspose.Slides.ISection section1 = presentation.Sections.AddSection("First Section", slide1);

            // Add a slide for the second section
            Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Second Section", slide2);

            // Load custom images and add them to the presentation's image collection
            Aspose.Slides.IImage img1 = Aspose.Slides.Images.FromFile(imagePath1);
            Aspose.Slides.IPPImage ipImage1 = presentation.Images.AddImage(img1);
            Aspose.Slides.IImage img2 = Aspose.Slides.Images.FromFile(imagePath2);
            Aspose.Slides.IPPImage ipImage2 = presentation.Images.AddImage(img2);

            // Add Section Zoom frames on the first slide with custom images
            Aspose.Slides.ISectionZoomFrame zoomFrame1 = presentation.Slides[0].Shapes.AddSectionZoomFrame(50f, 50f, 100f, 100f, section1, ipImage1);
            Aspose.Slides.ISectionZoomFrame zoomFrame2 = presentation.Slides[0].Shapes.AddSectionZoomFrame(200f, 50f, 100f, 100f, section2, ipImage2);

            // Save the presentation in PPTX format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}