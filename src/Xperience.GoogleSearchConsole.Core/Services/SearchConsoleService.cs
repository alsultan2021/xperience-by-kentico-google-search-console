

using Xperience.GoogleSearchConsole.Core.Models;

namespace Xperience.GoogleSearchConsole.Core.Services;

public interface ISearchConsoleService
{
    public Task<IReadOnlyList<SearchConsolePageStatusInfo>> GetCoverageAsync(
        string siteUrl, CancellationToken ct);

    public Task<object?> InspectUrlAsync(string url, CancellationToken ct);

    public Task RequestIndexingAsync(string url, CancellationToken ct);
}

internal sealed class SearchConsoleService : ISearchConsoleService
{
    public Task<IReadOnlyList<SearchConsolePageStatusInfo>> GetCoverageAsync(
        string siteUrl, CancellationToken ct)
        => Task.FromResult<IReadOnlyList<SearchConsolePageStatusInfo>>(Array.Empty<SearchConsolePageStatusInfo>());

    public Task<object?> InspectUrlAsync(string url, CancellationToken ct)
        => Task.FromResult<object?>(null);

    public Task RequestIndexingAsync(string url, CancellationToken ct)
        => Task.CompletedTask;
}
