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

        public int InsertDepartment(string name, string descrip, int br_id)
        {
            if (descrip == "null")
            {
                string query = "insert into departments values('" + name + "', null, " + br_id + ", 1)";
                return dbMan.ExecuteNonQuery(query);
            }
            else
            {
                string query = "insert into departments values('" + name + "', '" + descrip + "', " + br_id + ", 1)";
                return dbMan.ExecuteNonQuery(query);
            }
        }

        public int InsertBranch(string city, string area)
        {
            string query = "insert into branches values('" + city + "', '" + area + "', 0, 0, 1)";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertService(string type, string name, int price)
        {
            string query = "insert into services values('" + type + "', '" + name + "', " + price + ", 1)";
            return dbMan.ExecuteNonQuery(query);
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

        public int GetUserID(string user, string un, string pass)
        {
            string query = "select id from " + user + " where username = '" + un + "' and password = '" + pass + "' and active = 1";
            return (int)dbMan.ExecuteScalar(query);
        }

        public DataTable GetAllDeps()
        {
            string query = "select * from departments where active = 1 and branch_id in (select id from branches where active = 1)";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetAllBranches()
        {
            string query = "select * from branches where active = 1";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetAllServices()
        {
            string query = "select * from services where active = 1";
            return dbMan.ExecuteReader(query);
        }

        public int DeleteDepartment(int dep_id)
        {
            string query = "update departments set active = 0 where id = " + dep_id + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteBranch(int br_id)
        {
            string query = "update branches set active = 0 where id = " + br_id + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteService(int sr_id)
        {
            string query = "update services set active = 0 where id = " + sr_id + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateDepartment(int dep_id, int br_id)
        {
            string query = "update departments set branch_id = " + br_id + " where id = " + dep_id + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateBranch(int br_id, string city, string area)
        {
            string query = "update branches set area = '" + area + "', city = '" + city + "' where id = " + br_id + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateService(int id, int price)
        {
            string query = "update services set price = " + price + "where id = " + id + "";
            return dbMan.ExecuteNonQuery(query);
        }
    }
}
