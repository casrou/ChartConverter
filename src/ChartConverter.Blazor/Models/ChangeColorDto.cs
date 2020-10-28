using ChartConverter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChartConverter.Blazor.Models
{
    public class ChangeColorDto
    {
        public CloneHeroColor OldColor { get; set; }
        public CloneHeroColor NewColor { get; set; }
    }
}
