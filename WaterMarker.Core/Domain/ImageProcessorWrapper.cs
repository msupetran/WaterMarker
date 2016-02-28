using ImageProcessor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace WaterMarker.Core.Domain
{
    public class ImageProcessorWrapper : IImageProcessorWrapper
    {
        // Fields
        private Image image;
        protected ImageFactory ImageFactory;

        // Properties
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        // Constructors
        public ImageProcessorWrapper()
        {
            ImageFactory = new ImageFactory();
        }

        // Methods
        public IImageProcessorWrapper Watermark(IWaterMark waterMark)
        {
            this.ImageFactory = ImageFactory.Watermark(waterMark.TextLayer);
            return this;
        }
        public IImageProcessorWrapper Load(Stream memoryStream)
        {
            this.ImageFactory = ImageFactory.Load(memoryStream);
            return this;
        }
        public void Dispose()
        {
            ImageFactory.Dispose();
        }
    }
}
