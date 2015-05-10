Steampunk Rochester
==================

- [Story - Writing Design](#story)
    - [Dialogue Structure](#dialogue-structure)
    - [Twine Formatting](#twine-formatting)
    - [Characters](#characters)
    - [Dialogue by Character](#dialogue-by-character)
    - [Scene Interactions](#scene-interactions)
    - [Factions](#factions)
    - [Locations](#locations)
    - [Interviews and Info by Location](#interviews-and-info-by-location)
    - [Learning about the Church of Light](#learning-about-the-church-of-light)
    - [Beliefs of Church of Light](#beliefs-of-church-of-light)
    - [World Info](#world-info)
    - [Basic Storyline](#basic-storyline)
    - [Summary(short)](#summary-short)
    - [Summary(long)](#summary-long)
    - [Endings](#endings)
- [Story Flow](#story-flow)
- [Gameplay](#gameplay)
- [Menus and Screen Flow](#menus-and-screen-flow)
- [User Interface Mockups](#user-interface-mockups)
- [Design Statements](#design-statements)
- [Art Style](#art-style)
    - [UI](#ui)
    - [Characters](#art-characters)
    - [Setting](#setting)

# Story
 
## Dialogue Structure

Players have parallel branching choices for each character
somethings you can ask everyone?
some things are specific to a character
presenting items/evidence/asking a question/starting a conversation in some way are all ways of starting a conversation
tone and the way the player says something is also important throughout a conversation
asking politely will have different effects (depending on the character) than demanding an answer
Player can also present relevant evidence/items to a character
non-relevant items can be presented but would be met with an “I have no information on this/I don’t know what this is” ???
evidence can only be presented at certain times in dialogue, typically before and after starting other parts of a conversation - the player must finished the dialogue track they started before starting another one

## Dialogue Format
itemReq-- ITEM NAME
itemGain-- ITEM NAME
itemRem-- ITEM NAME
happyUp-- CHARACTER NAME (ups the happiness of the specified character by 1)
happyDwn-- CHARACTER NAME (lowers the happiness of the specified character by 1)
happyReq-- CHARACTER NAME : HAPPY NUMBER (ranges from -10 to 10)
Speaker : Content 
[[Links|link]]

## Characters
1. Aleksei
    - Duke from Russia
    - Fled from Revolution, made Canada his new homeland
    - Very polite, but brief/privileged? sense of humor
    - Older, in his 40s/50s?
    - Egotistical, makes himself seem more important?
    - Seeking fame
    - Not a communist!!!, ran away from them!
2. Sophie
    - Peppy on the outside, distrustful, independent, manipulative but nice
    - Shapeshifter – very good at fitting herself into situations, changes over the story, provides alternate viewpoint as female in man’s world/during women's suffrage
    - “Truth seeker” – prove herself as the ultimate journalist and that she can do this job better
    - Smokes?
    - think about why she doesn’t trust people - was possibly manipulated by a prominent figure in her past, maybe a lover or caretaker, now employs similar tactics in day-to-day work
3. Kieran/nickname?
    - Sarcastic, gruff,  scruffy/dirty, Irish, generally good guy
    - seeking to get away from mafia influence?
        - pay them off, maybe become more respectable?
    - Has friends in mafia
    - Drinks? And smokes
    - Steam powered prosthetic - lost in war
    - thinks of draft as work/volunteers - hopes can get better work after
    - definitely has friends (war, drinking, siblings)
    - family guy 
4. Editor - we need a good america name XD
    - Very brief, Unforgiving?
    - Annoying (drunk) uncle type
    - Tries to hit on Suffy – (joking)
        - She uses this to her advantage?
    - Older white guy, “True blue” American
    - Hate Scruffy – tolerates because of contacts and is nice
    - Suspicious of Fluffy being a communist
5. Mason Senton, CoL leader
    - Charismatic, calm and soothing, in control
    - Health nut
    - used to be a conman - maybe he still is
    - truly believes in the Church’s ideas of well-being (was always a health nut) but not really in the glowing water being sacred or any better for people
    - started the church as a con, but due to the beliefs of other members he wants to make the religion legitimate
    - but does he have an ulterior motive in money? Yes, a little for sure, but how much more?  
6. Jetpack Chemist
    - Model after Sylvester Roper?
    - Sterling Roper?, Dr?
    - steam related research/inventions (steam jetpack)
    - bookish? Typically quiet? …
    - INFO
        - Bring the glowing water
        - Tells you it glows, that there is some foreign entity in it? Can’t identify?
        - Need ideas for answer
    - CONTACT?: Fluffy (friends?)
    - CoL follower 1
    - CoL follower 2…
    - Glowing water salesman - says he’s with CoL
    - fast talking? maybe lies about affiliation? Some third party(didn’t mean to resolve that just replay lol)
    - looks fancy
    - always there the first time, otherwise only there at certain times

## DIALOGUE:
- Matty - Party Host
    - Generic: FINISHED
- Editor (no name)
    - Intro: FINISHED
    - Generic: WIP(Bryce)
        - (ask general questions, can show evidence so far for hints to next steps?)
- Evelyn Foreman - Salesman(guy)
    - First: FINISHED
    - Generic: WIP(Ian)
        - (confront about this is only option next time talk to after finding out his pin is fake - so what’s his real affiliation?)
        - sort of spills his life story before you can stop him, used to be a con man/worked with a con man that is described just like Senton
- Mason Senton - CoL Leader
    - Park, First: FINISHED
    - Park, Generic: FINISHED
    - Confrontation: FINISHED
        - talk to him in private elsewhere, and he confesses he was a conman and did found the church for profit, but since then, has actually come to enjoy the organization and while doesn’t believe in god, did find he liked the people and the life style
    - and can confirm he his buying from both mafia’s here is already know
- Bartender (no name, doesn’t need one?)
    - Generic: FINISHED
- Tim White - CoL Member 
    - Generic at Park: FINISHED
        - there everyday during a CoL meeting, general questions for them, they Chave some miracle story about the glowing water
    - Generic at Bar: FINISHED
        - goes to bar one night a week, get’s marginally drunk, will talk to you, but you need to buy him a round or two more before he starts saying how no one ever heard of Senton before this and it’s rumored how before, he did x, y, and z…(maybe he is a conman)
        - also mention that Senton is only at the park on Saturday mornings
- Ziccardi Mafia Guy (Quincy?/no name)
    - Generic: BROOKE (low priority)
        - one time encounter(only on a Thursday), catch in passing as making a delivery of crates, doesn’t tell you much, but bumps into you, get’s your attention, kind of sketch…
- Chemist (not a priority)
    - Generic at Lab/RAMI?: OPEN (low priority)

## SCENE INTERACTIONS:

Player interacting with/examining an object. Formatting in Twine(First title is still “0”):
  
This is a test item.(no speaker)
  
[[Examine|Examine]] (and/or other interactions listed here))
  
[[Take|Take]] (not all items will need this)
  
[[Leave|Leave]]

- Party
    - Examine Pin: FINISHED
    - Glowing Wine: FINISHED
    - other items? Can the player look at their inventory and do we need specific stuff here?
- Canal
    - canal water: FINISHED
    - glowing water: FINISHED
    - old empty bottles: FINISHED
    - Salesman’s CoL Pin: FINISHED
    - salesman’s wares: OPEN(Ian?)
        - generally his visible wares: glowing water in jars, glowing soap, other strange things that glow...
- Park, no CoL Meeting
    - small stage: FINISHED
- Park, During CoL Meeting, Not Thursday
    - small stage: FINISHED
- Park, During CoL Meeting, Thursday
    - small stage: FINISHED
- Bar 
    - alcoholic beverage: FINISHED

## Factions
- Mafia - two families
    - Ziccardi - larger, older, more cautious
        - run alcohol, prostitution rings, gambling
        - compete with Mercurio family in alcohol and in attempting to take over black market prosthetics
    - Mercurio - newer, more aggressive
- Church of Light - aspiring religion centered around healthy living
- Suffragists - pro-women’s rights, against the mafia/alcohol
    - lots of rumors about what the feminists are doing
        - about dumping chemicals in the water
        
## Locations
1. High Society Location/Mansion? – talking to people in his element, learns about the water for the first time
2. Canal Area – water glowing(Y/N?), arrives on a nice boat or steam-car?
    - talk to a Church of Light character somewhere?
3. RAMI lab – get water sample tested
    - crazy-ish scientist
4. Park - Initiated during the church meeting? Near the canal?, very nice
    - sermon/mass location that can be revisited daily to hear diff things, maybe get hints
    - talk to people here who tell you about excommunicated people?
    - Squirrel with cheese in an apple tree in the background!! #designteam
5. CoL Pastor/organizer offices(leader’s mansion, not real office)
    - learn incriminating evidence?
6. Editors office – could be an interactive cut scene, could be a mini level where can talk to Suffy and Scruffy and Editor and check the map?
    - game map is map on wall, with notes and string and pictures and newspaper clippings…
        - evolves over time - previously collected information is stored on the map for player to review
    - group meetings happen here in scene
7. Speakeasy
    - bartender - ask about any rumors and he says “Why the hell do people keep asking me that?”

## Interviews and Info by Location
### Can always ask people about what they think the glowing water is
- High Society
    - Interviews
        - someone familiar/friend of a friend 
            - glowing water from canal, supposed to purify you
            - maybe they sort of believe in the water, have a drink of their own
        - more disillusioned person
            - talks about the wonderful properties of the water from the canal?
    - Physical(observable to player?) Evidence
        - glowing alcohol? in glasses, offered by a server at this party
            - ask someone about it?
        - some sort of pin/medallion/brooches with a strange symbol
- Canal Area
    - Interviews
        - glowing water salesman
            - claims to be part of CoL “Light Samuel”
            - buy some glowing water
                - can ask if it is alcohol, be blunt, be pushy, buddy buddy(sneaky)
                - if sneaky about it, will confess there is some alcohol in it
                    - alcohol is suspicious
            - if you ask him about CoL
                - directs you to park gatherings if want more info
            - come back a second time(after you know he isn’t part of CoL)
                - ask where he gets the alcohol
                    - learn about mafia connection
                - confront about the fake CoL symbol?
    - Physical(observable to player?) Evidence
        - the salesman’s jars of water
            - some are alcohol (buyable?)
            - some are for lights (buyable)
            - has a similar but not identical CoL pin (fake)
        - canal water
- RAMI lab
    - Interviews
        - chemist
            - ask him about the glowing water
            - ask about CoL
            - if you have water sample, can give it to him
                - need to give him time to test it?
    - Physical(observable to player?) Evidence
        - jetpack
            - chemist rants to you about it
            - mentions testing it in the middle of this rant, and needing special chemical fuel to use it
- Park
    - Around noon every day, CoL mass
        - stretching, seminars on healthy living, drink water
        - random CoL members in attendance, maybe day specific
            - talk to them about glowing water, why they use it/what they believe
                - realist opinions, opinions that make it sound like magic, etc.
                - why is it healthy? who says it is good for you
                    - some say leader told them so
                    - some anecdotes about people being able to see better, looking younger, that kind of thing
                        - be able to talk to one of these people, directed to specific day at the park or somewhere
            - one will tell you about seeing a guy from the Mafia(unknown family) visit every Wednesday at mass
        - Physical(observable to player?) Evidence
            - CoL crest/symbol on a podium/mini stage, on posters 
            - pick up a poster
            - CoL pamphlet - healthy living tips, Jesus, and glowing water
            - glowing water
    - Saturday, they have extended mass(all day), Ziccardi shipment
        - stretching, seminars on healthy living, drink water
        - CoL leader in attendance
            - ask about water/beliefs/stuff
            - confront about conman past (if found out)
                - blows you off, changes subject 
                    - calls you drunk? has someone send you home
                - if you persist he won’t talk to you the rest of that day?
        - members
        - Physical(observable to player?) Evidence
            - CoL crest/symbol on a podium/mini stage, on posters 
            - pick up a poster
            - CoL pamphlet - healthy living tips, Jesus, and glowing water
            - glowing water
            - suspicious glowing water crates (Ziccardi markers or something)
    - Wednesday, Mercurio shipment in addition to mass
        - Mafia guy hanging in the back
        - Physical(observable to player?) Evidence
            - suspicious glowing water crates (Mercurio markers or something)
- CoL offices - at leader guys “mansion”
    - if you attend 3+ CoL masses, then they will let you in 
    - Interviews
        - leader
            - confront about conman past 
                - whether he started the cult for the right reasons or not, now he really does care
                - doesn’t matter if this cult’s beliefs are wrong or not since helping people - say anything about him in the paper, but don’t hurt his people
    - Physical(observable to player?) Evidence
        - orders from Mafia
        - diary with daily routine showing he IS a crazy health nut
- Obligatory Speakeasy - Ziccardi Speakeasy 
    - Mafia people, bartender with trivia (not really useful)
        - specific characters on specific days
        - on a specific day, excommunicated CoL member shows up - excommunicated because of “loss of faith” or something
            - past history on CoL leader - some kind of con artist? or at least used to be
    - Physical(observable to player?) Evidence
        - maybe see same suspicious crates in back, with Mercurio markers 
        - different kinds of glowing alcohol

## Learning about the Church of Light
- Learn/memorize the code of conduct or something? 
- Learn other bits about the faith, why the symbol is what it is, 
- As you learn more, can use that information to pass persuades/information checks with members to get more information or access to another location?
- Learn the church wine is supplied by the mafia
    - mafia making the water glow to fuel industry for cult OR mafia taking advantage of cult?
    - buying from both mafias
- CoL leader used to be a conman
- Use glowing water to light places

## Beliefs of Church of Light
- Better Mind, Better Body - holistic understanding of person
- Drink glowing water a lot
- Emphasis on diet - low fat, whole-grains, fiber, 
- less emphasis on enemas/clearing of the bowels as healing, sunbaths, encourage least sex possible
- Drink alcohol sometimes(with glowing water) – like church wine
	- want to be recognized as an official church so can use alcohol without having to smuggle it in
- Special glowing water bath – use like a baptism or an extreme purification for members who have not been so pure recently
- Seeks longevity through the water and healthy living
- Can always become more pure – seek the ultimate level of Purity
    - Surge(wave) of Light – end event once all people reach “Purity” that leads everyone to immortality or something – Nirvana?
- Follows call each other Lights (either just in general or replacing their last name with “Light”
    - Brother and sister lights if don’t know name
    - Nightlights – recruiters – go out to those who don’t believe and bring them back
    - Maybe
- Church gatherings, they do yoga
- sect of christian church(Adventism-ish)

## World Info
steam jet pack (prototype)
glowing water in jars to serve as lanterns/nightlights/regular lights
collected and used by poor people?
last about a week
glowing water comes more frequently in this world (couple times a month)
 
## Storyline:

- Overall
    - Learn about the glowing water at the party
    - go to investigate the water
    - assigned to team at newspaper
    - told to investigate the CoL more
    - go to a gathering, ask about people
    - investigate upper offices maybe
    - Turning point somewhere in the game that changes up what is going on/perspective?
    - presented with choice to take story for yourself
    - continue to collect info
    - eventually write the full report

Otherwise, presented more on a scene by scene basis, since locations are not in a precise chronological order

## Summary Short
There is something in the water. Prosperity has not washed over everyone equally. The lower classes, at the risk of the unknown effects of the water, use it to light their homes while a high society cult has formed around assumed holistic properties of the glowing water. The Church of Light, as they are called, hold health-centric gatherings in parks and spike their glowing water with alcohol smuggled in from the organized crime families, while trying to get permission to buy their wine legally from the government. But the mafia isn’t a cohesive unit. Two families are locked in a power struggle to determine who really owns the city. The conniving suffragists contribute to the rumors of unrest, but know nothing about the militant members of their sect. Unknown to the outside world, a factory has been dumping chemical waste into the river and one of these more aggressive members may have had a part in the spread of the glowing water.

## Summary Long
	
1920s. Rochester, New York. There is something in the water. Prosperity has not washed over everyone equally. The lower classes, risking the unknown effects of the water, use it to light their homes while a high society cult has formed around assumed holistic properties of the glowing water. The Church of Light, as they are called, hold health-centric gatherings in parks and spike their glowing water with alcohol smuggled in from the organized crime families, while trying to get permission to buy their wine legally from the government. But the mafia isn’t a cohesive unit. Two families are locked in a power struggle to determine who really owns the city. The conniving suffragists contribute to the rumors of unrest, but know nothing about the militant members of their sect. Unknown to the outside world, a factory has been dumping chemical waste into the river and one of these more aggressive members may have had a part in the spread of the glowing water.

Three journalists are assigned the task of finding the true origin of the glowing water. Sophie is a female journalist in a field that is predominantly male, and while being extremely capable, faces discrimination every day in the field. She trusts no one, but has an inner need to find the truth. Peter is a Duke who fled his native Russia during the Russian Revolution, and continues to be a part of high society with his now-meaningless title and journalistic aptitude. The loss of the majority of his relations and his exile have made him jaded, but he still retains his royal dignity. Seán is an Irishman struggling to free himself of his Mafia ties. His prosthetic arm cost him far more than he could muster, leaving him indebted to the Mafia and desperately trying to make ends meet. On the outside, he appears gruff and sarcastic, but the reality is that he is far more kind-hearted than the majority of the city. They are all in competition to write the article that exposes the origins of the glowing water, but trade information and help each other in order to get the most complete stories possible.

The Church of Light is a cult built around the glowing water. They believe that the glowing water is representative of a holistic purity they strive for, and they constantly strive to become more “pure.” Besides rituals involving the glowing water, they encourage a wide range of healthful exercises and activities. However, they are still not accepted as a proper religion, garnering a lot of suspicion because of the continued spread of the glowing water, which everyone suspects they have a major part in. 

The Mafia is divided between two families the Ziccardis and the Mercurios. The Ziccardis have been around Rochester for a longer time than the Mercurios, and are a larger, more cautious family. They mainly focus on illegal speakeasies, prostitution rings, and gambling, but are branching out to take over the Mercurios’ prosthetic trade. On the other hand, the Mercurios are a newer, more aggressive family in the city. They control the black market prosthetic trade, and also a significant portion of the speakeasies. The conflict between them is expected to turn bloody sometime soon, and everybody silently holds their breath, preparing for the worst.

The Suffragists, having gained the vote for women fairly recently, now focus on women’s rights and squashing the illegal consumption of alcohol. Many of them are lower class workers, filling out a large portion of the factory staff in the area. Their positions bring them in conflict with the Mafia families all the time, but no violent altercations between the two have taken place yet. While not particularly aggressive overall, certain members are very militant, trying to evoke radical change through radical means. There have been mysterious fire bombings and sabotage incidents attributed to these members, but there is no direct proof of their misdeeds.

The player will control one of the journalists every day (for the prototype, only one journalist will be available) and try to find information to write their article. Different events happen on each day at different times, and the player can attend these events to gather information from evidence or from interviews. Some of these pieces of informations will unlock other information or events at different locations. There will be specific story events that happen immediately after gathering certain bits of information that progress the plot and change the situation (like, for example, a Mafia rampage that may make certain informants unavailable and unlock new physical evidence). Main gameplay will be basically a point-and-click adventure, with the player clicking on things to collect information or talk to people.

## Endings:
- CoL
    - water is placebo effect - just microscopic particles?
    - water is good, makes people healthy
- Mafia
    - Mafia is manipulating glowing water for profit, adding alcohol
    - Mafia is trying to help out with glowing water, by cleaning the canal
    - regardless of ending, the mafia probably profit off of selling glowing alcohol to CoL
- Suffragists
    - rumors they dumped something for multiple reasons
    - to deter mafia, because they want more respect
    - boston tea party with chemicals? (dumped something 
    - whatever happened, it backfired
- Other
    - Factory dumping chemical waste into canal that causes it to glow
    - Mafia was hired by the Chemist to mix chemical concoction into the canal makes the water glow, but the main purpose is to create a more efficient fuel source for his jet pack.
    - he has determined it has no adverse effects on humans physically
    - The Suffragists hired the Chemist to make some kind of chemical to help them. The Mafia found out, stole all the chemicals and dumped it into the canal. This caused the water to glow, and a few people who drank it were affected mentally and started their own cult revolved around the glowing water called “The Church of Light”. The Mafia learned of this, and began to use the glowing water to profit off of the CoL.

# Story Flow
- Party
    - Who: Matty
    - What: Sets up the world, establishes who you are, introduces the glowing water plot
    - When: Night

- Canal
    - Who: Evelyn
    - What: More information about the glowing water, you obtain water and fake pin
    - When: Night

- Editor’s Office
    - Who: Editor
    - What: Call to action, you are given the assignment of finding out about the glowing water
    - When: Morning

- Park
    - Who: Tim White
    - What: Sets up the next meeting with him at the bar, gives you business card
    - When:  Morning/Afternoon
    - Who: Senton
    - What: CoL Info, accuse him here, Mansion Flag (opens talking to him at the mansion)
    - When: Morning/Afternoon

- Bar
    - Who: Tim White
    - What:Gives you info about the Church of Light and Senton, DOG FLAG
    - When: Night

- Mansion
    - Who: Senton
    - What: Accuse Senton, ACCUSE FLAG
    - When: Night

- Endings:
    1. Water is good
    2. Water is placebo
    3. Church of Light is poisoning the water supply

if(accuse Senton)
  
	Ending 3
  
else if(Find out about Tim White’s Dog)
  
	Ending 1
  
else
  
	Ending 2

- Flags
    1.Dog flag - TimWhiteBar - AskDog
    2.

- Paths:

    - Party -> Canal -> Editor’s Office -> Park, Bar, or Mansion (Open Ended)

        - The party MUST be the first location, followed by the canal and editor’s office.
        - After the editor’s office, the player has a choice of where to go. 
        - You talk to Tim White and Senton at the park. Tim White is basically just used for information at this location. Senton, however, will open up the Mansion to investigation/interrogation as opposed to just an empty scene.
        - Mansion can can be accessed anytime after the initial three scenes, but cannot really do anything until Senton is there at night.
        - Going to the bar at night you will find Tim White. If you give him enough drinks he will then tell you about his past life more (And his dog which will flag one of the endings) as well as the past life of the CoL leader. 
        - At the mansion the player will be able to accuse Senton of his past actions which will trigger another ending. This ending will overwrite the other two endings if triggered.
        - After the day ends the player will be sent to a final ending scene at the editors office and receive and ending based on what they did in the game. 


## Gameplay

The game will take place over the course of a few days (3-5), with a set number of hours within that day for you to investigate. Throughout the day, different people will be in different places. For example, in the morning the suffragettes might be having a meeting in the park, while at night the mafia might be stirring up trouble. A big part of this game will be time management. Different actions such as travelling and talking take up different amounts of time, and you must use your time wisely in order to get the most out of your day.

One of the main screens of the game is the map screen. Here you can see the current time, your current location, different locations, and where the other journalists are. This should look like a map that might be posted in the newspaper headquarters, with pins marking different locations and strings marking paths in between (and perhaps photo-like pictures pinned to show who is where).

When you go to a location, you use time to travel. To start, when you get to a location a screen will open with you having a conversation with another character. Our goal is to later have a single environment screen that has different objects to click on and investigate as well as people to talk to, which would open up an overlay of the aforementioned conversation screen.

We have decided it would be good to play the story straight as far as the feel of the game goes. Humor can be present, but the game is not a comedy game. It is an investigation and time management roleplay. We also decided that the steampunk aspect should be present.

The three characters have nicknames: Suffy (the suffragette flapper woman in a man's world), Scruffy (the Irish vet with mafia ties due to his steam prosthetic), and Fluffy (the pulitzer prize-wannabe Russian journalist whose important family fled to America during the Bolshevik revolution). The player chooses one character to play as through the game. Although having all three available one day would be nice, we've decided that starting with Fluffy as the only character available to play is best (though the others will still be present in the story).

As far as the factions go, the mafia is really two in one: the Ziccardis and the Merrcurios. This faction therefore has high tension, and they're very dark and dangerous. They are pro drinking and could have problems with the suffragettes. The suffragettes are half "puritanical perfect picket fence" women and half flappers. While there might be some tension there, it's negligible. They are against drinking and are anti-mafia. The Church of Light is still up in the air. We know that they're definitely going to be a crazy cult... it's just a matter of how. We will discuss further.

While publishing a small story at the end of every day that would have an effect on the following days would be nice, it's a stretch goal and not to be worried about currently.

Different conversation choices you make throughout the game award points. Each conversation has a final weighted score based on good/bad decisions and comments (you may make people so mad at you that they no longer want to talk to you, which has more of an effect past the score). Your final score for the game is made by adding up these weighted scores. Between each section of conversation you are given the option to present evidence.

# Menus and Game Flow

- Start Screen
    - Play the Game
    - Credits
    - Quit
- Map
    - Clickable locations
- Scene
    - Interactable People and Items
- Conversation
    - Dialogues
    - Choices
- Present Evidence
    - All items currently in your inventory
- Inventory
    - All items currently in your inventory
- Pause
    - Inventory
    - Quit
    - Resume

# User Interface Mockups

## Design 1
![](http://imgur.com/a/2ehTi#eFxjqoQ)
![](http://imgur.com/a/2ehTi#fJfbZD1)
![](http://imgur.com/a/2ehTi#QFrirzy)
![](http://imgur.com/a/2ehTi#wfZhBCd)
![](http://imgur.com/a/2ehTi#6tfeLLm)

## Design 2
![](http://imgur.com/a/S6Lpr#xdtxx4P)
![](http://imgur.com/a/S6Lpr#OjVJ4K8)
![](http://imgur.com/a/S6Lpr#w1OUrt4)
![](http://imgur.com/a/S6Lpr#a4Juqcu)
![](http://imgur.com/a/S6Lpr#Eo9uj2k)

# Design Statements

As a <user role>, I want <goal> so that [reason].
  
As a journalist, I want a story so that I can win a Pulitzer Prize (to gain respect/money).
  
As a member of the Church of Light, I want to drink glowing water so that others can see how awesome it is (or see the light).
  
As the leader of the Church of Light, I want to lead my people to a better life/take advantage of them for my gain/use them as a distraction for more nefarious deeds/be ambiguous about my true goals and leave the player to decide my true intentions.
  
As a newspaper editor, I want a story that will entice readers yet is somewhat relevant. PAAAARRRRRKKKEEEER!!!
  
As a player, I want to have a conversation. Jackie go away <3
  
As an investigator, I want to find evidence so that I can present it to others for information.
  
As an npc, I want to have a purpose in the story (unless you die in the first 5 minutes).
  
As a mafia man, I want to put a horse head in somebody’s bed, and make offers that you can’t refuse.
  
As Fluffy, I want to write a good story to earn prestige and further my title.
  
As Suffy, I want to earn the respect that male journalists have and be treated as an equal.
  
As Suffy, I want to get to the bottom of this story and find out the truth.
  
As Scruffy, I want redemption from my past deeds, and to earn the respect that no one seems to give me. And also to get hammered in a bar, alone, late at night, stereotypes be damned.
  
As a player, I want to know when I can meet other NPCs in the game so I don’t miss important information.
  
As a player, I want a clear and concise map to show me where I can go in this world.
  
As a user, I want to see what time of day it is.
  
As a developer, I want progression in day/night cycle for limiting the time a player can meet with an NPC.
  
As a player, I want to review previous conversations. 
  
As a player, I want to see all the pieces of evidence I picked up in the game so I have direction on where to go if I forget. 
  
As a player, I want to see multiperson interviews because I would feel more engaged in conversation that isn’t just in between me and one NPC.
  
As a player, I want to have a general understanding of my dialogue choices.
  
As a player, I want to see the news story based off my gameplay choices.  
  
As a player, I want to know what I can interact with!
  
As a player, I want the ability to load, save, quit, change resolution and such. 
  
As a player, AJ wants to know how many possible endings there are. lol (INFINITE ENDINGS!!! But seriously, at least two per character and/or faction fully implemented)
  
As a player, I want more than one save slots because I want to possibly try different dialogue choices throughout my playthroughs. 
  
As a user, I want a clear and responsive UI so I can understand what the hell is going on. 
  
As a user I want the game to run on multiple platforms, windows, mac, linux.
  
As a developer I need more coffee.
  
As a user I want customizable hats. Hat Simulator 2015™.
  
As a 2-user I both want and don't want ukuleles (chip-tune ukuleles).
  
As a user I want to understand what NPC’s emotions are via facial expressions. 
  
As a funny player, I want occasional humorous choices and proper responses to such. (what about a drunk mechanic for when Fluffy drinks too much vodka? He just starts asking really silly or weird questions, like “Can you tell me why your church is a duck?”)
  
As a player, I want to interact with a wide variety of characters.
  
As a player, I want to hear ambient music when I am in places. 
  
As a player, I want a compelling soundtrack (20s chip-tune Jazz ukulele)

# Art Style

## UI

The refined look that is a bit run down I think covers a lot of bases. It’s a more typical steampunk feel, which I don’t think is a bad thing. I’d rather the ui look more “natural” to the theme and something else in the gameplay be diff/interesting
 
These have a nice amount of polish/metal

This one is a bit darker/heavier. I especially like the angle and deterioration

## Art Characters

Love the almost stained glass/broken feel. The sketchiness maybe even more so? This for character close ups, maybe models depending on how we set up the game

I really love the sketchiness they have here, not sure how much character realism we want to go with

 
## Setting

Mostly the faded part. I support using actual Rochester images to base buildings and setting on, I also love the widespread decay that isn’t overly heavy but it there for sure. Upper class might be able to pretend nothing is broken

Silhouettes are very pretty, but depends on where we want to go in game. I also love the gears and rough style of the pieces

And maybe a bit of fog and gloom. Love the trees

I really like all of this one except for the lightness. Maybe the game gets progressively darker or something. Anyway, sketch and water color?

