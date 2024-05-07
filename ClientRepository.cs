using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2bank
{
    public class ClientRepository
    {
        private string connectionString;

        public ClientRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddClient(Client client) 
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("INSERT INTO Clients (FirstName, LastName) VALUES (@FirstName, @LastName); SELECT SCOPE_IDENTITY();", connection);
                cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                cmd.Parameters.AddWithValue("@LastName", client.LastName);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    client.ClientId = Convert.ToInt32(result);
                }
            }
        }

        public Client GetClient(int clientId) 
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("SELECT ClientId, FirstName, LastName FROM Clients WHERE ClientId = @ClientId", connection);
                cmd.Parameters.AddWithValue("@ClientId", clientId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Client(reader.GetString(1), reader.GetString(2));
                    }
                }
            }
            return null;
        }



        public void UpdateClient(Client client)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("UPDATE Clients SET FirstName = @FirstName, LastName = @LastName WHERE ClientId = @ClientId", connection);
                cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                cmd.Parameters.AddWithValue("@LastName", client.LastName);
                cmd.Parameters.AddWithValue("@ClientId", client.ClientId);
                cmd.ExecuteNonQuery();
            }   
        }

        public void DeleteClient(int clientId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("DELETE FROM Clients WHERE ClientId = @ClientId", connection);
                cmd.Parameters.AddWithValue("@ClientId", clientId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
