using Ecommerce.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Map
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            ToTable("Telefone");
            HasKey(x => x.Id);
            Property(x => x.Numero).HasMaxLength(12).IsRequired();
            Property(x => x.ClienteCpf).IsRequired();
        }
    }
}
