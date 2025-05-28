using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.RepoTemplate;

[assembly: CMS.RegisterModule(typeof(SearchConsoleAdminModule))]

namespace Kentico.Xperience.RepoTemplate;

internal class SearchConsoleAdminModule : AdminModule
{
    public SearchConsoleAdminModule()
    : base(nameof(SearchConsoleAdminModule))
    {
    }

    protected override void OnInit()
    {
        base.OnInit();

        RegisterClientModule("searchconsole", "web-admin");


    }


}
