using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AddChartSeriesAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

                // Add animation to the chart series (animate by series)
                IAnimationTimeLine timeline = slide.Timeline;
                timeline.MainSequence.AddEffect(
                    chart,
                    EffectChartMajorGroupingType.BySeries,
                    0, // series index (first series)
                    EffectType.Fly,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Save the presentation
                presentation.Save("ChartSeriesAnimation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}