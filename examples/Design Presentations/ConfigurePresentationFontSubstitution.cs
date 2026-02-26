using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontSubstitutionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Define source and destination fonts
            Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Arial");
            Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("Times New Roman");

            // Create a font substitution rule
            Aspose.Slides.FontSubstRule substitutionRule = new Aspose.Slides.FontSubstRule(sourceFont, destFont);

            // Apply the substitution rule to the presentation
            presentation.FontsManager.ReplaceFont(substitutionRule);

            // List current font substitutions
            foreach (Aspose.Slides.FontSubstitutionInfo info in presentation.FontsManager.GetSubstitutions())
            {
                Console.WriteLine("{0} -> {1}", info.OriginalFontName, info.SubstitutedFontName);
            }

            // Save the presentation
            presentation.Save("FontSubstitutionOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}