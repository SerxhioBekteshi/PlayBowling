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
    internal class FrameRepository : RepositoryBase<Frame>, IFrameRepository
    {
        public FrameRepository(RepositoryContext repositoryContext)
          : base(repositoryContext)
        {
        }
        public void CreateRecord(Frame frame) => Create(frame);
        public void DeleteRecord(Frame frame) => Delete(frame);
        public async Task<Frame> GetRecordByIdAsync(int id) =>
        await FindByCondition(c => c.Id.Equals(id))
              .SingleOrDefaultAsync();
        public void UpdateRecord(Frame frame) => Update(frame);
        public async Task<IEnumerable<Frame>> GetAllRecordsAsync() => await FindAll().ToListAsync();
    }
}
