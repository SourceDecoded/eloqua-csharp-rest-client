﻿using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Accounts.Views;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Campaigns;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Lists;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Segments;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Views;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.ContentSections;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.CustomObjects;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.DynamicContents;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Groups;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.External;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Forms;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.LandingPages.Structured;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Microsites;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.OptionLists;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Clients.Assets
{
    public class AssetClient
    {
        #region constructor 

        public AssetClient(BaseClient baseClient)
        {
            BaseClient = baseClient;
        }

        #endregion

        #region properties

        protected BaseClient BaseClient;

        #endregion

        #region Contact Assets

        public GenericClient<ContactSegment> ContactSegment => _contactSegment ?? (_contactSegment = new GenericClient<ContactSegment>(BaseClient));
        private GenericClient<ContactSegment> _contactSegment;

        public GenericClient<ContactList> ContactList => _contactList ?? (_contactList = new GenericClient<ContactList>(BaseClient));
        private GenericClient<ContactList> _contactList;

        public GenericClient<ContactView> ContactView => _contactView ?? (_contactView = new GenericClient<ContactView>(BaseClient));
        private GenericClient<ContactView> _contactView;

        public GenericClient<ContactField> ContactFields => _contactFields ?? (_contactFields= new GenericClient<ContactField>(BaseClient));
        private GenericClient<ContactField> _contactFields;
        

        #endregion

        #region Account Assets

        public GenericClient<AccountView> AccountView => _accountView ?? (_accountView = new GenericClient<AccountView>(BaseClient));
        private GenericClient<AccountView> _accountView;

        #endregion

        #region Email

        public GenericClient<Email> Email => _emailClient ?? (_emailClient = new GenericClient<Email>(BaseClient));
        private GenericClient<Email> _emailClient;

        public GenericClient<global::LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Structured.Email> StructuredEmail => _structuredEmailClient ?? ( _structuredEmailClient = new GenericClient<global::LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Structured.Email>(BaseClient));
        private GenericClient<global::LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Structured.Email> _structuredEmailClient;

        public GenericClient<EmailGroup> EmailGroup => _emailGroupClient ?? (_emailGroupClient = new GenericClient<EmailGroup>(BaseClient));
        private GenericClient<EmailGroup> _emailGroupClient; 

        #endregion

        #region EmailDeployment

        public SearchClient<EmailDeployment> EmailDeployment => _emailDeployment ?? (_emailDeployment = new SearchClient<EmailDeployment>(BaseClient));
        private SearchClient<EmailDeployment> _emailDeployment; 

        public GenericClient<EmailInlineDeployment> EmailInlineDeployment => _emailInlineDeployment ?? (_emailInlineDeployment = new GenericClient<EmailInlineDeployment>(BaseClient));
        private GenericClient<EmailInlineDeployment> _emailInlineDeployment;

        public GenericClient<global::LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Deployment.Structured.EmailInlineDeployment> StructuredEmailInlineDeployment => _structuredEmailInlineDeployment ?? (_structuredEmailInlineDeployment = new GenericClient<global::LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Deployment.Structured.EmailInlineDeployment>(BaseClient));
        private GenericClient<global::LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Deployment.Structured.EmailInlineDeployment> _structuredEmailInlineDeployment;

        public GenericClient<EmailTestDeployment> EmailTestDeployment => _emailTestDeployment ?? (_emailTestDeployment = new GenericClient<EmailTestDeployment>(BaseClient));
        private GenericClient<EmailTestDeployment> _emailTestDeployment;

        #endregion

        #region LandingPages

        public GenericClient<LandingPage> LandingPage => _landingPage ?? (_landingPage = new GenericClient<LandingPage>(BaseClient));
        private GenericClient<LandingPage> _landingPage;

        public GenericClient<global::LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.LandingPages.Structured.LandingPage> StructuredLandingPage => _structuredLandingPage ?? (_structuredLandingPage = new GenericClient<global::LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.LandingPages.Structured.LandingPage>(BaseClient));
        private GenericClient<global::LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.LandingPages.Structured.LandingPage> _structuredLandingPage;

        #endregion

        #region Campaigns

        public GenericClient<Campaign> Campaign => _campaign ?? (_campaign = new GenericClient<Campaign>(BaseClient));
        private GenericClient<Campaign> _campaign;

        #endregion

        #region CustomObjects

        public GenericClient<CustomObject> CustomObject => _customObjectClient ?? (_customObjectClient = new GenericClient<CustomObject>(BaseClient));
        private GenericClient<CustomObject> _customObjectClient;

        #endregion

        #region Microsites

        public GenericClient<Microsite> Microsite => _micrositeClient ?? (_micrositeClient = new GenericClient<Microsite>(BaseClient));
        private GenericClient<Microsite> _micrositeClient;

        #endregion

        #region OptionLists

        public GenericClient<OptionList> OptionList => _optionList ?? (_optionList = new GenericClient<OptionList>(BaseClient));
        private GenericClient<OptionList> _optionList;

        #endregion

        #region Content 

        public GenericClient<DynamicContent> DynamicContent => _dynamicContent ?? (_dynamicContent = new GenericClient<DynamicContent>(BaseClient));
        private GenericClient<DynamicContent> _dynamicContent;

        public GenericClient<ContentSection> ContentSection => _contentSection ?? (_contentSection = new GenericClient<ContentSection>(BaseClient));
        private GenericClient<ContentSection> _contentSection;

        #endregion

        #region External Assets

        public GenericClient<ExternalAsset> ExternalAsset => _externalAsset ?? (_externalAsset = new GenericClient<ExternalAsset>(BaseClient));
        private GenericClient<ExternalAsset> _externalAsset;

        #endregion

        #region Forms

        public GenericClient<Form> Form => _form ?? (_form = new GenericClient<Form>(BaseClient));
        private GenericClient<Form> _form;
        
        #endregion

    }
}
