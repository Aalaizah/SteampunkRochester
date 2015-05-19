Codename:

Steampunk Rochester

A Technical Document

Authors/ Programming Team:
Tyler Gerber, Tim Steen, Joseph Coppola, Natasha Martinez, AJ Mandula



#Table Of Contents

Table Of Contents

Overview

Level Structure

Scene or Prefab

System Manager

Background “Bg”

Parser

Map

Time/Emotion/Inventory Managers

UI

Paradigm

Dialogue Screen and DialogueComponent.cs

#Overview

The steampunk rochester project is an on-going project to combine rich history from 1920’s rochester with open source game development. The idea was to make an adventure game where players visit different areas of Rochester, trying to solve the mystery of glowing water in the downtown canal.

#Level Structure
##Scene vs. Prefab
When discussing our options for levels we saw two primary choices. 

Create a new scene and fill it with level content, then either change the scene or use the additive option to create a popup for the level. 
Create prefabs that could be instantiated and limit the usage of scenes. 

We quickly prototyped the prefab technique and ran with it but each technique has its downsides.

##System Manager
Every level has a few dependendencies; 

- A twine importer (to read files and store dialogue), 
- A test manager (to leave conversation and return to map),
- A TimeManager (to change and track time), 
- An emotion manger (to change and track emotions), and 
- An Inventory (to store items). 

We place these inside of a GameObject called “SystemManager”. We only need to place one of these in the main map scene and it will stick around for all levels. We attempted to use static classes but they operated unusually in Unity.

There is also a class called ObjectFinder which can find these components, and if they don’t exist it will create them.
##Background “Bg” Images
Backgrounds are images named “Bg” so that we can find them easily in code. We use Transform.FindChild(...) to make sure that we get the right “Bg”. This is used for the Scrolling Camera.
##Scrolling Camera
The scrolling camera is an orthogonal camera with variable size. It finds the “Bg” background and tries to set boundaries. It also finds two children called “arrowLeft” and “arrowRight” which light up when you scroll left and right. 

All logic is with ScrollCamBhv and all mouse input is in ScrollCamCtrl this separation resembles Model-View-Controller but this pattern should not be pursued. All C# classes are Mono-Behaviours capable of being model, view (OnGUI), or controller. A different pattern may be preferrable.
##Core and Interactable.cs
A core is a prefab and Interactable is its corresponding script, the two names will be used interchangeably. Together they make the “Core System”. This system is used to add interactivity and dialogue to the levels. A core contains an interactable component and and has a sprite representing a clickable zone. The interactable component updates, waits for input, and hides the core sprite depending on if the user hovers over. The contents of the interactable class have a lot of functionality which you can learn more about in the Characters and Items section just below. A feature of the “Core System” which we have yet to implement is a “Detective Mode” which would visually reveal all cores in the scene. This can be done simply by check for Input.IsKeyDown(...) in Interactable’s update function, but the implementation is open to discussion.
##Characters and Items
Both characters and items are sprites with a core prefab as a child. This parent child structure is essential to the functionality of the core.

Once a sprite has a core attached you can begin editing the core to make it into a character or an item. Setting what twine file to load, what time of day it appears in, its position/location/rotation, and even where on the interactable players must click to activate the core. (To do this move and resize the core object itself)

#Parser

The parser is in the Twine Node class, in the overload of the constructor that takes both a string and a string array. There are many command flags from the text file that are parsed in this method that were added in order to allow for a variety of things to occur when a player reaches a certain node of a conversation such as gaining an item, flagging an ending, requiring an item or the player to have a certain relationship with the player. 

Following the format of the previous command flags, it is very easy to add new ones. Any attributes should be private and there should be a respective getter or setter (mostly getters). The parser will also grab different parts of a twine node such as the title, the content, the speaker, the links and obviously the command flags (added in for this project).

#Map

The map is the interface through which the player travels throughout Rochester. It is designed to be a map of rochester with thumbtacks indicating each available location. When players click the thumbtack it should display the travel time to reach the destination, as well as display a preview of what the location looks like. 

We also wanted to achieve a 3D effect, the result being a slightly tilted perspective. To achieve this we used Unity’s canvas, with a mix of canvas elements and unity sprites, with a perspective camera.

#Time/Emotion/Inventory Managers

The time, emotion, and inventory managers are all their own separate classes. 

The emotion and inventory have their own collection(s) in order to preserve the data of the items the player receives or the relationship between the player and the NPCs. Both of these are dynamically added to in such a way that if a new item or new NPC is added to the game, there will not need to be any changes to these structures. The emotion and inventory managers have their own functions for accessing and modifying values in the collections. 

The time manager just has a couple of integers and strings in order to preserve what time of day it is. The integers get changed every time a player moves into a new area (aside from the first few areas at the beginning) and when the player talks to the character (30 and 60 minutes respectively). The time manager also takes care of showing a “watch” to the player that has the current time in a watch format every time the player does something that progresses time forwards.
#UI

##Paradigm
Our canvas UI uses panels to create adaptive UI, using Min and Max in RectTransform we can set percentages that will stretch to match different resolutions. Inside these panels we place other panels, text, and images.
##Dialogue Screen and DialogueComponent.cs
The DialogueScreen is a canvas prefab with 3 main panels; 

- ScreenPanel, 
- ScreenSafePanel and 
- CharacterNamePanel. 

ScreenPanel is stretched 100% to fill the screen. ScreenSafePanel is has 5% padding around the edges, this is so that we keep our UI within a comfortable range for different monitors and devices. In this panel we place our main character “Aleksei” and the character/item he is interacting with. Then we have our CharacterNamePanel which uses 15% of the upper screen safe area. Inside we have panels with text for our characters.

The DialogueComponent script is the code side of the dialogue. It is attached to the DialogueScreen and we create a new DialogueScreen when we click a core. The component is responsible for reading the twine file of the core, using OnGUI to draw conversation and options, loading the interactables image into the dialogue screen as well as its name, and all interactions with items and inventory. It is where majority of the gameplay occurs as this is an investigative game.
##Time UI
The TimeUI, also referred to as Watch, uses panels there is one Watch placed in the map scene. It has one important panel, TimeDisplay, which contains an image WatchFace which preserves aspect ratio, which contains a text label called TimeKeeper for displaying the time.

TimeManager handles all the logic for the TimeUI, whenever time passes it will show the watch and start a countdown before hiding it again. The alpha of the watch is updated as the countdown progress to create a wavering fade effect (mostly through Mathf.Sin(...)).

##Map UI

The Map UI as stated earlier uses Unity's 4.6.1 canvas system to render all UI elements to the screen. The markers on the map are button objects that when clicked bring up an info window that details the area. Each marker has a marker behavior script that helps dictate what level is to be loaded. To hook up a new marker is fairly simple. Just change the button's image to the pin and its highlighted sprite to the highlighted sprite you desire. Then throw on a marker behavior script, give it a level to load in the Unity editor. Then you must take the marker button you just created, and drag the button from the hierarchy into the button's onClick() event handler and then set the button's onClick() event to the marker behavior script's method called ClickAction(). This user interface also uses the color of the camera background to help convey the time of day, as well as having a panel in the bottom right that is updated by the TimeManager. Lastly we have the pause button that puts the game into a paused state, when in reality it is simply disabling the map UI an enabling the pause UI. 

##Pause UI

The pause UI is simply a prefab object that allows for a few basic interactions with the game. The user can resume, which destroys the pause UI and reactivates the map UI. The user can go to the inventory page to see what they have collected throughout their journeys in Steampunk Rochester. Lastly we have the quit button, which exits the game. All these buttons are on the prefab, and work via the UI Manager.
