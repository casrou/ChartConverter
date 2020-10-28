using Bunit;
using ChartConverter.Blazor.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using ChartConverter.Core;

namespace ChartConverter.Tests.Components
{
    public class CloneHeroFretsTests : TestContext
    {
        [Fact]
        public void CurrentColorShouldChangeWhenFretClicked()
        {
            // Arrange: render the Counter.razor component
            var cloneHeroComponent = RenderComponent<CloneHeroFrets>();

            // Act: find and click the <button> element to increment
            // the counter in the <p> element
            cloneHeroComponent.Find("#chFretRed").Click();

            // Assert: first find the <p> element, then verify its content
            //cloneHeroComponent.Find("p").MarkupMatches("<p>Current count: 1</p>");
            Assert.Equal(CloneHeroColor.Red, cloneHeroComponent.Instance.CurrentColor);
        }
    }
}
