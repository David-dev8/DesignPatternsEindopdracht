# DesignPatternsEindopdracht

Voor het ontwikkelen van de code binnen dit project zijn de volgende codeconventies gebruikt: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions.



<h2>Configuratie</h2>

Om de applicatie te kunnen opstarten zijn de volgende dingen nodig:

- Microsoft Visual studio 2022, waarbij in de installer de volgende workload moet worden geïnstalleerd: .NET desktop development.
- De volgende NuGet packages moeten binnen het project aanwezig zijn:
  - SharpVectors - Elinam LLC, versie 1.7.7



<h2>Gekozen design patterns</h2>

In het schaakspel zijn verschillende design patterns gebruikt, elk met hun eigen functie en doel. Een lijst van de gebruikte patterns binnen dit project is hieronder te vinden. In de opdracht binnen het moduleboek staat dat er minimaal vier patterns moeten worden gebruikt. Wanneer er maar vier van de patterns hoeven worden beoordeeld voor het onderdeel "Gebruik van
design patterns" binnen de scoring rubrics, moeten de bovenste vier worden genomen.

- **Commands** - Om een schaakstuk naar legale posities te laten bewegen, wordt er gebruikgemaakt van commands. Hierbij worden eerst alle mogelijkheden opgehaald voor een bepaald schaakstuk, door middel van de MovementPatterns die het betreffende schaakstuk bezit. Deze mogelijkheden worden vervolgens voor de speler op het bord getoond, waardoor de speler de gewenste zet kan uitvoeren. Het uitvoeren van de zet wordt mogelijk gemaakt in de command Move met de "Make" methode. Daarnaast heeft deze command een "Undo" methode om de uitgevoerde actie ongedaan te maken.

- **Abstract factory** - Binnen dit project wordt gebruikgemaakt van een abstract factory: PieceFactory. Deze factory creëert verschillende schaakstukken met verschillende eigenschappen. Hierin wordt bijvoorbeeld een toren gemaakt met de movement StraightLineMovement. Er is voor een abstract factory gekozen omdat het algemene type schaakstukken voor elk spel hetzelfde zijn (koning, koningin), alleen elk type kan andere eigenschappen bevatten voor een bepaalde gamemodus. Door dit concept toe te passen kunnen er dus verschillende factories worden gemaakt die dezelfde familie van producten returnen, maar waarbij wel de producten andere eigenschappen bevatten. De gamemodus "Classical chess" bevat bijvoorbeeld schaakstukken met de standaard eigenschappen en de gamemodus "Corrupt chess" bevat schaakstukken die andere movements bezitten. Zo kan een toren bijvoorbeeld bij deze modus diagonaal bewegen. Door een abstract factory te gebruiken, maakt het de code die ermee werkt niet uit welke stukken precies gemaakt worden. 

- **Strategy pattern** - Elk type schaakstuk heeft een aparte movement, zo kan een toren normaalgesproken horizontaal en verticaal bewegen en kan een loper diagonaal verplaatsen. Om dit gedrag van het schaakstuk zelf los te koppelen, is ervoor gekozen om een strategy pattern toe te passen, waardoor het mogelijk is om dynamisch een movement te gebruiken. Hierdoor kan elk stuk een andere beweging krijgen, wat nuttig is bij bijvoorbeeld "Corrupt chess". Dankzij de strategy zijn de verschillende movements ook heel makkelijk herbruikbaar. Een koningin gebruikt bijvoorbeeld net als de toren een beweging voor een rechte lijn.

- **Template method** - Binnen het project is een abstracte gameklasse gemaakt die als basis dient voor elke gamemodus. Hierin is een template method te vinden, genaamd "MakeMove". Binnen deze methode wordt gebruikgemaakt van een aantal methodes die verschillende substappen vertegenwoordigen. Deze substappen kunnen per gamemodus verschillen, waardoor de implementatie hiervan in de subklasses komt te staan. Er zijn daarnaast een aantal stappen die basisimplementatie bevatten. Wannneer een gamemodus hier andere implementatie voor nodig heeft, kan een stap worden overschreven.

- **Factory method** - De klasse "Game" bevat een methode voor het creëren van een bord, waarop het spel wordt gespeeld. Elke gamemodus kan op een ander bordstructuur worden gespeeld, zo kan het bord van "Four player chess" een andere structuur hebben dan die van "Classical chess". Door een factory method toe te passen, kan in de klasse "Game" het bord worden gebruikt, zonder dat hiervan de eigenschappen en structuur bekend zijn.

- **Decorator** - Naast het uitvoeren van een move, kunnen er nog een aantal andere acties bij een stap moeten worden uitgevoerd. Zo zal bijvoorbeeld bij het castlen de toren ook moeten worden verplaatst en zullen er andere stukken moeten worden gecaptured bij een explosie in atomic chess. Een move kan daarom om deze functionaliteiten heen worden gewrapt, zodat alle functionaliteiten die bij een move horen achter elkaar kunnen worden uitgevoerd en verschillende decorators makkelijk functionaliteit kunnen toevoegen.

- **Composite** - Elk schaakstuk heeft zijn eigen bewegingen met behulp van movements. Een schaakstuk kan echter ook meerdere bewegingingsrichtingen hebben. Zo kan een koningin zowel in een rechte lijn bewegen als diagonaal. Deze twee bewegingen zijn aparte movements, maar met behulp van een compositeklasse kunnen ze als één beweging worden beschouwd en behandeld. 

Naast de bovengenoemde design patterns is er gebruikgemaakt van MVVM om data te kunnen binden op views. Om ervoor te zorgen dat databinding werkt, is er een observable klasse gemaakt. In deze klasse zijn twee methodes aanwezig die subscribers inlichten over bepaalde veranderingen van properties. Door één van deze methodes aan te roepen in de juiste property zal databinding in de views werken.
