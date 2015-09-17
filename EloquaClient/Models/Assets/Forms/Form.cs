﻿using System.Collections.Generic;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Forms
{
    [Resource("/assets/form", "Form")]
    public class Form : EloquaDto, ISearchable
    {
        public int? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? FolderId { get; set; }
        public int? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public List<FormElement> Elements {get; set;}
        public string Html { get; set; }
        public string HtmlName { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
