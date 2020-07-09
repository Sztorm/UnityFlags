# UnityFlags
An enum flags drawer for Unity editor.
## Features
Custom Property drawer that interprets enum flags as set of booleans.
Not all flag fields must be exposed to the editor, you can decide which flags to display and give them custom, inspector-only name.
You can attach Tooltips to flags as well via ``FlagTooltips`` attribute.

## Examples/How to use
<details>
<summary>Step by step</summary>
  
 * Firstly, Create new Monobehaviour script and attach it to any gameobject you want it on.
 * Remember to import ``Sztorm.Unity.Flags`` namespace as well as ``Sztorm.Extensions.Enum`` to ease work with enum flags.
 * Create 8-bit enum. Each flag must correspond to exactly one bit but not all flags must be specified if they are not needed.
```csharp
[System.Flags] // Flags attribute is optional. It provides nice text format for bit flags.
enum ExampleEnum : byte // Can be sbyte as well.
{
  None = 0,
  Bit0 = 1 << 0,
  Bit1 = 1 << 1,
  Bit2 = 1 << 2,
  Bit3 = 1 << 3,
}
```
 * Define ``ExampleEnum`` field in your ``MonoBehaviour`` script.
```csharp
[SerializeField] // Allows to show nonpublic fields in inspector
private ExampleEnum flags;
```
 * Attach ``FlagFields`` attribute and specify names for flags to show in inspector. You can keep some fields private.
 
```csharp
[FlagFields(
  flagName0: "First bit field", // ExampleEnum.Bit0
  flagName2: "Third bit field")] // ExampleEnum.Bit2
[SerializeField] // Allows to show nonpublic fields in inspector
private ExampleEnum flags;
```
 * Additionally, you can attach ``FlagTooltips`` attribute to specify tooltips for your flags.
 
```csharp
[FlagTooltips(
  tooltip0: "This is first bit important note.", // ExampleEnum.Bit0
  tooltip2: "This is first bit important note.")] // ExampleEnum.Bit2
[FlagFields(
  flagName0: "First bit field", // ExampleEnum.Bit0
  flagName2: "Third bit field")] // ExampleEnum.Bit2
[SerializeField] // Allows to show nonpublic fields in inspector
private ExampleEnum flags;
```
 * The end, it should look like this:
 
Script:
 ```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sztorm.Unity.Flags;
using Sztorm.Extensions.Enum;

public class ExampleBehaviour : MonoBehaviour
{
    [System.Flags] // Flags attribute is optional. It provides nice text format for bit flags.
    enum ExampleEnum : byte // Can be sbyte as well.
    {
        None = 0,
        Bit0 = 1 << 0,
        Bit1 = 1 << 1,
        Bit2 = 1 << 2,
        Bit3 = 1 << 3,
    }

    [FlagTooltips(
        tooltip0: "This is first bit important note.", // ExampleEnum.Bit0
        tooltip2: "This is first bit important note.")] // ExampleEnum.Bit2
    [FlagFields(
        flagName0: "First bit field", // ExampleEnum.Bit0
        flagName2: "Third bit field")] // ExampleEnum.Bit2
    [SerializeField] // Allows to show nonpublic fields in inspector
    private ExampleEnum flags;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
```
Inspector:

![Inspector image.](https://i.imgur.com/a9gKa1F.png "Inspector image.")

To learn how to use enum extensions from ``Sztorm.Extensions.Enum``, see [examples](https://github.com/Sztorm/CSharpExtensions#examples)

</details>

For complete example, see [Examples](.Examples) folder.
Example in action:

![Example in action](https://i.imgur.com/AFgVymH.gif "Example in action")

## Requirements
 * Drawer works only for 8-bit enums (with underlying type of ``byte`` or ``sbyte``) with properly set flag fields (1 bit per flag).
 * .NET Standard 2.0 compatibility
 * [System.Runtime.CompilerServices.Unsafe 4.7.1](https://www.nuget.org/packages/System.Runtime.CompilerServices.Unsafe/4.7.1)
 * [Sztorm/CSharpExtensions 0.1.0](https://github.com/Sztorm/CSharpExtensions)
 
Although library dependencies are provided in [Plugins](.Plugins) folder. If you already have one of them in your project make sure to handle references to them properly and move them in/out the Plugins folder or just delete the duplicates.

Works in Unity 2019.4.0f1 and Unity 2019.1.3f1, however UnityFlags may work in newer as well as in older Unity versions.

## Instalation
 * Download release unitypackage and import it to your project.
 
 or 
 * Download sourcecode.zip and extract it in your project ``Assets`` folder.

## License
UnityFlags is licensed under the MIT license. UnityFlags is free for commercial and non-commercial use.

[More about license.](./LICENSE)
