using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.ControleDeVinhos.Models;

namespace WebApi.ControleDeVinhos.Repository
{
    public interface IRepositoryVinhos
    {
        IEnumerable<Vinhos> GetVinhos();
        Vinhos GetVinhosById(int id);
        void InsertVinho(Vinhos vinho);
        void UpdateVinho(Vinhos vinho);
        void DeleteVinho(Vinhos vinho);
        void SaveVinho();
    }
}