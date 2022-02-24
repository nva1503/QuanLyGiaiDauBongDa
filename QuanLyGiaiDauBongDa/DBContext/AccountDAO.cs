using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
namespace QuanLyGiaiDauBongDa.DBContext
{
    internal class Account
    {
        public int accountID { get; set; }
        public string fullName { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string email { get; set; }
        public DateTime dob { get; set; }
    }
    class AccountDAO : DAO
    {
        public List<Account> GetAccounts()
        {
            List<Account> accounts= new  List<Account>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("Select * from Account", connection);
            try
            {
                connection.Open();
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        accounts.Add(new Account
                        {
                            accountID = reader.GetInt32("account_id"),
                            fullName=reader.GetString("full_name"),
                            userName=reader.GetString("username"),
                            passWord=reader.GetString("password"),
                            email=reader.GetString("email"),
                            dob=reader.GetDateTime("dob")
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return accounts;
        }
    }
}
