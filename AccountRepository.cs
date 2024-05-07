using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2bank
{
    public class AccountRepository
    {
        private string connectionString;

        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddAccount(Account account, int clientId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("INSERT INTO Accounts (AccountId, ClientId, Balance, InterestRate) VALUES (@AccountId, @ClientId, @Balance, @InterestRate)", connection);
                cmd.Parameters.AddWithValue("@AccountId", account.Id);
                cmd.Parameters.AddWithValue("@ClientId", clientId);
                cmd.Parameters.AddWithValue("@Balance", account.Balance.UAH);
                cmd.Parameters.AddWithValue("@InterestRate", account.InterestRate);
                cmd.ExecuteNonQuery();
            }
        }

        public Account GetAccount(Guid accountId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("SELECT AccountId, Balance, InterestRate FROM Accounts WHERE AccountId = @AccountId", connection);
                cmd.Parameters.AddWithValue("@AccountId", accountId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var account = new Account(
                            reader.GetGuid(0),
                            reader.GetDecimal(1),
                            reader.GetDecimal(2));
                        return account;
                    }
                }
            }
            return null;
        }

        public void UpdateAccount(Account account)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("UPDATE Accounts SET Balance = @Balance, InterestRate = @InterestRate WHERE AccountId = @AccountId", connection);
                cmd.Parameters.AddWithValue("@Balance", account.Balance.UAH);
                cmd.Parameters.AddWithValue("@InterestRate", account.InterestRate);
                cmd.Parameters.AddWithValue("@AccountId", account.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAccount(Guid accountId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("DELETE FROM Accounts WHERE AccountId = @AccountId", connection);
                cmd.Parameters.AddWithValue("@AccountId", accountId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
