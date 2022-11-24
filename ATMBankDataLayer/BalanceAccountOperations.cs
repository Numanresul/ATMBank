
using ATMBankEntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMBankDataLayer
{
    public class BalanceAccountOperations
    {
    private ATMBankDBContext _db;

        public BalanceAccountOperations()
        {
            _db = new ATMBankDBContext();
        }

        public BalanceAccounts? GetById(Guid guidId)
        {
            return _db.BalanceAccounts.Where(x => x.Deleted == false && x.Id == guidId).SingleOrDefault();
        }
        public List<BalanceAccounts> GetAll() 
        { 
            return _db.BalanceAccounts.Where(x => x.Deleted == false).ToList();
        }
        public BalanceAccounts? Edit(BalanceAccounts data)
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

        public BalanceAccounts? Create(BalanceAccounts data)
        {
            try
            {
                _db.Add(data);
               int result =  _db.SaveChanges();
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
            BalanceAccounts? willDeleteBalanceAccounts = _db.BalanceAccounts.Where(x => x.Deleted == false && x.Id == guidId).SingleOrDefault();
            
            if (willDeleteBalanceAccounts != null)
            {
                willDeleteBalanceAccounts.Deleted = true;
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
