using System;
using System.Text;
using System.Threading.Tasks;

namespace Herolab.Umbraco
{
    public interface IContentServer
    {
        void Init(String workingDir);

        System.String GetObject();
    }
}
