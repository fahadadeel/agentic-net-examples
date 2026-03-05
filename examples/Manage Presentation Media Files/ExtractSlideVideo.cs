using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string sourcePath = "Video.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            int slideNumber = 0;

            // Iterate through each slide
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                // Iterate through each shape on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Check if the shape is a video frame
                    if (shape is Aspose.Slides.IVideoFrame)
                    {
                        Aspose.Slides.IVideoFrame videoFrame = (Aspose.Slides.IVideoFrame)shape;
                        Aspose.Slides.IVideo video = videoFrame.EmbeddedVideo;

                        // Determine file extension from content type
                        string contentType = video.ContentType;
                        int lastSlash = contentType.LastIndexOf('/');
                        string extension = contentType.Substring(lastSlash + 1);

                        // Get video binary data
                        byte[] videoData = video.BinaryData;

                        // Save the video to a file
                        string outputFileName = $"ExtractedVideo_Slide{slideNumber}_{extension}";
                        using (FileStream outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            outputStream.Write(videoData, 0, videoData.Length);
                        }
                    }
                }

                slideNumber++;
            }

            // Save the presentation (even if unchanged) before exiting
            presentation.Save("Video_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}