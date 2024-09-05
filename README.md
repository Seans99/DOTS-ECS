# DOTS-ECS
School assignment

This Unity DOTS system efficiently manages player movement, bullet firing, and spawning using a data-oriented approach. Key features include:

- Data Management 
Uses Entities, Components, and Systems to keep data and behavior separate, which boosts performance.

- Burst Compiler 
Speeds up calculations by optimizing code with Burst, especially for tasks like moving players and bullets.

- Jobs System 
Allows parallel processing, so things like player movement happen faster and more smoothly.

- EntityCommandBuffer 
Groups entity changes together for better performance, used when firing bullets and resetting input.

Process:

The main goal was to build a high performance system in Unity using DOTS for smooth player movement, efficient bullet firing, and effective spawning.

I used Unity's Entity Component System (ECS) to organize data into entities and components, which helps the system process everything quickly.

The Burst Compiler was applied to speed up important calculations for movement and firing.

I also used the Jobs System to run tasks in parallel, which greatly improved how quickly I could update player and bullet positions.

Reflection:

Separating data and behavior with ECS helped manage complex interactions and keep performance high.

Using Burst and Jobs early on gave a big boost in performance and prevented slowdowns.