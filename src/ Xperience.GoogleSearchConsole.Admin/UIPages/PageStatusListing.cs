using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.RepoTemplate.UIPages;

using Xperience.GoogleSearchConsole.Core;

[assembly: UIPage(
    parentType: typeof(SearchConsoleApplicationPage),   // put it under the tile
    slug: "pages",
    uiPageType: typeof(PageStatusListing),
    name: "Page statuses",
    templateName: TemplateNames.LISTING,
    order: UIPageOrder.First)]

namespace Kentico.Xperience.RepoTemplate.UIPages;

/// <summary>Shows cached GSC data in a grid (no actions yet).</summary>
public class PageStatusListing : ListingPage
{
    // tell the listing which *Info* object it should show
    protected override string ObjectType => SearchConsolePageStatusIPageDataInfo.OBJECT_TYPE;

    /// <summary>Columns query for the grid.</summary>
    public override Task ConfigurePage()
    {
        PageConfiguration.ColumnConfigurations
            .AddColumn(nameof(SearchConsolePageStatusIPageDataInfo.Url), "Page URL")
            .AddColumn(nameof(SearchConsolePageStatusIPageDataInfo.CoverageState), "Coverage")
            .AddColumn(nameof(SearchConsolePageStatusIPageDataInfo.LastCrawl), "Last crawl")
            .AddColumn(nameof(SearchConsolePageStatusIPageDataInfo.IssueType), "Issue");

        // Show only rows belonging to the current site
        PageConfiguration.QueryModifiers.AddModifier(
            q => q.WhereEquals(nameof(SearchConsolePageStatusIPageDataInfo.SiteID), 1));


        return base.ConfigurePage();
    }
}
