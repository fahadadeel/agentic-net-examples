using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Tiff;

class AsposeImagingDemo
{
    static void Main()
    {
        // ------------------------------------------------------------
        // 1. Create a new blank PNG image (200x200) and save it.
        // ------------------------------------------------------------
        using (Image pngImage = Image.Create(200, 200, new PngOptions()))
        {
            // Example: fill the image with a solid color (red) by setting pixels.
            // This loop is simple; for large images a more efficient method should be used.
            for (int y = 0; y < pngImage.Height; y++)
            {
                for (int x = 0; x < pngImage.Width; x++)
                {
                    pngImage.SetPixel(x, y, System.Drawing.Color.Red);
                }
            }

            // Persist the created image to disk.
            pngImage.Save("CreatedImage.png");
        }

        // ------------------------------------------------------------
        // 2. Load an existing JPEG image, resize it, and save as WebP.
        // ------------------------------------------------------------
        using (Image jpegImage = Image.Load("SampleInput.jpg"))
        {
            // Resize the image to 150x150 pixels.
            jpegImage.Resize(150, 150);

            // Define WebP save options (default settings are sufficient for most cases).
            var webpOptions = new WebpOptions();

            // Save the transformed image as WebP.
            jpegImage.Save("ResizedImage.webp", webpOptions);
        }

        // ------------------------------------------------------------
        // 3. Load a WebP image, add a new page (for formats that support pages),
        //    and save the result as a multi‑page TIFF.
        // ------------------------------------------------------------
        using (Image webpImage = Image.Load("SampleInput.webp"))
        {
            // Some formats (e.g., TIFF) support multiple pages/frames.
            // Here we demonstrate adding the loaded WebP as a page to a new TIFF image.
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            using (var tiffImage = (TiffImage)Image.Create(webpImage.Width, webpImage.Height, tiffOptions))
            {
                // Add the WebP image as the first page.
                tiffImage.AddPage(webpImage);

                // Optionally, add a second blank page.
                using (Image blankPage = Image.Create(webpImage.Width, webpImage.Height, new TiffOptions(TiffExpectedFormat.Default)))
                {
                    tiffImage.AddPage(blankPage);
                }

                // Save the multi‑page TIFF.
                tiffImage.Save("MultiPageResult.tiff", tiffOptions);
            }
        }

        // ------------------------------------------------------------
        // 4. Load a BMP image, apply a simple brightness adjustment,
        //    and save it as an ICO file with multiple resolutions.
        // ------------------------------------------------------------
        using (Image bmpImage = Image.Load("SampleInput.bmp"))
        {
            // Increase brightness by 30 units.
            bmpImage.AdjustBrightness(30);

            // ICO files can contain several image sizes; we add three common ones.
            var icoOptions = new IcoOptions();
            using (var icoImage = (IcoImage)Image.Create(bmpImage.Width, bmpImage.Height, icoOptions))
            {
                // Add the original size.
                icoImage.AddPage(bmpImage);

                // Add a 64x64 version.
                using (Image resized64 = bmpImage.Clone())
                {
                    resized64.Resize(64, 64);
                    icoImage.AddPage(resized64);
                }

                // Add a 32x32 version.
                using (Image resized32 = bmpImage.Clone())
                {
                    resized32.Resize(32, 32);
                    icoImage.AddPage(resized32);
                }

                // Persist the ICO file.
                icoImage.Save("ResultIcon.ico", icoOptions);
            }
        }

        // ------------------------------------------------------------
        // 5. Demonstrate loading a multi‑page DICOM image and saving each page as PNG.
        // ------------------------------------------------------------
        using (Image dicomImage = Image.Load("SampleInput.dcm"))
        {
            // DICOM images are often multi‑page; iterate through pages if present.
            for (int pageIndex = 0; pageIndex < dicomImage.Pages.Count; pageIndex++)
            {
                // Activate the current page.
                dicomImage.ActiveFrame = pageIndex;

                // Save the current page as a separate PNG file.
                string outputPath = $"DICOM_Page_{pageIndex + 1}.png";
                dicomImage.Save(outputPath, new PngOptions());
            }
        }

        Console.WriteLine("All operations completed successfully.");
    }
}