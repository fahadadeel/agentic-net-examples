using System;

class Program
{
    static void Main()
    {
        // Input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Define source and destination fonts
        Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Arial");
        Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("Times New Roman");

        // Create a font substitution rule (replace when the source font is inaccessible)
        Aspose.Slides.IFontSubstRule substRule = new Aspose.Slides.FontSubstRule(sourceFont, destFont, Aspose.Slides.FontSubstCondition.WhenInaccessible);

        // Create a collection of substitution rules and add the rule
        Aspose.Slides.IFontSubstRuleCollection substRules = new Aspose.Slides.FontSubstRuleCollection();
        substRules.Add(substRule);

        // Assign the substitution rules to the presentation
        pres.FontsManager.FontSubstRuleList = substRules;

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}