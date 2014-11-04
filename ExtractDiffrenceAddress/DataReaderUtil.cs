using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using ExtractDiffrenceAddress.Models;

namespace ExtractDiffrenceAddress
{
    public static class DataReaderUtil
    {
        public static List<AddressRecord> DataReaderToList(OleDbDataReader dataReader)
        {
            var addressRecords = new List<AddressRecord>();

            while (dataReader.Read())
            {
                var address = new AddressRecord();
                address.Location = dataReader["Location"].ToString();
                address.layer_code = dataReader["layer_code"].ToString();
                address.ADCD = dataReader["ADCD"].ToString();
                address.Kanj_Tod = dataReader["Kanj_Tod"].ToString();
                address.Kanj_Shi = dataReader["Kanj_Shi"].ToString();
                address.Kanj_Ooa = dataReader["Kanj_Ooa"].ToString();
                address.Kanj_Aza = dataReader["Kanj_Aza"].ToString();
                address.Address1 = dataReader["Address1"].ToString();
                address.X_tky = dataReader["X_tky"].ToString();
                address.Y_tky = dataReader["Y_tky"].ToString();
                address.MapCode = dataReader["MapCode"].ToString();
                address.X = dataReader["X"].ToString();
                address.Y = dataReader["Y"].ToString();
                address.X_meter = dataReader["X_meter"].ToString();
                address.Y_meter = dataReader["Y_meter"].ToString();

                addressRecords.Add(address);
            }
            return addressRecords;
        }
    }
}
