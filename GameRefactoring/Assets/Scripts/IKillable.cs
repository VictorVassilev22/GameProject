using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    interface IKillable
    {
        void kill();
        void killListener();
        void playDeathAnimation();
    }
}
