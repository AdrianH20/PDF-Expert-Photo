using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


using Image = iText.Layout.Element.Image;
using System.Windows.Forms;

namespace JPEGtoPDF
{
    class OrientationChecking
    {
        static double degree = 0;

        public static void rotateChecking(ref Image img, string orientationTag, ref ImageSelection image, bool setOrientation)
        {

            Regex rx = new Regex(@"rotate\s+[0-9]{1,3}(cw|ccw|\s){0,1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rx2 = new Regex(@"(cw|ccw)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rx3 = new Regex(@"cw", RegexOptions.Compiled | RegexOptions.IgnoreCase);

          
            if (rx.IsMatch(orientationTag))
            {
                Match matchDegree = Regex.Match(orientationTag, @"[0-9]{1,3}");
                Match matchType = rx2.Match(orientationTag);
                degree = double.Parse(matchDegree.Value.ToString());
                

                if (!rx3.IsMatch(matchType.Value)) degree = -degree;
                Console.WriteLine(image.ToString()+ " "+orientationTag + "appear "+ image.format);
                switch (degree)
                {
                    case 90:    img.SetRotationAngle(-Math.PI / 2);
                        if (!setOrientation) image.format = (image.format == "portrait") ? "landscape" : "portrait";
                        break;
                    case 180:   img.SetRotationAngle(-Math.PI); break;
                    case 270:   img.SetRotationAngle(-Math.PI * 3 / 2);
                        if (!setOrientation) image.format = (image.format == "portrait") ? "landscape" : "portrait"; 
                        break;

                    case -90:   img.SetRotationAngle(Math.PI / 2);
                        if (!setOrientation) image.format = (image.format == "portrait") ? "landscape" : "portrait"; 
                        break;
                    case -180:  img.SetRotationAngle(Math.PI); break;
                    case -270:  img.SetRotationAngle(Math.PI * 3 / 2);
                        if (!setOrientation) image.format = (image.format == "portrait") ? "landscape" : "portrait";
                        break;

                }
              
            }
        }


        public static void rotateCheckingPreview( ref System.Drawing.Image imgPreview, string path)
        {

            var directories = MetadataExtractor.ImageMetadataReader.ReadMetadata(path);

            string orientationTag = "";

            foreach (var directory in directories)
            {
                foreach (var tag in directory.Tags)
                    if (tag.Name == "Orientation" && directory.Name == "Exif IFD0")
                    {
                        orientationTag = tag.Description;
                        break;
                    }
                if (directory.HasError)
                {
                    foreach (var error in directory.Errors)
                        Console.WriteLine($"ERROR: {error}");
                }
            }
            

           
            Regex rx = new Regex(@"rotate\s+[0-9]{1,3}(cw|ccw|\s){0,1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rx2 = new Regex(@"(cw|ccw)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rx3 = new Regex(@"cw", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (rx.IsMatch(orientationTag))
            {
               

                Match matchDegree = Regex.Match(orientationTag, @"[0-9]{1,3}");
                Match matchType = rx2.Match(orientationTag);
                degree = double.Parse(matchDegree.Value.ToString());
                
                if (!rx3.IsMatch(matchType.Value)) degree = -degree;

                switch (degree)
                {
                    case 90: imgPreview.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone); break;
                    case 180: imgPreview.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone); break;           
                    case 270: imgPreview.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);break;

                    case -90: imgPreview.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone); break;
                    case -180: imgPreview.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone); break;
                    case -270: imgPreview.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone); break;
                }
            }
        }
    }

     class Dimensions
    {
        
        public static void getDim(ref ImageSelection image)
        {
            var directories = MetadataExtractor.ImageMetadataReader.ReadMetadata(image.getPath());

            bool foundWidth = false;
            bool foundHeight = false;
            string descriptionWidth="";
            string descriptionHeight="";
            foreach (var directory in directories)
            {
                
                foreach (var tag in directory.Tags)
                {
                   
                    
                    if (!foundWidth &&(tag.Name == "Image Width") && (directory.Name=="JPEG"  || directory.Name =="JPG" || directory.Name.Contains("JPG") || directory.Name.Contains("JPEG") || directory.Name.Contains("PNG") || directory.Name.Contains("JFIF") || directory.Name.Contains("BMP") || directory.Name.Contains("TIF") || directory.Name.Contains("TIFF") || directory.Name.Contains("GIF")))
                    {
                       
                        descriptionWidth = tag.Description;
                        foundWidth = true;
                    }
                    if (!foundHeight && (tag.Name == "Image Height") && (directory.Name == "JPEG" || directory.Name == "JPG" || directory.Name.Contains("JPG") || directory.Name.Contains("JPEG") || directory.Name.Contains("PNG") || directory.Name.Contains("JFIF") || directory.Name.Contains("BMP") || directory.Name.Contains("TIF") || directory.Name.Contains("TIFF") || directory.Name.Contains("GIF")))
                    {
                        
                        descriptionHeight = tag.Description;
                        foundHeight = true;
                    }
                    if (foundHeight && foundWidth) break;

                }
                if (directory.HasError)
                {
                    foreach (var error in directory.Errors)
                        Console.WriteLine($"ERROR: {error}");
                }

                if (foundHeight && foundWidth) break;
            }
            
            Regex rx = new Regex(@"[0-9]{1,6}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if(rx.IsMatch(descriptionWidth))  image.setWidth(int.Parse(rx.Match(descriptionWidth).Value));
            if(rx.IsMatch(descriptionHeight)) image.setHeight(int.Parse(rx.Match(descriptionHeight).Value));
            
            if (image.getHeight() >= image.getWidth()) image.format = "portrait";
            else image.format = "landscape";
            Console.WriteLine( image.ToString()+" "+image.getWidth() + "(width)x" + image.getHeight()+"(height)   "+image.format);
            
        }
    }
}