using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public abstract class BaseLogic<TPoco>  where TPoco : IPoco
    {
        protected IDataRepository<TPoco> _repository;
        public BaseLogic(IDataRepository<TPoco> repository)
        {
            _repository = repository;
        }

        protected virtual void Verify(TPoco[] pocos)
        {
            return;
        }

        // This method could be removed after adding GetSingle
        public virtual TPoco Get(Guid? id)
        {
            if (id == null)
                return default(TPoco);
            return _repository.GetSingle(c => c.Id == id);
        }

        public virtual TPoco GetSingle(Func<TPoco, bool> where, params System.Linq.Expressions.Expression<Func<TPoco, object>>[] navigationProperties)
        {
            return _repository.GetSingle(where, navigationProperties);
        }

        public virtual List<TPoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual List<TPoco> GetList(Func<TPoco, bool> where, params System.Linq.Expressions.Expression<Func<TPoco, object>>[] navigationProperties)
        {
            return _repository.GetList(where, navigationProperties).ToList();
        }
       

        
        public virtual void Add(TPoco[] pocos)
        {
            foreach (TPoco poco in pocos)
            {
                if (poco.Id == Guid.Empty)
                {
                    poco.Id = Guid.NewGuid();
                }
            }

            _repository.Add(pocos);
        }

        public virtual void Update(TPoco[] pocos)
        {
            _repository.Update(pocos);
        }

        public void Delete(TPoco[] pocos)
        {
            _repository.Remove(pocos);
        }
    }
}
