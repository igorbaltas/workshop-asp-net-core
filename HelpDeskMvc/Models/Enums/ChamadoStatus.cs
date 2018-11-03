using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Models.Enums
{
    public enum ChamadoStatus : int
    {
        aguardandoAtendimento = 0,
        emAtendimento = 1,
        Encerrado = 2
    }
}
