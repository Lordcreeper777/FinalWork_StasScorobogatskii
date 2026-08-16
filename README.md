# Final Work - Stas Scorobogatskii

This repository contains my final project for the Bachelor's program at Erasmushogeschool Brussel, Campus Kaai.

The project is a 2D Unity game in which the player explores the environment, interacts with characters and objects, collects a key, and progresses through the level.

The game combines 2D platforming, NPC interaction, animated cutscenes, sound effects, post-processing and controller support.

## Features

- 2D player movement and jumping
- Keyboard and mouse support
- Controller support
- NPC dialogue and interaction
- Key pickup system
- Gate unlocking system
- Death and respawn system
- In-game cutscene
- Start menu
- Controls menu
- Pause menu
- UI hover animations and sound effects
- Walking, jumping and death sounds
- Post-processing and visual effects
- Scene transitions

## Controls

### Keyboard and Mouse

| Action             | Control             |
| ------------------ | ------------------- |
| Move               | A / D or Arrow Keys |
| Jump               | Space               |
| Interact with lock | Mouse Click         |
| Pause / Resume     | Escape              |
| Navigate menus     | Mouse               |

### Controller

| Action                   | Control    |
| ------------------------ | ---------- |
| Move                     | Left Stick |
| Navigate menus           | Left Stick |
| Jump                     | X / Cross  |
| Confirm menu selection   | X / Cross  |
| Interact with NPC / Lock | Circle     |

## How to Run

### Requirements

- Unity Hub
- Unity 2022.3.17f1
- Git
- Git LFS

It is recommended to use **Unity 2022.3.17f1** to avoid compatibility problems.

### Setup

1. Clone the repository:

```bash
git clone https://github.com/Lordcreeper777/FinalWork_StasScorobogatskii.git
```

2. Open Unity Hub.

3. Click **Add > Add project from disk**.

4. Select the `FinalWork_clean` project folder.

5. Open the project using **Unity 2022.3.17f1**.

6. Open the `StartScreen` scene from the `Assets/Scenes` folder.

7. Press **Play** to start the game.

The active development branch is:

```text
master
```

If Unity asks to open the project with another version, select Unity 2022.3.17f1.
The game should be started from the `StartScreen` scene to test the full game flow.

## How to Develop

### Prerequisites

- Unity 2022.3.17f1
- Git
- Git LFS
- Basic knowledge of C#
- Basic knowledge of Unity

### Development Setup

1. Clone the repository.
2. Open the project through Unity Hub.
3. Make sure you are working on the `master` branch.
4. Open the required scene from `Assets/Scenes`.
5. Make your changes.
6. Test the changes in Unity Play Mode.
7. Commit and push the changes to GitHub.

Git LFS is used for larger files such as `.mp4` cutscene videos.

After installing Git LFS, run:

```bash
git lfs install
```

## Testing

Before committing changes, test the game in Unity Play Mode.

Important systems to test include:

- Player movement
- Jumping
- Keyboard controls
- Controller controls
- Menu navigation
- Pause and resume
- Key pickup
- NPC interaction
- Cutscene playback
- Gate unlocking
- Death and respawn
- Audio
- Scene transitions

It is recommended to test the complete game starting from the `StartScreen` scene instead of starting directly from a gameplay scene.

## Folder Structure

- `Assets/` - Contains the main game assets.
  - `Animations/` - Animations used in the game.
  - `Audio/` - Music and sound effects.
  - `Scenes/` - Unity scenes.
  - `Scripts/` - C# game logic.
  - `Video/` - Video files used for cutscenes.
  - Other folders contain sprites, materials, UI elements and visual effects.
- `Packages/` - Unity package information.
- `ProjectSettings/` - Unity project settings.

Unity automatically generates folders such as:

```text
Library/
Temp/
Logs/
Obj/
UserSettings/
```

These folders should not be committed to GitHub.

## Main Systems

The project includes several gameplay systems implemented in C#, including:

- Player movement and jumping
- Player audio
- NPC dialogue and interaction
- Key pickup and gate unlocking
- Death and respawn
- Pause menu
- Controller support
- UI hover and button effects
- Scene transitions
- In-game cutscene playback

## Git

The project uses Git and GitHub for version control.

Repository:

```text
https://github.com/Lordcreeper777/FinalWork_StasScorobogatskii
```

Main branch:

```text
master
```

Git LFS is used for large files such as `.mp4` videos.

## Sources

The following official documentation was used during the development of this project.

### Unity

