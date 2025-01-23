using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Linq;



class Program {
  static int hitdie = 8;
  public static Random rand = new Random();
  static int coins = 0;
  static double exp = 0;
  static int level = 1;
  static int oldMmod;

  public static int option, storyblock, intelligence = 10, strength = 10, immunity = 10, wisdom = 10, agility = 10, charisma = 10, Imod, Smod, Mmod, Wmod, Amod, Cmod, herohealth;
  static string heroclass = "None", herorace = "None";
  static List<int> statchoices = new List<int>();
  static List<int> healthrolls = new List<int>();
  static List<int> abilities = new List<int> {1,2,3};
  public static int enemyHP;
  
   public static string[] inventory = {"potions","magic leaves","water bottles", "towels"};
  public static int[] itemCounts = {2,3,6,8};
  
  public static void Main (){
    
    healthrolls.Add(hitdie);
    runStory(0);
  }

  static void runStory(double block){
    switch(block){
      case 0:
        Stats();
        RaceChoose();
        break;
      case 1:
        MineWakeUp();
        break;
      case 1.1:
        Quota300();
        break;
      case 1.2:
        mineDay2();
        break;
      case 2:
        MineFallAsleep();
        break;
      case 2.1:
        MineExploreHalls();
        break;
      case 2.11:
        CaughtByGuard(false);
        break;
      case 2.12:
        CaughtByGuard(true);
        break;
      case 3:
        Prison();
        break;
      case 3.1:
        DigWalls();
        break;
      case 3.2:
        EscapeAsGuard();
        break;
      case 3.21:
        PoisonGuard();
        break;
      case -1:
        //OldManStory();
        break;
    }
  }
  
  static void Stats(){
    clear();
    
    WriteLine("To choose your stats, you get six random numbers to choose from, and each stat can have one of those numbers.");
    WriteLine("Your numbers are:");
    for(int i = 0; i < 6; i++){
      int num1 = roll(6);
      int num2 = roll(6);
      int num3 = roll(6);
      int num4 = roll(6);
      statchoices.Add(num1+num2+num3+num4-Math.Min(Math.Min(num1,num2), Math.Min(num3,num4)));
      
    }
    intelligence = choosestat("intelligence");
    strength = choosestat("strength");
    immunity = choosestat("immunity");
    wisdom = choosestat("wisdom");
    agility = choosestat("agility");
    charisma = choosestat("charisma");
    waitkey();
  

    static int choosestat(string stat){
      print(statchoices);
      Write("\n\nWhat value in this list would you like for ");
      switch(stat){
        case "strength":
          color("strength",ConsoleColor.DarkRed,"? Strength is how easily you can kill enemies, move objects, and destroy things.");
          break;
        case "immunity":
          color("immunity", ConsoleColor.Green, "? This includes your health, ability to heal others, and your resistance to illnesses.");
          break;
        case "intelligence":
          color("intelligence", ConsoleColor.Yellow, "? This includes your ability to make desicions, solve puzzles, and interpret clues. ");
          break;
        case "wisdom":
          color("wisdom", ConsoleColor.Magenta, "? Wisdom is your knowledge in the areas of spells, magic, history, and pre-historic cultures.");
          break;
        case "agility":
          color("agility", ConsoleColor.DarkBlue, "? Agility is your speed, stealth, and ability to dodge attacks.");
          break;
        case "charisma":
          color("charisma", ConsoleColor.Red, "? It is your ability to persuade others, force of will, and overall appearance.");
          break;
      
      }
      int statval;
      WriteLine("");
      string input = Console.ReadLine();
      if(!Information.IsNumeric(input)){
        WriteLine("You have chose an invalid choice, so it has defaulted to the lowest value.");
        int minvalue = 19;
        foreach(int i in statchoices){
          minvalue = Math.Min(minvalue,i);
        }
        statchoices.Remove(minvalue);
        return minvalue;
      } else {
        statval = Convert.ToInt32(input);
      }
      if(statchoices.Remove(statval)){
        return statval;
      } else {
        WriteLine("You have chose an invalid choice, so it has defaulted to the lowest value.");
        int minvalue = 19;
        foreach(int i in statchoices){
          minvalue = Math.Min(minvalue,i);
        }
        statchoices.Remove(minvalue);
        return minvalue;
      }
    }
  }

