using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PurchaseMicroService.Models;
using PurchaseMicroService.Repositories;

namespace PurchaseMicroService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly ILogger<PurchaseController> logger;
        private readonly IRepository<Purchase> purchaseRepository;

        public PurchaseController(ILogger<PurchaseController> Logger, IRepository<Purchase> PurchaseRepository)
        {
            logger = Logger;
            purchaseRepository = PurchaseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Purchase purchase)
        {
            try
            {
                if (purchase != null)
                {
                    Facade.FacadeService service = new Facade.FacadeService(purchaseRepository);
                    var response =await service.Add(purchase);
                    if(response != null)
                    {
                        return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
                    }
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
