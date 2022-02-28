using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLyGiaiDauBongDa.DBContext
{
    internal class Account
    {
       
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
            command = new SqlCommand("select * from Account", connection);
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
                            userName = reader.GetString("username"),
                            fullName =reader.GetString("full_name"),                         
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
        public int CreateAccount(Account account)
        {
            int numRow = 0;
            connection = new SqlConnection(GetConnectionString());
            string sql = "Insert into Account values(@username,@full_name,@password,@email,@dob)";
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", account.userName);
            command.Parameters.AddWithValue("@full_name", account.fullName);       
            command.Parameters.AddWithValue("@password", account.passWord);
            command.Parameters.AddWithValue("@email", account.email);
            command.Parameters.AddWithValue("@dob", account.dob);
            try
            {
                connection.Open();
                numRow = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return numRow;
        }
        internal bool CheckExistAccount(string userName)
        {
            bool isExist = false;
            List<Account> accounts = new AccountDAO().GetAccounts();
            foreach (var a in accounts)
            {
                if (a.userName.Trim().Equals(userName))
                {
                    isExist = true;
                }
            }
            return isExist;
        }
    }
}
