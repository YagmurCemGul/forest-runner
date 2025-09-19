<img width="1472" height="704" alt="Forest Runner" src="https://github.com/user-attachments/assets/df813d28-a228-45cd-9e8d-80bddd38d9b5" />

<h1 align="center">Forest Runner — Unity 2D Project</h1>

<p align="center">
  Endless-style forest runner focused on tight 2D controls, smooth parallax, and collectible loops.
</p>

<p align="center">
  <a href="https://unity.com/releases/lts"><img alt="Unity 2021.3 LTS+" src="https://img.shields.io/badge/Unity-2021.3+_LTS-black?logo=unity"></a>
  <img alt="Pipeline: 2D Renderer" src="https://img.shields.io/badge/Render-2D_Renderer-6aa84f">
  <img alt="Input: Keyboard" src="https://img.shields.io/badge/Input-Keyboard-blue">
  <img alt="TextMeshPro" src="https://img.shields.io/badge/TextMeshPro-✔-informational">
  <img alt="License" src="https://img.shields.io/badge/license-TBD-lightgrey">
</p>

<p align="center">
  <a href="#-demo--downloads">Demo</a> •
  <a href="#-about-the-project">About</a> •
  <a href="#-game-features">Features</a> •
  <a href="#-technologies-used">Tech</a> •
  <a href="#-getting-started">Setup</a> •
  <a href="#-controls">Controls</a> •
  <a href="#-project-structure">Structure</a> •
  <a href="#-development-workflow">Workflow</a> •
  <a href="#-performance-checklist-2d">Perf</a> •
  <a href="#-testing">Tests</a> •
  <a href="#-git-lfs--repo-hygiene">LFS</a> •
  <a href="#-screenshots--media">Media</a> •
  <a href="#-troubleshooting">Troubleshooting</a> •
  <a href="#-roadmap">Roadmap</a> •
  <a href="#-asset-credits">Credits</a> •
  <a href="#-contributing">Contributing</a> •
  <a href="#-license">License</a>
</p>

---

## 🎮 Demo & Downloads

* **Latest build (Releases):** *Add link after first release*
* **Itch.io page (optional):** *Add if hosted*
* **Short gameplay video:** *Embed a YouTube link*

---

## 📖 About the Project

A 2D forest runner where the player collects diamonds while traversing parallaxed scenes. Built to practice **movement/physics**, **collection loops**, **UI with TextMeshPro**, and **audio** basics.

---

## 🌟 Game Features

* **2D platform loop:** run, jump, collect, progress
* **Character animations:** running, jumping, idle
* **Collectibles system:** diamonds/coins with score feedback
* **Parallax backgrounds:** multi-layer depth for motion richness
* **SFX:** pickup/jump/ambient cues
* **Level transition:** next level loader / restart flow

---

## 🛠️ Technologies Used

* **Unity Engine** — 2D development (2021.3 LTS+)
* **C#** — gameplay scripting
* **TextMeshPro** — crisp UI text
* **(Optional)** 2D Renderer / Sprite Atlas for batching

---

## 📁 Project Structure

```
Assets/
├── Audio/           # Audio files
├── Fonts/           # Font files
├── Prefabs/         # Reusable gameplay/UI objects
├── Scenes/          # Game scenes (Level_01, Level_02, ...)
├── Script/          # C# scripts
├── Textures/        # Sprites, tiles, backgrounds
└── TextMesh Pro/    # TMP essentials
```

---

## 🧩 Main Scripts

* `CharacterController.cs` — horizontal move + jump (+ coyote/buffer ready)
* `Coin.cs` — collectible logic + score event
* `LevelRestart.cs` — restart/reset flows
* `NextLevel.cs` — transition to next scene / finish line

> *Tip:* Consider extracting a `ScoreManager` and `GameEvents` to decouple UI from pickups.

---

## 🚀 Getting Started

1. **Open in Unity Hub** → Unity **2021.3 LTS** (or newer)
2. **Load Scene** → `Assets/Scenes/Level_01.unity` (or `SampleScene`)
3. **Press Play** → run & collect

