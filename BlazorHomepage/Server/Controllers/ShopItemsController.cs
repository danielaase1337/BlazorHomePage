using AutoMapper;
using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.Model.HandlelisteModels;
using BlazorHomepage.Shared.Repository;
using Google.Cloud.Firestore;
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
    public class ShopItemsController : ControllerBase
    {
        private readonly IGenericRepository<ShopItem> datamanager;
        private readonly IMapper mapper;

        public ShopItemsController(IGenericRepository<ShopItem> datamanager, IMapper mapper)
        {
            this.datamanager = datamanager;
            this.mapper = mapper;
        }
        // GET: api/<ShopItemsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await datamanager.Get();
            var resmodels = mapper.Map<ShopItemModel[]>(items);
            return Ok(resmodels.ToList()); 
        }

        // GET api/<ShopItemsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var shopItem = await datamanager.Get(id);
            var resmodel = mapper.Map<ShopItemModel>(shopItem);
            return Ok(resmodel);

        }

        // POST api/<ShopItemsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShopItemModel value)
        {
            var shopItem = mapper.Map<ShopItem>(value);
            var res = await datamanager.Insert(shopItem);
            if (res == null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(mapper.Map<ShopItemModel>(res));
        }

        // PUT api/<ShopItemsController>/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ShopItemModel value)
        {
            var shopItem = mapper.Map<ShopItem>(value);
            var res = await datamanager.Update(shopItem);
            if (res == null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(mapper.Map<ShopItemModel>(res));
        }

        // DELETE api/<ShopItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var res = await datamanager.Delete(id);
            return Ok(res);
        }
    }
}
