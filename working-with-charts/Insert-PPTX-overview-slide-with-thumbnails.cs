using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OverviewSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
                {
                    // Capture existing slides before adding the overview slide
                    Aspose.Slides.ISlide[] existingSlides = presentation.Slides.ToArray();

                    // Add a new empty slide for the overview (using the first layout slide)
                    Aspose.Slides.ISlide overviewSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                    // Optional: Add a title shape to the overview slide
                    overviewSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle,
                        20, 20, 600, 50).TextFrame.Text = "Overview";

                    // Define thumbnail size and spacing
                    float thumbScaleX = 0.3f;
                    float thumbScaleY = 0.3f;
                    float marginX = 20f;
                    float marginY = 80f;
                    float spacingX = 20f;
                    float spacingY = 20f;

                    // Position variables
                    float currentX = marginX;
                    float currentY = marginY;
                    float maxRowHeight = 0f;

                    // Iterate through each existing slide and add its thumbnail to the overview slide
                    foreach (Aspose.Slides.ISlide slide in existingSlides)
                    {
                        // Generate a thumbnail image for the slide
                        using (Aspose.Slides.IImage thumbnail = slide.GetImage(thumbScaleX, thumbScaleY))
                        {
                            // Add the image to the presentation's image collection
                            Aspose.Slides.IPPImage pptImage = presentation.Images.AddImage(thumbnail);

                            // Add the picture frame to the overview slide
                            overviewSlide.Shapes.AddPictureFrame(
                                Aspose.Slides.ShapeType.Rectangle,
                                currentX,
                                currentY,
                                thumbnail.Width,
                                thumbnail.Height,
                                pptImage);

                            // Update positioning for the next thumbnail
                            if (thumbnail.Height > maxRowHeight)
                            {
                                maxRowHeight = thumbnail.Height;
                            }

                            currentX += thumbnail.Width + spacingX;

                            // Move to next row if exceeding slide width (assume 960 width)
                            if (currentX + thumbnail.Width > 960)
                            {
                                currentX = marginX;
                                currentY += maxRowHeight + spacingY;
                                maxRowHeight = 0f;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}