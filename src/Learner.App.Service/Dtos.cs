using System;
using System.ComponentModel.DataAnnotations;
namespace Learner.App.Service.Dtos
{
    public record ItemDto(Guid Id, string LearnerName, string CourseName);
    public record CreateItemDto([Required] string LearnerName, string CourseName);

     public record updateItemDto([Required] string LearnerName, string CourseName);
}