using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IGameFrameRepository
    {
        void CreateRecord(GameFrame gameFrame);
        Task<GameFrame> GetRecordByIdAsync(int id);
        Task<GameFrame> GetRecordByGameIdAndFrameIdAsync(int gameId, int frameId);
        Task<IEnumerable<GameFrame>> GetAllFramesByGameIdAsync(int gameId);
        void UpdateRecord(GameFrame gameFrame);
        void DeleteRecord(GameFrame gameFrame);
        Task<int> GetAllByGameIdAsync(int gameId);
    }
}
