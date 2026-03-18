using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace MathEquationInspector
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputPath = args.Length > 0 ? args[0] : "input.pptx";
                using (var presentation = new Presentation(inputPath))
                {
                    for (var i = 0; i < presentation.Slides.Count; i++)
                    {
                        var slide = presentation.Slides[i];
                        for (var j = 0; j < slide.Shapes.Count; j++)
                        {
                            var shape = slide.Shapes[j];
                            if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                            {
                                var paragraphs = autoShape.TextFrame.Paragraphs;
                                for (var p = 0; p < paragraphs.Count; p++)
                                {
                                    var portions = paragraphs[p].Portions;
                                    for (var q = 0; q < portions.Count; q++)
                                    {
                                        if (portions[q] is MathPortion mathPortion)
                                        {
                                            var mathParagraph = mathPortion.MathParagraph;
                                            var latex = mathParagraph.ToLatex();
                                            Console.WriteLine($"Slide {i + 1}, Shape {j + 1}, Equation {q + 1}: {latex}");
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the presentation after processing
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}