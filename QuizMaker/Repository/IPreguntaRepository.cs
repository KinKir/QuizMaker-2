using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    internal interface IPReguntaRepository
    {

        public bool Save(Pregunta p);

        public Pregunta GetByID(int id);

        public bool Delete(int id);

        public bool Update(Pregunta p);

        public IEnumerable<Pregunta> GetAll();

        public bool Exit(int id);


    }
}
