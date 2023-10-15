using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.BusinessLayer.Concreate;
using Hotel.DtoLayer.Dtos.BookingDto;
using Hotel.DtoLayer.Dtos.CategoryMessageDto;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryMessageController : ControllerBase
    {
        private readonly IService<CategoryMessage> _service;
        private readonly ICategoryMessageService _categoryMessageService;
        private readonly IMapper _mapper;

        public CategoryMessageController(IService<CategoryMessage> service, ICategoryMessageService categoryMessageService, IMapper mapper)
        {
            _service = service;
            _categoryMessageService = categoryMessageService;
            _mapper = mapper;
        }
        [HttpGet]
        
        public async Task<IActionResult> MessageCategories()
        {
            var model = await _categoryMessageService.GetAllCategoryMessage();      
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategoryMessage(AddCategoryMessageDto addCategory )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<CategoryMessage>(addCategory);
                await _service.AddAsync(model);

                return Ok();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> AllDeleteCategoryMessage(Guid id)
        {
            var model = await _service.GetByIdAsync(id);

            await _service.CompletelyDeletedAsync(model.Id);
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryMessage(UpdateCategoryMessage updateCategoryMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<CategoryMessage>(updateCategoryMessage);
                await _service.UpdateAsync(model);
                return Ok();
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CategoryMessage(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            return Ok(model);
        }
        //[HttpGet("id")]
        //public IActionResult UpdateCategoryMessageStatus(Guid id)
        //{
        //    _bookingService.BookingStatusChangeApproved(id);


        //    return Ok();
        //}

    }
}
