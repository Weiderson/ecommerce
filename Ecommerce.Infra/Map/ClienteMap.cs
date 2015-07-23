using Ecommerce.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Map
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Cliente");
            HasKey(x => x.Cpf);
            Property(x => x.Cpf).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);            
            Property(x => x.Nome).HasMaxLength(100).IsRequired();
            Property(x => x.Endereco).HasMaxLength(120).IsRequired();
            Property(x => x.Email).HasMaxLength(90).IsRequired();
            Property(x => x.Cidade).HasMaxLength(100).IsRequired();
            Property(x => x.Estado).HasMaxLength(50).IsRequired();
            Property(x => x.EstadoCivil).HasMaxLength(12).IsRequired();
            HasMany(x => x.Telefones);
        }
        
    }
}
