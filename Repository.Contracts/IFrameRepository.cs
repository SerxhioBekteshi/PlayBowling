using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IFrameRepository
    {
        void CreateRecord (Frame Frame);
        Task<Frame> GetRecordByIdAsync(int id);
        void UpdateRecord(Frame Frame);
        void DeleteRecord(Frame Frame);
        Task<IEnumerable<Frame>> GetAllRecordsAsync();

    }
}
