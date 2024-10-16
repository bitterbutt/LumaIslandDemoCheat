# LumaIslandDemoCheat

BepInEx / Harmony plugin to remove the demo time limit and enable developer / cheat commands

## Features

- Removes the 5 day in-game time limit
- Enables developer / cheat commands via the console

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

Too many to list, use `help` and see for yourself

## Notes

This is my first time creating a plugin for BepInEx / Harmony, so there may be bugs or issues.
As this is for the demo, I imagine this will be obsolete once the full game is released.
