using ChartConverter.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChartConverter.Tests
{
    public class BeatSaberToCloneHeroHelperTests
    {
        [Fact]
        public async void MakeCloneHeroZipStreamFromBeatSaberZipFilePath_WithCorrectBeatSaberZip_HaveCorrectFileName()
        {
            var converter = new BeatSaberToCloneHeroConverter(ConverterConfig.GetDefault());
            var test = await converter.GenerateCloneHeroZipBytesFromBeatSaberZipFile("Favorite_Alexander_Nakarada.zip");
            Assert.Equal("Favorite - Alexander Nakarada.zip", test.FileName);
        }
    }
}
