# [AutoReference](../Runtime/AutoReference.cs)

Class in `Incantium.Attributes` | Assembled in [`Incantium.AutoReference`](../README.md)

Extends [`PropertyAttribute`](https://docs.unity3d.com/ScriptReference/PropertyAttribute.html)

## Description

![AutoReference](../Images~/AutoReference.png)

AutoReference is a highly-advanced attribute to make the Unity inspector & your code cleaner while giving a slight
performance boost to any game you make.

The main use case of AutoReference is to make automatic references to other components without the use of a serialized
field or [GetComponent()](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GameObject.GetComponent.html) 
in `Start()`. This attribute works perfectly together with the 
[RequireComponent](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/RequireComponent.html) attribute.

With this attribute, you can specify where the component is the near hierarchy around the current game object. You can
choose from:

- Current: Searches through the current game object with the required component.
- Children: Searches through the children for the required component. This will always take the first component of the
  correct type.
- Parent. Searches through the parent game object of the current game object for the required component.

As seen in the above picture, this attribute will create an error box when the required component cannot be found and
automatically referenced.

Under the hood, this attribute uses the corresponding 
[GetComponent()](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GameObject.GetComponent.html) while
removing the field entirely. As it still uses a reference field, this attribute does not require any more usage of the
Unity `Start()`, giving a slight performance boost.

Normally, you would create a reference to a component on the same game object like this:

```csharp
using UnityEngine;

[RequireComponent(typeof(RigidBody))]
public class ExampleClass : MonoBehaviour
{
    private RigidBody rb;
    
    private void Start() 
    {
        rb = GetComponent<RigidBody>();
    }
}
```

But with AutoReference, you can enhance it like this:

```csharp
using Incantium.Attributes;
using UnityEngine;

[RequireComponent(typeof(RigidBody))]
public class BetterExampleClass : MonoBehaviour
{
    [SerializeField]
    [AutoReference]
    private RigidBody rb;
}
```

> **Info**: The AutoReference only works with 
> [SerializeField](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/SerializeField.html) or public 
> variables, so that it is visible by the Unity Editor.

> **Info**: AutoReference is only able to auto reference UnityEngine Component or classes that implement IReferenceable.

> **Warning**: This attribute will only auto reference upon inspecting the component it is included in. In normal 
> circumstances while using this attribute in combination with
> [RequireComponent](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/RequireComponent.html), the changes
> of a reference failure (no reference attached) is slim to none. However, updating a script with a new AutoReference
> will result in such failure if the script is not inspected at least once. Adding a pre-build script with this 
> attribute is completely safe, as the Unity Editor by default inspects the component.

## Variables

### :green_book: `Target` target

The target location of the component for auto-referencing.
