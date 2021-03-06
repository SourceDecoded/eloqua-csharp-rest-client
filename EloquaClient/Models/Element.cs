﻿using System.Collections.Generic;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models
{
    public class Element<T>
    {
        public List<T> Elements { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
    }
}
