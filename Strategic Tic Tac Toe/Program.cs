using System;
using System.Collections.Generic;
using System.Threading;


class Program {
  static int[,] brd = {
    {1,2,3,10,11,12,19,20,21},
    {4,5,6,13,14,15,22,23,24},
    {7,8,9,16,17,18,25,26,27},
    {28,29,30,37,38,39,46,47,48},
    {31,32,33,40,41,42,49,50,51},
    {34,35,36,43,44,45,52,53,54},
    {55,56,57,64,65,66,73,74,75},
    {58,59,60,67,68,69,76,77,78},
    {61,62,63,70,71,72,79,80,81}
  };
  static int[] sq1 = {1,2,3,10,11,12,19,20,21};
  static int[] sq2 = {4,5,6,13,14,15,22,23,24};
  static int[] sq3 = {7,8,9,16,17,18,25,26,27};
  static int[] sq4 = {28,29,30,37,38,39,46,47,48};
  static int[] sq5 = {31,32,33,40,41,42,49,50,51};
  static int[] sq6 = {34,35,36,43,44,45,52,53,54};
  static int[] sq7 = {55,56,57,64,65,66,73,74,75};
  static int[] sq8 = {58,59,60,67,68,69,76,77,78};
  static int[] sq9 = {61,62,63,70,71,72,79,80,81};
  static List<int> Cspots = new List<int>();
  static List<int> Ospots = new List<int>();
  static List<int> Xspots = new List<int>();
  static List<int> Osquares = new List<int>();
  static List<int> Xsquares = new List<int>();
  static List<int> Dsquares = new List<int>();
  static bool player1Turn = true;
  static int number;
  static int board;
  static int space;
  static int squarenum;
  static int Space;
  
