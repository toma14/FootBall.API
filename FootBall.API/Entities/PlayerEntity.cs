using System.ComponentModel.DataAnnotations;

namespace FootBall.API.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public double Rating { get; set; }
    }
}