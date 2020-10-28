using ChartConverter.Core;
using ChartConverter.Core.CloneHero;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChartConverter.Tests.CloneHero
{
    public class CloneHeroChartSongDataTests
    {
        [Fact]
        public void ToString_FromCorrectInfoFileAndResolution_MakeCorrectString()
        {
            // Arrange
            var bpm = 200;
            var name = "TestName";
            var author = "TestAuthor";
            var charter = "TestCharter";
            var offset = 0;

            var infoFile = new BeatSaberInfoFile()
            {
                BeatsPerMinute = bpm,
                SongName = name,
                SongAuthorName = author,
                LevelAuthorName = charter,
                SongTimeOffset = offset
            };

            var resolution = 192;
            var metadata = new CloneHeroChartSongData(infoFile, resolution);

            // Act
            var metadataString = metadata.ToString();

            // Assert
            var sb = new StringBuilder();
            sb.AppendLine("[Song]");
            sb.AppendLine("{");
            sb.AppendLine($"  Name = \"{infoFile.SongName}\"");
            sb.AppendLine($"  Artist = \"{infoFile.SongAuthorName}\"");
            sb.AppendLine($"  Charter = \"{infoFile.LevelAuthorName}\"");
            sb.AppendLine($"  Offset = {infoFile.SongTimeOffset}");
            sb.AppendLine($"  Resolution = {metadata.Resolution}");
            sb.AppendLine($"  Player2 = {metadata.Player2}");
            sb.AppendLine($"  Difficulty = {metadata.Difficulty}");
            sb.AppendLine($"  PreviewStart = {metadata.PreviewStart}");
            sb.AppendLine($"  PreviewEnd = {metadata.PreviewEnd}");
            sb.AppendLine($"  MusicStream = \"{metadata.MusicStream}\"");
            sb.AppendLine("}");
            var correctMetadataString = sb.ToString();
            Assert.Equal(correctMetadataString, metadataString);
        }
    }
}
