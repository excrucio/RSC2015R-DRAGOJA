using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Core
{
    public interface IUnitOfWork
    {
        IDbSet<Mec> Mec  { get; }
        IDbSet<Igra> Igra  {get;}
        IDbSet<Igrac> Igrac { get; }
        IDbSet<Korisnik> Korisnik { get; }
        IDbSet<Prepreke> Prepreke { get; }
        IDbSet<Suci> Suci { get; }
        IDbSet<Tim> Tim { get; }
        IDbSet<TimPripadnost> TimPripadnost { get; }
        IDbSet<VrstaPrepreke> VrstaPrepreke { get; }
        DbSet<T> CreateSet<T>() where T : class;
        void SetModified<T>(T item) where T : class;
  
        void Commit();
        void RollbackChanges();
    }
}
