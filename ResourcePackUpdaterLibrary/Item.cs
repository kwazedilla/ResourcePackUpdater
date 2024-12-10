using System.Text.Json.Serialization;

namespace ResourcePackUpdaterLibrary;

/*
{
    "model": {
        "type": "minecraft:model",
        "model": "horizonsend:[path of original file, no extension]"
    }
} 
 */

/**
 * Class for storing deserialized JSON data
 */
internal class Item
{
    [JsonInclude][JsonPropertyName("model")] internal ModelInst? Model { get; set; }

    internal class ModelInst
    {
        [JsonInclude][JsonPropertyName("type")] internal string? Type { get; set; }

        [JsonInclude][JsonPropertyName("model")] internal string? Model { get; set; }
    }
}