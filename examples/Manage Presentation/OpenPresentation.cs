using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Path to the password‑protected presentation
        string inputPath = "protected.pptx";
        string outputPath = "opened.pptx";
        string password = "myPassword";

        // Create LoadOptions and set the password
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.Password = password;

        // Open the presentation with the load options
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
        {
            // Perform any required operations on the presentation here

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }

        // Determine if the presentation is password protected
        Aspose.Slides.IPresentationInfo info = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);
        if (info.IsPasswordProtected)
        {
            Console.WriteLine("The presentation is password protected.");
        }
        else
        {
            Console.WriteLine("The presentation is not password protected.");
        }

        // Verify whether the provided password is correct
        bool isPasswordCorrect = info.CheckPassword(password);
        Console.WriteLine("Password correct: " + isPasswordCorrect);
    }
}