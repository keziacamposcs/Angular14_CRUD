using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrgMat.Models
{
    public class TipoModelUpdate
    {
        public Guid id_tipo { get; set; }
        public string tipo { get; set; }

      
    }
}