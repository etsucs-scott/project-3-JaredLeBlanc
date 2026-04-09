# Minesweeper Console Game

A console-based Minesweeper game in C# with deterministic mine placement, multiple board sizes, cascading reveals, and high score persistence.

---

## Build & Run

```bash
git clone https://github.com/etsucs-scott/project-3-JaredLeBlanc.git
cd project-3
dotnet build
dotnet run --project src/Minesweeper.Console
```
Controls
```
Command	Description
r row col	Reveal the tile at (row, col)
f row col	Flag or unflag the tile at (row, col)
q	Quit the current game

Note: Rows and columns are 0-indexed.
```
Legend
```
Symbol	Meaning
#	Hidden tile
f	Flagged tile
b	Bomb (revealed when hit)
.	Empty revealed tile
1-8	Number of adjacent mines
```
Board Example
```
Menu: 
1) 8x8
2) 12x12
3) 16x16
Seed (blank = time): 12345

Commands: r row col | f row col | q

  0 1 2 3 4 5 6 7
0 # # # # # # # #
1 # # # # # # # #
2 # # # # # # # #
3 # # # # # # # #
4 # # # # # # # #
5 # # # # # # # #
6 # # # # # # # #
7 # # # # # # # #

> r 2 3
  0 1 2 3 4 5 6 7
0 # # # # # # # #
1 # # # # # # # #
2 # # 1 2 # # # #
3 # # . . 4 # # #
4 # # . . . # # #
5 # # # # # # # #
6 # # # # # # # #
7 # # # # # # # #
```
Win/Lose Conditions
```
Win: All non-mine tiles are revealed.
Lose: Revealed a mine tile.
```
Seed Usage
```
Prompted for a seed (integer) at game start.
Leaving blank generates a seed from current time.
Seed determines mine placement for reproducible games.
```
High Scores
```
Fastest completion time wins.
Tie-breaker: fewer moves.
Stores top 5 scores per board size.
Saved in data/highscores.csv (CSV format):
size,seconds,moves,seed,timestamp
8x8,45,12,12345,2026-04-08T14:23:10Z
```
UML Diagram
```
File: Documents/Minesweeper_UML.png

Diagram shows:

All core classes (GameApp, Renderer, InputHandler, ICommands,
RevealCommand, FlagCommand, Game, Board, Tile, RevealService,
WinChecker, AdjacencyCalculator, MineGenerator, HighScore,
HighScoreManager, HighScoreRepository, CsvParser)

Relationships: composition, usage, and implementation

Key fields/properties and methods
```
Git Usage Notes
```
Clone:
git clone https://github.com/etsucs-scott/project-3-USER.git
Build:
dotnet build
Run:
dotnet run --project src/Minesweeper.Console
```
Unit Tests
```
Run unit tests using xUnit:
dotnet test
```
Tests cover
```
Board generation
Adjacency calculations
Cascade reveal
Win/Loss rules
High score persistence
```
