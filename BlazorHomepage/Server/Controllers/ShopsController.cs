using AutoMapper;
using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.Model.HandlelisteModels;
using BlazorHomepage.Shared.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorHomepage.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IGenericRepository<Shop> datamanger;
        private readonly IMapper mapper;

        public ShopsController(IGenericRepository<Shop> datamanger, IMapper mapper)
        {
            this.datamanger = datamanger;
            this.mapper = mapper;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await datamanger.Get(); 
                if(res == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Could not Get any stored shops");
                if (!res.Any())
                    return Ok(new List<ShopModel>());
                var shops = mapper.Map<ShopModel[]>(res);
                return Ok(shops.ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, somethingFailed serverside..");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var res = await datamanger.Get(id);
                if (res == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Could not Get any stored shops");
                var shops = mapper.Map<ShopModel>(res);
                return Ok(shops);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, somethingFailed serverside..");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShopModel value)
        {
            try
            {
                var shop = mapper.Map<Shop>(value); 
                var res = await datamanger.Insert(shop); 
                if(res == null)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                return Ok(mapper.Map<ShopModel>(res)); 
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, somethingFailed serverside..");
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ShopModel value)
        {
            try
            {
                var shop = mapper.Map<Shop>(value);
                var res = await datamanger.Update(shop);
                if (res == null)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                return Ok(mapper.Map<ShopModel>(res));

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, somethingFailed serverside..");

            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var res = await datamanger.Delete(id);
                if (res)
                    return NoContent();
                return StatusCode(StatusCodes.Status500InternalServerError, $"Feil under sletting av id {id}"); 
                 
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, somethingFailed serverside..");
            }
        }
    }
}
