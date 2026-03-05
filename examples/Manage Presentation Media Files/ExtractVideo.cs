using System;
using System.IO;
using Aspose.Slides;

namespace ExtractVideoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "Video.pptx";
            // Output directory for extracted videos
            string outputDir = "ExtractedVideos";

            // Create output directory if it does not exist
            System.IO.Directory.CreateDirectory(outputDir);

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            try
            {
                int videoIndex = 0;
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.VideoFrame)
                        {
                            Aspose.Slides.IVideoFrame vf = (Aspose.Slides.IVideoFrame)shape;
                            string contentType = vf.EmbeddedVideo.ContentType;
                            int slashPos = contentType.LastIndexOf('/');
                            string extension = contentType.Substring(slashPos + 1);
                            byte[] data = vf.EmbeddedVideo.BinaryData;
                            string outPath = System.IO.Path.Combine(outputDir, $"video_{videoIndex}.{extension}");
                            System.IO.FileStream fs = new System.IO.FileStream(outPath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Read);
                            try
                            {
                                fs.Write(data, 0, data.Length);
                            }
                            finally
                            {
                                fs.Dispose();
                            }
                            videoIndex++;
                        }
                    }
                }

                // Save the presentation before exiting
                presentation.Save("Video_extracted.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}