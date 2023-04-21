using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ToolSYS
{
    class Rental
    {
        private int rentalID;
        private int customerID;
        private decimal totalFee;

        public Rental(int rentalID, int customerID, decimal totalFee)
        {
            this.rentalID = rentalID;
            this.customerID = customerID;
            this.totalFee = totalFee;
        }

        public Rental()
        {
            rentalID = 0;
            customerID = 0;
            totalFee = 0;
        }

        public int GetRentalID()
        {
            return this.rentalID;
        }

        public int GetCustomerID()
        {
            return this.customerID;
        }

        public decimal GetTotalFee()
        {
            return this.totalFee;
        }

        public void SetRentalID(int rentalID)
        {
            this.rentalID = rentalID;
        }

        public void SetCustomerID(int customerID)
        {
            this.customerID = customerID;
        }

        public void SetTotalFee(decimal totalFee)
        {
            this.totalFee = totalFee;
        }

        public void AddRental()
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            String sqlQuery = "INSERT INTO Rentals Values (" +
                this.rentalID + ", " +
                this.customerID + ", " +
                this.totalFee + ")";

            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static int GetNextRentalID()
        {
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            String sqlQuery = "SELECT MAX(RentalID) FROM Rentals";
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            OracleDataReader dr = cmd.ExecuteReader();

            int NextRentalID;

            dr.Read();

            if (dr.IsDBNull(0))
            {
                NextRentalID = 1;
            }
            else
            {
                NextRentalID = dr.GetInt32(0) + 1;
            }
            conn.Close();

            return NextRentalID;

        }


    }
}
