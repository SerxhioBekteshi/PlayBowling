using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class GameFrame
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int FrameId { get; set; }
        public int? FirstThrow { get; set; }
        public int? SecondThrow { get; set; }
        public int? ThirdThrow { get; set; } 
        public int? TotalScore { get; set; }
        public bool IsSpareOrStrike { get; set; }

        public virtual Game Game { get; set; }
        public virtual Frame Frame { get; set; }
    }
}
