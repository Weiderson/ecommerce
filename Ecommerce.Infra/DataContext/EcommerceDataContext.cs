using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain;
using Ecommerce.Infra;
using Ecommerce.Infra.Map;

namespace Ecommerce.Infra.DataContext
{
    public class  EcommerceDataContext : DbContext
    {
        public EcommerceDataContext()
            : base("EcommerceConnectionString")
        {          
           Database.SetInitializer<EcommerceDataContext>(new EcommerceDataContextInitializer());
           Configuration.LazyLoadingEnabled = false;
           Configuration.ProxyCreationEnabled = false;
        }
             
        public IDbSet<Cliente> Clientes { get; set; }
        public IDbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class EcommerceDataContextInitializer : DropCreateDatabaseIfModelChanges<EcommerceDataContext>
    {
        protected override void Seed(EcommerceDataContext context)
        {
            context.Clientes.Add(new Cliente { Cpf = 03481011636, Nome = "Weiderson Mendes Queiroz", Email = "weiderson.mendes@gmail.com", EstadoCivil = "Divorciado", Endereco = "Rua Batalha dos Palmares, 25 apto501 bl6", Cidade= "Belo Horizonte", Estado = "MG", Cep ="31985-160" });
            context.Clientes.Add(new Cliente { Cpf = 83159734102, Nome = "Carolina Vieira Mendes Queiroz", Email = "carol.1010@hotmail.com", EstadoCivil = "Solteira", Endereco = "Rua Xenônio, 130, ", Cidade = "Ipatinga", Estado = "MG", Cep = "35160-284" });
            context.SaveChanges();
            context.Telefones.Add(new Telefone { Numero = "3187611294", ClienteCpf = 03481011636});
            context.Telefones.Add(new Telefone { Numero = "3193550401", ClienteCpf = 03481011636});
            context.Telefones.Add(new Telefone { Numero = "3193550401", ClienteCpf = 83159734102 });            
            context.SaveChanges();            
            //base.Seed(context);            
        }
    }

}
