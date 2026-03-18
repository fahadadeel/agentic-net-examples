using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AddChartAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a clustered column chart to the slide
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

                    // Add an animation effect to the chart (animate by series on click)
                    ISequence mainSequence = slide.Timeline.MainSequence;
                    mainSequence.AddEffect(
                        chart,
                        EffectChartMajorGroupingType.BySeries,
                        0,
                        EffectType.Fade,
                        EffectSubtype.None,
                        EffectTriggerType.OnClick);

                    // Save the presentation
                    presentation.Save("ChartAnimation_out.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}