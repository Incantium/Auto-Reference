using System;
using UnityEngine;

namespace Incantium.Attributes
{
    /// <summary>
    /// Attribute to auto reference a component attached to the same or a close family member of the current game
    /// object.
    /// </summary>
    /// <remarks>This attribute only works for classes that implement <see cref="UnityEngine.Object"/> or those that
    /// implement <see cref="IReferenceable"/>.</remarks>
    /// <seealso href="https://github.com/Incantium/Auto-Reference/blob/main/Documentation~/API.md">
    /// AutoReference</seealso>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class AutoReference : PropertyAttribute
    {
        /// <summary>
        /// The target location of the component to be automatically referenced.
        /// </summary>
        internal Target target { get; private set; }
        
        public AutoReference(Target target = Target.Current) => this.target = target;
    }
}