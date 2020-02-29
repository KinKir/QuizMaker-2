using Data.DbModels;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class PreguntaRepository : IPReguntaRepository
    {
        #region Fiels
        private readonly DB_Context db;

        public PreguntaRepository()
        {
            db = new DB_Context();
        }
        public bool Delete(int id)
        {
            try
            {
                var data = db.TPregunta.Find(id);
                db.TPregunta.Remove(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Exit(int id)
        {
            try
            {
                var data = db.TPregunta.Find(id);
                return data != null ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Pregunta> GetAll()
        {
            try
            {
                var data = db.TPregunta.Select(x => new Pregunta()
                {
                    Id = x.Id,
                    Texto = x.Texto,
                    IdTipoPregunta = x.IdTipoPregunta,
                    Orden = x.Orden,
                    Instrucciones = x.Instrucciones,
                    IdCuestionario = x.IdCuestionario,
                    Peso = x.Peso,
                    RangoMaximo = x.RangoMaximo,
                    RangoMinimo = x.RangoMinimo,
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Pregunta GetByID(int id)
        {

            try
            {
                var data = db.TPregunta.Find(id);
                return data != null ? ConvertToDBDDomain(data) : null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Save(Pregunta p)
        {
            try
            {
                var dbtable = ConvertToDBTable(p);
                db.TPregunta.Add(dbtable);
                db.SaveChanges();

                int i = dbtable.Id;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Pregunta p)
        {
            try
            {
                var data = db.TPregunta.Find(p.Id);
                if (data != null)
                {

                    db.TPregunta.Update(ConvertToDBTable(p));
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion Other Methos
        public TPregunta ConvertToDBTable(Pregunta p)
        {
            return new TPregunta
            {
                Id = p.Id,
                Texto = p.Texto,
                IdTipoPregunta = p.IdTipoPregunta,
                Orden = p.Orden,
                Instrucciones = p.Instrucciones,
                IdCuestionario = p.IdCuestionario,
                Peso = p.Peso,
                RangoMaximo = p.RangoMaximo,
                RangoMinimo = p.RangoMinimo,
            };
        }
        public Pregunta ConvertToDBDDomain(TPregunta p)
        {
            return new Pregunta
            {


                Id = p.Id,
                Texto = p.Texto,
                IdTipoPregunta = p.IdTipoPregunta,
                Orden = p.Orden,
                Instrucciones = p.Instrucciones,
                IdCuestionario = p.IdCuestionario,
                Peso = p.Peso,
                RangoMaximo = p.RangoMaximo,
                RangoMinimo = p.RangoMinimo,


            };
        }
    }
}