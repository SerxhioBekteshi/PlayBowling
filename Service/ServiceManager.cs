using AutoMapper;
using Microsoft.Extensions.Options;
using Repository.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPlayerService> _playerService;
        private readonly Lazy<IGameService> _gameService;
        private readonly Lazy<IFrameService> _frameService;

        public ServiceManager(IRepositoryManager repositoryManager //IDapperRepository dapperRepository
        , ILoggerManager logger
        , IMapper mapper

       )
        {
            _playerService = new Lazy<IPlayerService>(() => new PlayerService(logger, repositoryManager, mapper));
            _gameService = new Lazy<IGameService>(() => new GameService(logger, repositoryManager, mapper));
            _frameService = new Lazy<IFrameService>(() => new FrameService(logger, repositoryManager, mapper));
        }

        public IPlayerService PlayerService => _playerService.Value;
        public IGameService GameService => _gameService.Value;
        public IFrameService FrameService => _frameService.Value;

    }
}