### Build

1. `File → Build Settings`
2. Add active scene(s) to **Scenes in Build**
3. Target **macOS/Windows/Linux**
4. **Build and Run**

---

## 🎮 Controls

| Input             | Action           |
| ----------------- | ---------------- |
| `A / D` or Arrows | Move Left/Right  |
| `Space`           | Jump             |
| `Esc`             | Pause (optional) |

---

## 🧪 Testing

Use **Unity Test Runner** (EditMode/PlayMode) with **NUnit**.

```text
Assets/Tests/
├─ EditMode/
│  └─ CollectibleTests.cs
└─ PlayMode/
   └─ MovementSmokeTests.cs
```

*Sample NUnit (EditMode)*

```csharp
using NUnit.Framework;
public class MathSmokeTest {
  [Test] public void Addition_Works() => Assert.AreEqual(4, 2 + 2);
}
```

---

## 🔁 Development Workflow

* **Tight loop:** iterate in a single small scene; keep Console clean
* **Animation:** use Animator with blend or simple state switches
* **UI:** TMP + a lightweight `HUDController` (score, lives)
* **Audio:** centralize via `AudioManager`, avoid per-frame `PlayOneShot` spam
* **Scenes:** keep Level\_01 minimal for performance tests

---

## ⚡ Performance Checklist (2D)

* **Sprite Atlas** enabled → reduce draw calls
* **Sprite Import**: correct pixels per unit, compression, filter mode
* **Parallax**: limit layers; avoid excessive full-screen alpha overlap
* **Physics2D**: sane layer collision matrix; fixed timestep defaults are fine
* **Pooling**: for repeated pickups or effects (particles)
* **GC**: avoid per-frame allocations in Update; cache refs
* **Camera**: clamp orthographic size; pixel-perfect cameras if style requires

---

## 📦 Git LFS & Repo Hygiene

* Install LFS (first time): `git lfs install`
* Track heavy assets (example):

  ```
  git lfs track "*.png" "*.psd" "*.jpg" "*.wav" "*.mp3" "*.mp4" "*.ttf" "*.fbx" "*.anim" "*.prefab" "*.unity"
  ```
* Commit `.gitattributes`
* `.gitignore` essentials:

  ```
  [Ll]ibrary/
  [Tt]emp/
  [Oo]bj/
  [Bb]uild*/ 
  [Ll]ogs/
  *.csproj
  *.sln
  *.user
  ```

---

## 🖼️ Screenshots & Media

* Add GIFs from gameplay (`/Docs/media/`)
* Top banner (above) already embedded — add more: HUD, parallax, level end

---

## 🧰 Troubleshooting

1. **Sprites pink?** Reimport textures / check 2D Renderer setup
2. **Jump feels floaty?** Tune gravity scale & jump impulse
3. **Parallax jitter?** Match movement updates to camera step; avoid large textures scrolling every frame
4. **Build size high?** Compress textures/audio; remove unused assets
5. **Input not working?** Verify Input settings and bindings

---

## 🗺️ Roadmap

* [ ] Mobile controls (touch joystick / swipe)
* [ ] Hazards & checkpoints
* [ ] Power-ups (double jump, dash)
* [ ] Endless mode + score persistence
* [ ] Basic save/settings (volume, SFX, language)

---

## 🎨 Asset Credits

* Sprites / backgrounds: *Add sources or “original”*
* SFX: *Add source (e.g., freesound.org) or “original”*
* Fonts: *List license & link*

> Please ensure licenses allow distribution in this repo/build.

---

## 🤝 Contributing

PRs welcome!

* Keep scenes/assets tidy, follow folder structure
* Prefer small, focused PRs with a brief demo clip/gif
* Mark starter tasks with `good first issue`

---

## 📄 License

**TBD** — choose MIT/Apache-2.0 if open-sourcing, or leave as educational only.

---

### Metadata

**Developer:** Yağmur Cem Gül
**Project Date:** 2025
**Unity Version:** 2021.3+
