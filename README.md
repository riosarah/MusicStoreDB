# MusicStore

------

**Lernziele**

- Diese Vorlage dient als Ausgangspunkt f�r verschiedenste Aufgaben.

## MusicStore

Das Projekt **'MusicStore'** ist ein kleines datenzentriertes Anwendungsbeispiel mit welchem die Erstellung eines Software-Systems dargestellt werden soll. Aufgrund der Komplexit�t, die ein Software-System im Allgemeinem darstellt, ist die Erstellung des Beispiels in mehreren Themenbereichen unterteilt. Jedes Thema beginnt mit dieser Vorlage und wird entsprechend der jeweiligen Aufgabenstellung erweitert. 

### Vorlage

In dieser Vorlage gibt es bereits zwei unterschliedliche Projekte:

|Name|Beschreibung|
|---|---|
|MusicStore.ConApp| Eine Konsolen-Anwendung zum Starten der Anwendung und Ausf�hrung des Programm-Men�s. Die entsprechenden Men�-Funktionen m�ssen implementiert werden und sind mit *throw new NotImplementedException()* markiert. |
|MusicStore.Logic| In diesem Projekt sind alle Schnittstellen und der Datenzugriff definiert. |
|MusicStore.Logic.Contracts| In diesem Abschnitt befinden sich alle Schnittstellen. |
|MusicStore.Logic.DataContext| In diesem Abschnitt befindet sich der Data-Kontext (`MusicStroeContext`). |

### Datenstruktur

Die Datenstruktur vom 'MusicStore' ist einfach und besteht im wesentlichen aus 4 Komponenten welche in der folgenden Tabelle zusammengefasst sind:

|Komponente|Beschreibung|Gr�sse|Mussfeld|Eindeutig|
|---|---|---|---|---|
|**Artist**|Der Artist interpretiert und komponiert unterschiedlichste Musik-Titeln. Diese werden in einer oder mehreren Sammlung(en) (Album) zusammengefasst.|
|*Name*|Name und des Artisten|1024|Ja|Ja|
|**Album**|Das Album beinhaltet eine Sammlung von Musik-Titeln (Track) und ist einem Artisten zugeortnet.|||
|*Title*|Titel des Albums|1024|Ja|Ja|
|*ArtistId*|Fremdsch�ssel zum Artisten|int|Ja|Nein|
|**Genre**|Das Genre definiert eine Musikrichtung und dient zur Klassifikation. Diese Information muss einem Musiktitel (Track) zugeordnet sein.|||
|*Name*|Name vom Genre|256|Ja|Ja|
|**Track**|Der Track definiert einen Musik-Titel und ist einem Album zugeordnet. �ber das Album kann der Artist ermittelt werden.|||
|*Title*|Titel des Musikst�ckes|1024|Ja|Nein|
|*Composer*|Komponist des Musikst�ckes|512|Nein|Nein|
|*Bytes*|Gr��e, in Bytes, des Titles|long|Ja|Nein|
|*Milliseconds*|Zeit des Titles|long|Ja|Nein|
|*UnitPrice*|Kosten des Titles|double|Ja|Nein|
|*GenreId*|Fremdsch�ssel zum Genre|int|Ja|Nein|
|*AlbumId*|Fremdsch�ssel zum Album|int|Ja|Nein|
|**Hinweis**|Alle Komponenten haben eine eindeutige Identit�t (Id)||||
|*|*Nat�rlich k�nnen noch weitere Attribute hinzugef�gt werden.*||||

Aus dieser Definition kann ein entsprechendes Objektmodell abgeleitet werden, welches nachfolgend skizziert ist:

![Objektmodel](img/MusicStore.png)

### Testen des Systems

�berpr�fen Sie die Daten mit Excel oder einem beliebigem Text-Editor!

## Hilfsmitteln

- keine Angaben

## Abgabe

- Termin: 1 Woche nach der Ausgabe

- Klasse:

- Name:

## Quellen

- keine Angabe

> **Viel Erfolg!**
"# MusicStoreDB" 
"# MusicStoreDB" 
