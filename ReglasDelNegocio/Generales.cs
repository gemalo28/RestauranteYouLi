﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ReglasDelNegocio
{
    public class Generales
    {
        public Boolean ConectarDB(string sConnectionString, ref string sLastError, ref MySqlConnection xConnection)
        {
            bool bAllOk = false;

            try
            {
                xConnection.ConnectionString = sConnectionString;
                xConnection.Open();
                bAllOk = true;
            }
            catch(Exception ex)
            {
                sLastError = "error >>> " + ex.ToString();
            }

            return bAllOk;
        }

        public Boolean DesconectarDB(ref string sLastError, ref MySqlConnection xConnection)
        {
            bool bAllOk = false;

            try
            {
                xConnection.Close();
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = "error >>> " + ex.ToString();
            }

            return bAllOk;
        }
    }
}