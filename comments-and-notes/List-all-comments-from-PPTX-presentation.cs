using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CommentLister
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "input.pptx";
                if (args.Length > 0)
                {
                    filePath = args[0];
                }

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
                {
                    foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)
                    {
                        foreach (Aspose.Slides.IComment comment in author.Comments)
                        {
                            int slideNumber = comment.Slide.SlideNumber;
                            string authorName = author.Name;
                            string text = comment.Text;
                            DateTime created = comment.CreatedTime;
                            Console.WriteLine("Slide {0}: Author '{1}' commented \"{2}\" at {3}", slideNumber, authorName, text, created);
                        }
                    }

                    presentation.Save(filePath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}