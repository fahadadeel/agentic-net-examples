using System;
using Aspose.Slides;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            System.String inputPath = "input.ppt";
            System.String outputPath = "output.ppt";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through comment authors and their comments
            foreach (object commentAuthorObj in presentation.CommentAuthors)
            {
                Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)commentAuthorObj;
                foreach (object commentObj in author.Comments)
                {
                    Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;
                    System.Console.WriteLine("Slide " + comment.Slide.SlideNumber + ": " + comment.Text + " (Author: " + author.Name + ")");
                }
            }

            // Save the presentation in PPT format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}