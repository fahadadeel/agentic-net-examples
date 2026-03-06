using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a chart to the first slide
        IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Set the data range for the chart
        ((ChartData)chart.ChartData).SetRange("Sheet1!$A$1:$C$4");

        // Save the presentation
        pres.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
    }
}