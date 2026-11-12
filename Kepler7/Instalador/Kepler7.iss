; ============================================================
;  Instalador de Kepler-7  (Inno Setup 6.3+)
; ============================================================
#define MiApp      "Kepler-7"
#define MiVersion  "1.0.0"
#define MiExe      "Kepler7.Game.exe"

[Setup]
; GUID único de la app (no lo cambies entre versiones; las dobles llaves {{ son intencionales)
AppId={{099ACE7A-576B-4053-AF86-F6B206239F89}
AppName={#MiApp}
AppVersion={#MiVersion}
AppPublisher=Equipo Kepler-7

; --- Clave para la sala: instalar SIN administrador y en una carpeta con permiso de escritura ---
PrivilegesRequired=lowest
DefaultDirName={localappdata}\Programs\Kepler7

; El juego publicado es de 64 bits
ArchitecturesAllowed=x64compatible

DefaultGroupName={#MiApp}
DisableProgramGroupPage=yes
OutputDir=Salida
OutputBaseFilename=Kepler7_Setup
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
UninstallDisplayIcon={app}\{#MiExe}
; Si agregaste un ícono (paso 2.4), descomentá la línea siguiente:
; SetupIconFile=..\Kepler7.Game\kepler7.ico

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Todo el contenido de la carpeta publish (el runtime incluido), sin símbolos de depuración
Source: "..\publish\*"; DestDir: "{app}"; Excludes: "*.pdb,Kepler7.Core.xml"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\{#MiApp}"; Filename: "{app}\{#MiExe}"
Name: "{autodesktop}\{#MiApp}"; Filename: "{app}\{#MiExe}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MiExe}"; Description: "{cm:LaunchProgram,{#MiApp}}"; Flags: nowait postinstall skipifsilent
