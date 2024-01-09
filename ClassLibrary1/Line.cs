using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class Properties
    {
        [JsonProperty("NUMERO")] public string NUMERO { get; set; }
        [JsonProperty("PMR")] public string PMR { get; set; }
        [JsonProperty("COULEUR")] public string COULEUR { get; set; }
        [JsonProperty("CODE")] public string CODE { get; set; }
        [JsonProperty("LIBELLE")] public string LIBELLE { get; set; }
        [JsonProperty("ZONES_ARRET")] public List<string> ZONES_ARRET { get; set; }
        [JsonProperty("type")] public string type { get; set; }
        [JsonProperty("id")] public string id { get; set; }
        [JsonProperty("shape")] public string shape { get; set; }
    }

    public class Geometry
    {
        [JsonProperty("type")] public string type { get; set; }
        [JsonProperty("coordinates")] public List<List<List<double>>> coordinates { get; set; }
    }

    public class Feature
    {
        [JsonProperty("type")] public string type { get; set; }
        [JsonProperty("properties")] public Properties properties { get; set; }
        [JsonProperty("description")] public string description { get; set; }
        [JsonProperty("geometry")] public Geometry geometry { get; set; }
    }

    public class Line
    {
        [JsonProperty("description")] public string description { get; set; }
        [JsonProperty("type")] public string type { get; set; }
        [JsonProperty("features")] public List<Feature> features { get; set; }
    }
}
//     {
//     "description": "Fichier de description des lignes de transport en commun",
//     "type": "FeatureCollection",
//     "features": [
//     {
//         "type": "Feature",
//         "properties": {
//             "NUMERO": "Nom de la ligne, par exemple: 'C1'",
//             "PMR": "'1' pour accéssible aux PMR, '0' sinon",
//             "COULEUR": "Couleur du logo et du tracé de la ligne, par exemple: '255,224,0'",
//             "CODE": "Code de la ligne, par exemple: 'SEM_C1'",
//             "LIBELLE": "Libellé de la ligne, par exemple: 'GRENOBLE JEAN MACÉ - MEYLAN MAUPERTUIS'",
//             "ZONES_ARRET": [
//             "Liste des arrêts de la ligne, par exemple:",
//             "SEM_GENCITEMACE",
//             "SEM_GENARAGO",
//             "SEM_GENEMILGUEY",
//             "..."
//                 ],
//             "type": "ligne",
//             "id": "Id de la ligne, par exemple: SEM_C1",
//             "shape": "donnée polyligne encodée uniquement pour l'URL http://data.mobilites-m.fr/api/lines/json, par exemple 'et}rGegkb@TILEBEJMl@UJIBC`A{@BATAl'"
//         },
//         "description": "Géométrie de la ligne",
//         "geometry": {
//             "type": "MultiLineString",
//             "coordinates": "Tableau de lati-longi décrivant la ligne, par exemple: [[[5.797151, 45.212985], [5.797198, 45.212885], [5.80, 45.22]]] uniquement pour l'URL http://data.mobilites-m.fr/api/lines/json"
//         }
//     }
//     ]
