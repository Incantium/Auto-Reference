# [Target](../Runtime/Target.cs)

Enum in `Incantium.Attributes` | Assembled in [`Incantium.AutoReference`](../README.md)

## Description

Target is an enum for choosing what game object to target using [auto referencing](AutoReference.md). The following 
options are available:

- Current: Searches through the current game object to find the correct component. This used 
  [GetComponent](https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html).
- Children: Searches through the children for the correct component. This will always take the first component of the
  correct type. This target type uses
  [GetComponentInChildren](https://docs.unity3d.com/ScriptReference/Component.GetComponentInChildren.html).
- Parent. Searches through the parent game object of the current game object for the correct component. This uses
  [GetComponentInParent](https://docs.unity3d.com/ScriptReference/Component.GetComponentInParent.html).

## Variables

### :green_book: `Target` Current

Targeting the current game object for the auto referencing.

### :green_book: `Target` Child

Targeting a child game object from the current game object for the auto referencing.

### :green_book: `Target` Parent

Targeting the parent game object from the current game object for the auto referencing.
