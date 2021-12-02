using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEonard
{
    internal interface GeneralThreadInterface
    {
        void Start();
        void End();
        void Enable(bool f);
        bool IsRunning();
    }
}
