# Weather Monitor beadandó

## Feladat: Időjárás figyelő készítése

Készítsünk alkalmazást időjárás-megfigyeléseink feldolgozásához.

### 24.1 Elvárások, főbb funkciók
Az adatokat két forrásból szerezzük be: **egy belső és egy külső mérő berendezés adatait**
**rögzítjük**. A benti adatok: a *rögzítés időpontja (óra, perc is)*, *hőmérséklet*, *páratartalom*.
A külső eszköz által gyűjtött adatok: *rögzítés időpontja*, *hőmérséklet*, *légnyomás*, *csapadék*
mennyiség.
A bevitt adatok utólagos **módosítását**, **törlését** is tegyük lehetővé.

Készítsünk listázási lehetőséget, ami megjeleníti
- adott időszak összes adatát,
- adott időszak csak belső / külső adatait,
- adott időszakon belül eső napok átlaghőmérsékleteinek (dátum / átlag hőmérséklet)
értékeit,
- adott időszak külső és belső hőmérsékletét, grafikusan is jelölve, hogy a belső vagy a
külső hőmérséklet volt magasabb.

Készítsünk vonaldiagramot, ami egy kiválasztott időintervallumban megjeleníti mind a külső
mind a belső hőmérsékleteket.

Készítsünk diagramot, ami adott intervallumon belüli napok, egy napon belül számított átlag
hőmérsékleteit jeleníti meg. 