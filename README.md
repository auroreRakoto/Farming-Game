# 🌾 Solo Farming Game (Unity 2D Project)

A 2D farming game project made with Unity.  
Originally based on a **Udemy course** — extended with custom tools (Editor scripts), better architecture and my own ideas.

This project serves as a learning playground and portfolio project.

---

## 🚀 Features

✅ 2D **Tilemap-based world**  
✅ Smooth **player movement** with animations  
✅ Dynamic **camera follow** with clamping to map boundaries  
✅ Collision system to prevent player leaving the map  
✅ **Pond Generator** Editor tool (automatically create ponds in tilemap)  
✅ Modular project setup

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

### Next Steps

- [ ] Add interactable objects (trees, crops, rocks)
- [ ] Implement basic inventory system
- [ ] Add UI for player stats
- [ ] Expand Pond Generator to support **non-rectangular shapes** (Perlin noise)
- [ ] Polish player controls (diagonal movement smoothing, fine-tune animations)

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
├── Tilemaps/                       --> Tilemap layers and palettes
├── Prefabs/                        --> Reusable game objects
└── Scenes/                         --> Main scene
```

---

## ✨ Learning Goals

- Deepen Unity Editor knowledge (custom EditorWindows, tools)
- Practice **Tilemap-based level design**
- Master 2D player control and animation blending
- Build reusable tools for game production
- Prepare a polished project for portfolio

---

## 📚 References

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




