# Rimworld Storage Balance Patches
### by NutritiousCookie

This mod contains patches for other storage mods to rebalance their various storage buildings. It is intended to be used with Progression: Storage, although that mod is not required.

## Design philosophy

- Declutter menus by removing duplicate items across mods
- Declutter research by removing storage-specific projects, moving buildings to vanilla or vanilla expanded projects.
- Balance around vanilla shelves (which are changed to neolithic tech)
- Balance stack sizes by tech level and specialization of the building, rather than resource cost to build it.

General guidelines for stacks per cell are:

| Tech Level | General Use | Specific Use           |
|:----------:|:-----------:|------------------------|
| Neolithic  | 2-3         | 4-8                    |
| Medieval   | 4-5         | 6-10                   |
| Industrial | 6-8         | 8-16 or extra features |
| Spacer     | 15-20       | extra features         |

Buildings that are larger or have more restrictive allowed items will tend towards the higher end of the range, and buildings that are smaller, allow more items, or have extra uses will tend towards the lower end.

"Extra features" includes refrigeration, production bonuses, etc.

## Compatability

Currently covering these storage mods:
- [Adaptive Primitive Storage](https://steamcommunity.com/sharedfiles/filedetails/?id=3400037215) - Restores content cut by Progression: Storage. Reduces some material costs. Decreases stack sizes significantly.
- [Adaptive Storage Neolithic Module](https://steamcommunity.com/sharedfiles/filedetails/?id=3033901895) - Reduces some material costs. Removes wood pile if Adaptive Primitive is installed.
- [Reel's Expanded Storage](https://steamcommunity.com/sharedfiles/filedetails/?id=3237638097) - Removes some items if Adaptive Primitive is installed. Removes research projects. Moves buildings to vanilla projects, or Vanilla Furniture Expanded projects if VFE is installed. Covers the following:
  - [Vanilla Furniture Expanded - Core](https://steamcommunity.com/sharedfiles/filedetails/?id=1718190143)
  - [Vanilla Furniture Expanded - Art](https://steamcommunity.com/sharedfiles/filedetails/?id=1968134023)
  - [Vanilla Furniture Expanded - Production](https://steamcommunity.com/sharedfiles/filedetails/?id=1880253632)
  - [Vanilla Furniture Expanded - Spacer](https://steamcommunity.com/sharedfiles/filedetails/?id=2028381079)
  - [Vanilla Furniture Expanded - Props and Decor](https://steamcommunity.com/sharedfiles/filedetails/?id=2102143149)

Made with compatibility in mind for these other patches:
- [Progression: Storage](https://steamcommunity.com/sharedfiles/filedetails/?id=3292746186)
- [Restore Content - Progression: Storage](https://steamcommunity.com/sharedfiles/filedetails/?id=3417113151) (unnecessary with this mod)

## Installation

### [Steam Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=3566687115)

### Manual

Download and unzip into your `RimWorld/Mods/` folder. Sort it after all of the above mods.

Alternatively, use **[RimSort](https://github.com/RimSort/RimSort)**, the modern, actively developed, open-source modloader for RimWorld, and add this repository in `Download` > `Add Git Mod`. RimSort will sort this mod correctly.

## Usage, permissions, etc

Modding is a community effort that should never be constrained by money or author egos. Use, change, and distribute this mod as you wish. If something feels wrong or bothers you, contribute to the community by making a patch and uploading it for everyone.