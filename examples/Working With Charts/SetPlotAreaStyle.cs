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

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

        // Set chart area line format
        chart.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        chart.LineFormat.Style = Aspose.Slides.LineStyle.Single;
        chart.HasRoundedCorners = true;

        // Set plot area fill to solid yellow
        chart.PlotArea.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        chart.PlotArea.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Yellow;

        // Set plot area border line
        chart.PlotArea.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        chart.PlotArea.Format.Line.Width = 2f;

        // Save the presentation
        presentation.Save("SetPlotAreaStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}