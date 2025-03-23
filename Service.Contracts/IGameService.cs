using Entities.Models;
using Shared.DTO;
using Shared.ResponseFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IGameService
    {
        public Task<int> CreateRecord(GameDTO gameDTO);
        public Task<bool> UpdateGameStats(int id, GamePointsDTO gamePointDTO);
        public Task<GameResultsDTO> GetGameResults(int gameId);
        public Task<bool> UpdateGameFrame(int frameId, int gameId);

    }
}
