using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractFlashObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for extracted flash files
            string outputDir = "FlashOutput";
            Directory.CreateDirectory(outputDir);

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    // Get the collection of ActiveX controls on the current slide
                    IControlCollection controls = pres.Slides[slideIndex].Controls;
                    Control flashControl = null;

                    // Find the ShockwaveFlash control by name
                    foreach (IControl control in controls)
                    {
                        if (control.Name == "ShockwaveFlash1")
                        {
                            flashControl = (Control)control;
                            break;
                        }
                    }

                    // If a flash control is found, extract its binary data
                    if (flashControl != null)
                    {
                        byte[] flashData = flashControl.ActiveXControlBinary;
                        string flashFilePath = Path.Combine(outputDir, $"flash_slide{slideIndex}.swf");
                        using (FileStream fs = new FileStream(flashFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            fs.Write(flashData, 0, flashData.Length);
                        }
                    }
                }

                // Save the presentation (required by lifecycle rules)
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
    }
}