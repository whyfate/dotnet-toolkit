namespace Whyfate.Toolkit.Domain;

public interface IEntityId { }

public readonly struct IntId : IEntityId { public int Value { get; init; } }
public readonly struct LongId : IEntityId { public long Value { get; init; } }
public readonly struct StringId : IEntityId { public string Value { get; init; } }
public readonly struct GuidId : IEntityId { public Guid Value { get; init; } }