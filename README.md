# Dynamic Panels System for Unity

A flexible and modular system for creating dynamic UI panels in Unity. This package allows you to define UI fields via **specifications**, bind them to any data context, and render them automatically with custom field renderers. Fields can have visibility conditions and can be fully customized through `ScriptableObject` assets.

---

# Features

- **Dynamic Panel Construction**: Automatically builds panels based on field specifications.
- **Flexible Data Binding**: Works with any object implementing `IDataContext` for runtime data binding.
- **Field Types Supported**: Bool, Enum, Int (extendable).
- **Conditional Visibility**: Show or hide fields based on other field values.
- **Custom Renderers**: Register your own field renderers for different field types.
- **Extensible**: Add new field types, renderers, and panel layouts with minimal setup.
- **Example Assets Included**: Example prefabs and data for testing and prototyping.

---

# Installation

Simply download or clone this repository and copy the `DynamicPanels` folder into your Unity project (e.g., under `Assets/`).  

```bash
git clone https://github.com/KasaiFudo/DynamicPanels.git
```

# Usage

## 1. Create Field Specifications

Field specifications define what fields your panel will display. You can create them via `SpecsData` ScriptableObject:

```csharp
[CreateAssetMenu(fileName = "SpecsData", menuName = "Scriptable Objects/SpecsData")]
public class SpecsData : ScriptableObject
{
    [SerializeField] public List<FieldSpec> Specs { get; private set; }
}
```
Each FieldSpec can include:

**Id** – unique identifier from your data(Property name).

**Type** – field type (Bool, Enum, Int and more).

**Label** – user-visible label. Can be used as key for your localization

**Options** – for enums or selectable values.

**Group and Order** – for layout grouping and ordering.

**VisibleIf** – list of conditions for dynamic visibility.

## 2. Register Field Renderers

Create prefabs that inherit from `FieldRenderer` for each FieldType or use included ones. Then register them in a `RendererRegistry`:

```csharp
[CreateAssetMenu(fileName = "RendererRegistry", menuName = "Scriptable Objects/RendererRegistry")]
public class RendererRegistry : ScriptableObject
{
    [SerializeField] private List<Entry> _entries;
    
    public FieldRenderer GetRenderer(FieldType type) { ... }
}
```

## 3. Bind Data Context

Your data object should implement or be wrapped in `IDataContext`:

```csharp
public interface IDataContext
{
    object GetValue(string id);
    void SetValue(string id, object value);
}
```
You can use `DynamicDataContext<T>` for automatic binding of any class:

```csharp
var context = new DynamicDataContext<MyData>(myDataInstance);
panel.Build(context);
```

## 4. Build the Panel

Create a class inheriting from `DynamicPanel` and call Build with your data context:

```csharp
public class ExamplePanel : DynamicPanel
{
    public void Initialize(IDataContext context)
    {
        Build(context);
    }
    
    protected override void OnValueChanged()
    {
        Debug.Log("A field value changed!");
    }
}
```

All fields specified in `SpecsData` will be instantiated as UI elements inside `_container` using the registered renderers.

### Conditional Visibility

Fields can be shown or hidden based on other fields:

```csharp
[Serializable]
public class Condition
{
    [SerializeField] private string _settingId;
    [SerializeField] private string _op;        // "==", "!=", ">", "<", "in"
    [SerializeField] private string _propertyValue;

    public bool Evaluate(IDataContext context) { ... }
}
```
Supported operations: ==, !=, >, <, in.

# Project Structure

```bash
DynamicPanels/
├─ Scripts/           # Core scripts (DynamicPanel, FieldRenderer, DataContext)
├─ Prefabs/            # Included prefabs for first view
├─ Samples/          # Example prefabs, scenes, and ScriptableObjects
├─ UISwitcher        #Simply toggle component for UI
├─ README.md
└─ LICENSE
```

# Extending the System

Add new field types: Extend FieldType enum and create a corresponding FieldRenderer prefab.

Add new conditions: Extend Condition class with custom evaluation logic.

Customize panel layouts: Override DynamicPanel. Build for custom arrangement or animation.

# License

This project is licensed under the MIT License
.
