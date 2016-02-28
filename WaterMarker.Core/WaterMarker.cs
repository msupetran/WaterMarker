using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WaterMarker.Core.Domain;
using System.IO;

namespace WaterMarker.Core
{
    public class WaterMarker : IDisposable
    {
        // Fields
        private IImageProcessorWrapper imageProcessorWrapper;

        // Constructors
        public WaterMarker()
        {
        }

        public WaterMarker(IImageProcessorWrapper imageProcessor)
        {
            // TODO: Complete member initialization
            this.imageProcessorWrapper = imageProcessor;
        }
        
        // Methods
        public Image SetWaterMark(IWaterMark waterMark, Image image)
        {
            if (waterMark == null)
            {
                throw new ArgumentNullException("waterMark");
            }

            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            ImageConverter imageConverter = new ImageConverter();
            byte[] byteArray = (byte[])imageConverter.ConvertTo(image, typeof(byte[]));

            using (var memoryStream = new MemoryStream(byteArray))
            {
                return imageProcessorWrapper
                    .Load(memoryStream)
                    .Watermark(waterMark)
                    .Image;
            }
        }

        // IDisposable Members
        public void Dispose()
        {
            imageProcessorWrapper.Dispose();
        }
    }
}
