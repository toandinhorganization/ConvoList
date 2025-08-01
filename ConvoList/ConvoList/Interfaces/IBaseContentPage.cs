using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvoList.Interfaces
{
    public interface IBaseContentPage
    {
        Task InitializeAsync(CancellationToken cancellation);
    }
}
