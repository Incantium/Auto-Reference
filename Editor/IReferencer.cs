using System;

namespace Incantium.Attributes.Editor
{
    /// <summary>
    /// Interface for implementations used by the <see cref="AutoReference"/> and <see cref="AutoReferenceDrawer"/> to
    /// automatically reference components through the editor.
    /// </summary>
    internal interface IReferencer
    {
        /// <summary>
        /// The target typing to auto reference.
        /// </summary>
        Type type { get; }
        
        /// <summary>
        /// True when the auto reference has succeeded, otherwise false.
        /// </summary>
        bool valid { get; }

        /// <summary>
        /// Method to search for the object to auto reference.
        /// </summary>
        /// <param name="target">The target location to search for to auto reference.</param>
        void Search(Target target);
    }
}