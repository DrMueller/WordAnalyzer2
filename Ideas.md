# ToDos

## Cleanup

- Constants
- Parametereingabe für Dateiname
- Rules etc. zusammennehmen
- Testen gegen CAS_BGD Dokument


# Rule Checks

## Conventions

Wir müssen gewisse Tabellen und Abbildungen finden. Wir hardkodieren das auf Headers etc.
--> Nicht auf Wiederverwendbarkeit designen

## Allgemeines

Definierte Regeln, die lesend auf das Word Dokument zugreifen und prüfen

Regel besteht aus:

Kurzbezeichnung
Regel-Resultat
  - Fehlerbeschreibung
  - OK / nicht Ok

## Regeln


# Done

## Font prüfen

Hat der ganze Text die gleiche Font?

### Externe Links prüfen

Sind alle externen Links im Word-Dokument aufrufbar?

1. Link-Tabelle identifizieren
2. Links in der Link-Tabelle identifizieren
3. Alle Links aufrufen

### Tabellen haben Beschreibung oberhalb

1. Alle Tabellen identifizieren
2. Haben die Tabellen oberhalb eine Beschreibung

### Tabellen-Beschreibungen sind sortiert und starten mit Tabelle

1. Alle Tabellen identifizieren
2. Sind die Tabellen sortiert und starten mit "Tabelle:"

### Wörter im Glossar

Werden die Wörter im Glossar tatsächlich verwendet?

1. Glossar Tabelle identifizieren
2. Wörter in der Glossar Tabelle identifizieren
3. Wörter im Text Count > 1 (oder Glossar Tabelle ausschliessen)

# Nicht umgesetzt

## Interne Links prüfen

Sind alle internen Links innerhalb des Word-Dokuments?

1.Alle internen Links aufrufen
2. Zeigen diese Links auf das Word-Dokument?

### Abbildungen haben Beschreibung unterhalb

1. Alle Abbildungen identifizieren
2. Haben die Abbildungen unterhalb eine Beschreibung

### Abbildungen-Beschreibungen sind sortiert

1. Alle Abbildungen identifizieren
2. Sind die Abbildungen sortiert und starten mit "Abbildung:"

### Abbildungen sind im Abbildungsverzeichnis

1. Alle Abbildungen identifizieren
2. Abbildungsverzeichnis identidizieren
3. Stimmen die Abbildungsbeschreibungen zum Verzeichnis


### Tabellen sind im Tabellenverzeichnis

1. Alle Tabellen identifizieren
2. Tabellenverzeichnis identidizieren
3. Stimmen die Tabellenbeschreibungen zum Verzeichnis

### Seitenzahl prüfen

1. Alle Seitenzahlen prüfen
2. Sind diese laufend?


### LINK Sortierung

1. Alle LINK identifizieren
2. LINK Sortierung prüfen


### PIC sortiert

1. Alle PIC identifizieren
2. PIC Sortierung prüfen


### Externe Link LINK Verknüpfung

1. Link-Tabelle identifizieren
2. Links in der Link-Tabelle identifizieren
3. Passen diese überein?


### PIC in PIC Verzeichnis

1. Alle PIC identifizieren
2. PIC-Verzeichnis prüfen
3. Sind Alle PICs im PIC Verzeichnis
