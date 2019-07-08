using Toys.Module.BusinessObjects;

namespace Toys.Module.DTO
{
    public class ToddlerToyDto
    {
        public ToddlerToyDto(ToddlerToy toy)
        {
            HelpsTalking = toy.HelpsTalking;
            GoodForWalking = toy.GoodForWalking;
        }

        public bool HelpsTalking { get; set; }

        public bool GoodForWalking { get; set; }
    }
}