using System;
using UnityEngine;

namespace Incantium.Attributes.Editor
{
    /// <summary>
    /// Class representing methods to be called from the <see cref="Target"/> enum.
    /// </summary>
    internal static class TargetExtensions
    {
        /// <summary>
        /// Method to use GetComponent on the correct <see cref="Target"/>.
        /// </summary>
        /// <param name="target">The target where to GetComponent.</param>
        /// <param name="component">The component to use as the base for GetComponent.</param>
        /// <param name="type">The typing of component to search for.</param>
        /// <returns>The component to search for, or null when not found.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Target"/> enum is used outside its
        /// options.</exception>
        internal static Component GetComponent(this Target target, Component component, Type type) => target switch
        {
            Target.Current => component.GetComponent(type),
            Target.Child => component.GetComponentInChildren(type),
            Target.Parent => component.GetComponentInParent(type),
            _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
        };
        
        /// <summary>
        /// Method to generate what object is targeted as a string.
        /// </summary>
        /// <param name="target">The target location.</param>
        /// <returns>A string denoting what object is targeted.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="Target"/> enum is used outside its
        /// options.</exception>
        internal static string GenerateMessage(this Target target) => target switch
        {
            Target.Current => "the current game object",
            Target.Child => "a child game object",
            Target.Parent => "the parent game object",
            _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
        };
    }
}