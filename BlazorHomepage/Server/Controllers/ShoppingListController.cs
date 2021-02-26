using AutoMapper;
using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.HandlelisteData;
using BlazorHomepage.Shared.Model.HandlelisteModels;
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
    public class ShoppingListController : ControllerBase
    {
        public ShoppingListController(IStorageContext<ShoppingList> storageContext, IMapper mapper)
        {
            storageHandler = storageContext;
            this.mapper = mapper;
        }
        private IStorageContext<ShoppingList> storageHandler;
        private readonly IMapper mapper;

        // GET: api/<ShoppingListController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await storageHandler.GetStoredItems();

                if (res == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Could not Get any stored Lists");

                if (!res.Any())
                    return Ok(new List<ShoppingListModel>()); 

                var shoppingListModel = mapper.Map<List<ShoppingListModel>>(res);
               
                return Ok(shoppingListModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, somethingFailed serverside..");
            }

        }

        // GET api/<ShoppingListController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShoppingListController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShoppingListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShoppingListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
