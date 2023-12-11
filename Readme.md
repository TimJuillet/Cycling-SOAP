# Projet Biking

## Ce qui est fait

- Client java avec map qui prend deux lieux en entrée, et affiche le tracée
- On considère que les vélos vont à 15km/h, et la marche à 5km/h, puis on calcul le chemin le plus rapide entre uniquement la marche, et marche jusqu'à la station la plus proche, vélo jusqu'à la station la plus proche de l'arrivée, puis à nouveau marche jusq'à la destination.
- On calcul les 3 stations les plus proches des 2 points à vol d'oiseau, puis on calcul la vrai distance à pieds entre ces 3 stations et les points, et on prends la station la plus proche.
- Le cache garde une heure en mémoire l'état de toutes les stations, et met à jour lors de l'appel suivant.

## Ce qui n'est pas fait

- Pas d'activeMQ
- Pas de généricité sur le cache

## Comment lancer le projet

- Lancer launchFullServerSide.bat
- Lancer launchClientSide.bat
- Ecire le nom d'un lieu, entrer, puis le nom d'un autre lieu, entrer