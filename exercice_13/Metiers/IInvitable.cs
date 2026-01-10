using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice13
{
    internal interface IInvitable
    {
        bool Est_disponible(DateTime date);
        string Inviter(DateTime date);
    }
}
