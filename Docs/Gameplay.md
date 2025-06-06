# 🎮 Gameplay Documentation — *Codename: Alien*

This document outlines the core gameplay mechanics and systems implemented in *Codename: Alien*, a sci-fi platformer where the player controls a stranded alien navigating a hostile, oxygen-rich planet.

---

## 👽 Player Overview

The player assumes the role of an alien lifeform whose spaceship has crash-landed on an unfamiliar planet. To survive and escape, the alien must collect vital resources and avoid a variety of environmental and biological hazards.

---

## 🕹️ Player Controls

| Action        | Input (Default)        |
|---------------|------------------------|
| Move Left     | A / Left Arrow         |
| Move Right    | D / Right Arrow        |
| Jump          | W / Up Arrow           |
| Crouch        | S / Down Arrow         |
| Next Dialogue | Enter / Touch          |
| Pause         | P / (||) UI Button     |

---

## 🧬 Core Mechanics

### 🔹 Movement
- The player can run left and right, jump over gaps, crouch to avoid obstacles, and move through narrow passages.
- The movement is responsive and designed for precision platforming.

### 🔹 Resource Collection

#### 🌟 Luminex
- A mysterious energy resource found in glowing crystals.
- Used to sustain life temporarily in this planet.

#### 🛠️ Ship Parts
- Scattered across levels.
- All must be collected to initiate the final ship repair and escape sequence.
- Often found in high-risk zones or behind puzzles/hazards.

### 🔹 Breathing System
- The alien's species breathes **phosphine gas (PH₃)**.
- **Oxygen**, while abundant on the planet, is **toxic** to them.
- Exposure to oxygen reduces health over time

> This mechanic creates urgency and affects exploration pacing.

---

## 🐜 Enemies

### Types of Insects:
1. **Ground Insect**: Move on Ground in Left/Right direction, damage on contact.
2. **Flying Insect**: Flying enemies that Move in Up/Down Direction, damage on contact.
3. **Spike Insect** : Similar to Ground Insect but can't be defeated by Player due to presence of spike.
4. **Bullit Insect**: Similar to Ground Insect but shoots bullits
5. **Stomp Guy**    : a Mechanical Robot Which Crush you if not crouched nearby
6. **Boss Guy**     : a More Powerful Version of Stomp Guy (Not Implemented Yet)

- Enemies can be:
  - Defeated by jumping on them
  - Avoided or dodged using crouch/movement

---

## ☠️ Hazards & Obstacles

- **Spikes**: Instant damage on contact.
- **Dead End**: cross safely, if fell then dead.
- **Gravity Switch**: Make Player Upside Down and reverses it's gravity

---

## 🎯 Objectives

1. **Survive the environment** by avoiding hazards and enemies.
2. **Collect all essential ship parts** to repair the crashed spacecraft.
3. **Escape the planet** before you run out of Luminex Resources and Lives.

---

## 🔄 Progression System

- Levels may become more complex as the game progresses.
- Later stages introduce:
  - Advanced enemy types
  - Platforming challenges
  - Limited access to Luminex, forcing strategic resource use

---

## 🧪 Current Status

> Many of the core mechanics listed above are either implemented or under prototyping. This document will be updated alongside the game's development.

---

*Last updated: 2025-06-07*
