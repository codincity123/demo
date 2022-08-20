using Learner.App.Service.Dtos;
using Learner.App.Service.Entities;

namespace Learner.App.Service{
    public static class Extensions{
        
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto(item.Id, item.LearnerName, item.CourseName);
        }

    }
}
