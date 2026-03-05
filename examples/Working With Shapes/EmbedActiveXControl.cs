using System;
using System.IO;
using Aspose.Slides.Export;

namespace EmbedActiveXControlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string dataDir = Path.GetFullPath("Data");
            string inputPath = Path.Combine(dataDir, "TemplateWithActiveX.pptm");
            string outputPath = Path.Combine(dataDir, "ActiveXModified.pptm");

            // Load the presentation (must be PPTM to support ActiveX)
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Ensure there is at least one ActiveX control on the slide
            if (slide.Controls.Count > 0)
            {
                // Get the first control
                Aspose.Slides.IControl control = slide.Controls[0];

                // Example: set a property if the control supports property bags
                if (control.Name == "MyActiveXControl" && control.Properties != null)
                {
                    // Set a custom property (replace with actual property name/value as needed)
                    control.Properties["CustomProperty"] = "CustomValue";
                }

                // Modify the control's frame using a new ShapeFrame (cannot assign X/Y directly)
                Aspose.Slides.IShapeFrame newFrame = new Aspose.Slides.ShapeFrame(
                    control.Frame.X,                     // X position (unchanged)
                    control.Frame.Y + 20,                // Y position shifted down by 20 points
                    control.Frame.Width,                 // Width (unchanged)
                    control.Frame.Height,                // Height (unchanged)
                    control.Frame.FlipH,                 // Horizontal flip flag (unchanged)
                    control.Frame.FlipV,                 // Vertical flip flag (unchanged)
                    control.Frame.Rotation               // Rotation angle (unchanged)
                );

                // Assign the new frame to the control
                control.Frame = newFrame;
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptm);
        }
    }
}