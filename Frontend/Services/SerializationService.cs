﻿using DataStructures.SaveData;
using DataStructures.Serialization;
using Frontend.Core;

namespace Frontend.Services;

public class SerializationService : ObservableObject, ISerializationService
{
    public SerializationService(IEnumerable<ISerializer> serializers)
    {
        Serializers = serializers.ToList();
    }

    public void Serialize(object data)
    {
        var serializer = GetSerializer(data);
        var serialized = serializer.Serialize(data);
    }

    public object Deserialize(string serialized, Type targetType)
    {
        var deserializer = GetDeserializer(targetType);
        var data = deserializer.Deserialize(serialized, targetType);
        return data;
    }

    private ISerializer GetDeserializer(Type targetType)
    {
        var possibleSerializers = Serializers.Where(s => s.ProvideType() == targetType);
        if (possibleSerializers.Count() > 1)
            throw new InvalidOperationException($"Found more than one serializer that is able to deserialize '{targetType}'!");
        if (possibleSerializers.Count() == 0)
            throw new InvalidOperationException($"Found no serializer that is able to deserialize '{targetType}', but there should be one!");

        return possibleSerializers.Single();
    }

    private ISerializer GetSerializer(object data)
    {
        var type = data.GetType();
        var possibleSerializers = Serializers.Where(s => s.CanSerialize(type));
        if (possibleSerializers.Count() > 1)
            throw new InvalidOperationException($"Found more than one serializer that is able to serialize {type}!");
        if (possibleSerializers.Count() == 0)
            throw new InvalidOperationException($"Found no serializer that is able to serialize {type}, but there should be one!");

        return possibleSerializers.Single();
    }

    public IList<ISerializer> Serializers
    {
        get { return _serializers; }
        set { SetValue(ref _serializers, value); }
    }

    private IList<ISerializer> _serializers = [];
}
