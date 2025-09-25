# App-Name: StempelApp

## Team: CyberGuardians

### Team-Aufgaben
Konzept und programmiertechnische Umsetzung aller Authentifizierung- und Autorisierung-Cases
- Rollen
- Verwaltung
- Login

### Rollen
|Name EN|Name DE|Berechtigungen|
|---|---|---|
|appAdmin|AppAdmin|- verwaltet ReinigungsAdmins<br>- Zugriff auf alle Daten|
|cleaningAdmin|ReinigungsAdmin|- verwaltet ReinigungsMitarbeiter<br>- verwaltet ReinigungsKunden|
|cleaningStaff|Reinigungskraft|- verwalten von seinen Aufträgen|
|buildingOwner|Immobilienbesitzer|- nur Ansicht|

### Views

- Passwort-Änderung
- Login
- appAdmin-Dashboard
- Firma anlegen/ändern
- reinigungsAdmin-Dashboard
- reinigungskraft-Dashboard
- buildingOwner-Dashboard


### Benötigte Tabellen/Spalten
- Personen
    - email (unique)
    - passwort (hash)
    - roleId
    - companyId
- Rollen
    - roleId
    - roleName

---

### Registrierungsvorgang

#### AppAdmin legt CleaningFirma + CleaningAdmin an
1. AppAdmin wählt "Neue Firma anlegen"  
1. Firmen-Daten in Formular eintragen
1. System erstellt neuen Benutzer mit Rolle = CleaningAdmin, Status = "inaktiv", ohne Passwort
1. System generiert Passwort-Reset-Token
1. System sendet E-Mail mit Einladungslink an CleaningAdmin

#### CleaningAdmin aktiviert Konto
1. CleaningAdmin erhält E-Mail mit Link
1. Klick auf Link → ResetPassword-Seite mit Token
1. Benutzer setzt eigenes Passwort
1. System markiert Benutzer = "aktiv"
1. Redirect → CleaningAdmin-Dashboard

#### CleaningAdmin legt CleaningStaff an
1. CleaningAdmin wählt "Mitarbeiter anlegen"
1. E-Mail + Name eingeben
1. System erstellt neuen Benutzer mit Rolle = CleaningStaff, Status = "inaktiv"
1. System generiert Passwort-Reset-Token
1. System sendet E-Mail mit Einladungslink an CleaningStaff

#### CleaningStaff aktiviert Konto
1. CleaningStaff klickt auf Einladungslink
1. Passwort selbst festlegen
1. Redirect → Mitarbeiter-Dashboard

#### CleaningAdmin legt BuildingOwner an
1. CleaningAdmin wählt "Gebäudebesitzer anlegen"
1. E-Mail + Name eingeben
1. System erstellt neuen Benutzer mit Rolle = BuildingOwner, Status = "inaktiv"
1. System generiert Passwort-Reset-Token
1. System sendet E-Mail mit Einladungslink an BuildingOwner

#### BuildingOwner aktiviert Konto
1. BuildingOwner klickt auf Einladungslink
1. Passwort selbst festlegen
1. Redirect → BuildingOwner-Dashboard

---

### Sonstiges
- Verwendung von Identity (CookieAuth)
- Passworthasher