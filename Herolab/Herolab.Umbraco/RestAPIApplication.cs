using System;
using System.Collections.Generic;
using Umbraco.Core;

namespace Herolab.Umbraco
{
    internal class RestAPIApplication : UmbracoApplicationBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StandaloneCoreApplication"/> class.
        /// </summary>
        protected RestAPIApplication(string baseDirectory)
        {
            _baseDirectory = baseDirectory;
        }

        /// <summary>
        /// Provides the application boot manager.
        /// </summary>
        /// <returns>An application boot manager.</returns>
        protected override IBootManager GetBootManager()
        {
            return new RestAPIBootManager(this, _handlersToAdd, _handlersToRemove, _baseDirectory);
        }

        #region Application

        private readonly string _baseDirectory;
        private static RestAPIApplication _application;
        private static bool _started;
        private static readonly object AppLock = new object();

        /// <summary>
        /// Gets the instance of the standalone Umbraco application.
        /// </summary>
        public static RestAPIApplication GetApplication(string baseDirectory)
        {
            lock (AppLock)
            {
                return _application ?? (_application = new RestAPIApplication(baseDirectory));
            }
        }

        /// <summary>
        /// Starts the application.
        /// </summary>
        public void Start()
        {
            lock (AppLock)
            {
                if (_started)
                    throw new InvalidOperationException("Application has already started.");
                Application_Start(this, EventArgs.Empty);
                _started = true;
            }
        }

        #endregion

        #region IApplicationEventHandler management

        private readonly List<Type> _handlersToAdd = new List<Type>();
        private readonly List<Type> _handlersToRemove = new List<Type>();

        /// <summary>
        /// Associates an <see cref="IApplicationEventHandler"/> type with the application.
        /// </summary>
        /// <typeparam name="T">The type to associate.</typeparam>
        /// <returns>The application.</returns>
        /// <remarks>Types implementing <see cref="IApplicationEventHandler"/> from within
        /// an executable are not automatically discovered by Umbraco and have to be
        /// explicitely associated with the application using this method.</remarks>
        public RestAPIApplication WithApplicationEventHandler<T>()
            where T : IApplicationEventHandler
        {
            _handlersToAdd.Add(typeof(T));
            return this;
        }

        /// <summary>
        /// Dissociates an <see cref="IApplicationEventHandler"/> type from the application.
        /// </summary>
        /// <typeparam name="T">The type to dissociate.</typeparam>
        /// <returns>The application.</returns>
        public RestAPIApplication WithoutApplicationEventHandler<T>()
            where T : IApplicationEventHandler
        {
            _handlersToRemove.Add(typeof(T));
            return this;
        }

        /// <summary>
        /// Associates an <see cref="IApplicationEventHandler"/> type with the application.
        /// </summary>
        /// <param name="type">The type to associate.</param>
        /// <returns>The application.</returns>
        /// <remarks>Types implementing <see cref="IApplicationEventHandler"/> from within
        /// an executable are not automatically discovered by Umbraco and have to be
        /// explicitely associated with the application using this method.</remarks>
        public RestAPIApplication WithApplicationEventHandler(Type type)
        {
            if (type.Implements<IApplicationEventHandler>() == false)
                throw new ArgumentException("Type does not implement IApplicationEventHandler.", "type");
            _handlersToAdd.Add(type);
            return this;
        }

        /// <summary>
        /// Dissociates an <see cref="IApplicationEventHandler"/> type from the application.
        /// </summary>
        /// <param name="type">The type to dissociate.</param>
        /// <returns>The application.</returns>
        public RestAPIApplication WithoutApplicationEventHandler(Type type)
        {
            if (type.Implements<IApplicationEventHandler>() == false)
                throw new ArgumentException("Type does not implement IApplicationEventHandler.", "type");
            _handlersToRemove.Add(type);
            return this;
        }

        #endregion
    }
}