  static void RaceChoose(){
    clear("Races:");
    Write("Which race do you want to choose? Each race has different effects on your stats, and can have their own unique choices or dialogue options when playing the game.\n");
    
    Write("1. Centuar: half-horse and half-human, centuars are very wise. "); color("+4i ", "yellow"); color("+2w ", "magenta"); color("-1s ","red"); color("-2m\n","green");
    Write("2. Dragonborn: a half-dragon and half-human, they have no wings or tail. "); color("+2s ","red"); color("+1c\n","pink"); 
    Write("3. Dwarf: don't let their size fool you, dwarves are quite tough. "); color("+1s ","red"); color("+2m\n","green");
    Write("4. Elf: elves are magical people that can move between worlds. "); color("+2a ","blue"); color("+1w\n","magenta"); 
    Write("5. Gnome: gnomes have a passion for living and are very enthusiastic. "); color("+2i ","yellow"); color("+1c ","pink"); color("+1w","magenta"); color("-1m\n", "green");
    Write("6. Half-Elf: half-elfs get the best of both worlds from their human and elf parents"); color(" +2c ","pink"); color("+1a ","blue");color("+1w ","magenta"); color("-1s\n","red");
    Write("7. Halfling: these tiny creatures live in fear of the bigger things around them, but are very fast. "); color("+4a ","blue"); color("+1i ", "yellow"); color("-1m ", "green"); color("-1s\n","red");
    Write("8. Human: humans are the most versatile of any race and can do many things. "); color("+2a ", "blue"); color("+2i ", "yellow"); color("+2c ", "pink"); color("-1s ", "red"); color("-1w ","magenta"); color("-1m\n","green");
    Write("9. Orc: orcs are big and strong, but slow. "); color("+4s ","red"); color("-1a\n","blue");
    Write("10. Therian: therians are beastlike and strong. "); color("+2s ","red"); color("+2a ","blue"); color("-1i\n\n ","yellow");
    Write(" Your Stats:");
    color($"\nIntelligence(i): {intelligence}","yellow");
    color($"\nStrength(s): {strength}","red");
    color($"\nImmunity(m): {immunity}","green");
    color($"\nWisom(w): {wisdom}","magenta");
    color($"\nAgility(a): {agility}","blue");
    color($"\nCharisma(c): {charisma}\n","pink");
    
    Write("Which race would you like? enter the number or the name exactly.\n >> ");
    
    string input = Console.ReadLine().ToLower();
    if(input == "centuar" || input == "1"){
      herorace = "centuar";
      intelligence += 4;
      wisdom += 1;
      strength -= 1;
      immunity -= 2;
    }else if(input == "dragonborn" || input == "2"){
      herorace = "dragonborn";
      strength += 2;
      charisma += 1;
    }else if(input == "dwarf" || input == "3"){
      herorace = "dwarf";
      strength +=1;
      immunity +=2;
    }else if(input == "elf" || input == "4"){
      herorace = "elf";
      agility += 2;
      wisdom += 1;
    }else if(input == "gnome" || input == "5"){
      herorace = "gnome";
      intelligence += 2;
      charisma +=1;
      wisdom +=1;
      immunity -= 1;
    }else if(input == "half-elf" || input == "6"){
      herorace = "half-elf";
      charisma +=2;
      agility +=1;
      wisdom +=1;
      strength -=1;
    }else if(input == "halfling" || input == "7"){
      herorace = "halfling";
      agility += 4;
      addintelligence(1);
      immunity -= 1;
      strength -= 1;
    }else if(input == "human" || input == "8"){
      herorace = "human";
      agility += 2;
      intelligence += 2;
      charisma +=2;
      wisdom -= 1;
      strength -= 1;
      immunity -=1;
    }else if(input == "orc" || input == "9"){
      herorace = "orc";
      strength += 4;
      agility -=1;
    }else if(input == "therian" || input == "10"){
      herorace = "therian";
      strength +=2;
      agility +=2;
      intelligence -= 1;
    }else{herorace = "None"; }

    
    clear();

    Imod = Mod(intelligence);
    Smod = Mod(strength);
    Mmod = Mod(immunity);
    Wmod = Mod(wisdom);
    Amod = Mod(agility);
    Cmod = Mod(charisma);
    
    //load(1);
    WriteLine("Race and stat boosts updated.");
    
    waitkey(); 
    clear();
    runStory(1);
  }
  static void MineWakeUp(){
    //story block 1
    WriteLine("Clang! Clang! Clang! The sound of many others, just like you, completing their work. Mining for hours on end, with little food and water. The only relief is the 15 minute lunch break at noon, where you eat at the center of the mine. After that, the work continues on until who-knows-when. When the royal guard decides to close the mines, the laborers finally get to sleep. The next morning, a guard rings the bell and it's off to work again. Day after day, hour after hour, you work at the mines chipping away at this strange blue metal. You don't know what it's used for, or what it is, but it is what keeps you alive. You walk into the mine, greeting your friend, Devesh.");
    waitkey();
    option = Option("I'm fine","I had that dream again", text: "Devesh: Hey Peri, you look tired today");
    if(option == 1){
      color("\nYou: I'm fine",ConsoleColor.Cyan);
      Thread.Sleep(1000);
      color("\nDevesh: Are you sure? you don't look fine... ", ConsoleColor.DarkMagenta );
      Thread.Sleep(1000);
    }
    color("\nYou: Yeah, I had that dream again", ConsoleColor.Cyan);
    Thread.Sleep(1000);
    color("\nDevesh: You should probably get that checked out.",ConsoleColor.DarkMagenta);
    Thread.Sleep(1000);
    color("\nGuard: HEY YOU TWO, QUIT THE CHITCHAT AND GET TO WORK!", "red");
    Thread.Sleep(1000);
    color("\nDevesh: Sorry sir, we'll get going now", ConsoleColor.DarkMagenta);
    waitkey();
    clear();
    WriteLine("It isn't easy living at the mines. You have to be constantly competing against others to get rest or even eat. If you don't collect enough of the blue metal by the end of the day, they make you mine throughout the entire night. Luckily, you have stayed out of trouble so far. But, the guards may up the quota and you might be forced to turn to some less honorable methods.");
    waitkey();
    clear();
    color("Guard: I have noticed that some of you have been lazy and slow lately. Thats why I'm upping the quota to 300 nuggets of ore today.","red");
    Thread.Sleep(2000);
    color("\nPrisoner: But sir, we've never had this kind of qu-\n", ConsoleColor.DarkMagenta);
    color("Guard: I DON'T CARE! NOW SHUT UP OR I'LL RAISE IT EVEN HIGHER!!","red");
    waitkey();
    clear();
    runStory(1.1);
  }
  static void Quota300(){
    //story block 1.1
    clear();
    int time = 10;
    int quota = 300;
    int nuggets = 0;
    string newtime;
    while(time < 19){
      string ap = (time > 11)? "p.m." : "a.m.";
      if(time == 12){
        newtime = "12";
      } else newtime = Convert.ToString(time % 12);
      int option = Option("(s)Continue mining","(a)Steal from someone","(c)Convince a guard to lower your quota", text:$"current time: {newtime}{ap}\nYou need {quota} nuggets before 6 p.m. \nYou have {nuggets} nuggets");
      if(option == 1){
        int rate = 30+(strength-8) * 2;
        rate += rand.Next(-5,6);
        clear();
        WriteLine($"You were able to mine {rate} nuggets");
        time += 1;
        nuggets += rate;
        waitkey();
        continue;
      } else if(option == 2){
        clear();
        int amount = 30 + agility;
        amount += rand.Next(-30,30);
        WriteLine($"You were able to steal {amount} nuggets from other miners");
        nuggets += amount;
        time += 1;
        waitkey();
        continue;
      } else if(option ==3){
        clear();
        int number = charisma += rand.Next(-3,6);
        if(number < 12){
          WriteLine("You walk up to a guard, hoping you can convice them to reduce your quota.");
          waitkey();
          color("You: You should lower my quota","cyan");
          Thread.Sleep(1000);
          color("\nGuard: No.","purple");
          Thread.Sleep(1000);
          color("\nYou: I'll buy you ice cream","cyan");
          Thread.Sleep(1000);
          color("\nGuard: You know I'm a guard right? I get ice cream for free. I don't need you to get it for me.", "purple");
          Thread.Sleep(1000);
          color("\nYou: Oh.","cyan");
          Thread.Sleep(1000);
          WriteLine("\n You don't want to get into trouble so you leave the guard and head back to your section of the mine. Well, it was worth a try");
          time += 1;
          waitkey();
          continue;
        } else {
          WriteLine("You walk behind the guard and take their keys.");
          Thread.Sleep(1000);
          color("You: Can you lower my quota?","cyan");
          Thread.Sleep(1000);
          color("\nGuard: Why should I?","purple");
          Thread.Sleep(1000);
          Write("\nYou take the keys from your pocket and show them to the guard.");
          Thread.Sleep(1000);
          color("\nYou: the warden wouldn't be happy if you lost these","cyan");
          Thread.Sleep(1000);
          color("\nGuard: Give those back!","purple");
          Thread.Sleep(1000);
          color("\nYou: Not until my quota gets lowered.","cyan");
          Thread.Sleep(1000);
          color("\nGuard: Fine. I'll reduce your stupid quota","purple");
          waitkey();
          time += 1;
          quota -= rand.Next(20,80);
          continue;
        }
      } 
    }
    clear();
    if(nuggets > quota){
      WriteLine("You were able to mine enough nuggets today and were allowed to go to bed, but some of your fellow miners couldn't say the same. But you can't worry about that, or you'll go mad.");
      xp((nuggets-quota)/5);
      waitkey();
      runStory(2);
    }else{ 
      WriteLine("You weren't able to mine enough nuggets before the end of the day, and the guards have enough people mining overnght, so they decide to put you in the prison. You try resisting, but they say the only other opton is that they kill you. After that, you have no choice but to go with them.");
      waitkey();
      runStory(3);
    }
  }
  
