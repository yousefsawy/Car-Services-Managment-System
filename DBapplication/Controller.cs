using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }

        //insert functions here

        public int CheckAdminLogin(string un, string pass)
        {
            string query = "select * from admin where username = '" + un + "' and password = '" + pass + "'";
            DataTable check = dbMan.ExecuteReader(query);
            if (check == null) { return 0; }
            else { return 1; }
        }

        public int CheckManagerLogin(string un, string pass)
        {
            string query = "select * from manager where username = '" + un + "' and password = '" + pass + "' and active = 1";
            DataTable check = dbMan.ExecuteReader(query);
            if (check == null) { return 0; }
            else { return 1; }
        }

        public int CheckHODLogin(string un, string pass)
        {
            string query = "select * from hod where username = '" + un + "' and password = '" + pass + "' and active = 1";
            DataTable check = dbMan.ExecuteReader(query);
            if (check == null) { return 0; }
            else { return 1; }
        }

        public int CheckClientLogin(string un, string pass)
        {
            string query = "select * from client where username = '" + un + "' and password = '" + pass + "' and active = 1";
            DataTable check = dbMan.ExecuteReader(query);
            if (check == null) { return 0; }
            else { return 1; }
        }

        public int InsertClient(string un, string pass, string fname, string lname, string phone)
        {
            if (phone == "null")
            {
                string query = "insert into client values('" + un + "', '" + pass + "', '" + fname + "', '" + lname + "', null, 1)";
                return dbMan.ExecuteNonQuery(query);
            }
            else
            {
                string query = "insert into client values('" + un + "', '" + pass + "', '" + fname + "', '" + lname + "', '" + phone + "', 1)";
                return dbMan.ExecuteNonQuery(query);
            }
        }

        public int ChangePassword(string user, int id, string pass)
        {
            string query = "update " + user + " set password = '" + pass + "' where id = " + id + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

        public int GetAdminID(string un, string pass)
        {
            string query = "select id from admin where username = '" + un + "' and password = '" + pass + "'";
            return (int)dbMan.ExecuteScalar(query);
        }
    }
}
