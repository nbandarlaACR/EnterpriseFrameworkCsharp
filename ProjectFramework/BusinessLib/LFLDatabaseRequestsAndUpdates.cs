using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace LFL.Portal.Tests.BusinessLib
{
    public class LFLDatabaseRequestsAndUpdates
    {
        public IWebDriver driver;
        string port = "49535";
        public LFLDatabaseRequestsAndUpdates(IWebDriver cdriver)
        {
            this.driver = cdriver;
        }

        public bool deleteInactiveMember(string serverName, string databaseName, string userName, string password, string emailConfirm_tableName, string userId_TableName, string tokensTableName, string email)
        {
            string connectionString, sql1, sql2, sql3, sql4;
            Int64 userId = 0;
            bool flag = false;
            int numOfRowsDeleted, numberOfUserIdRowsDeleted, numberOfTokenRowsDeleted;
            SqlConnection cnn;
            SqlCommand command1;
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();
            sql1 = "select Id from " + emailConfirm_tableName + " where Username='" + email + "';";
            //connectionString = @"Server=" + serverName + "; Database=" + databaseName + "; User Id=" + userName + "; Password=" + password + ";";
            connectionString = @"Server=" + serverName + ","+ port +"; Database=" + databaseName + "; Integrated Security=SSPI";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            command1 = new SqlCommand(sql1, cnn);
            dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                userId = (Int64)dataReader.GetValue(0);
            }
            command1.Dispose();
            dataReader.Close();

            sql2 = "Delete from " + tokensTableName + " where UserId='" + userId.ToString() + "';";
            sql3 = "Delete from " + userId_TableName + " where UserId='" + userId.ToString() + "';";
            sql4 = "Delete from " + emailConfirm_tableName + " where Email='" + email + "';";

            adapter.DeleteCommand = new SqlCommand(sql2, cnn);
            numberOfTokenRowsDeleted = adapter.DeleteCommand.ExecuteNonQuery();
            adapter.DeleteCommand.Dispose();
            
            adapter.DeleteCommand = new SqlCommand(sql3, cnn);
            numberOfUserIdRowsDeleted = adapter.DeleteCommand.ExecuteNonQuery();
            adapter.DeleteCommand.Dispose();

            adapter.DeleteCommand = new SqlCommand(sql4, cnn);
            numOfRowsDeleted = adapter.DeleteCommand.ExecuteNonQuery();
            adapter.DeleteCommand.Dispose();

            cnn.Close();
            if (numOfRowsDeleted == 1)
            {
                flag = true;
            }
            return flag;
        }

        public string updateEmailAsConfirmedAndGetUserId(string serverName, string databaseName, string userName, string password, string emailConfirmationtableName, string userIdtableName, string email)
        {
            string connectionString, sql1, sql2, sql3, sql4, cf_userId="";
            Int64 userId=0;
            SqlConnection cnn;
            SqlCommand command1;
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();
            sql1 = "Update " + emailConfirmationtableName + " Set EmailConfirmed = 1 where Username = '" + email + "';";
            sql2 = "select Id from " + emailConfirmationtableName + " where Username='" + email + "';";
            //connectionString = @"Server="+serverName+"; Database="+databaseName+"; User Id="+userName+"; Password="+password+";";
            connectionString = @"Server=" + serverName + "," + port + "; Database=" + databaseName + "; Integrated Security=SSPI";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            //update command
            adapter.UpdateCommand = new SqlCommand(sql1, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            adapter.UpdateCommand.Dispose();

            //select command
            command1 = new SqlCommand(sql2, cnn);
            dataReader = command1.ExecuteReader();            
            while (dataReader.Read())
            {  
                userId = (Int64)dataReader.GetValue(0);
            }
            command1.Dispose();
            dataReader.Close();
            sql3 = "select Value from " + userIdtableName + " where UserId='" + userId.ToString() + "' and Type = 'caseflow_userid';";
            sql4 = "Update " + userIdtableName + " Set Value = 'true' where UserId='" + userId.ToString() + "' and Type = 'caseflow_user_confirmed';";

            command1 = new SqlCommand(sql3, cnn);
            dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                cf_userId = (string)dataReader.GetValue(0);
            }
            command1.Dispose();
            dataReader.Close();

            adapter.UpdateCommand = new SqlCommand(sql4, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            adapter.UpdateCommand.Dispose();

            cnn.Close();

            return cf_userId;
        }

        public string getLink(string serverName, string databaseName, string usersTable, string password, string passResetLinkTable, string email)
        {
            string connectionString, sql1, sql2, passResetLink = "";
            int i=0;
            Int64 userId = 0;
            SqlConnection cnn;
            SqlCommand command1;
            SqlCommand command2;
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();

            connectionString = @"Server=" + serverName + "," + port + "; Database=" + databaseName + "; Integrated Security=SSPI";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            while (String.IsNullOrEmpty(passResetLink))
            {

                sql1 = "select Id from " + usersTable + " where Email='" + email + "';";
                command1 = new SqlCommand(sql1, cnn);
                dataReader = command1.ExecuteReader();
                while (dataReader.Read())
                {
                    userId = (Int64)dataReader.GetValue(0);
                }

                command1.Dispose();
                dataReader.Close();

                sql2 = "select Link from " + passResetLinkTable + " where UserId='" + userId + "';";
                command2 = new SqlCommand(sql2, cnn);
                dataReader = command2.ExecuteReader();
                while (dataReader.Read())
                {
                    passResetLink = (string)dataReader.GetValue(0);
                }

                command2.Dispose();
                dataReader.Close();

                i++;

                if (i == 60)
                    break;
            }

            return passResetLink;
        }

        public bool lockAccount(string serverName, string databaseName, string usersTable, string password, string email)
        {
            string connectionString, sql1, sql2, sql3;
            bool isLocked = false;
            Int64 userId = 0;
            SqlConnection cnn;
            SqlCommand command1;
            SqlCommand command3;
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();

            connectionString = @"Server=" + serverName + "," + port + "; Database=" + databaseName + "; Integrated Security=SSPI";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            sql1 = "select Id from " + usersTable + " where Email='" + email + "';";
            command1 = new SqlCommand(sql1, cnn);
            dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                userId = (Int64)dataReader.GetValue(0);
            }
            command1.Dispose();
            dataReader.Close();

            sql2 = "update Users set LockedOut = 1, InvalidPasswordCount = 5, LockedTill = '2025-03-21 10:32:03.3188483' where Id='" + userId + "';";
            
            adapter.UpdateCommand = new SqlCommand(sql2, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            adapter.UpdateCommand.Dispose();
            
            sql3 = "select LockedOut from " + usersTable + " where Email='" + email + "';";
            command3 = new SqlCommand(sql3, cnn);
            dataReader = command3.ExecuteReader();
            while (dataReader.Read())
            {
                isLocked = (bool)dataReader.GetValue(0);                
            }
            command3.Dispose();
            dataReader.Close();

            return isLocked;
        }

        public bool deleteUnconfirmedAccounts(string serverName, string dbName, string usersTable, string propertiesTable, string tokensTable, string userRolesTable, string legacyPassTable, string email)
        {
            string connectionString, sql1, sql2, sql3, sql4, sql5, sql6;
            Int64 userId = 0;
            bool flag = false;
            SqlConnection cnn;
            SqlCommand command1;
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();

            sql1 = "select Id from " + usersTable + " where Username='" + email + "' and EmailConfirmed = 0 and CreatedAt <= getdate();";
            connectionString = @"Server=" + serverName + "," + port + "; Database=" + dbName + "; Integrated Security=SSPI";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            command1 = new SqlCommand(sql1, cnn);
            dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                userId = ((Int64)dataReader.GetValue(0));
            }

            command1.Dispose();
            dataReader.Close();

            if (userId != 0)
            {
                sql2 = "Delete from " + propertiesTable + " where UserId='" + userId.ToString() + "';";
                sql3 = "Delete from " + userRolesTable + " where UserId='" + userId.ToString() + "';";
                sql4 = "Delete from " + tokensTable + " where UserId='" + userId.ToString() + "';";
                sql5 = "Delete from " + legacyPassTable + " where UserId='" + userId.ToString() + "';";
                sql6 = "Delete from " + usersTable + " where Id='" + userId.ToString() + "';";

                adapter.DeleteCommand = new SqlCommand(sql2, cnn);
                adapter.DeleteCommand.ExecuteNonQuery();
                adapter.DeleteCommand.Dispose();

                adapter.DeleteCommand = new SqlCommand(sql3, cnn);
                adapter.DeleteCommand.ExecuteNonQuery();
                adapter.DeleteCommand.Dispose();

                adapter.DeleteCommand = new SqlCommand(sql4, cnn);
                adapter.DeleteCommand.ExecuteNonQuery();
                adapter.DeleteCommand.Dispose();

                adapter.DeleteCommand = new SqlCommand(sql5, cnn);
                adapter.DeleteCommand.ExecuteNonQuery();
                adapter.DeleteCommand.Dispose();

                adapter.DeleteCommand = new SqlCommand(sql6, cnn);
                adapter.DeleteCommand.ExecuteNonQuery();
                adapter.DeleteCommand.Dispose();

                flag = true;
            }
            return flag;
        }

        public string updateEmailAddress(string serverName, string databaseName, string usersTable, string password, string passResetLinkTable, string emailNew, string emailOrig)
        {
            string connectionString, sql1, sql2, sql3;
            string resetEmail = "";
            Int64 userId = 0;
            SqlConnection cnn;
            SqlCommand command1;
            SqlCommand command3;
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();

            connectionString = @"Server=" + serverName + "," + port + "; Database=" + databaseName + "; Integrated Security=SSPI";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            sql1 = "select Id from " + usersTable + " where NewEmail='" + emailNew + "'OR Email='"+ emailNew + "';";
            command1 = new SqlCommand(sql1, cnn);
            dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                userId = (Int64)dataReader.GetValue(0);
            }
            command1.Dispose();
            dataReader.Close();

            sql2 = "update Users set NewEmail = '" + emailOrig +"',Username='"+ emailOrig + "', Email='"+ emailOrig + "' where Id='" + userId + "';";

            adapter.UpdateCommand = new SqlCommand(sql2, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            adapter.UpdateCommand.Dispose();

            sql3 = "select Username from " + usersTable + " where Id ='" + userId + "';";
            command3 = new SqlCommand(sql3, cnn);
            dataReader = command3.ExecuteReader();
            while (dataReader.Read())
            {
                resetEmail = dataReader.GetValue(0).ToString();
            }
            command3.Dispose();
            dataReader.Close();

            return resetEmail;
        }
    }
}
