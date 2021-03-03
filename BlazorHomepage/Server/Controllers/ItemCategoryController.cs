using AutoMapper;
using BlazorHomepage.Shared.Data.Entities;
using BlazorHomepage.Shared.Model.HandlelisteModels;
using BlazorHomepage.Shared.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorHomepage.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IGenericRepository<ItemCategory> datamanager;
        private readonly IMapper mapper;

        public ItemCategoryController(IGenericRepository<ItemCategory> datamanager, IMapper mapper)
        {
            this.datamanager = datamanager;
            this.mapper = mapper;
        }
        // GET: api/<ItemCategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await datamanager.Get();
            if (res == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not get any stored categories");
            if (!res.Any())
                return Ok(new List<ItemCategoryModel>());
            var itemcatModels = mapper.Map<ItemCategoryModel[]>(res);
            return Ok(itemcatModels.ToList());
        }

        // GET api/<ItemCategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var res = await datamanager.Get(id);
            if (res == null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(mapper.Map<ItemCategoryModel>(res));
        }

        // POST api/<ItemCategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItemCategoryModel value)
        {
            var itemcategory = mapper.Map<ItemCategory>(value);

            var res = await datamanager.Insert(itemcategory);
            if (res == null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(mapper.Map<ItemCategoryModel>(res));
        }

        // PUT api/<ItemCategoryController>/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ItemCategoryModel value)
        {
            var itemcategory = mapper.Map<ItemCategory>(value);
            var res = await datamanager.Update(itemcategory);
            if (res == null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(mapper.Map<ItemCategoryModel>(res));

        }

        // DELETE api/<ItemCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var res = await datamanager.Delete(id);
            return Ok(res);
        }
    }
}
