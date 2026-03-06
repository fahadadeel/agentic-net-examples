using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;

namespace AnimatedChartOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            System.String inputPath = "input.pptx";
            System.String outputPath = "AnimatedChartOverview_out.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Try to get the first shape as a chart
            Aspose.Slides.IShape shape = slide.Shapes[0];
            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

            // If there is no chart, add a sample chart
            if (chart == null)
            {
                chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    0f, 0f, 500f, 400f);
            }

            // Add a fade effect for the whole chart
            slide.Timeline.MainSequence.AddEffect(
                chart,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Animate each series
            System.Int32 seriesCount = chart.ChartData.Series.Count;
            for (System.Int32 s = 0; s < seriesCount; s++)
            {
                ((Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence).AddEffect(
                    chart,
                    Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                    s,
                    Aspose.Slides.Animation.EffectType.Appear,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
            }

            // Animate each data point within each series
            for (System.Int32 s = 0; s < seriesCount; s++)
            {
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[s];
                System.Int32 pointCount = series.DataPoints.Count;
                for (System.Int32 p = 0; p < pointCount; p++)
                {
                    ((Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence).AddEffect(
                        chart,
                        Aspose.Slides.Animation.EffectChartMinorGroupingType.ByElementInSeries,
                        s,
                        p,
                        Aspose.Slides.Animation.EffectType.Appear,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                }
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}