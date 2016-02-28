using ImageProcessor.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WaterMarker.Core.Domain
{
    public class WaterMark : IWaterMark
    {
        public TextLayer TextLayer { get; set; }
    }
}
