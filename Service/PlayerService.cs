using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Repository.Contracts;
using Service.Contracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PlayerService : IPlayerService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public PlayerService(ILoggerManager logger, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<int> CreateRecord(PlayerDTO playerDTO)
        {
            try
            {
                var player = _mapper.Map<Player>(playerDTO);

                player.RegisteredDate = DateTime.UtcNow;

                _repositoryManager.PlayerRepository.CreateRecord(player);
                await _repositoryManager.SaveAsync();

                return player.Id;

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("{0}: {1}", nameof(CreateRecord), ex.Message));
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
