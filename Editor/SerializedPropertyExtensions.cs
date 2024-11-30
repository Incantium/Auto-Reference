using System.Reflection;
using UnityEditor;

namespace Incantium.Attributes.Editor
{
    /// <summary>
    /// Class with methods for the <see cref="SerializedProperty"/>.
    /// </summary>
    internal static class SerializedPropertyExtensions
    {
        /// <summary>
        /// Method to get the object set to the serialized property through reflection.
        /// </summary>
        /// <param name="property">The serialized property.</param>
        /// <returns>The object.</returns>
        internal static object Target(this SerializedProperty property)
        {
            if (property == null) return null;

            var path = property.propertyPath.Split('.');
            object obj = property.serializedObject.targetObject;

            foreach (var part in path)
            {
                var field = obj.GetType().GetField(part, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                if (field == null) return null;
                obj = field.GetValue(obj);
            }
            return obj;
        }
    }
}