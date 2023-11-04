using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;
using Content.Shared.Construction.Prototypes;

namespace Content.Shared.Construction;

/// <summary>
/// Used by <see cref="SchematicSystem"/> for starting a certain item crafting recipe on entity activation.
/// </summary>
[RegisterComponent]
public sealed partial class SchematicComponent : Component
{
    [DataField("prototype", customTypeSerializer: typeof(PrototypeIdSerializer<ConstructionPrototype>))]
    public string? Prototype { get; private set; }
}
