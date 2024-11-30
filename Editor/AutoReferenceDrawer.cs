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
        /// The static height of the property field when there is an error to be shown.
        /// </summary>
        private const int HEIGHT = 30;
        
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
            
            if (Init(position, property)) return;
            
            searcher.Search(auto.target);
            
            if (searcher.valid) return;
            
            EditorGUI.HelpBox(position, $"Unable to locate missing '{searcher.type}' for auto referencing at " +
                                        $"the {auto.target.GenerateMessage()}.", MessageType.Error);
        }

        /// <summary>
        /// Method to instantiate the applicable <see cref="IReferencer"/> to be able to auto reference correctly.
        /// </summary>
        /// <param name="position">The position of the property field.</param>
        /// <param name="property">The property to auto reference.</param>
        /// <returns>True when the targeted object to be auto referenced is unable to be done, false
        /// otherwise.</returns>
        private bool Init(Rect position, SerializedProperty property)
        {
            if (searcher != null) return false;
            
            var target = property.Target();
                
            if (target is IReferenceable reference)
            {
                searcher = new CustomReferencer(property, reference);
            }
            else if (!typeof(Component).IsAssignableFrom(fieldInfo.FieldType))
            { 
                EditorGUI.HelpBox(position, "Auto referencing is only applicable to component derived " +
                                            "objects.", MessageType.Warning); 
                return true;
            }
            else
            {
                searcher = new UnityReferencer(property, fieldInfo.FieldType);
            }

            return false;
        }
        
        /// <summary>
        /// Method to determine how large the property field height should be.
        /// </summary>
        /// <param name="property">The property to draw.</param>
        /// <param name="label">The label associated with the property.</param>
        /// <returns>The default <see cref="HEIGHT"/> when no <see cref="IReferencer"/> could be located for the target
        /// property or if the target property is not findable, otherwise 0.</returns>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (searcher == null) return HEIGHT;

            return searcher.valid ? 0 : HEIGHT;
        }
    }
}