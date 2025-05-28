// ────────────────────────────────────────────────────────────────────────────────
//  Data object – follows the exact pattern used in XperienceCommunity.Sustainability
// ────────────────────────────────────────────────────────────────────────────────

using System;
using System.Data;
using System.Drawing;

using CMS;
using CMS.DataEngine;
using CMS.Helpers;

using Xperience.GoogleSearchConsole.Core;

//  Register the object type so Kentico (XbyK) discovers it at start-up.
[assembly: RegisterObjectType(typeof(SearchConsolePageStatusIPageDataInfo), SearchConsolePageStatusIPageDataInfo.OBJECT_TYPE)]

namespace Xperience.GoogleSearchConsole.Core
{
    /// <summary>
    /// Cached Google Search Console status for a single page URL.
    /// </summary>
    public partial class SearchConsolePageStatusIPageDataInfo :
        AbstractInfo<SearchConsolePageStatusIPageDataInfo, IInfoProvider<SearchConsolePageStatusIPageDataInfo>>,
        IInfoWithId
    {
        // ────────────────────────────────────────────────────────────────────────
        //  Object-type metadata  (table name, PK, cache behaviour, etc.)
        // ────────────────────────────────────────────────────────────────────────

        public const string OBJECT_TYPE = "xperiencegooglesearchconsole.pagestatus";

        public static readonly ObjectTypeInfo TYPEINFO =
            new ObjectTypeInfo(typeof(IInfoProvider<SearchConsolePageStatusIPageDataInfo>),
                               OBJECT_TYPE,
                               "XBK_SearchConsole_PageStatus",   // DB table
                               "PageStatusID",                  // PK column
                               null, null, null, null, null, null, null)
            {
                TouchCacheDependencies = true,
            };

        // ────────────────────────────────────────────────────────────────────────
        //  Primary key (required by IInfoWithId)
        // ────────────────────────────────────────────────────────────────────────

        [DatabaseField]
        public virtual int PageStatusID
        {
            get => ValidationHelper.GetInteger(GetValue(nameof(PageStatusID)), 0);
            set => SetValue(nameof(PageStatusID), value);
        }

        // ────────────────────────────────────────────────────────────────────────
        //  Data columns
        // ────────────────────────────────────────────────────────────────────────

        [DatabaseField]
        public virtual int SiteID
        {
            get => ValidationHelper.GetInteger(GetValue(nameof(SiteID)), 0);
            set => SetValue(nameof(SiteID), value);
        }

        [DatabaseField]
        public virtual string Url
        {
            get => ValidationHelper.GetString(GetValue(nameof(Url)), string.Empty);
            set => SetValue(nameof(Url), value);
        }

        [DatabaseField]
        public virtual string CoverageState
        {
            get => ValidationHelper.GetString(GetValue(nameof(CoverageState)), string.Empty);
            set => SetValue(nameof(CoverageState), value);
        }

        [DatabaseField]
        public virtual DateTime? LastCrawl
        {
            get => ValidationHelper.GetDateTime(GetValue(nameof(LastCrawl)), DateTime.Now);
            set => SetValue(nameof(LastCrawl), value);
        }

        [DatabaseField]
        public virtual string IssueType
        {
            get => ValidationHelper.GetString(GetValue(nameof(IssueType)), string.Empty);
            set => SetValue(nameof(IssueType), value);
        }

        // ────────────────────────────────────────────────────────────────────────
        //  CRUD hooks – delegate to the provider
        // ────────────────────────────────────────────────────────────────────────

        protected override void DeleteObject() => Provider.Delete(this);
        protected override void SetObject() => Provider.Set(this);

        // ────────────────────────────────────────────────────────────────────────
        //  Constructors
        // ────────────────────────────────────────────────────────────────────────

        public SearchConsolePageStatusIPageDataInfo()
            : base(TYPEINFO) { }

        public SearchConsolePageStatusIPageDataInfo(DataRow dr)
            : base(TYPEINFO, dr) { }
    }
}
