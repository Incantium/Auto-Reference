# [IReferenceable](../Runtime/IReferenceable.cs)

Interface in `Incantium.Attributes` | Assembled in [`Incantium.AutoReference`](../README.md)

## Description

IReferenceable is an interface that other classes can implement to be included in [AutoReference](AutoReference.md).

## Notes

> **Info**: All classes that implement [Component](https://docs.unity3d.com/ScriptReference/Component.html) or its 
> counterpart [Object](https://docs.unity3d.com/ScriptReference/Object.html) doesn't need this interface. These types
> are explicitly auto referenceable.

## Variables

### :green_book: `Object` reference

The object to automatically get and set.

### :green_book: `Type` referenceType

The typing to search for through auto referencing.
