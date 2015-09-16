﻿using System;
using System.Collections.Generic;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Deployment;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails
{
    [Resource("/assets/email/deployment", "EmailInlineDeployment")]
    public class EmailInlineDeployment : RestObject, ISearchable
    {
        public int? ClickthroughCount { get; set; }
        public List<Contact> Contacts { get; set; }
        public int? OpenCount { get; set; }
        public int? SendFromUserId { get; set; }
        public List<EmailDeploymentStatistics> Statistics { get; set; }
        public Deployment.Email Email { get; set; }
        public DateTime EndAt { get; set; }
        public int? FailedSendCount { get; set; }
        public string SentSubject { get; set; }
        public string SuccessfulSendCount { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
