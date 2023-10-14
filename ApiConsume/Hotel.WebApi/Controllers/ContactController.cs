using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.DtoLayer.Dtos.ContactDto;
using Hotel.DtoLayer.Dtos.RoomDto;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IService<Contact> _service;
        private readonly IMapper _mapper;

        public ContactController(IService<Contact> service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllIsActiveTrueAsync();
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactDto addContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<Contact>(addContact);
                await _service.AddAsync(model);

                return Ok();
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> AllDeleteContact(Guid id)
        {
            var model = await _service.GetByIdAsync(id);

            await _service.CompletelyDeletedAsync(model.Id);
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<Contact>(updateContact);
                await _service.UpdateAsync(model);
                return Ok();
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Contact(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            return Ok(model);
        }
        //[HttpGet("GetContactCount")]
        //public async Task<IActionResult> GetContactCount()
        //{
        //    var model = await _service.GetAllIsActiveTrueAsync();
           
        //    return Ok(model.Count());
        //}
    }
}
