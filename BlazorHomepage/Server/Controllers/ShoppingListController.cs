using AutoMapper;
using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.HandlelisteData;
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
    public class ShoppingListController : ControllerBase
    {
        public ShoppingListController(IGenericRepository<ShoppingList> dataManager, 
            IMapper mapper)
        {
            storageHandler = dataManager;
            this.mapper = mapper;
        }
        private IGenericRepository<ShoppingList> storageHandler;
        private readonly IMapper mapper;

        // GET: api/<ShoppingListController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await storageHandler.Get();

                if (res == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Could not Get any stored Lists");

                if (!res.Any())
                    return Ok(new List<ShoppingListModel>()); 

                var shoppingListModel = mapper.Map<ShoppingListModel[]>(res);
               
                return Ok(shoppingListModel.ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, somethingFailed serverside..");
            }

        }

        // GET api/<ShoppingListController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var res = await storageHandler.Get(id);
            return Ok(mapper.Map<ShoppingListModel>(res));
        }

        // POST api/<ShoppingListController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShoppingListModel shoppinglistmodel)
        {
            var shoppinglist = mapper.Map<ShoppingList>(shoppinglistmodel);
            var addRes = await storageHandler.Insert(shoppinglist);
            if (addRes == null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(mapper.Map<ShoppingListModel>(addRes));
        }

        // PUT api/<ShoppingListController>/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ShoppingListModel value)
        {
            var shoppinglist = mapper.Map<ShoppingList>(value);
            var res = await storageHandler.Update(shoppinglist);
            if (res == null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(mapper.Map<ShoppingListModel>(res));

        }

        // DELETE api/<ShoppingListController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var res = await storageHandler.Delete(id);
            if(res)
                return NoContent();
            return StatusCode(StatusCodes.Status500InternalServerError, "Feil under sletting av id"); 
        }
    }
}
