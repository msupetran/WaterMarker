using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using WaterMarker.Core.Domain;
using WaterMarker.Core;
using System.IO;
using Moq;
using System.Text;

namespace WaterMarker.Core.Tests
{
    [TestClass]
    public class ImageWaterMarkerTest
    {
        // Fields
        private Mock<IImageProcessorWrapper> mockImageProcessor;
        private IImageProcessorWrapper imageProcessorWrapper;
        private WaterMarker sut;
        
        // Initialization
        [TestInitialize]
        public void TestInitialize()
        {
            mockImageProcessor = new Mock<IImageProcessorWrapper>();
            imageProcessorWrapper = mockImageProcessor.Object;
            sut = new WaterMarker(imageProcessorWrapper);

            // Setup mocking here...
            mockImageProcessor
                .Setup(imgProc => imgProc.Load(It.IsAny<MemoryStream>()))
                .Returns(imageProcessorWrapper);
            mockImageProcessor
                .Setup(imgProc => imgProc.Watermark(It.IsAny<IWaterMark>()))
                .Returns(imageProcessorWrapper);
            mockImageProcessor
                .SetupGet(imgProc => imgProc.Image)
                .Returns(imageProcessorWrapper.Image);
        }

        // Test Methods
        [TestMethod]
        public void SetWaterMarkWithValidImage()
        {
            // Arrange
            var waterMark = new WaterMark();
            var image = new Bitmap(50, 50);

            // Act
            var result = sut.SetWaterMark(waterMark, image);

            // Assert
            Assert.IsNotNull(result is Image);
            mockImageProcessor.Verify(imgProc =>
                imgProc.Load(It.IsAny<Stream>()),
                Times.Once);
            mockImageProcessor.Verify(imgProc =>
                imgProc.Watermark(It.IsAny<IWaterMark>()),
                Times.Once);
            mockImageProcessor.VerifyGet(imgProc =>
                imgProc.Image);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetWaterMarkWithNullImage()
        {
            // Arrange
            var waterMark = new WaterMark();
            Bitmap image = null;

            // Act
            var result = sut.SetWaterMark(waterMark, image);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetWaterMarkWithNullWaterMark()
        {
            // Arrange
            WaterMark waterMark = null;
            Bitmap image = new Bitmap(50, 50);

            // Act
            var result = sut.SetWaterMark(waterMark, image);
        }
    }
}
