using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.Create;
using API.Models.Update;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListController : ControllerBase
    {
        private readonly IItemListRepository _itemListRepository;
        private readonly IItemRepository _itemRepository;

        public ListController(IItemListRepository itemListRepository,
            IItemRepository itemRepository)
        {
            _itemListRepository = itemListRepository;
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var lists = _itemListRepository.GetAll();
            return Ok(lists.Select(list => new SimpleListDto(list)));
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var list = _itemListRepository.GetById(id);
            var items = _itemRepository.GetAllByListId(id).ToList();
            return Ok(new ListDto(list, items));
        }

        [HttpPost]
        public ActionResult Create(CreateList data)
        {
            var list = _itemListRepository.Create(data.Name, data.Description);
            if(list != null)
            {
                return Ok(new SimpleListDto(list));
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateList data)
        {
            var list = _itemListRepository.Update(id, data.Name, data.Description);
            if(list != null)
            {
                return Ok(new SimpleListDto(list));
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var list = _itemListRepository.GetById(id);
            var items = _itemRepository.GetAllByListId(id).ToList();
            items.ForEach(item => {
                _itemRepository.Destroy(item);
            });

            _itemListRepository.Destroy(list);

            return Ok();
        }
    }
}
