using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Template.Data;

namespace Template.Service
{
    public class ClinicRepository:IClinicRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Clinic> _clinicRepository;

        public ClinicRepository()
        {
            _datacontext = new DataContext();
            _clinicRepository = new RepositoryService<Clinic>(_datacontext);
            
        }

        public Clinic GetById(int id)
        {
           return _clinicRepository.GetById(id);
        }

        public List<Clinic> GetAll()
        {
            return _clinicRepository.GetAll().ToList();
        }

        public void Insert(Clinic model)
        {
            _clinicRepository.Insert(model);
        }

        public void Update(Clinic model)
        {
            _clinicRepository.Update(model);
        }

        public void Delete(Clinic model)
        {
            _clinicRepository.Delete(model);
        }

        public IEnumerable<Clinic> Find(Func<Clinic, bool> predicate)
        {
           return _clinicRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
