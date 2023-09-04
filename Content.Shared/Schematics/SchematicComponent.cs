using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;
using Content.Shared.Construction.Prototypes;

namespace Content.Shared.Schematics;

/// <summary>
/// Used for starting a certain item crafting recipe through activating schematics
/// </summary>
[RegisterComponent]
public sealed class SchematicComponent : Component
{
    [DataField("prototype", customTypeSerializer: typeof(PrototypeIdSerializer<ConstructionPrototype>))]
    public string? Prototype { get; private set; }
}
