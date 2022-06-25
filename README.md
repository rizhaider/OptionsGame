# OptionsGame
Rock, Scissor, Paper game

Build for Equisoft cosing test.

The game will start with Main Menu screen having two options:

![image](https://user-images.githubusercontent.com/30207845/175783297-989a7f98-66f8-44e5-b480-68dcd450107b.png)

By pressing 'P' you will be directed to play screen having different options currently implemented:
![image](https://user-images.githubusercontent.com/30207845/175783354-3ef1d3f0-7ded-426f-8ee8-149ab51b35e4.png)

By selecting one of the options you will be asked to enter players name depending on the selection: 
Note: if 1 or 3 is seleceted you will be prompted to give only Player 1 name, in these cases other player will be the Computer.

For option 1 where you are playing with computer the first turn taken by computer is always random options and then it follows the requirement specified,
this is implemented to have a certain degree of randomization.

Option 3 is already added as an upcoming requirement.

--------------------

By pressing 'O' on the main screen, the program will take you to insert more options in the current available oprions (ROCK, SCISSOR, PAPER).
It has been implemented to dynanmically add as many options as you want by specifying the insertion index
e.g. If you want to insert flamethrower at index 3 the result will be (ROCK, SCISSOR, FLAMETHROWER, PAPER).

Note: The lower the number of index in this option list can beat higher index, e.g. in above case Scissoe will beat Flamethrower and paper 
with one exception Paper will beat Rock as standard game do.

If you want to add more Playing Option you can always add a new decorator in the Decorators folder to apply a new playing option, as I did to add Computer - Random option.
In addition to that you have to add that option in GameController to take effect as well.
Please follow RandomSelectionDecorator to add a new option.
