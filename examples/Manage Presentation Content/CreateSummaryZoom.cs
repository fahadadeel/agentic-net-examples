using System;
using System.IO;
using Aspose.Slides;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Configure the first slide (belongs to the first section)
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
            Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide);

            // Add second slide and section
            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Green;
            Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide);

            // Add third slide and section
            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
            Aspose.Slides.ISection section3 = presentation.Sections.AddSection("Section 3", slide);

            // Add fourth slide and section
            slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;
            Aspose.Slides.ISection section4 = presentation.Sections.AddSection("Section 4", slide);

            // Add Summary Zoom frame to the first slide
            Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(150f, 20f, 500f, 250f);

            // Save the presentation
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SummaryZoom_out.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}