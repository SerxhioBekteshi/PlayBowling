namespace Repository.Contracts;

public interface IRepositoryManager
{
    IPlayerRepository PlayerRepository { get; }
    IGameRepository GameRepository { get; }
    IGameFrameRepository GameFrameRepository { get; }
    IFrameRepository FrameRepository { get; }
    Task SaveAsync();
}