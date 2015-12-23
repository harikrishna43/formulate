﻿namespace formulate.app.Controllers
{

    // Namespaces.
    using Helpers;
    using Layouts;
    using Models.Requests;
    using Persistence;
    using Resolvers;
    using System;
    using System.Linq;
    using System.Web.Http;
    using Umbraco.Core;
    using Umbraco.Core.Logging;
    using Umbraco.Web;
    using Umbraco.Web.Editors;
    using Umbraco.Web.Mvc;
    using Umbraco.Web.WebApi.Filters;
    using CoreConstants = Umbraco.Core.Constants;
    using LayoutsConstants = formulate.app.Constants.Trees.Layouts;


    /// <summary>
    /// Controller for Formulate layouts.
    /// </summary>
    [PluginController("formulate")]
    [UmbracoApplicationAuthorize(CoreConstants.Applications.Users)]
    public class LayoutsController : UmbracoAuthorizedJsonController
    {

        #region Constants

        private const string UnhandledError = @"An unhandled error occurred. Refer to the error log.";
        private const string PersistLayoutError = @"An error occurred while attempting to persist a Formulate layout.";
        private const string GetLayoutInfoError = @"An error occurred while attempting to get the layout info for a Formulate layout.";
        private const string DeleteLayoutError = @"An error occurred while attempting to delete the Formulate layout.";

        #endregion


        #region Properties

        private ILayoutPersistence Persistence { get; set; }
        private IEntityPersistence Entities { get; set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LayoutsController()
            : this(UmbracoContext.Current)
        {
        }


        /// <summary>
        /// Primary constructor.
        /// </summary>
        /// <param name="context">Umbraco context.</param>
        public LayoutsController(UmbracoContext context)
            : base(context)
        {
            Persistence = LayoutPersistence.Current.Manager;
            Entities = EntityPersistence.Current.Manager;
        }

        #endregion


        #region Web Methods

        /// <summary>
        /// Creates a layout.
        /// </summary>
        /// <param name="request">
        /// The request to create the layout.
        /// </param>
        /// <returns>
        /// An object indicating success or failure, along with some
        /// accompanying data.
        /// </returns>
        [HttpPost]
        public object PersistLayout(PersistLayoutRequest request)
        {

            // Variables.
            var result = default(object);
            var rootId = CoreConstants.System.Root.ToInvariantString();
            var layoutsRootId = GuidHelper.GetGuid(LayoutsConstants.Id);
            var parentId = GuidHelper.GetGuid(request.ParentId);
            var kindId = GuidHelper.GetGuid(request.KindId);


            // Catch all errors.
            try
            {

                // Parse or create the layout ID.
                var layoutId = string.IsNullOrWhiteSpace(request.LayoutId)
                    ? Guid.NewGuid()
                    : GuidHelper.GetGuid(request.LayoutId);


                // Get the ID path.
                var path = parentId == Guid.Empty
                    ? new[] { layoutsRootId, layoutId }
                    : Entities.Retrieve(parentId).Path
                        .Concat(new[] { layoutId }).ToArray();


                // Create layout.
                var layout = new Layout()
                {
                    KindId = kindId,
                    Id = layoutId,
                    Path = path,
                    Name = request.LayoutName,
                    Alias = request.LayoutAlias
                };


                // Persist layout.
                Persistence.Persist(layout);


                // Variables.
                var fullPath = new[] { rootId }
                    .Concat(path.Select(x => GuidHelper.GetString(x)))
                    .ToArray();


                // Success.
                result = new
                {
                    Success = true,
                    Id = GuidHelper.GetString(layoutId),
                    Path = fullPath
                };

            }
            catch(Exception ex)
            {

                // Error.
                LogHelper.Error<LayoutsController>(PersistLayoutError, ex);
                result = new
                {
                    Success = false,
                    Reason = UnhandledError
                };

            }


            // Return result.
            return result;

        }


        /// <summary>
        /// Returns info about the layout with the specified ID.
        /// </summary>
        /// <param name="request">
        /// The request to get the layout info.
        /// </param>
        /// <returns>
        /// An object indicating success or failure, along with some
        /// accompanying data.
        /// </returns>
        [HttpGet]
        public object GetLayoutInfo([FromUri] GetLayoutInfoRequest request)
        {

            // Variables.
            var result = default(object);
            var rootId = CoreConstants.System.Root.ToInvariantString();


            // Catch all errors.
            try
            {

                // Variables.
                var id = GuidHelper.GetGuid(request.LayoutId);
                var layout = Persistence.Retrieve(id);
                var fullPath = new[] { rootId }
                    .Concat(layout.Path.Select(x => GuidHelper.GetString(x)))
                    .ToArray();


                // Set result.
                result = new
                {
                    Success = true,
                    LayoutId = GuidHelper.GetString(layout.Id),
                    KindId = GuidHelper.GetString(layout.KindId),
                    Path = fullPath,
                    Alias = layout.Alias,
                    Name = layout.Name
                };

            }
            catch (Exception ex)
            {

                // Error.
                LogHelper.Error<LayoutsController>(GetLayoutInfoError, ex);
                result = new
                {
                    Success = false,
                    Reason = UnhandledError
                };

            }


            // Return result.
            return result;

        }


        /// <summary>
        /// Deletes the layout with the specified ID.
        /// </summary>
        /// <param name="request">
        /// The request to delete the layout.
        /// </param>
        /// <returns>
        /// An object indicating success or failure, along with some
        /// accompanying data.
        /// </returns>
        [HttpPost()]
        public object DeleteLayout(DeleteLayoutRequest request)
        {

            // Variables.
            var result = default(object);


            // Catch all errors.
            try
            {

                // Variables.
                var layoutId = GuidHelper.GetGuid(request.LayoutId);


                // Delete the layout.
                Persistence.Delete(layoutId);


                // Success.
                result = new
                {
                    Success = true
                };

            }
            catch (Exception ex)
            {

                // Error.
                LogHelper.Error<LayoutsController>(DeleteLayoutError, ex);
                result = new
                {
                    Success = false,
                    Reason = UnhandledError
                };

            }


            // Return the result.
            return result;

        }

        #endregion

    }

}