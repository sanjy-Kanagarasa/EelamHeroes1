namespace EelamHeroes.Models.ViewModel
{
    public class PostAddOrUpdateViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Excerpt { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
    }
}