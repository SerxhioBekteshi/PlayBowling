using Repository.Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IPlayerRepository> _playerRepository;
    private readonly Lazy<IGameRepository> _gameRepository;
    private readonly Lazy<IGameFrameRepository> _gameFrameRepository;
    private readonly Lazy<IFrameRepository> _frameRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _playerRepository = new Lazy<IPlayerRepository>(() => new PlayerRepository(repositoryContext));
        _gameRepository = new Lazy<IGameRepository>(() => new GameRepository(repositoryContext));
        _frameRepository = new Lazy<IFrameRepository>(() => new FrameRepository(repositoryContext));
        _gameFrameRepository = new Lazy<IGameFrameRepository>(() => new GameFrameRepository(repositoryContext));
    }

    public IPlayerRepository PlayerRepository => _playerRepository.Value;
    public IGameRepository GameRepository => _gameRepository.Value;
    public IFrameRepository FrameRepository => _frameRepository.Value;
    public IGameFrameRepository GameFrameRepository => _gameFrameRepository.Value;
    public async Task SaveAsync()
    {
        _repositoryContext.ChangeTracker.AutoDetectChangesEnabled = false;
        await _repositoryContext.SaveChangesAsync();
    }
}