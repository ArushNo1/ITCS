using System;
using System.Threading;


class Program {
  static bool hasKnife = false; 
  static bool hasChisel = false;
  static bool seenPainting = false;
  static bool clayGone = false;
  static bool bronzeKey = false;
  static bool hasr1 = false;
  static bool hasr2 = false;
  static bool hasr3 = false;
  static bool seenRocks = false;
  static bool istired = false;
  static int stepsbuilt = 0;
  static bool hasRock = false;
  static bool seenMouse = false;
  static bool seenDoor = false;
  static bool hasRing = false;
  static Random rand = new Random();

  static string[] chars ={"a","d","e","f","g","h","i","j","l","m","o","p","q","r","v","w","x","y","z","A","D","E","F","G","H","I","J","K","L","M","O","Q","R","S","U","W","X","Y","Z","1","2","4","5","0","!","@","#","$","^","&","*","-","=","/","|","?","<",";",":","[",",","`","~"};
  static void Main (string[] args) {
    
    Start();
  }
  static void Start(){
    init();
    Console.WriteLine("You wake up in a cold, dark room. You feel dazed and don't remember anything.");
    Console.WriteLine("You can't even remember your own name... ");
    waitkey();
    
    init();
    Console.WriteLine("To select an option, either enter the letter in parentheses or the number of the option.");
    waitkey();
    MainMenu();
    
  }
  static void MainMenu(bool invalid = false){
    init();
    Console.WriteLine("A torch ignites on the wall nearby, filling the room with light");
    Console.WriteLine("(u) 1. Look up");
    Console.WriteLine("(l) 2. Look to the left");
    Console.WriteLine("(r) 3. Look to the right");
    Console.WriteLine("(f) 4. Look forward");
    Console.WriteLine("(d) 5. Look down");
    Console.WriteLine("(s) 6. Save/load game");
    string answer = input(invalid);
    if(answer == "1" || answer == "u"){
      MainUp();
    } else if(answer == "2" || answer == "l") {
      MainLeft();
    } else if(answer == "3" || answer == "r") {
      MainRight();
    } else if(answer == "4" || answer == "f") {  
      MainFront();
    } else if(answer == "5" || answer == "d") {  
      MainDown();
    } else if(answer == "6" || answer == "s") {
      SaveLoad();
    } else{  
      MainMenu(true);
    }
    
}

  static void SaveLoad(){
    init();
    Console.WriteLine("Enter code (type \"save\" to get a code and \"exit\" to go back):");
    string code = Console.ReadLine();
    if(code == "exit"){
      MainMenu();
    } else if((code == "" || !(Char.IsNumber(code, code.Length - 1))) && code != "save"){
      keycontinue(true,true);
      SaveLoad();
    } else if(code == "save"){code="";if(hasKnife){code+="kN";}if(hasChisel){code+="%c";}if(seenPainting){code+="P+";}if(clayGone){code+="7t";}if(bronzeKey){code+="]3";}if(hasr1){code+="6V";}if(hasr2){code+="us";}if(hasr3){code+="C9";}if(seenRocks){code+="b@";}if(seenMouse){code+="BT";}if(seenDoor){code+=">.";}if(hasRing){code+="8n";}
      
      do {
        int randint = rand.Next(chars.Length);
        code += chars[randint];
      } while(code.Length <= 19 );
      code += Convert.ToString(stepsbuilt);
      Console.WriteLine($"Your save code is {code}\n To copy it, highlight it and right click, Ctrl+C/V will not work.");
      
      
      waitkey();
      MainMenu();
    } else {
      stepsbuilt = code[code.Length - 1];hasKnife = code.Contains("kN");hasChisel = code.Contains("%c");seenPainting = code.Contains("P+");clayGone = code.Contains("7t");bronzeKey = code.Contains("]3");hasr1 = code.Contains("6V");hasr2 = code.Contains("us");hasr3 = code.Contains("C9");seenRocks = code.Contains("b@");seenMouse = code.Contains("BT");seenDoor = code.Contains(">.");hasRing = code.Contains("8n");
      Console.WriteLine("Your save has been uploaded");
      waitkey();
      MainMenu();
    }
    
  }

  static void MainLeft(bool invalid = false){
    init();
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("On your left, there is a ");
    colortxt("door",ConsoleColor.DarkMagenta);
    Console.WriteLine(".");
    Console.WriteLine("(b) 1. Back");
    Console.WriteLine("(d) 2. Inspect the door");
    string answer = input(invalid);
    if(answer == "1" || answer == "b"){
      MainMenu();
      
    } else if(answer == "2" || answer == "d") {  
      LeftDoor();
    } else {  
      MainLeft(true);
    }
   }
  
