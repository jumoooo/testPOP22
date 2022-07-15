using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using OrderDTO;

namespace WebAPI.Models
{
    public class OrderDAC
    {
        string strConn;
        public OrderDAC()
        {
            strConn = WebConfigurationManager.ConnectionStrings["prjDB"].ConnectionString;
        }
        public List<OrderVO> GetAllOrders()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandText = "select UserNo, UserName, UserID, UserPwd from [User]";
                cmd.Connection.Open();

                List<OrderVO> list=  Helper.DataReaderMapToList<OrderVO> (cmd.ExecuteReader());
                cmd.Connection.Close();

                return list;
            }
        }

        public bool SaveOrder(OrderVO order)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandText = "SP_SaveUser";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@P_UserNo", order.UserNo);
                cmd.Parameters.AddWithValue("@P_UserName", order.UserName);
                cmd.Parameters.AddWithValue("@P_UserID", order.UserID);
                cmd.Parameters.AddWithValue("@P_UserPwd", order.UserPwd);

                cmd.Connection.Open();
                int iRowAffect= cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return iRowAffect>0;
            }
        }
    }
}