  static void mineDay2(){
    //story block 1.2f
    clear();
    WriteLine("Today, you have rec day. rec day happens 4 times a year, and today you get to relax. You have been meeting up with other prisoners and you have arranged a meeting at 4 p.m");
    waitkey();
    int time = 10;
    int suspicion = 0;
    string newtime;
    bool attendedMeeting = false;
    while(time < 18){
    string ap = (time > 11)? "p.m." : "a.m.";
        if(time == 12){
          newtime = "12";
        } else newtime = Convert.ToString(time % 12);
      option = Option("Play basketball","play tennis","Go to the meeting room","Relax for an hour",text:$"The current time is {newtime} {ap} \nWhat do you want to do?");
      if(option == 1){
        clear();
        WriteLine("You decide to play basketball and join a game.");
        waitkey();
        PlayBasketBall();
        clear();
        time += 1;
      }else if(option == 2){
        clear();
        WriteLine("You decide to play tennis to pass the time.");
        waitkey();
        clear();
        WriteLine("Your goal in tennis is to hit the left, right, or up arrow depending on where the ball is coming in from. You also have to time your key press when the ball is close to the bottom of the screen.");
        waitkey();
        PlayTennis();
        clear();
        WriteLine("You enjoyed playing tennis.");
        waitkey();
        time += 1;
      }else if(option == 3){
        clear();
        if(time != 16){
          WriteLine("You travel to the meeting room, and there is no-one. You have to be careful not coming to this room too often, or else the guards will catch you.");
          suspicion += 1;
          waitkey();
        }else{
          WriteLine("You travel to the meeting room, and just as you expected, some of your fellow prisoners are there.");
          attendedMeeting = true;
          suspicion = 0;
          waitkey();
          clear();
          color("Prisoner 1: How are we going to escape?","purple");
          Thread.Sleep(1000);
          color("Prisoner 2: I say we go by force. If all of us try, they can't stop any of us.","purple");
          Thread.Sleep(1000);
          color("Prisoner 3: But, What if it doesn't work?","purple");
          Thread.Sleep(1000);
          color("Prisoner 1: We won't fail. They can't take all of us at once.","purple");
          Thread.Sleep(1000);
          color("You: I second this plan. We should all just go at the same time.","color");
          Thread.Sleep(1000);
          color("Prisoner: Then it's settled. We'll follow the brute force approach. Thanks for meeting up, y'all.","purple");
          Thread.Sleep(1000);
          color("You: Let's go at 6 p.m.","cyan");
          Thread.Sleep(1000);
          color("Prisoner 1: Ok then.","purple");
          waitkey();
          clear();
          time += 1;
        }
      }else if(option == 4){
        clear();
        WriteLine("You sit down and relax for an hour.");
        time += 1;
        waitkey();
      }
    }
    if(attendedMeeting){
      WriteLine("You get ready to run out of the prison. You call the rest of the prisoners with you and you all get ready. But, the warden is alerted and he runs into the mine.");
      waitkey();
      clear();
      color("Warden: You thought you could just escape, Peri? Well, I'm never letting you leave!","red");
      waitkey();
      if(fight("The Warden",20,true)){
        clear();
        WriteLine("You beat the warden, and rush forward with your fellow prisoners. You finally make it to the surface and see sweet sunlight again.");
        //end 
      }else{
        clear();
        WriteLine("The warden may have beat you, but your fellow people are inspired by you, and mad at the warden. They all slash out against him, and carry you to the surface to see sunlight again.");
        //end
      }
    }else{
      clear();
      WriteLine("The rest of the people at the meeting are mad at you for arranging the meeting and then failing to show up. They believe you are the cause of their inprisonment and they start a brawl against you. You fight back, and the guards decide they're taking the entire group to the prison");
      waitkey();
      runStory(3);
    }
  }
  static void PlayBasketBall(){
    int myscore = 0;
    int enemyscore = 0;
    while(myscore + enemyscore < 6){
      clear();
      WriteLine($"The score is {myscore} to {enemyscore}");
      waitkey();
      clear();
      int num = rand.Next(1,3);
      if(num == 1){
        WriteLine("You run up to the end of the court, and are ready to shoot. But, your opponents surround you and you have to do something quick");
        waitkey();
        option = Option("Try to run through them","Shoot the ball","Pass to a teammate",text:"What do you do?");
        if(option == 1){
          if(check(Smod,20)){
            WriteLine("You run through your opponents and before they have time to react, you shoot and score a point.");
            waitkey();
            myscore+=1;
          }else{
            WriteLine("You try to run through them, but the other team steals the ball and scores a point.");
            waitkey();
            enemyscore+=1;
          }
        }else if(option == 2){
          if(check(Amod,15)){
            WriteLine("You shoot the ball and make it into the hoop");
            waitkey();
            myscore+=1;
          }else{
            WriteLine("You try to shoot, but another person blocks the ball and it falls to the floor.");
            waitkey();
            enemyscore+=1;
          }
        }else if(option == 3){
          WriteLine("You pass the ball to a teammate and they shoot it into the hoop and score a point.");
          waitkey();
          myscore+=1;
        }
      } else if(num == 2){
        WriteLine("Somebody comes into your side of the court and you have to stop them from scoring.");
        waitkey();
        option = Option("Steal the ball","Block their shot","surround the person",text:"How should you defend against the other player?");
        if(option == 1){
          if(check(Smod,10)){
            WriteLine("You run up to the opponent and take the ball from them. You then run up to the other side of the court and score.");
            waitkey();
            myscore+=1;
          } else{
            WriteLine("You try to steal the ball from them, but they run past you and score a point.");
            waitkey();
            enemyscore+=1;
          }
        }else if(option == 2){
          if(check(Amod,10)){
            WriteLine("you wait for them to shoot and yo stick your hand up in the air to block it. You then take the ball and score a point.");
            waitkey();
            myscore+=1;
          }else{
            WriteLine("You try to block the ball, but you are not fast enough and the ball flies past your hand into the goal");
            waitkey();
            enemyscore+=1;
          }
        }else if(option == 3){
          if(check(Cmod,10)){
            WriteLine("You call to your teammates and they come and surround the opponent. You take the ball from them and run up and score a point.");
            waitkey();
            myscore+=1;
          }else{
            WriteLine("You call to your team, but they can't arrive in time. The opponent rusn past you and scores a point.");
            waitkey();
            enemyscore+=1;
          }
        }
      }
    }
    clear();
    if(enemyscore > myscore){
      WriteLine("You lost the game, but you still had fun.");
      xp(myscore * 3);
      waitkey();
    }else{
      WriteLine("You won the game, and you high five your teammates in congratulation.");
      xp((myscore-enemyscore)*6);
      waitkey();
    }
  }

