using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace ChartCategoryAnimationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);

                // Apply a fade effect to the whole chart
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Get the main sequence as a concrete Sequence object
                Aspose.Slides.Animation.Sequence sequence = (Aspose.Slides.Animation.Sequence)slide.Timeline.MainSequence;

                // Determine counts of categories and series
                int categoryCount = chart.ChartData.Categories.Count;
                int seriesCount = chart.ChartData.Series.Count;

                // Animate each data point (by element in category)
                for (int cat = 0; cat < categoryCount; cat++)
                {
                    for (int ser = 0; ser < seriesCount; ser++)
                    {
                        sequence.AddEffect(
                            chart,
                            Aspose.Slides.Animation.EffectChartMinorGroupingType.ByElementInCategory,
                            ser,
                            cat,
                            Aspose.Slides.Animation.EffectType.Appear,
                            Aspose.Slides.Animation.EffectSubtype.None,
                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                    }
                }

                // Save the presentation
                presentation.Save("ChartCategoryAnimation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}