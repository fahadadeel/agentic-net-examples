using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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
            50f, 50f, 500f, 400f);

        // Enable and set the chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sales Data");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

        // Add a callout shape pointing to a data point
        Aspose.Slides.IAutoShape callout = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Callout1,
            300f, 150f, 200f, 100f);
        callout.TextFrame.Text = "Important point";

        // Set callout line format
        callout.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        callout.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;

        // Set callout fill format
        callout.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        callout.FillFormat.SolidFillColor.Color = Color.LightYellow;

        // Save the presentation to a file
        presentation.Save("ManageCallouts_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}