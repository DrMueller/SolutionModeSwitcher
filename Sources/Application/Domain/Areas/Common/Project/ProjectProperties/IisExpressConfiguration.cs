namespace Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties
{
    public class IisExpressConfiguration
    {
        public IisExpressConfiguration(
            bool useIisExpress,
            int? sslPort,
            string anonymousAuthentication,
            string windowsAuthentication,
            bool? useClassicPipelineMode)
        {
            UseIisExpress = useIisExpress;
            SslPort = sslPort;
            AnonymousAuthentication = anonymousAuthentication;
            WindowsAuthentication = windowsAuthentication;
            UseClassicPipelineMode = useClassicPipelineMode;
        }

        public string AnonymousAuthentication { get; }
        public int? SslPort { get; }
        public bool? UseClassicPipelineMode { get; }
        public bool UseIisExpress { get; }
        public string WindowsAuthentication { get; }
    }
}