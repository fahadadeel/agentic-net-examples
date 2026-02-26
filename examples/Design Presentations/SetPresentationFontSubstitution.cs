using System;

class Program
{
    static void Main()
    {
        // Create a new empty presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Define the source (missing) font and the substitute font
        Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("MissingFont");
        Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("Arial");

        // Create a substitution rule that triggers when the source font is not found
        Aspose.Slides.IFontSubstRule substRule = new Aspose.Slides.FontSubstRule(sourceFont, destFont, Aspose.Slides.FontSubstCondition.WhenInaccessible);

        // Create a collection for substitution rules and add the rule
        Aspose.Slides.IFontSubstRuleCollection substRules = new Aspose.Slides.FontSubstRuleCollection();
        substRules.Add(substRule);

        // Assign the substitution rule list to the presentation's FontsManager
        pres.FontsManager.FontSubstRuleList = substRules;

        // Save the presentation before exiting
        pres.Save("SubstitutedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}