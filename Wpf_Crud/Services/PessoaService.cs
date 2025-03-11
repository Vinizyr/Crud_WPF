using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Crud.Context;
using Wpf_Crud.Models;

namespace Wpf_Crud.Services
{
    internal class PessoaService
    {
        public List<Pessoa> GetAll()
        {
            using var db = new CrudWpfContext();
            return db.Pessoas.ToList();
        }

        public void Add(Pessoa pessoa)
        {
            using var db = new CrudWpfContext();
            db.Pessoas.Add(pessoa);
            db.SaveChanges();
        }

        public void Update(Pessoa pessoa)
        {
            using var db = new CrudWpfContext();
            db.Pessoas.Update(pessoa);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            using var db = new CrudWpfContext();
            var pessoa = db.Pessoas.Find(id);
            if (pessoa != null)
            {
                db.Pessoas.Remove(pessoa);
                db.SaveChanges();
            }
        }
    }
}
