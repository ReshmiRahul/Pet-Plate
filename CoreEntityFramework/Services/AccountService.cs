using PetAdoption.Interfaces;
//using PetAdoption.Migrations;
using PetAdoption.Models;
using Microsoft.EntityFrameworkCore;

namespace PetAdoption.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;
        // dependency injection of database context
        public AccountService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<AccountDto>> ListAccounts()
        {
            // all Accounts
            List<Account> Accounts = await _context.Accounts
                .ToListAsync();
            // empty list of data transfer object AccountDto
            List<AccountDto> AccountDtos = new List<AccountDto>();
            // foreach account record in database
            foreach (Account Account in Accounts)
            {
                // create new instance of AccountDto, add to list
                AccountDtos.Add(new AccountDto()
                {
                    AccountId = Account.AccountId,
                    AccountName = Account.AccountName,
                    AccountEmail = Account.AccountEmail,
                    AccountRole = Account.AccountRole,
                    AccountPassword = Account.AccountPassword,
                    AccountCity = Account.AccountCity,
                    AccountState = Account.AccountState
                });
            }
            // return AccountDtos
            return AccountDtos;

        }


        public async Task<AccountDto?> FindAccount(int id)
        {
            // include will join account(i)tem with 1 Pet, 1 application
            // first or default async will get the first account(i)tem matching the {id}
            var Account = await _context.Accounts
                .FirstOrDefaultAsync(c => c.AccountId == id);

            // no account item found
            if (Account == null)
            {
                return null;
            }
            // create an instance of AccountDto
            AccountDto AccountDto = new AccountDto()
            {
                AccountId = Account.AccountId,
                AccountName = Account.AccountName,
                AccountEmail = Account.AccountEmail,
                AccountRole = Account.AccountRole,
                AccountPassword = Account.AccountPassword,
                AccountCity = Account.AccountCity,
                AccountState = Account.AccountState
            };
            return AccountDto;

        }


        public async Task<ServiceResponse> UpdateAccount(AccountDto AccountDto)
        {
            ServiceResponse serviceResponse = new();


            // Create instance of Account
            Account Account = new Account()
            {
                AccountId = (int)AccountDto.AccountId,
                AccountName = AccountDto.AccountName,
                AccountEmail = AccountDto.AccountEmail,
                AccountRole = AccountDto.AccountRole,
                AccountPassword = AccountDto.AccountPassword,
                AccountCity = AccountDto.AccountCity,
                AccountState = AccountDto.AccountState
            };
            // flags that the object has changed
            _context.Entry(Account).State = EntityState.Modified;

            try
            {
                // SQL Equivalent: Update Accounts set ... where AccountId={id}
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                serviceResponse.Status = ServiceResponse.ServiceStatus.Error;
                serviceResponse.Messages.Add("An error occurred updating the record");
                return serviceResponse;
            }

            serviceResponse.Status = ServiceResponse.ServiceStatus.Updated;
            return serviceResponse;
        }


        public async Task<ServiceResponse> AddAccount(AccountDto AccountDto)
        {
            ServiceResponse serviceResponse = new();


            // Create instance of Account
            Account Account = new Account()
            {
                AccountName = AccountDto.AccountName,
                AccountEmail = AccountDto.AccountEmail,
                AccountRole = AccountDto.AccountRole,
                AccountPassword = AccountDto.AccountPassword,
                AccountCity = AccountDto.AccountCity,
                AccountState = AccountDto.AccountState
            };
            // SQL Equivalent: Insert into Accounts (..) values (..)

            try
            {
                _context.Accounts.Add(Account);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Status = ServiceResponse.ServiceStatus.Error;
                serviceResponse.Messages.Add("There was an error adding the Account.");
                serviceResponse.Messages.Add(ex.Message);
            }


            serviceResponse.Status = ServiceResponse.ServiceStatus.Created;
            serviceResponse.CreatedId = Account.AccountId;
            return serviceResponse;
        }


        public async Task<ServiceResponse> DeleteAccount(int id)
        {
            ServiceResponse response = new();
            // account Item must exist in the first place
            var Account = await _context.Accounts.FindAsync(id);
            if (Account == null)
            {
                response.Status = ServiceResponse.ServiceStatus.NotFound;
                response.Messages.Add("Account cannot be deleted because it does not exist.");
                return response;
            }

            try
            {
                _context.Accounts.Remove(Account);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.Status = ServiceResponse.ServiceStatus.Error;
                response.Messages.Add("Error encountered while deleting the Account");
                return response;
            }

            response.Status = ServiceResponse.ServiceStatus.Deleted;

            return response;

        }

        public async Task<IEnumerable<AccountDto>> ListAccountsForPet(int id)
        {
            // join AccountPet on Accounts.Accountid = AccountPet.Accountid WHERE AccountPet.Petid = {id}
            List<Account> Accounts = await _context.Accounts
                .Where(c => c.Pets.Any(p => p.PetId==id))
                .ToListAsync();

            // empty list of data transfer object AccountDto
            List<AccountDto> AccountDtos = new List<AccountDto>();
            // foreach account record in database
            foreach (Account Account in Accounts)
            {
                // create new instance of AccountDto, add to list
                AccountDtos.Add(new AccountDto()
                {
                    AccountId = Account.AccountId,
                    AccountName = Account.AccountName,
                    AccountEmail = Account.AccountEmail,
                    AccountRole = Account.AccountRole,
                    AccountPassword = Account.AccountPassword,
                    AccountCity = Account.AccountCity,
                    AccountState = Account.AccountState
                });
            }
            // return AccountDtos
            return AccountDtos;

        }

        public async Task<ServiceResponse> LinkAccountToPet(int AccountId, int PetId)
        {
            ServiceResponse serviceResponse = new();

            Account? Account = await _context.Accounts
                .Include(c => c.Pets)
                .Where(c => c.AccountId== AccountId)
                .FirstOrDefaultAsync();
            Pet? Pet = await _context.Pets.FindAsync(PetId);

            // Data must link to a valid entity
            if (Pet == null || Account == null) { 
                serviceResponse.Status = ServiceResponse.ServiceStatus.NotFound;
                if (Pet == null)
                {
                    serviceResponse.Messages.Add("Pet was not found. ");
                }
                if (Account == null)
                {
                    serviceResponse.Messages.Add("Account was not found.");
                }
                return serviceResponse;
            }
            try
            {
                Account.Pets.Add(Pet);
                _context.SaveChanges();
            }
            catch(Exception Ex)
            {
                serviceResponse.Messages.Add("There was an issue linking the Pet to the Account");
                serviceResponse.Messages.Add(Ex.Message);
            }


            serviceResponse.Status = ServiceResponse.ServiceStatus.Created;
            return serviceResponse;
        }

        public async Task<ServiceResponse> UnlinkAccountFromPet(int AccountId, int PetId)
        {
            ServiceResponse serviceResponse = new();

            Account? Account = await _context.Accounts
                .Include(c => c.Pets)
                .Where(c => c.AccountId == AccountId)
                .FirstOrDefaultAsync();
            Pet? Pet = await _context.Pets.FindAsync(PetId);

            // Data must link to a valid entity
            if (Pet == null || Account == null)
            {
                serviceResponse.Status = ServiceResponse.ServiceStatus.NotFound;
                if (Pet == null)
                {
                    serviceResponse.Messages.Add("Pet was not found. ");
                }
                if (Account == null)
                {
                    serviceResponse.Messages.Add("Account was not found.");
                }
                return serviceResponse;
            }
            try
            {
                Account.Pets.Remove(Pet);
                _context.SaveChanges();
            }
            catch (Exception Ex)
            {
                serviceResponse.Messages.Add("There was an issue unlinking the Pet to the Account");
                serviceResponse.Messages.Add(Ex.Message);
            }


            serviceResponse.Status = ServiceResponse.ServiceStatus.Deleted;
            return serviceResponse;
        }
    }
}
