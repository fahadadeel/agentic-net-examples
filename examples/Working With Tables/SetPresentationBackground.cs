using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Set the slide background to a solid light gray color
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.LightGray;

            // Define column widths and row heights for the table
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 30, 30 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 100, columnWidths, rowHeights);

            // Apply a built‑in style to the table
            table.StylePreset = TableStylePreset.LightStyle1Accent1;

            // Save the presentation
            presentation.Save("TableWithBackground.pptx", SaveFormat.Pptx);
        }
    }
}