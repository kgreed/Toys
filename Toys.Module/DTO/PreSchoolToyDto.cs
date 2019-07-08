using Toys.Module.BusinessObjects;

namespace Toys.Module.DTO
{
    public class PreSchoolToyDto
    {
        public PreSchoolToyDto(PreSchoolToy toy)
        {
            HelpsReading = toy.HelpsReading;
            GoodForSocial = toy.GoodForSocial;
        }
        public bool HelpsReading { get; set; }

        public bool GoodForSocial { get; set; }
    }
}