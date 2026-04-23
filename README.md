# Tic-Tac-Toe (Unity)

## Overview

This project is a Unity-based Tic-Tac-Toe game developed as a technical assignment.  
It is a local multiplayer game designed for two players on a single device and supports both Portrait and Landscape orientations.

The project focuses on gameplay functionality, UI structure, state persistence, and clean code organization.

---

## Features

### Main Menu (Play Scene)
- Play button with theme selection popup and game start
- Statistics popup displaying:
  - Total games played
  - Wins for Player 1 and Player 2
  - Number of draws
  - Average game duration
- Settings popup with toggles for:
  - Background music (BGM)
  - Sound effects (SFX)
- Exit button with confirmation popup

### Game Scene
- 3x3 Tic-Tac-Toe grid
- Turn-based local multiplayer (X and O)
- Win detection with strike animation
- Draw detection
- HUD displaying:
  - Match duration
  - Move count per player
- Settings access from HUD
- Game over popup with:
  - Result display
  - Match duration
  - Retry and Exit options

---

## Popups
- Theme selection popup (Main Menu)
- Statistics popup (Main Menu)
- Exit confirmation popup (Main Menu)
- Settings popup (accessible from both scenes)
- Game result popup (Game Scene)

---

## Audio
- Background music (BGM)
- Button click sound effects
- Piece placement sound effects
- Win/strike sound effects
- Popup animation sound effects

---

## Persistence
Game statistics are saved between sessions and include:
- Total games played
- Wins per player
- Draw count
- Average game duration

---

## Project Structure

The project is organized inside the standard Unity structure:
- Assets
- ProjectSettings
- Packages

All game logic is located under the Assets/Scripts directory.
