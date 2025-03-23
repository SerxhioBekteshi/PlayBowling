using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ResponseFeatures
{
    public class GameResultsDTO
    {
        public IEnumerable<GameFrame> GameFrames { get; set; }
        public int TotalScore { get; set; }
    }
}