- [Unity Input Manager](https://docs.unity3d.com/2022.3/Documentation/Manual/class-InputManager.html)  
  Used for keyboard and controller input configuration.

- [Unity Input.GetAxisRaw](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/Input.GetAxisRaw.html)  
  Used for player movement and controller movement input.

- [Unity Event System](https://docs.unity3d.com/2022.3/Documentation/Manual/EventSystem.html)  
  Used for UI interaction and menu navigation.

- [Unity Standalone Input Module](https://docs.unity3d.com/2022.3/Documentation/Manual/script-StandaloneInputModule.html)  
  Used for controller navigation, Submit input and menu interaction.

- [Unity Supported Events](https://docs.unity3d.com/2022.3/Documentation/Manual/SupportedEvents.html)  
  Used for pointer hover, controller selection, deselection and submit events.

- [Unity Rigidbody2D](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/Rigidbody2D.html)  
  Used for 2D player movement and physics.

- [Unity AudioSource](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/AudioSource.html)  
  Used for player, UI and gameplay audio.

- [Unity AudioSource.PlayOneShot](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/AudioSource.PlayOneShot.html)  
  Used for jump, death and UI sound effects.

- [Unity Video Player](https://docs.unity3d.com/2022.3/Documentation/Manual/class-VideoPlayer.html)  
  Used for the NPC rescue cutscene.

- [Unity VideoPlayer API](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/Video.VideoPlayer.html)  
  Used for controlling the cutscene through C#.

- [Unity RenderTexture](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/RenderTexture.html)  
  Used to display the video cutscene inside the gameplay UI.

- [Unity SceneManager.LoadScene](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/SceneManagement.SceneManager.LoadScene.html)  
  Used for transitions between game scenes.

- [Unity Time and Frame Management](https://docs.unity3d.com/2022.3/Documentation/Manual/TimeFrameManagement.html)  
  Used for the pause and resume system.

- [Unity Raycasters](https://docs.unity3d.com/2022.3/Documentation/Manual/Raycasters.html)  
  Used when configuring UI interaction and fixing UI elements that blocked mouse input.

### GitHub

- [GitHub - About Git Large File Storage](https://docs.github.com/en/repositories/working-with-files/managing-large-files/about-git-large-file-storage)  
  Used to configure Git LFS for large `.mp4` cutscene files.

- [GitHub - Collaboration with Git Large File Storage](https://docs.github.com/en/repositories/working-with-files/managing-large-files/collaboration-with-git-large-file-storage)  
  Used for cloning and sharing the project with Git LFS files.

The project was developed using **Unity 2022.3.17f1**.

For installation and basic development instructions, see the sections above in this README.

## Tutorials

The following tutorials were useful as additional references during development:

- [Brackeys - 2D Movement in Unity](https://www.youtube.com/watch?v=dwcT-Dch0bA)  
  Useful for understanding 2D player movement and jumping.

- [Brackeys - PAUSE MENU in Unity](https://www.youtube.com/watch?v=JivuXdrIHK0)  
   creating a pause menu using `Time.timeScale` and UI buttons.

- [Brackeys - How to make a 2D Platformer: Audio Manager](https://www.youtube.com/watch?v=HhFKtiRd0qI)  
   understanding how to organize and play sound effects in a 2D Unity game.

- [Brackeys - AUDIO in Unity](https://www.youtube.com/watch?v=6OT43pvUyfY)  
  Useful for working with Audio Sources, Audio Clips and gameplay sound effects.

- [Brackeys - How to Fade Between Scenes in Unity](https://www.youtube.com/results?search_query=Brackeys+How+to+Fade+Between+Scenes+in+Unity)  
  used as a reference for fade transitions between scenes.

- [Code Monkey - How to use NEW Input System Package!](https://www.youtube.com/watch?v=Yjee_e4fICc)  
  Used as an additional reference for understanding keyboard, mouse and gamepad input in Unity.

- [Code Monkey - Learn Unity Beginner/Intermediate 2023](https://www.youtube.com/watch?v=AmGSEH7QcDg)  
  Used as a general Unity reference for systems such as character controllers, interactions, sound effects, menus, pausing and controller menu navigation. The course specifically includes sections on sound effects, pause systems and controller/menu navigation. :contentReference[oaicite:4]{index=4}

- [Tarodev - Ultimate 2D Platformer Controller in Unity](https://www.youtube.com/watch?v=3sWTzMsmdx8)  
  Used as an additional reference for 2D platformer movement and improving player controller behaviour.

## AI Usage

ChatGPT was used during development as an additional tool for debugging, troubleshooting and exploring possible solutions to technical problems.

One example involved debugging a UI issue where the Pause button stopped receiving mouse input because a fullscreen visual effect was blocking UI raycasts.

The related conversation can be viewed here:

- [ChatGPT - Debugging the Pause Button UI Issue](https://chatgpt.com/share/6a820af6-6e10-83eb-bc3d-d6da23ca7d28)
  AI-generated suggestions were tested and adapted to fit the requirements of the project.

- [ChatGPT - Debugging Audio Between Scenes](https://chatgpt.com/share/6a820c19-96ec-83eb-82e3-2e0347253524)
  AI-generated suggestions were tested and adapted to fit the requirements of the project.

## License

This project was developed by **Stas Scorobogatskii**.

Copyright (c) 2026 Stas Scorobogatskii

This project is licensed under the **MIT License**.
