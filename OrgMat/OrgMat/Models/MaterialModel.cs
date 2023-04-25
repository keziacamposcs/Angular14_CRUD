using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OrgMat.Models
{
    public class MaterialModel
    {
        public string id_material { get; set; }

        public string nome { get; set; }

        public string descricao { get; set; }

        public string tamanho { get; set; }

        public TipoModel tipo { get; set; }

        public CriticidadeModel criticidade { get; set;}

        public SetorModel setor { get; set; }

        public LocalModel local { get; set; }

        public UsuarioModel usuario { get; set; }

        public bool ativo { get; set; }
    }
}
