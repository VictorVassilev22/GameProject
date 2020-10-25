using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    interface IDamagable
    {
        void takeDamage(float damage);
        float Health
        {
            get;
        }
    }
}
