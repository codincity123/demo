using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Learner.App.Service.Dtos;
using Learner.App.Service.Repositories;
using Learner.App.Service.Entities;

namespace Learner.App.Service.Controllers
{
    
[ApiController]
[Route("items")]
    public class ItemsController : ControllerBase
    {
  
        private readonly ItemsRepository itemsRepository = new();
        
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
            var items = (await itemsRepository.GetAllAsync())
                        .Select(items => items.AsDto());
            return items;

        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id){
            var item = await itemsRepository.GetAsync(id);
            if(item == null){
                return NotFound();
            }
            return item.AsDto();

        }
        //POST
        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto)
        {
            var item = new Item
            {
                LearnerName = createItemDto.LearnerName,
                CourseName = createItemDto.CourseName

            };

            await itemsRepository.CreateAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new {id =item.Id},item);


        }
        //PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, updateItemDto updateItemDto){

            var existingItem = await itemsRepository.GetAsync(id);

            if(existingItem == null){
                return NotFound();
            }

           existingItem.LearnerName = updateItemDto.LearnerName;
           existingItem.CourseName = updateItemDto.CourseName;
           await itemsRepository.UpdateAsync(existingItem);
           
        return NoContent();
        }
        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id){
            
            var item = await itemsRepository.GetAsync(id);
             
            if(item == null){
                return NotFound();
            }
            await itemsRepository.RemoveAsync(item.Id);

             return NoContent();

        }

    }
}