# Spaceship Game

## Overview
Spaceship is a simple 2D game built using MonoGame, emphasizing clean and structured C# code. The game features a player-controlled spaceship that must avoid asteroids in space. The game is designed with object-oriented principles and minimal external dependencies.

## Features
- Player-controlled spaceship movement
- Procedurally generated asteroids
- Collision detection between spaceship and asteroids
- Score tracking and game reset functionality
- Responsive controls with keyboard and gamepad support

## Requirements
- .NET SDK 6.0 or later
- MonoGame Framework (Latest Version)
- Visual Studio (Recommended) or any C# IDE

## Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/Heroftime/Spaceship.git
   ```
2. Navigate to the project directory:
   ```sh
   cd spaceship-game
   ```
3. Restore dependencies:
   ```sh
   dotnet restore
   ```
4. Build the project:
   ```sh
   dotnet build
   ```

## Running the Game
To run the game, use the following command:
```sh
dotnet run
```
Alternatively, open the project in Visual Studio and press `F5` to start debugging.

## Controls
- `Arrow Keys` / `WASD`: Move the spaceship
- `Escape`: Exit the game

## Code Structure
### `Game1.cs`
- **Initialize()**: Sets up the game window.
- **LoadContent()**: Loads textures and fonts.
- **Update()**: Handles game logic, user input, and collision detection.
- **Draw()**: Renders the game objects to the screen.

### `Ship.cs`
- Defines the spaceship's properties and movement logic.

### `Asteroid.cs`
- Handles asteroid generation, movement, and collision detection.

### `Controller.cs`
- Manages game state, including asteroid spawning and scoring.

## Assets
The game includes the following assets:
- `ship.png` (Spaceship sprite)
- `asteroid.png` (Asteroid sprite)
- `space.png` (Background image)
- `spaceFont.spritefont` (Game font)
- `timerFont.spritefont` (Timer font)

Ensure these assets are placed in the `Content` folder.

## Future Improvements
- Add power-ups to help the player survive longer.
- Implement a scoring system with a high-score tracker.
- Introduce sound effects and background music.
- Improve asteroid spawning logic for balanced difficulty.
