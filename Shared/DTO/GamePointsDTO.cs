using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class GamePointsDTO
    {
        public int? FirstShotPoints { get; set; }
        public int? SecondShotPoints { get; set; }
        public int? ThirdShotPoints { get; set; }
        public int FrameId { get; set; }

    }
}
