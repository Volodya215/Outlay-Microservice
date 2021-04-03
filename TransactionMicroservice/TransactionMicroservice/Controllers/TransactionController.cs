using CardMicroservice.Models;
using CardMicroservice.UoW;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //[HttpGet("{id}", Name = "Get")]
        //public IActionResult Get(int id)
        //{
        //    try
        //    {
        //        var transaction = _unitOfWork.Transactions.Get(id);
        //        if (transaction == null)
        //            return new NotFoundResult();

        //        return new OkObjectResult(transaction);
        //    }
        //    catch
        //    {
        //        return new BadRequestResult();
        //    }
        //}

        [Route("/cardTransaction")]
        [HttpGet]
        public ActionResult<CardTransaction> Get([FromBody]int cardid)
        {
            try
            {
                var transactions = _unitOfWork.Transactions.Find(x => x.Card.Id == cardid);
                if (transactions == null)
                    return new NotFoundResult();

                return new OkObjectResult(transactions);
            }
            catch
            {
                return new BadRequestResult();
            }
        }
    }
}
