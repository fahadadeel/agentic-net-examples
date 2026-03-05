using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace LoadMathEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string dataDir = @"C:\Data\";
            string sourcePath = Path.Combine(dataDir, "input.pptx");
            // Load the presentation from file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Iterate through all slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Process only AutoShape objects that contain a TextFrame
                        if (shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            if (autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
                            {
                                Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                                // Iterate through portions to find MathPortion instances
                                foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                                {
                                    Aspose.Slides.MathText.MathPortion mathPortion = portion as Aspose.Slides.MathText.MathPortion;
                                    if (mathPortion != null)
                                    {
                                        // Retrieve the mathematical paragraph and convert to LaTeX
                                        Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                        string latex = mathParagraph.ToLatex();
                                        Console.WriteLine("Equation LaTeX: " + latex);
                                    }
                                }
                            }
                        }
                    }
                }
                // Save the (potentially unchanged) presentation
                string outputPath = Path.Combine(dataDir, "output.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}