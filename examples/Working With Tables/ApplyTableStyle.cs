using System;
using Aspose.Slides;
using Aspose.Slides.Export;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Apply a predefined table style
        table.StylePreset = Aspose.Slides.TableStylePreset.MediumStyle2Accent1;

        // Save the presentation
        presentation.Save("ApplyTableStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}