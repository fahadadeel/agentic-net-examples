using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            Presentation pres = new Presentation();
            ISlide slide = pres.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
            IAxis categoryAxis = chart.Axes.HorizontalAxis;
            categoryAxis.CategoryAxisType = CategoryAxisType.Date;
            categoryAxis.NumberFormat = "dd-MMM-yyyy";
            pres.Save("CategoryAxisDateFormat.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}