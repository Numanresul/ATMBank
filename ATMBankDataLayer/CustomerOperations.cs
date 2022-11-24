using ATMBankEntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMBankDataLayer
{
    public class CustomerOperations
    {
        private ATMBankDBContext _db;
        public CustomerOperations()
        {
            _db = new ATMBankDBContext();
        }

        public Customers? GetById(Guid guidId)
        {
            return _db.Customers.Where(x => x.Deleted == false && x.Id == guidId).SingleOrDefault();
        }
        public Customers? GetByIdentityNumber(long identityNumber)
        {
            return _db.Customers.Where(x => x.Deleted == false && x.IdentityNumber == identityNumber).SingleOrDefault();
        }
        public List<Customers> GetAll()
        {
            return _db.Customers.Where(x => x.Deleted == false).ToList();
        }
        public Customers? Edit(Customers data)
        {
            try
            {
                _db.Update(data);
                int result = _db.SaveChanges();
                if (result > 0)
                {
                    return data;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Customers? Create(Customers data)
        {
            try
            {
                _db.Add(data);
                int result = _db.SaveChanges();
                if (result > 0)
                {
                    return data;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Guid guidId)
        {
            Customers? willDeleteCustomer = _db.Customers.Where(x => x.Deleted == false && x.Id == guidId).SingleOrDefault();

            if (willDeleteCustomer != null)
            {
                willDeleteCustomer.Deleted = true;
                int result = _db.SaveChanges();
                if (result > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
