using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50,   // X position
            50,   // Y position
            500,  // Width
            400   // Height
        );

        // Customize the chart border
        chart.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        chart.LineFormat.Style = Aspose.Slides.LineStyle.Single;

        // Enable rounded corners for the chart area
        chart.HasRoundedCorners = true;

        // Set a solid fill color for the chart area
        chart.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        chart.FillFormat.SolidFillColor.Color = Color.LightBlue;

        // Save the presentation to a PPTX file
        presentation.Save("CustomizedChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}