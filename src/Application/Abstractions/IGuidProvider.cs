namespace Src.Application.Abstractions;

public interface IGuidProvider
{
    Task<long> MakeNewGuid();
}