  static void PlayTennis(){
    
    int num = rand.Next(1,4);
    
    if(num == 1){
      if(TennisLeft()){
        WriteLine("Nice Hit!");
        xp(2);
        Thread.Sleep(1000);
        PlayTennis();
      }else{
        WriteLine("You missed the shot. Try again.");
        Thread.Sleep(1000);
        waitkey();
        return;
      }
    }else if(num== 2){
      if(TennisUp()){
        WriteLine("Nice Hit!");
        xp(2);
        waitkey();
        PlayTennis();
      }else{
        WriteLine("You missed the shot. Try again.");
        Thread.Sleep(1000);
        waitkey();
        return;
      }
    }else if(num == 3){
      if(TennisRight()){
        WriteLine("Nice Hit!");
        xp(2);
        Thread.Sleep(1000);
        PlayTennis();
      }else{
        WriteLine("You missed the shot. Try again.");
        Thread.Sleep(1000);
        waitkey();
        return;
      }
    }
  }

  static bool TennisLeft(){
    clear();
    string[] tennisleftframes = {"|       🟢                        |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|     🟢                          |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|     🟢                          |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|     🟢                          |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|     🟢                          |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|     🟢                          |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|     🟢                          |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|      🟢                         |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|      🟢                         |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|      🟢                         |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|      🟢                         |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|     🟢                          |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|     🟢                          |"};
    int i = 0;
    do{
      while(!Console.KeyAvailable){
        if(i< tennisleftframes.Length){
          frame(tennisleftframes[i],50);
          i++;
        }else{
          return false;
        }
      }
    }while(Console.ReadKey().Key != ConsoleKey.LeftArrow );
    if(i > 8){
      return true;
    } else{
      return false;
    }
  }
  static bool TennisUp(){
    clear();
    string[] tennisupframes = {"|               🟢                |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|               🟢                |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|               🟢                |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|               🟢                |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|               🟢                |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|               🟢                |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|               🟢                |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|               🟢                |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|               🟢                |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|               🟢                |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|               🟢                |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|               🟢                |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|               🟢                |"};
    int i = 0;
    do{
      while(!Console.KeyAvailable){
        if(i< tennisupframes.Length){
          frame(tennisupframes[i],50);
          i++;
        }else{
          return false;
        }
      }
    }while(Console.ReadKey().Key != ConsoleKey.UpArrow );
    if(i > 8){
      return true;
    } else{
      return false;
    }
  }
  static bool TennisRight(){
    clear();
    string[] tennisrightframes = {"|                        🟢       |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                        🟢       |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                        🟢       |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                        🟢       |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                        🟢       |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                        🟢       |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                        🟢       |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                        🟢       |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                        🟢       |\n|                                 |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                        🟢       |\n|                                 |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                        🟢       |\n|                                 |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                        🟢       |\n|                                 |","|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                                 |\n|                        🟢       |"};
    int i = 0;
    do{
      while(!Console.KeyAvailable){
        if(i< tennisrightframes.Length){
          frame(tennisrightframes[i],50);
          i++;
        }else{
          return false;
        }
      }
    }while(Console.ReadKey().Key != ConsoleKey.RightArrow );
    if(i > 8){
      return true;
    } else{
      return false;
    }
  }
  static void MineFallAsleep(){
    //story block 2
    clear();
    WriteLine("After mining, you head to your quarters. You stare at yourself in the dusty mirror as you reimagine what your life would've been if you were born up there, on the ground... why did your mother have to leave you here? Suddenly, someone knocks on your door. As you walk closer to the door to open it, you hear faint whispers, \"Peri, he never died, find me\". The eerie whispers send a chill down your spine... ");
    waitkey();
    clear();
    WriteLine("You open the door, and are greeted by- absolutely nothing. You turn the single lightbulb off and head to your tattered mattress to get some sleep. You toss and turn all night trying to figure out what your dream, and the whispers meant. They began after that day in the mine where you touched the green metal, the one you weren't supposed to go near... People called it the mad metal, stupidity steel, rumors said it would drive you crazy.. You hear footsteps outside the door . . .");
    waitkey();
    option = Option("Try to Sleep","(i)Explore the halls");
    clear();
    if(option == 1){
      WriteLine("You toss and turn, and after what feels like hours, you finally get some shut-eye.");
      waitkey();
      runStory(1.2);
    } else if (option == 2){
      WriteLine("You decide you want to explore the halls and try to find whatever those whispers are.");
      xp(3);
      waitkey();
      runStory(2.1);
    }
  }
  static void MineExploreHalls(){
    clear();
    //story block 2.1f
    if(check(Wmod,10)){
      WriteLine("You have been keepng track of the guards' movement the past few days, and think you could avoid the guards while being out.");
      waitkey();
      clear();
      WriteLine("You walk outside, and see a shadow with a strange silhouette on the wall at the end of the hallway. You turn around as you hear the footsteps get fainter.");
      waitkey();
      option = Option("Chase the mysterious figure","Go back to your room");
      if(option == 1){
        WriteLine("You run after them, turning the tight corners as you sprint, the hallway gets brighter at the end until you see a doorway with nothing but light. Blinding light.");;
        waitkey();
        clear();
        WriteLine("You walk into someplace that looks straight out of a dream... Your dream... You are in a medium sized room with stone walls and a warm fireplace. There is a red velvet couch with someone on it... You walk toward the couch to see an old man in a dark purple robe... ");
        waitkey();
        clear();
        color("Old Man: Welcome Peri..., I have been waiting for you","purple");
        Thread.Sleep(1000);
        color("You: How.. How do you know my name?","cyan");
        Thread.Sleep(1000);
        color("Old Man: That is a story for another time. I called you here becuase I wanted to tell you to meet me when you escape.","purple");
        Thread.Sleep(1000);
        color("You: Don't you mean if I escape?","cyan");
        Thread.Sleep(1000);
        color("Old Man: That is a question you yourself must answer.","purple");
        waitkey();
        clear();
        WriteLine("Suddenly, a bright flash blinds you... You hear more whispers in your head as you feel a force pull you backwards...");
        waitkey();
        clear();
        WriteLine("you land on a bed. Not the tattered, hard-as-rock ones they had back in the mine. This was a nice one; With soft white sheets you look around, completely in shock surrounded by pastel blue walls and fancy room decor. The room comes alive with sunlight shining through a window on a wall to the left of the bed. Outside, you see a town surrounded by mountains. No. A kingdom. Flowering with life and people. They all looked so... happy. In the distance, a ruined emerald green castle lies still. Before you can look for more, the sunlight flashes your eyes as you are yet again pulled backward. Again, you land on a bed. But unlike last time, this is your mattress.");
        waitkey();
        clear();
        WriteLine("With a newfound passion to escape from the mine, you dash back to your room and have no trouble sleeping.");
        xp(3);
        waitkey();
        runStory(1.2);
      }else if (option == 2){
        if(check(Amod,15)){
          WriteLine("You go back into your room and have no trouble falling asleep");
          xp(3);
        }else{
          runStory(2.12);
        }
      }
    } else {
      runStory(2.11);
    }
  }

