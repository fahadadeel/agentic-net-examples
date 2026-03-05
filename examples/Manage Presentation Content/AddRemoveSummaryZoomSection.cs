using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // ----- Create sections with distinct background colors -----
        // Section 1 (first slide already exists)
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Red;
        Aspose.Slides.ISection section1 = presentation.Sections.AddSection("Section 1", slide);

        // Section 2
        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Green;
        Aspose.Slides.ISection section2 = presentation.Sections.AddSection("Section 2", slide);

        // Section 3
        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;
        Aspose.Slides.ISection section3 = presentation.Sections.AddSection("Section 3", slide);

        // Section 4
        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.Yellow;
        Aspose.Slides.ISection section4 = presentation.Sections.AddSection("Section 4", slide);

        // ----- Add Summary Zoom frame on the first slide -----
        Aspose.Slides.ISummaryZoomFrame summaryZoom = presentation.Slides[0].Shapes.AddSummaryZoomFrame(50f, 50f, 400f, 300f);

        // ----- Add a Summary Zoom Section for Section 2 -----
        Aspose.Slides.ISummaryZoomSection addedSection = summaryZoom.SummaryZoomCollection.AddSummaryZoomSection(section2);

        // ----- Remove the same Summary Zoom Section -----
        summaryZoom.SummaryZoomCollection.RemoveSummaryZoomSection(section2);

        // ----- Save the presentation -----
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "AddRemoveSummaryZoomSection_out.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}