using AutoMapper;
using Hotel.BusinessLayer.Abstract;
using Hotel.DtoLayer.Dtos.SenderMessage;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderMessageController : ControllerBase
    {
        private readonly IService<SenderMessage> _service;
        private readonly IMapper _mapper;
        public SenderMessageController(IService<SenderMessage> service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> SenderMessages()
        {
            var model = await _service.GetAllIsActiveTrueAsync();
            
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(AddSenderMessageDto addSenderMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<SenderMessage>(addSenderMessage);
                await _service.AddAsync(model);

                return Ok();
            }

        }        
        [HttpDelete("{id}")]
        public async Task<IActionResult> AllDeleteSenderMessage(Guid id)
        {
            var model = await _service.GetByIdAsync(id);

            await _service.CompletelyDeletedAsync(model.Id);
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSenderMessage(UpdateSenderMessage updateSenderMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var model = _mapper.Map<SenderMessage>(updateSenderMessage);
                await _service.UpdateAsync(model);
                return Ok();
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> SenderMessage(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            return Ok(model);
        }
        [HttpGet("SenderMessageCount")]
        public async Task<IActionResult> SenderMessageCount()
        {
            var model =await _service.GetAllIsActiveTrueAsync();

            return Ok(model.Count());

             
        }

    }
}
