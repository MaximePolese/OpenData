using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class Line
    {
        [JsonProperty("description")] public string Description { get; private set; }
        [JsonProperty("type")] public string Type { get; private set; }
        [JsonProperty("features")] public List<Feature> Features { get; private set; }

        public Line(string description, string type, List<Feature> features)
        {
            Description = description;
            Type = type;
            Features = features;
        }
    }

    public class Feature
    {
        [JsonProperty("type")] public string Type { get; private set; }
        [JsonProperty("properties")] public Properties Properties { get; private set; }
        [JsonProperty("description")] public string Description { get; private set; }
        [JsonProperty("geometry")] public Geometry Geometry { get; private set; }

        public Feature(string type, Properties properties, string description, Geometry geometry)
        {
            Type = type;
            Properties = properties;
            Description = description;
            Geometry = geometry;
        }
    }

    public class Properties
    {
        [JsonProperty("numero")] public string Numero { get; private set; }
        [JsonProperty("pmr")] public string Pmr { get; private set; }
        [JsonProperty("couleur")] public string Couleur { get; private set; }
        [JsonProperty("code")] public string Code { get; private set; }
        [JsonProperty("libelle")] public string Libelle { get; private set; }
        [JsonProperty("zonesArret")] public List<string> ZonesArret { get; private set; }
        [JsonProperty("type")] public string Type { get; private set; }
        [JsonProperty("lineId")] public string LineId { get; private set; }
        [JsonProperty("shape")] public string Shape { get; private set; }

        public Properties(string numero, string pmr, string couleur, string code, string libelle,
            List<string> zonesArret, string type, string lineId, string shape)
        {
            Numero = numero;
            Pmr = pmr;
            Couleur = couleur;
            Code = code;
            Libelle = libelle;
            ZonesArret = zonesArret;
            Type = type;
            LineId = lineId;
            Shape = shape;
        }
    }

    public class Geometry
    {
        [JsonProperty("type")] public string Type { get; private set; }
        [JsonProperty("coordinates")] public string Coordinates { get; private set; }

        public Geometry(string type, string coordinates)
        {
            Type = type;
            Coordinates = coordinates;
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
// }
}