using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.Admin.Base.UIPages;
using Kentico.Xperience.RepoTemplate.UIPages;

[assembly: UIApplication(
    identifier: SearchConsoleApplicationPage.IDENTIFIER,
     type: typeof(SearchConsoleApplicationPage),
    slug: "GoogleSearchConsole",
    name: "Google Search Console",
    category: BaseApplicationCategories.DEVELOPMENT,
    icon: Icons.Gauge,
    templateName: TemplateNames.SECTION_LAYOUT)]

namespace Kentico.Xperience.RepoTemplate.UIPages;

public sealed class SearchConsoleApplicationPage : ApplicationPage
{
    public const string IDENTIFIER = "GoogleSearchConsole.App";
}
