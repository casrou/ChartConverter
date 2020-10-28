using ChartConverter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChartConverter.Blazor.Models
{
    public class SelectPreviewDto
    {
        public BeatSaberConfiguration Configuration { get; set; }
        public CloneHeroColor Color { get; set; }
    }
}
