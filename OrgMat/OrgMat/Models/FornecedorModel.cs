using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrgMat.Models
{
    public class FornecedorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_fornecedor { get; set; }

        public String fornecedor { get; set; }

        public String cnpj { get; set; }

        public String endereco { get; set; }

        public String telefone { get; set; }

        public String email { get; set; }

        public String vendedor { get; set; }
    }
}
