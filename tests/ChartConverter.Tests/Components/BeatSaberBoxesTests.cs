using Bunit;
using ChartConverter.Blazor.Models;
using ChartConverter.Blazor.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChartConverter.Tests.Components
{
    public class BeatSaberBoxesTests : TestContext
    {
        [Fact]
        public void CellClickShouldChangeColorAndDirection()
        {
            // Arrange
            int row = 0;
            int col = 0;
            var beatSaberComponent = RenderComponent<BeatSaberBoxes>();

            // Act
            beatSaberComponent.Find($"#bsCell{row}{col}").Click();

            // Assert
            var dirAndColor = beatSaberComponent.Instance.CurrentConfiguration.DirectionAndColors[row, col];
            var expectedDirAndColor = new DirectionAndColor()
            {
                Color = BeatSaberColor.BLUE,
                Direction = BeatSaberCutDirection.ALL
            };
            Assert.Equal(expectedDirAndColor, dirAndColor);
        }
    }
}
