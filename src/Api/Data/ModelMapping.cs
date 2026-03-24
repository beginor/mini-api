using System;
using Beginor.AppFx.Core;
using Beginor.MiniApi.Data.Entities;
using Beginor.MiniApi.Models;

namespace Beginor.MiniApi.Data;

public class ModelMapping : AutoMapper.Profile {

    public ModelMapping() {
        CreateMap<CityEntity, CityModel>().ReverseMap();
    }

}
