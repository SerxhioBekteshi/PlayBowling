using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IPlayerService PlayerService { get; }
        IGameService GameService { get; }
        IFrameService FrameService { get; }

    }
}
