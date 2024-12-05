# Auto Reference

`Unity 2022.3 (or higher)`
`.NET Standard 2.1`
`C# 9.0`

## Overview

Are you tired writing [`GetComponent`](https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html) in each 
script to reference another script, even though this can never go wrong (when using 
[`[RequireComponent]`](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/RequireComponent.html))? This 
package named AutoReference solves that problem by automatically referencing other script without any extra code.

## Installation instructions

- Open the [Package Manager](https://docs.unity3d.com/Manual/upm-ui.html) in a Unity project.
- Click on the "+" button to add a new package.
- Click on "Install package from git URL...".
- Put in `https://github.com/Incantium/Auto-Reference.git`.
- Click on "Install" or press enter.
- Enjoy!

## Limitations

- It is impossible to reference classes that cannot be referenced through the Unity Editor (that do not inherit from 
  [Component](https://docs.unity3d.com/ScriptReference/Component.html)).
- AutoReference works incorrectly when a prefab in a scene auto references outside the prefab's scope. This is a known
  bug.

## Workflow

Originally, you may have code like this:

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

But with AutoReference, you can enhance it to this:

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

## References

| Class                                    | Description                                                            |
|------------------------------------------|------------------------------------------------------------------------|
| [AutoReference](API~/AutoReference.md)   | The AutoReference attribute to automatically reference another script. |
| [IReferenceable](API~/IReferenceable.md) | Interface for other classes able to be auto referenced.                |
| [Target](API~/Target.md)                 | The target location of the automatically referenced script.            |

## Frequently Asked Questions

### Which Unity versions are compatible with this package?

This package is heavily tested in `Unity 2022.3.44f1` and `Unity 6000.0.25f1`. It is expected that this package also 
works in older and newer versions of the Unity Editor because it is not dependent on any other Unity package.

### Why does a warning appear when I use AutoReference?

![Warning not referenceable.png](Images~/Warning%20not%20referenceable.png)

This warning shows up when the field to be auto referenced is not referenceable through the Unity Editor (like all 
primitive data structures such as integers, floats, and booleans). Only the classes inherited from 
[Component](https://docs.unity3d.com/ScriptReference/Component.html) are referenceable through the Unity Editor. The 
exception is the [IReferenceable](API~/IReferenceable.md) interface, which also makes it possible to be auto 
referenced.

### It is possible for custom classes to be auto referenced?

Yes. It is possible for classes that don't inherit from 
[Component](https://docs.unity3d.com/ScriptReference/Component.html) to be auto referenced, such as 
[serializable](https://learn.microsoft.com/en-us/dotnet/api/system.serializableattribute?view=net-9.0) classes. These 
classes need to implement the [IReferenceable](API~/IReferenceable.md) interface to function properly with the
AutoReference attribute.
