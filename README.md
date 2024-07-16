# Asteroids

## Description
A standard clone of the well-known game [Asteroids](https://en.wikipedia.org/wiki/Asteroids_(video_game)).  
Rules are simple - get as many points as possible by destroying asteroids and UFOs, while avoiding collisions with them.  
There are three types of enemies:
- `Asteroid` - appears at the edges of the screen, moves in a random direction;
- `Asteroid fragment` - appears when an asteroid is destroyed, moves in a random direction;
- `UFO` - appears at the edges of the screen, moves towards the player;

The player's movement is implemented with acceleration and inertia.  
The screen doesn't restrict movement, because it's a portal (for both the player and the asteroids).  

The player has two types of weapons:
- `Bullets` - destroy themselves and the enemy upon contact, bullets are destroyed at the edges of the screen;
- `Laser` - works for a limited time and has a limited number of charges that regenerate over time, it destroys all enemies it intersects with during its activation;

The game ends if the player collides with an enemy.  

## Showcase
![](https://github.com/Bdiebeak/Asteroids/blob/main/GitDescription/Asteroids-Showcase.gif)  

## Controls
`W` / `Up Arrow` - move forward;  
`A`, `D` / `Left Arrow`, `Right Arrow` - rotate;  
`Space` / `J` - shoot bullets;  
`Alt` / `K` - shoot laser;  


# Modules
The project is divided into 3 main modules, all of them are described in details below.  
Each module contains an `Assembly Definition`, which allows clearer dependency management between modules, improves compilation time, and gives other advantages from using them.  
The `DI` and `ECS` modules were written by myself from scratch, as this project is a test task and the use of third-party frameworks was forbidden.  

## Core
The main game logic module.  
Contains the implementation of the main application logic - components, systems, services, infrastructure and etc.  

## DI
Dependency Injection module.  
To work with dependencies in the project, I implemented a custom `DI container` with constructor and method injection using attributes.  
The container has fairly simple functionality, extended for more convenient work in `Unity` using methods located in a child `asmdef`.  

## ECS
Entity Component System module.  
A simple ECS was created primarily to use its architecture rather than its other advantages.  
This ECS implementation isn't production-ready and has its disadvantages. I mainly used it for its architecture and didn't focus on optimization, cause I don't want to spend time reinventing the whell at this moment.  
There are a lot of existing solutions.

# Architecture

## Entry Point
The entry point of the project is an object with the `GameRunner` class.  
This class is where the first code is called, which is responsible for creating the container and initial work with the game's state machine. It connects the user cycle with Unity's main loop through the lifecycle of `MonoBehaviour`.  
I didn't add additional scenes, because there is no need here.  

## State Machine
To manage the game, several main states were implemented: `BootstrapState`, `GameStartState`, `GameLoopState`, `GameOverState`, `RestartState`.  
The state machine switches between states depending on the current game stage. Each state is responsible for a specific stage of the gameplay, which simplifies debugging and modification.  
![](https://github.com/Bdiebeak/Asteroids/blob/main/GitDescription/StateMachineLoop.png)

## Services
A separate architecture layer was implemented in the project to work with the necessary services.  
This separation makes the architecture more modular and maintainable, with clear division of responsibilities. With the proper implementation, we can easily replace service implementations when necessary.  
You can find the services used in the project [here](https://github.com/Bdiebeak/Asteroids/tree/main/Assets/Asteroids/Scripts/Core/Utilities/Services), including services for working with resources, configurations, and more.  

## DI
To work with dependencies in the project, standard Unity methods are used:
- Required services are registered in the container and dependencies are obtained through automatic constructor injection;
- `MonoBehaviour` classes implement an additional `Construct` method with the `[Inject]` attribute;
- Factories are implemented using the container - `SystemFactory`, `GameFactory` and etc.

## ECS
ECS is divided into contexts - `InputContext` and `GameplayContext`.  
Each game functionality is separated into its own [feature](https://github.com/Bdiebeak/Asteroids/tree/main/Assets/Asteroids/Scripts/Core/Game/Features) - `MovementFeature`, `DestroyFeature` and etc.  

### Views
The following classes were created for displaying entities in the Unity world:
- `EntityView` - a view to which the entity is attached.
- `EcsListener` - a class that updates the view, such as [TransformListener](https://github.com/Bdiebeak/Asteroids/blob/main/Assets/Asteroids/Scripts/Core/Game/Features/Movement/Listeners/TransformListener.cs).  
For optimization, an object pool for views was implemented.  

### Unity
Unity's physics is not used for movement, as this was one of the requirements. Unity's physics is only used for collision handling in the `ECS` world.  
This is implemented using the [CollisionEventProvider](https://github.com/Bdiebeak/Asteroids/blob/main/Assets/Asteroids/Scripts/Core/Game/Features/Collision/CollisionEventProvider.cs), which is a `MonoBehaviour` that creates collision events in the `ECS` world. This approach makes it easy to replace the physics engine if needed.  
Additionally, you may notice the use of classes from `UnityEngine` within systems. These are primarily objects like `Vector2` and etc., which can also be easily replaced if necessary.  

## UI
Work with user interface is implemented in a manner similar to `MV*`.  
There is a screen and a screen model on which the data in the `View` is based.  
In a more complex implementation, you could add reactivity for automatic data updates in the `View`, but there is no need in this behavior here.  