  static void CaughtByGuard(bool walkingBack){
    //story block 2.11f and 2.12f
    string var1 = (walkingBack)? "back to" : "out of";
    WriteLine($"You decide that since it's so late, all the guards should be sleeping. You walk {var1} your room, and stop straight in your tracks as you see what's in front of you. ");
    waitkey();
    option = Option("run from the guard","try to fight them","talk it out",text : "Guard: Well, what do we have here?");
    if(option == 1){
      Write("You run as fast as you can from the guard. You open a door and hide behind it. ");
      if(check(Amod,10)){
        WriteLine("Luckily for you, the room you hid behind was Devesh's room.");
        waitkey();
        clear();
        color("Devesh: What are you doing here, Peri?","purple");
        Thread.Sleep(1000);
        color("\nYou: Nothing.","cyan");
        Thread.Sleep(1000);
        color("\nDevesh: It's probably not nothing when you're breathing that heavy.","purple");
        Thread.Sleep(1000);
        color("\nYou: I'm running from a guard, I'll go back to my room when I've lost him.","cyan");
        Thread.Sleep(1000);
        color("\nDevesh: Come on Peri, you can't keep doing this! You'll get caught and sent to the prison!","purple");
        Thread.Sleep(1000);
        color("\nYou: The Guard's gone. I'm going back to my room, and I'm sorry for bothering you.","cyan");
        Thread.Sleep(1000);
        color("\nDevesh: Ok then, bye.","purple");
        waitkey();
        clear();
        WriteLine("That was close. You dart back to your room and have no trouble falling asleep after tonight's events.");
        xp(3);
        waitkey();
        runStory(1.2);
      }else{
        WriteLine("You turn around to see several guards waiting for you. You realize that you are cornered and you have no choice but to go to the prison.");
        waitkey();
        runStory(3);
      }       
    } else if(option == 2){
      if(check(Smod,15)){
        Write("You were able to knock the guard out, but you didn't notice the other guards around you");
      }
      WriteLine("The guards surround you and you are unable to do anything. You realize that the only place they could be taking you to is the prison.");
      waitkey();
      runStory(3);
    } else if(option == 3){
      color("You: I was just heading back to my room","cyan");
      Thread.Sleep(1000);
      if(check(Cmod, 5)){
        color("\nGuard: Don't you know you miners aren't supposed to be out after 6? Don't let me catch you again or your'e going straight to prison","red");
        waitkey();
        clear();
        WriteLine("That was close. You dart back to your room and have no trouble falling asleep after tonight's events.");
        xp(3);
        waitkey();
        runStory(1.2);
      } else{
        color("\nGuard: Yeah, right. I saw you just leave your room. You're going to the prison, buddy.","red");
        waitkey();
        runStory(3);
      }
    }
  }
  static void Prison(){
    //story block 3
    clear();
    WriteLine("You wake up in a room that looks like it was made out of a cave. There are ragged stone walls, and no windows whatsoever. The air feels darker than the rest of the mine and you can tell that you are deeper underground. You remember that this is what the prison looks like, and that you need to escape, if only to see the sunlight one more time.");
    waitkey();
    option = Option("By digging through the walls","by disguising as a guard",text:"How are you going to escape");
    if(option == 1){
      clear();
      WriteLine("You decide digging through the walls is the better option to escape. You need to find tools to help you escape, so you begin to search. ");
      waitkey();
      runStory(3.1);
    }else if(option == 2){
      WriteLine("Pretending to be a guard and leaving normally is the better option.");
      waitkey();
      clear();
      WriteLine("In order to get a guard's disguise, you need to first get them unconcious.");
      runStory(3.2);
    }
  }
  
  static void DigWalls(){
    //story block 3.1f
    bool haswood = false;
    bool hastools = false;
    bool shovelgone = false;
    option =  Option("Check the door","check the walls","check the ceiling","check the floor",text:"Where do you look to find tools");
    if(option == 1){
      clear();      
      Console.WriteLine("You check the door, and there seems to be nothing there. But, near the top, you see a group of fibers coming off of the wood door. You think they could be useful for something and grab them.");
      haswood = true;
      waitkey();
      DigWalls();
    } else if (option == 2){
      clear();
      if(hastools){
        WriteLine("There is a picaxe, a hammer, and some rocks next to the wall that you found earlier.");
        waitkey();
        DigWalls();
      } else if(haswood){
        WriteLine("You notice that the wood fibers you took are really strong, and you think that you could use them to try to scratch through the walls. As you are scratching, you begin to lose hope as nothing happens. But finally, as you sweep the walls a second time, you find a piece of softer rock that could be clay. You scratch the clay and behind it, you find a picaxe, a hammer, and some sharp rocks. You think to leave them there and then use them when you need to.");
        hastools = true;
        waitkey();
        DigWalls();
      }else{
        WriteLine("You check around the walls, but you don't find anything. However, you notice that when you tap one part of the wall, it sounds a bit different.");
        waitkey();
        DigWalls();
      }
    } else if (option == 3){
      if(shovelgone){
        WriteLine("There is nothing on the ceiling above you");  
      }else{
        WriteLine("Above you, there is noting but a peculiar shovel hanging from the ceiling by rope");      
      }
      if(hastools){
        WriteLine("You realize you could use the rocks you have to cut the rope and bring the shovel down. You throw the rocks one by one, and finally, the roe breaks and the shovel comes clattering down, missing you by a few inches.");
        shovelgone = true;
      }
      waitkey();
      DigWalls();
    } else if (option == 4){
      if(shovelgone){
        WriteLine("When the shovel fell, you noticed it didn't clang. You look where the shovel fell, and sure enough, there is a dip in the floor. You realize this means you could probably dig out this part from the floor.");
        waitkey();
        clear();
        WriteLine("You dig the spot, and the floor there turns out to be sand. You dig more, and it seems there is a tunnel underneath. You make sure to bring the picaxe and hammer, and enter the tunnel.");
        waitkey();
        clear();
        WriteLine("You crawl into the tunnel, and within a few feet, you are blocked by a wall. The wall says, \"Go Back\", but you ignore it. Whatever's ahead is probably better than rotting in a cell for eternity.");
        waitkey();
        clear();
        option = Option("Use your hammer","use your picaxe",text:"what should you use to break the wall?");
        string tool = (option == 1)? "hammer" : "picaxe";
        WriteLine($"You use your {tool} to try to break the wall. You hit it a few times and the wall crumbles in front of you. You continue crawling through the tunnel.");
        waitkey();
        clear();
        color("Warden: Hello, Peri. You thought you could escape, huh? Well, that's not the case. You should have listened to the wall and stayed back in your cell. ","red");
        Thread.Sleep(1000);
        color("\nYou: How? How are you here?","cyan");
        Thread.Sleep(1000);
        color("\nWarden: You came all the way here and didn't suspect anything? You thought there just happened to be tools in the wall, a shovel in the ceiling, sand in the floor, and a tunnel underneath? I thought you were smarter than that.","red");
        Thread.Sleep(2000);
        color("\nYou: Why do you care about me so much? just let me leave.","cyan");
        Thread.Sleep(1000);
        color("\nWarden: No.","red");
        waitkey();
        if(fight("The warden",20,true)){
          WriteLine("You beat the warden and he gets taken to the mine hospital by the medics. Before they can figure out what happened to him, you escape from the mine and get to the surface.");
          xp(30);
          //end
        } else {
          WriteLine("The warden pins you to the floor and is ready to throw you back into the prison. But, as he opens the door, guards come rushing in. The warden asks what it is, and after they reply that he needs to see himself, he leaves you alone. You run and make it to the surface.");
          //end
        }
      } else{
        WriteLine("There doesn't seem to be anything on the floor");
        waitkey();
        DigWalls();
      }
    }
  }
  static void EscapeAsGuard(){
    //story block 3.2f
    
    option = Option("Try to poison the guard","punch the guard",text:"how do you obtain the guard's uniform?");
    if(option == 1){
      WriteLine("you decide trying to make some poison to give to the guard is the best bet. You find a flatter area of rock on the floor and break off a stick shaped rock from a nearby stalagmite.");
      waitkey();
      runStory(3.21);
    }
  }
  static int mushroom = 0,fern = 0,dirt = 0,water = 0,rock = 0;
    
