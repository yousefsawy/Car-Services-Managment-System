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

        public bool CheckSlotID(int id)
        {
            string query = "select * from slots where id = " + id + " and status = 1 and active = 1";
            DataTable check = dbMan.ExecuteReader(query);
            if (check == null) { return false; }
            else { return true; }
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

        public int InsertAdmin(string un, string pass, string fname, string lname, string phone)
        {
            string query = "insert into admin values('" + un + "', '" + pass + "', '" + fname + "', '" + lname + "', '" + phone + "')";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertManager(string un, string pass, string fname, string lname, string phone, int br_id)
        {
            string query = "insert into manager values('" + un + "', '" + pass + "', '" + fname + "', '" + lname + "', '" + phone + "', " + br_id + ", 1)";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertReview(int book_id, int rating, string text)
        {
            string query = "insert into reviews values('" + text + "', " + rating + ", " + book_id + ")";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertRequest(int qty, int total, int status, int cid, int sl_id, int sid, int bid)
        {
            string query = "insert into requests values(" + qty + "," + total + "," + status + "," + cid + "," + sl_id + "," + sid + "," + bid + ");" +
                "update slots set status = 0 where id = " + sl_id + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertEmployee(string fname, string lname, string phone, int dep_id)
        {
            string query = "insert into employee values('" + fname + "', '" + lname + "', '" + phone + "', 0, 1, " + dep_id + ", 1)";
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

        public int GetSlotID(string day, int time, int br_id, int s_id)
        {
            string query = "select id from slots where day = '" + day + "' and time = " + time + " and dep_id in" +
                "(select id from departments where branch_id = " + br_id + " and id in" +
                "(select dep_id from specialities where service_id = " + s_id + "))";
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

        public DataTable GetAllManagers()
        {
            string query = "select * from manager where active = 1 and branch_id in (select id from branches where active = 1)";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetAllUnmanagedBranches()
        {
            string query = "select * from branches where active = 1 and id not in (select branch_id from manager where active = 1)";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetAllBranchesCities()
        {
            string query = "select distinct city from branches where active = 1";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetAllBranchesFilterCity(string city)
        {
            string query = "select * from branches where city = '" + city + "'";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetAllBranchesFilterSName(string name)
        {
            string query = "select * from branches where id in" +
                "(select branch_id from departments where id in" +
                "(select distinct dep_id from specialities where service_id in" +
                "(select id from services where name = '" + name + "'and active = 1)))";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetAllServicesTypes()
        {
            string query = "select distinct type from services where active = 1";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetAllServicesFilterType(string type)
        {
            string query = "select * from services where type = '" + type + "' and active = 1";
            return dbMan.ExecuteReader(query);
        }

        public int GetServicePrice(string name)
        {
            string query = "select price from services where name = '" + name + "'";
            return (int)dbMan.ExecuteScalar(query);
        }

        public DataTable GetClientHistory(int id)
        {
            string query = "select * from requests where client_id = " + id + " and id in (select request_id from bookings)";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetClientReviews(int id)
        {
            string query = "select * from reviews where booking_id in" +
                "(select id from bookings where request_id in" +
                "(select id from requests where client_id = " + id + "))";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetEmpSCount(int hid)
        {
            string query = "select fname, lname, services_count from employee where dep_id in" +
                "(select dep_id from hod where id = " + hid + ")";
            return dbMan.ExecuteReader(query);
        }

        public int GetDepSCount(int hid)
        {
            string query = "select sum(services_count) from employee where dep_id in" +
                "(select dep_id from hod where id = " + hid + ")";
            return (int)dbMan.ExecuteScalar(query);
        }

        public DataTable GetDepRequests(int hid)
        {
            string query = "select * from requests where status = 0 and branch_id in (select branch_id from departments where id in" +
                "(select dep_id from hod where id = "+hid+")) and service_id in" +
                "(select service_id from specialities where dep_id in" +
                "(select dep_id from hod where id = " + hid + "))";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetFreeEmp(int hid)
        {
            string query = "select * from employee where active = 1 and dep_id in" +
                "(select dep_id from hod where id = "+hid+")";
            return dbMan.ExecuteReader(query);
        }

        public int GetBranchSCount(int id)
        {
            string query = "select services_count from branches where id in" +
                "(select branch_id from manager where id = " + id + ")";
            return (int)dbMan.ExecuteScalar(query);
        }

        public int GetBranchRevenue(int id)
        {
            string query = "select revenue from branches where id in" +
                "(select branch_id from manager where id = " + id + ")";
            return (int)dbMan.ExecuteScalar(query);
        }

        public DataTable GetBranchStorage(int id)
        {
            string query = "select * from branch_storage where branch_id in" +
                "(select branch_id from manager where id = " + id + ")";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetParts()
        {
            string query = "select * from services where type = 'battery' or type = 'tyre' and active = 1";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetDepsBranch(int id)
        {
            string query = "select * from departments where active = 1 and branch_id in" +
                "(select branch_id from manager where id = " + id + ")";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetEmpsBranch(int id)
        {
            string query = "select * from employee where active = 1 and dep_id in" +
                "(select id from departments where branch_id in" +
                "(select branch_id from manager where id = " + id + "))";
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

        public int DeleteManager(int mn_id)
        {
            string query = "update manager set active = 0 where id = " + mn_id + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteEmployee(int id)
        {
            string query = "update employee set active = 0 where id = " + id + "";
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

        public int UpdateManager(int id, int br_id)
        {
            string query = "update manager set branch_id = " + br_id + " where id = " + id + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateEmployee(int id, int dep_id)
        {
            string query = "update employee set dep_id = " + dep_id + " where id = " + id + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateCountRevenue(int emp_id, int req_id)
        {
            string query = "update employee set services_count = services_count + 1 where id = " + emp_id + ";" +
                "update branches set services_count = services_count + 1," +
                "revenue = revenue + (select(total) from requests where id = " + req_id + ")" +
                "where id in(select branch_id from requests where id = " + req_id + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateStorage(int id, int pid, int qty)
        {
            string query = "update branch_storage set quantity = quantity + " + qty + " where part_id = " + pid + " and branch_id in" +
                "(select branch_id from manager where id = " + id + ")";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateStorageClient(int bid, int pid, int qty)
        {
            string query = "update branch_storage set quantity = quantity - " + qty + " where part_id = " + pid + " and branch_id  = " + bid + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeclineRequest(int id)
        {
            string query = "update requests set status = -1 where id = " + id + "";
            return dbMan.ExecuteNonQuery(query);
        }

        public int AcceptRequest(int id)
        {
            string query = "update requests set status = 1 where id = " + id + "";
            return dbMan.ExecuteNonQuery(query);
        }
    }
}
