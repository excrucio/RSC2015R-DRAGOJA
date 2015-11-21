using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bazaContext _context;

        public UnitOfWork(bazaContext context)
        {
            _context = context;
            _context.Configuration.ProxyCreationEnabled = true;
            _context.Configuration.LazyLoadingEnabled = true;
        }

        IDbSet<Mec> _mec;
        public IDbSet<Mec> Mec
        {
            get
            {
                if ( _mec == null)
                    _mec = _context.Set<Mec>();

                return _mec;
            }
        }

        IDbSet<Igra> _igra;
        public IDbSet<Igra> Igra
        {
            get
            {
                if (_igra == null)
                    _igra = _context.Set<Igra>();

                return _igra;
            }
        }

        IDbSet<Igrac> _igrac;
        public IDbSet<Igrac> Igrac
        {
            get {
                if (_igrac == null)
                    _igrac = _context.Set<Igrac>();

                return _igrac;
            }
        }

        IDbSet<Korisnik> _korisnik;
        public IDbSet<Korisnik> Korisnik
        {
            get
            {
                if (_korisnik == null)
                    _korisnik= _context.Set<Korisnik>();
          
                return _korisnik;
            }
        }

        IDbSet<Prepreke> _prepreke;
        public IDbSet<Prepreke> Prepreke
        {
            get
            {
                if (_prepreke == null)
                    _prepreke = _context.Set<Prepreke>();

                return _prepreke;
            }
        }

        IDbSet<Suci> _suci;
        public IDbSet<Suci> Suci
        {
            get
            {
                if (_suci == null)
                    _suci = _context.Set<Suci>();

                return _suci;
            }
        }

        IDbSet<TimPripadnost> _timpripadnost;
        public IDbSet<TimPripadnost> TimPripadnost
        {
            get
            {
                if (_timpripadnost == null)
                    _timpripadnost = _context.Set<TimPripadnost>();

                return _timpripadnost;
            }
        }

        IDbSet<VrstaPrepreke> _vrstaPrepreke;
        public IDbSet<VrstaPrepreke> VrstaPrepreke
        {
            get
            {
                if (_vrstaPrepreke == null)
                    _vrstaPrepreke = _context.Set<VrstaPrepreke>();

                return _vrstaPrepreke;
            }
        }

        IDbSet<Tim> _tim;
        public IDbSet<Tim> Tim
        {
            get
            {
                if (_tim == null)
                    _tim = _context.Set<Tim>();

                return _tim;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollbackChanges()
        {
            _context.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        public DbSet<T> CreateSet<T>()
            where T : class
        {
            return _context.Set<T>();
        }

        public void SetModified<T>(T item)
            where T : class
        {
            _context.Entry<T>(item).State = EntityState.Modified;
        }

    }
}
