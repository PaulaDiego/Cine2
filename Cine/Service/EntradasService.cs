using Cine;
using Cine.Models;
using Cine.Repository;
using System;
using System.Linq;

namespace Cine.Service
{
    public class EntradasService : IEntradasService
    {
        private IEntradasRepository EntradasRepository;
        public EntradasService(IEntradasRepository _EntradasRepository)
        {
            this.EntradasRepository = _EntradasRepository;
        }
        public Entrada Create(Entrada Entrada)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Entrada = EntradasRepository.Create(Entrada);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Entrada;
            }
        }

        public IQueryable<Entrada> ReadEntradas()
        {
            using (var context = new ApplicationDbContext())
            {
                IQueryable<Entrada> Entradas;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Entradas = EntradasRepository.ReadEntradas();
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Entradas;
            }
        }

        public Entrada GetEntrada(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                Entrada Entrada;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Entrada = EntradasRepository.Read(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Entrada;
            }
        }

        public void PutEntrada(Entrada Entrada)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        EntradasRepository.PutEntrada(Entrada);
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

        public Entrada Delete(long id)
        {
            Entrada resultado;
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        resultado = EntradasRepository.Delete(id);
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