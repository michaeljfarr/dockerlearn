using Umbraco.Core.Configuration.UmbracoSettings;

namespace Herolab.Umbraco
{
    public class UmbracoSettings : IUmbracoSettingsSection
    {
        public UmbracoSettings()
        {
            Content = new UmbracoContentSettings();
            DistributedCall = new DistributedCallSection();
            RequestHandler = new RequestHandlerSection();
        }
        public IContentSection Content { get; }
        public ISecuritySection Security { get; }
        public IRequestHandlerSection RequestHandler { get; }
        public ITemplatesSection Templates { get; }
        public IDeveloperSection Developer { get; }
        public IViewStateMoverModuleSection ViewStateMoverModule { get; }
        public ILoggingSection Logging { get; }
        public IScheduledTasksSection ScheduledTasks { get; }
        public IDistributedCallSection DistributedCall { get; }
        public IRepositoriesSection PackageRepositories { get; }
        public IProvidersSection Providers { get; }
        public IHelpSection Help { get; }
        public IWebRoutingSection WebRouting { get; }
        public IScriptingSection Scripting { get; }
    }
}