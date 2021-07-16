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
            List<SimpleListDto> listDto = new List<SimpleListDto>();
            var lists = _itemListRepository.GetAll();
            lists.ForEach(l => {
                int count = _itemRepository.GetAllByListId(l.Id).Count();
                listDto.Add(new SimpleListDto(l, count));
            });
            return Ok(listDto);
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
                return Ok(new SimpleListDto(list, 0));
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateList data)
        {
            var list = _itemListRepository.Update(id, data.Name, data.Description);
            var itemCount = _itemRepository.GetAllByListId(id).Count();
            if(list != null)
            {
                return Ok(new SimpleListDto(list, itemCount));
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