  static void LeftDoor(bool invalid = false){
    //Match door from blobkeep and inspectdoor/magKey
    if(hasr1){
      seenDoor = true;
    }
    init();
    Console.Write("The ");
    
    colortxt("door", ConsoleColor.DarkMagenta);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" is made of some material that looks and feels like smooth plastic. It is pink colored and cool to the touch. It seems there are some sort of archaic runes inscribed in the door. You try opening it, but it is locked. It is too strong to smash through.");
    if(hasr1){
      Console.WriteLine(" You can sort of make out the runes on the door. You think this is because of the strange rock that flew at you. They say something about how triangles are best or something along those lines.");
    }else{
      Console.WriteLine("");
    }
    Console.WriteLine("(b) 1. Back");
    Console.WriteLine("(o) 2. Try opening the door");
    string answer = input(invalid);
    
    if(answer == "1" || answer == "b"){
      MainLeft();
    } else if(answer == "2" || answer == "o"){
      OpenDoor();
    } else {

      LeftDoor(true);
    }
    
  }

  static void OpenDoor(){
    init();
    if(hasr1){
      Console.WriteLine("The glass shards you have look like they could fit in the keyhole on the door. ");
    }
    if(hasr1 && hasr2 && hasr3){
      end();
    } else if(hasr1 && hasr2){
      Console.WriteLine("You put the two shards you have in the keyhole, and they stay in for a little while. As you are about to leave, the shards fly out of the door and land on the floor behind you. You pick them up.");
      waitkey();
      LeftDoor();
    } else if(hasr1){
      Console.WriteLine("You notice that the object that almost hit you is the exact same shade of pink as the door. You try to put it into the keyhole, but as soon as you let go, the shard flies out of the door and lands in your hand.");
      waitkey();
      LeftDoor();
    } else if(hasKnife){
      Console.WriteLine("You think you could try to pick the door's lock with your knife. When you try to pick the lock, you notice your knife's blade is completely deformed. As you leave the room discouraged, you notice that your knife is somehow as good as knew again.");
      waitkey();
      LeftDoor();
    } else {
      Console.WriteLine("There is nothing you have that you could use to open the door.");
      waitkey();
      LeftDoor();
    }
    
  }
  static void end(){
    init();
    Console.WriteLine("You put the three pink shards you have. They fit perfectly in the keyhole in the door, and they seem to dissapear into it. The door flies open and you walk through it.");
    waitkey();
    init();
    Console.WriteLine("You notice that your hands are gone, and that they are replaced by blue blobs. You also see that you are holding a sword and bow in your blob hands. But there is no time to think about that now. You are surrounded by dark blue slime-looking creatures, and they are all waiting to kill you.");
    waitkey();
    Console.WriteLine("The game continues at https://pixel1l.github.io/Blobkeep/");
  }
  static void MainRight(bool invalid = false){
    init();
    Console.WriteLine("There is a painting on the wall next to you. You try to look behind the painting, and there seems to be something behind.");
    Console.WriteLine("(b) 1. Back");
    Console.WriteLine("(p) 2. Inspect the painting");
    if((seenPainting) && !(clayGone)) { 
      Console.WriteLine("(c) 3. Inspect the clay");
    }
    
    
    
    string answer = input(invalid);
    if(answer == "1" || answer == "b"){
      MainMenu();
    } else if(answer == "2" || answer == "p"){
      seenPainting = true;
      RightPainting();
      
    } else if((seenPainting) && (answer == "3" || answer == "c")){
      RightClay();
    
    } else {

      MainRight(true);
    }  
  }
  static void RightPainting(bool invalid = false){
    init();
    Console.Write("The painting was made with oil paints, and is painted on a wooden board. The wooden board ");
    if(clayGone){
      Console.Write("used to be ");
    } else{
      Console.Write("is ");
    }
    Console.Write("held to the wall by rock-like ");
    colortxt("clay.",ConsoleColor.Red,true);
    Console.WriteLine("(b) 1. Back");
    if(!(clayGone)){
    Console.WriteLine("(c) 2. Inspect the clay");
    }
    if(clayGone){
      Console.WriteLine("(w) 2. Pull open the wooden board");
    }
    
    
    string answer = input(invalid);
    if(answer == "1" || answer == "b"){
      MainRight();
    } else if((answer == "2" || answer == "c")&& !(clayGone)){
      RightClay();
    } else if((answer == "2" || answer == "w") && (clayGone)){
      PaintingOpen();
    } else {

      RightPainting(true);
    }
  }
  static void PaintingOpen(bool invalid = false){
    init();
    
    Console.Write("You pull on the painting, and the wooden board hinges open with a creak.");
    if(!(hasKnife)){
      Console.Write("Behind it you find a small"); 
      colortxt(" pocket knife",ConsoleColor.Green);
      Console.Write(", and you pick it up.");
      hasKnife = true;
    }
    Console.Write(" There is also a ");
    colortxt("bronze", ConsoleColor.Yellow);
    Console.WriteLine(" lock attached to some sort of metal box.");
    Console.WriteLine("(b) 1. Back");
    if(bronzeKey){
      Console.Write("(z) 2. Open the ");
      colortxt("bronze",ConsoleColor.Magenta);
      Console.WriteLine(" lock with your key");
    }
    string answer = input(invalid);
    if(answer == "1" || answer == "b"){
      RightPainting();
    } else if(answer == "2" || answer == "z" && bronzeKey ) {
      BronzeLock();
    } else {

      PaintingOpen(true);
    }
  }
  static void BronzeLock(){
    Console.WriteLine("You put the key into the lock, and it pops open. You open the metal box that it's attached to. Inside, there is another pink shard inside, just like the first.");
    hasr2 = true;
    waitkey();
    PaintingOpen();
  }
  static void RightClay(bool invalid = false){
    init();

    
    Console.Write("The painting is held to the wall by four clay bits on the corners. The"); 
    colortxt(" clay ", ConsoleColor.Red);
    Console.Write("is a light tan-red color and is brittle. The bits could be broken with a handheld"); 
    colortxt(" tool", ConsoleColor.Green); 
    Console.WriteLine(".");
    Console.WriteLine("(b) 1. Back");
    if((hasChisel && !(clayGone))){
      Console.Write("(c) 2. Use your "); 
      colortxt("chisel ",ConsoleColor.Green);
      Console.WriteLine("to break the clay");
    }
    
    string answer = input(invalid);
    if(answer == "1" || answer == "b"){
      MainRight();
    } else if((answer == "2" || answer == "c") && (hasChisel)){
      ClayBreak();
    } else {

      RightClay(true);
    }
  }
  static void ClayBreak(){
    init();
    clayGone = true;
    Console.Write("You hit the ");
    colortxt("clay",ConsoleColor.Red);
    Console.Write(" with your ");
    colortxt("chisel",ConsoleColor.Green);
    Console.WriteLine(". It breaks into pieces and crubles onto the floor");
    waitkey();
    MainRight();
  }
  
  static void MainDown(bool invalid = false){
    init();
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Below you there is a ");
    colortxt("red carpet.",ConsoleColor.DarkRed);
    Console.WriteLine(".");
    Console.WriteLine("(b) 1. Back");
    Console.WriteLine("(c) 2. Inspect the carpet");
    

    string answer = input(invalid);
    if(answer == "1" || answer == "b"){
      MainMenu();
    }else if(answer == "2" || answer == "c"){
      DownCarpet();
    } else{  
      MainDown(true);
    }
  }
  static void DownCarpet(bool invalid = false){
    init();
    Console.WriteLine("The carpet is a deep red color and is about half of an inch thick.");
    Console.WriteLine("(b) 1. Back");
    Console.WriteLine("(p) 2. Pull the carpet");
    if (seenRocks){
      Console.WriteLine("(r) 3. Pick up a rock");
    }

    string answer = input(invalid);
    if(answer == "1" || answer == "b"){
      MainDown();
    } else if(answer == "2" || answer == "p"){
      CarpetPull();
    } else if((answer == "3" || answer == "r") && seenRocks) {
      rockuptxt();
      DownCarpet();
    } else{
      DownCarpet(true);
    }
  }
  static void CarpetPull(){
    init();
    if(hasRing){
      Console.Write("Now that the rocks are gone, you can see clearly in the hole in the floor. You look carefully under the carpet, and see that there is a metal rod with spikes on it. The spikes look like the ones that could be on a key, and the rod itself is made of the same");
      colortxt(" bronze ",ConsoleColor.Magenta);
      Console.WriteLine("As the ring you picked up earlier. You put the two next to each other in your hands, and sure enough they click together");
      bronzeKey = true;
      waitkey();
      DownCarpet();
    } else if (hasKnife){
      if(!(seenRocks)){
        seenRocks = true;
        Console.WriteLine("You cut the glue from the corner of the carpet and pull it up. You do not see anything, so you pull the entire carpet off of the floor. ");
      } 
      Console.WriteLine("Underneath the carpet, there is a big pile of rock slabs that you could carry, but would take most of your strength.");

      waitkey();
      DownCarpet();
    } else {
      Console.WriteLine("The carpet is glued down. You are unable to pull it up.");
      waitkey();
      DownCarpet();
    }
  }
  static void MainFront(bool invalid = false){
    init();
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("In front of you, there is a");
    colortxt(" bed ", ConsoleColor.DarkGreen);
    Console.Write("with a blanket and pillow.");
    Console.Write("In the wall, there is a ");
    colortxt("mouse hole",ConsoleColor.DarkGray);
    Console.WriteLine(".");
    Console.WriteLine("(b) 1. Back");
    Console.WriteLine("(m) 2. Inspect the mouse hole");
    Console.WriteLine("(i) 3. Inspect the Bed");
    
    
    
    string answer = input(invalid);
    if(answer == "2" || answer == "m"){
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.White;
      if(!(hasChisel) && seenPainting){
        
        Console.Write("It seems there is a ");
        colortxt("chisel",ConsoleColor.Green);
        Console.WriteLine(" in the mouse hole. How strange!");
        colortxt("You pick up the chisel.", ConsoleColor.Red,true);
        hasChisel = true;
        waitkey();
        MainFront();
      } else {
        if(hasr2){
          seenMouse = true;
        }
        Console.Write("The ");
        colortxt("mouse hole", ConsoleColor.DarkGray);
        Console.WriteLine(" is empty.");
        waitkey();
        MainFront();
      }
      
    } else if(answer == "3" || answer == "i"){
      FrontBed();
    }else if(answer == "1" || answer == "b"){
      MainMenu();
    } else{ 
      MainFront(true);
    }
  }
  static void FrontBed(bool invalid = false){
    init();
    Console.Write("On the ");
    colortxt("bed ", ConsoleColor.DarkGreen);
    Console.WriteLine("there is a red, soft, blanket and a pillow filled with feathers.");
    Console.WriteLine("(b) 1. Back");
    Console.WriteLine("(l) 2. Lift the blanket");
    if(hasKnife && hasr1 && seenDoor){
      Console.Write("(s) 3. Stab the pillow with your");
      colortxt(" knife",ConsoleColor.Green,true);
    }

    string answer = input(invalid);
    if(answer == "1" || answer == "b"){
      MainFront();
    } else if(answer == "2" || answer == "l"){
      BlanketLift();
    } else if((answer == "3" || answer == "s") && (hasKnife) && (hasr1) && seenDoor){
      PillowRip();
    } else {

      FrontBed(true);
    }
  
  }
  static void PillowRip(){
    init();
    Console.Write("You stab the pillow with your ");
    colortxt("knife", ConsoleColor.Green);
    Console.Write(" and the feathers inside come flying out. After you shake the empty pillowcase, you notice that there is a ");
    colortxt("bronze", ConsoleColor.Magenta);
    Console.WriteLine(" ring inside. You don't know what it is for, so you put it in your pocket.");
    hasRing = true;
    waitkey();
    FrontBed();
  }
  static void BlanketLift(){
    Console.Write("You pull up the blanket.");
    if(hasr2 && seenMouse){
      Console.WriteLine(" Underneath, you see a third pink shard. You pick up the shard.");
      hasr3 = true;
    } else{
      Console.WriteLine(" There is nothing under it.");
    }
    waitkey();
    FrontBed();
  }
  
  static void MainUp(bool invalid = false){
    init();
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Above you there is a ");
    colortxt("wooden trapdoor", ConsoleColor.DarkYellow);
    Console.WriteLine(", but you cannot reach it. The rest is just a cobblestone ceiling");
    Console.WriteLine("(b) 1. Back");
    if(seenRocks && !(stepsbuilt > 8 ) && (hasRock)){
      Console.WriteLine("(r) 2. Place down a rock");
    }
    if((stepsbuilt >= 8 ) && !(hasRock)){
      Console.WriteLine("(c) 2. Climb up to the trapdoor using the staircase");
    }
    //Once implemented, add a option to place ladder/climb up to trapdoor
    
    string answer = input(invalid);
    if(answer == "1" || answer == "b"){
      MainMenu();
    } else if((answer == "2" || answer == "r") && !(stepsbuilt >= 8) && (seenRocks) && (hasRock)){
      PlaceRock();
    } else if((answer == "2" || answer == "c") && (stepsbuilt >= 8)){
      ClimbCase();
    } else{  
      MainUp(true);
    }
    
  }
  static void PlaceRock(){
    init();
    hasRock = false;
    stepsbuilt += 1;
    switch(stepsbuilt){
      case 1:
        Console.WriteLine("You place down the first rock on the floor.");
        waitkey();
        break;
      case 2:
        Console.WriteLine("You place another rock on the first, so that you can step up onto the second.");
        waitkey();
        break;
      case 3:
        Console.WriteLine("You place another rock down on the pile.");
        waitkey();
        break;
      case 4:
        Console.WriteLine("You place down a fourth slab on the staircase. It is now halfway to to the ceiling.");
        waitkey();
        break;
      case 5:
        Console.WriteLine("After placing the fifth rock, you are over 5 feet above the ground when on top of the staircase.");
        waitkey();
        break;
      case 6:
        Console.WriteLine("Placing the sixth rock allows you to almost be able to reach the trapdoor's handle");
        waitkey();
        break;
      case 7:
        Console.WriteLine("You place down a 7th slab on the pile. You can now open the trapdoor, but you can't see what's above.");
        waitkey();
        break;
      case 8:
        Console.WriteLine("You place the eighth rock down. after climbing up the pile, you think you could reach the trapdoor and climb up");
        waitkey();
        break;
      case 9:
        Console.WriteLine("There is no space to put a ninth rock on the staircase. It already reaches the ceiling.");
        waitkey();
        stepsbuilt -= 1;
        break;
    }
  Thread tiredtimer = new Thread(Program.tired);
  tiredtimer.Start();
  MainUp();
  }

  static void ClimbCase(){
    init();
    Console.WriteLine("You climb up the staircase that you built with the rock slabs. At the top, you can just barely reach the trapdoor and climb through the ceiling. At the top, You notice that there are no walls around you, and that you can see all the way to the horizon.");
    waitkey();
    if(hasr1) {
      MainUp();
    } else {
    init();
    Console.WriteLine("As you are staring at sky, you remember that you need to escape this place. Memories of the boat, the city, and the guards all come back to you as you remember some of your past.");
    waitkey();
    init();
    Console.WriteLine("You are straining to recall more of who you are when you notice some kind of small speck in the air. It grows bigger and bigger, and then you realize that it's a rock flying at you. You catch it just before it hits you in the head.");
    waitkey();
    init();
    Console.WriteLine("Upon further inspection, you see that the rock is a deep pink color, and has runes matching the door you saw earlier. You put it in your pocket and climb back down");
    waitkey();
    hasr1 = true;
    MainUp();
    }
  }

  static void keycontinue(bool save = false,bool wait = false){
    if(save){
      colortxt("\nPlease enter a valid code",ConsoleColor.DarkGreen, true);
    } else {
      colortxt("Please choose a valid response",ConsoleColor.DarkGreen, true );
    }
    if(wait){
      waitkey();
    }
    return;
    
      
  }    
  static void rockuptxt(){
    init();
    if(hasRock){
    Console.WriteLine("You are already holding a rock slab, and cannot carry any more.");
      waitkey();
      return;
    } else if(istired){
      Console.WriteLine("You are too tired to pick up a rock right now.");
      waitkey();
      return;
    } else {
      Console.WriteLine("You pick up a rock");
      waitkey();
      Thread rocktimer = new Thread(Program.rockup);
      rocktimer.Start();
      return;
    }
  }
  static void rockup(){
    
    
    hasRock = true;
    Thread.Sleep(15000);
    if(hasRock){
    init();
    Console.WriteLine("You have become tired from carrying the rock. You have to put it down.");
    waitkey();
    hasRock = false;
    Thread tiredtimer = new Thread(Program.tired);
    tiredtimer.Start();
    MainMenu();
    }
  }
  static void tired(){
    istired = true;
    Thread.Sleep(15000);
    istired = false;
  }

  static void colortxt(string text, ConsoleColor Ccolor, bool enter = false){
    
    Console.ForegroundColor = Ccolor;
    if(enter){
      Console.WriteLine(text);
    } else {
      Console.Write(text);
    }
    Console.ForegroundColor = ConsoleColor.White;
  }
  static string input(bool invalid = false){
    if(invalid){
      keycontinue();
    }
    colortxt("Enter Choice: ",ConsoleColor.Cyan);
    string answer = Console.ReadLine();
    return answer;
  } 
  static void init(){
    Console.Clear();
    Console.Write("\n\n");
    Console.ForegroundColor = ConsoleColor.White;
    
  }
  static void waitkey(){
    colortxt("Press any key to contine", ConsoleColor.Blue, true);
    Console.ReadKey();
    Console.Clear();
  }
    
}
  
