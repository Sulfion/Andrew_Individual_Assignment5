# Individual Assignment 5  

## <p align="center"> Quest Adventure in Beanling Town </p>  
An AI crowd interaction and YarnSpinner storyline, created for Swansea University.  
Enter the busy Beanling town of Seaswan and complete the three quests to finish the game.  

### You will encounter:  
Four NPC's, three major quests, realistic crowd interactions between the Beanlings, and more!  

Enjoy your stay.  



VIDEO GOES HERE  


#### Features:  
* Realistic crowd AI simulation of 50 Beanlings, implemented with Flocking algorithm  
* Four interactable NPC characters  
* Three major quests  
* Optional dialogue trees for accepting/rejecting quests  
* Fail-state for each quest (for example, bringing incorrect item)  
* Grabbable quest objects  
* Amusing dialogue between NPC and player  

___________________________________________  
The dialogue system is interlinked by calling/setting variables to/from C# and YarnSpinner. This allowed me to much more easily link different interactions between the NPC and Player, as well as introduce Fail-States to the quests. These fail states lead to new dialogue as well. Additionally, the dialogue can be humorous at times which can help with engagement.  
___________________________________________  
The crowd of “Beanlings” was implemented using “Flocking”, which is a theory based on three rules that govern how a crowd moves and interacts with each other. Nearby Beanlings with a common goal will group up when near each other and align themselves towards the goal. They will be steered by the centre mass of the group. Finally, they and will move around/away from their neighbours to avoid colliding (to the best of their ability).  
___________________________________________  
The goal behind the story I wanted to make was “simple, but intricately connected”, and I feel like it was mostly achieved. Complete three quests for the Beanlings is the overall purpose, and each quest has some form of interaction with each other. As an example, the Delivery quest asks you to deliver two items, but tells you that if you’ve spoken to the other two Beanlings, you should know who gets what item. A second example would be bringing an unrelated item from a different quest to a Beanling who said he didn’t like it from during his own quest, leading to a new dialogue branch.  
___________________________________________  

#### Full Build Images:  

![1](https://user-images.githubusercontent.com/115562974/206928612-dfb90dff-3a4c-47d2-bc18-c2a21822b604.jpg)
![2](https://user-images.githubusercontent.com/115562974/206928616-9432741c-1cda-4a8b-9342-bdbd281b8ee7.jpg)
![3](https://user-images.githubusercontent.com/115562974/206928618-788242f9-8789-4b1a-9869-976478890180.jpg)
![4](https://user-images.githubusercontent.com/115562974/206928619-53c7b566-9a50-41ca-88d2-bc010bc217b9.jpg)


