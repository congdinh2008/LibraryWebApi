using System.Collections.Generic;

namespace LibraryApi.Dtos
{
    public class LinkedCollectionResourceWrapperDto<T> : 
        LinkedResourceBaseDto where T : LinkedResourceBaseDto
    {
        public LinkedCollectionResourceWrapperDto(IEnumerable<T> value)
        {
            Value = value;
        }

        public IEnumerable<T> Value { get; set; }
    }
}
