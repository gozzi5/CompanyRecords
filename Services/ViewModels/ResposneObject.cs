using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class ResponseObjects<T>
    {

        public List<T> Results { get; set; }

        public string Message { get; set; } 
        public bool Success { get; set; }
    }

    public class ResponseObject<T>
    {
        
        public bool Success { get; set; }
        public T Result { get; set; }

        public string Message { get; set; } 
    }
}
