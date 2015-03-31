using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SrpClass
{
    public class FileUpload
    {
        public class ImageFile
        {
            public string Url { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }
        public class File
        {
            public string Url { get; set; }
            public string Name { get; set; }
        }
        public static string UploadFile(HttpPostedFileBase file, HttpServerUtilityBase Server, File newFile)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = newFile.Name + Path.GetExtension(file.FileName);
                var path = Path.Combine(newFile.Url, fileName);
                file.SaveAs(path);
                return Server.UrlEncode(fileName);
            }
            return String.Empty;
        }
        public static string UploadFixImage(HttpPostedFileBase file, HttpServerUtilityBase Server, ImageFile image)
        {
            if (file.ContentType.Contains("image"))
            {
                Image img = FixOrientation(file);
                var fileName = DateTime.Now.Ticks.ToString() + ".png";
                using (img)
                {
                    Bitmap trans = ScaleImage(new Bitmap(img), image.Width, image.Height);
                    trans.Save(Path.Combine(Server.MapPath(image.Url), fileName), System.Drawing.Imaging.ImageFormat.Png);
                }
                return Server.UrlEncode(fileName);
            }
            return String.Empty;
        }
        public static string UploadFixImage(HttpPostedFileBase file, HttpServerUtilityBase Server, ImageFile image, string ImageName)
        {
            if (file.ContentType.Contains("image"))
            {
                Image img = FixOrientation(file);
                var fileName = ImageName + DateTime.Now.Ticks.ToString() + ".png";
                using (img)
                {
                    Bitmap trans = ScaleImage(new Bitmap(img), image.Width, image.Height);
                    trans.Save(Path.Combine(Server.MapPath(image.Url), fileName), System.Drawing.Imaging.ImageFormat.Png);
                }
                return Server.UrlEncode(fileName);
            }
            return String.Empty;
        }
        public static Image FixOrientation(HttpPostedFileBase fileUpload)
        {
            byte[] imageData = new byte[fileUpload.ContentLength];
            fileUpload.InputStream.Read(imageData, 0, fileUpload.ContentLength);

            MemoryStream ms = new MemoryStream(imageData);
            Image originalImage = Image.FromStream(ms);

            if (originalImage.PropertyIdList.Contains(0x0112))
            {
                int rotationValue = originalImage.GetPropertyItem(0x0112).Value[0];
                switch (rotationValue)
                {
                    case 1: // landscape, do nothing
                        break;

                    case 8: // rotated 90 right
                        // de-rotate:
                        originalImage.RotateFlip(rotateFlipType: RotateFlipType.Rotate270FlipNone);
                        break;

                    case 3: // bottoms up
                        originalImage.RotateFlip(rotateFlipType: RotateFlipType.Rotate180FlipNone);
                        break;

                    case 6: // rotated 90 left
                        originalImage.RotateFlip(rotateFlipType: RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            return originalImage;
        }
        public static Bitmap ScaleImage(Bitmap image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }
    }
}
