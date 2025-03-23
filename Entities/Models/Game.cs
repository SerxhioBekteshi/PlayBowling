using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsCompleted { get; set; }
        public int TotalScore { get; set; }

        public virtual Player Player { get; set; }
        public virtual ICollection<GameFrame> GameFrames { get; set; }
    }
}
