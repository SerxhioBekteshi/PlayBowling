using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class GameFrameRepository : RepositoryBase<GameFrame>, IGameFrameRepository
    {
        public GameFrameRepository(RepositoryContext repositoryContext)
          : base(repositoryContext)
        {
        }
        public void CreateRecord(GameFrame gameFrame) => Create(gameFrame);
        public void DeleteRecord(GameFrame gameFrame) => Delete(gameFrame);
        public async Task<GameFrame> GetRecordByIdAsync(int id) =>
        await FindByCondition(c => c.Id.Equals(id))
              .SingleOrDefaultAsync();

        public async Task<GameFrame> GetRecordByGameIdAndFrameIdAsync(int gameId, int frameId) =>
            await FindByCondition(c => c.GameId.Equals(gameId) && c.FrameId.Equals(frameId))
              .SingleOrDefaultAsync();

        public async Task<IEnumerable<GameFrame>> GetAllFramesByGameIdAsync(int gameId) =>
            await FindByCondition(c => c.GameId.Equals(gameId))
              .ToListAsync();
        public void UpdateRecord(GameFrame gameFrame) => Update(gameFrame);

        public async Task<int> GetAllByGameIdAsync(int gameId) =>
            (int)await FindByCondition(c => c.GameId == gameId)
                    .SumAsync(c => c.TotalScore);
    }
}
