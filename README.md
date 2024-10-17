# LumaIslandDemoCheat

BepInEx / Harmony plugin to remove the demo time limit and enable developer / cheat commands

## Features

- Removes the 5 day in-game time limit. [Preview](https://zipline.bitter.house/u/7825n9.gif)
- Enables developer / cheat commands via the console. [Preview](https://zipline.bitter.house/u/19B7Ho.gif)

## Pre-requisites

- [BepInEx](https://github.com/BepInEx/BepInEx) (tested with v5.4.23.2 Mono)

## Installation

1. Download the latest release [here](https://github.com/bitterbutt/LumaIslandDemoCheat/releases/latest)
2. Place the `LumaIslandDemoCheat.dll` file in the `BepInEx/plugins` folder of your Luma Island Demo installation directory
3. Modify the `BepInEx/config/BepInEx.cfg` file
   - Set `HideManagerGameObject` to `true` to hide the manager game object
   - Optionally set `Enabled` to `true` under the `[Logging.Console]` section to enable console logging

## Usage

- Load your save
- Press `~` (backtick) to open the console
- Enter `EnableCheats` to enable developer / cheat commands
- Enter `help` to see a list of available commands

## Commands

This list was AI generated because I'm too lazy to go through the method and pluck it all out and test it. See something inaccurate? Make a PR!

- **EnableCheats**: Enables developer / cheat commands.

- **help**: Displays a list of available commands.
- **explore**: Gives the player 100 of each of the following items:
  - **Bars**: CopperBar, IronBar, MoonstoneBar, VolcanicBar
  - **Wood**: FarmWood, ForestWood, MountainWood, JungleWood
  - **Planks**: FarmPlank, ForestPlank, MountainPlank, JunglePlank
  - **Stone**: FarmStone, ForestStone, MountainStone, JungleStone
  - **Stone Blocks**: FarmStoneBlock, ForestStoneBlock, MountainStoneBlock, JungleStoneBlock
  - **Resin**: FarmResin, ForestResin, MountainResin, JungleResin
- **freestuff**: Gives the player 100 of each of the following items:
  - **Stone**: FarmStone, ForestStone
  - **Stone Blocks**: FarmStoneBlock, ForestStoneBlock
  - **Wood**: FarmWood, ForestWood
  - **Planks**: FarmPlank, ForestPlank
  - **Bars**: CopperBar, IronBar
  - **Ores**: CopperOre, IronOre
  - **Miscellaneous**: Twigs, Hay, FernLeaf, Rope, Charcoal, Glass
  - **Fertilizers**: FarmFertilizer, ForestFertilizer
  - **Resin**: FarmResin, ForestResin
  - **Leather**: FarmLeather, ForestLeather
  - **Other**: Sand, Cotton, Fabric, Reed, FarmMushroom_01, FarmBerry_01, FarmFlower_01, SilkRope
- **alchemy**: Gives the player 100 of each of the following items:
  - **Special Mushrooms**:
    - HornOfPlentyMushroom_Special
    - PorciniMushroom_Special
    - KingOysterMushroom_Special
    - AmanitaMushroom_Special
    - ChanterelleMushroom_Special
- **begin**: Gives the player a `StoneMachete`.
- **tools**: Gives the player the following tools:
  - TinAxe
  - TinPickaxe
  - TinHoe
  - WateringCan
  - FishingRod
  - BugNet
  - TinWhip
- **coppertools**: Gives the player the following copper tools:
  - CopperAxe
  - CopperPickaxe
  - CopperHoe
  - WateringCan
  - CopperFishingRod
  - BugNet
  - CopperWhip
- **irontools**: Gives the player the following iron tools:
  - IronAxe
  - IronPickaxe
  - IronHoe
  - WateringCan
  - IronFishingRod
  - BugNet
  - IronWhip
- **moonstonetools**: Gives the player the following moonstone tools:
  - MoonstoneAxe
  - MoonstonePickaxe
  - MoonstoneHoe
  - WateringCan
  - MoonstoneFishingRod
  - BugNet
  - MoonstoneWhip
- **volcanictools**: Gives the player the following volcanic tools:
  - VolcanicAxe
  - VolcanicPickaxe
  - VolcanicHoe
  - WateringCan
  - VolcanicFishingRod
  - BugNet
  - VolcanicWhip
- **giveitem (gi)**: Grants the player a specified item.
  - _Argument_: `string[]` (item name) and `string[]` (amount)
- **takeitem (ti)**: Removes a specified item from the player’s inventory.
  - _Argument_: `string[]` (item name) and `string[]` (amount)
- **giveallitems**: Provides all available items to the player.
- **givemoney (gm)**: Adds money to the player's funds.
  - _Argument_: `string[]` (amount)
- **endday**: Ends the current day in the game.
- **unlockblueprint**: Unlocks a specific blueprint for the player.
  - _Argument_: `string[]` (blueprint name)
- **unlockrecipe**: Unlocks a specific recipe.
  - _Argument_: `string[]` (recipe name)
- **unlockall**: Unlocks all available drawings and recipes.
- **unlockalldrawings**: Unlocks all available drawings.
- **unlockallrecipes**: Unlocks all recipes for the player.
- **unlockallshopitemss**: Unlocks all shop items for the player.
- **lockrecipe**: Locks a specific recipe, preventing its use.
  - _Argument_: `string[]` (recipe name)
- **freeblueprints**: Grants access to blueprints without cost.
- **settime**: Adjusts the in-game time to a specified value.
  - _Argument_: `string[]` (time value)
- **givetokens**: Provides the player with tokens.
  - _Argument_: `string[]` (token type) and `string[]` (amount)
- **startminigame**: Begins a minigame.
  - _Argument_: `string[]` (minigame name)
- **growforest**: Causes a forest to grow in the game environment.
- **growgrass**: Causes grass to grow.
- **cleargrass**: Clears all grass in the game environment.
- **getlightamount**: Retrieves the current amount of light in the game.
- **rebakenavmesh**: Recalculates the navigation mesh for AI pathfinding.
- **listunlockedrecipes**: Lists all recipes currently unlocked by the player.
- **clear**: Clears the console log.
- **setrtpc**: Sets a specific Real-Time Parameter Control (RTPC) value.
  - _Argument_: `string[]` (RTPC name and value)
- **setglobalstate**: Sets a global state in the game.
  - _Argument_: `string[]` (state name and value)
- **getglobalstate**: Retrieves the current global state.
  - _Argument_: `string[]` (state name)
- **setplayerstate**: Sets a state or status for the player.
  - _Argument_: `string[]` (state name and value)
- **getplayerstate**: Retrieves the player's current state.
  - _Argument_: `string[]` (state name)
- **xpbomb**: Activates an XP bomb, potentially granting a large amount of XP.
- **dropxp**: Causes XP to drop as loot.
- **givexp**: Grants the player experience points (XP).
  - _Argument_: `string[]` (amount)
- **resetcaves**: Resets all caves in the game.
- **resetcave**: Resets a specific cave.
  - _Argument_: `string[]` (cave name)
- **startdanger**: Starts a dangerous event or encounter.
- **setsimulationspeed**: Adjusts the speed of the game simulation.
  - _Argument_: `string[]` (speed value)
- **setgamespeed**: Changes the overall game speed.
  - _Argument_: `string[]` (speed value)
- **freeseeds**: Provides free seeds to the player.
- **growcrops**: Causes crops to grow instantly.
- **spawnasloot**: Spawns items as loot in the game.
  - _Argument_: `string[]` (item name)
- **moneyasloot**: Spawns money as loot.
- **teleport**: Teleports the player to a specified location.
  - _Argument_: `string[]` (coordinates or location)
- **startcutscene**: Begins a cutscene.
- **godmode**: Activates god mode, making the player invincible.
- **disablegodmode**: Disables god mode.
- **addtally**: Adds a tally or count for specific in-game elements.
  - _Argument_: `string[]` (element name and count)
- **fillinventory**: Fills the player's inventory with items.
- **clearinventory**: Clears the player's inventory.
- **startquest**: Starts a new quest for the player.
  - _Argument_: `string[]` (quest name)
- **startquestlocal**: Starts a local quest.
  - _Argument_: `string[]` (quest name)
- **forcecompletetask**: Forces the completion of a task.
  - _Argument_: `string[]` (task name)
- **forcecompletetasklocal**: Forces completion of a local task.
  - _Argument_: `string[]` (task name)
- **forcecompletetrackedtask**: Forces the completion of a tracked task.
  - _Argument_: `string[]` (task name)
- **givealllumas**: Grants the player all luma-related items.
- **upgradetool**: Upgrades a specific tool for the player.
  - _Argument_: `string[]` (tool name)
- **ascendtool**: Ascends or further improves a specific tool.
  - _Argument_: `string[]` (tool name)
- **setday**: Sets the in-game day to a specific value.
  - _Argument_: `string[]` (day value)
- **hide**: Hides the UI.
- **show**: Shows the UI.
- **hidegameui**: Hides the in-game UI elements.
- **showgameui**: Displays the in-game UI elements.
- **hideworldui**: Hides the world UI elements.
- **showworldui**: Shows the world UI elements.
- **showwindow**: Shows a specific window.
  - _Argument_: `string[]` (window name)
- **hidewindow**: Hides a specific window.
  - _Argument_: `string[]` (window name)
- **coords**: Prints the player’s current coordinates.
- **next**: Advances to the next room in the temple.
- **ignorecost**: Ignores any associated cost for an action or item.
- **spider**: Spawns a spider in a cave.
- **setprof**: Sets the player's profession.
  - _Argument_: `string[]` (profession name)
- **allprofs**: Grants all professions to the player.
- **chestcheat**: Unlocks all chests.
- **resetchests**: Resets all chests in the game.
- **setcraftingspeed**: Adjusts the crafting speed.
  - _Argument_: `string[]` (speed value)
- **setcropspeed**: Adjusts the speed at which crops grow.
  - _Argument_: `string[]` (speed value)
- **spawnspider**: Spawns a spider.
- **killspiders**: Kills all spiders in the game.
- **spawnghost**: Spawns a ghost.
- **spawnblueprint**: Spawns a blueprint.
- **unstuck**: Helps the player get unstuck from a location.
- **teleporttotile**: Teleports the player to a specific tile.
  - _Argument_: `string[]` (tile coordinates)
- **bait**: Adds bait to the player's inventory.
- **printwindowstate**: Prints the current state of a window.
- **enablewindowlog**: Enables logging for window actions.
- **disablewindowlog**: Disables logging for window actions.
- **enddemo**: Ends the demo mode.
- **nuke**: Triggers a large destructive event.

## Notes

On Day 4 -> Day 5 you will still experience the camera shake "cutscene" but you won't be ejected from the demo.
The game does not save past Day 4. Still trying to patch out that logic. Use the `setday` command to revert the day.

## Disclaimer

This is my first time creating a plugin for BepInEx / Harmony, so there may be bugs or issues.
As this is for the demo, I imagine this will be obsolete once the full game is released.
