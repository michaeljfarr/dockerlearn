using System.Collections.Generic;
using Umbraco.Core;
using Umbraco.Core.Configuration.UmbracoSettings;

namespace Herolab.Umbraco
{
    public class UmbracoContentSettings : IContentSection
    {
        public UmbracoContentSettings()
        {
            EnsureUniqueNaming = true;
        }

        public string NotificationEmailAddress { get; }
        public bool DisableHtmlEmail { get; }
        public IEnumerable<string> ImageFileTypes { get; }
        public IEnumerable<string> ImageTagAllowedAttributes { get; }
        public IEnumerable<IImagingAutoFillUploadField> ImageAutoFillProperties { get; }
        public string ScriptFolderPath { get; }
        public IEnumerable<string> ScriptFileTypes { get; }
        public bool ScriptEditorDisable { get; }
        public bool ResolveUrlsFromTextString { get; }
        public bool UploadAllowDirectories { get; }
        public IEnumerable<IContentErrorPage> Error404Collection { get; }
        public bool EnsureUniqueNaming { get; }
        public bool TidyEditorContent { get; }
        public string TidyCharEncoding { get; }
        public bool XmlCacheEnabled { get; }
        public bool ContinouslyUpdateXmlDiskCache { get; }
        public bool XmlContentCheckForDiskChanges { get; }
        public bool EnableSplashWhileLoading { get; }
        public string PropertyContextHelpOption { get; }
        public bool UseLegacyXmlSchema { get; }
        public bool ForceSafeAliases { get; }
        public string PreviewBadge { get; }
        public int UmbracoLibraryCacheDuration { get; }
        public MacroErrorBehaviour MacroErrorBehaviour { get; }
        public IEnumerable<string> DisallowedUploadFiles { get; }
        public bool CloneXmlContent { get; }
        public bool GlobalPreviewStorageEnabled { get; }
        public string DefaultDocumentTypeProperty { get; }
    }
}