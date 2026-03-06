using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ApplyFaqPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the directory containing the source presentation
            string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
            // Define the full path to the source PPTX file
            string sourcePath = Path.Combine(dataDir, "input.pptx");
            // Define the full path for the output PPTX file
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Load the presentation from the specified file
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath);

            // Iterate through each slide in the presentation
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                // Get the current slide as IBaseSlide
                Aspose.Slides.IBaseSlide slide = pres.Slides[i];
                // Retrieve all text boxes (text frames) on the slide
                Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

                // Process each text frame (e.g., output its text to console)
                for (int j = 0; j < textFrames.Length; j++)
                {
                    Aspose.Slides.ITextFrame tf = textFrames[j];
                    // Concatenate all paragraphs and portions text
                    string slideText = "";
                    for (int p = 0; p < tf.Paragraphs.Count; p++)
                    {
                        Aspose.Slides.IParagraph para = tf.Paragraphs[p];
                        for (int pt = 0; pt < para.Portions.Count; pt++)
                        {
                            Aspose.Slides.IPortion portion = para.Portions[pt];
                            slideText += portion.Text;
                        }
                    }
                    Console.WriteLine("Slide {0}, TextBox {1}: {2}", i + 1, j + 1, slideText);
                }
            }

            // Save the (potentially modified) presentation to the output file
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            // Release resources
            pres.Dispose();
        }
    }
}