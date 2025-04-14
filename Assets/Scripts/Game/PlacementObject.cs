using System;
using JetBrains.Annotations;
using UnityEngine;
using VContainer.Unity;

public class PlacementObject : IDisposable, IInitializable
{
    public readonly Placement Object;

    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)] //Suppressing Warnings
    public PlacementObject(Placement placement)
    {
        Object = placement;
    }

    void IDisposable.Dispose()
    {
        Object.Dispose();
    }

    void IInitializable.Initialize()
    {
        Debug.Log("");
    }
}