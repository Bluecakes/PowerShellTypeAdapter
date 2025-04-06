namespace PowerShellTypeAdapter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Management.Automation;

    /// <summary>
    /// An Adapter to define how PowerShell should format the Person class
    /// </summary>
    /// <seealso cref="System.Management.Automation.PSPropertyAdapter" />
    public class FavoriteAdapter : PSPropertyAdapter
    {
        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <param name="baseObject">The base object.</param>
        /// <returns>Collection of properties</returns>
        /// <exception cref="NotSupportedException">resource is not supported</exception>
        public override Collection<PSAdaptedProperty> GetProperties(object baseObject)
        {
            if (!(baseObject is Favorite favorite))
            {
                throw new ArgumentNullException(nameof(baseObject));
            }

            var collection = new Collection<PSAdaptedProperty>();

            foreach (var property in favorite.Properties)
            {
                collection.Add(new PSAdaptedProperty(property.Key, null));
            }

            return collection;
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="baseObject">The base object.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>resource property</returns>
        /// <exception cref="NotSupportedException">resource is not supported</exception>
        public override PSAdaptedProperty GetProperty(object baseObject, string propertyName)
        {
            if (!(baseObject is Favorite))
            {
                throw new NotSupportedException(nameof(baseObject));
            }

            return new PSAdaptedProperty(propertyName, null);
        }

        /// <summary>
        /// Determines whether the specified adapted property is settable.
        /// </summary>
        /// <param name="adaptedProperty">The adapted property.</param>
        /// <returns>
        ///   <c>true</c> if the specified adapted property is settable; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">adaptedProperty was not supplied</exception>
        /// <exception cref="NotSupportedException">resource is not supported</exception>
        public override bool IsSettable(PSAdaptedProperty adaptedProperty)
        {
            if (adaptedProperty == null)
            {
                throw new ArgumentNullException(nameof(adaptedProperty));
            }

            if (!(adaptedProperty.BaseObject is Favorite favorite))
            {
                throw new NotSupportedException(nameof(adaptedProperty));
            }

            var property = favorite.GetType().GetProperty(adaptedProperty.Name);

            return property != null && property.CanWrite;
        }

        /// <summary>
        /// Determines whether the specified adapted property is gettable.
        /// </summary>
        /// <param name="adaptedProperty">The adapted property.</param>
        /// <returns>
        ///   <c>true</c> if the specified adapted property is gettable; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">adaptedProperty was not supplied</exception>
        /// <exception cref="NotSupportedException">resource is not supported</exception>
        public override bool IsGettable(PSAdaptedProperty adaptedProperty)
        {
            if (adaptedProperty == null)
            {
                throw new ArgumentNullException(nameof(adaptedProperty));
            }

            if (!(adaptedProperty.BaseObject is Favorite favorite))
            {
                throw new NotSupportedException(nameof(adaptedProperty));
            }

            var property = favorite.GetType().GetProperty(adaptedProperty.Name);

            return property != null && property.CanRead;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="adaptedProperty">The adapted property.</param>
        /// <returns>the property value</returns>
        /// <exception cref="ArgumentNullException">
        /// adaptedProperty
        /// or
        /// BaseObject
        /// or
        /// Name
        /// </exception>
        /// <exception cref="NotSupportedException">BaseObject is not supported</exception>
        public override object GetPropertyValue(PSAdaptedProperty adaptedProperty)
        {
            if (adaptedProperty == null)
            {
                throw new ArgumentNullException(nameof(adaptedProperty));
            }

            if (adaptedProperty.BaseObject == null)
            {
                throw new ArgumentNullException(nameof(adaptedProperty.BaseObject));
            }

            if (adaptedProperty.Name == null)
            {
                throw new ArgumentNullException(nameof(adaptedProperty.Name));
            }

            if (!(adaptedProperty.BaseObject is Favorite favorite))
            {
                throw new NotSupportedException(nameof(adaptedProperty.BaseObject));
            }

            return favorite.Properties.TryGetValue(adaptedProperty.Name, out var value) ? value : null;
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="adaptedProperty">The adapted property.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">
        /// adaptedProperty
        /// or
        /// BaseObject
        /// or
        /// Name
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// BaseObject
        /// or
        /// Name
        /// </exception>
        public override void SetPropertyValue(PSAdaptedProperty adaptedProperty, object value)
        {
            if (adaptedProperty == null)
            {
                throw new ArgumentNullException(nameof(adaptedProperty));
            }

            if (adaptedProperty.BaseObject == null)
            {
                throw new ArgumentNullException(nameof(adaptedProperty.BaseObject));
            }

            if (adaptedProperty.Name == null)
            {
                throw new ArgumentNullException(nameof(adaptedProperty.Name));
            }

            if (!(adaptedProperty.BaseObject is Favorite favorite))
            {
                throw new NotSupportedException(nameof(adaptedProperty.BaseObject));
            }

            favorite.Properties[adaptedProperty.Name] = value;
        }

        /// <summary>
        /// Gets the name of the property type.
        /// </summary>
        /// <param name="adaptedProperty">The adapted property.</param>
        /// <returns>the type name of the property</returns>
        /// <exception cref="ArgumentNullException">adaptedProperty was not supplied</exception>
        /// <exception cref="NotSupportedException">adaptedProperty is not supported</exception>
        public override string GetPropertyTypeName(PSAdaptedProperty adaptedProperty)
        {
            if (adaptedProperty == null)
            {
                throw new ArgumentNullException(nameof(adaptedProperty));
            }

            if (!(adaptedProperty.BaseObject is Favorite favorite))
            {
                throw new NotSupportedException(nameof(adaptedProperty));
            }

            var property = favorite.GetType().GetProperty(adaptedProperty.Name);

            return property?.Name;
        }
    }
}
