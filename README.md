Úvod 

Povolené charaktery na zašifrování i na klíč: abcdefghijklmnopqrstuvwxyz1234567890.,:-?@ 
Z těchto charakterů je poté složená zašifrovaná zpráva. 
Pokud jsou v textu nepovolené charaktery, v zašifrované verzi jsou vynechány (čau -> au). 
Klíč může být jedno-charakterový, ale čím delší bude, tím lepší. Doporučuji 4 a více charakterů. S krátkými klíči se v zašifrované verzi často opakují písmena. 
Veškerá velká písmena jak v klíči, tak v textu budou při šifraci převedena na malá. 
Jakékoli šifrování i odšifrování automaticky ukládá výsledný text do textové schránky. 
Pro extra zabezpečení lze zašifrovat již zašifrovaný text. Výsledný text bude delší a bezpečnější, hlavně když při druhém kroku použijete jiný klíč. 



První Krok – Morseova abeceda 

Písmena jsou oddělena mezerou, slova jsou oddělena lomítkem. Tečky, čárky a ostatní speciální znaky mají své vlastní znaky. 
V prvním kroku se celý text převede do Morseovy abecedy přes třídu MorseCodeConverter. 
Tato třída obsahuje 2 metody a jeden slovník. 
Součástí slovníku jsou převody všech používaných charakterů na jejich ekvivalenty v morseovce. 
První funkce, nazvaná EncodeToMorseCode,  vrací text přepsaný do Morseovy abecedy. 
Druhá funkce, DecodeFromMorseCode, dělá přesný opak. 
Tato část šifrování je jediná, která nevyužívá klíče. 

Ukázka funkce 

Vstupní text 
text na zasifrovani 
Výstupní text 
- . -..- - / -. .- / --.. .- ... .. ..-. .-. --- ...- .- -. .. 
 


Druhý Krok – Morseova abeceda do písmen 

Tuto část šifrování řeší funkce morseCharsToText, pro dešifraci slouží morseCharsToTextBack. 
Obě funkce vyžadují vstupní text a klíč. 
Nejdříve se přes funkci keyArr() vygenerují čísla odpovídající pořadí v abecedě.

Funkce keyArr() 

Navrací pole čísel. 
Tyto čísla jsou ekvivalentní pozici v abecedě, a začíná na 0 
Ukázka: 
Klíč: klic 
Návrat funkce: 10, 11, 8, 2 

Je definován int alphabetIndex, který počítá, odkud z abecedy se budou brát písmena. 
Tento proces proběhne pro každé písmenko v textu: 
Do alphabetIndex je přidáno číslo v současném místě keyArr. 
Pokud je první písmeno v klíči c, keyArr vrátí 2 a alphabetIndex se posune o 2.  
Z místa alphabetIndex se do výstupu připíše současné písmenko, pokud je v textu mezera, o písmeno dál pro tečku, o dvě dál pro pomlčku a o tři dál pro lomítko. 
AlphabetIndex se v prvním opakování posune o jedno místo a bude na 1, a pokud bude v textu -, vepíše se do výsledku d, protože pomlčka je posun o dvě v abecedě. 


Ukázka funkce 
Vstupní text, klíč: klic 
- . -..- - / -. .- / --.. .- ... .. ..-. .-. --- ...- .- -. .. 
Výstupní text 
mv56bltw5bhmt7-?jv27-kst4-gjr4,-gs12:hqr1:fgp3.:eqy1,enqy,cdoz7 



Třetí Krok – Prohození písmen 

Funkce alphabetGen vygeneruje spřeházenou abecedu podle klíče. 
Tato abeceda má každý charakter originální, bez toho by byl text nedešifrovatelný. 
Způsob generace abecedy: 
Funkce vezme právě určující písmeno, převede ho do čísel podle seřazení a přidá k němu číslo z keyArr (vysvětlen výše), výsledek se převede zpět do charakteru v té pozici.
Pokud je tento charakter už použitý, vezme se charakter v pořadí za ním, dokud se nenajde vhodný charakter. 
Způsob prohazování písmen: 
Funkce switchString bere jako argumenty text na zpřeházení a zpřeházenou abecedu z alphabetGen.

Funkce AlphabetGen 

Vstupní klíč:  
pampeliska 
Vygenerovaná abeceda: 
pbosiqrztykx2u13948v7.50,c:a6@d-eflgj?mnhw 
Původní abeceda: 
abcdefghijklmnopqrstuvwxyz1234567890.,:-?@ 
Poté projede celým textem a prohazuje písmena z originální abecedy za jejich ekvivalenty v zpřeházené abecedě. 
 

Ukázka funkce 

Vstupní text, klíč: klic 
mv56bltw5bhmt7-?jv27-kst4-gjr4,-gs12:hqr1:fgp3.:eqy1,enqy,cdoz7 
Výstupní text
w6?amu58?msw5@hjt6,@hv35:hqt1:ghq30,fs210foqz-efp290gpy29glnx.

Závěr 

Naprogramování šifry jsem očekával obtížnější. Chtěl bych udělat i něco obtížnějšího, ale nenapadl mě žádný lepší způsob zašifrování. 
Proces programování mě bavil a neměl jsem moc potíží. Rozdělení kódu na jednotlivé funkce udělalo kód velmi snadný na debuggování.  
