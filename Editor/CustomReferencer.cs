using System;
using UnityEditor;
using UnityEngine;

namespace Incantium.Attributes.Editor
{
    /// <summary>
    /// Class representing the auto referencing of <see cref="IReferenceable"/> implementations.
    /// </summary>
    public class CustomReferencer : IReferencer
    {
        /// <summary>
        /// The serialized property to auto reference.
        /// </summary>
        private readonly SerializedProperty property;
        
        /// <summary>
        /// The reference to auto reference.
        /// </summary>
        private readonly IReferenceable reference;

        /// <inheritdoc cref="IReferencer.type"/>
        public Type type => reference.referenceType;
        
        /// <inheritdoc cref="IReferencer.valid"/>
        public bool valid => reference.reference;

        public CustomReferencer(SerializedProperty property, IReferenceable reference)
        {
            this.property = property;
            this.reference = reference;
        }
            
        /// <inheritdoc cref="IReferencer.Search"/>
        public void Search(Target target) 
        {
            var gameObject = property.serializedObject.targetObject as Component;
            var component = target.GetComponent(gameObject, type);

            if (!component) return;
                
            reference.reference = component;
            EditorUtility.SetDirty(gameObject);
        }
    }
}