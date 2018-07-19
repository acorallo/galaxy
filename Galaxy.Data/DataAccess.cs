﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Galaxy.Data
{
    public abstract class DataAccess : IDisposable
    {
        
        private const string DB_FILENAME = "galaxia.mdf";
        private static readonly string AttachedDbFileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DB_FILENAME);
        private static readonly string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Personal\Galaxy\Galaxy.Data\galaxia.mdf;Integrated Security=True";
        


        private static IDbConnection _dbConnection = null;


        protected IDbConnection DBConnection
        {
            get
            {   if (_dbConnection == null)
                    _dbConnection = new SqlConnection(ConnectionString);
                return _dbConnection;
            }
        }
            
        public void OpenConnection()
        {
            if (this.DBConnection.State != ConnectionState.Open)
                this.DBConnection.Open();
        }

        public void ClosConnection ()
        {
            if(this.DBConnection.State != ConnectionState.Closed)
                this.DBConnection.Close();
        }
            
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IDbCommand getCommand()
        {
            return this.DBConnection.CreateCommand();
        }
            

    }
}