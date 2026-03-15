using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Path to the JPEG image
        string dir = @"c:\temp\";
        string fileName = "original.jpg";

        // Load the JPEG image using Aspose.Imaging (lifecycle rule)
        using (JpegImage image = (JpegImage)Image.Load(dir + fileName))
        {
            // Access EXIF data container
            JpegExifData exifData = image.ExifData as JpegExifData;

            // Dictionary that maps each EXIF tag to its definition (documentation)
            var exifDefinitions = new Dictionary<ExifProperties, string>
            {
                { ExifProperties.ImageWidth, "The number of columns of image data, equal to the number of pixels per row." },
                { ExifProperties.ImageLength, "The number of rows of image data." },
                { ExifProperties.BitsPerSample, "The number of bits per image component. In this standard each component of the image is 8 bits, so the value for this tag is 8." },
                { ExifProperties.Compression, "The compression scheme used for the image data. When a primary image is JPEG compressed, this designation is not necessary and is omitted." },
                { ExifProperties.PhotometricInterpretation, "The pixel composition." },
                { ExifProperties.ImageDescription, "A character string giving the title of the image. It may be a comment such as \"1988 company picnic\" or the like." },
                { ExifProperties.Make, "The manufacturer of the recording equipment. This is the manufacturer of the DSC, scanner, video digitizer or other equipment that generated the image." },
                { ExifProperties.Model, "The model name or model number of the equipment." },
                { ExifProperties.Orientation, "The image orientation viewed in terms of rows and columns." },
                { ExifProperties.SamplesPerPixel, "The number of components per pixel. Since this standard applies to RGB and YCbCr images, the value set for this tag is 3." },
                { ExifProperties.XResolution, "The number of pixels per ResolutionUnit in the ImageWidth direction. When the image resolution is unknown, 72 [dpi] is designated." },
                { ExifProperties.YResolution, "The number of pixels per ResolutionUnit in the ImageLength direction. The same value as XResolution is designated." },
                { ExifProperties.PlanarConfiguration, "Indicates whether pixel components are recorded in a chunky or planar format. If this field does not exist, the TIFF default of 1 (chunky) is assumed." },
                { ExifProperties.ResolutionUnit, "The unit for measuring XResolution and YResolution. The same unit is used for both XResolution and YResolution. If the image resolution is unknown, 2 (inches) is designated." },
                { ExifProperties.TransferFunction, "A transfer function for the image, described in tabular style. Normally this tag is not necessary, since color space is specified in the color space information ColorSpace tag." },
                { ExifProperties.Software, "This tag records the name and version of the software or firmware of the camera or image input device used to generate the image." },
                { ExifProperties.DateTime, "The date and time of image creation. In Exif standard, it is the date and time the file was changed." },
                { ExifProperties.Artist, "This tag records the name of the camera owner, photographer or image creator." },
                { ExifProperties.WhitePoint, "The chromaticity of the white point of the image." },
                { ExifProperties.PrimaryChromaticities, "The chromaticity of the three primary colors of the image." },
                { ExifProperties.YCbCrCoefficients, "The matrix coefficients for transformation from RGB to YCbCr image data." },
                { ExifProperties.YCbCrSubSampling, "The sampling ratio of chrominance components in relation to the luminance component." },
                { ExifProperties.YCbCrPositioning, "The position of chrominance components in relation to the luminance component." },
                { ExifProperties.ReferenceBlackWhite, "The reference black point value and reference white point value." },
                { ExifProperties.Copyright, "Copyright information. In this standard the tag is used to indicate both the photographer and editor copyrights." },
                { ExifProperties.ExposureTime, "Exposure time, given in seconds." },
                { ExifProperties.FNumber, "The F number." },
                { ExifProperties.ExposureProgram, "The class of the program used by the camera to set exposure when the picture is taken." },
                { ExifProperties.SpectralSensitivity, "Indicates the spectral sensitivity of each channel of the camera used." },
                { ExifProperties.PhotographicSensitivity, "Indicates the ISO Speed and ISO Latitude of the camera or input device as specified in ISO 12232." },
                { ExifProperties.OECF, "Indicates the Opto-Electric Conversion Function (OECF) specified in ISO 14524." },
                { ExifProperties.ExifVersion, "The Exif version." },
                { ExifProperties.DateTimeOriginal, "The date and time when the original image data was generated." },
                { ExifProperties.DateTimeDigitized, "The date time digitized." },
                { ExifProperties.ComponentsConfiguration, "The components' configuration." },
                { ExifProperties.CompressedBitsPerPixel, "Specific to compressed data; states the compressed bits per pixel." },
                { ExifProperties.ShutterSpeedValue, "The shutter speed value." },
                { ExifProperties.ApertureValue, "The lens aperture value." },
                { ExifProperties.BrightnessValue, "The brightness value." },
                { ExifProperties.ExposureBiasValue, "The exposure bias value." },
                { ExifProperties.MaxApertureValue, "The max aperture value." },
                { ExifProperties.SubjectDistance, "The distance to the subject, given in meters." },
                { ExifProperties.MeteringMode, "The metering mode." },
                { ExifProperties.LightSource, "The kind light source." },
                { ExifProperties.Flash, "Indicates the status of flash when the image was shot." },
                { ExifProperties.FocalLength, "The actual focal length of the lens, in mm." },
                { ExifProperties.SubjectArea, "This tag indicates the location and area of the main subject in the overall scene." },
                { ExifProperties.MakerNote, "A tag for manufacturers of Exif writers to record any desired information." },
                { ExifProperties.UserComment, "A tag for Exif users to write keywords or comments on the image besides those in ImageDescription." },
                { ExifProperties.SubsecTime, "A tag used to record fractions of seconds for the DateTime tag." },
                { ExifProperties.SubsecTimeOriginal, "A tag used to record fractions of seconds for the DateTimeOriginal tag." },
                { ExifProperties.SubsecTimeDigitized, "A tag used to record fractions of seconds for the DateTimeDigitized tag." },
                { ExifProperties.FlashpixVersion, "The Flashpix format version supported by a FPXR file." },
                { ExifProperties.ColorSpace, "The color space information tag (ColorSpace) is always recorded as the color space specifier." },
                { ExifProperties.RelatedSoundFile, "The related sound file." },
                { ExifProperties.FlashEnergy, "Indicates the strobe energy at the time the image is captured, as measured in Beam Candle Power Seconds (BCPS)." },
                { ExifProperties.SpatialFrequencyResponse, "This tag records the camera or input device spatial frequency table and SFR values." },
                { ExifProperties.FocalPlaneXResolution, "Indicates the number of pixels in the image width (X) direction per FocalPlaneResolutionUnit on the camera focal plane." },
                { ExifProperties.FocalPlaneYResolution, "Indicates the number of pixels in the image height (Y) direction per FocalPlaneResolutionUnit on the camera focal plane." },
                { ExifProperties.FocalPlaneResolutionUnit, "Indicates the unit for measuring FocalPlaneXResolution and FocalPlaneYResolution." },
                { ExifProperties.SubjectLocation, "Indicates the location of the main subject in the scene." },
                { ExifProperties.ExposureIndex, "Indicates the exposure index selected on the camera or input device at the time the image is captured." },
                { ExifProperties.SensingMethod, "Indicates the image sensor type on the camera or input device." },
                { ExifProperties.FileSource, "The file source." },
                { ExifProperties.SceneType, "Indicates the type of scene. If a DSC recorded the image, this tag value shall always be set to 1." },
                { ExifProperties.CFAPattern, "Indicates the color filter array (CFA) geometric pattern of the image sensor when a one-chip color area sensor is used." },
                { ExifProperties.CustomRendered, "This tag indicates the use of special processing on image data." },
                { ExifProperties.ExposureMode, "This tag indicates the exposure mode set when the image was shot." },
                { ExifProperties.WhiteBalance, "This tag indicates the white balance mode set when the image was shot." },
                { ExifProperties.DigitalZoomRatio, "This tag indicates the digital zoom ratio when the image was shot." },
                { ExifProperties.FocalLengthIn35MmFilm, "This tag indicates the equivalent focal length assuming a 35mm film camera, in mm." },
                { ExifProperties.SceneCaptureType, "This tag indicates the type of scene that was shot." },
                { ExifProperties.GainControl, "This tag indicates the degree of overall image gain adjustment." },
                { ExifProperties.Contrast, "This tag indicates the direction of contrast processing applied by the camera when the image was shot." },
                { ExifProperties.Saturation, "This tag indicates the direction of saturation processing applied by the camera when the image was shot." },
                { ExifProperties.Sharpness, "This tag indicates the direction of sharpness processing applied by the camera when the image was shot." },
                { ExifProperties.DeviceSettingDescription, "This tag indicates information on the picture-taking conditions of a particular camera model." },
                { ExifProperties.SubjectDistanceRange, "This tag indicates the distance to the subject." },
                { ExifProperties.ImageUniqueID, "The image unique id." },
                { ExifProperties.GPSVersionID, "Indicates the version of GPSInfoIFD." },
                { ExifProperties.GPSLatitudeRef, "Indicates whether the latitude is north or south latitude." },
                { ExifProperties.GPSLatitude, "Indicates the latitude. Expressed as three RATIONAL values (degrees, minutes, seconds)." },
                { ExifProperties.GPSLongitudeRef, "Indicates whether the longitude is east or west longitude." },
                { ExifProperties.GPSLongitude, "Indicates the longitude. Expressed as three RATIONAL values (degrees, minutes, seconds)." },
                { ExifProperties.GPSAltitudeRef, "Indicates the altitude used as the reference altitude." },
                { ExifProperties.GPSAltitude, "Indicates the altitude based on the reference in GPSAltitudeRef. Expressed in meters." },
                { ExifProperties.GPSTimestamp, "Indicates the time as UTC (Coordinated Universal Time). Expressed as three RATIONAL values (hour, minute, second)." },
                { ExifProperties.GPSSatellites, "Indicates the GPS satellites used for measurements." },
                { ExifProperties.GPSStatus, "Indicates the status of the GPS receiver when the image is recorded." },
                { ExifProperties.GPSMeasureMode, "Indicates the GPS measurement mode." },
                { ExifProperties.GPSDOP, "Indicates the GPS DOP (data degree of precision)." },
                { ExifProperties.GPSSpeedRef, "Indicates the unit used to express the GPS receiver speed of movement." },
                { ExifProperties.GPSSpeed, "Indicates the speed of GPS receiver movement." },
                { ExifProperties.GPSTrackRef, "Indicates the reference for giving the direction of GPS receiver movement." },
                { ExifProperties.GPSTrack, "Indicates the direction of GPS receiver movement." },
                { ExifProperties.GPSImgDirectionRef, "Indicates the reference for giving the direction of the image when it is captured." },
                { ExifProperties.GPSImgDirection, "Indicates the direction of the image when it was captured." },
                { ExifProperties.GPSMapDatum, "Indicates the geodetic survey data used by the GPS receiver." },
                { ExifProperties.GPSDestLatitudeRef, "Indicates whether the latitude of the destination point is north or south latitude." },
                { ExifProperties.GPSDestLatitude, "Indicates the latitude of the destination point." },
                { ExifProperties.GPSDestLongitudeRef, "Indicates whether the longitude of the destination point is east or west longitude." },
                { ExifProperties.GPSDestLongitude, "Indicates the longitude of the destination point." },
                { ExifProperties.GPSDestBearingRef, "Indicates the reference used for giving the bearing to the destination point." },
                { ExifProperties.GPSDestBearing, "Indicates the bearing to the destination point." },
                { ExifProperties.GPSDestDistanceRef, "Indicates the unit used to express the distance to the destination point." },
                { ExifProperties.GPSDestDistance, "Indicates the distance to the destination point." },
                { ExifProperties.GPSProcessingMethod, "A character string recording the name of the method used for location finding." },
                { ExifProperties.GPSAreaInformation, "A character string recording the name of the GPS area." },
                { ExifProperties.GPSDateStamp, "A character string recording date and time information relative to UTC (YYYY:MM:DD)." },
                { ExifProperties.GPSDifferential, "Indicates whether differential correction is applied to the GPS receiver." },
                { ExifProperties.StripOffsets, "For each strip, the byte offset of that strip." },
                { ExifProperties.JPEGInterchangeFormat, "The offset to the start byte (SOI) of JPEG compressed thumbnail data." },
                { ExifProperties.JPEGInterchangeFormatLength, "The number of bytes of JPEG compressed thumbnail data." },
                { ExifProperties.ExifIfdPointer, "A pointer to the Exif IFD." },
                { ExifProperties.GPSIfdPointer, "The GPS IFD pointer." },
                { ExifProperties.RowsPerStrip, "The number of rows per strip." },
                { ExifProperties.StripByteCounts, "The total number of bytes in each strip." },
                { ExifProperties.PixelXDimension, "Information specific to compressed data. Valid width of the meaningful image." },
                { ExifProperties.PixelYDimension, "Information specific to compressed data. Valid height of the meaningful image." },
                { ExifProperties.Gamma, "Gamma value." },
                { ExifProperties.SensitivityType, "Type of photographic sensitivity." },
                { ExifProperties.StandardOutputSensitivity, "Indicates standard output sensitivity of camera." },
                { ExifProperties.RecommendedExposureIndex, "Indicates recommended exposure index." },
                { ExifProperties.ISOSpeed, "Information about ISO speed value as defined in ISO 12232." },
                { ExifProperties.ISOSpeedLatitudeYYY, "ISO speed latitude yyy value as defined in ISO 12232." },
                { ExifProperties.ISOSpeedLatitudeZZZ, "ISO speed latitude zzz value as defined in ISO 12232." },
                { ExifProperties.CameraOwnerName, "Contains camera owner name." },
                { ExifProperties.BodySerialNumber, "Contains camera body serial number." },
                { ExifProperties.LensMake, "This tag records lens manufacturer." },
                { ExifProperties.LensModel, "This tag records lens's model name and model number." },
                { ExifProperties.LensSerialNumber, "This tag records the serial number of interchangeable lens." },
                { ExifProperties.LensSpecification, "This tag notes minimum focal length, maximum focal length, minimum F number in the minimum focal length and minimum F number in maximum focal length." }
            };

            // Output the tag name, numeric value and its definition.
            foreach (var entry in exifDefinitions)
            {
                ushort numericValue = (ushort)entry.Key;
                Console.WriteLine($"{entry.Key} ({numericValue}): {entry.Value}");
            }

            // Optionally, display actual values present in the image (if any)
            if (exifData != null && exifData.Properties != null)
            {
                Console.WriteLine("\n--- Actual EXIF values present in the image ---");
                foreach (var tag in exifData.Properties)
                {
                    // tag.TagId corresponds to the numeric EXIF tag identifier
                    Console.WriteLine($"Tag ID {tag.TagId}: {tag.Value}");
                }
            }
        }
    }
}