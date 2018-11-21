using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskMvc.Models
{
    public class Inventario
    {
        [Key]
        public int idMaquina { get; set; }
        public string hostNameMaquina { get; set; }
        public string sistemaMaquina { get; set; }
        public string tipoEquipamento { get; set; }
        public string cpuMaquina { get; set; }
        public string memoriaMaquina { get; set; }
        public string localMaquina { get; set; }

        public Inventario()
        {

        }

        public Inventario(int idMaquina, string hostNameMaquina, string sistemaMaquina, string tipoEquipamento, string cpuMaquina, string memoriaMaquina, string localMaquina)
        {
            this.idMaquina = idMaquina;
            this.hostNameMaquina = hostNameMaquina;
            this.sistemaMaquina = sistemaMaquina;
            this.tipoEquipamento = tipoEquipamento;
            this.cpuMaquina = cpuMaquina;
            this.memoriaMaquina = memoriaMaquina;
            this.localMaquina = localMaquina;
        }
    }
}
