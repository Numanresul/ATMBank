using ATMBankBusinessLayer.Dtos;
using ATMBankEntitiesLayer;
using ATMBankDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ATMBankBusinessLayer
{
    public class WithdrawOperation
    {
        private CustomerOperations _customerOperations;
        private CurrencyOperations _currencyOperations;
        private BalanceAccountOperations _balanceAccountOperations;
        public WithdrawOperation()
        {
            _customerOperations = new CustomerOperations();
            _currencyOperations = new CurrencyOperations();
            _balanceAccountOperations = new BalanceAccountOperations();
        }
        public ReturnDataDtos Withdraw(WithdrawDataDto withdrawDataDto)
        {
            ReturnDataDtos result = new ReturnDataDtos();

            Customers? CurrentCustomer = _customerOperations.GetById(withdrawDataDto.CustomersId);
            if (CurrentCustomer != null)
            {
                Currencies? CurrentCurrency = _currencyOperations.GetByName(withdrawDataDto.CurrencyName);
                if (CurrentCurrency != null)
                {
                    BalanceAccounts? CurrentBalanceAccount = _balanceAccountOperations.GetAll()
                    .Where(x => x.CustomersId == CurrentCustomer.Id && x.CurrenciesId == CurrentCurrency.Id && x.Deleted == false).SingleOrDefault();

                    if (CurrentBalanceAccount != null)
                    {
                        if (CurrentBalanceAccount.CurrentBalance < withdrawDataDto.AmountToBeWithdrawn)
                        {
                            result.Result = false;
                            result.Message = "You do not have enough balance !";
                        }
                        else
                        {
                            CurrentBalanceAccount.CurrentBalance = CurrentBalanceAccount.CurrentBalance - withdrawDataDto.AmountToBeWithdrawn;
                            var proccessResult = _balanceAccountOperations.Edit(CurrentBalanceAccount);
                            if (proccessResult != null)
                            {
                                result.Result = true;
                                result.Message = $"Transaction completed successfully. Your current balance is {CurrentBalanceAccount.CurrentBalance} {CurrentCurrency.CurrencyName}";
                            }
                            else
                            {
                                result.Result = false;
                                result.Message = "Error";
                            }
                        }
                    }
                    else
                    {

                       Currencies? currency = _currencyOperations.GetByName(withdrawDataDto.CurrencyName);

                        BalanceAccounts newBalanceAccounts = new BalanceAccounts();
                        newBalanceAccounts.CurrenciesId = currency.Id;
                        newBalanceAccounts.CustomersId = withdrawDataDto.CustomersId;
                        newBalanceAccounts.CurrentBalance = 0;
                        newBalanceAccounts.Deleted = false;
                        newBalanceAccounts.CreatedBy = "Default";
                        _balanceAccountOperations.Create(newBalanceAccounts);


                        result.Result = false;
                        result.Message = "Your transaction could not be completed because you do not have a balance account, but your account has been created. You can try the transaction again.";
                    }

                }
                else
                {
                    result.Result = false;
                    result.Message = "Invalid account currency !";
                }

            }
            else
            {
                result.Result = false;
                result.Message = "Invalid customer !";
            }

            return result;
        }
    }
}