  public static void Main (string[] args) {
    fillSquares();
    drawBoard();
    fTurn();
  }
  static bool isEmpty(int a){
    return !(Osquares.Contains(a) || Xsquares.Contains(a) || Dsquares.Contains(a) || Xspots.Contains(a) || Ospots.Contains(a));
  }
  static void fillSquares(){
    Cspots.RemoveRange(0,Cspots.Count);

    for(int a = 1; a < 82; a++){
      if(isEmpty(a)){
        Cspots.Add(a);
      }
    }
  }
  static void drawBoard(){
    Console.Clear();
    
    
    for(int i = 1;i <= 81; i++){
      ConsoleColor color;
      String text;
      if(Ospots.Contains(i)){
        text = " O ";
      }else if(Xspots.Contains(i)){
        text = " X ";
      }else{
        text = " _ ";
      }

      if(Xsquares.Contains(i)){
        color = ConsoleColor.DarkBlue;
      }else if(Osquares.Contains(i)){
        color = ConsoleColor.DarkRed;
      }else if(Dsquares.Contains(i)){
        color = ConsoleColor.Yellow;
      }else{
        if(Xspots.Contains(i)){
          color = ConsoleColor.DarkBlue;
        }else if(Ospots.Contains(i)){
          color = ConsoleColor.DarkRed;
        }else if(Cspots.Contains(i)){
          color = ConsoleColor.DarkGreen;
        }else{
          color = ConsoleColor.White;
        }
      }
      if(i % 27 == 0){
        text += "\n\n";
      }else if(i % 9 == 0){
        text += "\n";
      }else if(i % 3 == 0){
        text += "   ";
      }

      Console.ForegroundColor = color;
      Console.Write(text);
      Console.ForegroundColor = ConsoleColor.White;
      
      {
      /*
      if(Ospots.Contains(i)){
        if(Xsquares.Contains(i)){
          color(" O " , ConsoleColor.DarkBlue);
        } else if (Dsquares.Contains(i)){
          color(" O " , ConsoleColor.DarkMagenta);
        } else {
          color(" O " , ConsoleColor.DarkRed);
        }
             
      } else if(Xspots.Contains(i)){
        if(Osquares.Contains(i)){
          color(" X " , ConsoleColor.DarkRed);
        } else if (Dsquares.Contains(i)){
          color(" X " , ConsoleColor.DarkMagenta);
        } else {
          color(" X " , ConsoleColor.DarkBlue);
        }
        
      } else {
        if(Xsquares.Contains(i)){
          color(" _ ", ConsoleColor.DarkBlue);
        } else if(Osquares.Contains(i)){
          color(" _j ", ConsoleColor.DarkRed);
        } else if(Dsquares.Contains(i)){
          color(" _j ", ConsoleColor.DarkMagenta);  
        
        } else if(Cspots.Contains(i)){
          color(" _j ", ConsoleColor.DarkGreen);  
        }else{
          color(" _j ",ConsoleColor.Gray);
        }
        if( Ospots.Contains(i) || Xspots.Contains(i) ){
          Cspots[Cspots.IndexOf(i)] = 999;
        }
      }
      if(i % 27 == 0){
        Console.WriteLine("\n");
      } else if(i % 9 == 0){
        Console.Write("\n");
      } else if(i % 3 == 0){
        Console.Write("   ");
      }
     */ 
        }
    }
    
  }
  static void turn(){

    drawBoard();
    checkforwin();
    if(player1Turn){
      color("Player 1",ConsoleColor.DarkRed);
      Console.WriteLine(", choose your square! :");
    } else{
      color("Player 2",ConsoleColor.DarkBlue);
      Console.WriteLine(", choose your square! :");
    } 
    
    do{
    space = getnum();
    } while(space == 10);
    place(space);
  }
  static void fTurn(){
    if(player1Turn){
      color("Player 1",ConsoleColor.DarkRed);
    } else{
      color("Player 2",ConsoleColor.DarkBlue);
    }
    Console.WriteLine(", which board do you want to place in? ");
    Console.WriteLine("Enter a number from 1-9 with 1 being the top-left corner and 9 being bottom-right");
    do{
    board = getnum();
    } while (board == 10);
    currentSquare(board);
    turn();
  }
  static void currentSquare(int Board){
    Cspots.RemoveRange(0,Cspots.Count);
    switch(Board){
      case 1:
        Cspots.AddRange(sq1);
        break;
      case 2:
        Cspots.AddRange(sq2);
        break;
      case 3:
        Cspots.AddRange(sq3);
        break;
      case 4:
        Cspots.AddRange(sq4);
        break;
      case 5:
        Cspots.AddRange(sq5);
        break;
      case 6:
        Cspots.AddRange(sq6);
        break;
      case 7:
        Cspots.AddRange(sq7);
        break;
      case 8:
        Cspots.AddRange(sq8);
        break;
      case 9:
        Cspots.AddRange(sq9);
        break;
    }
  }
  static int getnum(){
    string input = Console.ReadLine();
    bool success = Int32.TryParse(input, out number);
    if(success && number > 0 && number <= 9){
      return Convert.ToInt32(number);
    } else {
      Console.WriteLine("You have entered an invalid value.");
      Console.WriteLine("Enter another number:");
      return 10;
    }
  }
  static void place(int spot){
    int currentSpot = Cspots[spot - 1];
    if(Xspots.Contains(currentSpot) || Ospots.Contains(currentSpot)){
      Console.WriteLine("That spot is already taken. Enter another number");
      do{
        Space = getnum();
      } while (Space == 10);
      place(Space);
    }
    if(player1Turn){
      Ospots.Add(currentSpot);
    } else {
      Xspots.Add(currentSpot);
    }
    
    if(player1Turn){
      player1Turn = false;
    } else {
      player1Turn = true;
    }
    currentSquare(spot);
    check3row();
    squarenum = findSquares(currentSpot);
    if(Xsquares.Contains(squarenum) || Osquares.Contains(squarenum) || Dsquares.Contains(squarenum)){
      fillSquares();
      drawBoard();
      fTurn();
    } else {
      drawBoard();
      turn();
    }
    
  }
  static int findSquares(int spot){
    int num = findSquare(spot, sq1);
    if(num != 1203){ return num;}
    num = findSquare(spot, sq2);
    if(num != 1203){ return num;}
    num = findSquare(spot, sq3);
    if(num != 1203){ return num;}
    num = findSquare(spot, sq4);
    if(num != 1203){ return num;}
    num = findSquare(spot, sq5);
    if(num != 1203){ return num;}
    num = findSquare(spot, sq6);
    if(num != 1203){ return num;}
    num = findSquare(spot, sq7);
    if(num != 1203){ return num;}
    num = findSquare(spot, sq8);
    if(num != 1203){ return num;}
    num = findSquare(spot, sq9);
    if(num != 1203){ return num;}
    else{
      return 1204; 
    }
  }
  static int findSquare(int spot, int[] sq){
    if(Array.IndexOf(sq ,spot) == 0){
      return 1;
    }else if(Array.IndexOf(sq ,spot) == 1){
      return 4;
    } else if(Array.IndexOf(sq ,spot) == 2){
      return 7;
    } else if(Array.IndexOf(sq ,spot) == 3){
      return 28;
    } else if(Array.IndexOf(sq ,spot) == 4){
      return 31;
    } else if(Array.IndexOf(sq ,spot) == 5){
      return 34;
    } else if(Array.IndexOf(sq ,spot) == 6){
      return 55;
    } else if(Array.IndexOf(sq ,spot) == 7){
      return 58;
    } else if(Array.IndexOf(sq ,spot) == 8){
      return 61;
    } else {
      return 1203;
    }
    
  }
  
