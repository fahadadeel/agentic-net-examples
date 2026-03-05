using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GetImageTransparency
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Assume the first shape on the first slide is a table whose fill transparency we want to read
            ISlide slide = pres.Slides[0];
            IShape shape = slide.Shapes[0];

            // Check if the shape is a table
            if (shape is ITable)
            {
                ITable table = (ITable)shape;

                // Get the transparency of the table fill
                float transparency = table.TableFormat.Transparency;

                // Output the transparency value
                Console.WriteLine("Table fill transparency: " + transparency);
            }
            else
            {
                Console.WriteLine("The first shape is not a table. Transparency retrieval not applicable.");
            }

            // Save the presentation before exiting
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}