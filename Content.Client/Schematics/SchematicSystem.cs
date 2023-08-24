using Content.Client.Construction;
using Content.Shared.Schematics;

namespace Content.Client.Schematics;

public sealed class SchematicSystem : SharedSchematicSystem
{
    [Dependency] private readonly ConstructionSystem _constructionSystem = default!;

    public override void Initialize()
    {
        base.Initialize();
    }

    protected override void ActivateSchematic(EntityUid uid, SchematicComponent schematic)
    {
        if (schematic.Prototype == null) return;

        _constructionSystem.TryStartItemConstruction(schematic.Prototype);
        return;
    }
}