  static void color(string text, ConsoleColor Ccolor){
    Console.ForegroundColor = Ccolor;
    Console.Write( text );
    Console.ForegroundColor = ConsoleColor.White;
  }
  static void check3row(){
    checksquare(sq1);
    checksquare(sq2);
    checksquare(sq3);
    checksquare(sq4);
    checksquare(sq5);
    checksquare(sq6);
    checksquare(sq7);
    checksquare(sq8);
    checksquare(sq9);
    
  }
  static void checksquare(int[] list){
    int counter = 0;
    foreach(int i in list){
      if(Ospots.Contains(i) || Xspots.Contains(i)){
        counter++;
      }
    }
    if(counter < 3){
      return;
    }
    if(c(list[0],1)){
      if((c(list[1],1) && c(list[2],1)) || (c(list[3],1) && c(list[6],1)) || (c(list[4],1) && c(list[8],1))){
        foreach(int i in list){
          if(!(Xsquares.Contains(i))){
            Xsquares.Add(i);
          }
        }
      }
    } if(c(list[1],1)){
       if((c(list[4],1) && c(list[7],1))){
        foreach(int i in list){
          if(!(Xsquares.Contains(i))){
            Xsquares.Add(i);
          }
        }
      }
    } if(c(list[2],1)){
      if((c(list[4],1) && c(list[6],1)) || (c(list[5],1) && c(list[7],1))){
        foreach(int i in list){
          if(!(Xsquares.Contains(i))){
            Xsquares.Add(i);
          }
        }
      }
    } if(c(list[3],1)){
      if((c(list[4],1) && c(list[5],1))){
        foreach(int i in list){
          if(!(Xsquares.Contains(i))){
            Xsquares.Add(i);
          }
        }
      }
    } if(c(list[6],1)){
        if((c(list[7],1) && c(list[8],1)) ){
        foreach(int i in list){
          if(!(Xsquares.Contains(i))){
            Xsquares.Add(i);
          }
        }
      }
    }
    if(c(list[0],2)){
      if((c(list[1],2) && c(list[2],2)) || (c(list[3],2) && c(list[6],2)) || (c(list[4],2) && c(list[8],1))){
        foreach(int i in list){
          if(!(Osquares.Contains(i))){
            Osquares.Add(i);
          }
        }
      }
    } if(c(list[1],2)){
      if((c(list[4],2) && c(list[7],2))){
        foreach(int i in list){
          if(!(Osquares.Contains(i))){
            Osquares.Add(i);
          }
        }
      }
    } if(c(list[2],2)){
      if((c(list[4],2) && c(list[6],2)) || (c(list[5],2) && c(list[7],1))){
        foreach(int i in list){
          if(!(Osquares.Contains(i))){
            Osquares.Add(i);
          }
        }
      }
    } if(c(list[3],2)){
      if((c(list[4],2) && c(list[5],2))){
        foreach(int i in list){
          if(!(Osquares.Contains(i))){
            Osquares.Add(i);
          }
        }
      }
    } if(c(list[6],2)){
        if((c(list[7],2) && c(list[8],2)) ){
        foreach(int i in list){
          if(!(Osquares.Contains(i))){
            Osquares.Add(i);
          }
        }
      }
    }
                                                                   
                                                     
     if(counter >= 9){
      foreach(int i in list){
        Dsquares.Add(i);
      }
    }
  }
  static void checkforwin(){
    int counter = Xsquares.Count + Osquares.Count;
    
    if(counter < 27){
      return;
    }
    if(C(1,1)){
      if((C(4,1) && C(7,1)) || (C(31,1) && C(61,1)) || (C(28,1) && C(55,1))){
        Xwin();
      }
    } if(C(4,1)){
       if((C(31,1) && C(58,1))){
        Xwin();
      }
    } if(C(7,1)){
      if((C(31,1) && C(55,1)) || (C(34,1) && C(61,1))){
        Xwin();
      }
    } if(C(28,1)){
      if((C(31,1) && C(34,1))){
        Xwin();
      }
    } if(C(55,1)){
        if((C(58,1) && C(61,1)) ){
        Xwin();
      }
    }
    if(C(1)){
      if((C(4) && C(7)) || (C(31) && C(61)) || (C(28) && C(55))){
        Owin();
      }
    } if(C(4)){
       if((C(31) && C(58))){
        Owin();
      }
    } if(C(7)){
      if((C(31) && C(55)) || (C(34) && C(61))){
        Owin();
      }
    } if(C(28)){
      if((C(31) && C(34))){
        Owin();
      }
    } if(C(55)){
        if((C(58) && C(61)) ){
        Owin();
      }
    }
                                                                   
                                                     
    if(counter >= 81){
      Draw();
    }
  }
  static void print(List<int> list){
    Console.Write("list has:" );
    foreach(int i in list){
      
      Console.Write( i + " , ");
      
    }
    Console.WriteLine("");
  }
  static bool c(int val, int xo = 0){
    if(xo == 1){
      if(Xspots.Contains(val)){
        return true;
      } else {
        return false;
      }
    } else{
      if(Ospots.Contains(val)){
        return true;
      } else {
        return false;
      }
    }
  }
  static void Xwin(){
    color("Player 2 has won the game!", ConsoleColor.DarkBlue);
    Thread.Sleep(100000);
  }
  static void Owin(){
    color("Player 1 has won the game!", ConsoleColor.DarkBlue);
    Thread.Sleep(100000);
  }
  static void Draw(){
    color("The game ended in a draw", ConsoleColor.DarkMagenta);
    Thread.Sleep(100000);
  } 
  static bool C(int val, int xo = 0){
    if(xo == 1){
      if(Xsquares.Contains(val)){
        return true;
      } else {
        return false;
      }
    } else{
      if(Osquares.Contains(val)){
        return true;
      } else {
        return false;
      }
    }
  }
}