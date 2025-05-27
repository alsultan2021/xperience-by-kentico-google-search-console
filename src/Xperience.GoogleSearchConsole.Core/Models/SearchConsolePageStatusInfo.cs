using CMS.DataEngine;

// NB: Use your preferred namespace structure
namespace Xperience.GoogleSearchConsole.Core.Models;

[DatabaseTable("XBK_SearchConsole_PageStatus")]
public partial class SearchConsolePageStatusInfo :
    AbstractInfo<SearchConsolePageStatusInfo, ISearchConsolePageStatusInfoProvider>
{
    // ——— required by AbstractInfo ———
    public SearchConsolePageStatusInfo() { }
    public SearchConsolePageStatusInfo(DataRow row) : base(row) { }

    // ——— fields ———
    [DatabaseField, Size(450)]
    public string Url
    {
        get => GetString(nameof(Url));
        set => SetValue(nameof(Url), value);
    }

    [DatabaseField, Size(50)]
    public string CoverageState
    {
        get => GetString(nameof(CoverageState));
        set => SetValue(nameof(CoverageState), value);
    }

    [DatabaseField, Nullable]
    public DateTime? LastCrawl
    {
        get => GetDateTime(nameof(LastCrawl), default);
        set => SetValue(nameof(LastCrawl), value);
    }

    [DatabaseField, Nullable, Size(100)]
    public string? IssueType
    {
        get => GetString(nameof(IssueType));
        set => SetValue(nameof(IssueType), value);
    }

    // site-scoping (optional but recommended)
    [DatabaseField]
    public int SiteID
    {
        get => GetInt(nameof(SiteID));
        set => SetValue(nameof(SiteID), value);
    }
}
