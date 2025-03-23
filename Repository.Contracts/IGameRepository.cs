using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IGameRepository
    {
        void CreateRecord(Game game);
        Task<Game> GetRecordByIdAsync(int id);
        void UpdateRecord(Game game);
        void DeleteRecord(Game game);
    }
}
