# A* Navigation Pathfinding

## Overview

The Pathfinding Navigation Package is a Unity package designed to provide A* pathfinding and ready-to-use scripts for agent navigation. It supports both 2D and 3D (with some restrictions) environments and includes features such as public parameters and callbacks for movement start and end events.

## Important

This package was first developed for a project in which a 3D object moves on a 2D Tilemap. The Tilemap is on the ground and the object moves in the X and Z axis. In this project, an intermediate script sends the start position, end position and a list of obstacle positions for the package to get the best path.

This package ignores one of the 3D axes. Because it uses a two-axis grid pathfinding algorithm, it does not generate a path for all three axes.
This package uses Vector2Int and Vector3Int for locomotion.
This package was developed in version 2021.3.x.

## Getting Started

### Installation

1. Download the package and import it into your Unity project through the link:
- https://github.com/Jvramiro/Astar-Navigation.git
2. Ensure that no errors occur for reasons of incompatibility.

### Usage

#### Basic Usage

You can add an Agent directly to the object you are going to move.

You can edit the parameters of your Agent, such as speed and rotation speed.

You must, through your script, call the Setup function with the starting position and destination of the movement. The starting position is an optional parameter; if you don't add it, it searches for the current position of the object.

You can use your script to subscribe to the OnMovementStart, OnMovementStop and OnAgentReached events.

#### Ideal Usage

This project is designed to create and customize your own Agent class by inheriting the AStarAgent Abstract Class.

You can read the AStarAgent2D and AStarAgent3D scripts and create your own Agent and move your object in the way that best suits your project.

Through your custom class you can decide whether to use other components to improve its locomotion, for example rigidbody.

#### Examples

The package includes example scenes and scripts for both 2D and 3D agents located in the `Samples` directory.

## License

This package is licensed under the [MIT License](LICENSE).

---
