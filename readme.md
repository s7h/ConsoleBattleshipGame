# Console Battleship Game

Yet another just for fun project with 2D arrays. 

<img src="http://i65.tinypic.com/11lq7v6.jpg" />

# About the game

This is just another version of the classic battleship board game. Originally played with paper and pencil and dates back to World War I. 

The objective of the game is to identify the location of various ships each player has placed on their battlefield grid. The grid contains cells and each player calls out column and row coordinates on the other player's grid in an attempt to identify and destroy their ships. 

## Setting up the game

Each player gets a JSON setup file. The file is used to setup the ships on the battlefield. Each player gets 5 types of ships and also gets to setup their alias.

The ships can either be aligned VERTICALLY or HORIZONTALLY. They cannot overlap or can go out of the grid.

### Types of ships 

 - CARRIER, size 5 cells
 - BATTLESHIP, size 4 cells
 - CRUISER, size 3 cells
 - SUBMARINE, size 3 cells
 - DESTROYER, size 2 cells

## Gameplay

Players take turn to fire missiles on enemy's battlefield. Players do it by entering 2-digit coordinates on the screen. 

On your turn, type in two numbers that identifies a row and column on your target grid. The code checks that coordinate on his battlefield and responds "miss" if there is no ship there, or "hit" if you have correctly guessed a space that is occupied by one of his ships.

The first player to sink all five of his opponent's ships wins the game.

## Reading battlefield coordinates

Battlefield coordinates can be identified by two digits X and Y. X represents a number from 0-9 listed in the blue squares vertically and Y represents a number listed in the blue square horizontally. 

Type both of this numbers together without a space. Typing any other number that is outside the range (00 - 99) or letters will result in error and you have to input the coordinates again.

![Sample Battlefiled](http://i67.tinypic.com/zjfayv.png)

Each players battlefield at the beginning of the game will be masked by **[~~~]**. When player hits a ship the value will changes to **[XXX]**. And if there is a miss the value will be **[/M/]** .
### Battlefield at the beginning of the game

![Empty Battlefield](http://i67.tinypic.com/15duzo7.png)

### In case of a HIT and a MISS
![Hit and Miss](http://i68.tinypic.com/34ysj2o.png)

#### ASCII art generated from [Patorjk](http://patorjk.com/software/taag/#p=display&f=Graffiti&t=Type%20Something%20)

