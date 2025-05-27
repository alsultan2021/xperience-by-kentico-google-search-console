using CMS.DataEngine;

namespace Xperience.GoogleSearchConsole.Core.Models;

public interface ISearchConsolePageStatusInfoProvider
    : IInfoProvider<SearchConsolePageStatusInfo>, IInfoByIdProvider<SearchConsolePageStatusInfo>
{ }

/// <summary>Standard Kentico InfoProvider.</summary>
[RegisterImplementation(typeof(ISearchConsolePageStatusInfoProvider))]
public class SearchConsolePageStatusInfoProvider :
    InfoProviderBase<SearchConsolePageStatusInfo>,
    ISearchConsolePageStatusInfoProvider
{
    public SearchConsolePageStatusInfoProvider(IProviderConfiguration<SearchConsolePageStatusInfo> config)
        : base(config) { }
}
