﻿namespace formulate.app.Managers
{

    // Namespaces.

    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    using Configuration;

    using core.Types;

    using Templates;

    /// <summary>
    /// The default configuration manager.
    /// </summary>
    internal sealed class DefaultConfigurationManager : IConfigurationManager
    {
        /// <summary>
        /// Gets or sets the Formulate config.
        /// </summary>
        private IFormulateConfig Config { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultConfigurationManager"/> class.
        /// </summary>
        /// <param name="config">
        /// The Formulate config.
        /// </param>
        public DefaultConfigurationManager(IFormulateConfig config)
        {
            Config = config;
        }

        #region Properties

        /// <summary>
        /// The base path to store JSON in.
        /// </summary>
        public string JsonBasePath
        {
            get
            {
                return Config.Persistence.JsonBasePath;
            }
        }

        /// <summary>
        /// The base path toe store submitted files in.
        /// </summary>
        public string FileStoreBasePath
        {
            get
            {
                return Config.Persistence.JsonBasePath;
            }
        }

        /// <summary>
        /// The templates used to render forms.
        /// </summary>
        public IEnumerable<Template> Templates
        {
            get
            {
                return Config.Templates;
            }
        }

        /// <summary>
        /// The button kinds used when creating button field types.
        /// </summary>
        public IEnumerable<string> ButtonKinds
        {
            get
            {
                return Config.Buttons?.Select(x => x.Kind);
            }
        }


        /// <summary>
        /// Enable server side validation of form submissions?
        /// </summary>
        public bool EnableServerSideValidation
        {
            get
            {
                return Config.Submissions.EnableServerSideValidation;
            }
        }

        /// <summary>
        /// Is the email whitelist enabled?
        /// </summary>
        public bool EnableEmailWhitelist
        {
            get
            {
                return Config.Email.Whitelist.Enabled;
            }
        }

        /// <summary>
        /// The emails to whitelist.
        /// </summary>
        public IEnumerable<AllowEmail> EmailWhitelist
        {
            get
            {
                return Config.Email.Whitelist.AllowedEmails.Select(x => new AllowEmail()
                {
                    Email = x.Email,
                    Domain = x.Domain
                }).ToArray();
            }
        }

        /// <summary>
        /// Gets the headers to use for emails.
        /// </summary>
        public IEnumerable<EmailHeader> EmailHeaders
        {
            get
            {
                return Config.Email.Headers.Select(x => new EmailHeader() { Name = x.Name, Value = x.Value });
            }
        }


        /// <summary>
        /// Gets the field categories.
        /// </summary>
        public IEnumerable<FieldCategory> FieldCategories
        {
            get
            {
                return Config.FieldCategories.Categories.Select(x => new FieldCategory()
                {
                    Kind = x.Kind,
                    Group = x.Group
                }).ToArray();
            }
        }

        #endregion

    }

}