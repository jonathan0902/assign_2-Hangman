using System;
using Xunit;
using Hangman;

namespace Hangman.Tests
{
    public class FileHandlerTests
    {
        [Fact]
        public void GetText_ShouldGatherStringFromTxtDocument()
        {

            FileHandler file = new FileHandler();
            string expected = "animal,house,oven,butter,egg";

            string actual = file.GetText("words.txt");
            
            Assert.Equal(expected, actual);

        }
    }
}
