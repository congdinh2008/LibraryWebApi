using System.Collections.Generic;

namespace LibraryApi.Dtos
{
    public abstract class LinkedResourceBaseDto
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
