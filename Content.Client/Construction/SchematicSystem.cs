using Content.Shared.Interaction;
using Content.Shared.Construction;
using Content.Shared.Construction.Prototypes;
using Robust.Shared.Prototypes;

namespace Content.Client.Construction;

public sealed class SchematicSystem : EntitySystem
{
    [Dependency] private readonly ConstructionSystem _constructionSystem = default!;
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<SchematicComponent, ActivateInWorldEvent>(OnActivate);
    }

    private void OnActivate(EntityUid uid, SchematicComponent component, ActivateInWorldEvent args)
    {
        if (args.Handled)
            return;

        TryStartConstruction(uid, component);
        args.Handled = true;
    }

    public bool TryStartConstruction(EntityUid uid, SchematicComponent component)
    {
        if (component.Prototype == null || _constructionSystem == null) return false;

        if ((_prototypeManager.Index<ConstructionPrototype>(component.Prototype)).Type == ConstructionType.Item)
        {
            _constructionSystem.TryStartItemConstruction(component.Prototype);
            return true;
        }

        return false;
    }
}
