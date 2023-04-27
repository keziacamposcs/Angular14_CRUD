using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrgMat.Models
{
    public class EquipamentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id_equipamento { get; set; }

        public String equipamento { get; set; }

        public String descricao { get; set; }

        public String num_serie { get; set; }

        public String tamanho { get; set; }

        public String anexo { get; set; }

        public TipoModel tipo { get; set; }

        public CriticidadeModel criticidade { get; set; }

        public SetorModel setor { get; set; }

        public ClienteModel cliente { get; set; }

        public LocalModel local { get; set; }

        public FornecedorModel fornecedor { get; set; }
    }
}
