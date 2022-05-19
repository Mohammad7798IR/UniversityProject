

namespace Shop.Domain.Entities.Site
{
    public class Slider : BaseEntity
    {
        public bool IsActive { get; set; }

        public string MainHeader { get; set; }

        public string SecondaryHeader { get; set; }

        public string Url { get; set; }


        public string Image { get; set; }
    }
}
