# 🌾 Solo Farming Game (Unity 2D Project)

A 2D farming game project made with Unity.  
Originally based on a **Udemy course** — extended with custom tools, better architecture and my own ideas.

This project serves as a learning playground and portfolio project.

---

## 🚀 Features

✅ 2D **Tilemap-based world**  
✅ Smooth **player movement** with animations  
✅ Dynamic **camera follow** with clamping to map boundaries  
✅ Collision system to prevent player leaving the map  
✅ Modular project setup    
✅ Player farming actions: till soil based on input    
✅ Tile evolution system using enums and sprite switching    
✅ Tool switching with keyboard input (Tab and number keys)    
✅ Tool selection UI with canvas, icons, and active tool indicator    

## 🌟 Personal Feature
🛠️ Advanced Pond Generator (Custom Editor Tool)    
→ Designed and implemented entirely outside the course    
→ Integrated into the Unity Editor as a custom EditorWindow    
→ Supports automatic generation of both square and circular ponds    
→ Smart placement of custom tiles (center, edges, corners)    
→ Greatly speeds up level design and iteration with the Tilemap system    

---

## 🎮 Current Progress

### Basic Game Loop

- [x] Create tilemap for the world
- [x] Add player sprite, animations, and movement
- [x] Setup camera follow and clamp system
- [x] Setup map boundaries and physics collisions

### Tools & Level Editing

- [x] Created **Pond Generator** Editor window  
    → Supports automatic square pond generation  
    → Uses custom tiles (center / sides / corners)  
    → Integrated with Tilemap system

### Player Interaction & Farming
- [x] Implement tile states (barren, ploughed) via enums
- [x] Visual feedback on soil tiles via sprite change
- [x] Player input system to plough soil on action
- [x] Good practice: actions are performed by the relevant objects themselves

### 🔜 Next Steps

- [ ] Expand Pond Generator to support **non-rectangular shapes** (Perlin noise)
- [ ] Add automatic UI Layout

- [ ] Add interactable objects: trees, rocks, and crops
- [ ] Implement seed buying/selling system
- [ ] Add planting and crop growth mechanics
- [ ] Introduce a day and time progression system
- [ ] Build a basic inventory system
- [ ] Track money and update based on sales and purchases
- [ ] Polish tool switching system and expand tool functionality
- [ ] Create UI for stats, inventory, and in-game shop
- [ ] Add main menu and audio system
- [ ] Implement tile targeting system for planting/harvesting
- [ ] Playtest and refine full game loop

---

## 🗂 Project Structure
```
Assets/
├── Editor/
│   └── PondGeneratorWindow.cs      --> Custom EditorWindow
├── Scripts/
│   ├── PlayerController.cs         --> Player movement + animation
│   ├── CameraFollow.cs             --> Camera follow + clamping
│   ├── PondGenerator.cs            --> MonoBehaviour for pond generation
│   ├── GrowBlock.cs                --> Soil tile logic and sprite evolution
│   └── ToolManager.cs              --> Tool enum and usage logic
├── Tilemaps/                       --> Tilemap layers and palettes
├── Prefabs/                        --> Reusable game objects
├── UI/                             --> Toolbar and icons
└── Scenes/                         --> Main scene
```

---

## ✨ Learning Goals

- Deepen Unity Editor knowledge (custom EditorWindows, tools)
- Practice **Tilemap-based level design**
- Master 2D player control and animation blending
- Build reusable tools for game production
- Explore Unity's UI system and input handling
- Prepare a polished project for portfolio


---

## 📚 References

- https://www.udemy.com/share/10cavl3@o5QYPtFAiATe8AxnYibETH5ecG4agFHeknewVbGhZDDphwTmkmGqeBNHeCDlk_Colg==/
- [Udemy Course - Solo Farm Game](https://www.notion.so/Solo-Farm-Game-Udemy-20e97e9c743680c0946ddc897a997de1?pvs=21)
- Personal extensions & experiments


---

## 🎨 Credits

Tiles and sprites used in this project come from free and paid asset packs used for learning purposes.

---

## 👩‍💻 About me

I’m building this project as part of my **game development learning journey**.  
This repository serves both as a training project and a showcase for future portfolio work.  
Feel free to check my profile for more Unity experiments!

---

**Unity Version:** 6000.0.50f1




