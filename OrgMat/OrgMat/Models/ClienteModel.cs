using System.ComponentModel.DataAnnotations;

namespace OrgMat.Models
{
    public class ClienteModel
    {
        public int id_cliente { get; set; }

        public string cliente { get; set; }

        public string cnpj { get; set; }

    }
}
