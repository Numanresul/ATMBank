using ATMBankEntitiesLayer;

namespace ATMBankDataLayer
{
    public class AccountHistoryOperations
    {
        private ATMBankDBContext _db;
        public AccountHistoryOperations()
        {
            _db = new ATMBankDBContext();
        }

        public AccountHistories? GetById(Guid guidId)
        {
            return _db.AccountHistories.Where(x => x.Deleted == false && x.Id == guidId).SingleOrDefault();
        }
        public List<AccountHistories> GetAll()
        {
            return _db.AccountHistories.Where(x => x.Deleted == false).ToList();
        }
        public AccountHistories? Edit(AccountHistories data)
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

        public AccountHistories? Create(AccountHistories data)
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
            AccountHistories? willDeleteAccountHistories = _db.AccountHistories.Where(x => x.Deleted == false && x.Id == guidId).SingleOrDefault();

            if (willDeleteAccountHistories != null)
            {
                willDeleteAccountHistories.Deleted = true;
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
