using System;
using Object = UnityEngine.Object;

namespace Incantium.Attributes
{
    /// <summary>
    /// Interface for classes that don't implement <see cref="Object"/>, but are still able to be referenceable with
    /// <see cref="AutoReference"/>.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Auto-Reference/blob/main/API~/IReferenceable.md">
    /// IReferenceable</seealso>
    public interface IReferenceable
    {
        /// <summary>
        /// The object to automatically get and set.
        /// </summary>
        Object reference { get; set; }
        
        /// <summary>
        /// The typing to search for through auto referencing.
        /// </summary>
        Type referenceType { get; }
    }
}