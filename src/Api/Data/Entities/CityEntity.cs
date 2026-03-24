using System;
using NHibernate.Mapping.Attributes;
using Beginor.AppFx.Core;

namespace Beginor.MiniApi.Data.Entities;

/// <summary>Table, cities</summary>
[Class(Schema = "public", Table = "cities")]
public partial class CityEntity : BaseEntity<long> {

    /// <summary>id, int8</summary>
    [Id(Name = nameof(Id), Column = "id", Type = "long", Generator = "trigger-identity")]
    public override long Id { get { return base.Id; } set { base.Id = value; } }

    /// <summary>name, varchar</summary>
    [Property(Name = nameof(Name), Column = "name", Type = "string", NotNull = false, Length = 64)]
    public virtual string? Name { get; set; }

    /// <summary>population, int4</summary>
    [Property(Name = nameof(Population), Column = "population", Type = "int", NotNull = false)]
    public virtual int? Population { get; set; }

}