  static void PoisonGuard(){
    clear();
    option = Option("Mushrooms","Ferns","Dirt","Water","Rock","Finish potion",text:"What do you want to add to your potion? \n Be careful not to add too much of anything or your potion might not work.");
    if(option == 1){
      WriteLine("You pick a mushroom that's growing on the ground and add it onto your table. You smash it and it turns into a brown paste.");
      mushroom += 1;
      
    } else if(option == 2){
      WriteLine("You rip part of some ferns you see on the wall and crush it into your potion");
      fern += 1;
    } else if(option == 3){
      WriteLine("You pick up some dirt and throw it onto your poison.");
      dirt += 1;
    } else if(option == 4){
      WriteLine("You travel further into the cave and find a small stream of water. You cup your hands and take the water to your rock table");
      water += 1;
    } else if(option == 5){
      WriteLine("You grab some pebbles and crush them into a dust.");
      rock += 1;
    } else if(option == 6){
      Write("You mix everything together and hope your concoction works on the guard.");
      if((water + .2*dirt + .2* fern) > 3){
        WriteLine("You notice your potion is too watery and drips off the table, and you have to start again.");
        waitkey();
        runStory(3.2);
      } else if((dirt + rock - water*.5) > 3){
        WriteLine("Your potion is too dry and powdery and doesnt clump together. You have to start again.");
        waitkey();
        runStory(3.2);
      } else if((fern + mushroom) < 1){
        WriteLine("Your potion couldn't posion the guard with just dirt and sand. You have to start again.");
        waitkey();
        runStory(3.2);
      } else{
        waitkey();
        clear();
        WriteLine("You finish your potion and wait for the guard to serve you food.");
        waitkey();
        clear();
        WriteLine("After waiting a few minutes, the guard arrives. As the guard is leaving, you pin them to the floor, and throw the poison in their mouth. Maybe it poisoned them, or just choked them, but they get knocked unconcious and you take their uniform.");
        xp(10);
        waitkey();
        clear();
        WriteLine("You casually walk out into the hallway, pretending you are a guard. As you are leaving the prison, you spy the warden staring at you. You can tell by his stare he knows you are an impostor.");
        waitkey();
        clear();
        color("Warden: You know I can't just let you leave like that, Peri.","red");
        waitkey();
        clear();
        if(fight("The warden",20,true)){
          WriteLine("You beat the warden and he gets taken to the mine hospital by the medics. Before they can figure out what happened to him, you escape from the mine and get to the surface.");
          xp(30);
          //end
        } else {
          WriteLine("The warden pins you to the floor and is ready to throw you back into the prison. But, as he opens the door, guards come rushing in. The warden asks what it is, and after they reply that he needs to see himself, he leaves you alone. You run and make it to the surface.");
          //end
        }
      }
      
    }
  }
  /*
  static void OldManStory(){
    clear("Old Man:");
    Write("Long ago, before the great trinity war, all the clans lived in harmony, sharing the resources of Viernin, the guardian realm of the trinity gem. The trinity gem was an artifact that I, the First Dragon, sealed in Viernin to protect it from the greedy hands that lay past the walls of the realm. The Trinity Gem contains immense powers from the original Trinity Wizards that founded Viernin centuries ago, as the place of magic and wonders it is today.");
    waitkey();
    clear("The Wizards:");
    color("Bresen",ConsoleColor.Magenta); Write(": The mighty ruler of the Elderflame Clan. He had the power to control fire and steel. He was the greatest blacksmith in the land, and his tools were used by the Trinity Champions. \n\n"); color("Aizen",ConsoleColor.Green); Write(": The lightning-quick medic. Aizen is a stealthy healer, with millenia of experience in the medicine of Viernin. Soon after Gridet\'s greed engulfed him, Aizen and the rest of the Tygi Clan retreated into the Luminescent Cove. \n\n"); color("Gridet", ConsoleColor.Yellow); Write(": The Emperor of Viernin. Feared by all Gridet ruled with power and possesion over the trinity gem. Although soon after, his greed got the better of him as he threatened Aizen and Bresen for total control over Viernen and all of it\'s resources and power. ");
    waitkey();
    Console.Clear();
  Write("These wizards each created a ");
    color("champion", ConsoleColor.Magenta ); Write(" who served as the Militia General for their respective clans. The champions would give their life for their leader, as they are immensely devoted to their supreme creator.");
    waitkey();
    clear("The Champions:");
    color("Xaosi", ConsoleColor.DarkRed);
    Write(": The brute force champion. His immense strength is unparalleled as he can move mountains with his bare hands.\n\n");

color("Nembyt", ConsoleColor.DarkBlue);    
Write(": The wise creative champion. He can materialize any weapon or object out of ice from the sacred water of the Luminescent Cove he holds in his pouch. He is the heir of the Tygi Clan, and the adoptive son of Aizen.\n\n");

color("Emri", ConsoleColor.Red);
Write(": The queen of Viernen. She was created by Gridet after he took control of Viernen after the Battle of Sumoi. She has no empathy and her devotion to Gridet is immeasurable.\n\n");

  }
  */
  static int Option(string op1, string op2, string op3 = "", string op4 = "", string op5 = "", string op6 = "", string text = ""){
		int num;
		do{num = GetChoice(op1,op2,op3,op4,op5,op6,text);}while (num == 10);
		return num;
	}  
  static int GetChoice(string op1, string op2, string op3 = "", string op4 = "",string op5 = "", string op6 = "", string text = ""){
		clear();
		Console.WriteLine(text + "\n");
		color("A) ", ConsoleColor.DarkRed, op1 , false);color("\nB) ", ConsoleColor.DarkBlue, op2 , false);
		if(op3 != ""){color("\nC) ", ConsoleColor.Yellow, op3, false);}
		if(op4 != ""){color("\nD) ", ConsoleColor.DarkGreen, op4 , false);}
		if(op5 != ""){color("\nE) ", ConsoleColor.Cyan, op5 , false);}
		if(op6 != ""){color("\nF) ", ConsoleColor.DarkMagenta, op6 , false);}
		Console.Write("\n\nEnter a choice by entering the letter in front. use \'m\' to open your character menu. \nNote: a letter in parentheses means that your stats play a role in the outcome of the desicion. \n >> ");
		string input = Console.ReadLine();
		input = input.ToLower();
		input = input.Trim();
		clear();
		if(input == "a"){return 1;}
		else if(input == "b"){return 2;}
		else if(input == "c"){return 3;}
		else if(input == "d"){return 4;}
		else if (input == "e"){return 5;}else if (input == "f"){return 6;} else if (input == "m"){StatMenu();return 10;}return 10;}
  static void waitkey(){ConsoleKey key;color("\nPress c to continue\n", ConsoleColor.Blue);do{key = Console.ReadKey(true).Key;} while(key != ConsoleKey.C);checklevel();}
  static void print(List<int> list){ foreach(int i in list) {Console.Write(i + " "); } }
  public static void Write(string text){int i = 0;while(!Console.KeyAvailable && i < text.Length ){Console.Write(text[i]);i++;Thread.Sleep(50);}Console.Write(text.Substring(i));}
  public static void WriteLine(string text){int i = 0;while(!Console.KeyAvailable && i < text.Length ){Console.Write(text[i]);i++;Thread.Sleep(50);}Console.Write(text.Substring(i) + "\n");}
  //static void load(int seconds){Console.ForegroundColor = ConsoleColor.Blue;for(int i = 0;i < seconds;i++){Console.Clear();Console.Write("Loading.");Thread.Sleep(333);Console.Clear();Console.Write("Loading..");Thread.Sleep(333);Console.Clear();Console.Write("Loading...");Thread.Sleep(333);}Console.ForegroundColor = ConsoleColor.White;Console.Clear();}
  static void color(string text, string color = "", string whitetext = "", bool slow = true){
		if(color == "pink") Console.ForegroundColor = ConsoleColor.Red;
		else if(color == "red" ) Console.ForegroundColor = ConsoleColor.DarkRed;
		else if(color == "blue") Console.ForegroundColor = ConsoleColor.DarkBlue;
		else if(color == "yellow") Console.ForegroundColor = ConsoleColor.Yellow;
		else if(color == "cyan") Console.ForegroundColor = ConsoleColor.Cyan;
		else if(color == "magenta") Console.ForegroundColor = ConsoleColor.Magenta;
		else if(color == "green") Console.ForegroundColor = ConsoleColor.Green;
		else if(color == "purple"){Console.ForegroundColor = ConsoleColor.DarkMagenta;}
		if(slow) Write(text);
		else Console.Write(text);
		Console.ForegroundColor = ConsoleColor.White;
		Write(whitetext);
	}
  static void checklevel(){
    int templevel;
    templevel = Convert.ToInt32(Math.Floor(Math.Sqrt(exp/9.48683298051)));
    if(templevel > level){
      level = templevel;
      levelUp();
    }
  }
  static void levelUp(){
    clear();
    WriteLine("You have leveled up! you now have more health");
    waitkey();
    healthrolls.Add(roll(hitdie));
    if(level == 4 || level == 8 || level == 12 || level == 16 || level == 19){
      levelwithstats();
    }
  }
  static void levelwithstats(){
    int stattotal = intelligence + strength + immunity + wisdom + agility + charisma;
    int newstatotal = stattotal;
    while(newstatotal - 4 < stattotal){
      option = Option($"intelligence","strength","immunity","wisdom","agility","charisma",text:"You have leveled up! You get to increase your stats at this level. You have {4 - (newstatotal - stattotal)} stat increases left.");
      if(option == 1 && intelligence < 20){
        addintelligence( 1);
        newstatotal += 1;
      }else if(option == 2 && strength < 20){
        addstrength(1);
        newstatotal +=1;
      }else if(option == 3 && immunity < 20){
        addimmunity(1);
        newstatotal += 1;
      }else if(option == 4 && wisdom < 20){
        addwisdom(1);
        newstatotal += 1;
      }else if(option == 5 && agility < 20){
        addagility(1);
        newstatotal += 1;
      }else if(option == 6 && charisma < 20){
        addcharisma(1);
        newstatotal += 1;
      }else{
        WriteLine("You cannot increase a stat past 20 when you level up.");
      }
    } 
  }
  public static string numtospell(int num){
    switch(num){
      case 1:
        return "punch";
      case 2:
        return "kick";
      case 3:
        return "crouch - crouching gives you time to heal some of your lost health.";
    }
    return "a";
  }
  public static int spelltonum(string spell){
    switch(spell){
      case "punch":
        return 1;
      case "kick":
        return 2;
      case "crouch":
        return 3;
      default:
        return 500;
    }
  }
  public static void castspell(int num){
    /*switch(num){
      case 1:
        attack(5,1);
    }*/
  }
  static void attack(int damage, int risk){
    clear();
    int number = damage;
    damage += rand.Next(-1*risk,risk + 1);
  }
  static void color(string text, ConsoleColor Color,  string whitetext = "", bool slow = true){
		Console.ForegroundColor = Color;
		if(!slow) Console.Write(text);
		else Write(text);
		Console.ForegroundColor = ConsoleColor.White;
		Write(whitetext);
	}
  static void clear(string text = ""){
		Console.Clear();
		Console.Write(text + "\n\n");
	}
  static int roll(int max, int mod = 0){
		int Roll = rand.Next(1,max+1);
		return Roll += mod;
	}  
  static int Mod(int stat){
		return ((stat - 10)/2);
	}
  static bool check(int stat, int difficulty){
		int num1 = roll(20);num1+=stat;return (num1>=20);
	}
  static void addintelligence (int amount){
    intelligence += amount;
    Imod = Mod(intelligence);
  }
  static void addstrength (int amount){
    strength += amount;
    Smod = Mod(strength);
  }
  static void addimmunity (int amount){
    oldMmod = Mmod;
    immunity += amount;
    Mmod = Mod(immunity);
    calchealth();
  }
  static void addwisdom (int amount){
    wisdom += amount;
    Wmod = Mod(wisdom);
  }
  static void addagility (int amount){
    agility += amount;
    Amod = Mod(agility);
  }
  static void addcharisma (int amount){
    charisma += amount;
    Cmod = Mod(charisma);
  }
  static void calchealth(){
    herohealth = healthrolls.Sum() + (level * Mmod);
  }
  static void xp(int amount){
    exp += amount;
    color("+{amount}xp","green");
  }
  public static void choosefeat(){
    Console.Clear();
    foreach(int i in abilities){
      Console.WriteLine(i + " - " + numtospell(i));
    }
    Console.Write("Enter the number of the ");
  }
  public static bool fight(string enemyName, int hp,bool boss){
    PlayAnimation(boss);
    //finish bossfight.
    enemyHP = hp;
    int newherohealth = herohealth;
    int power = 8;
    while (hp > 0 && herohealth > 0){
      choosefeat();
      waitkey();
      clear();
      if(enemyHP < .2*hp){
        int imm = 2 + rand.Next(hp/5-2,hp/5+2);
        enemyHP += imm;
        WriteLine($"{enemyName} healed by {imm} HP.");
      } else {
        int str = 3 + rand.Next(hp/5-2,hp/5+2);
        newherohealth -= str;
        WriteLine($"{enemyName} attacked you and dealt {str} damage.");
      }
      waitkey();
      clear();
    }
    if(newherohealth > 0){
      return true;
    } else{
      return false;
    }
  }
  static void Save(){
    clear();
    string savecode = "";
    savecode = exp + "|" + hitdie/2 + ":" + storyblock + "/" + (intelligence + 2) + ":" + (strength*3) + "/" + (immunity-6) + "|" + (wisdom*2) + ":" + agility + "/" + (charisma*10) + ":";
    foreach(int i in healthrolls){
      savecode += i;
      savecode += ".";
    }
    Console.WriteLine("Your code is:\n"+savecode);
    Thread.Sleep(3000);
    waitkey();
  }
  static void Load(){
    clear();
    Console.Write("Enter your save code. type in 'c' to cancel.\n >> ");
    string savecode = Console.ReadLine();
    if(savecode == "c"){
      return;
    }
    string[] codes = savecode.Split('|',':','/');
    
    exp = Convert.ToDouble(codes[0]);
    hitdie = Convert.ToInt32(codes[1]) * 2;
    intelligence = Convert.ToInt32(codes[3]) - 2;
    strength = Convert.ToInt32(codes[4]) / 3;
    immunity = Convert.ToInt32(codes[5]) + 6;
    wisdom = Convert.ToInt32(codes[6])/2;
    agility = Convert.ToInt32(codes[7]);
    charisma = Convert.ToInt32(codes[8])/10;
    Imod = Mod(intelligence);
    Smod = Mod(strength);
    Mmod = Mod(immunity);
    Wmod = Mod(wisdom);
    Amod = Mod(agility);
    Cmod = Mod(charisma);
    level = Convert.ToInt32(Math.Floor(Math.Sqrt(exp/9.48683298051)));
    herohealth = healthrolls.Sum() + (level * Mmod);
    string allrolls = codes[9];
    string[] rolls = allrolls.Split('.');
    foreach(string i in rolls){
      if(i != ""){
        healthrolls.Add(Convert.ToInt32(i));
      }
    }
    Console.WriteLine("Loading...");
    Thread.Sleep(2000);
    runStory(Convert.ToDouble(codes[2]));
  }
  static void PlayAnimation(bool boss){
    if(boss){
      for(int i = 0; i< 3; i++){
        frame("-          BOSS-FIGHT          -");
        frame("--         BOSS-FIGHT         --");
        frame(" -         BOSS-FIGHT         - ");
        frame(" --        BOSS-FIGHT        -- ");
        frame("  -        BOSS-FIGHT        -  ");
        frame("  --       BOSS-FIGHT       --  ");
        frame("   -       BOSS-FIGHT       -   ");
        frame("   --      BOSS-FIGHT      --   ");
        frame("    -      BOSS-FIGHT      -    ");
        frame("    --     BOSS-FIGHT     --    ");
        frame("     -     BOSS-FIGHT     -     ");
        frame("     --    BOSS-FIGHT    --     ");
        frame("      -    BOSS-FIGHT    -      ");
        frame("      --   BOSS-FIGHT   --      ");
        frame("       -   BOSS-FIGHT   -       ");
        frame("       --  BOSS-FIGHT  --       ");
        frame("        -  BOSS-FIGHT  -        ");
        frame("        -- BOSS-FIGHT --        ");
        frame("         - BOSS-FIGHT -         ");
        frame("         --BOSS-FIGHT--         ");
        frame("          -BOSS-FIGHT-          ");
        frame("         --BOSS-FIGHT--         ");
        frame("         - BOSS-FIGHT -         ");
        frame("        -- BOSS-FIGHT --        ");
        frame("        -  BOSS-FIGHT  -        ");
        frame("       --  BOSS-FIGHT  --       ");
        frame("       -   BOSS-FIGHT   -       ");
        frame("      --   BOSS-FIGHT   --      ");
        frame("      -    BOSS-FIGHT    -      ");
        frame("     --    BOSS-FIGHT    --     ");
        frame("     -     BOSS-FIGHT     -     ");
        frame("    --     BOSS-FIGHT     --    ");
        frame("    -      BOSS-FIGHT      -    ");
        frame("   --      BOSS-FIGHT      --   ");
        frame("   -       BOSS-FIGHT       -   ");
        frame("  --       BOSS-FIGHT       --  ");
        frame("  -        BOSS-FIGHT        -  ");
        frame(" --        BOSS-FIGHT        -- ");
        frame(" -         BOSS-FIGHT         - ");
        frame("--         BOSS-FIGHT         --");
        frame("-          BOSS-FIGHT          -");
      }
    }
  }
  static void frame(string text,int time = 5){
    Console.Write(text);
    Thread.Sleep(time*10);
    Console.Clear();
  }
  static void StatMenu(){
    Console.Clear();
    Console.WriteLine("Your character:\n");
    Console.WriteLine($"Race: {herorace}");
    Console.WriteLine($"Class: {heroclass}");
    Console.WriteLine($"Health: {herohealth} \n");
    string p = (Imod > 0)? "+" : "";
    color($"Intelligence(i): {intelligence} \nModifier:{p}{Imod} ", "yellow");
    p = (Smod > 0)? "+" : "";
    color($"\n\nStrength(s): {strength} \nModifier :{p}{Smod} ", "red");
    p = (Mmod > 0)? "+" : "";
    color($"\n\nImmunity(m): {immunity} \nModifier :{p}{Mmod} ", "green");
    p = (Wmod > 0)? "+" : "";
    color($"\n\nWisdom(w): {wisdom} \nModifier: {p}{Wmod} ", "magenta");
    p = (Amod > 0)? "+" : "";
    color($"\n\nAgility(a): {agility} \nModifier: {p}{Amod} ", "blue");
    p = (Cmod > 0)? "+" : "";
    color($"\n\nCharisma(c): {charisma} \nModifier: {p}{Cmod} ", "pink");
    waitkey();
  }

   public static void Inventory()
  {
    //displays inventory
    for(int i = 0; i < inventory.Length; i++)
    {
       Console.WriteLine($"({i}) x" + itemCounts[i] + " " + inventory[i]);
    }
   
    Console.WriteLine("(2) Back");

    //check for input
    ConsoleKey key = Console.ReadKey().Key;

    if(key == ConsoleKey.D1)
    {
      if(1==1)
      {
        //we have the item > 0
      }
    }else if(key == ConsoleKey.D2)
    {
      //go back
    }
  
  }
}

