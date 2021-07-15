using System.Linq;
using API.Models;
using API.Models.Create;
using API.Models.Update;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var items = _itemRepository.GetAll();
            return Ok(items.Select(item => new SimpleItemDto(item)));
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var item = _itemRepository.GetById(id);
            return Ok(new SimpleItemDto(item));
        }

        [HttpPost]
        public ActionResult Create(CreateItem data)
        {
            var item = _itemRepository.Create(data.ListId, data.Name);
            if(item != null)
            {
                return Ok(new SimpleItemDto(item));
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateItem data)
        {
            var item = _itemRepository.Update(id, data.Name, data.IsChecked);
            if(item != null)
            {
                return Ok(new SimpleItemDto(item));
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var item = _itemRepository.GetById(id);

            _itemRepository.Destroy(item);

            return Ok();
        }
    }
}