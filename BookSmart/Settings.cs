using Mutagen.Bethesda.Synthesis.Settings;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.WPF.Reflection.Attributes;
using Noggog;

namespace BookSmart
{
    class Settings
    {
        // Which labels to add
        [SynthesisOrder]
        [SettingName("Ajouter le tag compétence")]
        [SynthesisTooltip("Ajoutez le tag de compétence au nom du livre si le livre enseigne une compétence.")]
        public bool addSkillLabels = true;
        //public bool ajouterTagCompetences = true;
        
        [SynthesisOrder]
        [SettingName("Ajouter le tag marqueur de carte")]
        [SynthesisTooltip("Ajoutez le tag marqueur de carte au nom du livre si le livre enseigne des marqueurs de carte.")]
        public bool addMapMarkerLabels = true;
        //public bool ajouterTagMarqueurDeCarte = true;

        [SynthesisOrder]
        [SettingName("Ajouter le tag quête")]
        [SynthesisTooltip("Ajoute le tag quête au nom du livre si celui-ci est utilisé dans une quête.")]
        public bool addQuestLabels = true;
        //public bool ajouterTagQuetes = true;

        [SynthesisOrder]
        [SettingName("Les livres liés à un script sont des livres de quête")]
        [SynthesisTooltip("Part du principe que tout LIVRE lié à un script est un livre de quête. Peut marquer incorrectement certains livres. Améliorera la détection des livres de mods qui utilisent leurs propres scripts.")]
        public bool assumeBookScriptsAreQuests = false;
        //public bool lesLivresAvecSriptsSontDesLivresDeQuetes = false;
        

        // Label Position
        public enum LabelPosition
        {
            Avant,
            Après
        }

        [SynthesisOrder]
        [SynthesisSettingName("Position du tag")]
        [SynthesisTooltip("Où placer le tag lors de la création du nouveau nom.")]
        public LabelPosition labelPosition { get; set; } = LabelPosition.Avant;

        // Label Format
        public enum LabelFormat
        {
            Étoiles,
            Court,
            Long
        }

        [SynthesisOrder]
        [SynthesisSettingName("Format du tag")]
        [SynthesisTooltip("Étoile: *BookName\r\nCourt: <Alch> BookName\r\nLong: <Alchemy> BookName")]
        public LabelFormat labelFormat { get; set; } = LabelFormat.Long;

        // Encapsulating Characters
        public enum EncapsulatingCharacters
        {
            Parenthèses,
            Accolades,
            Crochets,
            Chevrons,
            Étoiles           
        }

        [SynthesisOrder]
        [SynthesisSettingName("Caractères d'encapsulation")]
        [SynthesisTooltip("Les caractères entourant le nom de la compétence.\r\nParenthèses: ()\r\nAccolades: {}\r\nCrochets: []\r\nChevrons: <>\r\nÉtoiles: *")]
        public EncapsulatingCharacters encapsulatingCharacters { get; set; } = EncapsulatingCharacters.Crochets;
    }
}
