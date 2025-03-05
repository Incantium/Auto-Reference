using UnityEditor;
using UnityEngine;

namespace Incantium.Attributes.Editor
{
    /// <summary>
    /// Class representing the auto referencing mechanism to automatically reference an <see cref="Object"/> to a
    /// property field.
    /// </summary>
    /// <seealso cref="UnityReferencer"/>
    /// <seealso cref="CustomReferencer"/>
    [CustomPropertyDrawer(typeof(AutoReference))]
    internal sealed class AutoReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// The referencer to solve the auto referencing.
        /// </summary>
        private IReferencer searcher;
        
        /// <inheritdoc cref="PropertyDrawer.OnGUI"/>
        /// <summary>
        /// Method to automatically reference the target property and remove the original editor field if possible.
        /// </summary>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (attribute is not AutoReference auto) return;
            if (searcher is { valid: true }) return;
            
            if (Init(property)) return;
            
            searcher.Search(auto.target);
            
            if (searcher.valid) return;

            var message = $"Unable to locate missing '{searcher.type}' for auto referencing at {auto.target.GenerateMessage()}.";
            EditorGUILayout.HelpBox(message, MessageType.Error);
        }

        /// <summary>
        /// Method to instantiate the applicable <see cref="IReferencer"/> to be able to auto reference correctly.
        /// </summary>
        /// <param name="property">The property to auto reference.</param>
        /// <returns>True when the targeted object to be auto referenced is unable to be done, false
        /// otherwise.</returns>
        private bool Init(SerializedProperty property)
        {
            if (searcher != null) return false;
            
            var target = property.Target();
                
            if (target is IReferenceable reference)
            {
                searcher = new CustomReferencer(property, reference);
            }
            else if (!typeof(Component).IsAssignableFrom(fieldInfo.FieldType))
            {
                var message = $"Auto referencing is only applicable to classes derived from '{typeof(Object)}' or '{typeof(IReferenceable)}'.";
                EditorGUILayout.HelpBox(message, MessageType.Warning); 
                return true;
            }
            else
            {
                searcher = new UnityReferencer(property, fieldInfo.FieldType);
            }

            return false;
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => 0;
    }
}