using System;
using UnityEditor;
using UnityEngine;

namespace Incantium.Attributes.Editor
{
    /// <summary>
    /// Class representing the auto referencing of <see cref="UnityEngine.Component"/> implementations.
    /// </summary>
    public class UnityReferencer : IReferencer
    {
        /// <summary>
        /// The serialized property to auto reference.
        /// </summary>
        private readonly SerializedProperty property;
        
        /// <inheritdoc cref="IReferencer.type"/>
        public Type type { get; }

        /// <inheritdoc cref="IReferencer.valid"/>
        public bool valid => typeof(Component).IsAssignableFrom(type) && property.objectReferenceValue != null;

        public UnityReferencer(SerializedProperty property, Type type)
        {
            this.property = property;
            this.type = type;
        }
        
        /// <inheritdoc cref="IReferencer.Search"/>
        public void Search(Target target) 
        {
            var gameObject = property.serializedObject.targetObject as Component;
            var component = target.GetComponent(gameObject, type);

            if (!component) return;
                
            property.objectReferenceValue = component;
        }
    }
}