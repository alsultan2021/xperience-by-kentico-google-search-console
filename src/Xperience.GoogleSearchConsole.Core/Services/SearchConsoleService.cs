// ────────────────────────────────────────────────────────────────────────────────
//  Google Search Console + Indexing API wrapper (stubbed for now)
// ────────────────────────────────────────────────────────────────────────────────


using Google.Apis.Auth.OAuth2;
using Google.Apis.SearchConsole.v1.Data;
using Google.Apis.Services;

//  Alias Google service types so we don’t clash with our own class name.
using GscService = Google.Apis.SearchConsole.v1.SearchConsoleService;
using IndexService = Google.Apis.Indexing.v3.IndexingService;

namespace Xperience.GoogleSearchConsole.Core.Services
{
    public interface ISearchConsoleService
    {
        Task<IReadOnlyList<SearchConsolePageStatusIPageDataInfo>> GetCoverageAsync(string siteUrl, CancellationToken ct);
        Task<UrlInspectionResult?> InspectUrlAsync(string url, CancellationToken ct);
        Task RequestIndexingAsync(string url, CancellationToken ct);
    }

    /// <summary>
    /// Thin wrapper around Google Search Console &amp; Indexing APIs (logic still).
    /// </summary>
    internal sealed class SearchConsoleService : ISearchConsoleService
    {
        private readonly GscService sc;
        private readonly IndexService indexing;

        public SearchConsoleService()        // ← simplest ctor until we wire DI
        {
            // 1) Obtain default credentials (service-account JSON on server or
            //    your user creds if running locally with `gcloud auth application-default login`)
            var credential = GoogleCredential
                .GetApplicationDefault()
                .CreateScoped(
                    GscService.Scope.WebmastersReadonly,    // Search Console read access
                    IndexService.Scope.Indexing);           // Indexing API write access

            // 2) Shared initializer for both Google services
            var init = new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Xperience-GSC"
            };

            sc = new GscService(init);
            indexing = new IndexService(init);
        }

        // ─────────────────────────────────────
        //  Stubbed methods (compile-time only)
        // ─────────────────────────────────────

        public Task<IReadOnlyList<SearchConsolePageStatusIPageDataInfo>> GetCoverageAsync(
            string siteUrl, CancellationToken ct) =>
            Task.FromResult<IReadOnlyList<SearchConsolePageStatusIPageDataInfo>>(Array.Empty<SearchConsolePageStatusIPageDataInfo>());

        public Task<UrlInspectionResult?> InspectUrlAsync(string url, CancellationToken ct) =>
            Task.FromResult<UrlInspectionResult?>(null);

        public Task RequestIndexingAsync(string url, CancellationToken ct) =>
            Task.CompletedTask;
    }
}
