# Exercise 7 - 3D Interactive House

Itch.io link:
https://yarinkash1.itch.io/ex7

## Project Overview
This is a Unity 3D project featuring an interactive house environment with a first-person player controller, light switch mechanics, NPC interactions, and shooting gameplay.

## Assignment Sections Completed

### 1. World Building (Section 1.a)
- Built a simple 3-room house using ProBuilder
- Created walls, floors, and basic structure
- Added furniture and decorative elements
- Implemented 3D text labels on walls

### 2. Interacting with environment (Section 2.c)
- Created interaction system using raycasts
- Created NPC with collision detection
- Collision feedback: "Don't bump into me!" message appears when player collides with NPC

### 3. Enemy Interaction (Section 3.b)
- Implemented shooting mechanics with visual feedback (line renderer)
- Added crosshair UI for aiming

- Implemented health system (3 hearts)
- Added visual health display above NPC using TextMeshPro
- NPC becomes invisible when health reaches zero
- Shooting mechanics: Player can shoot NPC to reduce health

## Features

### Player Controls
- **WASD**: Move around
- **Mouse**: Look around
- **Left Click**: Shoot
- **E**: Interact with objects (light switch)
- **ESC**: Unlock cursor

### Interactive Elements
1. **Light Switch** (blue sphere)
   - Press E while looking at it to toggle room lights on/off
   - Console feedback displays light status

2. **NPC** (red cylinder)
   - Displays 3 hearts (♥♥♥) above its head
   - Can be shot 3 times before "dying"
   - Shows "Don't bump into me!" text when player collides with it
   - Becomes invisible when defeated

3. **Shooting System**
   - Cyan line shows bullet trajectory
   - Crosshair (+) in center of screen for aiming
   - Maximum range: 200 units

## Project Structure
```
Assets/
├── Scenes/
│   └── SampleScene.unity
├── Scripts/
│   ├── PlayerMovement.cs
│   ├── PlayerShooting.cs
│   ├── LightSwitch.cs
│   ├── NPCInteraction.cs
│   └── NPCHealth.cs
├── Materials/
├── Prefabs/
└── [Furniture/Props folders]
```

## Technical Implementation

### Scripts Overview
- **PlayerMovement.cs**: Handles player movement, camera control, and object interaction
- **PlayerShooting.cs**: Manages shooting mechanics and visual feedback
- **LightSwitch.cs**: Controls light toggling functionality
- **NPCInteraction.cs**: Handles collision detection and displays warning text
- **NPCHealth.cs**: Manages NPC health system and visual health display

### Key Systems
- ProBuilder for level geometry
- TextMeshPro for 3D text rendering
- Unity's Character Controller for player movement
- Raycast-based interaction system
- LineRenderer for bullet visualization
- Coroutines for timed visual effects

## Requirements
- Unity 6 (6000.2.8f1 or compatible)
- ProBuilder package
- TextMeshPro package

## How to Run
1. Clone this repository
2. Open the project in Unity 6
3. Open `SampleScene` in the Scenes folder
4. Press Play to start

## Controls Summary
| Action | Key/Button |
|--------|------------|
| Move | WASD |
| Look Around | Mouse |
| Shoot | Left Click |
| Interact | E |
| Unlock Cursor | ESC |

## Credits
Created as part of Game Development course exercise 7. 
