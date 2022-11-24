using ATMBankEntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMBankDataLayer
{
    public class CurrencyOperations
    {
        private ATMBankDBContext _db;
        public CurrencyOperations() 
        {
            _db = new ATMBankDBContext();
        }

        public Currencies? GetById(Guid guidId)
        {
            return _db.Currencies.Where(x => x.Deleted == false && x.Id == guidId).SingleOrDefault();
        }
        public Currencies? GetByName(string currencyName)
        {
            return _db.Currencies.Where(x => x.Deleted == false && x.CurrencyName == currencyName).SingleOrDefault();
        }
        public Currencies? GetByType(int accountTyppe)
        {
            return _db.Currencies.Where(x => x.Deleted == false && x.AccountType == accountTyppe).SingleOrDefault();
        }
        public List<Currencies> GetAll()
        {
            return _db.Currencies.Where(x => x.Deleted == false).ToList();
        }
        public Currencies? Edit(Currencies data)
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

        public Currencies? Create(Currencies data)
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
            Currencies? willDeleteCurrency = _db.Currencies.Where(x => x.Deleted == false && x.Id == guidId).SingleOrDefault();

            if (willDeleteCurrency != null)
            {
                willDeleteCurrency.Deleted = true;
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
