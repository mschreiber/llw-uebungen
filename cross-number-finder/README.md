<h1>Cross-Number-Finder</h1>

<h2>Aufgabe 1</h2>
<p>
Erstelle ein Programm, das in der Kommandozeile aufgerufen werden kann und folgende Aufgabe übernimmt:
<ul>
<li> -Es soll möglich sein, eine beliebige Textdatei anzugeben (Pfadangabe und/oder per Command Line Parameter).</li>
<li> -Das Programm soll die Textdatei lesen und pro Zeile die Quersumme der Zahlen berechnen. Ist die Quersumme größer als 100, soll sie ausgegeben werden.
</ul>

<p>
Beispiel Textdatei:
<code>
1134347777793132433244
9119338274664832248847
9988987678988909877337
1234554345665433345632
</code>
In diesem Beispiel sind die Quersummen: 
<code>
Zeile 1: 
1+1+3+4+3+4+7+7+7+7+7+9+3+1+3+2+4+3+3+2+4+4=98
Zeile 2: 109
Zeile 3: 157
Zeile 4: 86
</code>
Somit sind Zeile 2 und Zeile 3 die Gesuchten, weil dort die Quersumme größer als 100 ist.
</p>
<p>
Beispiel Aufruf und Ergebnis:
<code>
   C:\>NumberFinder.exe C:\daten\datei1.txt
</code>
Geforderte Ausgabe:
<code>
Quersummen von Datei C:\daten\datei1.txt:
Zeile 2: 109
Zeile 3: 157
</code>

</p>
</p>

<h2>Aufgabe 2</h2>
<p>
Verändere das Programm, dass pro Zeile ausgegeben wird, ab welcher Stelle die Quersumme von 50 erreicht bzw. überschritten wird und zusätzlich welche Zeile die Zeile ist, bei der die Quersumme von 50 
am schnellsten erreicht wurde. Sind mehrere Zeilen gleich schnell bei der Quersumme von 50, soll die erste Zeile bei der das der Fall ist, ausgegeben werden.
<p>
Beispiel mit dem obigen Input:
<code>
Zeile 1: 1+1+3+4+3+4+7+7+7+7+7 -> 51, somit ist hier die Grenze überschritten und das sind somit 11 Zahlen: Ergebnis somit 11
Zeile 2: 9+1+1+9+3+3+8+2+7+4+6 -> 53, somit ist hier die Grenze auch bei 11 Zahlen überschritten: Ergegebnis somit auch 11
Zeile 3: 9+9+8+8+9+8 -> 51, somit ist hier die Grenze schon nach 6 Zahlen überschritten: Ergebnis 6
Zeile 4: 1+2+3+4+5+5+4+3+4+5+6+6+5 -> 53, somit ist hier die Grenze nach 13 Zahlen überschritten: Ergebnis somit 13
Zeile 3 ist die Zeile, bei der die Quersumme am schnellsten erreicht wurde.
</code>
Ausgabe soll somit so aussehen:
<code>
Zeile 1: 11
Zeile 2: 11
Zeile 3: 6
Zeile 4: 13

Zeile 3 ist die Zeile, die am schnellsten die 50 erreicht hat
</code>
</p>
</p>
<h2>Aufgabe 3:</h2>
<p>
Erweitere das Programm, dass die Anzahl der Zahlen bis zur Quersumme von 50 oder mehr irgendwo (z.B. Datenbank) persisiert und der Input Datei zugeordnet werden (C:\daten\datei1.txt). Damit soll es möglich sein, das Programm mit mehreren verschiedenen Input Dateien hintereinander aufzurufen.
Im Konsolen Programm soll es dadurch möglich sein, eine Statistik über alle Dateien zu erstellen. Die Statistik soll ausgeben:<br>
<ul>
<li>In welcher Datei wurde die Quersumme am schnellsten erreicht</li>
<li>Wieviele Zeichen/Zahlen braucht es pro Datei durchschnittlich bis die >=50 erreicht werden</li>
<li>In welcher Datei wurde in Zeile 1 am meisten Zeichen/Zahlen gebraucht um die Grenze zu erreichen</li>
</ul>
</p>
