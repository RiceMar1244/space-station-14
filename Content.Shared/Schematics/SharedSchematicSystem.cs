using Content.Shared.Foldable;
using Content.Shared.Interaction;

namespace Content.Shared.Schematics;

public abstract class SharedSchematicSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<SchematicComponent, ActivateInWorldEvent>(OnActivate);
    }

    private void OnActivate(EntityUid uid, SchematicComponent schematic, ActivateInWorldEvent args)
    {
        if (args.Handled)
            return;

        TryActivateSchematic(uid, schematic);
        args.Handled = true;
    }

    public bool TryActivateSchematic(EntityUid uid, SchematicComponent schematic)
    {
        if (TryComp<FoldableComponent>(uid, out var foldcomp) && foldcomp.IsFolded) return false;

        ActivateSchematic(uid, schematic);
        return true;
    }

    protected virtual void ActivateSchematic(EntityUid uid, SchematicComponent schematic)
    {
        //clientside SchematicSystem.cs will handle this we only want to unhide the recipe on a specific client's side
    }
}
