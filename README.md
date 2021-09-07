# Syn Book Smart
Améliore les titres des livres pour afficher plus d'informations à leur sujet. Entièrement configurable.

## Paramètres
Tous les paramètres peuvent être configurés dans l'application Synthesis.

### Ajouter le tag compétence
Ajoute le nom de la compétence qu'un livre augmente, s'il est lié au script 'Teaches skill', ne fonctionnera pas sur les livres de mods qui n'utilisent pas ce script.

### Ajouter le tag marqueur de carte
Ajoute ce tag à tous les livres qui ajoutent un marqueur de carte via un script, à condition que le script soit lié au livre en lui même et contient "MapMarker" dans son nom. Will not apply to scripts belonging to the quest record instead of the book. This may be able to be improved in the future.

### Ajouter le tag quête
Ajoute un tag à tous les livres liés à une quête. Pour ce faire le patcher créera un cache des livres de quêtes à chaque lancement, ce qui allongera légèrement le temps d'exécution de synthesis. Ce cache scannera les quêtes à la recherche d'un alias faisant référence à un livre. Il scannera également les livres à la recherche d'un script lié contenant le mot 'Quest' dans son nom. Dans les deux si le scan est positif alors le livre sera taggé comme livre de quête.

### Position du tag
- Avant
  - `<Alchimie> Livre de potions de Snap`
- Après
  - `Livre de potions de Snap <Alchimie>`

### Format du tag
- Étoile
  - `*Livre de potions de Snap`
- Court
  - `<Alch> Livre de potions de Snap`
- Long
  - `<Alchimie> Livre de potions de Snap`

### Caractères d'encapsulation
This setting has no effect if a Label Format of `Star` is chosen.

- Parenthèses
  - `(Alch) Livre de potions de Snap`
- Accolades
  - `{Alch} Livre de potions de Snap`
- Crochets
  - `[Alch] Livre de potions de Snap`
- Chevrons
  - `<Alch> Livre de potions de Snap`
  - Si vous choisissez cette option le tag n'apparaîtra QUE dans votre inventaire.
- Étoiles
  - `*Alch* Livre de potions de Snap`

## Version à utiliser
0.30.4 et 0.19.2

# Crédits
Un très grand merci à Phlasriel qui a gentiment modifié le code pour qu'il fonctionne avec les particularités de la langue française.
