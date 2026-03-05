using System;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;
using System.Drawing;

namespace SetTextTransparency
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Get the first shape on the first slide (assumed to be an AutoShape with text)
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)pres.Slides[0].Shapes[0];

            // Access the effect format of the first portion of the first paragraph
            Aspose.Slides.IEffectFormat effectFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EffectFormat;

            // Get the outer shadow effect
            Aspose.Slides.Effects.IOuterShadow outerShadow = effectFormat.OuterShadowEffect;

            // Retrieve the current shadow color
            System.Drawing.Color shadowColor = outerShadow.ShadowColor.Color;

            // Set the shadow color with an alpha value to define transparency (e.g., 128 out of 255)
            outerShadow.ShadowColor.Color = System.Drawing.Color.FromArgb(128, shadowColor);

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}