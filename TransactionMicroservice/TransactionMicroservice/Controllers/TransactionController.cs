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

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var transaction = _unitOfWork.Transactions.Get(id);
                if (transaction == null)
                    return new NotFoundResult();

                return new OkObjectResult(transaction);
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        [Route("/userscard")]
        [HttpGet]
        public IActionResult Get([FromBody] string login)
        {
            try
            {
                var cards = _unitOfWork.Transactions.Find(x => x.User.Login == login);
                if (cards == null)
                    return new NotFoundResult();

                return new OkObjectResult(cards);
            }
            catch
            {
                return new BadRequestResult();
            }
        }
    }
}
