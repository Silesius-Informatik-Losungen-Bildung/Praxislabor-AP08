# App-Name: StempelApp

## Team: CyberGuardians

### Team-Aufgaben
Konzept und programmiertechnische Umsetzung aller Authentifizierung- und Autorisierung-Cases
- Rollen
- Registrierung
- Login

### Rollen
|Name EN|Name DE|Berechtigungen|
|---|---|---|
|appAdmin|AppAdmin|- verwaltet ReinigungsAdmins<br>- Zugriff auf alle Daten|
|cleaningAdmin|ReinigungsAdmin|- verwaltet ReinigungsMitarbeiter<br>- verwaltet ReinigungsKunden|
|claeaningStaff|Reinigungskraft|varwalten von seinen Aufträgen|
|buildingOwner|ImmobilienBesitzer|Nur Ansicht|

### Views
- Registrierung
- Login
- appAdmin-Dashboard
- reinigungsAdmin-Dashboard
- reinigungskraft-Dashboard
- buildingOwner-Dashboard


### Benötigte Tabellen/Spalten
- Personen
    - email (unique)
    - passwort (hash)
    - salt?
    - roleId
    - companyId
- Rollen
    - roleId
    - roleName

---

### Sonstiges
- Verwendung von Identity
- optional: Pepper zum Hash hinzufügen
- IP-Adresse, Datum und Browser

### Registrierungsvorgang

#### AppAdmin legt CleaningFirma + CleaningAdmin an
[AppAdmin wählt "Neue Firma anlegen"]
      |
      v
[Firmen-Daten in Formular eintragen]
      |
      v
[System erstellt neuen Benutzer mit Rolle = CleaningAdmin, Status = "inaktiv", ohne Passwort]
      |
      v
[System generiert Passwort-Reset-Token]
      |
      v
[System sendet E-Mail mit Einladungslink an CleaningAdmin]

#### CleaningAdmin aktiviert Konto
[CleaningAdmin erhält E-Mail mit Link]
      |
      v
[Klick auf Link → ResetPassword-Seite mit Token]
      |
      v
[Benutzer setzt eigenes Passwort]
      |
      v
[System markiert Benutzer = "aktiv"]
      |
      v
[Redirect → CleaningAdmin-Dashboard]

#### CleaningAdmin legt CleaningStaff an
[CleaningAdmin wählt "Mitarbeiter anlegen"]
      |
      v
[E-Mail + Name eingeben]
      |
      v
[System erstellt neuen Benutzer mit Rolle = CleaningStaff, Status = "inaktiv"]
      |
      v
[System generiert Passwort-Reset-Token]
      |
      v
[System sendet E-Mail mit Einladungslink an CleaningStaff]

#### CleaningStaff aktiviert Konto
[CleaningStaff klickt auf Einladungslink]
      |
      v
[Passwort selbst festlegen]
      |
      v
[Redirect → Mitarbeiter-Dashboard]

#### CleaningAdmin legt BuildingOwner an
[CleaningAdmin wählt "Gebäudebesitzer anlegen"]
      |
      v
[E-Mail + Name eingeben]
      |
      v
[System erstellt neuen Benutzer mit Rolle = BuildingOwner, Status = "inaktiv"]
      |
      v
[System generiert Passwort-Reset-Token]
      |
      v
[System sendet E-Mail mit Einladungslink an BuildingOwner]

#### BuildingOwner aktiviert Konto
[BuildingOwner klickt auf Einladungslink]
      |
      v
[Passwort selbst festlegen]
      |
      v
[Redirect → BuildingOwner-Dashboard]
