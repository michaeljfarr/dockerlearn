using System;

namespace Herolab.WebAPI.Config
{
    public interface ISystemStatus
    {
        String Magic { get; }
    }
    public class SystemStatus : ISystemStatus
    {
        public String Magic { get { return "asdf"; } }
    }
}