using JetBrains.Annotations;

public class PlacementObject
{
    public readonly Placement Object;

    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)] //Suppressing Warnings
    public PlacementObject(Placement placement)
    {
        Object = placement;
    }
}