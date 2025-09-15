# Rimworld Storage Balance Patches
### by NutritiousCookie

![Storage Balance Patches](About/preview.png)

This mod contains patches for other storage mods to rebalance their various storage buildings. It is intended to be used with Progression: Storage, although that mod is not required.

The changes made by this mod are listed [here](https://docs.google.com/spreadsheets/d/1aPsodNrzzR2pbRKwGoJjD76U-y6hecBySeb66Cm9250).

## Design philosophy

- Declutter menus by removing duplicate items across mods
- Declutter research by removing storage-specific projects, moving buildings to vanilla or vanilla expanded projects.
- Balance around vanilla shelves
- Balance stack sizes by tech level and specialization of the building, rather than resource cost to build it.

General guidelines for stacks per cell are:

| Tech Level | General Use | Specific Use           |
|:----------:|:-----------:|------------------------|
| Neolithic  | 2-3         | 4-6                    |
| Medieval   | 3-4         | 6-8                    |
| Industrial | 4-6         | 8-10 or extra features |
| Spacer     | 10+         | 20+ or extra features  |

Buildings that are larger or have more restrictive allowed items will tend towards the higher end of the range, and buildings that are smaller, allow more items, or have extra uses will tend towards the lower end.

"Extra features" includes refrigeration, production bonuses, etc.

## Compatability

![Storage Balance Patches](About/support.png)
Currently covering these storage mods:
- [Adaptive Primitive Storage](https://steamcommunity.com/sharedfiles/filedetails/?id=3400037215) - Decreases stack sizes significantly. Reduces some material costs.
- [Adaptive Storage Neolithic Module](https://steamcommunity.com/sharedfiles/filedetails/?id=3033901895) - Reduces some material costs. Removes wood pile if Adaptive Primitive is installed.
- [Reel's Expanded Storage](https://steamcommunity.com/sharedfiles/filedetails/?id=3237638097) - Decreases stack sizes. Removes some items if Adaptive Primitive is installed. Removes research projects. Moves buildings to vanilla projects, or Vanilla Furniture Expanded projects if VFE is installed. Also covers the buildings from [VFE - Props](https://steamcommunity.com/sharedfiles/filedetails/?id=2102143149) and [VFE - Art](https://steamcommunity.com/sharedfiles/filedetails/?id=1968134023) if they are installed.
- [Phaneron's Basic Storage](https://steamcommunity.com/sharedfiles/filedetails/?id=3201536200) - Rebalances stack sizes, mostly small tweaks. Removes crates, barrel, meat hook, and weapon rack if Reel's is installed. Removes research projects. Moves buildings to vanilla projects, or VFE projects if VFE is installed.

Research projects are removed, and items are instead assigned to projects from:
- Vanilla (no required DLCs)
- [Vanilla Furniture Expanded - Core](https://steamcommunity.com/sharedfiles/filedetails/?id=1718190143)
- [Vanilla Furniture Expanded - Spacer](https://steamcommunity.com/sharedfiles/filedetails/?id=2028381079)

Made with compatibility in mind for these other mods:
- [Progression: Storage](https://steamcommunity.com/sharedfiles/filedetails/?id=3292746186)
- [Restore Content - Progression: Storage](https://steamcommunity.com/sharedfiles/filedetails/?id=3417113151)

## Installation

### [Steam Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=3566687115)

### Manual

Download and unzip into your `RimWorld/Mods/` folder. Sort it after all of the above mods.

Alternatively, use **[RimSort](https://github.com/RimSort/RimSort)**, the modern, actively developed, open-source modloader for RimWorld, and add this repository in `Download` > `Add Git Mod`. RimSort will sort this mod correctly.

## Usage, permissions, etc

Modding is a community effort that should never be constrained by money or author egos. Use, change, and distribute this mod as you wish. If something feels wrong or bothers you, contribute to the community by making a patch and uploading it for everyone.