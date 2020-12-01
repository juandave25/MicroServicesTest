using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PriceMicroservice.Interfaces;
using PriceMicroservice.Models;
using PriceMicroservice.Services;

namespace PriceMicroservice.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IService<DollarPrice> dollarService;
        private readonly IService<RealPrice> realService;
        private readonly ILogger<PriceController> logger;

        public PriceController(ILogger<PriceController> Logger, IService<DollarPrice> DollarService, IService<RealPrice> RealService)
        {
            logger = Logger;
            dollarService = DollarService;
            realService = RealService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Facade.FacadeService service = new Facade.FacadeService(dollarService, realService);
                var response = await service.GetPrices();
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                throw;
            }

        }

        [HttpGet("currency/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                Facade.FacadeService service = new Facade.FacadeService(dollarService, realService);

                if (string.IsNullOrEmpty(id))
                {
                    var response = await service.GetPriceByCurrency(id);
                    if (response.Currency != null)
                    {
                        return Ok(response);
                    }
                    else
                    {
                        return NotFound(response);
                    }
                }

                return BadRequest();

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                throw;
            }

        }

    }
}
