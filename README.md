
#  Système de Contrôle d'Accès Sécurisé (SAS)


## Présentation du Projet

Conception et réalisation d'un système de sécurité critique pour la gestion d'un SAS d'accès. Le système assure l'interverrouillage des portes, l'identification des personnels via une base de données centralisée et la journalisation des événements.


## Expertise Technique

• Langages : C# (.NET / UWP), XAML (Interface IHM), SQL.
• Système embarqué : Windows IoT Core sur Raspberry Pi.
• Modélisation : Analyse fonctionnelle via SysML (Block Definition Diagram).
• Réseau : Communication client-serveur via Sockets TCP/IP.

## Fonctionnalités Clés

• Automate à 14 États : Gestion rigoureuse des cycles d'entrée/sortie et des priorités de passage.
• Gestion des Exceptions matérielles :
• Filtrage Debounce : Anti-rebond logiciel sur les capteurs GPIO.
• Fail-Safe : Timer de sécurité de 10s pour prévenir le blocage du SAS en cas d'abandon de cycle.
• Traçabilité : Envoi de trames structurées au serveur pour archivage en base de données (Logs).

## Contenu du Dépôt

• /src : Code source C# (Modularisé par service : Hardware, Network, Logic).
• /docs : Diagrammes SysML, schémas de câblage et dossier technique.
• Config.txt : Fichier de paramétrage dynamique du système.
