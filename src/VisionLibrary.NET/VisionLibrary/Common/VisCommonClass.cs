using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging.Filters;
using AForge.Video.FFMPEG;
using Image = AForge.Imaging.Image;
//using AForge.Video.FFMPEG;

namespace VisionLibrary.Common
{
    public class VisCommonClass
    {
        /// <summary>
        /// Returns the contents of the specified file as a byte array.
        /// </summary>
        /// <param name="imageFilePath">The image file to read.</param>
        /// <param name="maxSize">压缩目标尺寸kb</param>/// 
        /// <returns>The byte array of the image data.</returns>
        public static byte[] GetImageAsByteArray(string imageFilePath, bool min = true, int minSizeWidth = 0, int minSizeHeight = 0, int maxSize = 2 * 1024)
        {
            using (FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                //resize
                if (min)
                {

                    //byte[] imageArray = System.IO.File.ReadAllBytes(imageFilePath);
                    //string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                    //return imageArray;
                    //test
                    //byte[] fuck = new byte[fileStream.Length];
                    //fileStream.Read(fuck, 0, Convert.ToInt32(fileStream.Length));                    

                    //Console.WriteLine($"origin byte:{fuck.Length}");
                    //byte[] fuck1 = new byte[fileStream.Length];



                    Stream minStream = CompressImage(fileStream, 90, maxSize, true);
                    byte[] buffer = new byte[minStream.Length];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        minStream.Seek(0, SeekOrigin.Begin);
                        int read;
                        while ((read = minStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }

                        return buffer;
                    }
                    //Console.WriteLine($"min byte:{buffer.Length}");
                    ////Bitmap newImage = miniSizeImage(fileStream, minSizeWidth, minSizeHeight, maxSize);
                    //using (MemoryStream memoryStream = new MemoryStream())
                    //{
                    //    Bitmap newImage = System.Drawing.Image.FromStream(fileStream) as Bitmap;
                    //    newImage.Save(memoryStream, ImageFormat.Bmp);
                    //    Console.WriteLine($"bitmap byte:{memoryStream.ToArray().Length}");
                    //    //read
                    //    return buffer;

                    //}


                }
                else
                {
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    return binaryReader.ReadBytes((int)fileStream.Length);
                }
            }
        }

        internal static byte[] GetImageAsByteArray(Bitmap image, bool min = true, int minSizeWidth = 600, int minSizeHeight = 600, int maxSize = 2 * 1024 * 1024)
        {

            if (min)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, ImageFormat.Bmp);

                    MemoryStream res = CompressImage(memoryStream, size: maxSize) as MemoryStream;
                    return res.ToArray();
                }
            }
            else
            {
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(image, typeof(byte[]));

            }
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
        /// <param name="maxSize">压缩目标尺寸kb</param>/// 
        /// <returns></returns>
        public static Bitmap miniSizeImage(FileStream stream, int width, int height, int maxSize = 2 * 1024, bool forceMin = false)
        {
            //System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
            //if (!forceMin && stream.Length <= maxSize)
            //{
            //    return image as Bitmap;
            //}
            //var length = new FileInfo(image).Length;
            //return miniSizeImage(image, width, height);

            Stream res = CompressImage(stream, 90, maxSize, true);
            System.Drawing.Image image = System.Drawing.Image.FromStream(res);
            return image as Bitmap;
        }
        /// <summary>
        /// 将图片大小标准化(4M限制)
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width">压缩目标宽,会按原比例缩放</param>
        /// <param name="height">压缩目标高,会按原比例缩放</param>
        /// <returns></returns>
        public static Bitmap miniSizeImage(System.Drawing.Image image, int width, int height)
        {

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
            try
            {
                return filter.Apply(image as Bitmap);
            }
            catch (Exception ex)
            {
                return image as Bitmap;
            }

        }


        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片steam</param>
        /// <param name="dFile">压缩后保存图片地址</param>
        /// <param name="flag">压缩质量（数字越小压缩率越高）1-100</param>
        /// <param name="size">压缩后图片的最大大小kb</param>
        /// <param name="sfsc">是否是第一次调用</param>
        /// <returns></returns>
        public static Stream CompressImage(Stream sFile, int flag = 90, int size = 300, bool sfsc = true, Stream dFile = null)
        {

            //Console.WriteLine("sfile:" + sFile.Length);

            //如果是第一次调用，原始图像的大小小于要压缩的大小，则直接复制文件，并且返回true            
            if (sfsc == true && sFile.Length < size * 1024)
            {
                //sFile.CopyTo(dFile);
                return sFile;
            }
            System.Drawing.Image iSource = System.Drawing.Image.FromStream(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int dHeight = iSource.Height / 2;
            int dWidth = iSource.Width / 2;
            int sW = 0, sH = 0;
            //按比例缩放
            Size tem_size = new Size(iSource.Width, iSource.Height);
            if (tem_size.Width > dHeight || tem_size.Width > dWidth)
            {
                if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (tem_size.Width * dHeight) / tem_size.Height;
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }

            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            g.Dispose();

            //以下代码为保存图片时，设置压缩质量
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;

            try
            {

                if (dFile != null)
                {
                    dFile.Close();
                }
                dFile = new MemoryStream();

                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }

                if (jpegICIinfo != null)
                {

                    //var fuckPath = Path.Combine(@"C:\Users\GUJIAMING\OneDrive\桌面\test\temp", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")+".jpg");
                    //ob.Save(fuckPath, jpegICIinfo, ep);//dFile是压缩后的                   
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径                                            
                    //Console.WriteLine("dfile:" + dFile.Length);
                    //Console.WriteLine("dfile byte:"+ (dFile as MemoryStream).ToArray().LongLength);
                    if (dFile.Length > 1024 * size)
                    {
                        flag = flag - 10;
                        dFile = CompressImage(sFile, flag, size, false, dFile);//递归压缩直到可行
                    }
                }


                //
                return dFile;
            }
            catch
            {
                return sFile;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
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
