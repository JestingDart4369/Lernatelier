//63 Felder ohgne start
//5,9,23,41,45,54 Gans rückblick
//14,18,27,32,36,50,59 Gans vor
//6 Brücke,19 Gasthaus, 31 Brunne, 42 Maze, 52 Prison, 58 Dead, 63 finish
// Brücke nochmal würfeln,gans rückblich zurück auf das vorherige feld,gans in laufrichtung nochmal würfeln, Gasthaus einmal aussetzen, brunne nochmal würfeln,labirint ausetzen, gefängnis usetze,tote gangs nochmal von anfanfang
//only get in if right number
bool finish = false;
static void Game()
{
    //Facts
    int[] GooseBack = new int[] { 5, 9, 23, 41, 45, 54 };
    int[] GooseForward = new int[] { 14, 18, 27, 32, 36, 50, 59 };
    //Variabels
    int players = 0;
    int playerNow = 0;
    bool finish = false;
    int[] postionPlayers = new int[4] { 0, 0, 0, 0 };
    int role = 0 ;
    bool[] playertimeout = new bool[4] { false, false, false, false };
    Console.WriteLine("Willkomen Beim Gänse Spiel :)");
    Console.WriteLine("Bitte geben sie an von 1-4 Wie viele Spieler sie sind.");
    players = System.Convert.ToInt32(Console.ReadLine());
    while (players == 0) ;
    do
    {
        if (playerNow >= players)
        {
            Console.WriteLine("Diese Runde Ist vorbei Hier ein zwischenstand:");
            int playerCounterEndOfRound = 0;
            for (int i = 1; i < players; i++)
            {
                Console.WriteLine("Der Spieler " + i + " Ist auf der positzion " + postionPlayers[playerCounterEndOfRound] + ".");
                int playerCounterRound = playerCounterEndOfRound + 1;
            }
            playerNow = 0;
        }else
        if (playertimeout[playerNow] == true)
        {
            Console.WriteLine("Du Must Ausetzen Sory:(");
            playertimeout[playerNow] = false;
            playerNow = playerNow + 1;
        }
        else
        {

            //runde 
            Console.WriteLine("Hallo Spieler " + (playerNow + 1) + " Du bist an der Reihe");
            Console.WriteLine("Gib bite ein was du gewürfelt hast");
            role = System.Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Du hast ne " + role + " Gewürfelt");
            int tempplace = postionPlayers[playerNow] + role;
            Console.WriteLine("OK Du gehst von " + postionPlayers[playerNow] + " Zu " + tempplace);
            if (tempplace > 63)
            {
                Console.WriteLine("Oh Du bist über das ziel hinaus wie schade du must um " + (tempplace - 63) + "Zurückgehen und Komst auf das feld" + (63 - (tempplace - 63)));
                tempplace = 63 - (tempplace - 63);
            }
            if (GooseBack.Contains(tempplace))
            {
                Console.WriteLine("Du bist auf einer rückwärt ente geladet du gehst wider auf dein voheriges Feld");
            }
            else
            {
                postionPlayers[playerNow] = tempplace;
            }

            if (GooseForward.Contains(tempplace))
            {
                Console.WriteLine("Du bist auf einer nach vorne Sehenden Ente Gelandet du darfst nochmal");
                playerNow = playerNow - 1;
            }

            if (tempplace == 6)
            {
                Console.WriteLine("Du Bist auf Der Brücke gelandet du darfst nochmal");
                playerNow = playerNow - 1;
            }

            if (tempplace == 19)
            {
                Console.WriteLine("Du Bist Auf Dem Gasthaus Gelandet du must eine Runde Ausetzen");
                playertimeout[playerNow] = true;
            }
            if (tempplace == 31)
            {
                Console.WriteLine("Du Bist auf dem Brunnen Gelandet du Darft nochmal würfeln");
                playerNow = playerNow - 1;
            }
            if (tempplace == 42)
            {
                Console.WriteLine("Du Bist Auf dem labirit Gelandet du must eine runde Ausetzen");
                playertimeout[playerNow] = true;
            }
            if (tempplace == 52)
            {
                Console.WriteLine("Du bist auf dem Gefängnis gelandet du must eine runde ausetzen");
                playertimeout[playerNow] = true;
            }
            if (tempplace == 58)
            {
                Console.WriteLine("Du Bist auf der toten ganns gelandet du must nochmal an den start");
                postionPlayers[playerNow] = 0;
            }
            if (tempplace == 63)
            {
                Console.WriteLine("Du hast es in das ziel geschaft Supper:) Du Spiler " + playerNow + " Hast Gewonnen");
                finish = true;
            }
            playerNow = playerNow + 1;

        }

        
    } while (finish == false);
}
do
{
    Game();
    Console.WriteLine("Möchten Sie nochmal spielen Ja(1) Nein(2)");
    int x = System.Convert.ToInt32(Console.ReadLine());
    if (x == 2)
    {
        finish = true;
    }
} while (finish == false);
