using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.ControleDeVinhos.Banco;
using WebApi.ControleDeVinhos.Models;

namespace WebApi.ControleDeVinhos.Repository
{
    public class RepositorioVinhos : IRepositoryVinhos
    {
        private MeuBanco context = new MeuBanco();


        public void DeleteVinho(Vinhos vinho)
        {
            context.vinhos.Remove(vinho);
            this.SaveVinho();
        }

        public IEnumerable<Vinhos> GetVinhos()
        {
            return context.vinhos.ToList();
        }

        public Vinhos GetVinhosById(int id)
        {
            return context.vinhos.Find(id);
        }

        public void InsertVinho(Vinhos vinho)
        {
            context.vinhos.Add(vinho);
            this.SaveVinho();
        }

        public void SaveVinho()
        {
            context.SaveChanges();
        }

        public void UpdateVinho(Vinhos vinho)
        {
            context.Entry(vinho).State = System.Data.Entity.EntityState.Modified;
            this.SaveVinho();
        }
    }
}