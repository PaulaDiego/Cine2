using Cine;
using Cine.Models;
using Cine.Repository;
using System;
using System.Linq;

namespace Cine.Service
{
    public class PeliculasService : IPeliculasService
    {
        private IPeliculasRepository PeliculasRepository;
        public PeliculasService(IPeliculasRepository _PeliculasRepository)
        {
            this.PeliculasRepository = _PeliculasRepository;
        }
        public Pelicula Create(Pelicula Pelicula)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Pelicula = PeliculasRepository.Create(Pelicula);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Pelicula;
            }
        }

        public IQueryable<Pelicula> ReadPeliculas()
        {
            using (var context = new ApplicationDbContext())
            {
                IQueryable<Pelicula> Peliculas;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Peliculas = PeliculasRepository.ReadPeliculas();
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Peliculas;
            }
        }

        public Pelicula GetPelicula(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                Pelicula Pelicula;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Pelicula = PeliculasRepository.Read(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Pelicula;
            }
        }

        public void PutPelicula(Pelicula Pelicula)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        PeliculasRepository.PutPelicula(Pelicula);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
            }
        }

        public Pelicula Delete(long id)
        {
            Pelicula resultado;
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        resultado = PeliculasRepository.Delete(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch(NoEncontradoException)
                    {
                        dbContextTransaction.Rollback();
                        throw;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
            }
            return resultado;
        }
    }
}