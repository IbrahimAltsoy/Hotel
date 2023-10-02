using System.ComponentModel.DataAnnotations;

namespace Hotel.WebUI.Dtos.TestimonialDto
{
    public class ResultTestimonialDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        [Required, MinLength(100)]
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
