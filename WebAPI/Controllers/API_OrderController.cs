using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrderDTO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class API_OrderController : ApiController
    {
        //https://localhost:44383/api/User/Orders
        [Route("Orders")]
        public IHttpActionResult GetAllUser()
        {
            try
            {
                OrderDAC db = new OrderDAC();
                List<OrderVO> list = db.GetAllOrders();
                MessageVO<List<OrderVO>> result = new MessageVO<List<OrderVO>>()
                {
                    ErrCode = (list == null) ? -9 : 0,
                    ErrMsg = (list == null) ? "조회중 오류발생" : "s",
                    Data = list
                };

                return Ok(result);
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.Message);

                return Ok(new MessageVO
                {
                    ErrCode = -9,
                    ErrMsg = "조회중 오류 발생, 문의해주세유"
                });
            }
        }
    }
}
