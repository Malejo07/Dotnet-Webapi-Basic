using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Dtos.FamilyGroup
{
    public class FamilyGroupRequestDto
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
