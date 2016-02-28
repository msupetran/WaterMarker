using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace WaterMarker.Core.Domain
{
    public interface IImageProcessorWrapper : IDisposable
    {
        // Properties
        Image Image { get; set; }

        // Methods
        IImageProcessorWrapper Watermark(IWaterMark waterMark);
        IImageProcessorWrapper Load(Stream memoryStream);
    }
}
