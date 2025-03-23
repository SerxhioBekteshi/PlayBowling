using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Frame
    {
        public int Id { get; set; }
        public string? Description { get; set; }    
        public int FrameNumber { get; set; } 
        public int MaxThrows { get; set; }

        public virtual ICollection<GameFrame> GameFrames { get; set; }
    }
}
