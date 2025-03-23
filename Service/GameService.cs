using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Repository.Contracts;
using Service.Contracts;
using Shared.DTO;
using Shared.ResponseFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GameService : IGameService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GameService(ILoggerManager logger, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<bool> UpdateGameFrame(int frameId, int gameId)
        {
            try
            {
                var currentGameFrame = await _repositoryManager.GameFrameRepository.GetRecordByGameIdAndFrameIdAsync(gameId, frameId);
                if (currentGameFrame is null)
                {

                    GameFrame gameFrame = new GameFrame();
                    gameFrame.GameId = gameId;
                    gameFrame.FrameId = frameId;
                    _repositoryManager.GameFrameRepository.CreateRecord(gameFrame);
                }

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("{0}: {1}", nameof(CreateRecord), ex.Message));
                throw new BadRequestException(ex.Message);
            }
        }
        public async Task<int> CreateRecord(GameDTO gameDTO)
        {
            try
            {
                var game = _mapper.Map<Game>(gameDTO);

                game.StartTime = DateTime.UtcNow;
                game.IsCompleted = false;
                game.TotalScore = 0;
                _repositoryManager.GameRepository.CreateRecord(game);
                await _repositoryManager.SaveAsync();


                //PREVIOUS LOGIC ONE GAME PER FRAME 
                //var frame = await _repositoryManager.FrameRepository.GetRecordByIdAsync(gameDTO.FrameId);

                //if (frame is null)
                //{
                //    throw new NotFoundException(string.Format("Frame with Id {0} not found!", gameDTO.FrameId));
                //}


                //CURRENT LOGIC ONE GAME WILL HAVE 10 FRAMES - ROUNDS 
                for (int i = 1; i <= 10; i++)
                {
                    GameFrame gameFrame = new GameFrame();
                    gameFrame.GameId = game.Id;
                    gameFrame.FrameId = i;
                    gameFrame.IsSpareOrStrike = false;

                    _repositoryManager.GameFrameRepository.CreateRecord(gameFrame);
                    await _repositoryManager.SaveAsync();
                }

                return game.Id;

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("{0}: {1}", nameof(CreateRecord), ex.Message));
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task<bool> UpdateGameStats(int id, GamePointsDTO gamePointsDTO)
        {
            try
            {
                var existingGame = await _repositoryManager.GameRepository.GetRecordByIdAsync(id);

                if (existingGame is null)
                {
                    throw new NotFoundException(string.Format("Game with Id {0} not found!", id));
                }


                var frame = await _repositoryManager.FrameRepository.GetRecordByIdAsync(gamePointsDTO.FrameId);

                if (frame is null)
                {
                    throw new NotFoundException(string.Format("Frame with Id {0} not found!", gamePointsDTO.FrameId));
                }

                var existingGameFrame = await _repositoryManager.GameFrameRepository.GetRecordByGameIdAndFrameIdAsync(existingGame.Id, frame.Id);
                if (existingGameFrame is null)
                {
                    throw new NotFoundException($"GameFrame for Game Id {existingGame.Id}, Frame {gamePointsDTO.FrameId} not found!");
                }
                if (gamePointsDTO.FirstShotPoints is not null)
                {
                    existingGameFrame.FirstThrow = gamePointsDTO.FirstShotPoints;
                }

                if (gamePointsDTO.SecondShotPoints is not null)
                {
                    existingGameFrame.SecondThrow = gamePointsDTO.SecondShotPoints;
                }

                if (gamePointsDTO.ThirdShotPoints is not null)
                {
                    existingGameFrame.ThirdThrow = gamePointsDTO.ThirdShotPoints;
                }

                int frameScore = (gamePointsDTO.FirstShotPoints ?? 0) +
                          (gamePointsDTO.SecondShotPoints ?? 0) +
                          (gamePointsDTO.ThirdShotPoints ?? 0);


                // Handle strike and spare
                bool isStrike = gamePointsDTO.FirstShotPoints == 10;
                bool isSpare = !isStrike && (gamePointsDTO.FirstShotPoints + gamePointsDTO.SecondShotPoints == 10);
                existingGameFrame.IsSpareOrStrike = isStrike || isSpare;

                _repositoryManager.GameFrameRepository.UpdateRecord(existingGameFrame);
                await _repositoryManager.SaveAsync();



                if (isStrike || isSpare)
                {0
                    //MISCONCEPT OF POINTS CALCULATION
                    //if(gamePointsDTO.FrameId > 1)
                    //{
                    //    var previousFrame = await _repositoryManager.GameFrameRepository.GetRecordByGameIdAndFrameIdAsync(existingGame.Id, gamePointsDTO.FrameId - 1);
                    //    if (previousFrame is not null)
                    //    {
                    if (isStrike)
                    {
                        // Base 10 + bonus 10 + next two balls
                        existingGameFrame.TotalScore = 10 + 10 + (gamePointsDTO.SecondShotPoints ?? 0) + (gamePointsDTO.ThirdShotPoints ?? 0);
                    }
                    else if (isSpare)
                    {
                        // Base 10 + bonus 10 + next ball
                        existingGameFrame.TotalScore = 10 + 10 + (gamePointsDTO.ThirdShotPoints ?? 0);
                    }

                    //update the totalScore 
                    _repositoryManager.GameFrameRepository.UpdateRecord(existingGameFrame);
                    await _repositoryManager.SaveAsync();
                    //    }
                    //}                    
                }
                else
                {
                    existingGameFrame.TotalScore = frameScore;
                    _repositoryManager.GameFrameRepository.UpdateRecord(existingGameFrame);
                    await _repositoryManager.SaveAsync();
                }


                if (gamePointsDTO.FrameId == 10)
                {
                    existingGame.TotalScore = await CalculateTotalScore(existingGame.Id);
                    existingGame.IsCompleted = true;
                    existingGame.EndTime = DateTime.Now;

                    _repositoryManager.GameRepository.UpdateRecord(existingGame);
                    await _repositoryManager.SaveAsync();
                }

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("{0}: {1}", nameof(CreateRecord), ex.Message));
                throw new BadRequestException(ex.Message);
            }
        }
        public async Task<GameResultsDTO> GetGameResults(int gameId)
        {
            var existingGame = await _repositoryManager.GameRepository.GetRecordByIdAsync(gameId);

            if (existingGame is null)
            {
                throw new NotFoundException(string.Format("Game with Id {0} not found!", gameId));
            }

            var frames = await _repositoryManager.GameFrameRepository.GetAllFramesByGameIdAsync(gameId);

            GameResultsDTO gameResults = new GameResultsDTO();
            gameResults.TotalScore = existingGame.TotalScore;
            gameResults.GameFrames = frames;

            return gameResults;

        }
        private async Task<int> CalculateTotalScore(int gameId)
        {
            return await _repositoryManager.GameFrameRepository.GetAllByGameIdAsync(gameId);
        }
    }
}
