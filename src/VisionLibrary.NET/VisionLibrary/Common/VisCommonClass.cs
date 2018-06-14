using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging.Filters;
using Image = AForge.Imaging.Image;
using AForge.Video.FFMPEG;

namespace VisionLibrary.Common
{
    public class VisCommonClass
    {
        /// <summary>
        /// Returns the contents of the specified file as a byte array.
        /// </summary>
        /// <param name="imageFilePath">The image file to read.</param>
        /// <returns>The byte array of the image data.</returns>
        public static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                //BinaryReader binaryReader = new BinaryReader(fileStream);
                //return binaryReader.ReadBytes((int)fileStream.Length);

                //resize
                Bitmap newImage = miniSizeImage(fileStream, 600, 600);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    newImage.Save(memoryStream, ImageFormat.Bmp);
                    //read
                    return memoryStream.ToArray();
                }
            }
        }

        internal static byte[] GetImageAsByteArray(Bitmap image)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(image, typeof(byte[]));
        }

        /// <summary>
        /// Formats the given JSON string by adding line breaks and indents.
        /// </summary>
        /// <param name="json">The raw JSON string to format.</param>
        /// <returns>The formatted JSON string.</returns>
        public static string JsonPrettyPrint(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");

            string INDENT_STRING = "    ";
            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();
            for (var i = 0; i < json.Length; i++)
            {
                var ch = json[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, ++indent).ForEach(
                                item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, --indent).ForEach(
                                item => sb.Append(INDENT_STRING));
                        }
                        sb.Append(ch);
                        break;
                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while (index > 0 && json[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, indent).ForEach(
                                item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case ':':
                        sb.Append(ch);
                        if (!quoted)
                            sb.Append(" ");
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将图片大小标准化(4M限制)
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="width">压缩目标宽,会按原比例缩放</param>
        /// <param name="height">压缩目标高,会按原比例缩放</param>
        /// <returns></returns>
        public static Bitmap miniSizeImage(FileStream stream, int width, int height)
        {

            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
            int _height = 0;
            int _width = 0;
            //height much bigger , so height is the max number of size
            if (image.Size.Height > image.Size.Width)
            {
                _height = height;
                _width = (int)((double)image.Size.Width / image.Size.Height * height);
            }
            else
            {
                _height = (int)((double)image.Size.Height / image.Size.Width * width);
                _width = width;
            };
            ResizeBicubic filter = new ResizeBicubic(_width, _height);
            // apply the filter
            return filter.Apply(image as Bitmap);

        }

        //TODO readType 
        public static Bitmap GetVideoFrame(string filepath)
        {
            VideoFileReader reader = new VideoFileReader();
            reader.Open(filepath);            
            Bitmap videoFrame = reader.ReadVideoFrame();
            reader.Close();
            return videoFrame;
        }
    }
}
