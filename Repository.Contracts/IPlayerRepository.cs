using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IPlayerRepository
    {
        void CreateRecord(Player device);
        Task<Player> GetRecordByIdAsync(int id);
        void UpdateRecord(Player device);
        void DeleteRecord(Player device);

    }
}
