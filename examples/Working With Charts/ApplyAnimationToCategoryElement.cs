using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define data directory and output file name
        string dataDir = "Data/";
        string outputChartFile = "AnimatedChart.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a chart to the slide
        Aspose.Slides.IShapeCollection shapes = slide.Shapes;
        Aspose.Slides.Charts.IChart chart = shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Add an initial fade effect to the chart
        slide.Timeline.MainSequence.AddEffect(chart, Aspose.Slides.Animation.EffectType.Fade, Aspose.Slides.Animation.EffectSubtype.None, Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Get the main sequence as a Sequence object
        Aspose.Slides.Animation.Sequence seq = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

        // Determine the number of categories and series
        int categoryCount = chart.ChartData.Categories.Count;
        int seriesCount = chart.ChartData.Series.Count;

        // Animate each element in each category
        for (int cat = 0; cat < categoryCount; cat++)
        {
            for (int ser = 0; ser < seriesCount; ser++)
            {
                seq.AddEffect(chart,
                    Aspose.Slides.Animation.EffectChartMinorGroupingType.ByElementInCategory,
                    ser,
                    cat,
                    Aspose.Slides.Animation.EffectType.Appear,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
            }
        }

        // Save the presentation
        presentation.Save(dataDir + outputChartFile, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}